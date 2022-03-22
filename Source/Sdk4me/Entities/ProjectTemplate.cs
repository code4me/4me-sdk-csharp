using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_templates/">project template</see> object.
    /// </summary>
    public class ProjectTemplate : BaseItem
    {
        private bool disabled;
        private string source;
        private string sourceID;
        private string subject;
        private int timesApplied;

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the project template may not be used to help register new projects.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
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

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description that needs to be copied to the Subject field of a new project when it is being created based on the template.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Times applied

        /// <summary>
        /// The number of times the project template is used to create a project.
        /// </summary>
        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion
    }
}
