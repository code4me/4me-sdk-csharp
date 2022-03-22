using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/workflow_templates/task_template_relations/">task template relation</see> object.
    /// </summary>
    public class TaskTemplateRelation : BaseItem
    {
        private string phaseName;
        private TaskTemplate taskTemplate;
        private TaskTemplate failureTaskTemplate;

        #region Phase name

        /// <summary>
        /// The Phase Name field indicates the phase of the workflow template that the task template relation is a part of.
        /// </summary>
        [JsonProperty("phase_name")]
        public string PhaseName
        {
            get => phaseName;
            set => phaseName = SetValue("phase_name", phaseName, value);
        }

        #endregion

        #region Task template

        /// <summary>
        /// The related task template.
        /// </summary>
        [JsonProperty("task_template")]
        public TaskTemplate TaskTemplate
        {
            get => taskTemplate;
            set => taskTemplate = SetValue("task_template_id", taskTemplate, value);
        }

        [JsonProperty("task_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskTemplateID => taskTemplate?.ID;

        #endregion

        #region Failure task template

        /// <summary>
        /// The template of the task that will be assigned in case this task is failed or rejected.
        /// </summary>
        [JsonProperty("failure_task_template")]
        public TaskTemplate FailureTaskTemplate
        {
            get => failureTaskTemplate;
            set => failureTaskTemplate = SetValue("failure_task_template_id", failureTaskTemplate, value);
        }

        [JsonProperty("failure_task_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FailureTaskTemplateID => failureTaskTemplate?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            taskTemplate?.ResetPropertySerializationCollection();
            failureTaskTemplate?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
