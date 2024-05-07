#load nuget:?package=Cake.Recipe&version=3.1.1

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
  shouldRunCodecov: false,
  preferredBuildProviderType: BuildProviderType.GitHubActions,
  preferredBuildAgentOperatingSystem: PlatformFamily.Linux);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
