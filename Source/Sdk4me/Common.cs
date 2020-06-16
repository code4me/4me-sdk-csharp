using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Sdk4me
{
    internal class Common
    {
        /// <summary>
        /// A list of hard coded conversion values.
        /// </summary>
        private static readonly string[] hardCodedConversions = new string[]
        {
            "sourceID",
            "supportID",
            "productID",
            "supplier_requestID",
            "systemID",
            "assetID",
            "employeeID",
            "authenticationID"
        };

        /// <summary>
        /// Converts a enumerator value to snake case string value; in case the filter is a Sdk4me.PredefinedEmptyFilter a null value will be returned.
        /// </summary>
        /// <typeparam name="T">A System.Enum compatible type.</typeparam>
        /// <param name="filter">The System.Enum value.</param>
        /// <returns>A snake case filter value; or null if T is Sdk4me.PredefinedEmptyFilter</returns>
        internal static string ConvertTo4mePredefinedFilter<T>(T filter) where T : Enum
        {
            if (typeof(T) == typeof(PredefinedDefaultFilter))
                return null;

            return ConvertTo4meAttributeName(filter.ToString());
        }

        /// <summary>
        /// Gets the enumerator member value for an enumerator.
        /// </summary>
        /// <typeparam name="T">A System.Enum compatible type.</typeparam>
        /// <param name="value">The enumerator value.</param>
        /// <returns>The enumerator member value.</returns>
        internal static string ConvertTo4meAttributeName<T>(T value) where T : Enum
        {
            Type enumType = typeof(T);
            string name = Enum.GetName(enumType, value);
            return ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single().Value;
        }

        /// <summary>
        /// Gets the enumerator member value for an array of enumerators.
        /// </summary>
        /// <typeparam name="T">A System.Enum compatible type.</typeparam>
        /// <param name="value">An array of enumerators values.</param>
        /// <returns>An array of enumerator member values.</returns>
        internal static string[] ConvertTo4meAttributeName<T>(T[] values) where T : Enum
        {
            string[] retval = new string[values.Length];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                retval[i] = ConvertTo4meAttributeName(values[i]);
            return retval;
        }

        /// <summary>
        /// Converts an attribute name to snake case attribute name; known exception such as sourceID and supportID will not be converted.
        /// </summary>
        /// <param name="attributeName">The attribute name to be converted.</param>
        /// <returns>A snake case attribute name value.</returns>
        internal static string ConvertTo4meAttributeName(string attributeName)
        {
            //MAKE SURE IT IS NOT BLANK OR NULL
            if (string.IsNullOrWhiteSpace(attributeName))
                return attributeName;

            //CHECK IF THIS ATTRIBUTE HAS A HARD CODED CONVERSION VALUE
            for (int i = 0; i <= hardCodedConversions.GetUpperBound(0); i++)
                if (attributeName.Equals(hardCodedConversions[i], StringComparison.InvariantCultureIgnoreCase))
                    return hardCodedConversions[i];

            //CONVERT TO SNAKE CASE
            string retval = "";
            for (int i = 0; i < attributeName.Length; i++)
            {
                bool isPrevCharLower = i != 0 && char.IsLower(attributeName[i - 1]);
                bool isPrevCharNumber = i != 0 && char.IsNumber(attributeName[i - 1]);

                if ((isPrevCharLower && char.IsUpper(attributeName[i])) || (isPrevCharNumber && char.IsUpper(attributeName[i])))
                    retval += "_";
                retval += char.ToLower(attributeName[i]);
            }
            return retval;
        }

        /// <summary>
        /// Converts an array of attribute names to an array of snake case attribute names; known exception such as sourceID and supportID will not be converted.
        /// </summary>
        /// <param name="attributeNames">An array of attribute names to be converted.</param>
        /// <returns>An array of snake case attribute name values.</returns>
        internal static string[] ConvertTo4meAttributeNames(string[] attributeNames)
        {
            if (attributeNames == null)
                return null;

            string[] retval = new string[attributeNames.Length];

            for (int i = 0; i <= attributeNames.GetUpperBound(0); i++)
                retval[i] = ConvertTo4meAttributeName(attributeNames[i]);

            return retval;
        }

        /// <summary>
        /// Returns the base URL for a specific environment.
        /// </summary>
        /// <param name="environmentType">The environment type.</param>
        /// <returns>The base URL for the specified environment.</returns>
        internal static string GetBaseUrl(EnvironmentType environmentType)
        {
            switch (environmentType)
            {
                case EnvironmentType.Quality:
                    return "https://api.4me.qa";

                case EnvironmentType.Demo:
                    return "https://api.4me-demo.com";

                default:
                    return "https://api.4me.com";
            }
        }


    }
}
