await Bootstrapper
  .Factory
  .CreateDocs(args)
  .DeployToGitHubPagesBranch(
    Config.FromSetting<string>("STATIQ_DEPLOY_OWNER"),
    Config.FromSetting<string>("WYAM_DEPLOY_REMOTE"),
    Config.FromSetting<string>("WYAM_ACCESS_TOKEN"),
    Config.FromSetting<string>("WYAM_DEPLOY_BRANCH")
  )
  .RunAsync();
