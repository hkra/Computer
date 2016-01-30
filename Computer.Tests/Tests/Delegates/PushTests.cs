using System;
using Xunit;
using Computer.Interfaces;
using Moq;
using Computer;
using Computer.Delegates;

namespace Computer.Tests.Tests.Delegates
{
    public class PushTests
    {
        [Fact]
        public void Push_EncodesADataInstructionWithGivenOperand()
        {
            // Arrange
            var encoder = new Mock<IEncoder>();
            var stack = new Mock<IStack>();
            var context = new ExecutionContext
            {
                Encoder = encoder.Object,
                Stack = stack.Object
            };
            var instruction = new Instruction { Operand = 12345 };
            var pusher = new Push();

            // Act
            pusher.Execute(context, instruction);

            // Assert
            encoder.Verify(e => e.Encode(It.Is<Instruction>(i => i.Operand == instruction.Operand && i.Type == InstructionType.Data)));
        }

        [Fact]
        public void Push_PushesValueOntoStack()
        {
            // Arrange
            var encoder = new Mock<IEncoder>();
            var stack = new Mock<IStack>();
            var context = new ExecutionContext
            {
                Encoder = encoder.Object,
                Stack = stack.Object
            };
            var instruction = new Instruction { Operand = 12345 };
            var pusher = new Push();

            // Act
            pusher.Execute(context, instruction);

            // Assert
            stack.Verify(s => s.Push(It.IsAny<UInt64>()), Times.Once);
        }
    }
}