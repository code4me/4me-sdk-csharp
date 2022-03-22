using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/reservations/">reservation</see> object.
    /// </summary>
    public class Reservation : BaseItem
    {
        private ConfigurationItem ci;
        private DateTime endAt;
        private string name;
        private bool onlyThisOccurrence;
        private Person person;
        private DateTime preparationStartAt;
        private string recurrence;
        private ReservationOffering reservationOffering;
        private Request request;
        private string source;
        private string sourceID;
        private DateTime startAt;
        private ReservationStatus status;

        #region Configuration item

        /// <summary>
        /// The related asset.
        /// </summary>
        [JsonProperty("ci")]
        public ConfigurationItem ConfigurationItem
        {
            get => ci;
            set => ci = SetValue("ci_id", ci, value);
        }

        [JsonProperty("ci_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ConfigurationItemID => ci?.ID;

        #endregion

        #region End at

        /// <summary>
        /// The End field is used to specify the moment at which the reservation ends. This field is available only when the Multi-day box of the reservation offering is checked.
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter a name for the reservation.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Only this occurrence

        /// <summary>
        /// Set to true when only this occurrence of a recurrent reservation should be updated. Otherwise this and all future occurrences will be updated.
        /// </summary>
        [JsonProperty("only_this_occurrence")]
        public bool OnlyThisOccurrence
        {
            get => onlyThisOccurrence;
            set => onlyThisOccurrence = SetValue("only_this_occurrence", onlyThisOccurrence, value);
        }

        #endregion

        #region Person

        /// <summary>
        /// The person.
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

        #region Preparation start at

        /// <summary>
        /// The preparation start field is used to specify the moment at which the reservation is being prepared.
        /// </summary>
        [JsonProperty("preparation_start_at")]
        public DateTime PreparationStartAt
        {
            get => preparationStartAt;
            internal set => preparationStartAt = value;
        }

        #endregion

        #region Recurrence

        /// <summary>
        /// The recurrence settings hash, missing in case the reservation has no recurrence defined. See Recurrence for the fields in the recurrence hash.
        /// </summary>
        [JsonProperty("recurrence")]
        public string Recurrence
        {
            get => recurrence;
            internal set => recurrence = value;
        }

        #endregion

        #region Reservation offering

        /// <summary>
        /// The Reservation offering that was related to the request template used to request the reservation.
        /// </summary>
        [JsonProperty("reservation_offering")]
        public ReservationOffering ReservationOffering
        {
            get => reservationOffering;
            set => reservationOffering = SetValue("reservation_offering_id", reservationOffering, value);
        }

        [JsonProperty("reservation_offering_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ReservationOfferingID => reservationOffering?.ID;

        #endregion

        #region Request

        /// <summary>
        /// The request used to create the reservation.
        /// </summary>
        [JsonProperty("request")]
        public Request Request
        {
            get => request;
            set => request = SetValue("request_id", request, value);
        }

        [JsonProperty("request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestID => request?.ID;

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

        #region Start at

        /// <summary>
        /// The Start field is used to specify the moment at which the reservation begins.
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field is used to specify whether a reservation that was requested using the reservation offering is immediately confirmed after it has been submitted, or that an action (such as an approval) is still required before it can be confirmed. 
        /// </summary>
        [JsonProperty("status")]
        public ReservationStatus Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            person?.ResetPropertySerializationCollection();
            reservationOffering?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
