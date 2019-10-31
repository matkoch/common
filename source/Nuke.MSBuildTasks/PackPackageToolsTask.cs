// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class PackPackageToolsTask : ContextAwareTask
    {
        [Required]
        public string ProjectAssetsFile { get; set; }

        [Required]
        public string NuGetPackageRoot { get; set; }

        [Required]
        public string TargetFramework { get; set; }

        [Output]
        public ITaskItem[] TargetOutputs { get; set; }

        protected override bool ExecuteInner()
        {
            var assetFileContent = File.ReadAllText(ProjectAssetsFile);
            var reader = JsonReaderWriterFactory.CreateJsonReader(
                Encoding.UTF8.GetBytes(assetFileContent),
                new XmlDictionaryReaderQuotas());

            var root = XElement.Load(reader);
            var packages = root.XPathSelectElements("//libraries/*/path")
                .Select(x => x.Value.Split(new[] { "/" }, StringSplitOptions.None))
                .Select(x => new { Id = x[0], Version = x[1] }).ToList();

            TargetOutputs = packages.SelectMany(x => GetFiles(x.Id, x.Version)).ToArray();

            return true;
        }

        private IEnumerable<ITaskItem> GetFiles(string packageId, string packageVersion)
        {
            var packageToolsPath = Path.Combine(NuGetPackageRoot, packageId, packageVersion, "tools");
            if (!Directory.Exists(packageToolsPath))
                yield break;

            foreach (var file in Directory.GetFiles(packageToolsPath, "*", SearchOption.AllDirectories))
            {
                var taskItem = new TaskItem(file);
                taskItem.SetMetadata("BuildAction", "None");
                taskItem.SetMetadata("PackagePath",
                    Path.Combine(
                        "tools",
                        TargetFramework,
                        "any",
                        packageId,
                        GetRelativePath(packageToolsPath, file)));
                yield return taskItem;
            }
        }
    }
}
