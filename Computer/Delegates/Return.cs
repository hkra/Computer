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
    /// Execution delegate for the return instruction.
    /// </summary>
    public class Return : AbstractDelegate<Return>
    {
        /// <summary>
        /// Execute the return instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            var address = (int)context.Decoder.Decode(context.Stack.Pop()).Operand;
            context.ProgramCounter = address;
        }
    }
}
