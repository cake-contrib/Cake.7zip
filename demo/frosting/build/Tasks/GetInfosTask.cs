using System.Linq;
using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.SevenZip;

namespace Build.Tasks
{
    [TaskName("GetInfos")]
    public sealed class GetInfosTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => m
                .InInformationMode()
                .WithCommandOutput(o =>
                {
                    context.Information("7Zip version is:" + o.Information);
                    context.Information("7Zip supports QCOW:" + (Enumerable.Any<string>(o.Formats, x => x.IndexOf("QCOW") > -1)));
                }));
        }
    }
}
