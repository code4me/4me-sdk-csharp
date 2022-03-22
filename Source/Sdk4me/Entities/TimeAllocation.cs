using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/time_allocations/">time allocation</see> object.
    /// </summary>
    public class TimeAllocation : BaseItem
    {
        private TimeAllocationCustomerCategory customerCategory;
        private TimeAllocationDescriptionCategory descriptionCategory;
        private bool disabled;
        private EffortClass effortClass;
        private string group;
        private string localizedGroup;
        private string localizedName;
        private string name;
        private TimeAllocationServiceCategory serviceCategory;
        private string source;
        private string sourceID;

        #region Customer category

        /// <summary>
        /// The Customer field is used to specify if a Person who spent on the time allocation needs to select a Customer Organization, and if this is the case, whether this person may only select from the customer organizations linked to the time allocation or is allowed to select any customer organization. 
        /// </summary>
        [JsonProperty("customer_category")]
        public TimeAllocationCustomerCategory CustomerCategory
        {
            get => customerCategory;
            set => customerCategory = SetValue("customer_category", customerCategory, value);
        }

        #endregion

        #region Description category

        /// <summary>
        /// The Description field is used to specify whether the Description field should be available, and if so, whether it should be required, in the time entries to which the time allocation is related. 
        /// </summary>
        [JsonProperty("description_category")]
        public TimeAllocationDescriptionCategory DescriptionCategory
        {
            get => descriptionCategory;
            set => descriptionCategory = SetValue("description_category", descriptionCategory, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the time allocation may no longer be related to any more organizations.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Effort class

        /// <summary>
        /// The effort class that is selected by default, when someone registers time on this time allocation.
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

        #region Group

        /// <summary>
        /// The Group field is used to include the time allocation in a group.
        /// </summary>
        [JsonProperty("group")]
        public string Group
        {
            get => group;
            set => group = SetValue("group", group, value);
        }

        #endregion

        #region Localized group

        /// <summary>
        /// Translated Group in the current language, defaults to group in case no translation is provided.
        /// </summary>
        [JsonProperty("localized_group"), Sdk4meIgnoreInFieldSelection()]
        public string LocalizedGroup
        {
            get => localizedGroup;
            internal set => localizedGroup = value;
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
        /// The Name field is used to enter the name of the time allocation.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Service category

        /// <summary>
        /// The Service field is used to specify if a Person who spent on the time allocation needs to select a Service, and if this is the case, whether this person may only select from the services linked to the time allocation or is allowed to select any service. 
        /// </summary>
        [JsonProperty("service_category")]
        public TimeAllocationServiceCategory ServiceCategory
        {
            get => serviceCategory;
            set => serviceCategory = SetValue("service_category", serviceCategory, value);
        }

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

        internal override void ResetPropertySerializationCollection()
        {
            effortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
