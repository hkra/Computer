using System;
using Xunit;
using FluentAssertions;
using Moq;
using Computer.Interfaces;

namespace Computer.Tests
{
    public class ComputerTests
    {
        [Fact]
        public void Execute_StartsExecutor()
        {
            // Arrange
            var executorMock = new Mock<IExecutionUnit>();
            var computer = new Computer(null, null, executorMock.Object);

            // Act
            computer.Execute();

            // Assert
            executorMock.Verify(m => m.Execute(), Times.Once);
        }

        [Fact]
        public void SetAddress_SetsExecutorProgramCounter()
        {
            // Arrange
            var executorMock = new Mock<IExecutionUnit>();
            var computer = new Computer(null, null, executorMock.Object);

            // Act
            computer.SetAddress(100);

            // Assert
            executorMock.VerifySet(m => m.ProgramCounter = 100, Times.Once);
        }

        [Fact]
        public void SetAddress_ReturnsThis()
        {
            // Arrange
            var executorMock = new Mock<IExecutionUnit>();
            var computer = new Computer(null, null, executorMock.Object);

            // Act
            var result = computer.SetAddress(100);

            // Assert
            result.Should().Be(computer);
        }

        [Fact]
        public void Insert_ReturnsThis()
        {
            // Arrange
            var stackMock = new Mock<IStack>();
            var encoderMock = new Mock<IEncoder>();
            var executorMock = new Mock<IExecutionUnit>();
            var computer = new Computer(stackMock.Object, encoderMock.Object, executorMock.Object);

            // Act
            var result = computer.Insert(InstructionType.Call, 3945873);

            // Assert
            result.Should().Be(computer);
        }

        [Fact]
        public void Insert_InsertsInstructionIntoStack()
        {
            // Arrange
            var stackMock = new Mock<IStack>();
            var encoderMock = new Mock<IEncoder>();
            var executorMock = new Mock<IExecutionUnit>();

            var computer = new Computer(stackMock.Object, encoderMock.Object, executorMock.Object);

            // Act
            computer.Insert(InstructionType.Call, 3945873);

            // Assert
            stackMock.Verify(m => m.SetAt(0, It.IsAny<UInt64>()));
            executorMock.VerifySet(e => e.ProgramCounter = 1);
        }

        [Fact]
        public void New_CreatesNewComputer()
        {
            // Act
            var computer = Computer.New(100);

            // Assert
            computer.Should().NotBeNull();
        }
    }
}
