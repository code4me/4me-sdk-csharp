using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sdk4me
{
    [Serializable(), DebuggerDisplay("Count = {Count}")]
    public sealed class CustomFieldCollection : IDictionary<string, string>
    {
        private readonly Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private bool changed = false;

        public event EventHandler Changed;

        public bool HasChanged
        {
            get => changed;
        }

        public string this[string key]
        {
            get => keyValuePairs[key];
            set
            {
                if (keyValuePairs[key] != value)
                {
                    changed = true;
                    Changed?.Invoke(this, EventArgs.Empty);
                }
                keyValuePairs[key] = value;
            }
        }

        public ICollection<string> Keys
        {
            get => keyValuePairs.Keys;
        }

        public ICollection<string> Values
        {
            get => keyValuePairs.Values;
        }

        public int Count
        {
            get => keyValuePairs.Count;
        }

        public bool IsReadOnly
        {
            get => ((IDictionary<string, string>)keyValuePairs).IsReadOnly;
        }

        public void Add(string key, string value)
        {
            keyValuePairs.Add(key, value);
            changed = true;
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            ((IDictionary<string, string>)keyValuePairs).Add(item);
            changed = true;
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            keyValuePairs.Clear();
            changed = true;
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return keyValuePairs.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return keyValuePairs.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((IDictionary<string, string>)keyValuePairs).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return keyValuePairs.GetEnumerator();
        }

        public bool Remove(string key)
        {
            bool result = keyValuePairs.Remove(key);
            if (result)
            {
                changed = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            return result;
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            bool result = ((IDictionary<string, string>)keyValuePairs).Remove(item);
            if (result)
            {
                changed = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            return result;
        }

        public bool TryGetValue(string key, out string value)
        {
            return keyValuePairs.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return keyValuePairs.GetEnumerator();
        }

        internal CustomFieldCollection()
        {
            this.Clear();
            changed = false;
        }

        internal CustomFieldCollection(List<CustomField> customFields)
        {
            this.Clear();
            if (customFields != null)
            {
                for (int i = 0; i < customFields.Count; i++)
                    this.Add(customFields[i].ID, customFields[i].Value);
            }
            changed = false;
        }

        internal List<CustomField> GetCustomFields()
        {
            List<CustomField> customFields = new List<CustomField>();
            foreach (string key in this.Keys)
                customFields.Add(new CustomField()
                {
                    ID = key,
                    Value = this[key]
                });
            return customFields;
        }
    }
}
