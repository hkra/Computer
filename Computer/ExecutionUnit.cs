using Computer.Delegates;
using Computer.Helpers;
using Computer.Interfaces;
using Computer;
using System;
using System.Collections.Generic;

namespace Computer
{
    /// <summary>
    /// Program execution unit.
    /// </summary>
    public class ExecutionUnit : IExecutionUnit
    {
        private readonly IDictionary<InstructionType, Action<ExecutionContext, Instruction>> _dispatcher;
        private readonly ExecutionContext _context;

        /// <summary>
        /// The Program Counter.
        /// </summary>
        public Int32 ProgramCounter 
        {
            get { return _context.ProgramCounter; }
            set { _context.ProgramCounter = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <param name="encoder">The instruction encoder.</param>
        /// <param name="decoder">The instruction decoder.</param>
        public ExecutionUnit(IStack stack, IEncoder encoder, IDecoder decoder, IArithmeticLogicUnit alu)
        {
            _context = new ExecutionContext
            {
                Stack = stack,
                Encoder = encoder,
                Decoder = decoder,
                Alu = alu,
                Executing = true
            };

            _dispatcher = new Dictionary<InstructionType, Action<ExecutionContext, Instruction>>
            {
                { InstructionType.Mult, Multiply.GetAction() },
                { InstructionType.Call, Call.GetAction() },
                { InstructionType.Ret, Return.GetAction() },
                { InstructionType.Stop, Stop.GetAction() },
                { InstructionType.Print, Print.GetAction() },
                { InstructionType.Push, Push.GetAction() }
            };
        }

        /// <summary>
        /// Begin program execution.
        /// </summary>
        public void Execute()
        {
            while (_context.Executing)
            {
                // Fetch
                var nextOp = _context.Stack.GetAt(ProgramCounter++);

                //Decode
                var instruction = _context.Decoder.Decode(nextOp);

                // Execute
                (_dispatcher.Lookup(instruction.Type) ?? InvalidInstruction)(_context, instruction);
            }
        }

        private static void InvalidInstruction(ExecutionContext context, Instruction instruction)
        {
            throw new InvalidOperationException(instruction.ToString());
        }
    }
}
