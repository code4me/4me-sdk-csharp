using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me audit trail object.
    /// </summary>
    public class AuditTrail : BaseItem
    {
        #region Updated at (override)

        /// <summary>
        /// The updated date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region nodeID

        [JsonProperty("nodeID")]
        internal string NodeID { get; set; }

        #endregion

        /// <summary>
        /// Indicates the type of transactions that caused the audit entry to be generated.
        /// </summary>
        [JsonProperty("action"), Sdk4meIgnoreInFieldSelection()]
        public string Action { get; internal set; }

        /// <summary>
        /// Is set to the person who caused the audit entry to be generated.
        /// </summary>
        [JsonProperty("created_by"), Sdk4meIgnoreInFieldSelection()]
        public Person CreatedBy { get; internal set; }

        /// <summary>
        /// Is set to the person who caused the audit entry to be generated.
        /// </summary>
        [JsonProperty("user"), Sdk4meIgnoreInFieldSelection()]
        public AuditTrailUser User { get; internal set; }

        /// <summary>
        /// The old and the new value of each field’s value that was set or changed by the transaction that caused the audit entry to be generated.
        /// </summary>
        [JsonProperty("changes"), Sdk4meIgnoreInFieldSelection()]
        public Dictionary<string, JToken> Changes { get; internal set; }

        /// <summary>
        /// Provides a reference to the record for which the audit entry was generated.
        /// </summary>
        [JsonProperty("audited"), Sdk4meIgnoreInFieldSelection()]
        public string Audited { get; internal set; }

        /// <summary>
        /// The audit data.
        /// </summary>
        [JsonExtensionData, Sdk4meIgnoreInFieldSelection()]
        public Dictionary<string, JToken> Data { get; internal set; }

        /// <summary>
        /// Get a data value.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="dataName">The data property name.</param>
        /// <returns>The casted value.</returns>
        public T GetDataValue<T>(string dataName)
        {
            if (Data == null)
                return default(T);

            return (T)Data[dataName].ToObject(typeof(T));
        }

        /// <summary>
        /// Get a change value.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="changeName">The change property name.</param>
        /// <returns>The casted value.</returns>
        public T GetChangeValue<T>(string changeName)
        {
            if (Changes == null)
                return default(T);

            return (T)Changes[changeName].ToObject(typeof(T));
        }

        /// <summary>
        /// Get change values.
        /// </summary>
        /// <typeparam name="T">The 4me object type.</typeparam>
        /// <param name="changeName">The change property name.</param>
        /// <returns>A collection of casted values.</returns>
        public List<T> GetChangeValues<T>(string changeName)
        {
            if (Changes == null)
                return default(List<T>);

            return (List<T>)Changes[changeName].ToObject(typeof(List<T>));
        }
    }
}
