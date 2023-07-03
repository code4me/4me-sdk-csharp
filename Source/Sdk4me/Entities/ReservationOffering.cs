using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/reservation_offerings/">reservation offering</see> object.
    /// </summary>
    public class ReservationOffering : BaseItem
    {
        private bool allowRepeat;
        private bool disabled;
        private Calendar calendar;
        private List<ReservationOfferingFilters> filterCollection;
        private ReservationOfferingStatus initialStatus;
        private TimeSpan? maxAdvanceDuration;
        private TimeSpan maxDuration;
        private TimeSpan? minAdvanceDuration;
        private TimeSpan minDuration;
        private bool multiDay;
        private string name;
        private TimeSpan? preparationDuration;
        private ServiceInstance serviceInstance;
        private string source;
        private string sourceID;
        private TimeSpan stepDuration;
        private string timeZone;

        #region Allow repeat

        /// <summary>
        /// Whether it is allowed to create recurrent reservations for this offering.
        /// </summary>
        [JsonProperty("allow_repeat")]
        public bool AllowRepeat
        {
            get => allowRepeat;
            set => allowRepeat = SetValue("allow_repeat", allowRepeat, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the reservation offering may not be related to a request template any more.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Calendar

        /// <summary>
        /// The Calendar field is used to select the Calendar that defines the hours during which the Configuration Items can be made available for temporary use.
        /// </summary>
        [JsonProperty("calendar")]
        public Calendar Calendar
        {
            get => calendar;
            set => calendar = SetValue("calendar_id", calendar, value);
        }

        [JsonProperty("calendar_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CalendarID => calendar?.ID;

        #endregion

        #region Filters

        /// <summary>
        /// The Filters field allows filters to be selected that people, who are selecting a configuration item of the reservation offering, can use to limit the list of configuration items to only those that meet specific criteria, such as the configuration item’s product or site.
        /// </summary>
        public ReservationOfferingFilters Filters
        {
            get
            {
                ReservationOfferingFilters retval = ReservationOfferingFilters.None;
                foreach (ReservationOfferingFilters filter in filterCollection)
                    retval |= filter;
                return retval;
            }
            set
            {
                List<ReservationOfferingFilters> items = Enum.GetValues(value.GetType()).Cast<Enum>().Where(value.HasFlag).Cast<ReservationOfferingFilters>().ToList();
                items.Remove(ReservationOfferingFilters.None);
                if (!Enumerable.SequenceEqual(filterCollection, items))
                {
                    filterCollection = items;
                    AddPropertySerializationItem("filters");
                }
            }
        }

        [JsonProperty("filters")]
        internal List<ReservationOfferingFilters> FilterCollection
        {
            get => filterCollection;
            set => filterCollection = value;
        }

        #endregion

        #region Initial status

        /// <summary>
        /// The Initial status field is used to specify whether a reservation that was requested using the reservation offering is immediately confirmed after it has been submitted, or that an action (such as an approval) is still required before it can be confirmed. 
        /// </summary>
        [JsonProperty("initial_status")]
        public ReservationOfferingStatus InitialStatus
        {
            get => initialStatus;
            set => initialStatus = SetValue("initial_status", initialStatus, value);
        }

        #endregion

        #region Max advance duration

        /// <summary>
        /// The maximum advance duration field is used to specify how far in the future the start of a reservation is allowed to be scheduled using the reservation offering.
        /// </summary>
        public TimeSpan? MaxAdvanceDuration
        {
            get => maxAdvanceDuration;
            set => maxAdvanceDuration = SetValue("max_advance_duration", maxAdvanceDuration, value);
        }

        [JsonProperty("max_advance_duration")]
        internal int? MaxAdvanceDurationInMinutes
        {
            get => maxAdvanceDuration != null ? Convert.ToInt32(maxAdvanceDuration.Value.TotalMinutes) : (int?)null;
            set => maxAdvanceDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Max duration

        /// <summary>
        /// The maximum duration field is used to specify the maximum length of time for which a configuration item of the reservation offering can be reserved.
        /// </summary>
        public TimeSpan MaxDuration
        {
            get => maxDuration;
            set => maxDuration = SetValue("max_duration", maxDuration, value);
        }

        [JsonProperty("max_duration")]
        internal int MaxDurationInMinutes
        {
            get => Convert.ToInt32(maxDuration.TotalMinutes);
            set => maxDuration = TimeSpan.FromMinutes(value);
        }

        #endregion

        #region Min advance duration

        /// <summary>
        /// The minimum advance duration field is used to specify how much advance notice is needed from the moment a reservation is requested using the reservation offering and the start of the reservation. This is typically the time needed to prepare a configuration item of the reservation offering.
        /// </summary>
        public TimeSpan? MinAdvanceDuration
        {
            get => minAdvanceDuration;
            set => minAdvanceDuration = SetValue("min_advance_duration", minAdvanceDuration, value);
        }

        [JsonProperty("min_advance_duration")]
        internal int? MinAdvanceDurationInMinutes
        {
            get => minAdvanceDuration != null ? Convert.ToInt32(minAdvanceDuration.Value.TotalMinutes) : (int?)null;
            set => minAdvanceDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Min duration

        /// <summary>
        /// The minimum duration field is used to specify the minimum length of time for which a configuration item of the reservation offering can be reserved.
        /// </summary>
        public TimeSpan MinDuration
        {
            get => minDuration;
            set => minDuration = SetValue("min_duration", maxDuration, value);
        }

        [JsonProperty("min_duration")]
        internal int MinDurationInMinutes
        {
            get => Convert.ToInt32(minDuration.TotalMinutes);
            set => minDuration = TimeSpan.FromMinutes(value);
        }

        #endregion

        #region Multi day

        /// <summary>
        /// The Multi-day box is checked when a reservation request that uses the reservation offering is allowed to start on one day and end on another. When true the duration of a reservation that makes use of the reservation offering is defined by filling out the End field instead of the duration field.
        /// </summary>
        [JsonProperty("multi_day")]
        public bool MultiDay
        {
            get => multiDay;
            set => multiDay = SetValue("multi_day", multiDay, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter a name for the reservation offering.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Preparation duration

        /// <summary>
        /// The Preparation duration field is used to specify the amount of time needed to prepare a configuration item of the reservation offering for the next person who reserved it. People are not be able to request a reservation of a configuration item if it overlaps with the preparation duration of an existing reservation for the same configuration item.
        /// </summary>
        public TimeSpan? PreparationDuration
        {
            get => preparationDuration;
            set => preparationDuration = SetValue("preparation_duration", preparationDuration, value);
        }

        [JsonProperty("preparation_duration")]
        internal int? PreparationDurationInMinutes
        {
            get => preparationDuration != null ? Convert.ToInt32(preparationDuration.Value.TotalMinutes) : (int?)null;
            set => preparationDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Service instance

        /// <summary>
        /// The service instance field is used to select the Service Instance for which people need to be covered in order to be able to make use of the reservation offering.
        /// </summary>
        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set => serviceInstance = SetValue("service_instance_id", serviceInstance, value);
        }

        [JsonProperty("service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceInstanceID => serviceInstance?.ID;

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

        #region Step duration

        /// <summary>
        /// The Step duration field is used specify the time increments for the duration of a reservation that is requested using the reservation offering.
        /// </summary>
        public TimeSpan StepDuration
        {
            get => stepDuration;
            set => stepDuration = SetValue("step_duration", stepDuration, value);
        }

        [JsonProperty("step_duration")]
        internal int StepDurationInMinutes
        {
            get => Convert.ToInt32(stepDuration.TotalMinutes);
            set => stepDuration = TimeSpan.FromMinutes(value);
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected calendar.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            calendar?.ResetPropertySerializationCollection();
            serviceInstance?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
