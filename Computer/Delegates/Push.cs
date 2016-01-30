using Computer.Interfaces;
using Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Delegates
{
    /// <summary>
    /// Execution delegate for the push instruction.
    /// </summary>
    public class Push : AbstractDelegate<Push>
    {
        /// <summary>
        /// Execute the push instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            var value = context.Encoder.Encode(new Instruction
            {
                Type = InstructionType.Data,
                Operand = instruction.Operand
            });

            context.Stack.Push(value);
        }
    }
}
