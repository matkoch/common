// THIS FILE IS AUTO-GENERATED
// ITS CONTENT IS OVERWRITTEN WITH EXCEPTION OF MARKED USER BLOCKS

import jetbrains.buildServer.configs.kotlin.v2018_1.*
import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.*
import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.*
import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.*
import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.*

version = "2019.1"

// BEGIN USER FUNCTIONS
// END USER FUNCTIONS

project {
    // BEGIN USER MODIFICATIONS
    Announce.name = "🗣 Announce"
    Compile.name  = "⚙️ Compile"
    Pack.name     = "📦 Pack"
    Publish.name  = "🚚 Publish"
    Test.name     = "🚦 Test"
    // END USER MODIFICATIONS

    vcsRoot(VcsRoot)

    buildType(Compile)
    buildType(Pack)
    buildType(Test)
    buildType(Publish)
    buildType(Announce)

    buildTypesOrder = arrayListOf(Compile, Pack, Test, Publish, Announce)

    params {
        select("env.Verbosity",
            label = "Verbosity",
            description = "Logging verbosity during build execution. Default is 'Normal'.",
            options = listOf("Minimal" to "Minimal", "Normal" to "Normal", "Quiet" to "Quiet", "Verbose" to "Verbose"),
            value = "Normal",
            display = ParameterDisplay.NORMAL)
        select("env.Configuration",
            label = "Configuration",
            description = "Configuration to build - Default is 'Debug' (local) or 'Release' (server)",
            options = listOf("Debug" to "Debug", "Release" to "Release"),
            value = "Release",
            display = ParameterDisplay.NORMAL)
        text("env.Source",
            label = "Source",
            allowEmpty = true,
            value = "https://api.nuget.org/v3/index.json",
            display = ParameterDisplay.NORMAL)
        text("env.Solution",
            label = "Solution",
            description = "Path to a solution file that is automatically loaded.",
            allowEmpty = true,
            value = "nuke-common.sln",
            display = ParameterDisplay.NORMAL)
        text("env.GlobalToolProject",
            label = "GlobalToolProject",
            description = "Project from solution",
            allowEmpty = true,
            value = "source/Nuke.GlobalTool/Nuke.GlobalTool.csproj",
            display = ParameterDisplay.NORMAL)
        text("env.MSBuildTaskRunnerProject",
            label = "MSBuildTaskRunnerProject",
            description = "Project from solution",
            allowEmpty = true,
            value = "source/Nuke.MSBuildTaskRunner/Nuke.MSBuildTaskRunner.csproj",
            display = ParameterDisplay.NORMAL)
    }
}
object VcsRoot : GitVcsRoot({
    name = "https://github.com/nuke-build/common.git#refs/heads/develop"
    url = "https://github.com/nuke-build/common.git"
    branch = "refs/heads/develop"
    pollInterval = 60
    branchSpec = "+:refs/heads/*"
})
object Compile : BuildType({
    name = "Compile"
    vcs {
        root(VcsRoot)
    }
    steps {
        exec {
            path = "build.sh"
            arguments = "Restore Compile --skip"
        }
    }
})
object Pack : BuildType({
    name = "Pack"
    vcs {
        root(VcsRoot)
    }
    artifactRules = """
        +:output/*.nupkg
    """.trimIndent()
    steps {
        exec {
            path = "build.sh"
            arguments = "Pack --skip"
        }
    }
    triggers {
        vcs {
            branchFilter = ""
            triggerRules = "+:**"
        }
        schedule {
            schedulingPolicy = daily {
                hour = 3
                timezone = "Europe/Berlin"
            }
            branchFilter = ""
            triggerRules = "+:**"
            triggerBuild = always()
            withPendingChangesOnly = false
            enableQueueOptimization = false
            param("cronExpression_min","3")
        }
    }
    dependencies {
        snapshot(Compile) {
        }
    }
})
object Test : BuildType({
    name = "Test"
    vcs {
        root(VcsRoot)
    }
    steps {
        exec {
            path = "build.sh"
            arguments = "Test --skip"
        }
    }
    triggers {
        vcs {
            branchFilter = ""
            triggerRules = "+:**"
        }
        schedule {
            schedulingPolicy = daily {
                hour = 3
                timezone = "Europe/Berlin"
            }
            branchFilter = ""
            triggerRules = "+:**"
            triggerBuild = always()
            withPendingChangesOnly = false
            enableQueueOptimization = false
            param("cronExpression_min","3")
        }
    }
    dependencies {
        snapshot(Compile) {
        }
    }
})
object Publish : BuildType({
    name = "Publish"
    vcs {
        root(VcsRoot)
    }
    steps {
        exec {
            path = "build.sh"
            arguments = "Publish --skip"
        }
    }
    params {
        text("env.ApiKey",
            label = "ApiKey",
            description = "ApiKey for the specified source",
            value = "",
            display = ParameterDisplay.PROMPT)
        text("env.SlackWebhook",
            label = "SlackWebhook",
            description = "Slack webhook",
            value = "",
            display = ParameterDisplay.PROMPT)
        text("env.GitterAuthToken",
            label = "GitterAuthToken",
            description = "Gitter authtoken",
            value = "",
            display = ParameterDisplay.PROMPT)
    }
    dependencies {
        snapshot(Test) {
        }
        snapshot(Pack) {
        }
        artifacts(Pack) {
            artifactRules = """
                +:output/*.nupkg
            """.trimIndent()
        }
    }
})
object Announce : BuildType({
    name = "Announce"
    vcs {
        root(VcsRoot)
    }
    steps {
        exec {
            path = "build.sh"
            arguments = "Announce --skip"
        }
    }
    triggers {
        finishBuildTrigger {
            buildType = "Publish"
        }
    }
})
