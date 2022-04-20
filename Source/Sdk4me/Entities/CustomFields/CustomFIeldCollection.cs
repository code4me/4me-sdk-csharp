using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// A <see cref="CustomField"/> collection.
    /// </summary>
    [DebuggerDisplay("Count = {Count}")]
    public sealed class CustomFieldCollection : IDictionary<string, string>
    {
        private readonly Dictionary<string, string> collection = new Dictionary<string, string>();

        public event EventHandler Changed;

        /// <summary>
        /// Create a new instance of a <see cref="CustomFieldCollection"/>.
        /// </summary>
        internal CustomFieldCollection()
        {
            Clear();
        }

        /// <summary>
        /// Create a new instance of a <see cref="CustomFieldCollection"/>.
        /// </summary>
        /// <param name="customFields">A <see cref="List{T}"/> collection.</param>
        internal CustomFieldCollection(List<CustomField> customFields)
        {
            Clear();
            if (customFields != null)
            {
                for (int i = 0; i < customFields.Count; i++)
                    Add(customFields[i].ID, customFields[i].Value);
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the element to get or set.</param>
        /// <returns>The element with the specified identifier.</returns>
        public string this[string identifier]
        {
            get => collection[identifier];
            set
            {
                if (collection[identifier] != value)
                    Changed?.Invoke(this, EventArgs.Empty);
                collection[identifier] = value;
            }
        }

        /// <summary>
        /// Gets a collection containing the identifiers in the <see cref="CustomFieldCollection"/>.
        /// </summary>
        public ICollection<string> Keys
        {
            get => collection.Keys;
        }

        /// <summary>
        /// Gets a collection containing the values in the <see cref="CustomFieldCollection"/>.
        /// </summary>
        public ICollection<string> Values
        {
            get => collection.Values;
        }

        /// <summary>
        /// Gets the number of identifier/value pairs contained in the <see cref="CustomFieldCollection"/>.
        /// </summary>
        public int Count
        {
            get => collection.Count;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="CustomFieldCollection"/> is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get => ((IDictionary<string, string>)collection).IsReadOnly;
        }

        /// <summary>
        /// Adds the specified identifier and value to the collection.
        /// </summary>
        /// <param name="id">The identifier of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public void Add(string id, string value)
        {
            collection.Add(id, value);
            Changed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Adds or updates the specified identifier's value.
        /// </summary>
        /// <param name="id">The identifier of the element to add or update.</param>
        /// <param name="value">The value of the element to add or update. The value can be null for reference types.</param>
        public void AddOrUpdate(string id, string value)
        {
            if (collection.ContainsKey(id))
            {
                if (collection[id] != value)
                    Changed?.Invoke(this, EventArgs.Empty);
                collection[id] = value;
            }
            else
            {
                collection.Add(id, value);
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Adds the specified identifier and value to the collection.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="CustomFieldCollection"/>.</param>
        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds the specified identifier and value to the collection; or updates the value when the identifier already exists.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="CustomFieldCollection"/>.</param>
        public void AddOrUpdate(KeyValuePair<string, string> item)
        {
            AddOrUpdate(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all identifiers and values from the <see cref="CustomFieldCollection"/>.
        /// </summary>
        public void Clear()
        {
            collection.Clear();
            Changed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<string, string> item)
        {
            return collection.Contains(item);
        }

        /// <summary>
        /// Determines whether the <see cref="CustomFieldCollection"/> contains an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier to locate in the System.Collections.Generic.IDictionary`2.</param>
        /// <returns>True if the <see cref="CustomFieldCollection"/> contains an element with the identifier; otherwise, false.</returns>
        public bool ContainsKey(string id)
        {
            return collection.ContainsKey(id);
        }

        /// <summary>
        /// Copies the elements of the <see cref="CustomFieldCollection"/> to an System.Array, starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="CustomFieldCollection"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((IDictionary<string, string>)collection).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="CustomFieldCollection"/>.
        /// </summary>
        /// <returns>A <see cref="CustomFieldCollection"/>.Enumerator structure for the <see cref="CustomFieldCollection"/>.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        /// <summary>
        /// Removes the value with the specified identifier from the <see cref="CustomFieldCollection"/>.
        /// </summary>
        /// <param name="identifier">The identifier of the element to remove.</param>
        /// <returns>True if the element is successfully found and removed; otherwise, false. This method returns false if identifier is not found in the <see cref="CustomFieldCollection"/>.</returns>
        public bool Remove(string identifier)
        {
            bool result = collection.Remove(identifier);
            if (result)
                Changed?.Invoke(this, EventArgs.Empty);
            return result;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="CustomFieldCollection"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="CustomFieldCollection"/>.</param>
        /// <returns>true if item was successfully removed from the <see cref="CustomFieldCollection"/>; otherwise, false. This method also returns false if item is not found in the original <see cref="CustomFieldCollection"/>.</returns>
        public bool Remove(KeyValuePair<string, string> item)
        {
            bool result = ((IDictionary<string, string>)collection).Remove(item);
            if (result)
                Changed?.Invoke(this, EventArgs.Empty);
            return result;
        }

        /// <summary>
        /// Gets the value associated with the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified identifier, if the identifier is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns>True if the <see cref="CustomFieldCollection"/> contains an element with the specified identifier; otherwise, false.</returns>
        public bool TryGetValue(string identifier, out string value)
        {
            return collection.TryGetValue(identifier, out value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="CustomFieldCollection"/>.
        /// </summary>
        /// <returns>A <see cref="CustomFieldCollection"/>.Enumerator structure for the <see cref="CustomFieldCollection"/>./returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        /// <summary>
        /// Return the <see cref="CustomFieldCollection"/> as a <see cref="List{T}"/>.
        /// </summary>
        /// <returns></returns>
        internal List<CustomField> GetCustomFields()
        {
            List<CustomField> customFields = new List<CustomField>();
            foreach (string key in Keys)
            {
                customFields.Add(new CustomField()
                {
                    ID = key,
                    Value = this[key]
                });
            }
            return customFields;
        }
    }
}
