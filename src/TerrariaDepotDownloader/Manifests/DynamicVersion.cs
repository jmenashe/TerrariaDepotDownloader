using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariaDepotDownloader.Manifests;

namespace TerrariaDepotDownloader;
public class DynamicVersion : IComparable<DynamicVersion>
{
    public class DynamicVersionComparer : IComparer<DynamicVersion>
    {
        public int Compare(DynamicVersion x, DynamicVersion y) => x.CompareTo(y);
    }
    public static readonly IComparer<DynamicVersion> DefaultComparer = new DynamicVersionComparer();
    public static readonly DynamicVersion Empty = new DynamicVersion();
    public const int DefaultVersionLength = 5;
    private List<int> VersionParts = new List<int>();
    public int Length => this.VersionParts.Count;

    public DynamicVersion() : this(v: null, DefaultVersionLength) { }
    public DynamicVersion(string v) : this(v, DefaultVersionLength) { }
    public DynamicVersion(string v, int length)
    {
        if(v == null)
            v = string.Empty;
        v = v.Trim();
        var parts = v.Split('.');
        if (parts.Length == 0)
        {
            this.VersionParts.Add(0);
            return;
        }
        for(int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i], out int iPart))
                this.VersionParts.Add(iPart);
            else
                this.VersionParts.Add(0);
        }
    }

    public int CompareTo(DynamicVersion other)
    {
        for(int i = 0; i < this.VersionParts.Count; i++)
        {
            int thisPart = this.VersionParts[i], otherPart = 0;
            if (i < other.VersionParts.Count)
                otherPart = other.VersionParts[i];
            var result = thisPart.CompareTo(otherPart);
            if (result != 0)
                return result;
        }
        for(int i = this.VersionParts.Count; i < other.VersionParts.Count; i++)
        {
            int thisPart = 0, otherPart = other.VersionParts[i];
            var result = thisPart.CompareTo(otherPart);
            if(result != 0) 
                return result;
        }
        return 0;
    }

    public bool IsEmpty() => this.CompareTo(Empty) == 0;

    public override string ToString() => string.Join(".", this.VersionParts);
}
