using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/notes/">note</see> object.
    /// </summary>
    public class Note : BaseItem
    {
        private List<Attachment> attachments;
        private bool _internal;
        private AccountReference internalAccount;
        private NoteMedium medium;
        private Person person;
        private string text;

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.CreatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Account

        /// <summary>
        /// The account, only present for public notes.
        /// </summary>
        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public new AccountReference Account
        {
            get => base.Account;
            internal set => base.Account = value;
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Internal

        /// <summary>
        /// When the note is internal, the Internal field is set to true.
        /// </summary>
        [JsonProperty("internal")]
        public bool Internal
        {
            get => _internal;
            set => _internal = SetValue("internal", _internal, value);
        }

        #endregion

        #region Internal account

        /// <summary>
        /// The internal account, only present for internal notes.
        /// </summary>
        [JsonProperty("internal_account"), Sdk4meIgnoreInFieldSelection()]
        public AccountReference InternalAccount
        {
            get => internalAccount;
            internal set => internalAccount = value;
        }

        #endregion

        #region Medium

        /// <summary>
        /// The medium used to add the note. 
        /// </summary>
        [JsonProperty("medium")]
        public NoteMedium Medium
        {
            get => medium;
            internal set => medium = value;
        }

        #endregion

        #region Person

        /// <summary>
        /// The Manager field is used to select the manager of the organization.
        /// </summary>
        [JsonProperty("person")]
        public Person Person
        {
            get => person;
            set => person = SetValue("person_id", person, value);
        }

        [JsonProperty("person_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? PersonID => person?.ID;

        #endregion

        #region Text

        /// <summary>
        /// Required text (max 64KB), default: <see cref="string.Empty"/>.
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get => text;
            set => text = SetValue("text", text, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            Person?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
