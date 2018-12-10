using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class Release : BaseItem
    {
        private DateTime? completedAt;
        private ReleaseCompletionReasonType? completionReason;
        private DateTime? completionTargetAt;
        private ReleaseImpactType? impact;
        private Person manager;
        private string note;
        private string source;
        private string sourceID;
        private ReleaseStatusType? status;
        private string subject;

        #region completed_at

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            set
            {
                if (completedAt != value)
                    AddIncludedDuringSerialization("completed_at");
                completedAt = value;
            }
        }

        #endregion

        #region completion_reason

        [JsonProperty("completion_reason")]
        public ReleaseCompletionReasonType? CompletionReason
        {
            get => completionReason;
            internal set => completionReason = value;
        }

        #endregion

        #region completion_target_at

        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public ReleaseImpactType? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region manager

        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set
            {
                if (manager?.ID != value?.ID)
                    AddIncludedDuringSerialization("manager_id");
                manager = value;
            }
        }

        [JsonProperty(PropertyName = "manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ManagerID
        {
            get => (manager != null ? manager.ID : (long?)null);
        }

        #endregion

        #region note

        [JsonProperty("note"), Sdk4meIgnoreInFieldSelection()]
        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                    AddIncludedDuringSerialization("note");
                note = value;
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

        #region status

        [JsonProperty("status")]
        public ReleaseStatusType? Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region subject

        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                    AddIncludedDuringSerialization("subject");
                subject = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            manager?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
