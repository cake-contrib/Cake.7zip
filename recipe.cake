#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake.7zip",
  repositoryOwner: "nils-a",
  repositoryName: "Cake.7zip",
  shouldRunGitVersion: true,
  shouldExecuteGitLink: false,
  shouldRunCodecov: true,
  shouldDeployGraphDocumentation: false,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
