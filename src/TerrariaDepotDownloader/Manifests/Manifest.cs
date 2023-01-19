using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaDepotDownloader.Manifests;
public record class Manifest
{
    public DynamicVersion Version { get; set; }
    public ulong ManifestID { get; set; }
    public virtual uint AppID { get; }
    public virtual uint DepotID { get; }
    public bool IsDownloaded { get; set; } = false;

    protected Manifest(DynamicVersion version, ulong manifestID, uint appID, uint depotID)
    {
        this.Version = version;
        this.ManifestID = manifestID;
        this.AppID = appID;
        this.DepotID = depotID;
    }

    public bool IsEmpty() => this.Version.IsEmpty() || this.ManifestID == 0 || this.AppID == 0 || this.DepotID == 0;
}
