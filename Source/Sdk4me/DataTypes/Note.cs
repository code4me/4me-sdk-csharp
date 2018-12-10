using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Note : BaseItem
    {
        private List<Attachment> attachments;
        private NoteMediumType? medium;
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

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region medium

        [JsonProperty("medium")]
        public NoteMediumType? Medium
        {
            get => medium;
            internal set => medium = value;
        }

        #endregion

        #region person

        [JsonProperty("person")]
        public Person Person
        {
            get => person;
            set
            {
                if (person?.ID != value?.ID)
                    AddIncludedDuringSerialization("person_id");
                person = value;
            }
        }

        [JsonProperty(PropertyName = "person_id"), Sdk4meIgnoreInFieldSelection()]
        private long? PersonID
        {
            get => (person != null ? person.ID : (long?)null);
        }

        #endregion

        #region text

        [JsonProperty("text")]
        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                    AddIncludedDuringSerialization("text");
                text = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            base.ResetIncludedDuringSerialization();
        }
    }
}
