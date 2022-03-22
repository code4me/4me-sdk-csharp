using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/effort_classes/">effort class</see> object.
    /// </summary>
    public class EffortClass : BaseItem
    {
        private float? costMultiplier;
        private bool disabled;
        private string name;
        private int? position;
        private string source;
        private string sourceID;

        #region Cost multiplier

        /// <summary>
        /// The amount with which to multiply the cost of time entries with this effort class.
        /// </summary>
        [JsonProperty("cost_multiplier")]
        public float? CostMultiplier
        {
            get => costMultiplier;
            set => costMultiplier = SetValue("cost_multiplier", costMultiplier, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the effort class may no longer be related to any more timesheet settings.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the effort class.
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
        /// The Position field dictates the position that the effort class takes when it is displayed in a sorted list.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
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
    }
}
