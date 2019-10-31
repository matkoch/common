// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.CodeGeneration;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class CodeGenerationTask : ContextAwareTask
    {
        [Microsoft.Build.Framework.Required]
        public ITaskItem[] SpecificationFiles { get; set; }

        [Microsoft.Build.Framework.Required]
        public string BaseDirectory { get; set; }

        public bool UseNestedNamespaces { get; set; }

        [CanBeNull]
        public string BaseNamespace { get; set; }

        public bool UpdateReferences { get; set; }

        protected override bool ExecuteInner()
        {
            var specificationFiles = SpecificationFiles.Select(x => x.GetMetadata("Fullpath")).ToList();
            var repository = ControlFlow.SuppressErrors(() => GitRepository.FromLocalDirectory(BaseDirectory));

            CodeGenerator.GenerateCode(
                specificationFiles,
                x =>
                    (PathConstruction.AbsolutePath) BaseDirectory
                    / (UseNestedNamespaces ? x.Name : ".")
                    / x.DefaultOutputFileName,
                x =>
                    !UseNestedNamespaces
                        ? BaseNamespace
                        : string.IsNullOrEmpty(BaseNamespace)
                            ? x.Name
                            : $"{BaseNamespace}.{x.Name}",
                x =>
                    repository.IsGitHubRepository() ? repository?.GetGitHubDownloadUrl(x.SpecificationFile) : null);

            if (UpdateReferences)
                ReferenceUpdater.UpdateReferences(specificationFiles);

            return true;
        }
    }
}
