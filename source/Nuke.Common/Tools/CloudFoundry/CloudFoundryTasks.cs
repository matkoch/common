// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Nuke.Common.Tooling;
using static Nuke.Common.IO.HttpTasks;
using static Nuke.Common.IO.FileSystemTasks;

namespace Nuke.Common.Tools.CloudFoundry
{
    public static partial class CloudFoundryTasks
    {

        public static string GetToolPath()
        {
            try
            {
                return ToolPathResolver.TryGetEnvironmentExecutable("CLOUDFOUNDRY_EXE") ??
                             ToolPathResolver.GetPathExecutable("cf");
            }
            catch
            {
            }
            
            var cliDir = NukeBuild.TemporaryDirectory / "cf-cli";
            var binary = cliDir / (Environment.OSVersion.Platform == PlatformID.Win32NT ? "cf.exe" : "cf");
            if (FileExists(binary))
                return binary;

            string releaseName;
            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                releaseName = Environment.Is64BitOperatingSystem ? "windows64-exe" : "windows32-exe";
            }
            else if(Environment.OSVersion.Platform == PlatformID.Unix)
            {
                releaseName = Environment.Is64BitOperatingSystem ? "linux64-binary" : "linux32-binary";
            }
            else if(Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                releaseName = "macosx64-binary";
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
            var archive = cliDir / "cf.archive";
            EnsureExistingDirectory(cliDir);
            HttpDownloadFile($"https://packages.cloudfoundry.org/stable?release={releaseName}", archive);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                ZipFile.ExtractToDirectory(archive, cliDir);
            }
            else
            {
                TarArchive.CreateInputTarArchive(new GZipInputStream(File.Open(archive, FileMode.Open))).ExtractContents(cliDir);
            }
            File.Delete(archive);
            return binary;
        }

        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance)
        {
            bool IsCreating()
            {    
                var commandResult = CloudFoundryGetServiceInfo(c => c
                        .SetServiceInstance(serviceInstance))
                    .First(x => x.Text.StartsWith("status:"))
                    .Text;
                var result = Regex.Match(commandResult, @"(?<=^status:\s+)[a-z].+", RegexOptions.Multiline).Value;
                return result == "create in progress";
            }
            
            while (IsCreating())
            {
                await Task.Delay(5000);
            }
        }
    }
    
}
