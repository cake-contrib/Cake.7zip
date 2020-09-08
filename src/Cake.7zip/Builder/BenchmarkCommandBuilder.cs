using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="BenchmarkCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("DoBenchmark")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///         .InBenchmarkMode()
    ///         .WithMethod("*")
    ///         .WithNumberOfIterations(2)
    ///         .WithCommandOutput(o =>
    ///         {
    ///             Information("7Zip version is:" + o.Information);
    ///             Information("Benchmark results:");
    ///             Information(o.Benchmark);
    ///         }));
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class BenchmarkCommandBuilder :
        BaseOutputBuilder<BenchmarkCommandBuilder, IBenchmarkOutput>
    {
        private readonly BenchmarkCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenchmarkCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal BenchmarkCommandBuilder(ref BenchmarkCommand command)
        {
            this.command = command;
        }

        /// <inheritdoc/>
        protected override BaseOutputCommand<IBenchmarkOutput> OutputCommand => command;

        /// <summary>
        /// Sets the number of iterations.
        /// </summary>
        /// <param name="numberOfIterations">The number of iterations.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public BenchmarkCommandBuilder WithNumberOfIterations(int numberOfIterations)
        {
            command.NumberOfIterations = numberOfIterations;
            return this;
        }

        /// <summary>
        /// Sets the size of the dictionary.
        /// </summary>
        /// <param name="dictionarySize">Size of the dictionary.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public BenchmarkCommandBuilder WithDictionarySize(int dictionarySize)
        {
            command.DictionarySize = dictionarySize;
            return this;
        }

        /// <summary>
        /// Sets the number of threads.
        /// </summary>
        /// <param name="numberOfThreads">The number of threads.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public BenchmarkCommandBuilder WithNumberOfThreads(int numberOfThreads)
        {
            command.NumberOfThreads = numberOfThreads;
            return this;
        }

        /// <summary>
        /// Sets the method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public BenchmarkCommandBuilder WithMethod(string method)
        {
            command.Method = method;
            return this;
        }
    }
}
