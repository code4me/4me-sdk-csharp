using Newtonsoft.Json;

namespace Sdk4me
{
    public class EffortClass : BaseItem
    {
        private float? costMultiplier;
        private bool disabled;
        private string name;
        private int? position;
        private string source;
        private string sourceID;

        #region cost_multiplier

        [JsonProperty("cost_multiplier")]
        public float? CostMultiplier
        {
            get => costMultiplier;
            set
            {
                if (costMultiplier != value)
                    AddIncludedDuringSerialization("cost_multiplier");
                costMultiplier = value;
            }
        }

        #endregion

        #region disabled

        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set
            {
                if (disabled != value)
                    AddIncludedDuringSerialization("disabled");
                disabled = value;
            }
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

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion
    }
}
