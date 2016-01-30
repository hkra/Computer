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
    /// Execution delegate for the print instruction.
    /// </summary>
    public class Print : AbstractDelegate<Print>
    {
        /// <summary>
        /// Execute the print instruction.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <param name="instruction">The instruction.</param>
        public override void Execute(ExecutionContext context, Instruction instruction)
        {
            var value = (int)context.Decoder.Decode(context.Stack.Pop()).Operand;
            Console.WriteLine(value);
        }
    }
}
