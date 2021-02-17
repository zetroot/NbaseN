using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NbaseN
{
    /// <summary>
    /// Base abstract class
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Alphabet chars
        /// </summary>
        public abstract IReadOnlyList<char> BaseChars { get; }

        /// <summary>
        /// Основание системы счисления
        /// </summary>
        public virtual int TargetBase => BaseChars.Count;
    }
}