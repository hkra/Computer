using System;
using Computer.Interfaces;
using Moq;
using Xunit;
using FluentAssertions;

namespace Computer.Tests.Tests
{
    public class ExecutionUnitTests
    {
        private readonly IDecoder _stopDecoder;
        private readonly IStack _defaultStack;

        public ExecutionUnitTests()
        {
            _defaultStack = new Mock<Stack>(10).Object;

            var stopDecoderMock = new Mock<IDecoder>();
            stopDecoderMock.Setup(m => m.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction { Type = InstructionType.Stop });
            _stopDecoder = stopDecoderMock.Object;
        }

        [Fact]
        public void Execute_IncrementProgramCounter()
        {
            // Arrange
            var executor = new ExecutionUnit(_defaultStack, null, _stopDecoder, null);
            var pc = executor.ProgramCounter;

            // Act
            executor.Execute();

            // Assert
            executor.ProgramCounter.Should().Be(pc + 1);
        }

        [Fact]
        public void Execute_InvalidInstructionThrowsException()
        {
            // Arrange
            var decoder = new Mock<IDecoder>();
            decoder.Setup(m => m.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction { Type = (InstructionType)12345 });

            // Act
            var executor = new ExecutionUnit(_defaultStack, null, decoder.Object, null);

            // Assert
            executor.Invoking(e => e.Execute()).ShouldThrow<InvalidOperationException>();
        }
    }
}
