using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Computer.Delegates;
using Moq;
using Computer.Interfaces;
using Computer;

namespace Computer.Tests.Tests.Delegates
{
    public class PrintTests
    {
        [Fact]
        public void Print_PopsAnOperandFromTheStack()
        {
            // Arrange
            var printer = new Print();
            var stack = new Mock<IStack>();
            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction
                {
                    Operand = 12345
                });

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Decoder = decoder.Object
            };

            // Act
            printer.Execute(context, null);

            // Verify
            stack.Verify(s => s.Pop(), Times.Once);
        }

        [Fact]
        public void Print_DecodesOperand()
        {
            // Arrange
            var printer = new Print();
            var stack = new Mock<IStack>();
            stack.Setup(s => s.Pop())
                .Returns(1234);

            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(It.IsAny<UInt64>()))
                .Returns(new Instruction
                {
                    Operand = 12345
                });

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Decoder = decoder.Object
            };

            // Act
            printer.Execute(context, null);

            // Verify
            decoder.Verify(d => d.Decode(1234), Times.Once);
        }
    }
}
