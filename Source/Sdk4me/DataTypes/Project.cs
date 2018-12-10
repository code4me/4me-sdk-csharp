using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Project : BaseItem
    {
        private string category;
        private DateTime? completedAt;
        private ProjectCompletionReasonType? completionReason;
        private DateTime? completionTargetAt;
        private float? costOfEffort;
        private float? costOfPurchases;
        private Organization customer;
        private int? effort;
        private ProjectJustificationType? justification;
        private Person manager;
        private string note;
        private string program;
        private string riskLevel;
        private long? roi;
        private Service service;
        private string source;
        private string sourceID;
        private ProjectStatusType? status;
        private string subject;
        private string timeZone;
        private float? totalCost;
        private UIExtension uIExtension;
        private float? value;
        private Calendar workHours;
        private CustomFieldCollection customFields;

        #region category

        [JsonProperty("category")]
        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                    AddIncludedDuringSerialization("category");
                category = value;
            }
        }

        #endregion

        #region completed_at

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region completion_reason

        [JsonProperty("completion_reason")]
        public ProjectCompletionReasonType? CompletionReason
        {
            get => completionReason;
            set
            {
                if (completionReason != value)
                    AddIncludedDuringSerialization("completion_reason");
                completionReason = value;
            }
        }

        #endregion

        #region completion_target_at

        [JsonProperty("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => completionTargetAt;
            internal set => completionTargetAt = value;
        }

        #endregion

        #region cost_of_effort

        [JsonProperty("cost_of_effort")]
        public float? CostOfEffort
        {
            get => costOfEffort;
            set
            {
                if (costOfEffort != value)
                    AddIncludedDuringSerialization("cost_of_effort");
                costOfEffort = value;
            }
        }

        #endregion

        #region cost_of_purchases

        [JsonProperty("cost_of_purchases")]
        public float? CostOfPurchases
        {
            get => costOfPurchases;
            set
            {
                if (costOfPurchases != value)
                    AddIncludedDuringSerialization("cost_of_purchases");
                costOfPurchases = value;
            }
        }

        #endregion

        #region customer

        [JsonProperty("customer")]
        public Organization Customer
        {
            get => customer;
            set
            {
                if (customer?.ID != value?.ID)
                    AddIncludedDuringSerialization("customer_id");
                customer = value;
            }
        }

        [JsonProperty(PropertyName = "customer_id"), Sdk4meIgnoreInFieldSelection()]
        private long? CustomerID
        {
            get => (customer != null ? customer.ID : (long?)null);
        }

        #endregion

        #region effort

        [JsonProperty("effort")]
        public int? Effort
        {
            get => effort;
            set
            {
                if (effort != value)
                    AddIncludedDuringSerialization("effort");
                effort = value;
            }
        }

        #endregion

        #region justification

        [JsonProperty("justification")]
        public ProjectJustificationType? Justification
        {
            get => justification;
            set
            {
                if (justification != value)
                    AddIncludedDuringSerialization("justification");
                justification = value;
            }
        }

        #endregion

        #region manager

        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set
            {
                if (manager?.ID != value?.ID)
                    AddIncludedDuringSerialization("manager_id");
                manager = value;
            }
        }

        [JsonProperty(PropertyName = "manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ManagerID
        {
            get => (manager != null ? manager.ID : (long?)null);
        }

        #endregion

        #region note

        [JsonProperty("note"), Sdk4meIgnoreInFieldSelection()]
        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                    AddIncludedDuringSerialization("note");
                note = value;
            }
        }

        #endregion

        #region program

        [JsonProperty("program")]
        public string Program
        {
            get => program;
            set
            {
                if (program != value)
                    AddIncludedDuringSerialization("program");
                program = value;
            }
        }

        #endregion

        #region risk_level

        [JsonProperty("risk_level")]
        public string RiskLevel
        {
            get => riskLevel;
            set
            {
                if (riskLevel != value)
                    AddIncludedDuringSerialization("risk_level");
                riskLevel = value;
            }
        }

        #endregion

        #region roi

        [JsonProperty("roi")]
        public long? Roi
        {
            get => roi;
            internal set => roi = value;
        }

        #endregion

        #region service

        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set
            {
                if (service?.ID != value?.ID)
                    AddIncludedDuringSerialization("service_id");
                service = value;
            }
        }

        [JsonProperty(PropertyName = "service_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ServiceID
        {
            get => (service != null ? service.ID : (long?)null);
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

        #region status

        [JsonProperty("status")]
        public ProjectStatusType? Status
        {
            get => status;
            set
            {
                if (status != value)
                    AddIncludedDuringSerialization("status");
                status = value;
            }
        }

        #endregion

        #region subject

        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                    AddIncludedDuringSerialization("subject");
                subject = value;
            }
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set
            {
                if (timeZone != value)
                    AddIncludedDuringSerialization("time_zone");
                timeZone = value;
            }
        }

        #endregion

        #region total_cost

        [JsonProperty("total_cost")]
        public float? TotalCost
        {
            get => totalCost;
            internal set => totalCost = value;
        }

        #endregion

        #region ui_extension

        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uIExtension;
            set
            {
                if (uIExtension?.ID != value?.ID)
                    AddIncludedDuringSerialization("ui_extension_id");
                uIExtension = value;
            }
        }

        [JsonProperty(PropertyName = "ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        private long? UIExtensionID
        {
            get => (uIExtension != null ? uIExtension.ID : (long?)null);
        }

        #endregion

        #region value

        [JsonProperty("value")]
        public float? Value
        {
            get => value;
            set
            {
                if (this.value != value)
                    AddIncludedDuringSerialization("value");
                this.value = value;
            }
        }

        #endregion

        #region work_hours

        [JsonProperty("work_hours")]
        public Calendar WorkHours
        {
            get => workHours;
            set
            {
                if (workHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("work_hours_id");
                workHours = value;
            }
        }

        [JsonProperty(PropertyName = "work_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? WorkHoursID
        {
            get => (workHours != null ? workHours.ID : (long?)null);
        }

        #endregion

        #region custom_fields

        [JsonProperty("custom_fields")]
        private List<CustomField> CustomFieldsPrivate
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        [JsonIgnore(), Sdk4meIgnoreInFieldSelection()]
        public CustomFieldCollection CustomFields
        {
            get => customFields;
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddIncludedDuringSerialization("custom_fields");
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            customer?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            workHours?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
