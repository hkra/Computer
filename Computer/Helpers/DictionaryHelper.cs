using Computer;
using System;
using System.Collections.Generic;

namespace Computer.Helpers
{
    /// <summary>
    /// Helper methods for working with IDictionary
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// Someone decided that dictionaries should throw instead of returning null...let's undo that.
        /// Tries to get a value for the given key. Returns null if it doesn't exist.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">They key.</param>
        /// <returns></returns>
        public static Action<ExecutionContext, Instruction> Lookup(this IDictionary<InstructionType, Action<ExecutionContext, Instruction>> dictionary, InstructionType key)
        {
            Action<ExecutionContext, Instruction> action;
            dictionary.TryGetValue(key, out action);
            return action;
        }
    }
}
