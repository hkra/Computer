using System;

namespace Computer.Interfaces
{
    public interface IExecutionUnit
    {
        /// <summary>
        /// The Program Counter.
        /// </summary>
        Int32 ProgramCounter { get; set; }

        /// <summary>
        /// Begin program execution.
        /// </summary>
        void Execute();
    }
}
