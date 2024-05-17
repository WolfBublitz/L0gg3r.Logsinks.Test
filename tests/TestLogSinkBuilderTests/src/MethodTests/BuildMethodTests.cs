using L0gg3r.LogSinks.Test;

namespace TestLogSinkBuilderTests.MethodTests.TheBuildMethod;

[TestClass]
public class TheBuildMethod
{
    [TestMethod]
    public void ShouldReturnANewTestLogSink()
    {
        // Arrange
        TestLogSinkBuilder builder = new();

        // Act
        TestLogSink testLogSink = builder.Build();

        // Assert
        testLogSink.Should().NotBeNull();
    }
}
