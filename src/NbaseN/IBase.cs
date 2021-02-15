using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// Интерфейс основания системы счисления
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// Символы алфавита
        /// </summary>
        IReadOnlyList<char> BaseChars { get; }
        
        /// <summary>
        /// Основание системы счисления
        /// </summary>
        int TargetBase { get; }
    }
}