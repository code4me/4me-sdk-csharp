using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/projects/">project</see> object.
    /// </summary>
    public class Project : CustomFieldsBaseItem
    {
        private string category;
        private DateTime? completedAt;
        private ProjectCompletionReason? completionReason;
        private DateTime? completionTargetAt;
        private float? costOfEffort;
        private float? costOfPurchases;
        private Organization customer;
        private int? effort;
        private ProjectJustification justification;
        private Person manager;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private string program;
        private TimeSpan? resolutionDuration;
        private string riskLevel;
        private int? roi;
        private Service service;
        private string source;
        private string sourceID;
        private ProjectStatus? status;
        private string subject;
        private string timeZone;
        private float? totalCost;
        private UIExtension uiExtension;
        private float? value;
        private string valueCurrency;
        private Calendar workHours;

        #region Category

        /// <summary>
        /// The Category field is used to select the category of the project.
        /// </summary>
        [JsonProperty("category")]
        public string Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Completed at

        /// <summary>
        /// The Completed at field is automatically set to the date and time at which the project is saved with the status “Completed”.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region Completion reason

        /// <summary>
        /// The Completion reason field is used to select the appropriate completion reason for the project when it has been completed. It is automatically set to “Complete” when all tasks related to the project have reached the status “Completed”, “Approved” or “Canceled”. 
        /// </summary>
        [JsonProperty("completion_reason")]
        public ProjectCompletionReason? CompletionReason
        {
            get => completionReason;
            set => completionReason = SetValue("completion_reason", completionReason, value);
        }

        #endregion

        #region Completion target at

        /// <summary>
        /// The Completion target field shows the target date and time of the last task of the project.
        /// </summary>
        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region Cost of effort

        /// <summary>
        /// The Cost of effort field is used to specify the estimated cost of the effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [JsonProperty("cost_of_effort")]
        public float? CostOfEffort
        {
            get => costOfEffort;
            set => costOfEffort = SetValue("cost_of_effort", costOfEffort, value);
        }

        #endregion

        #region Cost of purchases

        /// <summary>
        /// The Cost of purchases field is used to specify the estimated cost of all purchases (for equipment, consulting effort, licenses, etc.) needed to implement the project. Recurring costs that will be incurred following the implementation of the project are to be included for the entire ROI calculation period.
        /// </summary>
        [JsonProperty("cost_of_purchases")]
        public float? CostOfPurchases
        {
            get => costOfPurchases;
            set => costOfPurchases = SetValue("cost_of_purchases", costOfPurchases, value);
        }

        #endregion

        #region Customer

        /// <summary>
        /// The Customer field is used to select the organization for which the project is to be implemented.
        /// </summary>
        [JsonProperty("customer")]
        public Organization Customer
        {
            get => customer;
            set => customer = SetValue("customer_id", customer, value);
        }

        [JsonProperty("customer_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CustomerID => customer?.ID;

        #endregion

        #region Effort

        /// <summary>
        /// The Effort field is used to specify the estimated number of hours of effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [JsonProperty("effort")]
        public int? Effort
        {
            get => effort;
            set => effort = SetValue("effort", effort, value);
        }

        #endregion

        #region Justification

        /// <summary>
        /// The Justification field is used to select the reason why the project should be considered for implementation. 
        /// </summary>
        [JsonProperty("justification")]
        public ProjectJustification Justification
        {
            get => justification;
            set => justification = SetValue("justification", justification, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the person who is responsible for coordinating the implementation of the project.
        /// </summary>
        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set => manager = SetValue("manager_id", manager, value);
        }

        [JsonProperty("manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ManagerID => manager?.ID;

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to provide a high-level description of the project. It is also used to add any information that could prove useful for anyone involved in the project, including the people whose approval is needed and the people who are helping to implement it.
        /// </summary>
        [JsonProperty("note"), Sdk4meIgnoreInFieldSelection()]
        public string Note
        {
            get => note;
            set => note = SetValue("note", note, value);
        }

        #endregion

        #region Note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded note attachment. Use <see cref="Attachment"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceNoteAttachment(string key, long fileSize, bool inline = false)
        {
            if (noteAttachments == null)
                noteAttachments = new List<AttachmentReference>();

            noteAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("note_attachments");
        }

        [JsonProperty("note_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> NoteAttachments
        {
            get => noteAttachments;
        }

        #endregion

        #region Program

        /// <summary>
        /// The Program field is used to indicate which program the project is a part of. A previously entered program name can be selected, or a new one can be entered.
        /// </summary>
        [JsonProperty("program")]
        public string Program
        {
            get => program;
            set => program = SetValue("program", program, value);
        }

        #endregion

        #region Resolution duration

        /// <summary>
        /// The number of minutes it took to complete this project, which is calculated as the difference between the created_at and completed_at values.
        /// </summary>
        public TimeSpan? ActualResolutionDuration => resolutionDuration;

        [JsonProperty("resolution_duration")]
        internal int? ActualResolutionDurationInMinutes
        {
            get => resolutionDuration != null ? Convert.ToInt32(resolutionDuration.Value.TotalMinutes) : (int?)null;
            set => resolutionDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Risk level

        /// <summary>
        /// The Risk level field is used to select the risk level of the project.
        /// </summary>
        [JsonProperty("risk_level")]
        public string RiskLevel
        {
            get => riskLevel;
            set => riskLevel = SetValue("risk_level", riskLevel, value);
        }

        #endregion

        #region Roi

        /// <summary>
        /// The ROI field displays the estimated return on investment for the project. This percentage is calculated by dividing the value, minus the total costs, by the total costs and multiplying the result by 100.
        /// </summary>
        [JsonProperty("roi")]
        public int? Roi
        {
            get => roi;
            internal set => roi = value;
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the service for which the project will be implemented.
        /// </summary>
        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set => service = SetValue("service_id", service, value);
        }

        [JsonProperty("service_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceID => service?.ID;

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

        #region Status

        /// <summary>
        /// The Status field is automatically set based on the status of the project’s tasks. 
        /// </summary>
        [JsonProperty("status")]
        public ProjectStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description of the objective of the project.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected work hours.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region Total cost

        /// <summary>
        /// The Total costs field displays the total estimated cost to implement the project. This is the sum of the estimated cost of effort and cost of purchases.
        /// </summary>
        [JsonProperty("total_cost")]
        public float? TotalCost
        {
            get => totalCost;
            internal set => totalCost = value;
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the project.
        /// </summary>
        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uiExtension;
            set => uiExtension = SetValue("ui_extension_id", uiExtension, value);
        }

        [JsonProperty("ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UIExtensionID => uiExtension?.ID;

        #endregion

        #region Value

        /// <summary>
        /// The Value field is used to specify the estimated financial value that the implementation of the project will deliver for the entire ROI calculation period.
        /// </summary>
        [JsonProperty("value")]
        public float? Value
        {
            get => value;
            set => this.value = SetValue("value", value, value);
        }

        #endregion

        #region Value currency

        /// <summary>
        /// The currency of the Value field value of the project. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("value_currency")]
        public string ValueCurrency
        {
            get => valueCurrency;
            set => valueCurrency = SetValue("value_currency", valueCurrency, value);
        }

        #endregion

        #region Work hours

        /// <summary>
        /// The Work hours field is used to select a calendar that defines the work hours that are to be used to calculate the anticipated assignment and completion target for the tasks of the project.
        /// </summary>
        [JsonProperty("work_hours")]
        public Calendar WorkHours
        {
            get => workHours;
            set => workHours = SetValue("work_hours_id", workHours, value);
        }

        [JsonProperty("work_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkHoursID => workHours?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            customer?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            workHours?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
