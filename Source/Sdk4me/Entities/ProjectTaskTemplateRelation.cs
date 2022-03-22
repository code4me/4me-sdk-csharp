using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_templates/project_task_templates/">project template - project task template relation</see> object.
    /// </summary>
    public class ProjectTaskTemplateRelation : BaseItem
    {
        private string phaseName;
        private ProjectTaskTemplate taskTemplate;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Phase name

        /// <summary>
        /// The Phase Name field indicates the phase of the project template that the project task template is a part of.
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
        /// The Project Task Template field indicates the project task template that is related to the project template.
        /// </summary>
        [JsonProperty("task_template")]
        public ProjectTaskTemplate TaskTemplate
        {
            get => taskTemplate;
            set => taskTemplate = SetValue("task_template_id", taskTemplate, value);
        }

        [JsonProperty("task_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskTemplateID => taskTemplate?.ID;

        #endregion
    }
}
