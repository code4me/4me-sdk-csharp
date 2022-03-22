using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Sdk4me
{
    [DebuggerDisplay("{ID}")]
    public class InboxItem : BaseItem
    {
        /// <summary>
        /// Returns the identifier for the request or task.
        /// </summary>
        public new long ID
        {
            get => (Request ?? Task).ID;
            internal set => (Request ?? Task).ID = value;
        }

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

        /// <summary>
        /// Returns the request; or null when it is a task.
        /// </summary>
        [JsonProperty("request")]
        public InboxData Request { get; internal set; }

        /// <summary>
        /// Returns the task; or null when it is a request.
        /// </summary>
        [JsonProperty("task")]
        public InboxData Task { get; internal set; }

        /// <summary>
        /// The request or task.
        /// </summary>
        public InboxData Item => Request ?? Task;

        /// <summary>
        /// Check if this is a task.
        /// </summary>
        /// <returns>Returns true if it is a task; otherwise false.</returns>
        public bool IsTask()
        {
            return Task != null;
        }

        /// <summary>
        /// Check if this is a request.
        /// </summary>
        /// <returns>Returns true if it is a request; otherwise false.</returns>
        public bool IsRequest()
        {
            return Request != null;
        }
    }
}
