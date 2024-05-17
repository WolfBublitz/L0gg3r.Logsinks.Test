// ----------------------------------------------------------------------------
// <copyright file="TestLogSink.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using L0gg3r.Base;
using L0gg3r.LogSinks.Base;

namespace L0gg3r.LogSinks.Test
{
    /// <summary>
    /// A test log sink for testing that stores log messages in memory.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public sealed class TestLogSink : LogSinkBase<TestLogSink>
    {
        // ┌────────────────────────────────────────────────────────────────────────────────┐
        // │ Private Fields                                                                 │
        // └────────────────────────────────────────────────────────────────────────────────┘
        private readonly List<LogMessage> logMessages = [];

        // ┌────────────────────────────────────────────────────────────────────────────────┐
        // │ Public Properties                                                              │
        // └────────────────────────────────────────────────────────────────────────────────┘

        /// <summary>
        /// Gets the list of received <see cref="LogMessage"/>s.
        /// </summary>
        public IEnumerable<LogMessage> LogMessages => logMessages;

        // ┌────────────────────────────────────────────────────────────────────────────────┐
        // │ Public Methods                                                                 │
        // └────────────────────────────────────────────────────────────────────────────────┘

        /// <summary>
        /// Clears the list of received <see cref="LogMessage"/>s.
        /// </summary>
        /// <seealso cref="LogMessages"/>
        public void Clear() => logMessages.Clear();

        // ┌────────────────────────────────────────────────────────────────────────────────┐
        // │ Protected Methods                                                              │
        // └────────────────────────────────────────────────────────────────────────────────┘

        /// <inheritdoc/>
        protected override ValueTask WriteAsync(in LogMessage logMessage)
        {
            logMessages.Add(logMessage);

            return ValueTask.CompletedTask;
        }

        // ┌────────────────────────────────────────────────────────────────────────────────┐
        // │ Private Methods                                                                │
        // └────────────────────────────────────────────────────────────────────────────────┘
        private string GetDebuggerDisplay() => $"LogMessages: {logMessages.Count}";
    }
}
