#load nuget:?package=Cake.Recipe&version=4.0.0

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
  preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
  shouldUseTargetFrameworkPath: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);
ToolSettings.SetToolPreprocessorDirectives(
    reportGeneratorGlobalTool: "#tool dotnet:?package=dotnet-reportgenerator-globaltool&version=5.4.7",
    coverallsGlobalTool: "#tool dotnet:?package=coveralls.net&version=4.0.1");

Build.RunDotNetCore();
