using System.Linq;
using L0gg3r;
using L0gg3r.Builder;
using L0gg3r.LogSinks.Test;

namespace LogToExtensionMethodTests.MethodTests.TestLogSinkMethodTests;

[TestClass]
public class TheTestLogSinkMethod
{
    [TestMethod]
    public void ShouldBuildALoggerWithATestLogSink()
    {
        // Arrange
        LoggerBuilder loggerBuilder = new();

        // Act
        Logger logger = loggerBuilder.LogTo.TestLogSink().Build();

        // Assert
        logger.LogSinks.Should().ContainSingle();
        logger.LogSinks.First().Should().BeOfType<TestLogSink>();
    }
}