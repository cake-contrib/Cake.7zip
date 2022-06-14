#load nuget:?package=Cake.Recipe&version=2.2.1

// Workaround for https://github.com/cake-contrib/Cake.Recipe/issues/854
#tool nuget:?package=NuGet.CommandLine&version=5.11.2

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake.7zip",
  masterBranchName: "main",
  repositoryOwner: "cake-contrib",
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true,
  shouldRunDupFinder: false, // dupFinder is missing in 2021.3.0-eap
  shouldRunInspectCode: false, // we're shipping a custom version of it below
  preferredBuildProviderType: BuildProviderType.GitHubActions,
  preferredBuildAgentOperatingSystem: PlatformFamily.Linux);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);
ToolSettings.SetToolPreprocessorDirectives(
    reSharperTools: "#tool nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2021.3.0-eap10&prerelease");

Build.RunDotNetCore();

// additional workaround for https://github.com/cake-contrib/Cake.Recipe/issues/862
// to suppress the --build/--no-build warning that is generated in the default
BuildParameters.Tasks.InspectCodeTask = Task("InspectCode2021")
    .WithCriteria(() => BuildParameters.BuildAgentOperatingSystem == PlatformFamily.Windows, "Skipping due to not running on Windows")
    .Does<BuildData>(data => RequireTool(ToolSettings.ReSharperTools, () => {
        var inspectCodeLogFilePath = BuildParameters.Paths.Directories.InspectCodeTestResults.CombineWithFilePath("inspectcode.xml");

        var settings = new InspectCodeSettings() {
            SolutionWideAnalysis = true,
            OutputFile = inspectCodeLogFilePath,
            ArgumentCustomization = x => x.Append("--no-build")
        };

        if (FileExists(BuildParameters.SourceDirectoryPath.CombineWithFilePath(BuildParameters.ResharperSettingsFileName)))
        {
            settings.Profile = BuildParameters.SourceDirectoryPath.CombineWithFilePath(BuildParameters.ResharperSettingsFileName);
        }

        InspectCode(BuildParameters.SolutionFilePath, settings);

        // Pass path to InspectCode log file to Cake.Issues.Recipe
        IssuesParameters.InputFiles.InspectCodeLogFilePath = inspectCodeLogFilePath;
    })
);
BuildParameters.Tasks.AnalyzeTask.IsDependentOn("InspectCode2021");
IssuesBuildTasks.ReadIssuesTask.IsDependentOn("InspectCode2021");
