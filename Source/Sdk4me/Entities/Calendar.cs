using Newtonsoft.Json;
using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/calendars/">calendar</see> object.
    /// </summary>
    public class Calendar : BaseItem
    {
        private List<CalendarHours> calendarHours;
        private bool disabled;
        private string name;
        private string source;
        private string sourceID;

        #region Calendar hours

        /// <summary>
        /// Readonly aggregated calendar hours
        /// </summary>
        [JsonProperty("calendar_hours")]
        public List<CalendarHours> CalendarHours
        {
            get => calendarHours;
            internal set => calendarHours = value;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the calendar may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the calendar.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Source

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            calendarHours?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
