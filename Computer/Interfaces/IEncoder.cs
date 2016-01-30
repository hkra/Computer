using Computer;
using System;

namespace Computer.Interfaces
{
    /// <summary>
    /// Interface for implementations of instruction encoders.
    /// </summary>
    public interface IEncoder
    {
        /// <summary>
        /// Encode an instruction.
        /// </summary>
        /// <param name="instruction">Instruction to encode.</param>
        /// <returns></returns>
        UInt64 Encode(Instruction instruction);
    }
}
