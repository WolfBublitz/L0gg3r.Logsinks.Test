using L0gg3r.LogSinks.Test;

namespace TestLogSinkTests.PropertyTests.LogMessagesPropertyTests;

[TestClass]
public class TheLogMessagesProperty
{
    [TestMethod]
    public void ShouldBeEmptyAtDefault()
    {
        // Arrange
        TestLogSink logSink = new();

        // Assert
        logSink.LogMessages.Should().BeEmpty();
    }
}
