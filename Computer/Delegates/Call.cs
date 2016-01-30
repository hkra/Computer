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
    /// Execution delegate for the call instruction.
    /// </summary>
    public class Call : AbstractDelegate<Call>
    {
        /// <summary>
        /// Execute the call instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            context.ProgramCounter = (int)instruction.Operand;
        }
    }
}
