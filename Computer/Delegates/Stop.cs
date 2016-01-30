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
    /// Execution delegate for the stop instruction.
    /// </summary>
    public class Stop : AbstractDelegate<Stop>
    {
        /// <summary>
        /// Execute the stop instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            context.Executing = false;
        }
    }
}
