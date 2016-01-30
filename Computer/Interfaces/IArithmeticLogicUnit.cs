using System;

namespace Computer.Interfaces
{
    /// <summary>
    /// Interface for implementations of arithmetic logic units.
    /// </summary>
    public interface IArithmeticLogicUnit
    {
        /// <summary>
        /// Multiply two 32-bit integers. Don't care about overflow (for now).
        /// </summary>
        /// <param name="arg1">First argument to be multiplied.</param>
        /// <param name="arg2">Second argument to be multiplied.</param>
        /// <returns>The product of the two arguments.</returns>
        Int32 Multiply(Int32 arg1, Int32 arg2);
    }
}
