using Computer;
using FluentAssertions;
using System;
using Xunit;

namespace Computer.Tests
{
    public class EncoderTests
    {
        [Fact]
        public void Encode_NullInstructionThrowsException()
        {
            // Arrange
            var encoder = new Encoder();
            Exception exception = null;

            // Act
            try
            {
                encoder.Encode(null);
            }
            catch(Exception e)
            {
                exception = e;
            }

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentNullException>();
            exception.As<ArgumentNullException>().ParamName.Should().Be("instruction");
        }

        [Theory]
        [InlineData(InstructionType.Data, 42, 0x00000002A)]
        [InlineData(InstructionType.Push, 42, 0x60000002A)]
        [InlineData(InstructionType.Call, 42, 0x20000002A)]
        [InlineData(InstructionType.Mult, null,0x100000000)]
        [InlineData(InstructionType.Ret, null, 0x300000000)]
        [InlineData(InstructionType.Stop, null, 0x400000000)]
        [InlineData(InstructionType.Print, null, 0x500000000)]
        public void Encode_EncodesInstructionsCorrectly(InstructionType op, Int32? operand, UInt64 expected)
        {
            // Arrange
            var encoder = new Encoder();
            var instruction = new Instruction
            {
                Type = op,
                Operand = operand.HasValue ? operand.Value : 0
            };

            // Act
            var encodedInstruction = encoder.Encode(instruction);

            // Assert
            encodedInstruction.Should().Be(expected);
        }

        [Theory]
        [InlineData(InstructionType.Ret, 42, 0x300000000)]
        [InlineData(InstructionType.Stop, 42, 0x400000000)]
        [InlineData(InstructionType.Print, 42, 0x500000000)]
        [InlineData(InstructionType.Mult, 42, 0x100000000)]
        public void Encode_DoesIgnoresOperandForNonOperandInstructions(InstructionType op, Int32 operand, UInt64 expected)
        {
            // Arrange
            var encoder = new Encoder();
            var instruction = new Instruction
            {
                Type = op,
                Operand = operand
            };

            // Act
            var encodedInstruction = encoder.Encode(instruction);

            // Assert
            encodedInstruction.Should().Be(expected);
        }
    }
}
