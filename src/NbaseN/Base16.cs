using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// Hexadecimal implementation
    /// </summary>
    public class Base16 : Base
    {
        /// <inheritdoc />
        public override IReadOnlyList<char> BaseChars { get; } = new[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F'
        };

        /// <inheritdoc />
        public override int TargetBase => 16;
    }
}