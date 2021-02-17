using System.Collections.Generic;

namespace NbaseN
{
    /// <summary>
    /// default implementation for binary encoding
    /// </summary>
    public class Base2 : Base
    {
        /// <inheritdoc />
        public override IReadOnlyList<char> BaseChars { get; } = new[] {'0', '1'};
        
        /// <inheritdoc />
        public override int TargetBase => 2;
    }
}