using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/workflows/phases/">workflow phase</see> object.
    /// </summary>
    public class WorkflowPhase : BaseItem
    {
        private DateTime? completedAt;
        private string name;
        private int? position;
        private DateTime? startedAt;
        private WorkflowPhaseStatus status;

        #region Completed at

        /// <summary>
        /// The date and time at which the workflow phase was set to the status “Completed”.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the workflow phase.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Position

        /// <summary>
        /// The Position field dictates the position that the workflow phase takes when it is presented in the workflow’s Gantt chart.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion

        #region Started at

        /// <summary>
        /// The Started field indicates the date and time at which the first workflow task of the phase was set to a status other than ‘Registered’ or ‘Canceled’.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime? StartedAt
        {
            get => startedAt;
            internal set => startedAt = value;
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field indicates the current status of the workflow phase.
        /// </summary>
        [JsonProperty("status")]
        public WorkflowPhaseStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion
    }
}
