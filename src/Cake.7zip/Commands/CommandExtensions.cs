using System;
using System.Collections;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Extensions for internal use.
    /// </summary>
    internal static class CommandExtensions
    {
        /// <summary>
        /// Asserts that at least one of the given arguments is set.
        /// Throws a new <see cref="ArgumentException"/> with the given message, if arguments are not set.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="message">The message.</param>
        /// <param name="alternativeArguments">The alternative arguments.</param>
        internal static void RequireNotNull(this object argument, string message, params object[] alternativeArguments)
        {
            if (argument != null)
            {
                return;
            }

            foreach (var arg in alternativeArguments)
            {
                if (arg != null)
                {
                    return;
                }
            }

            throw new ArgumentException(message);
        }

        /// <summary>
        /// Asserts that at least one of the given arguments is set and not empty.
        /// Throws a new <see cref="ArgumentException"/> with the given message, if arguments are not set.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="message">The message.</param>
        /// <param name="alternativeArguments">The alternative arguments.</param>
        internal static void RequireNotEmpty(this IEnumerable argument, string message, params IEnumerable[] alternativeArguments)
        {
            bool NotEmpty(IEnumerable x)
            {
                if (x == null)
                {
                    return false;
                }

                var enumerator = x.GetEnumerator();
                enumerator.Reset();
                return enumerator.MoveNext();
            }

            if (NotEmpty(argument))
            {
                return;
            }

            foreach (var arg in alternativeArguments)
            {
                if (NotEmpty(arg))
                {
                    return;
                }
            }

            throw new ArgumentException(message);
        }

        /// <summary>
        /// Appends the Paths, if not null.
        /// </summary>
        /// <typeparam name="T">The type. See <see cref="Path"/>.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="paths">The paths.</param>
        /// <param name="projection">The path-projection. Default is <c>Path.FullPath</c>.</param>
        internal static void AppendPathsNullSafe<T>(this ProcessArgumentBuilder builder, IEnumerable<T> paths, Func<T, string> projection = null)
            where T : Path
        {
            if (paths == null)
            {
                return;
            }

            if (projection == null)
            {
                projection = x => x.FullPath;
            }

            foreach (var p in paths)
            {
                builder.AppendQuoted(projection(p));
            }
        }
    }
}
