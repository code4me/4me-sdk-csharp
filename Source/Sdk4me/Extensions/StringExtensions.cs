using System;
using System.Text;

namespace Sdk4me.Extensions
{
    internal static class StringExtensions
    {
#if NET452_OR_GREATER
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
#endif
    }
}
