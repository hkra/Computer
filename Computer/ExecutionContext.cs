using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    /// <summary>
    /// Contains components necessary for program execution.
    /// </summary>
    public class ExecutionContext
    {
        /// <summary>
        /// The Program Counter.
        /// </summary>
        public Int32 ProgramCounter { get; set; }

        /// <summary>
        /// Gets or sets the arithmetic logic unit for arithmetic stuff. Unicorn.
        /// </summary>
        public IArithmeticLogicUnit Alu { get; set; }

        /// <summary>
        /// Gets or sets the program stack.
        /// </summary>
        public IStack Stack { get; set; }

        /// <summary>
        /// Gets or sets the instruction decoder.
        /// </summary>
        public IDecoder Decoder { get; set; }

        /// <summary>
        /// Gets or sets the instruction encoder.
        /// </summary>
        public IEncoder Encoder { get; set; }

        /// <summary>
        /// Gets or sets the executing flag.
        /// </summary>
        /// <value>True if the program is still executing. False if it should halt.</value>
        public bool Executing { get; set; }
    }
}
