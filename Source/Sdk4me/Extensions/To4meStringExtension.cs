using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A class to converts 4me enumerators and property names.
    /// </summary>
    internal static class To4meStringExtension
    {
        private static readonly List<string> hardCodedConversions = new List<string>()
        {
            "assetID",
            "authenticationID",
            "employeeID",
            "financialID",
            "productID",
            "sourceID",
            "supplierRequestID",
            "supportID",
            "systemID",
            "supplier_requestID",
            "billingID",
            "agreementID",
            "activityID",
            "chargeID",
            "RateID"
        };

        /// <summary>
        /// Convert to the 4me snake case variant.
        /// </summary>
        /// <typeparam name="T">Any <see cref="Enum"/> type.</typeparam>
        /// <param name="value">The <see cref="Enum"/> value.</param>
        /// <returns>A 4me snake case value; or null if the value is <see cref="PredefinedDefaultFilter"/>.</returns>
        internal static string To4meString<T>(this T value) where T : Enum
        {
            return value == null || typeof(T) == TypeReferences.PredefinedDefaultFilterType ? null : value.GetEnumMemberValue().To4meString();
        }

        /// <summary>
        /// Convert to the 4me specific snake case variant.
        /// </summary>
        /// <typeparam name="T">Any <see cref="T:Enum[]"/> type.</typeparam>
        /// <param name="values">Any <see cref="T:Enum[]"/> value.</param>
        /// <returns>A collection of 4me snake case values; or null if the value in the collection is <see cref="PredefinedDefaultFilter"/>.</returns>
        internal static string[] To4meString<T>(this T[] values) where T : Enum
        {
            //cannot be null
            if (values == null)
                return null;

            string[] retval = new string[values.Length];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                retval[i] = values[i].To4meString();
            return retval;
        }

        /// <summary>
        /// Convert to the 4me specific snake case variant.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>A 4me snake case value.</returns>
        internal static string To4meString(this string value)
        {
            //cannot be blank or null
            if (string.IsNullOrWhiteSpace(value))
                return value;

            //convert to 4me snake case
            return Get4meString(value);
        }

        /// <summary>
        /// Convert to the 4me specific snake case variant.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>A collection of 4me snake case values.</returns>
        internal static string[] To4meString(this string[] values)
        {
            //cannot be null
            if (values == null)
                return null;

            string[] retval = new string[values.Length];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                retval[i] = values[i].To4meString();
            return retval;
        }

        /// <summary>
        /// <para>Convert a string to a 4me compatible snake case string.</para>
        /// <para>Field names end with ID instead of _id and keep commas</para>
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>A 4me compatible string value.</returns>
        internal static string Get4meString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            string convertionValue = hardCodedConversions.Find(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (convertionValue != null)
                return convertionValue;

            StringBuilder builder = new StringBuilder(value.Length + Math.Min(2, value.Length / 5));
            UnicodeCategory? previousCategory = default(UnicodeCategory?);

            for (int currentIndex = 0; currentIndex < value.Length; currentIndex++)
            {
                char currentChar = value[currentIndex];
                if (currentChar == '_' || currentChar == ',')
                {
                    builder.Append(currentChar);
                    previousCategory = null;
                    continue;
                }

                UnicodeCategory currentCategory = char.GetUnicodeCategory(currentChar);
                switch (currentCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.TitlecaseLetter:
                        if (previousCategory == UnicodeCategory.SpaceSeparator ||
                            previousCategory == UnicodeCategory.LowercaseLetter ||
                            previousCategory != UnicodeCategory.DecimalDigitNumber &&
                            previousCategory != null &&
                            currentIndex > 0 &&
                            currentIndex + 1 < value.Length &&
                            char.IsLower(value[currentIndex + 1]))
                        {
                            builder.Append('_');
                        }

                        currentChar = char.ToLower(currentChar, CultureInfo.InvariantCulture);
                        break;

                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (previousCategory == UnicodeCategory.SpaceSeparator)
                        {
                            builder.Append('_');
                        }
                        break;

                    default:
                        if (previousCategory != null)
                        {
                            previousCategory = UnicodeCategory.SpaceSeparator;
                        }
                        continue;
                }

                builder.Append(currentChar);
                previousCategory = currentCategory;
            }

            //if it ends with _id convert it back to ID
            return builder.ToString();
        }
    }
}
