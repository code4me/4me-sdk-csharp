using System.Collections.Generic;

namespace Sdk4me.Extensions
{
    internal static class ListExtensions
    {
        public static void ResetPropertySerializationCollection<T>(this List<T> collection) where T : BaseItem
        {
            if (collection != null)
            {
                foreach (T item in collection)
                    item.ResetPropertySerializationCollection();
            }
        }
    }
}
