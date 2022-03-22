using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/out_of_office_periods/">out of office period</see> object.
    /// </summary>
    public class OutOfOfficePeriod : BaseItem
    {
        private Person approvalDelegate;
        private DateTime endAt;
        private Person person;
        private string reason;
        private string source;
        private string sourceID;
        private DateTime startAt;
        private TimeAllocation timeAllocation;
        private EffortClass effortClass;

        #region Approval delegate

        /// <summary>
        /// The person who is selected as the approval delegate for the out of office period.
        /// </summary>
        [JsonProperty("approval_delegate")]
        public Person ApprovalDelegate
        {
            get => approvalDelegate;
            set => approvalDelegate = SetValue("approval_delegate_id", approvalDelegate, value);
        }

        [JsonProperty("approval_delegate_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ApprovalDelegateID => approvalDelegate?.ID;

        #endregion

        #region End at

        /// <summary>
        /// Required datetime
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Person

        /// <summary>
        /// The person who is out of office.
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

        #region Reason

        /// <summary>
        /// The Reason field is used to enter the reason of the out of office period. Required when the description category of the time allocation is required.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason
        {
            get => reason;
            set => reason = SetValue("reason", reason, value);
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

        #region Start at

        /// <summary>
        /// Required datetime
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
        }

        #endregion

        #region Time allocation

        /// <summary>
        /// The time allocation field is used to generate time entries for the out of office period. Only the time allocations without service and customer that are linked to the person’s organization can be selected. This field is required if at least one time allocation exists that meets those conditions.
        /// </summary>
        [JsonProperty("time_allocation")]
        public TimeAllocation TimeAllocation
        {
            get => timeAllocation;
            set => timeAllocation = SetValue("time_allocation_id", timeAllocation, value);
        }

        [JsonProperty("time_allocation_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TimeAllocationID => timeAllocation?.ID;

        #endregion

        #region Effort class

        /// <summary>
        /// The Effort class field is used to generate time entries for the out of office period. This field is applicable if the timesheet settings linked to the person’s organization has one or more effort classes.
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set => effortClass = SetValue("effort_class_id", effortClass, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => effortClass?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            approvalDelegate?.ResetPropertySerializationCollection();
            person?.ResetPropertySerializationCollection();
            timeAllocation?.ResetPropertySerializationCollection();
            effortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
