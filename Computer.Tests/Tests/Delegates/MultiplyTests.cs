using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Moq;
using Computer.Interfaces;
using Computer;
using Computer.Delegates;

namespace Computer.Tests.Tests.Delegates
{
    public class MultiplyTests
    {

        private const Int32 Operand = 12;
        private const Int32 Result = 144;
        private const UInt64 EncodedValue = 123456789;

        [Fact]
        public void Multiply_PopsTwoOperandsMultiplyEncodeAndPushBackToStack()
        {
            // Arrange
            var instruction = new Instruction { Type = InstructionType.Mult };

            var stack = new Mock<IStack>();
            stack.Setup(s => s.Pop())
                .Returns(Operand);

            var encoder = new Mock<IEncoder>();
            encoder.Setup(e => e.Encode(It.Is<Instruction>(i => i.Operand == Result && i.Type == InstructionType.Data)))
                .Returns(EncodedValue);

            var decoder = new Mock<IDecoder>();
            decoder.Setup(d => d.Decode(Operand))
                .Returns(new Instruction { Operand = Operand });

            var alu = new Mock<IArithmeticLogicUnit>();
            alu.Setup(a => a.Multiply(Operand, Operand))
                .Returns(Result);

            var context = new ExecutionContext
            {
                Stack = stack.Object,
                Encoder = encoder.Object,
                Decoder = decoder.Object,
                Alu = alu.Object
            };

            var multiplier = new Multiply();

            // Act
            multiplier.Execute(context, instruction);

            // Assert
            stack.Verify(s => s.Pop(), Times.Exactly(2));
            decoder.Verify(d => d.Decode(Operand), Times.Exactly(2));
            alu.Verify(a => a.Multiply(Operand, Operand), Times.Once);
            encoder.Verify(e => e.Encode(It.Is<Instruction>(i => i.Operand == Result && i.Type == InstructionType.Data)));
            stack.Verify(s => s.Push(EncodedValue), Times.Once);
        }
    }
}