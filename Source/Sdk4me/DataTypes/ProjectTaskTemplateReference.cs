using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ProjectTaskTemplateReference : BaseItem
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

        #region phase_name

        [JsonProperty("phase_name")]
        public string PhaseName
        {
            get => phaseName;
            set
            {
                if (phaseName != value)
                    AddIncludedDuringSerialization("phase_name");
                phaseName = value;
            }
        }

        #endregion

        #region task_template

        [JsonProperty("task_template")]
        public ProjectTaskTemplate TaskTemplate
        {
            get => taskTemplate;
            set
            {
                if (taskTemplate?.ID != value?.ID)
                    AddIncludedDuringSerialization("task_template_id");
                taskTemplate = value;
            }
        }

        [JsonProperty(PropertyName = "task_template_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TaskTemplateID
        {
            get => (taskTemplate != null ? taskTemplate.ID : (long?)null);
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            taskTemplate?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
