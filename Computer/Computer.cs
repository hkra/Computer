using Computer.Interfaces;
using Computer;
using System;

namespace Computer
{
    /// <summary>
    /// Concrete implementation of computer.
    /// </summary>
    public class Computer : IComputer
    {
        private readonly IExecutionUnit _executor;
        private readonly IStack _stack;
        private readonly IEncoder _encoder;
        
        public static Computer New(int stackSize)
        {
            var stack = new Stack(stackSize);
            var encoder = new Encoder();
            var executor = new ExecutionUnit(stack, encoder, new Decoder(), new ArithmeticLogicUnit());
            return new Computer(stack, encoder, executor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class.
        /// </summary>
        /// <param name="stackSize">The size of the stack in number of 64-bit elements.</param>
        public Computer(IStack stack, IEncoder encoder, IExecutionUnit executor)
        {
            _stack = stack;
            _encoder = encoder;
            _executor = executor;
        }

        /// <summary>
        /// Set program counter address.
        /// </summary>
        /// <returns>An instance of <see cref="IComputer"/> which can be used for method chaining.</returns>
        public IComputer SetAddress(Int32 address)
        {
            _executor.ProgramCounter = address;
            return this;
        }

        /// <summary>s
        /// Insert an instruction at the current address.
        /// </summary>
        /// <param name="instruction">Type of instruction.</param>
        /// <param name="operand">An optional instruction arguments.</param>
        /// <returns>An instance of <see cref="IComputer"/> which can be used for method chaining.</returns>
        public IComputer Insert(InstructionType type, Int32 operand = 0)
        {
            var instruction = new Instruction
            {
                Type = type,
                Operand = operand
            };
            
            _stack.SetAt(_executor.ProgramCounter++, _encoder.Encode(instruction));
            return this;
        }

        /// <summary>
        /// Begin program execution at the current address.
        /// </summary>
        public void Execute()
        {
            _executor.Execute();
        }
    }
}
