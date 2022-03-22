using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/product_backlogs/product_backlog_items/">product backlog item</see> object.
    /// </summary>
    public class ProductBacklogItem : BaseItem
    {
        private int position;
        private Problem problem;
        private Request request;

        #region Position

        /// <summary>
        /// The Position field is used to specify the position of the item, relative to the other items of the product backlog. The top item has position 1.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        {
            get => position;
            internal set => position = value;
        }

        #endregion

        #region Problem

        /// <summary>
        /// The Problem field is filled for problems on the product backlog.
        /// </summary>
        [JsonProperty("problem")]
        public Problem Problem
        {
            get => problem;
            set => problem = SetValue("problem_id", problem, value);
        }

        [JsonProperty("problem_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemID => problem?.ID;

        #endregion

        #region Request

        /// <summary>
        /// The Request field is filled for requests on the product backlog.
        /// </summary>
        [JsonProperty("request")]
        public Request Request
        {
            get => request;
            set => request = SetValue("request_id", request, value);
        }

        [JsonProperty("request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestID => request?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            problem?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
