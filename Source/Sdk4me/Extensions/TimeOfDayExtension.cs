using System;
using System.Text.RegularExpressions;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// Support conversion of military date format to and from <see cref="TimeSpan"/>.
    /// </summary>
    internal static class TimeOfDayExtension
    {
        /// <summary>
        /// Convert a <see cref="string"/> to <see cref="TimeSpan"/>; the minimum value is 00:00 and the maximum value is 24:00.
        /// </summary>
        /// <param name="value">The time value.</param>
        /// <returns>The converted string value.</returns>
        internal static TimeSpan ToTimeOfDayTimeSpan(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return TimeSpan.Zero;

            if (Regex.Match(value, "([0-2][0-3]:[0-5][0-9])|24:00").Success)
            {
                string[] data = value.Split(':');
                return new TimeSpan(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), 0);
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Convert a <see cref="TimeSpan"/> to 24 hour formatted <see cref="string"/>; the minimum value is 00:00 and the maximum value is 24:00.
        /// </summary>
        /// <param name="value">The time value.</param>
        /// <returns>The converted TimeSpan value.</returns>
        internal static string ToTimeOfDayString(this TimeSpan value)
        {
            if (value.TotalHours < 0)
                return "00:00";
            if (value.TotalHours >= 24)
                return "24:00";
            else
                return value.ToString(@"hh\:mm");
        }
    }
}
