namespace Cake.7zip
{
  using Cake.Core;
  using Cake.Core.Annotations;
  using Cake.Core.IO;

  [CakeAliasCategory("7zip")]
  public static class 7zipAliases
  {
    [CakeMethodAlias]
    public static void 7zip(this ICakeContext context)
    {
      7zip(context, new 7zipSettings());
    }

    [CakeMethodAlias]
    public static void 7zip(this ICakeContext context, 7zipSettings settings)
    {
      var runner = new 7zipRunner(
        context.FileSystem,
        context.Environment,
        context.ProcessRunner,
        context.Tools);
      runner.Run(settings);
    }
  }
}
