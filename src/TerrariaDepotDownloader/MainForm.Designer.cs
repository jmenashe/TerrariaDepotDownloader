
namespace TerrariaDepotDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvVersionList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDownloader = new System.Windows.Forms.TabPage();
            this.btnOpenDepots = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnReloadList = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxSkipUpdateCheck = new System.Windows.Forms.CheckBox();
            this.cbxLogActions = new System.Windows.Forms.CheckBox();
            this.cbxShowTooltips = new System.Windows.Forms.CheckBox();
            this.cbxOverwriteStreamDir = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBaseDepotDir = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.menuTop = new System.Windows.Forms.ToolStrip();
            this.miFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.miInfo = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoveApp = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDownloadApp = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabDownloader.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.menuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvVersionList
            // 
            this.lvVersionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVersionList.BackColor = System.Drawing.SystemColors.Window;
            this.lvVersionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.lvVersionList.FullRowSelect = true;
            this.lvVersionList.GridLines = true;
            this.lvVersionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvVersionList.Location = new System.Drawing.Point(0, 0);
            this.lvVersionList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvVersionList.Name = "lvVersionList";
            this.lvVersionList.Size = new System.Drawing.Size(629, 289);
            this.lvVersionList.TabIndex = 2;
            this.lvVersionList.UseCompatibleStateImageBehavior = false;
            this.lvVersionList.View = System.Windows.Forms.View.Details;
            this.lvVersionList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvVersionList_ItemSelectionChanged);
            this.lvVersionList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvVersionList_MouseClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Manifest ID";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Installed";
            this.columnHeader3.Width = 204;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDownloader);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ItemSize = new System.Drawing.Size(28, 28);
            this.tabControl1.Location = new System.Drawing.Point(14, 166);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(40, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 378);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDownloader
            // 
            this.tabDownloader.Controls.Add(this.btnOpenDepots);
            this.tabDownloader.Controls.Add(this.btnRemoveAll);
            this.tabDownloader.Controls.Add(this.btnReloadList);
            this.tabDownloader.Controls.Add(this.lvVersionList);
            this.tabDownloader.Location = new System.Drawing.Point(4, 32);
            this.tabDownloader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabDownloader.Name = "tabDownloader";
            this.tabDownloader.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabDownloader.Size = new System.Drawing.Size(634, 342);
            this.tabDownloader.TabIndex = 0;
            this.tabDownloader.Text = "Downloader";
            this.tabDownloader.UseVisualStyleBackColor = true;
            // 
            // btnOpenDepots
            // 
            this.btnOpenDepots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDepots.Location = new System.Drawing.Point(513, 297);
            this.btnOpenDepots.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOpenDepots.Name = "btnOpenDepots";
            this.btnOpenDepots.Size = new System.Drawing.Size(119, 33);
            this.btnOpenDepots.TabIndex = 4;
            this.btnOpenDepots.Text = "Open Depots";
            this.btnOpenDepots.UseVisualStyleBackColor = true;
            this.btnOpenDepots.Click += new System.EventHandler(this.btnOpenDepots_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAll.Location = new System.Drawing.Point(110, 297);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(119, 33);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnReloadList
            // 
            this.btnReloadList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadList.Location = new System.Drawing.Point(0, 297);
            this.btnReloadList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReloadList.Name = "btnReloadList";
            this.btnReloadList.Size = new System.Drawing.Size(103, 33);
            this.btnReloadList.TabIndex = 3;
            this.btnReloadList.Text = "Reload List";
            this.btnReloadList.UseVisualStyleBackColor = true;
            this.btnReloadList.Click += new System.EventHandler(this.btnReloadList_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox3);
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 32);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabSettings.Size = new System.Drawing.Size(634, 342);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxSkipUpdateCheck);
            this.groupBox3.Controls.Add(this.cbxLogActions);
            this.groupBox3.Controls.Add(this.cbxShowTooltips);
            this.groupBox3.Controls.Add(this.cbxOverwriteStreamDir);
            this.groupBox3.Location = new System.Drawing.Point(14, 197);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(606, 127);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // cbxSkipUpdateCheck
            // 
            this.cbxSkipUpdateCheck.AutoSize = true;
            this.cbxSkipUpdateCheck.Location = new System.Drawing.Point(7, 96);
            this.cbxSkipUpdateCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxSkipUpdateCheck.Name = "cbxSkipUpdateCheck";
            this.cbxSkipUpdateCheck.Size = new System.Drawing.Size(142, 20);
            this.cbxSkipUpdateCheck.TabIndex = 15;
            this.cbxSkipUpdateCheck.Text = "Skip Update Check";
            this.cbxSkipUpdateCheck.UseVisualStyleBackColor = true;
            this.cbxSkipUpdateCheck.CheckedChanged += new System.EventHandler(this.cbxSkipUpdateCheck_CheckedChanged);
            // 
            // cbxLogActions
            // 
            this.cbxLogActions.AutoSize = true;
            this.cbxLogActions.Checked = true;
            this.cbxLogActions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLogActions.Location = new System.Drawing.Point(7, 23);
            this.cbxLogActions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxLogActions.Name = "cbxLogActions";
            this.cbxLogActions.Size = new System.Drawing.Size(96, 20);
            this.cbxLogActions.TabIndex = 12;
            this.cbxLogActions.Text = "Log Actions";
            this.cbxLogActions.UseVisualStyleBackColor = true;
            this.cbxLogActions.CheckedChanged += new System.EventHandler(this.cbxLogActions_CheckedChanged);
            // 
            // cbxShowTooltips
            // 
            this.cbxShowTooltips.AutoSize = true;
            this.cbxShowTooltips.Checked = true;
            this.cbxShowTooltips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowTooltips.Location = new System.Drawing.Point(7, 47);
            this.cbxShowTooltips.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxShowTooltips.Name = "cbxShowTooltips";
            this.cbxShowTooltips.Size = new System.Drawing.Size(111, 20);
            this.cbxShowTooltips.TabIndex = 13;
            this.cbxShowTooltips.Text = "Show Tooltips";
            this.cbxShowTooltips.UseVisualStyleBackColor = true;
            this.cbxShowTooltips.CheckedChanged += new System.EventHandler(this.cbxShowTooltips_CheckedChanged);
            // 
            // cbxOverwriteStreamDir
            // 
            this.cbxOverwriteStreamDir.AutoSize = true;
            this.cbxOverwriteStreamDir.Location = new System.Drawing.Point(7, 72);
            this.cbxOverwriteStreamDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxOverwriteStreamDir.Name = "cbxOverwriteStreamDir";
            this.cbxOverwriteStreamDir.Size = new System.Drawing.Size(181, 20);
            this.cbxOverwriteStreamDir.TabIndex = 14;
            this.cbxOverwriteStreamDir.Text = "Overwrite Steam Directory";
            this.cbxOverwriteStreamDir.UseVisualStyleBackColor = true;
            this.cbxOverwriteStreamDir.CheckedChanged += new System.EventHandler(this.cbxOverwriteStreamDir_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtBaseDepotDir);
            this.groupBox2.Location = new System.Drawing.Point(14, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(606, 63);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base Depot Directory";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(512, 24);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(88, 27);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBaseDepotDir
            // 
            this.txtBaseDepotDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseDepotDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBaseDepotDir.Location = new System.Drawing.Point(10, 24);
            this.txtBaseDepotDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBaseDepotDir.Name = "txtBaseDepotDir";
            this.txtBaseDepotDir.ReadOnly = true;
            this.txtBaseDepotDir.Size = new System.Drawing.Size(494, 22);
            this.txtBaseDepotDir.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(14, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(606, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steam Login Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Name:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAccountName.Location = new System.Drawing.Point(130, 36);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(375, 22);
            this.txtAccountName.TabIndex = 10;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(512, 68);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(88, 27);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseDown);
            this.btnShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(130, 68);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(375, 22);
            this.txtPassword.TabIndex = 11;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.rtbLog);
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Location = new System.Drawing.Point(4, 32);
            this.tabLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(634, 342);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbLog.Size = new System.Drawing.Size(629, 289);
            this.rtbLog.TabIndex = 16;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearLog.Location = new System.Drawing.Point(0, 297);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(103, 33);
            this.btnClearLog.TabIndex = 17;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // menuTop
            // 
            this.menuTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miInfo});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(670, 27);
            this.menuTop.TabIndex = 4;
            this.menuTop.Text = "toolStrip1";
            // 
            // miFile
            // 
            this.miFile.AutoToolTip = false;
            this.miFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClose});
            this.miFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miFile.Image = ((System.Drawing.Image)(resources.GetObject("miFile.Image")));
            this.miFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFile.Name = "miFile";
            this.miFile.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.miFile.ShowDropDownArrow = false;
            this.miFile.Size = new System.Drawing.Size(46, 24);
            this.miFile.Text = "File";
            // 
            // miClose
            // 
            this.miClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miClose.Image = global::TerrariaDepotDownloader.Properties.Resources.CoolDown;
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(114, 24);
            this.miClose.Text = "Close";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // miInfo
            // 
            this.miInfo.AutoToolTip = false;
            this.miInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miInfo.Image = ((System.Drawing.Image)(resources.GetObject("miInfo.Image")));
            this.miInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miInfo.Name = "miInfo";
            this.miInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.miInfo.ShowDropDownArrow = false;
            this.miInfo.Size = new System.Drawing.Size(49, 24);
            this.miInfo.Text = "Info";
            this.miInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.miInfo_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(385, 554);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 61);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.Enabled = false;
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLaunch.Location = new System.Drawing.Point(524, 554);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(132, 61);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(14, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 130);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnRemoveApp
            // 
            this.btnRemoveApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveApp.Enabled = false;
            this.btnRemoveApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveApp.Location = new System.Drawing.Point(19, 554);
            this.btnRemoveApp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveApp.Name = "btnRemoveApp";
            this.btnRemoveApp.Size = new System.Drawing.Size(132, 61);
            this.btnRemoveApp.TabIndex = 5;
            this.btnRemoveApp.Text = "Remove App";
            this.btnRemoveApp.UseVisualStyleBackColor = true;
            this.btnRemoveApp.Click += new System.EventHandler(this.btnRemoveApp_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDownloadApp,
            this.miRemoveApp});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 48);
            // 
            // miDownloadApp
            // 
            this.miDownloadApp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miDownloadApp.Image = global::TerrariaDepotDownloader.Properties.Resources.Item_149;
            this.miDownloadApp.Name = "miDownloadApp";
            this.miDownloadApp.Size = new System.Drawing.Size(162, 22);
            this.miDownloadApp.Text = "Download App";
            this.miDownloadApp.Click += new System.EventHandler(this.miDownloadApp_Click);
            // 
            // miRemoveApp
            // 
            this.miRemoveApp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miRemoveApp.Image = global::TerrariaDepotDownloader.Properties.Resources.Trash;
            this.miRemoveApp.Name = "miRemoveApp";
            this.miRemoveApp.Size = new System.Drawing.Size(162, 22);
            this.miRemoveApp.Text = "Remove App";
            this.miRemoveApp.Click += new System.EventHandler(this.miRemoveApp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 629);
            this.Controls.Add(this.btnRemoveApp);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuTop);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(686, 559);
            this.Name = "MainForm";
            this.Text = "Terraria Depot Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDownloader.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvVersionList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDownloader;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip menuTop;
        private System.Windows.Forms.ToolStripDropDownButton miInfo;
        private System.Windows.Forms.ToolStripDropDownButton miFile;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnReloadList;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtBaseDepotDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveApp;
        private System.Windows.Forms.Button btnOpenDepots;
        private System.Windows.Forms.CheckBox cbxLogActions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxOverwriteStreamDir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miDownloadApp;
        private System.Windows.Forms.ToolStripMenuItem miRemoveApp;
        private System.Windows.Forms.CheckBox cbxShowTooltips;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxSkipUpdateCheck;
    }
}

