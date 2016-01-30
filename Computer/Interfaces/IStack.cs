using System;

namespace Computer
{
    /// <summary>
    /// Interface for implementations of a stack.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Gets the size of the stack.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Get the value at a given position in the stack.
        /// </summary>
        /// <param name="address">Address in the stack.</param>
        /// <returns>The value stored at <paramref name="address"/>.</returns>
        UInt64 GetAt(Int32 address);

        /// <summary>
        /// Pop an item off of the stack.
        /// </summary>
        /// <returns>The value from the top of the stack.</returns>
        UInt64 Pop();

        /// <summary>
        /// Push an item on the top of the stack.
        /// </summary>
        /// <param name="value">Value to push onto the stack.</param>
        void Push(UInt64 value);

        /// <summary>
        /// Sets the value at the given position in the stack.
        /// </summary>
        /// <param name="address">Address in the stack.</param>
        /// <param name="value">Value to set.</param>
        void SetAt(Int32 address, UInt64 value);
    }
}
