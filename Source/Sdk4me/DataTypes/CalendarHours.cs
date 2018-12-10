using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Sdk4me
{
    public class CalendarHours : BaseItem
    {
        private string timeFrom;
        private string timeUntil;
        private string weekday;

        #region time_from

        [JsonProperty("time_from")]
        public string TimeFrom
        {
            get => timeFrom;
            internal set => timeFrom = value;
        }

        #endregion

        #region time_until

        [JsonProperty("time_until")]
        public string TimeUntil
        {
            get => timeUntil;
            internal set => timeUntil = value;
        }

        #endregion

        #region weekday

        [JsonProperty("weekday")]
        public string Weekday
        {
            get => weekday;
            internal set => weekday = value;
        }

        #endregion
    }
}
