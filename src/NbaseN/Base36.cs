using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// Base 36 conversion. Alphabet of 10 digits and 26 english capital letters
    /// </summary>
    public class Base36 : Base
    {
        /// <inheritdoc />
        public override IReadOnlyList<char> BaseChars { get; } = new[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        /// <inheritdoc />
        public override int TargetBase => 36;
    }
}