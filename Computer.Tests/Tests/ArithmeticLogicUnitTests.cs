using System;
using FluentAssertions;
using Xunit;

namespace Computer.Tests
{
    public class ArithmeticLogicUnitTests
    {
        [Theory]
        [InlineData(10, 10, 100)]
        [InlineData(-10, -10, 100)]
        [InlineData(10, -10, -100)]
        [InlineData(0, 0, 0)]
        public void ALUMultiply_Multiplies32BitIntegers(Int32 first, Int32 second, Int32 expected)
        {
            // Arrange
            var alu = new ArithmeticLogicUnit();

            // Act
            Int32 result = alu.Multiply(first, second);

            // Assert
            result.Should().Be(expected);
        }
    }
}
