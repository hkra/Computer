using Computer.Helpers;
using Computer;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Computer.Tests.Tests.Helpers
{
    public class DictionaryHelperTests
    {
        [Fact]
        public void Lookup_NonExistantKeyReturnsNull()
        {
            // Arrange
            var dictionary = new Dictionary<InstructionType, Action<ExecutionContext, Instruction>>();

            // Act
            var value = dictionary.Lookup(InstructionType.Call);

            // Assert
            value.Should().BeNull();
        }

        [Fact]
        public void Lookup_ReturnsValueForExistingKey()
        {
            // Arrange
            Action<ExecutionContext, Instruction> action = (e, i) => { /* Do nothing */ };
            var dictionary = new Dictionary<InstructionType, Action<ExecutionContext, Instruction>>
            {
                { InstructionType.Mult, action }
            };

            // Act
            var value = dictionary.Lookup(InstructionType.Mult);

            // Assert
            value.Should().Be(action);
        }
    }
}
