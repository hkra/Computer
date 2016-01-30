using Computer.Interfaces;
using Computer;
using System;

namespace Computer
{
    /// <summary>
    /// Instruction encoder.
    /// </summary>
    public class Encoder : IEncoder
    {
        /// <summary>
        /// Encode an instruction.
        /// </summary>
        /// <param name="instruction">Instruction to encode.</param>
        /// <returns></returns>
        public UInt64 Encode(Instruction instruction)
        {
            if (instruction == null)
            {
                throw new ArgumentNullException("instruction");
            }

            UInt32 encodeOperand = (UInt32)instruction.Operand;

            switch (instruction.Type)
            {
                // No encoded operands
                case InstructionType.Mult: // Fallthrough intentional
                case InstructionType.Ret:
                case InstructionType.Stop:
                case InstructionType.Print:
                    encodeOperand = 0;
                    break;
            }

            return (((UInt64)instruction.Type) << 32) + encodeOperand;
        }
    }
}
