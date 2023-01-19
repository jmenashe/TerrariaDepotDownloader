using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TerrariaDepotDownloader.Manifests;
public record class TerrariaManifest : Manifest
{
    public const int TerrariaAppID = 105600;
    public const int TerrariaDepotID = 105601;
    public string DownloadDirectory => Path.Combine(Properties.Settings.Default.DepotPath, $"Terraria-v{this.Version}");
    public string ExecutablePath => Path.Combine(DownloadDirectory, "Terraria.exe");
    public bool IsRunning
    {
        get
        {
            var proc = Process.GetProcessesByName("Terraria").FirstOrDefault(p => p.MainModule.FileName.Equals(this.ExecutablePath, StringComparison.InvariantCultureIgnoreCase));
            bool isRunning = proc != default;
            return isRunning;
        }
    }
    public TerrariaManifest(DynamicVersion version, ulong manifestId)
        : base(version, manifestId, appID: TerrariaAppID, depotID: TerrariaDepotID)
    { }
}
