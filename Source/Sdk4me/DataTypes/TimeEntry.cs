using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class TimeEntry : BaseItem
    {
        private bool correction;
        private Organization customer;
        private DateTime? date;
        private bool deleted;
        private string description;
        private Organization organization;
        private Person person;
        private Problem problem;
        private Request request;
        private Service service;
        private Task task;
        private TimeAllocation timeAllocation;
        private int timeSpent;

        #region correction

        [JsonProperty("correction")]
        public bool Correction
        {
            get => correction;
            set
            {
                if (correction != value)
                    AddIncludedDuringSerialization("correction");
                correction = value;
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

        #region date

        [JsonProperty("date")]
        public DateTime? Date
        {
            get => date;
            set
            {
                if (date != value)
                    AddIncludedDuringSerialization("date");
                date = value;
            }
        }

        #endregion

        #region deleted

        [JsonProperty("deleted")]
        public bool Deleted
        {
            get => deleted;
            set
            {
                if (deleted != value)
                    AddIncludedDuringSerialization("deleted");
                deleted = value;
            }
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

        #region organization

        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set
            {
                if (organization?.ID != value?.ID)
                    AddIncludedDuringSerialization("organization_id");
                organization = value;
            }
        }

        [JsonProperty(PropertyName = "organization_id"), Sdk4meIgnoreInFieldSelection()]
        private long? OrganizationID
        {
            get => (organization != null ? organization.ID : (long?)null);
        }

        #endregion

        #region person

        [JsonProperty("person")]
        public Person Person
        {
            get => person;
            set
            {
                if (person?.ID != value?.ID)
                    AddIncludedDuringSerialization("person_id");
                person = value;
            }
        }

        [JsonProperty(PropertyName = "person_id"), Sdk4meIgnoreInFieldSelection()]
        private long? PersonID
        {
            get => (person != null ? person.ID : (long?)null);
        }

        #endregion

        #region problem

        [JsonProperty("problem"), Sdk4meIgnoreInFieldSelection()]
        public Problem Problem
        {
            get => problem;
            internal set => problem = value;
        }

        #endregion

        #region request

        [JsonProperty("request"), Sdk4meIgnoreInFieldSelection()]
        public Request Request
        {
            get => request;
            internal set => request = value;
        }

        #endregion

        #region service

        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set
            {
                if (service != value)
                    AddIncludedDuringSerialization("service");
                service = value;
            }
        }

        #endregion

        #region task

        [JsonProperty("task"), Sdk4meIgnoreInFieldSelection()]
        public Task Task
        {
            get => task;
            internal set => task = value;
        }

        #endregion

        #region time_allocation

        [JsonProperty("time_allocation")]
        public TimeAllocation TimeAllocation
        {
            get => timeAllocation;
            set
            {
                if (timeAllocation?.ID != value?.ID)
                    AddIncludedDuringSerialization("time_allocation_id");
                timeAllocation = value;
            }
        }

        [JsonProperty(PropertyName = "time_allocation_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TimeAllocationID
        {
            get => (timeAllocation != null ? timeAllocation.ID : (long?)null);
        }

        #endregion

        #region time_spent

        [JsonProperty("time_spent")]
        public int TimeSpent
        {
            get => timeSpent;
            set
            {
                if (timeSpent != value)
                    AddIncludedDuringSerialization("time_spent");
                timeSpent = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            customer?.ResetIncludedDuringSerialization();
            organization?.ResetIncludedDuringSerialization();
            person?.ResetIncludedDuringSerialization();
            problem?.ResetIncludedDuringSerialization();
            request?.ResetIncludedDuringSerialization();
            service?.ResetIncludedDuringSerialization();
            task?.ResetIncludedDuringSerialization();
            timeAllocation?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
