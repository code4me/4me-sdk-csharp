using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace Sdk4me
{
    public class BaseItem : IBaseType
    {
        private readonly HashSet<string> includedDuringSerialization = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private string allAttributeNames = null;


        /// <summary>
        /// The unique identifier of the object.
        /// </summary>
        [JsonProperty("id"), DebuggerDisplay("{ID}")]
        public long ID { get; set; }

        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        [JsonProperty("created_at")]
        public virtual DateTime? CreatedAt { get; internal set; }

        /// <summary>
        /// The date and time the object was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual DateTime? UpdatedAt { get; internal set; }

        /// <summary>
        /// Returns a copy of the attributes that will be serialized.
        /// </summary>
        internal HashSet<string> IncludeDuringSerialization
        {
            get => new HashSet<string>(includedDuringSerialization);
        }

        /// <summary>
        /// Get a comma separated string with all attributes.
        /// </summary>
        /// <returns>Returns a comma separated string of all attributes.</returns>
        internal string GetAllAttributeNames()
        {
            if (string.IsNullOrWhiteSpace(allAttributeNames))
            {
                List<string> allAttributes = new List<string>();
                Type type = this.GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                for (int i = 0; i <= properties.GetUpperBound(0); i++)
                {
                    if (properties[i].GetCustomAttribute(typeof(JsonPropertyAttribute)) is JsonPropertyAttribute jsonPropertyAttribute && !(properties[i].GetCustomAttribute(typeof(Sdk4meIgnoreInFieldSelectionAttribute)) is Sdk4meIgnoreInFieldSelectionAttribute))
                    {
                        allAttributes.Add(jsonPropertyAttribute.PropertyName ?? properties[i].Name);
                    }
                        
                }
                this.allAttributeNames = string.Join(",", allAttributes);
            }
            return this.allAttributeNames;
        }

        /// <summary>
        /// Checks if the dataset has changed, if not then there is no need for an API request.
        /// </summary>
        /// <returns>True if there is at least one attribute to be serialized; otherwise false.</returns>
        internal bool ShouldSendApiRequest()
        {
            if (includedDuringSerialization == null)
                return false;
            else if (includedDuringSerialization.Count == 0)
                return false;
            else if (includedDuringSerialization.Count == 1 && includedDuringSerialization.Contains("id"))
                return false;

            return true;
        }

        /// <summary>
        /// Adds the ID property attribute during serialization.
        /// </summary>
        internal void IncludeIdentifierDuringSerialization()
        {
            AddIncludedDuringSerialization("id");
        }

        /// <summary>
        /// Removes the ID property attribute during serialization.
        /// </summary>
        internal void RemoveIdentifierDuringSerialization()
        {
            RemoveIncludedDuringSerialization("id");
        }

        /// <summary>
        /// Adds an attribute during serialization.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        protected void AddIncludedDuringSerialization(string name)
        {
            if (!includedDuringSerialization.Contains(name))
                includedDuringSerialization.Add(name);
        }

        /// <summary>
        /// Removes and attribute during serialization.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        protected void RemoveIncludedDuringSerialization(string name)
        {
            if (includedDuringSerialization.Contains(name))
                includedDuringSerialization.Remove(name);
        }

        /// <summary>
        /// Removes all attributes during serialization.
        /// </summary>
        internal virtual void ResetIncludedDuringSerialization()
        {
            includedDuringSerialization.Clear();
        }
    }
}
