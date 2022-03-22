using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me
{
    /// <summary>
    /// The base identity of a 4me object extended with the CustomField property.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class CustomFieldsBaseItem : BaseItem
    {
        private CustomFieldCollection customFields;

        #region Custom fields

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        [JsonProperty("custom_fields")]
        internal List<CustomField> CustomFieldsList
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        /// <summary>
        /// Returns the custom fields.
        /// </summary>
        [JsonIgnore(), Sdk4meIgnoreInFieldSelection()]
        public CustomFieldCollection CustomFields
        {
            get
            {
                if (customFields == null)
                {
                    customFields = new CustomFieldCollection();
                    customFields.Changed += CustomFields_Changed;
                }
                return customFields;
            }
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddPropertySerializationItem("custom_fields");
        }

        #endregion
    }
}
