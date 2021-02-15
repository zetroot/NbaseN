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
        private const int MAX_LONG_BUFFER_SIZE = 64; 
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
        
        /// <summary>
        /// Convert positive <see cref="long"/> to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source long value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 32 chars length</exception>
        public static string ConvertToString(long value)
        {
            Span<char> buffer = stackalloc char[MAX_LONG_BUFFER_SIZE];

            for(int i = buffer.Length - 1; i>=0; --i)
            {
                buffer[i] = baseN.BaseChars[(int)(value % baseN.TargetBase)];
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