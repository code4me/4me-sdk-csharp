using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/people/contacts/">people contacts</see> object.
    /// </summary>
    public class Contact : BaseItem
    {
        private string email;
        private bool integration;
        private ContactType label;
        private string telephone;
        private string chat;
        private string website;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Email

        /// <summary>
        /// The Email field is used to enter the person’s work or personal email address.
        /// </summary>
        [JsonProperty("email"), Sdk4meIgnoreInFieldSelection()]
        public string Email
        {
            get => email;
            set => email = SetValue("email", email, value);
        }

        #endregion

        #region Integration

        /// <summary>
        /// The Integration field
        /// </summary>
        [JsonProperty("integration")]
        public bool Integration
        {
            get => integration;
            set => integration = SetValue("integration", integration, value);
        }

        #endregion

        #region Label

        /// <summary>
        /// The Label of the contact details.
        /// </summary>
        [JsonProperty("label")]
        public ContactType Label
        {
            get => label;
            set => label = SetValue("label", label, value);
        }

        #endregion

        #region Telephone

        /// <summary>
        /// The Telephone field is used to enter the person’s work, mobile, home, or fax number.
        /// </summary>
        [JsonProperty("telephone"), Sdk4meIgnoreInFieldSelection()]
        public string Telephone
        {
            get => telephone;
            set => telephone = SetValue("telephone", telephone, value);
        }

        #endregion

        #region Chat

        /// <summary>
        /// The Chat field is used to enter the link that can be used to start a direct chat with the person.
        /// </summary>
        [JsonProperty("chat"), Sdk4meIgnoreInFieldSelection()]
        public string Chat
        {
            get => chat;
            set => chat = SetValue("chat", chat, value);
        }

        #endregion

        #region Website

        /// <summary>
        /// The Website field is used to enter the person’s work or personal website URL.
        /// </summary>
        [JsonProperty("website"), Sdk4meIgnoreInFieldSelection()]
        public string Website
        {
            get => website;
            set => website = SetValue("website", website, value);
        }

        #endregion

        internal override HashSet<string> PropertySerializationCollection
        {
            get => HasChanged ? new HashSet<string>() { "email", "integration", "label", "telephone", "chat", "website" } : base.PropertySerializationCollection;
        }
    }
}
