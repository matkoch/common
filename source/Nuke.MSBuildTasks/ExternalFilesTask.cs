// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTasks
{
    public static class TaskItemExtensions
    {
        public static string GetMetadataOrNull(this ITaskItem taskItem, string metdataName)
        {
            return taskItem.MetadataNames.Cast<string>().Contains(metdataName)
                ? taskItem.GetMetadata(metdataName)
                : null;
        }
    }

    [UsedImplicitly]
    public class ExternalFilesTask : ContextAwareTask
    {
        private static readonly string[] s_predefined =
        {
            "Visible",
            "FullPath",
            "RootDir",
            "Filename",
            "Extension",
            "RelativeDir",
            "Directory",
            "RecursiveDir",
            "Identity",
            "ModifiedTime",
            "CreatedTime",
            "AccessedTime",
            "DefiningProjectFullPath",
            "DefiningProjectDirectory",
            "DefiningProjectName",
            "DefiningProjectExtension"
        };

        [Microsoft.Build.Framework.Required]
        public ITaskItem[] ExternalFiles { get; set; }

        public int Timeout { get; set; }

        protected override bool ExecuteInner()
        {
            return ExternalFiles
                .Select(x => DownloadExternalFile(x, Timeout))
                .ToList()
                .All(x => x.Result);
        }

        public async Task<bool> DownloadExternalFile(ITaskItem externalFile, int timeout)
        {
            var externalFileUri = externalFile.GetMetadata("Identity");
            var externalFileBasePath = NormalizePath(Combine(EnvironmentInfo.WorkingDirectory, externalFile.GetMetadataOrNull("BasePath")));

            var tokens = externalFile
                .MetadataNames.Cast<string>()
                .Except(s_predefined)
                .ToDictionary(TemplateUtility.GetTokenName, externalFile.GetMetadata);

            try
            {
                foreach (var (uri, outputRelativePath) in GetExternalFilePairs(externalFileUri))
                {
                    var outputPath = Path.Combine(externalFileBasePath, outputRelativePath);
                    var previousHash = File.Exists(outputPath) ? FileSystemTasks.GetFileHash(outputPath) : null;

                    var template = (await HttpTasks.HttpDownloadStringAsync(uri.OriginalString)).SplitLineBreaks();
                    File.WriteAllLines(outputPath, TemplateUtility.FillTemplate(template, tokens));

                    var newHash = FileSystemTasks.GetFileHash(outputPath);
                    if (newHash != previousHash)
                        LogWarning(message: $"External file '{outputPath}' has been updated.", file: externalFileUri);
                }

                return true;
            }
            catch (Exception exception)
            {
                LogError(message: exception.Message, file: externalFileUri);
                return false;
            }

            // var client = new GitHubClient(new ProductHeaderValue(nameof(NukeBuild)));
            // var repo = await client.Repository.Get("nuke-build", "nuke");
            // var treeResponse = await client.Git.Tree.GetRecursive("nuke-build", "nuke", repo.DefaultBranch);
            //
            // treeResponse.Tree
            //     .Where(x => x.Type == TreeType.Blob)
            //     .ForEach(x => Logger.Info(x.Path));
        }

        // https://github.com/nuke-build/common/tree/develop/source/Nuke.GlobalTool/templates
        // https://github.com/nuke-build/common/blob/develop/source/Nuke.GlobalTool/templates/_build.sdk.csproj
        // https://raw.githubusercontent.com/nuke-build/common/develop/source/Nuke.GlobalTool/templates/_build.sdk.csproj
        private IEnumerable<(Uri Uri, string OutputPath)> GetExternalFilePairs(string externalFileUri)
        {
            var regex = new Regex(@"^https://github.com/(?'owner'[\w-]+)/(?'user'[\w-]+)/(?'method'(blob|tree)+)/(?'path'.+)$");
            var match = regex.Match(externalFileUri);
            if (match.Success)
            {
                if (match.Groups["method"].Value == "blob")
                    yield return $"https://raw.githubusercontent.com///{match.Groups["path"].Value}";
            }


            ControlFlow.Assert(Uri.TryCreate(externalFileUri, UriKind.RelativeOrAbsolute, out var uri),
                $"Could not parse URI for external file from first line of '{externalFileUri}'.");

            var fileName = uri.Segments.Last();
            yield return (uri, fileName);
        }
    }
}
