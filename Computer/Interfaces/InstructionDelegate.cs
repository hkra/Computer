using Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Interfaces
{
    /// <summary>
    /// Interface for instruction execution delegates.
    /// </summary>
    public interface IInstructionDelegate
    {
        /// <summary>
        /// Execute the instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        void Execute(ExecutionContext context, Instruction instruction);
    }
}
