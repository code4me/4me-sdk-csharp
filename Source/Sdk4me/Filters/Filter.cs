using System;
using System.Text;

namespace Sdk4me
{
    public class Filter
    {
        /// <summary>
        /// Gets the attribute name.
        /// </summary>
        public string AttributeName { get; } = "";

        /// <summary>
        /// Gets the attribute value casted into a string.
        /// </summary>
        public string AttributeValue { get; } = "";

        /// <summary>
        /// Gets the filter condition.
        /// </summary>
        public FilterCondition Condition { get; } = FilterCondition.Equality;

        /// <summary>
        /// Gets the serialized filter.
        /// </summary>
        internal string FilterCommand
        {
            get => GetFilter();
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, string attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue;
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, DateTime attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue.ToString("yyyy-MM-ddTHH:mm:sszzz");
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, short attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue.ToString();
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, int attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue.ToString();
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, long attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue.ToString();
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public Filter(string attributeName, FilterCondition filter, bool attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = attributeValue ? "true" : "false";
            this.Condition = filter;
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value. The enumeration name will be used, camel case names will be converted to snake case.</param>
        public Filter(string attributeName, FilterCondition filter, Enum attributeValue)
        {
            this.AttributeName = Common.ConvertTo4meAttributeName(attributeName);
            this.AttributeValue = Common.ConvertTo4meAttributeName(attributeValue.ToString());
            this.Condition = filter;
        }

        /// <summary>
        /// Build an 4ME URI compliant filter.
        /// </summary>
        /// <returns>Returns a 4ME URI compliant filter syntax.</returns>
        private string GetFilter()
        {
            switch (this.Condition)
            {
                case FilterCondition.GreaterThan:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=>", Uri.EscapeDataString(this.AttributeValue));

                case FilterCondition.GreaterThanOrEqualsTo:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=>=", Uri.EscapeDataString(this.AttributeValue));

                case FilterCondition.LessThan:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=<", Uri.EscapeDataString(this.AttributeValue));

                case FilterCondition.LessThanOrEqualsTo:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=<=", Uri.EscapeDataString(this.AttributeValue));

                case FilterCondition.Negation:
                case FilterCondition.NotIn:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=!", Uri.EscapeDataString(this.AttributeValue));

                case FilterCondition.Present:
                    return string.Format("{0}{1}", Uri.EscapeDataString(this.AttributeName), "=!");

                case FilterCondition.Empty:
                    return string.Format("{0}{1}", Uri.EscapeDataString(this.AttributeName), "=");

                default:
                    return string.Format("{0}{1}{2}", Uri.EscapeDataString(this.AttributeName), "=", Uri.EscapeDataString(this.AttributeValue));
            }
        }
    }
}
