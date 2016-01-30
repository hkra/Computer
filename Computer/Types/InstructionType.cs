using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    /// <summary>
    /// Available instruction types.
    /// </summary>
    public enum InstructionType : uint
    {   
        /// <summary>
        /// No-op placeholder for stack data. 
        /// </summary>
        Data = 0,

        /// <summary>
        /// Pop two arguments from the stack, multiply them, and push back the result.
        /// </summary>
        Mult,

        /// <summary>
        /// Set Program Counter to an address.
        /// </summary>
        Call,

        /// <summary>
        /// Pop address from the stack and set the program counter to the address.
        /// </summary>
        Ret,

        /// <summary>
        /// Halt program execution.
        /// </summary>
        Stop,

        /// <summary>
        /// Pop a value from the stack and print it.
        /// </summary>
        Print,

        /// <summary>
        /// Push a value to the stack.
        /// </summary>
        Push
    }
}
