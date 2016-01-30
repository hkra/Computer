using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    /// <summary>
    /// Type for decoded instructions.
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// The instruction type.
        /// </summary>
        public InstructionType Type { get; set; }

        /// <summary>
        /// Optional operand on which the instruction operates.
        /// </summary>
        public Int32 Operand { get; set; }
    }
}
