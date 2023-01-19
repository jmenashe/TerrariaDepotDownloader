using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace TerrariaDepotDownloader
{
    public partial class MainForm : Form
    {
        public VersionManifests VersionManifests { get; private set; }

        #region Main Code
        public MainForm()
        {
            InitializeComponent();
            Console.SetOut(new MultiTextWriter(new ControlWriter(rtbLog), Console.Out));
            this.VersionManifests = new VersionManifests();
        }

        // Do Loading Events
        public ToolTip Tooltips = new ToolTip();
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Varify .NET 6.0 Or Later Exists - Update 1.8.3
            var dotnet86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\dotnet\host\fxr";
            var dotnet64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\dotnet\host\fxr";
            var dotnet86SDK = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\dotnet\sdk";
            var dotnet64SDK = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\dotnet\sdk";

            // Check If A Single Paths Exists
            if (!Directory.Exists(dotnet86) && !Directory.Exists(dotnet64) && !Directory.Exists(dotnet86SDK) && !Directory.Exists(dotnet64SDK))
            {
                MessageBox.Show(".NET 6.0 Is Required! Please Install And Try Agian. \n \n https://dotnet.microsoft.com/download/dotnet/6.0", "ERROR: TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // Close Application
                Application.Exit();
            }

            // Check Value
            try
            {
                // Create A List For Versions
                List<String> versionList = new List<string> { };

                // Check If x86 Path Exists
                if (Directory.Exists(dotnet86))
                {
                    // Add Folder Names To List
                    foreach (string version in Directory.GetDirectories(dotnet86).Select(Path.GetFileName).ToArray())
                    {
                        // Remove Any "-" From Name
                        versionList.Add(version.Split('-')[0]);
                    }
                }

                // Check If x64 Path Exists
                if (Directory.Exists(dotnet64))
                {
                    // Add Folder Names To List
                    foreach (string version in Directory.GetDirectories(dotnet64).Select(Path.GetFileName).ToArray())
                    {
                        // Remove Any "-" From Name
                        versionList.Add(version.Split('-')[0]);
                    }
                }

                // Check If x86 SDK Path Exists
                if (Directory.Exists(dotnet86SDK))
                {
                    // Add Folder Names To List
                    foreach (string version in Directory.GetDirectories(dotnet86SDK).Select(Path.GetFileName).ToArray())
                    {
                        // Remove Any "-" From Name
                        versionList.Add(version.Split('-')[0]);
                    }
                }

                // Check If x64 SDK Path Exists
                if (Directory.Exists(dotnet64SDK))
                {
                    // Add Folder Names To List
                    foreach (string version in Directory.GetDirectories(dotnet64SDK).Select(Path.GetFileName).ToArray())
                    {
                        // Remove Any "-" From Name
                        versionList.Add(version.Split('-')[0]);
                    }
                }

                // Check If Version Is Above or Equal 6.0.0
                if (!versionList.Any(x => Version.Parse(x) >= Version.Parse("6.0.0")))
                {
                    // Log .NET Version
                    Console.WriteLine("ERROR: Highest .NET version found: " + versionList.Max());

                    // Version Not Found
                    MessageBox.Show(".NET 6.0+ is required! Please install and try agian. \n \n https://dotnet.microsoft.com/download/dotnet/6.0 \n \n Highest .NET version found: " + versionList.Max(), "ERROR: TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    // Close Application
                    Application.Exit();
                }
                else
                {
                    // Log .NET Version
                    if (Properties.Settings.Default.LogActions) // Checkbox Not Initilized Yet
                    {
                        Console.WriteLine("Highest .NET version found: " + versionList.Max());
                    }
                }
            }
            catch (Exception)
            {
                // Error, No Updated Manifests
                MessageBox.Show("Unable to check .NET version!", "ERROR: TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Close Application
                Application.Exit();
            }

            // Load Steam Textbox Data
            txtAccountName.Text = Properties.Settings.Default.SteamUser;
            txtPassword.Text = Properties.Settings.Default.SteamPass;

            // Create Depot Folder
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "TerrariaDepots")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "TerrariaDepots"));
                Properties.Settings.Default.DepotPath = Path.Combine(Application.StartupPath, "TerrariaDepots");
            }
            txtBaseDepotDir.Text = Path.Combine(Application.StartupPath, "TerrariaDepots");

            // Populate Depot Setting Path
            if (Directory.Exists(Path.Combine(Application.StartupPath, "TerrariaDepots")) && Properties.Settings.Default.DepotPath == "")
            {
                // Check If Overwrite Steam Directory Is Enabled
                if (cbxOverwriteStreamDir.Checked)
                {
                    // Overwrite Steam Directory Enabled
                    Properties.Settings.Default.DepotPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\Terraria";
                }
                else
                {
                    // Overwrite Steam Directory Disabled
                    Properties.Settings.Default.DepotPath = Path.Combine(Application.StartupPath, "TerrariaDepots");
                }
            }

            // Update Depot Path & Create Folder
            txtBaseDepotDir.Text = Properties.Settings.Default.DepotPath;
            if (!Directory.Exists(Properties.Settings.Default.DepotPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.DepotPath);
            }

            // Update Checkboxes
            cbxLogActions.Checked = Properties.Settings.Default.LogActions;
            cbxOverwriteStreamDir.Checked = Properties.Settings.Default.OverwriteSteam;
            cbxShowTooltips.Checked = Properties.Settings.Default.ToolTips;
            cbxSkipUpdateCheck.Checked = Properties.Settings.Default.SkipUpdate;

            // Add Tooltips - Update 1.8.5
            Tooltips.InitialDelay = 1000;
            Tooltips.SetToolTip(btnClose, "Close game and application");
            Tooltips.SetToolTip(btnLaunch, "Download / Launch Terraria version");
            Tooltips.SetToolTip(btnReloadList, "Reload all installed versions");
            Tooltips.SetToolTip(btnClearLog, "Clear log of all entries");
            Tooltips.SetToolTip(btnRemoveApp, "Remove selected version");
            Tooltips.SetToolTip(btnBrowse, "Browse for a new install directory");
            Tooltips.SetToolTip(btnShow, "Temporarily show your password");
            Tooltips.SetToolTip(btnRemoveAll, "Remove all games from the list");
            Tooltips.SetToolTip(btnOpenDepots, "Open current base directory");

            Tooltips.SetToolTip(cbxLogActions, "Log all actions to the output log");
            Tooltips.SetToolTip(cbxOverwriteStreamDir, "All installs overwrites Steam directory");
            Tooltips.SetToolTip(cbxShowTooltips, "Show or hide tooltips");
            Tooltips.SetToolTip(cbxSkipUpdateCheck, "Skip API update check");

            // Enable or Disable Tooltips
            if (cbxShowTooltips.Checked)
            {
                // Enable Tooltips
                Tooltips.Active = true;
            }
            else
            {
                // Disable Tooltips
                Tooltips.Active = false;
            }

            // Update Buttons
            btnBrowse.Enabled = Properties.Settings.Default.PathChangeEnabled;

            RefreshManifestList();

            if(Properties.Settings.Default.SkipUpdate)
            {
                if (cbxLogActions.Checked)
                    Console.WriteLine("DepotDownloader API new vesion check was skipped!");
                return;
            }
            await this.CheckDepotDownloaderApi();
            //try
            //{
            //    await this.CheckDepotDownloaderApi();
            //}
            //catch (Exception ex)
            //{
            //    // Error Checking Version
            //    Console.WriteLine("ERROR: Unable to check DepotDownloader API's Github version!");
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        private async Task CheckDepotDownloaderApi()
        {                
            // Check Github For DepotDownloader Update
            Octokit.GitHubClient client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("DepotDownloader"));
            var releases = await client.Repository.Release.GetAll("SteamRE", "DepotDownloader");
            var latestGithubRelease = releases[0].TagName;

            // Get Current DepotDownload.dll Version
            var currentVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Application.StartupPath, "DepotDownloader.dll"));
            // Console.WriteLine(latestGithubRelease.ToString() + " | " + "DepotDownloader_" + currentVersionInfo.ProductVersion.ToString());

            // Do Version Check
            if (latestGithubRelease.ToString() != "DepotDownloader_" + currentVersionInfo.ProductVersion.ToString())
            {
                // New Version Found
                // Log Item
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine("New DepotDownloader API is available.");
                }

                // Ask For Install
                if (MessageBox.Show("You have an outdated version of the DepotDownloader API" + "\n" + "Do you wish to download and install the update?", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(Application.ExecutablePath)).FileVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Install Update
                    try
                    {
                        await this.InstallDepotDownloaderApi(client, releases);

                        // Log Item
                        if (cbxLogActions.Checked)
                        {
                            Console.WriteLine("DepotDownloader API has been download and installed successfully.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: DepotDownloader API download failed!");
                        return;
                    }
                }
                else
                {
                    // Update Was Declined
                    Console.WriteLine("WARN: DepotDownloader API update was declined.");
                    return;
                }
            }
            else
            {
                // No Update Needed
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine("DepotDownloader API is up to date.");
                }
                return;
            }
        }

        private async Task InstallDepotDownloaderApi(Octokit.GitHubClient client, IEnumerable<Octokit.Release> releases)
        {
            // Download From Github
            var firstReleaseId = releases.FirstOrDefault()?.Id;
            if (!firstReleaseId.HasValue)
                throw new ArgumentNullException($"No DepotDownloaderApi releases found.");
            var latestAsset = await client.Repository.Release.GetAllAssets("SteamRE", "DepotDownloader", firstReleaseId.Value);
            var uri = new Uri(latestAsset[0].BrowserDownloadUrl);
            var targetPath = Path.Combine(Application.StartupPath, @"Update.zip");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("user-agent", "Anything");
            var response = await httpClient.GetAsync(uri);
            using (var fs = new FileStream(targetPath, FileMode.OpenOrCreate))
            {
                await response.Content.CopyToAsync(fs);
            }

            // Extract ZIP Into Dir
            using var archive = new ZipFile(Path.Combine(Application.StartupPath, "Update.zip"));
            archive.ExtractAll(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);

            // Clean Up Files
            File.Delete(Path.Combine(Application.StartupPath, "Update.zip"));
            File.Delete(Path.Combine(Application.StartupPath, "DepotDownloader.exe"));
            File.Delete(Path.Combine(Application.StartupPath, "DepotDownloader.pdb"));
            File.Delete(Path.Combine(Application.StartupPath, "README.md"));
            File.Delete(Path.Combine(Application.StartupPath, "LICENSE"));

            // Task Finished
            MessageBox.Show("DepotDownloader API has been download and installed successfully.", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // Reload List
        private void btnReloadList_Click(object sender, EventArgs e)
        {
            RefreshManifestList();
            if (cbxLogActions.Checked)
            {
                Console.WriteLine("App list reloaded");
            }
        }

        public void RefreshManifestList()
        {
            lvVersionList.Items.Clear();

            // Check If Directory Contains A ChangeLog If Overwrite Steam Directory Is Enabled
            if (cbxOverwriteStreamDir.Checked)
            {
                // Check If Directory Contains A ChangeLog
                if (!File.Exists(Properties.Settings.Default.DepotPath + @"\changelog.txt"))
                {
                    File.WriteAllText(Properties.Settings.Default.DepotPath + @"\changelog.txt", "Empty Changelog!");
                    Console.WriteLine("No changelog file found in steam directory!");
                }
            }

            // Reset Controls
            btnLaunch.Text = "Download";
            btnRemoveApp.Enabled = false;

            if (!this.VersionManifests.IsValid)
            {
                MessageBox.Show("ERROR: Please update the manifest file!", "ERROR: TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }

            void addItem(ExtendedVersion version, string manifestId, bool exists)
            {
                string text = exists ? "Yes" : "No";
                var liData = new string[] { version.ToString(), manifestId, text };
                var item = new ListViewItem(liData);
                lvVersionList.Items.Add(item);
            }

            foreach (var versionManifest in this.VersionManifests)
            {
                var version = versionManifest.Key;
                var manifestId = versionManifest.Value;
                if (versionManifest.Key == new ExtendedVersion())
                    continue;
                if (string.IsNullOrWhiteSpace(versionManifest.Value))
                {
                    addItem(version, "(no manifest found)", false);
                    continue;
                }
                // Check If Overwrite Steam Directory Is Enabled
                if (cbxOverwriteStreamDir.Checked)
                {
                    var firstChangelogLine = File.ReadLines(Properties.Settings.Default.DepotPath + @"\changelog.txt").First();
                    var secondChangelogWord = firstChangelogLine.Split(" ").Skip(1).FirstOrDefault();
                    var depotGameVersion = new ExtendedVersion(secondChangelogWord);
                    if (depotGameVersion == version)
                        addItem(version, manifestId, true);
                    else
                        addItem(version, manifestId, false);
                }
                else
                {
                    // Check If Game Version Folder Exists
                    var versionPath = Path.Combine(Properties.Settings.Default.DepotPath, $"Terraria-v{version}");
                    if (Directory.Exists(versionPath))
                    {
                        // Check If Folder Is Not Empty - Update Feature
                        if (Directory.EnumerateFileSystemEntries(versionPath).Any())
                        {
                            // String Does Not Contain "null", Record Like Normal
                            addItem(version, manifestId, true);
                        }
                        else
                        {
                            // Delete Folder
                            Directory.Delete(versionPath, true);

                            // Log Item
                            if (cbxLogActions.Checked)
                            {
                                Console.WriteLine($"Removed empty folder: {versionPath}");
                            }
                            addItem(version, manifestId, false);
                        }
                    }
                    else
                    {
                        // String Does Not Contain "null", Record Like Normal
                        addItem(version, manifestId, false);
                    }
                }
            }
        }

        // Open Browse Dialogue
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtBaseDepotDir.Text = fbd.SelectedPath;
                    Properties.Settings.Default.DepotPath = fbd.SelectedPath;
                }
            }
        }

        // Close Games & Application
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Check For Any Open Clients
            if (Process.GetProcessesByName("Terraria").Length > 0)
            {
                // Is running
                foreach (var process in Process.GetProcessesByName("Terraria"))
                {
                    process.Kill();
                }
            }

            // Gather Steam Data
            Properties.Settings.Default.SteamUser = txtAccountName.Text;
            Properties.Settings.Default.SteamPass = txtPassword.Text;

            // Save Settings
            Properties.Settings.Default.Save();

            // Close Application
            Application.Exit();
        }

        // Form Closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Gather Steam Data
            Properties.Settings.Default.SteamUser = txtAccountName.Text;
            Properties.Settings.Default.SteamPass = txtPassword.Text;

            // Save Settings
            Properties.Settings.Default.Save();

            // Close Application
            Application.Exit();
        }

        // Clear Log
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            rtbLog.Update();
        }

        // Close Via ToolStrip
        private void miClose_Click(object sender, EventArgs e)
        {
            // Gather Steam Data
            Properties.Settings.Default.SteamUser = txtAccountName.Text;
            Properties.Settings.Default.SteamPass = txtPassword.Text;

            // Save Settings
            Properties.Settings.Default.Save();

            // Close Application
            Application.Exit();
        }

        // Open Info Tab
        private void miInfo_MouseUp(object sender, MouseEventArgs e)
        {
            // Open New Form2
            InfoForm frm2 = new InfoForm();
            frm2.ShowDialog();
        }

        // Show Password
        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\u0000';
        }

        // Hide Password
        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        // Open Context Menu
        private void lvVersionList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvVersionList.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        // Remove App Tool Via ToolStrip
        private void miRemoveApp_Click(object sender, EventArgs e)
        {
            // Check If Removal Is Avalible
            if (!btnRemoveApp.Enabled)
            {
                return;
            }

            // Disable If Overwrite Steam Directory Enabled
            if (cbxOverwriteStreamDir.Checked)
            {
                MessageBox.Show("You cannot use this feature while \"Overwrite Steam Directory\" feature is enabled.", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // Get Each Row
            foreach (ListViewItem itemRow in this.lvVersionList.Items)
            {
                // Get Selected Item
                if (itemRow.Focused)
                {
                    // Check If Already Downloaded
                    if (itemRow.SubItems[2].Text == "Yes")
                    {
                        // Check If Client Is Currently Running - Update 1.8.3
                        bool isRunning = Process.GetProcessesByName("Terraria").FirstOrDefault(p => p.MainModule.FileName.StartsWith(Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text, StringComparison.InvariantCultureIgnoreCase)) != default(Process);
                        if (isRunning)
                        {
                            // Is running
                            foreach (var process in Process.GetProcessesByName("Terraria"))
                            {
                                process.Kill();

                                // Log Item
                                if (cbxLogActions.Checked)
                                {
                                    Console.WriteLine("The Terraria process was killed to continue operations.");
                                }
                            }
                        }

                        // Delete Folder
                        Directory.Delete(Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text, true);

                        // Log Item
                        if (cbxLogActions.Checked)
                        {
                            Console.WriteLine("Removed: " + Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text);
                        }

                        // Update Forum
                        RefreshManifestList();
                    }
                }
            }
        }

        // Remove All Games
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // Check For Any Open Clients - Update 1.8.3
            if (Process.GetProcessesByName("Terraria").Length > 0)
            {
                // Is running
                foreach (var process in Process.GetProcessesByName("Terraria"))
                {
                    process.Kill();

                    // Log Item
                    if (cbxLogActions.Checked)
                    {
                        Console.WriteLine("Running game process was found and terminated.");
                    }
                }
            }

            // Disable If Overwrite Steam Directory Enabled
            if (cbxOverwriteStreamDir.Checked)
            {
                MessageBox.Show("You cannot use this feature while \"Overwrite Steam Directory\" feature is enabled.", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // Conformation Box
            if (MessageBox.Show("Remove All Games?\nYes or No", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                // Get Each Row
                foreach (ListViewItem itemRow in this.lvVersionList.Items)
                {
                    // Check If Already Downloaded
                    if (itemRow.SubItems[2].Text == "Yes")
                    {
                        // Delete Folder
                        Directory.Delete(Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text, true);

                        // Log Item
                        if (cbxLogActions.Checked)
                        {
                            Console.WriteLine("Removed: " + Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text);
                        }
                    }
                }
                // Update Forum
                RefreshManifestList();

                // Log Item
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine("All apps removed");
                }
            }
        }

        private void launchVersion(ListViewItem selectedRow)
        {
            string version = selectedRow.SubItems[0].Text;
            string workingDir = Path.Combine(Properties.Settings.Default.DepotPath, $"Terraria-v{version}");
            string changelogPath = Path.Combine(Properties.Settings.Default.DepotPath, "changelog.txt");
            string exePath = Path.Combine(workingDir, "Terraria.exe");
            try
            {
                if (cbxOverwriteStreamDir.Checked)
                    Process.Start("steam://rungameid/105600");
                else
                {
                    Process startPath = new Process();
                    startPath.StartInfo.WorkingDirectory = workingDir;
                    startPath.StartInfo.FileName = exePath;
                    startPath.Start();
                }

                // Do Logging If Enabled
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine($"Successfully launched Terraria v{version}");
                }
            }
            catch (Exception error)
            {
                // Log Item
                Console.WriteLine($"Failed to launch Terraria v{version}: {error.Message}");
            }
            btnLaunch.Enabled = false;
        }
        private void downloadVersion(ListViewItem selectedRow)
        {
            // Check If User & Pass Are Populated
            if (txtAccountName.Text != "" && txtPassword.Text != "")
            {
                // Check If Already Downloaded
                if (selectedRow.SubItems[2].Text == "No")
                {
                    // Disable Button
                    btnLaunch.Enabled = false;

                    // Select Tab Control
                    // tabControl1.SelectedIndex = 2;

                    // Download Version
                    String DLLLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DepotDownloader.dll";
                    String DotNetLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\dotnet\dotnet.exe";
                    // Update 1.5.0, Check If Everwrite To Steam Directory Is Enabled
                    String OutDir = Properties.Settings.Default.DepotPath + @"\Terraria-v" + selectedRow.SubItems[0].Text;
                    if (cbxOverwriteStreamDir.Checked) // Overwrite Steam Directory
                    {
                        OutDir = Properties.Settings.Default.DepotPath;

                        // Check If Client Is Already Running - Update 1.8.3
                        bool isRunning = Process.GetProcessesByName("Terraria").FirstOrDefault(p => p.MainModule.FileName.StartsWith(OutDir, StringComparison.InvariantCultureIgnoreCase)) != default(Process);
                        if (isRunning)
                        {
                            // Is running
                            foreach (var process in Process.GetProcessesByName("Terraria"))
                            {
                                process.Kill();

                                // Log Item
                                if (cbxLogActions.Checked)
                                {
                                    Console.WriteLine("The Terraria process was killed to continue operations.");
                                }
                            }
                        }

                        // Delete Folder
                        Directory.Delete(OutDir, true);
                        Directory.CreateDirectory(OutDir); // Update 1.8.2 Fix
                    }
                    String ManifestID = selectedRow.SubItems[1].Text;
                    String EscapedPassword = Regex.Replace(txtPassword.Text, @"[%|<>&^]", @"^$&"); // Escape Any CMD Special Characters If Any Exist // Update 1.8.5.2 Fix
                    String Arg = "dotnet " + "\"" + DLLLocation + "\"" + " -app 105600 -depot 105601 -manifest " + ManifestID + " -username " + txtAccountName.Text + " -password " + EscapedPassword + " -dir " + "\"" + OutDir + "\"";

                    // Start Download
                    try
                    {
                        // Start Download Process
                        ExecuteCmd.ExecuteCommandAsync(Arg);

                        // Log Item
                        if (cbxLogActions.Checked)
                        {
                            Console.WriteLine("Download prompt started for Terraria-v" + selectedRow.SubItems[0].Text);
                        }
                    }
                    catch (Exception)
                    {
                        // Process Failed, Delete Folder
                        Directory.Delete(OutDir, true);
                        Directory.CreateDirectory(OutDir); // Update 1.8.2 Fix
                    }

                    // Reload List
                    RefreshManifestList();
                }
            }
            else
            {
                // Disable Button
                btnLaunch.Enabled = false;

                // Display Error
                Console.WriteLine("ERROR: Please enter steam username / password");
            }
        }
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var selectedRow = lvVersionList.SelectedItems.Cast<ListViewItem>().SingleOrDefault();
            if (selectedRow == null)
                return;

            // Check Options
            if (btnLaunch.Text == "Launch")
            {
                launchVersion(selectedRow);
            }
            else if (btnLaunch.Text == "Download")
            {
                downloadVersion(selectedRow);
            }
        }

        private void miDownloadApp_Click(object sender, EventArgs e)
        {
            // Get Each Row
            foreach (ListViewItem itemRow in this.lvVersionList.Items)
            {
                // Get Selected Item
                if (itemRow.Focused)
                {
                    // Check If User & Pass Are Populated
                    if (txtAccountName.Text != "" && txtPassword.Text != "")
                    {
                        // Check If Already Downloaded
                        if (itemRow.SubItems[2].Text == "No")
                        {
                            // Disable Button
                            btnLaunch.Enabled = false;

                            // Select Tab Control
                            // tabControl1.SelectedIndex = 2;

                            // Download Version
                            String DLLLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DepotDownloader.dll";
                            String DotNetLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\dotnet\dotnet.exe";
                            // Update 1.5.0, Check If Everwrite To Steam Directory Is Enabled
                            String OutDir = Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text;
                            if (cbxOverwriteStreamDir.Checked) // Overwrite Steam Directory
                            {
                                OutDir = Properties.Settings.Default.DepotPath;

                                // Check If Client Is Already Running - Update 1.8.3
                                bool isRunning = Process.GetProcessesByName("Terraria").FirstOrDefault(p => p.MainModule.FileName.StartsWith(OutDir, StringComparison.InvariantCultureIgnoreCase)) != default(Process);
                                if (isRunning)
                                {
                                    // Is running
                                    foreach (var process in Process.GetProcessesByName("Terraria"))
                                    {
                                        process.Kill();

                                        // Log Item
                                        if (cbxLogActions.Checked)
                                        {
                                            Console.WriteLine("The Terraria process was killed to continue operations.");
                                        }
                                    }
                                }

                                // Delete Folder
                                Directory.Delete(OutDir, true);
                                Directory.CreateDirectory(OutDir); // Update 1.8.2 Fix
                            }
                            String ManifestID = itemRow.SubItems[1].Text;
                            String EscapedPassword = Regex.Replace(txtPassword.Text, @"[%|<>&^]", @"^$&"); // Escape Any CMD Special Characters If Any Exist // Update 1.8.5.2 Fix
                            String Arg = "dotnet " + "\"" + DLLLocation + "\"" + " -app 105600 -depot 105601 -manifest " + ManifestID + " -username " + txtAccountName.Text + " -password " + EscapedPassword + " -dir " + "\"" + OutDir + "\"";

                            // Start Download
                            try
                            {
                                // Start Download Process
                                ExecuteCmd.ExecuteCommandAsync(Arg);

                                // Log Item
                                if (cbxLogActions.Checked)
                                {
                                    Console.WriteLine("Download prompt started for Terraria-v" + itemRow.SubItems[0].Text);
                                }
                            }
                            catch (Exception)
                            {
                                // Process Failed, Delete Folder
                                Directory.Delete(OutDir, true);
                                Directory.CreateDirectory(OutDir); // Update 1.8.2 Fix
                            }

                            // Reload List
                            RefreshManifestList();
                        }
                    }
                    else
                    {
                        // Disable Button
                        btnLaunch.Enabled = false;

                        // Display Error
                        Console.WriteLine("ERROR: Please enter steam username / password");
                    }
                }
            }
        }

        private void btnRemoveApp_Click(object sender, EventArgs e)
        {
            // Disable If Overwrite Steam Directory Enabled
            if (cbxOverwriteStreamDir.Checked)
            {
                MessageBox.Show("You cannot use this feature while \"Overwrite Steam Directory\" feature is enabled.", "TerrariaDepotDownloader v" + FileVersionInfo.GetVersionInfo(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath)).FileVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // Get Each Row
            foreach (ListViewItem itemRow in this.lvVersionList.Items)
            {
                // Get Selected Item
                if (itemRow.Focused)
                {
                    // Check If Already Downloaded
                    if (itemRow.SubItems[2].Text == "Yes")
                    {
                        // Check If Client Is Currently Running - Update 1.8.3
                        bool isRunning = Process.GetProcessesByName("Terraria").FirstOrDefault(p => p.MainModule.FileName.StartsWith(Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text, StringComparison.InvariantCultureIgnoreCase)) != default(Process);
                        if (isRunning)
                        {
                            // Is running
                            foreach (var process in Process.GetProcessesByName("Terraria"))
                            {
                                process.Kill();

                                // Log Item
                                if (cbxLogActions.Checked)
                                {
                                    Console.WriteLine("The Terraria process was killed to continue operations.");
                                }
                            }
                        }

                        // Delete Folder
                        Directory.Delete(Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text, true);

                        // Log Item
                        if (cbxLogActions.Checked)
                        {
                            Console.WriteLine("Removed: " + Properties.Settings.Default.DepotPath + @"\Terraria-v" + itemRow.SubItems[0].Text);
                        }

                        // Update Forum
                        RefreshManifestList();
                    }
                }
            }

            // Edit Button
            btnRemoveApp.Enabled = false;
        }

        private void btnOpenDepots_Click(object sender, EventArgs e)
        {
            try
            {
                // Open Folder
                Process.Start(Properties.Settings.Default.DepotPath);

                // Log Action
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine("Opened depot directory");
                }
            }
            catch (Win32Exception win32Exception)
            {
                //The system cannot find the file specified...
                Console.WriteLine(win32Exception.Message);
            }
        }

        private void cbxLogActions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLogActions.Checked)
            {
                Properties.Settings.Default.LogActions = true;
            }
            else if (!cbxLogActions.Checked)
            {
                Properties.Settings.Default.LogActions = false;
            }
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            rtbLog.SelectionStart = rtbLog.Text.Length;

            // scroll it automatically
            rtbLog.ScrollToCaret();
        }

        private void cbxOverwriteStreamDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOverwriteStreamDir.Checked && Properties.Settings.Default.OverwriteSteam == false)
            {
                // Show Warning
                if (MessageBox.Show("This will overwrite your game within steamapps." + "\n" + "Do you want to continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Cancle Prompt
                    cbxOverwriteStreamDir.Checked = false;

                    // Enable Path Changing
                    btnBrowse.Enabled = true;

                    // Update Settings
                    Properties.Settings.Default.OverwriteSteam = false;
                    Properties.Settings.Default.PathChangeEnabled = true;

                    // Update Forum

                    // Log Item
                    if (cbxLogActions.Checked)
                    {
                        Console.WriteLine("Overwrite steam directory mode cancled.");
                    }
                    RefreshManifestList();
                }
                else
                {
                    // Prompt Yes, Create Directory, Change Textbox
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\Terraria"))
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\Terraria");
                    }
                    txtBaseDepotDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\Terraria";

                    // Disable Path Changing
                    btnBrowse.Enabled = false;

                    // Update Settings
                    Properties.Settings.Default.DepotPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\Terraria";
                    Properties.Settings.Default.OverwriteSteam = true;
                    Properties.Settings.Default.PathChangeEnabled = false;

                    // Update Forum

                    // Log Item
                    if (cbxLogActions.Checked)
                    {
                        Console.WriteLine("Overwrite steam directory mode enabled!");
                    }
                    RefreshManifestList();
                }
            }
            if (!cbxOverwriteStreamDir.Checked && Properties.Settings.Default.OverwriteSteam == true)
            {
                // Checkbox Unchecked, Reset Textbox To Defualt Dir
                txtBaseDepotDir.Text = Path.Combine(Application.StartupPath, "TerrariaDepots");

                // Enable Path Changing
                btnBrowse.Enabled = true;

                // Update Settings
                Properties.Settings.Default.DepotPath = Path.Combine(Application.StartupPath, "TerrariaDepots");
                Properties.Settings.Default.OverwriteSteam = false;
                Properties.Settings.Default.PathChangeEnabled = true;

                // Update Forum

                // Log Item
                if (cbxLogActions.Checked)
                {
                    Console.WriteLine("Overwrite steam directory mode disabled!");
                }
                RefreshManifestList();
            }
        }

        private void cbxShowTooltips_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or Disable Tooltips
            if (cbxShowTooltips.Checked)
            {
                // Enable Tooltips
                Properties.Settings.Default.ToolTips = true;
                Tooltips.Active = true;
            }
            else
            {
                // Disable Tooltips
                Properties.Settings.Default.ToolTips = false;
                Tooltips.Active = false;
            }
        }

        private void cbxSkipUpdateCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or Disable Tooltips
            if (cbxSkipUpdateCheck.Checked)
            {
                // Enable Tooltips
                Properties.Settings.Default.SkipUpdate = true;
            }
            else
            {
                // Disable Tooltips
                Properties.Settings.Default.SkipUpdate = false;
            }
        }
        #endregion

        private void lvVersionList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var list = (ListView)sender;
            var selectedRow = list.SelectedItems.Cast<ListViewItem>().SingleOrDefault();
            if (selectedRow == null)
                return;

            // Check If Already Downloaded
            if (selectedRow.SubItems[2].Text == "Yes")
            {
                // Edit Launch Button
                btnLaunch.Enabled = true;
                btnLaunch.Text = "Launch";

                // Edit Remove Button
                btnRemoveApp.Enabled = true;
            }
            else if (selectedRow.SubItems[2].Text == "No")
            {
                // Edit Launch Button
                btnLaunch.Enabled = true;
                btnLaunch.Text = "Download";

                // Edit Remove Button
                btnRemoveApp.Enabled = false;
            }
            else if (selectedRow.SubItems[2].Text == "N/A")
            {
                btnLaunch.Text = "N/A";
                btnLaunch.Enabled = false;
            }
        }
    }
}
