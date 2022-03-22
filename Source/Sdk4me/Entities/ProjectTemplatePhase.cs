using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_templates/phases/">project template phase</see> object.
    /// </summary>
    public class ProjectTemplatePhase : BaseItem
    {
        private string name;
        private int? position;

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the project template’s phase.
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
        /// The Position field dictates the position that the phase takes when it is presented in its project template.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion
    }
}
