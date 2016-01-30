using System;
using FluentAssertions;
using Xunit;
using Computer.Delegates;
using Computer;

namespace Computer.Tests.Tests.Delegates
{
    public class CallTest
    {
        [Fact]
        public void Call_SetsProgramCounterToOperandValue()
        {
            // Arrange
            var caller = new Call();
            var context = new ExecutionContext();
            var instruction = new Instruction { Operand = 54321 };

            // Act
            caller.Execute(context, instruction);

            // Assert
            context.ProgramCounter.Should().Be(54321);
        }
    }
}