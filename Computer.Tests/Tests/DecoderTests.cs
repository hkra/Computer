using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FluentAssertions;

namespace Computer.Tests
{
    public class DecoderTests
    {
        [Theory]
        [InlineData(0x000000000000002A, InstructionType.Data, 42)]
        [InlineData(0x000000060000002A, InstructionType.Push, 42)]
        [InlineData(0x000000020000002A, InstructionType.Call, 42)]
        [InlineData(0x0000000100000000, InstructionType.Mult, 0)]
        [InlineData(0x0000000300000000, InstructionType.Ret, 0)]
        [InlineData(0x0000000400000000, InstructionType.Stop, 0)]
        [InlineData(0x0000000500000000, InstructionType.Print, 0)]
        public void Decode_CorrectlyDecodesInstructions(UInt64 raw, InstructionType expectedOp, Int32 expecteOperand)
        {
            // Arrange
            var decoder = new Decoder();

            // Act
            var instruction = decoder.Decode(raw);

            // Assert
            instruction.Type.Should().Be(expectedOp);
            instruction.Operand.Should().Be(expecteOperand);
        }
    }
}