using System.Threading.Tasks;
using L0gg3r.Base;
using L0gg3r.LogSinks.Test;

namespace TestLogSinkTests.MethodTests.ClearMethodTests;

[TestClass]
public class TheClearMethodTests
{
    [TestMethod]
    public async Task ShouldClearTheLogMessages()
    {
        // Arrange
        TestLogSink logSink = new();
        LogMessage logMessage = new();

        // Assert
        logSink.LogMessages.Should().BeEmpty();

        // Act
        await logSink.SubmitAsync(logMessage).ConfigureAwait(false);
        await logSink.FlushAsync().ConfigureAwait(false);

        // Assert
        logSink.LogMessages.Should().ContainSingle();

        // Act
        logSink.Clear();

        // Assert
        logSink.LogMessages.Should().BeEmpty();
    }
}
