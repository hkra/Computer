using System;

namespace Computer
{
    /// <summary>
    /// Computer stack.
    /// </summary>
    public class Stack : IStack
    {
        private UInt64[] stack;

        /// <summary>
        /// The Stack Pointer.
        /// </summary>
        public Int32 StackPointer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack"/> class.
        /// </summary>
        /// <param name="size">Size of the stack in elements.</param>
        public Stack(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("size", "stack size must be positive");
            }

            stack = new UInt64[size];
        }

        /// <summary>
        /// Gets the size of the stack.
        /// </summary>
        public int Size
        {
            get
            {
                return stack.Length;
            }
        }

        /// <summary>
        /// Get the value at a given position in the stack.
        /// </summary>
        /// <param name="address">Address in the stack.</param>
        /// <returns>The value stored at <paramref name="address"/>.</returns>
        public UInt64 GetAt(Int32 address)
        {
            return stack[address];
        }

        /// <summary>
        /// Pop an item off of the stack.
        /// </summary>
        /// <returns>The value from the top of the stack.</returns>
        public UInt64 Pop()
        {
            return stack[StackPointer--];
        }
        
        /// <summary>
        /// Push an item on the top of the stack.
        /// </summary>
        /// <param name="value">Value to push onto the stack.</param>
        public void Push(UInt64 value)
        {
            StackPointer++;

            if (StackPointer >= stack.Length)
            {
                throw new StackOverflowException();
            }

            stack[StackPointer] = value;
        }

        /// <summary>
        /// Sets the value at the given position in the stack.
        /// </summary>
        /// <param name="address">Address in the stack.</param>
        /// <param name="value">Value to set.</param>
        public void SetAt(Int32 address, UInt64 value)
        {
            stack[address] = value;

            if (address > StackPointer)
            {
                StackPointer = address;
            }
        }
    }
}
