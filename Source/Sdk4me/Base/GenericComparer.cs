using System.Collections;
using System.Globalization;

namespace Sdk4me
{
    internal class GenericComparer
    {
        private static readonly Comparer comparer = new Comparer(CultureInfo.InvariantCulture);

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
