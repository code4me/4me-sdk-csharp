using System;
using System.Collections.Generic;

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
            "assetID"
        };

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
                bool isPrevCharLower = (i == 0) ? false : char.IsLower(attributeName[i - 1]);
                bool isPrevCharNumber = (i == 0) ? false : char.IsNumber(attributeName[i - 1]);

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

            for (int i = retval.GetLowerBound(0); i < attributeNames.Length; i++)
                retval[i] = ConvertTo4meAttributeName(attributeNames[i]);

            return retval;
        }
    }
}
