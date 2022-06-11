#if NET452_OR_GREATER
using System;
using System.Text;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A class containing <see cref="string"/> extension methods.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the provided comparison type.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of oldValue.</param>
        /// <param name="comparison">One of the enumeration values that determines how oldValue is searched within this instance.</param>
        /// <returns>A string that is equivalent to the current string except that all instances of oldValue are replaced with newValue. If oldValue is not found in the current instance, the method returns the current instance unchanged.</returns>
        public static string Replace(this string text, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int lastIndex = 0;
            int currIndex = text.IndexOf(oldValue, comparison);
            while (currIndex != -1)
            {
                stringBuilder.Append(text.Substring(lastIndex, currIndex - lastIndex));
                stringBuilder.Append(newValue);
                currIndex += oldValue.Length;
                lastIndex = currIndex;
                currIndex = text.IndexOf(oldValue, currIndex, comparison);
            }
            stringBuilder.Append(text.Substring(lastIndex));
            return stringBuilder.ToString();
        }
    }
}
#endif
