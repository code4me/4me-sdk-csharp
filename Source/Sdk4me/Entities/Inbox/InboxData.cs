using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    /// <summary>
    /// The 4me inbox object.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class InboxData
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; internal set; }

        /// <summary>
        /// The hyper text reference to the inbox item.
        /// </summary>
        [JsonProperty("href")]
        public string HypertextReference { get; internal set; }

        /// <summary>
        /// The organization an the requester.
        /// </summary>
        [JsonProperty("for")]
        public InboxFor For { get; internal set; }

        /// <summary>
        /// The request or task subject.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; internal set; }

        /// <summary>
        /// The team to whom the request or task is assigned.
        /// </summary>
        [JsonProperty("team")]
        public Team Team { get; internal set; }

        /// <summary>
        /// The next target of the request or task.
        /// </summary>
        [JsonProperty("next_target_at")]
        public string NextTargetAt { get; internal set; }

        /// <summary>
        /// True if this is a new assignment; otherwise false.
        /// </summary>
        [JsonProperty("new_assignment")]
        public bool NewAssignment { get; internal set; }

        /// <summary>
        /// The team member to whom the request or task is assigned.
        /// </summary>
        [JsonProperty("member")]
        public InboxMember Member { get; internal set; }

        /// <summary>
        /// The request or task status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; internal set; }

        /// <summary>
        /// The request or task impact.
        /// </summary>
        [JsonProperty("impact")]
        public string Impact { get; internal set; }

        /// <summary>
        /// Returns true then the request or task has been assigned to a team member; otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool HasMember()
        {
            return Member != null && Member.ID == null;
        }
    }
}
