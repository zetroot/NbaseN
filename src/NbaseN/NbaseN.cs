using System;

namespace NbaseN
{
    /// <summary>
    /// NET base-n converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class NbaseN<T> where T : Base, new()
    {
        /// <summary>
        /// Maximum local buffer size for using with int32 types
        /// </summary>
        private const int MAX_INT32_BUFFER_SIZE = 33; 
        private const int MAX_INT64_BUFFER_SIZE= 65; 
        private static readonly Base baseN;

        static NbaseN()
        {
            baseN = new T();
        }
        
        /// <summary>
        /// Convert positive <see cref="int"/> to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source int32 value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 32 chars length</exception>
        public static string ConvertToString(int value)
        {
            Span<char> buffer = stackalloc char[MAX_INT32_BUFFER_SIZE];
            
            var isNegative = value < 0;
            var absValue = Math.Abs(value);
            
            for(int i = buffer.Length - 1; i>=0; --i)
            {
                buffer[i] = baseN.BaseChars[absValue % baseN.TargetBase];
                absValue /= baseN.TargetBase;
                if (absValue <= 0)
                {
                    if (isNegative)
                        buffer[--i] = baseN.NegativeSign;
                    return new string(buffer.Slice(i));
                }
            }
            throw new OverflowException();
        }
        
        /// <summary>
        /// Convert positive <see cref="long"/> to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source long value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 32 chars length</exception>
        public static string ConvertToString(long value)
        {
            Span<char> buffer = stackalloc char[MAX_INT64_BUFFER_SIZE];

            var isNegative = value < 0;
            var absValue = Math.Abs(value);
            
            for(int i = buffer.Length - 1; i>=0; --i)
            {
                buffer[i] = baseN.BaseChars[(int)(absValue % baseN.TargetBase)];
                absValue /= baseN.TargetBase;
                if (absValue <= 0)
                {
                    if (isNegative)
                        buffer[--i] = baseN.NegativeSign;
                    return new string(buffer.Slice(i));
                }
            }
            throw new OverflowException();
        }
    }
}