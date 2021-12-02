using System;

using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Base for builders that support <see cref="BaseOutputCommand{T}"/>.
/// </summary>
/// <typeparam name="TBuilder">the command-builder that extends this base-class. Only needed for "nice" fluid-tying.</typeparam>
/// <typeparam name="TOutput">the output of the <see cref="BaseOutputCommand{T}"/> supported by this builder.</typeparam>
public abstract class BaseOutputBuilder<TBuilder, TOutput>
    where TBuilder : BaseOutputBuilder<TBuilder, TOutput>
    where TOutput : IOutput
{
    /// <summary>
    /// Gets the output command.
    /// </summary>
    /// <value>
    /// The output command.
    /// </value>
    protected abstract BaseOutputCommand<TOutput> OutputCommand { get; }

    // the following are no extensions (and this is no interface), because all those crazy generics can't be
    // automatically resolved in an extension. That would lead to bad non-fluid-typing in the DSL...

    /// <summary>
    /// fluent action to set the output-action of <see cref="BaseOutputCommand{T}"/>.
    /// </summary>
    /// <param name="outputAction">the action to perform on the output.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public TBuilder WithCommandOutput(Action<TOutput>? outputAction)
    {
        OutputCommand.OutputAction = outputAction;
        return (TBuilder)this;
    }

    /// <summary>
    /// fluent action to set the raw-output of <see cref="BaseOutputCommand{T}"/>.
    /// </summary>
    /// <param name="rawOutputAction">the action to perform on the output.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public TBuilder WithCommandRawOutput(Action<string[]>? rawOutputAction)
    {
        OutputCommand.RawOutputAction = rawOutputAction;
        return (TBuilder)this;
    }
}