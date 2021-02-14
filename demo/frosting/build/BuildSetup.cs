using Cake.Common.Diagnostics;
using Cake.Frosting;

namespace Build
{
    public class BuildSetup : FrostingSetup<BuildContext>
    {
        public override void Setup(BuildContext context)
        {
            var startPath = context.Environment.WorkingDirectory;
            context.Information($"Frosting was started from: {startPath}");
            context.Root = startPath.Combine("../../.."); // one more ".." than in Cake, for the "build" here..
            context.Output = startPath.Combine("output");
        }
    }
}


