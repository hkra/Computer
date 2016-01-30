using FluentAssertions;
using System;
using Xunit;

namespace Computer.Tests
{
    public class StackTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Stack_NonPositiveStackSizeThrowsException(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Stack(size));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(-1)]
        public void StackGet_IndexOutOfBoundsThrowsException(int address)
        {
            // Arrange
            var stack = new Stack(100);

            // Act, Assert
            Assert.Throws<IndexOutOfRangeException>(() => stack.GetAt(address));
        }

        [Theory]
        [InlineData(100, 36)]
        [InlineData(-1, 12)]
        public void StackSet_IndexOutOfBoundsThrowsException(int address, UInt32 value)
        {
            // Arrange
            var stack = new Stack(100);
            
            // Act, Assert
            Assert.Throws<IndexOutOfRangeException>(() => stack.SetAt(address, value));
        }

        [Fact]
        public void StackPush_ThrowsExceptionOnOverflow()
        {
            // Arrange
            var stack = new Stack(10);
            
            // Act, Assert
            stack.SetAt(9, 1);
            stack.Invoking(s => s.Push(2)).ShouldThrow<StackOverflowException>();
        }

        [Fact]
        public void StackPush_SetsValueAtStackPointer()
        {
            // Arrange
            var stack = new Stack(10);

            // Act
            stack.Push(123456789);

            // Assert
            stack.GetAt(stack.StackPointer).Should().Be(123456789);
        }

        [Fact]
        public void StackPop_ThrowsExceptionOnEmptyStack()
        {
            // Arrange
            var stack = new Stack(16);

            // Act, Assert
            stack.Pop(); // Stack always starts with one (index 0)
            stack.Invoking(s => s.Pop()).ShouldThrow<IndexOutOfRangeException>();
        }

        [Fact]
        public void StackPop_DecrementsStackPointer()
        {
            // Arrange
            var stack = new Stack(16);
            stack.SetAt(8, 80085);

            // Act
            stack.Pop();

            // Assert
            stack.StackPointer.Should().Be(7);
        }

        [Fact]
        public void StackPop_ReturnsValueFromTopOfStack()
        {
            // Arrange
            var stack = new Stack(16);
            stack.SetAt(8, 80085);

            // Act
            var value = stack.Pop();

            // Assert
            value.Should().Be(80085);
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(5, 394857)]
        [InlineData(9, 5)]
        public void StackSetGet_SetsValueAtGivenAddress(int address, UInt64 value)
        {
            // Arrange
            var stack = new Stack(10);

            // Act
            stack.SetAt(address, value);

            // Assert
            stack.GetAt(address).Should().Be(value);
        }

        [Fact]
        public void StackSize_ReturnsCorrectStackSize()
        {
            // Arrange
            var stack = new Stack(123);

            // Act, Assert
            stack.Size.Should().Be(123);
        }
    }
}
