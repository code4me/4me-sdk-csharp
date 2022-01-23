using Newtonsoft.Json;

namespace Sdk4me
{
    public class Service : BaseItem
    {
        private Person availabilityManager;
        private Person capacityManager;
        private Person changeManager;
        private Person continuityManager;
        private string description;
        private bool disabled;
        private Team firstLineTeam;
        private ServiceImpactType? impact;
        private Person knowledgeManager;
        private string localizedDescription;
        private string localizedName;
        private string name;
        private Person problemManager;
        private Organization provider;
        private Person releaseManager;
        private Person serviceOwner;
        private string source;
        private string sourceID;
        private Team supportTeam;

        #region availability_manager

        [JsonProperty("availability_manager")]
        public Person AvailabilityManager
        {
            get => availabilityManager;
            set
            {
                if (availabilityManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("availability_manager_id");
                availabilityManager = value;
            }
        }

        [JsonProperty(PropertyName = "availability_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? AvailabilityManagerID
        {
            get => (availabilityManager != null ? availabilityManager.ID : (long?)null);
        }

        #endregion

        #region capacity_manager

        [JsonProperty("capacity_manager")]
        public Person CapacityManager
        {
            get => capacityManager;
            set
            {
                if (capacityManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("capacity_manager_id");
                capacityManager = value;
            }
        }

        [JsonProperty(PropertyName = "capacity_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CapacityManagerID
        {
            get => (capacityManager != null ? capacityManager.ID : (long?)null);
        }

        #endregion

        #region change_manager

        [JsonProperty("change_manager")]
        public Person ChangeManager
        {
            get => changeManager;
            set
            {
                if (changeManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("change_manager_id");
                changeManager = value;
            }
        }

        [JsonProperty(PropertyName = "change_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ChangeManagerID
        {
            get => (changeManager != null ? changeManager.ID : (long?)null);
        }

        #endregion

        #region continuity_manager

        [JsonProperty("continuity_manager")]
        public Person ContinuityManager
        {
            get => continuityManager;
            set
            {
                if (continuityManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("continuity_manager_id");
                continuityManager = value;
            }
        }

        [JsonProperty(PropertyName = "continuity_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ContinuityManagerID
        {
            get => (continuityManager != null ? continuityManager.ID : (long?)null);
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

        #region first_line_team

        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            set
            {
                if (firstLineTeam?.ID != value?.ID)
                    AddIncludedDuringSerialization("first_line_team_id");
                firstLineTeam = value;
            }
        }

        [JsonProperty(PropertyName = "first_line_team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? FirstLineTeamID
        {
            get => (firstLineTeam != null ? firstLineTeam.ID : (long?)null);
        }

        #endregion

        #region impact

        [JsonProperty("impact")]
        public ServiceImpactType? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region knowledge_manager

        [JsonProperty("knowledge_manager")]
        public Person KnowledgeManager
        {
            get => knowledgeManager;
            set
            {
                if (knowledgeManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("knowledge_manager_id");
                knowledgeManager = value;
            }
        }

        [JsonProperty(PropertyName = "knowledge_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? KnowledgeManagerID
        {
            get => (knowledgeManager != null ? knowledgeManager.ID : (long?)null);
        }

        #endregion

        #region localized_description

        [JsonProperty("localized_description"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedDescription
        {
            get => localizedDescription;
            internal set => localizedDescription = value;
        }

        #endregion

        #region localized_name

        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
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

        #region problem_manager

        [JsonProperty("problem_manager")]
        public Person ProblemManager
        {
            get => problemManager;
            set
            {
                if (problemManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("problem_manager_id");
                problemManager = value;
            }
        }

        [JsonProperty(PropertyName = "problem_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProblemManagerID
        {
            get => (problemManager != null ? problemManager.ID : (long?)null);
        }

        #endregion

        #region provider

        [JsonProperty("provider")]
        public Organization Provider
        {
            get => provider;
            set
            {
                if (provider?.ID != value?.ID)
                    AddIncludedDuringSerialization("provider_id");
                provider = value;
            }
        }

        [JsonProperty(PropertyName = "provider_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProviderID
        {
            get => (provider != null ? provider.ID : (long?)null);
        }

        #endregion

        #region release_manager

        [JsonProperty("release_manager")]
        public Person ReleaseManager
        {
            get => releaseManager;
            set
            {
                if (releaseManager?.ID != value?.ID)
                    AddIncludedDuringSerialization("release_manager_id");
                releaseManager = value;
            }
        }

        [JsonProperty(PropertyName = "release_manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ReleaseManagerID
        {
            get => (releaseManager != null ? releaseManager.ID : (long?)null);
        }

        #endregion

        #region service_owner

        [JsonProperty("service_owner")]
        public Person ServiceOwner
        {
            get => serviceOwner;
            set
            {
                if (serviceOwner?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_owner_id");
                serviceOwner = value;
            }
        }

        [JsonProperty(PropertyName = "service_owner_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceOwnerID
        {
            get => (serviceOwner != null ? serviceOwner.ID : (long?)null);
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

        #region support_team

        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set
            {
                if (supportTeam != value)
                    AddIncludedDuringSerialization("support_team");
                supportTeam = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            availabilityManager?.ResetIncludedDuringSerialization();
            capacityManager?.ResetIncludedDuringSerialization();
            changeManager?.ResetIncludedDuringSerialization();
            continuityManager?.ResetIncludedDuringSerialization();
            firstLineTeam?.ResetIncludedDuringSerialization();
            knowledgeManager?.ResetIncludedDuringSerialization();
            problemManager?.ResetIncludedDuringSerialization();
            provider?.ResetIncludedDuringSerialization();
            releaseManager?.ResetIncludedDuringSerialization();
            serviceOwner?.ResetIncludedDuringSerialization();
            supportTeam?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
