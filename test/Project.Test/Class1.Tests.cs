using QodanaCoverageTest;

namespace Project.Test
{
    public class Class1Tests
    {
        [Fact]
        public void UsedMethod_ShouldExecuteWithoutException()
        {
            // Arrange
            var class1 = new Class1();

            // Act & Assert
            class1.UsedMethod();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void UsedMethodWithIf_ShouldWriteToConsole(int input)
        {
            // Arrange
            var class1 = new Class1();
            using var consoleOutput = new ConsoleOutput();

            // Act
            class1.UsedMethodWithIf(input);

            // Assert
            var output = consoleOutput.GetOutput();
            Assert.Contains(input.ToString(), output);
        }

        [Fact]
        public void UsedLambdaMethod_ShouldReturn4()
        {
            // Arrange
            var class1 = new Class1();

            // Act
            var result = class1.UsedLambdaMethod();

            // Assert
            Assert.Equal(4, result);
        }
    }

    // Helper class to capture console output
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}