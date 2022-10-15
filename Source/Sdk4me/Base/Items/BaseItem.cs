using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Sdk4me
{
    /// <summary>
    /// The base identity of a 4me object.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class BaseItem : IBaseItem
    {
        private readonly HashSet<string> propertySerializationCollection = new HashSet<string>();

        /// <summary>
        /// The unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }

        /// <summary>
        /// The unique GraphQL identifier.
        /// </summary>
        [JsonProperty("nodeID"), Sdk4meIgnoreInFieldSelection()]
        public string NodeID { get; set; }

        /// <summary>
        /// The creation date and time.
        /// </summary>
        [JsonProperty("created_at")]
        public virtual DateTime? CreatedAt { get; internal set; }

        /// <summary>
        /// The updated date and time.
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual DateTime? UpdatedAt { get; internal set; }

        /// <summary>
        /// The 4me account in which the object exists.
        /// <para>The value will be null unless the account of the resource is different from the account of the authenticated user; or the property does not exists for this entity.</para>
        /// </summary>
        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public AccountReference Account { get; internal set; }

        /// <summary>
        /// Returns the list of properties for which the value changed.
        /// </summary>
        internal virtual HashSet<string> PropertySerializationCollection
        {
            get => propertySerializationCollection;
        }

        /// <summary>
        /// Returns true when at least one of the properties values changed; otherwise false.
        /// </summary>
        internal bool HasChanged
        {
            get
            {
                if (propertySerializationCollection.Count.Equals(0))
                    return false;

                if (propertySerializationCollection.Count.Equals(1) && propertySerializationCollection.Contains("id"))
                    return false;

                return propertySerializationCollection.Count > 0;
            }
        }

        /// <summary>
        /// Get a comma separated string with all attributes except the onces with the <see cref="Sdk4meIgnoreInFieldSelectionAttribute"/> attribute.
        /// </summary>
        /// <returns>Returns a comma separated string of all attributes.</returns>
        internal string GetAllFieldNames()
        {
            List<string> allAttributes = new List<string>();
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttribute(TypeReferences.JsonPropertyAttributeType) is JsonPropertyAttribute jsonPropertyAttribute && property.GetCustomAttribute(TypeReferences.Sdk4meIgnoreInFieldSelectionAttributeType) is null)
                    allAttributes.Add(jsonPropertyAttribute.PropertyName);
            }
            return string.Join(",", allAttributes);
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <typeparam name="T">Any type implementing <see cref="IBaseItem"/>.</typeparam>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected T SetValue<T>(string name, T currentValue, T newValue)
        {
            if (!GenericComparer.Compare(currentValue, newValue))
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected int SetValue(string name, int currentValue, int newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected int? SetValue(string name, int? currentValue, int? newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected long SetValue(string name, long currentValue, long newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected long? SetValue(string name, long? currentValue, long? newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected string SetValue(string name, string currentValue, string newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected float SetValue(string name, float currentValue, float newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected float? SetValue(string name, float? currentValue, float? newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected bool SetValue(string name, bool currentValue, bool newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Checks the property value and when changed add it to the property serialization collection.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <returns>The new value of the property.</returns>
        protected TimeSpan SetValue(string name, TimeSpan currentValue, TimeSpan newValue)
        {
            if (currentValue != newValue)
                propertySerializationCollection.Add(name);
            return newValue;
        }

        /// <summary>
        /// Adds an item to the property serialization collection.
        /// </summary>
        /// <param name="name"></param>
        protected void AddPropertySerializationItem(string name)
        {
            propertySerializationCollection.Add(name);
        }

        /// <summary>
        /// Removes all attributes during serialization.
        /// </summary>
        internal virtual void ResetPropertySerializationCollection()
        {
            propertySerializationCollection.Clear();
        }
    }
}
