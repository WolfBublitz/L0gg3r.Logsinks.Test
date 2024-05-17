// ----------------------------------------------------------------------------
// <copyright file="LogToExtensions.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;

using L0gg3r.Builder;

namespace L0gg3r.LogSinks.Test;

/// <summary>
/// Provides extension methods for <see cref="LogSinkBuilder{TLogSink, TBuilder}"/>.
/// </summary>
public static class LogToExtensions
{
    /// <summary>
    /// Creates a new <see cref="Test.TestLogSink"/> and adds it to the <see cref="LogSinkBuilder{TLogSink, TBuilder}"/>.
    /// </summary>
    /// <param name="this">This <see cref="LogSinkBuilder{TLogSink, TBuilder}"/>.</param>
    /// <returns>This <see cref="LoggerBuilder"/>.</returns>
    public static LoggerBuilder TestLogSink(this LogTo @this)
    {
        ArgumentNullException.ThrowIfNull(@this, nameof(@this));

        TestLogSink testLogSink = new();

        return @this.LogSink(testLogSink);
    }

    /// <summary>
    /// Creates a new <see cref="Test.TestLogSink"/> that is build via the
    /// <paramref name="logSinkBuilder"/> and adds it to the <see cref="LogSinkBuilder{TLogSink, TBuilder}"/>.
    /// </summary>
    /// <param name="this">This <see cref="LogSinkBuilder{TLogSink, TBuilder}"/>.</param>
    /// <param name="logSinkBuilder">The <see cref="TestLogSinkBuilder"/>.</param>
    /// <returns>This <see cref="LoggerBuilder"/>.</returns>
    public static LoggerBuilder TestLogSink(this LogTo @this, Action<TestLogSinkBuilder> logSinkBuilder)
    {
        ArgumentNullException.ThrowIfNull(@this, nameof(@this));
        ArgumentNullException.ThrowIfNull(logSinkBuilder, nameof(logSinkBuilder));

        TestLogSinkBuilder testLogSinkBuilder = new();

        logSinkBuilder(testLogSinkBuilder);

        return @this.LogSink(testLogSinkBuilder.Build());
    }
}
