using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/services/">services</see> object.
    /// </summary>
    public class Service : CustomFieldsBaseItem
    {
        private List<Attachment> attachments;
        private Person availabilityManager;
        private Person capacityManager;
        private Person changeManager;
        private Person continuityManager;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private bool disabled;
        private Team firstLineTeam;
        private ServiceImpact? impact;
        private string keywords;
        private Person knowledgeManager;
        private string localizedDescription;
        private string localizedKeywords;
        private string localizedName;
        private string name;
        private string pictureUri;
        private Person problemManager;
        private Organization provider;
        private Person releaseManager;
        private Person serviceOwner;
        private string source;
        private string sourceID;
        private Team supportTeam;
        private Survey survey;

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Availability manager

        /// <summary>
        /// The Availability manager field is used to select the person who is responsible for ensuring that the availability targets specified in the active SLAs for the service are met.
        /// </summary>
        [JsonProperty("availability_manager")]
        public Person AvailabilityManager
        {
            get => availabilityManager;
            set => availabilityManager = SetValue("availability_manager_id", availabilityManager, value);
        }

        [JsonProperty("availability_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? AvailabilityManagerID => availabilityManager?.ID;

        #endregion

        #region Capacity manager

        /// <summary>
        /// The Capacity manager field is used to select the person who is responsible for ensuring that the service is not affected by incidents that are caused by capacity shortages.
        /// </summary>
        [JsonProperty("capacity_manager")]
        public Person CapacityManager
        {
            get => capacityManager;
            set => capacityManager = SetValue("capacity_manager_id", capacityManager, value);
        }

        [JsonProperty("capacity_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CapacityManagerID => capacityManager?.ID;

        #endregion

        #region Change manager

        /// <summary>
        /// The Workflow manager field is used to select the person who is responsible for coordinating the workflows of the service.
        /// </summary>
        [JsonProperty("change_manager")]
        public Person ChangeManager
        {
            get => changeManager;
            set => changeManager = SetValue("change_manager_id", changeManager, value);
        }

        [JsonProperty("change_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkflowManagerID => changeManager?.ID;

        #endregion

        #region Continuity manager

        /// <summary>
        /// The Continuity manager field is used to select the person who is responsible for creating and maintaining the continuity plans for the service’s instances that have an active SLA with a continuity target.
        /// </summary>
        [JsonProperty("continuity_manager")]
        public Person ContinuityManager
        {
            get => continuityManager;
            set => continuityManager = SetValue("continuity_manager_id", continuityManager, value);
        }

        [JsonProperty("continuity_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ContinuityManagerID => continuityManager?.ID;

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to enter a high-level description of the service’s core functionality.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Description attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceDescriptionAttachment(string key, long fileSize)
        {
            if (descriptionAttachments == null)
                descriptionAttachments = new List<AttachmentReference>();

            descriptionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("description_attachments");
        }

        [JsonProperty("description_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> DescriptionAttachments
        {
            get => descriptionAttachments;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the service may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region First line team

        /// <summary>
        /// The First line team field is used to select the team that will, by default, be selected in the First line team field of a new service instance when it is being registered for the service.
        /// </summary>
        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            set => firstLineTeam = SetValue("first_line_team_id", firstLineTeam, value);
        }

        [JsonProperty("first_line_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FirstLineTeamID => firstLineTeam?.ID;

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field shows the impact based on the highest impact of the affected SLAs for which the current user has read access. 
        /// </summary>
        [JsonProperty("impact")]
        public ServiceImpact? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Keywords

        /// <summary>
        /// The Keywords field contains a comma-separated list of words that can be used to find the service via search.
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords
        {
            get => keywords;
            set => keywords = SetValue("keywords", keywords, value);
        }

        #endregion

        #region Knowledge manager

        /// <summary>
        /// The Knowledge manager field is used to select the person who is responsible for the quality of the knowledge articles for the service.
        /// </summary>
        [JsonProperty("knowledge_manager")]
        public Person KnowledgeManager
        {
            get => knowledgeManager;
            set => knowledgeManager = SetValue("knowledge_manager_id", knowledgeManager, value);
        }

        [JsonProperty("knowledge_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? KnowledgeManagerID => knowledgeManager?.ID;

        #endregion

        #region Localized description

        /// <summary>
        /// Translated Description in the current language, defaults to description in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_description"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedDescription
        {
            get => localizedDescription;
            internal set => localizedDescription = value;
        }

        #endregion

        #region Localized keywords

        /// <summary>
        /// Translated Keywords in the current language, defaults to keywords in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_keywords"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedKeywords
        {
            get => localizedKeywords;
            internal set => localizedKeywords = value;
        }

        #endregion

        #region Localized name

        /// <summary>
        /// Translated Name in the current language, defaults to name in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_name"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedName
        {
            get => localizedName;
            internal set => localizedName = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the service. The service name may be followed by the name of its core application placed between brackets.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the agile board.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Problem manager

        /// <summary>
        /// The Problem manager field is used to select the person who is responsible for coordinating the problems that directly affect the service.
        /// </summary>
        [JsonProperty("problem_manager")]
        public Person ProblemManager
        {
            get => problemManager;
            set => problemManager = SetValue("problem_manager_id", problemManager, value);
        }

        [JsonProperty("problem_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemManagerID => problemManager?.ID;

        #endregion

        #region Provider

        /// <summary>
        /// Required reference to Organization.
        /// </summary>
        [JsonProperty("provider")]
        public Organization Provider
        {
            get => provider;
            set => provider = SetValue("provider_id", provider, value);
        }

        [JsonProperty("provider_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProviderID => provider?.ID;

        #endregion

        #region Release manager

        /// <summary>
        /// The Release manager field is used to select the person who is responsible for coordinating the releases of the service.
        /// </summary>
        [JsonProperty("release_manager")]
        public Person ReleaseManager
        {
            get => releaseManager;
            set => releaseManager = SetValue("release_manager_id", releaseManager, value);
        }

        [JsonProperty("release_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ReleaseManagerID => releaseManager?.ID;

        #endregion

        #region Service owner

        /// <summary>
        /// The Service owner field is used to select the Person who is responsible for ensuring that the service level targets specified in the SLAs for the service are met.
        /// </summary>
        [JsonProperty("service_owner")]
        public Person ServiceOwner
        {
            get => serviceOwner;
            set => serviceOwner = SetValue("service_owner_id", serviceOwner, value);
        }

        [JsonProperty("service_owner_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceOwnerID => serviceOwner?.ID;

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

        #region Support team

        /// <summary>
        /// The Support team field is used to select the team that will, by default, be selected in the Support team field of a service instance when one is registered for the service. Similarly, this team will be selected in the Team field of a Problem when the service is related to it.
        /// </summary>
        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set => supportTeam = SetValue("support_team_id", supportTeam, value);
        }

        [JsonProperty("support_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportTeamID => supportTeam?.ID;

        #endregion

        #region Survey

        /// <summary>
        /// The Survey field is used to select the survey that will be presented to users to give their rating for this service.
        /// </summary>
        [JsonProperty("survey")]
        public Survey Survey
        {
            get => survey;
            set => survey = SetValue("survey_id", survey, value);
        }

        [JsonProperty("survey_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SurveyID => survey?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            availabilityManager?.ResetPropertySerializationCollection();
            capacityManager?.ResetPropertySerializationCollection();
            changeManager?.ResetPropertySerializationCollection();
            continuityManager?.ResetPropertySerializationCollection();
            firstLineTeam?.ResetPropertySerializationCollection();
            knowledgeManager?.ResetPropertySerializationCollection();
            problemManager?.ResetPropertySerializationCollection();
            provider?.ResetPropertySerializationCollection();
            releaseManager?.ResetPropertySerializationCollection();
            serviceOwner?.ResetPropertySerializationCollection();
            supportTeam?.ResetPropertySerializationCollection();
            Survey?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
