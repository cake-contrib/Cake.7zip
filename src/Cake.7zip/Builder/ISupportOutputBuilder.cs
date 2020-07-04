using System;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    ///  Internal interface to make the extensions more type-able.
    /// </summary>
    /// <typeparam name="T">the output of the <see cref="OutputCommand{T}"/> supported by this builder.</typeparam>
    public interface ISupportOutputBuilder<T>
    {
        /// <summary>
        /// Sets the output-action from the command.
        /// </summary>
        /// <value>
        /// The output.
        /// </value>
        Action<T> OutputAction { set; }

        /// <summary>
        /// Sets the raw output-action from the command.
        /// </summary>
        /// <value>
        /// The raw output.
        /// </value>
        Action<string[]> RawOutputAction { set; }
    }

    /// <summary>
    /// Base for builders that support <see cref="OutputCommand{T}"/>.
    /// </summary>
    /// <typeparam name="TBuilder">the command-builder that extends this base-class. Only needed for "nice" fluid-tying.</typeparam>
    /// <typeparam name="TCommand">the <see cref="OutputCommand{T}"/> supported by this builder.</typeparam>
    /// <typeparam name="TOutput">the output of the <see cref="OutputCommand{T}"/> supported by this builder.</typeparam>
    public abstract class BaseOutputBuilder<TBuilder, TCommand, TOutput> : ISupportOutputBuilder<TOutput>
        where TBuilder : BaseOutputBuilder<TBuilder, TCommand, TOutput>, ISupportOutputBuilder<TOutput>
        where TCommand : OutputCommand<TOutput>
    {
        /// <inheritdoc/>
        public Action<TOutput> OutputAction
        {
            set => OutputCommand.OutputAction = value;
        }

        /// <inheritdoc/>
        public Action<string[]> RawOutputAction
        {
            set => OutputCommand.RawOutputAction = value;
        }

        /// <summary>
        /// Gets the output command.
        /// </summary>
        /// <value>
        /// The output command.
        /// </value>
        protected abstract OutputCommand<TOutput> OutputCommand { get; }

        // the following are no extensions, because all those crazy generics can't be
        // automatically resolved in an extension. That would lead to bad non-fluid-typing...

        /// <summary>
        /// fluent action to set the output-action of <see cref="OutputCommand{T}"/>.
        /// </summary>
        /// <param name="outputAction">the action to perform on the output.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public TBuilder WithCommandOutput(Action<TOutput> outputAction)
        {
            OutputAction = outputAction;
            return (TBuilder)this;
        }

        /// <summary>
        /// fluent action to set the raw-output of <see cref="OutputCommand{T}"/>.
        /// </summary>
        /// <param name="rawOutputAction">the action to perform on the output.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public TBuilder WithCommandRawOutput(Action<string[]> rawOutputAction)
        {
            RawOutputAction = rawOutputAction;
            return (TBuilder)this;
        }
    }
}
