using Newtonsoft.Json;
using Sdk4me.Extensions;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/calendars/calendar_hours/">calendar hours</see> object.
    /// </summary>
    public class CalendarHours : BaseItem
    {
        private TimeSpan timeFrom;
        private TimeSpan timeUntil;
        private CalendarWeekDay weekday;

        #region Created at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region Updated at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Time from

        /// <summary>
        /// The time at which the calendar becomes active on the given weekday.
        /// </summary>
        public TimeSpan TimeFrom
        {
            get => timeFrom;
            set => timeFrom = SetValue("time_from", timeFrom, value);
        }

        [JsonProperty("time_from")]
        internal string TimeFromValue
        {
            get => timeFrom.ToTimeOfDayString();
            set => timeFrom = value.ToTimeOfDayTimeSpan();
        }

        #endregion

        #region Time until

        /// <summary>
        /// The time at which the calendar stops being active on the given weekday.
        /// </summary>
        public TimeSpan TimeUntil
        {
            get => timeUntil;
            set => timeUntil = SetValue("time_until", timeUntil, value);
        }

        [JsonProperty("time_until")]
        internal string TimeUntilValue
        {
            get => timeUntil.ToTimeOfDayString();
            set => timeUntil = value.ToTimeOfDayTimeSpan();
        }

        #endregion

        #region Weekday

        /// <summary>
        /// The day of the week.
        /// </summary>
        [JsonProperty("weekday")]
        public CalendarWeekDay Weekday
        {
            get => weekday;
            set => weekday = SetValue("weekday", weekday, value);
        }

        #endregion

        internal override HashSet<string> PropertySerializationCollection
        {
            get => HasChanged ? new HashSet<string>() { "time_from", "time_until", "weekday" } : base.PropertySerializationCollection;
        }
    }
}
