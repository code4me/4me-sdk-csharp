using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/sprints/backlog_items/">sprint backlog item</see> object.
    /// </summary>
    public class SprintBacklogItem : BaseItem
    {
        private bool done;
        private int? estimate;
        private bool planned;
        private int? position;
        private Problem problem;
        private ProjectTask projectTask;
        private Request request;
        private Sprint sprint;
        private Task task;

        #region Done

        /// <summary>
        /// Whether this item has been completed in this sprint. null indicates the item was removed from the sprint.
        /// </summary>
        [JsonProperty("done")]
        public bool Done
        {
            get => done;
            internal set => done = value;
        }

        #endregion

        #region Estimate

        /// <summary>
        /// Estimate of the relative size of this record on the sprint backlog.
        /// </summary>
        [JsonProperty("estimate")]
        public int? Estimate
        {
            get => estimate;
            set => estimate = SetValue("estimate", estimate, value);
        }

        #endregion

        #region Planned

        /// <summary>
        /// Whether this item was part of the sprint backlog when the sprint was started.
        /// </summary>
        [JsonProperty("planned")]
        public bool Planned
        {
            get => planned;
            internal set => planned = value;
        }

        #endregion

        #region Position

        /// <summary>
        /// Position of this record on the sprint backlog. The top item has position 1.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion

        #region Problem

        /// <summary>
        /// The Problem field is filled for problems on the sprint backlog.
        /// </summary>
        [JsonProperty("problem"), Sdk4meIgnoreInFieldSelection()]
        public Problem Problem
        {
            get => problem;
            internal set => problem = value;
        }

        [JsonProperty("problem_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemID => problem?.ID;

        #endregion

        #region Project task

        /// <summary>
        /// The Project Task field is filled for project tasks on the sprint backlog.
        /// </summary>
        [JsonProperty("project_task"), Sdk4meIgnoreInFieldSelection()]
        public ProjectTask ProjectTask
        {
            get => projectTask;
            internal set => projectTask = value;
        }

        [JsonProperty("project_task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProjectTaskID => projectTask?.ID;

        #endregion

        #region Request

        /// <summary>
        /// The Request field is filled for requests on the sprint backlog.
        /// </summary>
        [JsonProperty("request"), Sdk4meIgnoreInFieldSelection()]
        public Request Request
        {
            get => request;
            internal set => request = value;
        }

        [JsonProperty("request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestID => request?.ID;

        #endregion

        #region Sprint

        /// <summary>
        /// The sprint this backlog item is part of.
        /// </summary>
        [JsonProperty("sprint")]
        public Sprint Sprint
        {
            get => sprint;
            internal set => sprint = value;
        }

        [JsonProperty("sprint_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SprintID => sprint?.ID;

        #endregion

        #region Task

        /// <summary>
        /// The Task field is filled for tasks on the sprint backlog.
        /// </summary>
        [JsonProperty("task"), Sdk4meIgnoreInFieldSelection()]
        public Task Task
        {
            get => task;
            internal set => task = value;
        }

        [JsonProperty("task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskID => task?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            problem?.ResetPropertySerializationCollection();
            projectTask?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            task?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
