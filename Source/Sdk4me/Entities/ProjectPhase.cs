using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/projects/phases/">project phase</see> object.
    /// </summary>
    public class ProjectPhase : BaseItem
    {
        private DateTime? completedAt;
        private string name;
        private int? position;
        private DateTime? startedAt;
        private ProjectPhaseStatus status;

        #region Completed at

        /// <summary>
        /// The date and time at which the project phase was set to the status “Completed”.
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
        /// The Name field is used to enter the name of the project phase.
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
        /// The Position field dictates the position that the project phase takes when it is presented in the project’s Gantt chart.
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
        /// The Started field indicates the date and time at which the first project task of the phase was set to a status other than ‘Registered’ or ‘Canceled’.
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
        /// The Status field indicates the current status of the project phase. 
        /// </summary>
        [JsonProperty("status")]
        public ProjectPhaseStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion
    }
}
