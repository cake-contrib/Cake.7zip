using System;
using System.Runtime.InteropServices;
using Cake.Frosting;

namespace Build
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return new CakeHost()
                .InstallSevenZip()
                .UseContext<BuildContext>()
                .UseSetup<BuildSetup>()
                .Run(args);
        }

        private static CakeHost InstallSevenZip(this CakeHost host)
        {
            // 7-Zip.CommandLine is a windows-only package
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                host.InstallTool(new Uri("nuget:?package=7-Zip.CommandLine&version=18.1.0"));
            }
            else
            {
                Console.WriteLine("7-Zip.CommandLine tool not installed. Make sure you hava a version of 7zip installed!");
            }

            return host;
        }
    }
}
