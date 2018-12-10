using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ProjectPhase : BaseItem
    {
        private DateTime? completedAt;
        private string name;
        private int? position;
        private DateTime? startedAt;
        private ProjectPhaseStatusType? status;

        #region completed_at

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
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

        #region position

        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set
            {
                if (position != value)
                    AddIncludedDuringSerialization("position");
                position = value;
            }
        }

        #endregion

        #region started_at

        [JsonProperty("started_at")]
        public DateTime? StartedAt
        {
            get => startedAt;
            internal set => startedAt = value;
        }

        #endregion

        #region status

        [JsonProperty("status")]
        public ProjectPhaseStatusType? Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion
    }
}
