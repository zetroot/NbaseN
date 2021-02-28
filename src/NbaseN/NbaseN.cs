using System;

namespace NbaseN
{
    /// <summary>
    /// NET base-n converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class NbaseN<T> where T : Base, new()
    {
        private static readonly Base baseN = new T();

        /// <summary>
        /// Convert <see cref="int"/> to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source int32 value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 32 chars length</exception>
        public static string ConvertToString(int value) => ArithmeticCore.ConvertToString(value, baseN);

        /// <summary>
        /// Convert <see cref="long"/> to string in <typeparamref name="T"/> base
        /// </summary>
        /// <param name="value">Source long value</param>
        /// <returns>String representation</returns>
        /// <exception cref="OverflowException">When result string is more than 64 chars length</exception>
        public static string ConvertToString(long value) => ArithmeticCore.ConvertToString(value, baseN);
    }
}