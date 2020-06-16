using System;
using System.Text;

namespace Sdk4me
{
    public class Filter
    {
        private readonly string attributeName = "";
        private readonly string[] attributeValues = null;
        private readonly FilterCondition filter = FilterCondition.Equality;

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        public Filter(string attributeName, FilterCondition filter)
        {
            if (filter != FilterCondition.Present && filter != FilterCondition.Empty)
                throw new ArgumentNullException("attributeValue");
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[0];
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, string attributeValue)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[1];
            this.attributeValues[0] = EscapeUriString(attributeValue ?? "");
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, DateTime attributeValue)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[1];
            this.attributeValues[0] = attributeValue.ToString("yyyy-MM-ddTHH:mm:sszzz");
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, short[] attributeValues)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[attributeValues.GetUpperBound(0) + 1];
            for (int i = 0; i <= attributeValues.GetUpperBound(0); i++)
                this.attributeValues[i] = attributeValues[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, params int[] attributeValues)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[attributeValues.GetUpperBound(0) + 1];
            for (int i = 0; i <= attributeValues.GetUpperBound(0); i++)
                this.attributeValues[i] = attributeValues[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, params long[] attributeValues)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[attributeValues.GetUpperBound(0) + 1];
            for (int i = 0; i <= attributeValues.GetUpperBound(0); i++)
                this.attributeValues[i] = attributeValues[i].ToString();
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, bool attributeValue)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[1];
            this.attributeValues[0] = attributeValue ? "true" : "false";
            this.filter = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value. The enumeration name will be used, camel case names will be converted to snake case.</param>
        public Filter(string attributeName, FilterCondition filter, params Enum[] attributeValues)
        {
            this.attributeName = EscapeUriString(Common.ConvertTo4meAttributeName(attributeName));
            this.attributeValues = new string[attributeValues.GetUpperBound(0) + 1];
            for (int i = 0; i <= attributeValues.GetUpperBound(0); i++)
                this.attributeValues[i] = EscapeUriString(Common.ConvertTo4meAttributeName(attributeValues[i].ToString()));
            this.filter = filter;
        }

        /// <summary>
        /// Build an 4me URI compliant filter.
        /// </summary>
        /// <returns>Returns a 4ME URI compliant filter syntax.</returns>
        internal string GetFilter()
        {
            switch (this.filter)
            {
                case FilterCondition.GreaterThan:
                    return string.Format("{0}{1}{2}", this.attributeName, "=>", string.Join(",", this.attributeValues));

                case FilterCondition.GreaterThanOrEqualsTo:
                    return string.Format("{0}{1}{2}", this.attributeName, "=>=", string.Join(",", this.attributeValues));

                case FilterCondition.LessThan:
                    return string.Format("{0}{1}{2}", this.attributeName, "=<", string.Join(",", this.attributeValues));

                case FilterCondition.LessThanOrEqualsTo:
                    return string.Format("{0}{1}{2}", this.attributeName, "=<=", string.Join(",", this.attributeValues));

                case FilterCondition.Negation:
                case FilterCondition.NotIn:
                    return string.Format("{0}{1}{2}", this.attributeName, "=!", string.Join(",", this.attributeValues));

                case FilterCondition.Present:
                    return string.Format("{0}{1}", this.attributeName, "=!");

                case FilterCondition.Empty:
                    return string.Format("{0}{1}", this.attributeName, "=");

                default:
                    return string.Format("{0}{1}{2}", this.attributeName, "=", string.Join(",", this.attributeValues));
            }
        }

        /// <summary>
        /// Converts a string to its escaped URI representation (except comma).
        /// </summary>
        /// <param name="value">The string to escape.</param>
        /// <returns>A System.String that contains the escaped URI representation of stringToEscape.</returns>
        private string EscapeUriString(string value)
        {
            return Uri.EscapeDataString(value).Replace("%2C", "\\,");
        }
    }
}
