using System;
using FluentAssertions;
using Xunit;
using Computer.Delegates;
using Moq;
using Computer.Interfaces;
using Computer;

namespace Computer.Tests.Tests.Delegates
{
    public class ReturnTests
    {
        [Fact]
        public void Return_PopsValueFromStack()
        {
            // Arrange
            var returner = new Return();
            var stack = new Mock<IStack>();
            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction { Operand = 999999999 });

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Decoder = decoder.Object
            };

            // Act
            returner.Execute(context, null);

            // Asserty
            stack.Verify(s => s.Pop(), Times.Once);
        }

        [Fact]
        public void Return_CallsDecodeToGetAddress()
        {
            // Arrange
            var returner = new Return();
            var stack = new Mock<IStack>();
            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction { Operand = 999999999 });

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Decoder = decoder.Object
            };

            // Act
            returner.Execute(context, null);

            // Asserty
            decoder.Verify(d => d.Decode(It.IsAny<UInt64>()), Times.Once);
        }

        [Fact]
        public void Return_SetsProgramCounterToDecodedAddress()
        {
            // Arrange
            var returner = new Return();
            var stack = new Mock<IStack>();
            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction { Operand = 999999999 });

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Decoder = decoder.Object
            };

            // Act
            returner.Execute(context, null);

            // Asserty
            context.ProgramCounter.Should().Be(999999999);
        }
    }
}