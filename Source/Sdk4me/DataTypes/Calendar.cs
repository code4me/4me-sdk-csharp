using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Calendar : BaseItem
    {
        private List<CalendarHours> calendarHours;
        private bool disabled;
        private string name;
        private string source;
        private string sourceID;

        #region calendar_hours

        [JsonProperty("calendar_hours")]
        public List<CalendarHours> CalendarHours
        {
            get => calendarHours;
            internal set => calendarHours = value;
        }

        #endregion

        #region disabled

        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set
            {
                if (disabled != value)
                    AddIncludedDuringSerialization("disabled");
                disabled = value;
            }
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                    AddIncludedDuringSerialization("name");
                name = value;
            }
        }

        #endregion

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (calendarHours != null)
                for (int i = 0; i < calendarHours.Count; i++)
                    calendarHours[i]?.ResetIncludedDuringSerialization();

            base.ResetIncludedDuringSerialization();
        }
    }
}
