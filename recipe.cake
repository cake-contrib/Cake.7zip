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
  preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
  shouldUseTargetFrameworkPath: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);
ToolSettings.SetToolPreprocessorDirectives(
    gitReleaseManagerGlobalTool: "#tool dotnet:?package=GitReleaseManager.Tool&version=0.18.0",
    gitVersionGlobalTool: "#tool dotnet:?package=GitVersion.Tool&version=5.12.0",
    reportGeneratorGlobalTool: "#tool dotnet:?package=dotnet-reportgenerator-globaltool&version=5.4.7",
    coverallsGlobalTool: "#tool dotnet:?package=coveralls.net&version=4.0.1");

Build.RunDotNetCore();
