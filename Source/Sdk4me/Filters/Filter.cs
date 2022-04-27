using Sdk4me.Extensions;
using System;

namespace Sdk4me
{
    public class Filter
    {
        private readonly string fieldName = null;
        private readonly string[] attributeValues = null;
        private readonly FilterCondition filter = FilterCondition.Equality;

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        public Filter(string fieldName, FilterCondition filter)
            : this(fieldName, filter, (string)null)
        {
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="value">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, string value)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[1];
            attributeValues[0] = Uri.EscapeDataString(value ?? "");
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="value">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, DateTime value)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[1];
            attributeValues[0] = Uri.EscapeDataString(value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            this.filter = filter;
        }

        /// <summary>
        /// Create a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="value1">The first attribute value.</param>
        /// <param name="value2">The second attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, DateTime value1, DateTime value2)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[2];
            attributeValues[0] = Uri.EscapeDataString(value1.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            attributeValues[1] = Uri.EscapeDataString(value2.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="value">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, BaseItem value)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[1];
            attributeValues[0] = value.ID.ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="values">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, params short[] values)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[values.GetUpperBound(0) + 1];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                attributeValues[i] = values[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="values">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, params int[] values)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[values.GetUpperBound(0) + 1];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                attributeValues[i] = values[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="values">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, params long[] values)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[values.GetUpperBound(0) + 1];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                attributeValues[i] = values[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="value">The attribute value.</param>
        public Filter(string fieldName, FilterCondition filter, bool value)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[1];
            attributeValues[0] = value ? "true" : "false";
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="values">The attribute value. The enumeration name will be used, camel case names will be converted to snake case.</param>
        public Filter(string fieldName, FilterCondition filter, params Enum[] values)
        {
            this.fieldName = EscapeUriString(fieldName.To4meString());
            attributeValues = new string[values.GetUpperBound(0) + 1];
            for (int i = 0; i <= values.GetUpperBound(0); i++)
                attributeValues[i] = Uri.EscapeDataString(values[i].To4meString());
            this.filter = filter;
        }

        /// <summary>
        /// Build an 4me URI compliant filter.
        /// </summary>
        /// <returns>Returns a 4ME URI compliant filter syntax.</returns>
        internal string GetFilter()
        {
            switch (filter)
            {
                case FilterCondition.GreaterThan:
                case FilterCondition.GreaterThanOrEqualsTo:
                case FilterCondition.LessThan:
                case FilterCondition.LessThanOrEqualsTo:
                    if (attributeValues is null || attributeValues.Length != 1)
                        throw new ApplicationException($"The {filter} filter requires a single value.");
                    return $"{fieldName}{"=<="}{attributeValues[0]}";

                case FilterCondition.GreaterThanAndLessThan:
                    if (attributeValues is null || attributeValues.Length != 1)
                        throw new ApplicationException($"The {filter} filter requires a single value.");
                    return $"{fieldName}{"=>"}{attributeValues[0]}<{attributeValues[1]}";

                case FilterCondition.GreaterThanOrEqualToAndLessThanOrEqualTo:
                    if (attributeValues is null || attributeValues.Length != 2)
                        throw new ApplicationException($"The {filter} filter requires a two values.");
                    return $"{fieldName}{"=>="}{attributeValues[0]}<={attributeValues[1]}";

                case FilterCondition.Negation:
                    if (attributeValues is null || attributeValues.Length != 1)
                        throw new ApplicationException($"The {filter} filter requires a single value.");
                    return $"{fieldName}{"=!"}{attributeValues[0]}";

                case FilterCondition.In:
                    return $"{fieldName}{"="}{string.Join(",", attributeValues)}";

                case FilterCondition.NotIn:
                    return $"{fieldName}{"=!"}{string.Join(",", attributeValues)}";

                case FilterCondition.Present:
                    return $"{fieldName}=!";

                case FilterCondition.Empty:
                    return $"{fieldName}=";

                default:
                    if (attributeValues is null || attributeValues.Length != 1)
                        throw new ApplicationException($"The {filter} filter requires a single value.");
                    return $"{fieldName}{"="}{attributeValues[0]}";
            }
        }

        /// <summary>
        /// Converts a string to its escaped URI representation (except comma).
        /// </summary>
        /// <param name="value">The string to escape.</param>
        /// <returns>A System.String that contains the escaped URI representation of stringToEscape.</returns>
        private static string EscapeUriString(string value)
        {
            return Uri.EscapeDataString(value).Replace("%2C", "\\,", StringComparison.OrdinalIgnoreCase);
        }
    }
}
