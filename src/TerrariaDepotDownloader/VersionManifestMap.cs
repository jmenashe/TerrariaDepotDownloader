using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Reflection;
using Octokit;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Specialized;

namespace TerrariaDepotDownloader;
public class VersionManifests : IOrderedEnumerable<KeyValuePair<ExtendedVersion, string>>
{
    private static Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
    private static readonly string ManifestMapFile = Path.Combine(Path.GetDirectoryName(CurrentAssembly.Location), "VersionManifests.json");
    public IReadOnlyDictionary<ExtendedVersion, string> Map => this._Map;
    private SortedDictionary<ExtendedVersion, string> _Map { get; set; }
    public string this[string ExtendedVersion] => this[new ExtendedVersion(ExtendedVersion)];
    public string this[ExtendedVersion ExtendedVersion] => this[ExtendedVersion];
    public bool IsValid { get; private set; }

    public IEnumerable<ExtendedVersion> Keys => this.Map.Keys;

    public IEnumerable<string> Values => this.Map.Values;

    public int Count => this.Map.Count;

    public VersionManifests()
    {
        this._Map = this.ReadManifestMap();
        this.IsValid = this.Validate();
    }

    private bool Validate()
    {
        if (this.Map == null) return false;
        if (this.Map.Count == 0) return false;
        return true;
    }

    private SortedDictionary<ExtendedVersion, string> ReadManifestMap()
    {
        IDictionary<string, string> data;
        if (this.TryReadManifestMapFile(out var map))
            data = map;
        else
            data = this.ReadEmbeddedManifestMap();
        var sorted = new SortedDictionary<ExtendedVersion, string>();
        foreach (var key in data.Keys)
            sorted.Add(new ExtendedVersion(key), data[key]);
        return sorted;
    }
    private bool TryReadManifestMapFile(out Dictionary<string, string> map)
    {
        map = null;
        if (!File.Exists(ManifestMapFile))
            return false;
        using var stream = File.OpenRead(ManifestMapFile);
        using var reader = new StreamReader(stream);
        string content = reader.ReadToEnd();
        map = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
        return true;
    }
    private Dictionary<string, string> ReadEmbeddedManifestMap()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"{CurrentAssembly.GetName().Name}.Resources.VersionManifests.json";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream);
        string content = reader.ReadToEnd();
        var deserialized = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
        return deserialized;
    }

    public IOrderedEnumerable<KeyValuePair<ExtendedVersion, string>> CreateOrderedEnumerable<TKey>(Func<KeyValuePair<ExtendedVersion, string>, TKey> keySelector, IComparer<TKey> comparer, bool descending)
    {
        if(descending)
            return this.Map.OrderByDescending(keySelector, comparer);
        else
            return this.Map.OrderBy(keySelector, comparer);
    }
    public IEnumerator<KeyValuePair<ExtendedVersion, string>> GetEnumerator() => this.Map.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
