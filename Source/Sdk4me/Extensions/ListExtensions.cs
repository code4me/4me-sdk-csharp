using System.Collections.Generic;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A class containing <see cref="List{T}"/> extension methods.
    /// </summary>
    internal static class ListExtensions
    {
        /// <summary>
        /// Reset the property serialization collection.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="collection">The list on which to reset the property serialization collection.</param>
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
