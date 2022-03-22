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

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        [JsonProperty("action"), Sdk4meIgnoreInFieldSelection()]
        public string Action { get; internal set; }

        [JsonProperty("created_by"), Sdk4meIgnoreInFieldSelection()]
        public Person CreatedBy { get; internal set; }

        [JsonProperty("user"), Sdk4meIgnoreInFieldSelection()]
        public AuditTrailUser User { get; internal set; }

        [JsonProperty("changes"), Sdk4meIgnoreInFieldSelection()]
        public Dictionary<string, JToken> Changes { get; internal set; }

        /// <summary>
        /// Get a change value.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="changeName">The change name.</param>
        /// <returns>The casted value.</returns>
        public T GetValue<T>(string changeName)
        {
            return (T)Changes[changeName].ToObject(typeof(T));
        }

        /// <summary>
        /// Get change values.
        /// </summary>
        /// <typeparam name="T">The 4me object type.</typeparam>
        /// <param name="changeName">The change name.</param>
        /// <returns>A collection of casted values.</returns>
        public List<T> GetValues<T>(string changeName)
        {
            return (List<T>)Changes[changeName].ToObject(typeof(List<T>));
            //return JsonConvert.DeserializeObject<T>(Changes[changeName])
        }
    }
}
