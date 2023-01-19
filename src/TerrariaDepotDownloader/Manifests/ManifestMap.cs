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

namespace TerrariaDepotDownloader.Manifests;
public class VersionManifests : IOrderedEnumerable<TerrariaManifest>
{
    private static Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
    private static readonly string ManifestMapFile = Path.Combine(Path.GetDirectoryName(CurrentAssembly.Location), "VersionManifests.json");
    public IReadOnlyDictionary<DynamicVersion, TerrariaManifest> Map => _Map;
    private SortedDictionary<DynamicVersion, TerrariaManifest> _Map { get; set; }
    public TerrariaManifest this[string ExtendedVersion] => this[new DynamicVersion(ExtendedVersion)];
    public TerrariaManifest this[DynamicVersion ExtendedVersion] => this[ExtendedVersion];
    public bool IsValid { get; private set; }

    public IEnumerable<DynamicVersion> Keys => Map.Keys;

    public IEnumerable<TerrariaManifest> Values => Map.Values;

    public int Count => Map.Count;

    public VersionManifests()
    {
        _Map = ReadManifestMap();
        IsValid = Validate();
    }

    private bool Validate()
    {
        if (Map == null) return false;
        if (Map.Count == 0) return false;
        return true;
    }

    private SortedDictionary<DynamicVersion, TerrariaManifest> ReadManifestMap()
    {
        IDictionary<string, string> data;
        if (TryReadManifestMapFile(out var map))
            data = map;
        else
            data = ReadEmbeddedManifestMap();
        var converted = data.Select(x => new TerrariaManifest(new DynamicVersion(x.Key), ulong.Parse(x.Value)));
        var sorted = converted.ToSortedDictionary(m => m.Version, DynamicVersion.DefaultComparer);
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

    public IOrderedEnumerable<TerrariaManifest> CreateOrderedEnumerable<TKey>(Func<TerrariaManifest, TKey> keySelector, IComparer<TKey> comparer, bool descending)
    {
        if (descending)
            return Map.Values.OrderByDescending(keySelector, comparer);
        else
            return Map.Values.OrderBy(keySelector, comparer);
    }
    public IEnumerator<TerrariaManifest> GetEnumerator() => Map.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
