using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// Hexadecimal implementation
    /// </summary>
    public class Base16 : IBase
    {
        /// <inheritdoc />
        public IReadOnlyList<char> BaseChars { get; } = new[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F'
        };

        /// <inheritdoc />
        public int TargetBase => 16;
    }
}