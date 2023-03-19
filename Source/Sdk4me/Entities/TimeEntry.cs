using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/time_entries/">time entry</see> object.
    /// </summary>
    public class TimeEntry : BaseItem
    {
        private string activityID;
        private string billingID;
        private float charge;
        private string chargeCurrency;
        private string chargeID;
        private float chargeRate;
        private ChargeType? chargeType;
        private bool correction;
        private float? cost;
        private string costCurrency;
        private Organization customer;
        private DateTime date;
        private bool deleted;
        private string description;
        private EffortClass effortClass;
        private int? noteID;
        private Organization organization;
        private Person person;
        private Problem problem;
        private Task projectTask;
        private Request request;
        private Service service;
        private ServiceInstance serviceInstance;
        private ServiceLevelAgreement sla;
        private DateTime? startedAt;
        private Task task;
        private TimeAllocation timeAllocation;
        private int timeSpent;

        #region ActivityID

        /// <summary>
        /// The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider. Some examples of activities are standard requests, a high impact incident or a request for information. The Activity ID can be used to support integrations between the billing system of the service provider and the 4me account in which the activities are performed.
        /// </summary>
        [JsonProperty("activityID")]
        public string ActivityID
        {
            get => activityID;
            internal set => activityID = value;
        }

        #endregion

        #region BillingID

        /// <summary>
        /// The Billing ID is the unique identifier by which all the activities that are performed through the coverage of the SLA are known in the billing system of the service provider. The billing ID can be used to support integrations between the billing system of the service provider and the 4me account in which the activities are performed.
        /// </summary>
        [JsonProperty("billingID")]
        public string BillingID
        {
            get => billingID;
            internal set => billingID = value;
        }

        #endregion

        #region Charge

        /// <summary>
        /// For a Time and Materials activity the charge is calculated by multiplying the time spent by the charge rate of the person’s who spent the time based on the selected effort class. For a Fixed Price activity the charge is the amount defined for the fixed price activity in the service offering (of the billable SLA related to the request).
        /// </summary>
        [JsonProperty("charge")]
        public float Charge
        {
            get => charge;
            internal set => charge = value;
        }

        #endregion

        #region Charge currency

        /// <summary>
        /// The currency of the charge field value of the time entry.
        /// </summary>
        [JsonProperty("charge_currency")]
        public string ChargeCurrency
        {
            get => chargeCurrency;
            internal set => chargeCurrency = value;
        }

        #endregion

        #region ChargeID

        /// <summary>
        /// The Charge ID is the unique identifier by which an effort class that is linked to a time entry when an activity was performed through the coverage of the SLA is known in the billing system of the service provider. The effort class represents the type of effort that was performed when working on an activity. Some examples of effort classes are ‘Billable - Normal Hours’, ‘Billable overtime’, ‘Non Billable’ or ‘Senior System Engineer’. The Charge ID can be used to support integrations between the billing system of the service provider and the 4me account in which the activities are performed. In the billing system the Charge IDs will be linked to the rates that have been agreed on in the service contract.
        /// </summary>
        [JsonProperty("chargeID")]
        public string ChargeID
        {
            get => chargeID;
            internal set => chargeID = value;
        }

        #endregion

        #region Charge rate

        /// <summary>
        /// Shows the charging rate per hour and is defined by the effort class that was selected when the person registered the time entry.
        /// </summary>
        [JsonProperty("charge_rate")]
        public float ChargeRate
        {
            get => chargeRate;
            internal set => chargeRate = value;
        }

        #endregion

        #region Charge type

        /// <summary>
        /// The charge type field defines how the activity is charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [JsonProperty("charge_type")]
        public ChargeType? ChargeType
        {
            get => chargeType;
            set => chargeType = SetValue("charge_type", chargeType, value);
        }

        #endregion

        #region Correction

        /// <summary>
        /// The Correction box is checked when the time entry should be considered a correction for a time entry that was registered for a date that has already been locked.
        /// </summary>
        [JsonProperty("correction")]
        public bool Correction
        {
            get => correction;
            set => correction = SetValue("correction", correction, value);
        }

        #endregion

        #region Cost

        /// <summary>
        /// The cost field shows cost of the time entry. It is calculated by multiplying the time spent by the cost per hour of the person’s who spent the time.
        /// </summary>
        [JsonProperty("cost")]
        public float? Cost
        {
            get => cost;
            internal set => cost = value;
        }

        #endregion

        #region Cost currency

        /// <summary>
        /// The currency of the cost field value of the time entry. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("cost_currency")]
        public string CostCurrency
        {
            get => costCurrency;
            set => costCurrency = SetValue("cost_currency", costCurrency, value);
        }

        #endregion

        #region Customer

        /// <summary>
        /// The Customer field is used to select the organization for which the time was spent.
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

        #region Date

        /// <summary>
        /// The Date field is used to select the date on which the time was spent.
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date
        {
            get => date;
            set => date = SetValue("date", date, value);
        }

        #endregion

        #region Deleted

        /// <summary>
        /// The Deleted box is automatically checked after the time entry has been deleted. The data of a deleted time entry that is older than 3 months can no longer be retrieved.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted
        {
            get => deleted;
            set => deleted = SetValue("deleted", deleted, value);
        }

        #endregion

        #region Description

        /// <summary>
        /// The Description field is used to enter a short description of the time spent. This field is available and required only when the Description required box is checked in the selected time allocation.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Effort class

        /// <summary>
        /// The Effort class field is used to select the effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set => effortClass = SetValue("effort_class_id", effortClass, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => effortClass?.ID;

        #endregion

        #region Note ID

        /// <summary>
        /// The unique ID of the note that the time entry is linked to.
        /// </summary>
        [JsonProperty("note_id")]
        public int? NoteID
        {
            get => noteID;
            set => noteID = SetValue("note_id", noteID, value);
        }

        #endregion

        #region Organization

        /// <summary>
        /// The organization to which the person was linked when the time entry was created.
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set => organization = SetValue("organization_id", organization, value);
        }

        [JsonProperty("organization_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? OrganizationID => organization?.ID;

        #endregion

        #region Person

        /// <summary>
        /// The Person field is used to specify the person who spent the time.
        /// </summary>
        [JsonProperty("person")]
        public Person Person
        {
            get => person;
            set => person = SetValue("person_id", person, value);
        }

        [JsonProperty("person_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? PersonID => person?.ID;

        #endregion

        #region Problem

        /// <summary>
        /// The Problem field shows the problem in which the Time spent field was filled out to cause the time entry to be generated.
        /// </summary>
        [JsonProperty("problem"), Sdk4meIgnoreInFieldSelection()]
        public Problem Problem
        {
            get => problem;
            set => problem = SetValue("problem_id", problem, value);
        }

        [JsonProperty("problem_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemID => problem?.ID;

        #endregion

        #region Project task

        /// <summary>
        /// The Project Task field shows the project task in which the Time spent field was filled out to cause the time entry to be generated.
        /// </summary>
        [JsonProperty("project_task"), Sdk4meIgnoreInFieldSelection()]
        public Task ProjectTask
        {
            get => projectTask;
            set => projectTask = SetValue("project_task_id", projectTask, value);
        }

        [JsonProperty("project_task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProjectTaskID => projectTask?.ID;

        #endregion

        #region Request

        /// <summary>
        /// The Request field shows the request in which the Time spent field was filled out to cause the time entry to be generated.
        /// </summary>
        [JsonProperty("request"), Sdk4meIgnoreInFieldSelection()]
        public Request Request
        {
            get => request;
            set => request = SetValue("request_id", request, value);
        }

        [JsonProperty("request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestID => request?.ID;

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the service for which the time was spent.
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

        #region Service instance

        /// <summary>
        /// The service instance for which the time was spent. This field is automatically set when a time entry is created for a request.
        /// </summary>
        [JsonProperty("service_instance")]
        public ServiceInstance ServiceInstance
        {
            get => serviceInstance;
            set => serviceInstance = SetValue("service_instance_id", serviceInstance, value);
        }

        [JsonProperty("service_instance_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceInstanceID => serviceInstance?.ID;

        #endregion

        #region SLA

        /// <summary>
        /// The service level agreement for which the time was spent. This field is automatically set when a time entry is created for a request.
        /// </summary>
        [JsonProperty("sla")]
        public ServiceLevelAgreement Sla
        {
            get => sla;
            internal set => sla = value;
        }

        #endregion

        #region Started at

        /// <summary>
        /// The Date field is used to select the date on which the time was spent.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime? StartedAt
        {
            get => startedAt;
            set => startedAt = SetValue("started_at", date, value);
        }

        #endregion

        #region Task

        /// <summary>
        /// The Task field shows the task in which the Time spent field was filled out to cause the time entry to be generated.
        /// </summary>
        [JsonProperty("task"), Sdk4meIgnoreInFieldSelection()]
        public Task Task
        {
            get => task;
            set => task = SetValue("task_id", task, value);
        }

        [JsonProperty("task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskID => task?.ID;

        #endregion

        #region Time allocation

        /// <summary>
        /// The Time allocation field is used to select the time allocation on which the time was spent. Only the time allocations that are linked to the person’s organization can be selected.
        /// </summary>
        [JsonProperty("time_allocation")]
        public TimeAllocation TimeAllocation
        {
            get => timeAllocation;
            set => timeAllocation = SetValue("time_allocation_id", timeAllocation, value);
        }

        [JsonProperty("time_allocation_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TimeAllocationID => timeAllocation?.ID;

        #endregion

        #region Time spent

        /// <summary>
        /// The Time spent field is used to specify the number of minutes that was spent on the selected time allocation. The number of minutes is allowed to be negative only when the correction field is set to true.
        /// </summary>
        [JsonProperty("time_spent")]
        public int TimeSpent
        {
            get => timeSpent;
            set => timeSpent = SetValue("time_spent", timeSpent, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            customer?.ResetPropertySerializationCollection();
            effortClass?.ResetPropertySerializationCollection();
            organization?.ResetPropertySerializationCollection();
            person?.ResetPropertySerializationCollection();
            problem?.ResetPropertySerializationCollection();
            projectTask?.ResetPropertySerializationCollection();
            request?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            serviceInstance?.ResetPropertySerializationCollection();
            sla?.ResetPropertySerializationCollection();
            task?.ResetPropertySerializationCollection();
            timeAllocation?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
