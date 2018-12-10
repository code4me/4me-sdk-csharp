using Newtonsoft.Json;

namespace Sdk4me
{
    public class ProjectTemplatePhase : BaseItem
    {
        private string name;
        private int? position;

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
    }
}
