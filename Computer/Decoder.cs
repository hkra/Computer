using Computer.Interfaces;
using Computer;
using System;

namespace Computer
{
    /// <summary>
    /// Instruction decoder.
    /// </summary>
    public class Decoder : IDecoder
    {
        /// <summary>
        /// Decode an instruction.
        /// </summary>
        /// <param name="rawOpValue">Encoded instruction composed of opcode and an optional operand.</param>
        /// <returns>A decoded instruction.</returns>
        public Instruction Decode(UInt64 rawOpValue)
        {
            return new Instruction
            {
                Type = (InstructionType)(rawOpValue >> 32),
                Operand = (Int32)(rawOpValue & 0x00000000FFFFFFFU)
            };
        }
    }
}
