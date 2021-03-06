﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Sdk4me
{
    public class FilterCollection : IList<Filter>
    {
        private readonly List<Filter> filterItems = new List<Filter>();

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public Filter this[int index]
        {
            get => filterItems[index];
            set => filterItems[index] = value;
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get => filterItems.Count;
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.   
        /// </summary>
        public bool IsReadOnly
        {
            get => ((IList<Filter>)filterItems).IsReadOnly;
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        public void Add(string attributeName, FilterCondition filter)
        {
            filterItems.Add(new Filter(attributeName, filter));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, string attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, DateTime attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, params short[] attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, params int[] attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, params long[] attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Add(string attributeName, FilterCondition filter, bool attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value. The enumeration name will be used, camel case names will be converted to snake case.</param>
        public void Add(string attributeName, FilterCondition filter, params Enum[] attributeValue)
        {
            filterItems.Add(new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Adds an object to the end of the collection.
        /// </summary>
        /// <param name="item">The object to be added to the end of the collection.</param>
        public void Add(Filter item)
        {
            filterItems.Add(item);
        }

        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public void Clear()
        {
            filterItems.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the collection.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>True if item is found in the collection; otherwise, false.</returns>
        public bool Contains(Filter item)
        {
            return filterItems.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from collection. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Filter[] array, int arrayIndex)
        {
            filterItems.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// A System.Collections.Generic.List.Enumerator for the collection.
        /// </summary>
        /// <returns>A System.Collections.Generic.List.Enumerator for the collection.</returns>
        public IEnumerator<Filter> GetEnumerator()
        {
            return filterItems.GetEnumerator();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire collection.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire collection, if found; otherwise, –1.</returns>
        public int IndexOf(Filter item)
        {
            return filterItems.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        public void Insert(int index, string attributeName, FilterCondition filter)
        {
            filterItems.Insert(index, new Filter(attributeName, filter));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, string attributeValue)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, DateTime attributeValue)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, params short[] attributeValues)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValues));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, params int[] attributeValues)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValues));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, params long[] attributeValues)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValues));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, bool attributeValue)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValue));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="attributeValue">The attribute value. The enumeration name will be used, camel case names will be converted to snake case.</param>
        public void Insert(int index, string attributeName, FilterCondition filter, params Enum[] attributeValues)
        {
            filterItems.Insert(index, new Filter(attributeName, filter, attributeValues));
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        public void Insert(int index, Filter item)
        {
            filterItems.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The object to remove from the collection</param>
        /// <returns>True if item is successfully removed; otherwise, false. This method also returns false if item was not found in the collection.</returns>
        public bool Remove(Filter item)
        {
            return filterItems.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            filterItems.RemoveAt(index);
        }

        /// <summary>
        /// A System.Collections.Generic.List.Enumerator for the collection.
        /// </summary>
        /// <returns>A System.Collections.Generic.List.Enumerator for the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return filterItems.GetEnumerator();
        }
    }
}
