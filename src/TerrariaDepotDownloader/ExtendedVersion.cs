using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaDepotDownloader;
public class ExtendedVersion : IComparable<ExtendedVersion>
{
    public const int DefaultVersionLength = 5;
    private List<int> VersionParts = new List<int>();
    public int Length => this.VersionParts.Count;

    public ExtendedVersion() : this(v: null, DefaultVersionLength) { }
    public ExtendedVersion(string v) : this(v, DefaultVersionLength) { }
    public ExtendedVersion(string v, int length)
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

    public int CompareTo(ExtendedVersion other)
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

    public override string ToString() => string.Join(".", this.VersionParts);
}
