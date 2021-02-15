using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// default implementation for binary encoding
    /// </summary>
    public class Base2 : IBase
    {
        /// <inheritdoc />
        public IReadOnlyList<char> BaseChars { get; } = new[] {'0', '1'};

        /// <inheritdoc />
        public int TargetBase => 2;
    }
}