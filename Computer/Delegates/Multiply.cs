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
    /// Execution delegate for the multiply instruction.
    /// </summary>
    public class Multiply : AbstractDelegate<Multiply>
    {
        /// <summary>
        /// Execute the multiply instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            var val1 = context.Decoder.Decode(context.Stack.Pop()).Operand;
            var val2 = context.Decoder.Decode(context.Stack.Pop()).Operand;
            var result = context.Alu.Multiply(val1, val2);

            context.Stack.Push(context.Encoder.Encode(new Instruction
            {
                Type = InstructionType.Data,
                Operand = result
            }));
        }
    }
}
