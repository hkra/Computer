using Computer.Interfaces;
using Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Delegates
{
    public abstract class AbstractDelegate<T> : IInstructionDelegate where T : IInstructionDelegate, new()
    {
        public static Action<ExecutionContext, Instruction> GetAction()
        {
            var child = new T();
            return new Action<ExecutionContext, Instruction>(child.Execute);
        }

        public abstract void Execute(ExecutionContext context, Instruction instruction);
    }
}
