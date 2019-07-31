﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://docs.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml">official website</a>.
    /// <a href="https://github.com/Microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md">Azure Pipeline Tasks Documentation</a>
    /// </summary>
    [PublicAPI]
    [BuildServer]
    [ExcludeFromCodeCoverage]
    public class AzureDevOps
    {
        private static Lazy<AzureDevOps> s_instance = new Lazy<AzureDevOps>(() => new AzureDevOps());

        public static AzureDevOps Instance => NukeBuild.Host == HostType.AzureDevOps ? s_instance.Value : null;

        internal static bool IsRunningAzureDevOps => Environment.GetEnvironmentVariable("TF_BUILD") != null;

        internal static bool IsHostedAgent =>
            !string.IsNullOrWhiteSpace(Variable("AGENT_NAME")) && Variable("AGENT_NAME").StartsWith("Hosted");

        private readonly Action<string> _messageSink;
        private readonly string _tfBuildCommandFormat;

        internal AzureDevOps(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
            _tfBuildCommandFormat = "##vso[{0} {1}]{3}";
        }

        public string AgentBuildDirectory => Variable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => Variable("AGENT_HOMEDIRECTORY");
        public long AgentId => Variable<long>("AGENT_ID");
        public AzureDevOpsJobStatus AgentJobStatus => Variable<AzureDevOpsJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => Variable("AGENT_MACHINENAME");
        public string AgentName => Variable("AGENT_NAME");
        public string AgentWorkFolder => Variable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => Variable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => Variable<long>("BUILD_BUILDID");
        [NoConvert] public string BuildNumber => Variable<string>("BUILD_BUILDNUMBER");
        public string BuildUri => Variable("BUILD_BUILDURI");
        public string BinariesDirectory => Variable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => Variable("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => Variable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => Variable("BUILD_QUEUEDBY");
        public Guid QueuedById => Variable<Guid>("BUILD_QUEUEDBYID");
        public AzureDevOpsBuildReason BuildReason => Variable<AzureDevOpsBuildReason>("BUILD_REASON");
        public bool RepositoryClean => Variable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => Variable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => Variable("BUILD_REPOSITORY_NAME");
        public AzureDevOpsRepositoryType RepositoryProvider => Variable<AzureDevOpsRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        [CanBeNull] public string RepositoryTfvcWorkspace => Variable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => Variable("BUILD_REPOSITORY_URI");
        public string RequestedFor => Variable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => Variable("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => Variable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => Variable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => Variable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => Variable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => Variable("BUILD_SOURCEVERSION");
        public string StagingDirectory => Variable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => Variable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => Variable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => Variable("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => Variable("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => Variable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => Variable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => Variable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public long? PullRequestId => Variable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => Variable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => Variable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => Variable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => Variable("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => Variable<Guid>("SYSTEM_TEAMPROJECTID");

        public void UploadLog(string localFilePath)
        {
            _messageSink($"##vso[build.uploadlog]{localFilePath}");
        }

        public void UpdateBuildNumber(string buildNumber)
        {
            _messageSink($"##vso[build.updatebuildnumber]{buildNumber}");
        }

        public void AddBuildTag(string buildTag)
        {
            _messageSink($"##vso[build.addbuildtag]{buildTag}");
        }

        public void UploadAzureDevOpsArtifacts(string containerFolder, string artifactName, string packageDirectory)
        {
            _messageSink($"##vso[artifact.upload containerfolder={containerFolder};artifactname={artifactName};]{packageDirectory}");
        }

        public void PublishAzureDevOpsTestResults(
            IEnumerable<FileInfo> files,
            string title,
            bool mergeResults = false,
            string platform = "x64",
            string configuration = "Release",
            string testType = "VSTest")
        {
            var resultFiles = string.Join(",", files.Select(x => x.FullName.Replace('\\', Path.DirectorySeparatorChar)));
            _messageSink($"##vso[results.publish type={testType};mergeResults={mergeResults};platform={platform}4;config={configuration};runTitle='{title}';publishRunAttachments=true;resultFiles={resultFiles};]");
        }

        public void LogError(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzureDevOpsIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzureDevOpsIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogIssue(
            AzureDevOpsIssueType type,
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            var properties = $"type={GetText(type)};";
            if (!string.IsNullOrEmpty(sourcePath))
                properties += $"sourcepath={sourcePath};";

            if (!string.IsNullOrEmpty(lineNumber))
                properties += $"linenumber={lineNumber};";

            if (!string.IsNullOrEmpty(columnNumber))
                properties += $"columnnumber={columnNumber};";

            if (!string.IsNullOrEmpty(code))
                properties += $"code={code};";

            _messageSink($"##vso[task.logissue {properties}]{message}");
        }

        private string GetText(AzureDevOpsIssueType type)
        {
            switch (type)
            {
                case AzureDevOpsIssueType.Warning:
                    return "warning";
                case AzureDevOpsIssueType.Error:
                    return "error";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, message: null);
            }
        }
    }
}
