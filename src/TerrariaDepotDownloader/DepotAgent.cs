using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerrariaDepotDownloader.Manifests;

namespace TerrariaDepotDownloader;
public static class DepotAgent
{
    public static async Task DownloadAppAsync(Manifest manifest, string username, string password, string outputDir)
    {
        var downloaderPath = Path.Combine(
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
            "DepotDownloader.exe"
        );
        var escPassword = Regex.Replace(password, @"[%|<>&^]", @"^$&");
        var args = new List<string> {
                "-app", manifest.AppID.ToString(),
                "-depot", manifest.DepotID.ToString(),
                "-manifest", manifest.ManifestID.ToString(),
                "-username", username,
                "-password", escPassword,
                "-dir", outputDir
            };
        var joinedArgs = string.Join(" ", args.Select((arg, index) =>
        {
            if (arg.StartsWith("-"))
                return arg;
            return $"\"{arg}\"";
        }));
        var startInfo = new ProcessStartInfo
        {
            FileName = downloaderPath,
            Arguments = joinedArgs
        };
        Process process = new Process
        {
            StartInfo = startInfo,
            EnableRaisingEvents = true
        };
        process.Start();
        await process.WaitForExitAsync();
    }
}
