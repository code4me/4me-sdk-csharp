using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ChangeType : BaseItem
    {
        private List<Attachment> attachments;
        private string description;
        private bool disabled;
        private string information;
        private string name;
        private int? position;
        private string reference;
        private string source;
        private string sourceID;

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region description

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                    AddIncludedDuringSerialization("description");
                description = value;
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

        #region information

        [JsonProperty("information")]
        public string Information
        {
            get => information;
            set
            {
                if (information != value)
                    AddIncludedDuringSerialization("information");
                information = value;
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

        #region reference

        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            set
            {
                if (reference != value)
                    AddIncludedDuringSerialization("reference");
                reference = value;
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
