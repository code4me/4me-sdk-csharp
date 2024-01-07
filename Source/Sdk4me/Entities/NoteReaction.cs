using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/notes/note_reactions/">note reaction</see> object.
    /// </summary>
    public class NoteReaction : BaseItem
    {
        private long noteID;
        private Person person;
        private string reaction;

        #region Created at (override)

        /// <summary>
        /// The creation date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

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

        #region Note ID

        /// <summary>
        /// Reference to note.
        /// </summary>
        [JsonProperty("note_id"), Sdk4meIgnoreInFieldSelection()]
        public long NoteID
        {
            get => noteID;
            set => noteID = SetValue("note_id", noteID, value);
        }

        #endregion

        #region Person

        /// <summary>
        /// Readonly reference to Person.
        /// </summary>
        [JsonProperty("person")]
        public Person Person
        {
            get => person;
            internal set => person = value;
        }

        [JsonProperty("person_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? PersonID => person?.ID;

        #endregion

        #region Reaction

        /// <summary>
        /// The type of reaction to add to the note, possible values are 👍 👎 😀 😕 🎉 ❤️.
        /// </summary>
        [JsonProperty("reaction")]
        public string Reaction
        {
            get => reaction;
            set => reaction = SetValue("reaction", reaction, value);
        }

        #endregion
    }
}