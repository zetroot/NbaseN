using System;

namespace NbaseN
{
    /// <summary>
    /// NET base-n converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class NbaseN<T> where T : IBase, new()
    {
        private const int MAX_BUFFER_SIZE = 32; 
        private static readonly IBase baseN;

        static NbaseN()
        {
            baseN = new T();
        }
        
        /// <summary>
        /// Convert positive int32 to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source int32 value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 32 chars length</exception>
        public static string ConvertToString(int value)
        {
            // 32 is the worst cast buffer size for base 2 and int.MaxValue
            Span<char> buffer = stackalloc char[MAX_BUFFER_SIZE];

            for(int i = buffer.Length - 1; i>=0; --i)
            {
                buffer[i] = baseN.BaseChars[value % baseN.TargetBase];
                value = value / baseN.TargetBase;
                if (value <= 0)
                {
                    return new string(buffer.Slice(i));
                }
            }
            throw new OverflowException();
        }
    }
}