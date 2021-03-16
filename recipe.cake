#load nuget:?package=Cake.Recipe&version=2.2.1

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake.7zip",
  masterBranchName: "main",
  repositoryOwner: "cake-contrib",
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
