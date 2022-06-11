using System.Collections;
using System.Globalization;

namespace Sdk4me
{
    /// <summary>
    /// A <see cref="BaseItem"/> comparer.
    /// </summary>
    internal class GenericComparer
    {
        private static readonly Comparer comparer = new Comparer(CultureInfo.InvariantCulture);

        /// <summary>
        /// Performs a case-sensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of a and b. Less than zero: a is less than b. Zero: a equals b. Greater than zero: a is greater than b.</returns>
        internal static bool Compare(object x, object y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x is BaseItem xItem && y is BaseItem yItem
                ? xItem.ID == yItem.ID
                : comparer.Compare(x, y) == 0;
        }
    }
}
