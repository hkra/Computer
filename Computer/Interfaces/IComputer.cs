using System;

namespace Computer
{
    /// <summary>
    /// Interface for computer implementations.
    /// </summary>
    public interface IComputer
    {
        /// <summary>
        /// Set program counter address.
        /// </summary>
        /// <returns>An instance of <see cref="IComputer"/> which can be used for method chaining.</returns>
        IComputer SetAddress(Int32 address);

        /// <summary>
        /// Insert an instruction at the current address.
        /// </summary>
        /// <param name="instruction">Type of instruction.</param>
        /// <param name="args">An array of instruction arguments.</param>
        /// <returns>An instance of <see cref="IComputer"/> which can be used for method chaining.</returns>
        IComputer Insert(InstructionType type, Int32 operand = 0);

        /// <summary>
        /// Begin program execution at the current address (default 0).
        /// </summary>
        void Execute();
    }
}
