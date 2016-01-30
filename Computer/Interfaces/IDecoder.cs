using Computer;
using System;

namespace Computer.Interfaces
{
    /// <summary>
    /// Interface for implementations of instruction decoders.
    /// </summary>
    public interface IDecoder
    {
        /// <summary>
        /// Decode an instruction.
        /// </summary>
        /// <param name="rawOpValue">Encoded instruction composed of opcode and an optional operand.</param>
        /// <returns>A decoded instruction.</returns>
        Instruction Decode(UInt64 rawOpValue);
    }
}
