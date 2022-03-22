using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/agile_boards/columns/">agile board column</see> object.
    /// </summary>
    public class AgileBoardColumn : BaseItem
    {
        private AgileBoardColumnAction actionType;
        private bool deleted;
        private AgileBoardColumnDialogType dialogType;
        private Person member;
        private string name;
        private int? position;
        private int? removeAfter;
        private Team team;
        private int? wipLimit;

        #region Action type

        /// <summary>
        /// The Action type field is used to specify what action is to be performed when an item is moved into the column. 
        /// </summary>
        [JsonProperty("action_type")]
        public AgileBoardColumnAction ActionType
        {
            get => actionType;
            set => actionType = SetValue("action_type", actionType, value);
        }

        #endregion

        #region Deleted

        /// <summary>
        /// The Deleted box is automatically checked after removing a column from a board. This happens only when the column has at any point in time contained 1 or more items.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted
        {
            get => deleted;
            internal set => deleted = value;
        }

        #endregion

        #region Dialog type

        /// <summary>
        /// The Dialog type field is used to specify what kind of dialog is to be shown when an item is moved into the column. 
        /// </summary>
        [JsonProperty("dialog_type")]
        public AgileBoardColumnDialogType DialogType
        {
            get => dialogType;
            set => dialogType = SetValue("dialog_type", dialogType, value);
        }

        #endregion

        #region Member

        /// <summary>
        /// The Member field is only applicable when the Team field of the column has a value, and indicates to which team member the item is to be assigned when it is moved into the column.
        /// </summary>
        [JsonProperty("member")]
        public Person Member
        {
            get => member;
            set => member = SetValue("member_id", member, value);
        }

        [JsonProperty("member_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? MemberID => member?.ID;

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the column.
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
        /// The Position field is used to specify the position of the column, relative to the other columns of the agile board. The leftmost column has position 1.
        /// </summary>
        [JsonProperty("position")]
        public int? Position
        {
            get => position;
            set => position = SetValue("position", position, value);
        }

        #endregion

        #region Remove after

        /// <summary>
        /// Items in this column that are not moved for the specified number of days are removed from the board.
        /// </summary>
        [JsonProperty("remove_after")]
        public int? RemoveAfter
        {
            get => removeAfter;
            set => removeAfter = SetValue("remove_after", removeAfter, value);
        }

        #endregion

        #region Team

        /// <summary>
        /// The Team field is only applicable when the Action type of the column is assign, and indicates to which team the item is to be assigned when it is moved into the column.
        /// </summary>
        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set => team = SetValue("team_id", team, value);
        }

        [JsonProperty("team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TeamID => team?.ID;

        #endregion

        #region WIP limit

        /// <summary>
        /// The Work In Progress (WIP) limit field is used to indicate the maximum number of items that are expected to be in the column at any point in time.
        /// </summary>
        [JsonProperty("wip_limit")]
        public int? WipLimit
        {
            get => wipLimit;
            set => wipLimit = SetValue("wip_limit", wipLimit, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            member?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
