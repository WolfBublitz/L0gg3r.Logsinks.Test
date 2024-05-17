using System.Threading.Tasks;
using L0gg3r.Base;
using L0gg3r.LogSinks.Test;

namespace TestLogSinkTests.MethodTests.SubmitAsyncMethodTests;

[TestClass]
public class TheSubmitAsyncMethodTests
{
    [TestMethod]
    public async Task ShouldLogALogMessage()
    {
        // Arrange
        TestLogSink logSink = new();
        LogMessage logMessage = new();

        // Act
        await logSink.SubmitAsync(logMessage).ConfigureAwait(false);
        await logSink.FlushAsync().ConfigureAwait(false);

        // Assert
        logSink.LogMessages.Should().ContainSingle();
        logSink.LogMessages.Should().Contain(logMessage);
    }
}
