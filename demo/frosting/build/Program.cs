using System;
using Cake.Frosting;

namespace Build
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return new CakeHost()
                .InstallTool(new Uri("nuget:?package=7-Zip.CommandLine&version=18.1.0"))
                .UseContext<BuildContext>()
                .UseSetup<BuildSetup>()
                .Run(args);
        }
    }
}
