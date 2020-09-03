#load nuget:?package=Cake.Recipe&version=1.1.2

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake.7zip",
  masterBranchName: "main",
  repositoryOwner: "cake-contrib",
  repositoryName: "Cake.7zip",
  shouldPublishMyGet: false, // currently broken
  shouldRunGitVersion: true,
  shouldExecuteGitLink: false,
  shouldRunCodecov: true,
  shouldDeployGraphDocumentation: false,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
