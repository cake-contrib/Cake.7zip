///////////////////////////////////////////////////////////////////////////////
// DISABLE WYAM
///////////////////////////////////////////////////////////////////////////////

BuildParameters.Tasks.PreviewDocumentationTask.WithCriteria(() => false, "Favor Statiq over Wyam");
BuildParameters.Tasks.PublishDocumentationTask.WithCriteria(() => false, "Favor Statiq over Wyam");
BuildParameters.Tasks.ForcePublishDocumentationTask.WithCriteria(() => false, "Favor Statiq over Wyam");

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

// No Clean task, we re-use the one provided in Wyam.cake

BuildParameters.Tasks.PublishDocumentationTask = Task("Publish-StatiqDocs")
    .IsDependentOn("Clean-Documentation")
    .WithCriteria(() => BuildParameters.ShouldGenerateDocumentation, "Statiq documentation has been disabled")
    .WithCriteria(() => DirectoryExists(BuildParameters.WyamRootDirectoryPath), "Statiq documentation directory is missing")
    .Does(() => {
        // ensure submodules are in place
        var gitTool = Context.Tools.Resolve("git");
        if (gitTool == null)
        {
            gitTool = Context.Tools.Resolve("git.exe");
        }
        if (gitTool == null)
        {
            throw new FileNotFoundException("git/git.exe could not be found!");
        }

        var exitCode = Context.StartProcess(
            gitTool,
            new ProcessSettings {
                Arguments = "submodule update --init --recursive",
            }
        );

        // Check to see if any documentation has changed
        var sourceCommit = GitLogTip("./");
        Information("Source Commit Sha: {0}", sourceCommit.Sha);
        var filesChanged = GitDiff("./", sourceCommit.Sha);
        Information("Number of changed files: {0}", filesChanged.Count);
        var docFileChanged = false;

        var wyamDocsFolderDirectoryName = BuildParameters.WyamRootDirectoryPath.GetDirectoryName();

        var pathsToTestAgainst = new List<string>() {
            string.Format("{0}{1}", wyamDocsFolderDirectoryName, "/input/")
        };

        if (BuildParameters.ShouldDocumentSourceFiles)
        {
            // BuildParameters.WyamSourceFiles can not be used - the wyam globs are different from globs in GetFiles().
            pathsToTestAgainst.Add(string.Format("{0}{1}", BuildParameters.SourceDirectoryPath.FullPath, '/'));
        }

        Verbose("Comparing all file-changes to the following paths:");
        foreach(var p in pathsToTestAgainst)
        {
            Verbose(" - "+p);
        }

        foreach (var file in filesChanged)
        {
            Verbose("Changed File OldPath: {0}, Path: {1}", file.OldPath, file.Path);
            if (pathsToTestAgainst.Any(x => file.OldPath.Contains(x) || file.Path.Contains(x)))
            {
                docFileChanged = true;
                break;
            }
        }

        if (docFileChanged)
        {
            Information("Detected that documentation files have changed, so running Statiq...");

            Statiq();
            PublishStatiqDocs();
        }
        else
        {
            Information("No documentation has changed, so no need to generate documentation");
        }
    }
)
.OnError(exception =>
{
    Error(exception.Message);
    Information("Publish-StatiqDocs Task failed, but continuing with next Task...");
    publishingError = true;
});

BuildParameters.Tasks.PreviewDocumentationTask = Task("Preview-StatiqDocs")
    .WithCriteria(() => DirectoryExists(BuildParameters.WyamRootDirectoryPath), "Statiq documentation directory is missing")
    .Does(() => {
        Statiq("preview");
    });


BuildParameters.Tasks.ForcePublishDocumentationTask = Task("Force-Publish-StatiqDocs")
    .IsDependentOn("Clean-Documentation")
    .WithCriteria(() => DirectoryExists(BuildParameters.WyamRootDirectoryPath), "Statiq documentation directory is missing")
    .Does(() => {
        Statiq();
        PublishStatiqDocs();
    }
);

public void PublishStatiqDocs()
{
    var canPublishToGitHub =
                !string.IsNullOrEmpty(BuildParameters.Wyam.AccessToken) &&
                !string.IsNullOrEmpty(BuildParameters.Wyam.DeployBranch) &&
                !string.IsNullOrEmpty(BuildParameters.RepositoryOwner) &&
                !string.IsNullOrEmpty(BuildParameters.RepositoryName);

    if (!canPublishToGitHub)
    {
        Warning("Unable to publish documentation, as not all Statiq configuration is present");
        return;
    }

    Statiq("deploy");
}

// TODO: Do we need Cake.Statiq ?
public void Statiq(string command = "", IDictionary<string, string> additionalSetting = null)
{
    var statiqProj = BuildParameters.WyamRootDirectoryPath.CombineWithFilePath("Docs.csproj").FullPath; // TODO: Configurable!
    var settings = new Dictionary<string, string>
    {
        { "Host", BuildParameters.WebHost },
        { "LinkRoot", BuildParameters.WebLinkRoot },
        { "BaseEditUrl", BuildParameters.WebBaseEditUrl },
        { "Title", BuildParameters.Title },
        { "IncludeGlobalNamespace", "false" },
        { "STATIQ_DEPLOY_OWNER", BuildParameters.RepositoryOwner },
        { "STATIQ_DEPLOY_REPO_NAME", BuildParameters.RepositoryName }
    };

    if (BuildParameters.ShouldDocumentSourceFiles)
    {
        settings.Add("SourceFiles", BuildParameters.WyamSourceFiles);
    }

    if(additionalSetting != null)
    {
        settings = new[]{settings, additionalSetting}.SelectMany(x => x).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    if((command.EqualsIgnoreCase("preview") || command.EqualsIgnoreCase("serve")) && !string.IsNullOrEmpty(BuildParameters.WebLinkRoot))
    {
        command += $" --virtual-dir={BuildParameters.WebLinkRoot}";
    }

    // TODO: Read log-level from Env/commandline?

    DotNetCoreRun(statiqProj, new DotNetCoreRunSettings
    {
        EnvironmentVariables = settings,
        ArgumentCustomization = args=>args
                                .Append(" -- ")
                                .Append(command)
                                .Append($"--root=\"{BuildParameters.WyamRootDirectoryPath}\""),
    });
}


///////////////////////////////////////////////////////////////////////////////
// BAKE STATIQ IN Cake.Recipe
///////////////////////////////////////////////////////////////////////////////

BuildParameters.Tasks.PreviewTask.IsDependentOn("Preview-StatiqDocs");
BuildParameters.Tasks.PublishDocsTask.IsDependentOn("Force-Publish-StatiqDocs");
BuildParameters.Tasks.ContinuousIntegrationTask.IsDependentOn("Publish-StatiqDocs");
