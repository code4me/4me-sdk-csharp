using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace Sdk4me
{
    /// <summary>
    /// A 4me Environment type.
    /// </summary>
    public enum EnvironmentType
    {
        Production,
        Quality
    }

    /// <summary>
    /// Sort order for the 4me web request.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Order by "id"
        /// </summary>
        ID = 0,

        /// <summary>
        /// Order by "created_at"
        /// </summary>
        CreatedAt = 1,

        /// <summary>
        /// Order by "updated_at"
        /// </summary>
        UpdatedAt = 2,

        /// <summary>
        /// Order by "created_at" and then by "id"
        /// </summary>
        CreatedAtAndID = 3,

        /// <summary>
        /// Order by "updated_at" and then by "id"
        /// </summary>
        UpdatedAtAndID = 4,

        /// <summary>
        /// Do not sort the output
        /// </summary>
        None = 5
    }

    /// <summary>
    /// Operators for web request filtering.
    /// </summary>
    public enum FilterCondition
    {
        /// <summary>
        /// Same as given value 
        /// </summary>
        Equality,

        /// <summary>
        /// Different from given value 
        /// </summary>
        Negation,

        /// <summary>
        /// Equal to one of the given values (integers and enumerable values only) 
        /// </summary>
        In,

        /// <summary>
        /// Not equal to one of the given values (integers and enumerable values only) 
        /// </summary>
        NotIn,

        /// <summary>
        /// Less than given value (not for enumerable values, strings and booleans) 
        /// </summary>
        LessThan,

        /// <summary>
        /// Less than or equal to given value (not for enumerable values, strings and booleans) 
        /// </summary>
        LessThanOrEqualsTo,

        /// <summary>
        /// Greater than given value (not for enumerable values, strings and booleans) 
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than or equal to given value (not for enumerable values, strings and booleans)
        /// </summary>
        GreaterThanOrEqualsTo
    }

    #region permissions

    [Flags]
    public enum AccessRoleType : long
    {
        None = 0x00000000,
        KeyContact = 0x00000001,
        Auditor = 0x00000002,
        DirectoryAuditor = 0x00000004,
        Specialist = 0x00000008,
        ServiceDeskAnalyst = 0x00000010,
        ServiceDeskManager = 0x00000020,
        KnowledgeManager = 0x00000040,
        ProblemManager = 0x00000080,
        ChangeManager = 0x00000100,
        ReleaseManager = 0x00000200,
        ProjectManager = 0x00000400,
        ServiceLevelManager = 0x00000800,
        ConfigurationManager = 0x00001000,
        AccountDesigner = 0x00002000,
        AccountAdministrator = 0x00004000,
        DirectoryDesigner = 0x00008000,
        DirectoryAdministrator = 0x00010000,
        AccountOwner = 0x00020000
    }

    #endregion

    #region contact

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContactType
    {
        [EnumMember(Value = "chat_hipchat")]
        ChatHipChat,
        [EnumMember(Value = "chat_skype")]
        ChatSkype,
        [EnumMember(Value = "chat_slack")]
        ChatSlack,
        [EnumMember(Value = "chat_workchat")]
        ChatWorkChat,
        [EnumMember(Value = "fax")]
        Fax,
        [EnumMember(Value = "home")]
        Home,
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "personal")]
        Personal,
        [EnumMember(Value = "work")]
        Work,
        [EnumMember(Value = "general")]
        General,
        [EnumMember(Value = "service_desk")]
        ServiceDesk,
        [EnumMember(Value = "service_desk_fax")]
        ServiceDeskFax
    }

    #endregion

    #region contract

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContractCategoryType
    {
        [EnumMember(Value = "lease_contract")]
        LeaseContract,
        [EnumMember(Value = "maintenance_contract")]
        MaintenanceContract,
        [EnumMember(Value = "support_contract")]
        SupportContract,
        [EnumMember(Value = "support_and_maintenance_contract")]
        SupportAndMaintenanceSupport,
        [EnumMember(Value = "other_type_of_contract")]
        OtherTypeOfContract
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContractStatusType
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region address

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddressType
    {
        [EnumMember(Value = "street")]
        Street,
        [EnumMember(Value = "mailing")]
        Mailing,
        [EnumMember(Value = "billing")]
        Billing,
        [EnumMember(Value = "home")]
        Home
    }

    #endregion

    #region request

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestSatisfactionType
    {
        [EnumMember(Value = "dissatisfied")]
        Dissatisfied,
        [EnumMember(Value = "satisfied")]
        Satisfied
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestGroupingType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "grouped")]
        Grouped,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestStatusType
    {
        [EnumMember(Value = "declined")]
        Declined,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "waiting_for_customer")]
        WaitingForCustomer,
        [EnumMember(Value = "change_pending")]
        ChangePending,
        [EnumMember(Value = "completed")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestImpactType
    {
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestCompletionReasonType
    {
        [EnumMember(Value = "solved")]
        Solved,
        [EnumMember(Value = "workaround")]
        Workaround,
        [EnumMember(Value = "gone")]
        Gone,
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        [EnumMember(Value = "conflict")]
        Conflict,
        [EnumMember(Value = "unsolvable")]
        Unsolvable
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestCategoryType
    {
        [EnumMember(Value = "incident")]
        Incident,
        [EnumMember(Value = "rfc")]
        RFC,
        [EnumMember(Value = "rfi")]
        RFI,
        [EnumMember(Value = "complaint")]
        Complaint,
        [EnumMember(Value = "compliment")]
        Compliment,
        [EnumMember(Value = "other")]
        Other
    }

    #endregion

    #region service instance

    [JsonConverter(typeof(StringEnumConverter))]

    public enum ServiceInstanceStatusType
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "in_production")]
        InProduction,
        [EnumMember(Value = "discontinued")]
        Discontinued
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceInstanceImpactType
    {
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region service

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceImpactType
    {
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region product

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductRuleSetType
    {
        [EnumMember(Value = "logical_asset_with_financial_data")]
        LogicalAssitWithFinancialData,
        [EnumMember(Value = "logical_asset_without_financial_data")]
        LogicalAssetWithoutFinancialData,
        [EnumMember(Value = "physical_asset")]
        PhysicalAsset,
        [EnumMember(Value = "server")]
        Server,
        [EnumMember(Value = "software")]
        Software,
        [EnumMember(Value = "software_distribution_package")]
        SoftwareDistributionPackage
    }

    #endregion

    #region configuration item

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConfigurationItemDepreciationMethodType
    {
        [EnumMember(Value = "na_cost_is_zero")]
        NotApplicableCostIsZero,
        [EnumMember(Value = "na_not_capitalized")]
        NotApplicableNotCapitilized,
        [EnumMember(Value = "na_leased")]
        NotApplicableLeased,
        [EnumMember(Value = "double_declining_balance")]
        DoubleDecliningBalance,
        [EnumMember(Value = "reducing_balance")]
        ReducingBalance,
        [EnumMember(Value = "straight_line")]
        StraightLine,
        [EnumMember(Value = "sum_of_the_years_digits")]
        SumOfTheYearsDigits
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConfigurationitemLicenseType
    {
        [EnumMember(Value = "concurrent_user_license")]
        ConcurrentUserLicense,
        [EnumMember(Value = "cpu_license")]
        CpuLicense,
        [EnumMember(Value = "installed_user_license")]
        InstalledUserLicense,
        [EnumMember(Value = "named_user_license")]
        NamedUserLicense,
        [EnumMember(Value = "unlimited_user_license")]
        UnlimitedUserLicense,
        [EnumMember(Value = "other_type_of_license")]
        OtherTypeOfLicense
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConfigurationItemRuleSetType
    {
        [EnumMember(Value = "license_certificate")]
        LicenseCertificate,
        [EnumMember(Value = "logical_asset_with_financial_data")]
        LogicalAssitWithFinancialData,
        [EnumMember(Value = "logical_asset_without_financial_data")]
        LogicalAssetWithoutFinancialData,
        [EnumMember(Value = "physical_asset")]
        PhysicalAsset,
        [EnumMember(Value = "server")]
        Server,
        [EnumMember(Value = "software")]
        Software,
        [EnumMember(Value = "software_distribution_package")]
        SoftwareDistributionPackage
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConfigurationItemStatusType
    {
        [EnumMember(Value = "ordered")]
        Ordered,
        [EnumMember(Value = "being_built")]
        BeingBuilt,
        [EnumMember(Value = "in_stock")]
        InStock,
        [EnumMember(Value = "reserved")]
        Reserved,
        [EnumMember(Value = "in_transit")]
        InTransit,
        [EnumMember(Value = "installed")]
        Installed,
        [EnumMember(Value = "being_tested")]
        BeingTested,
        [EnumMember(Value = "standby_for_continuity")]
        StandbyForContinuity,
        [EnumMember(Value = "lent_out")]
        LentOut,
        [EnumMember(Value = "in_production")]
        InProduction,
        [EnumMember(Value = "undergoing_maintenance")]
        UndergoingMaintenance,
        [EnumMember(Value = "broken_down")]
        BrokenDown,
        [EnumMember(Value = "being_repaired")]
        BeingRepaired,
        [EnumMember(Value = "archived")]
        Archived,
        [EnumMember(Value = "to_be_removed")]
        ToBeRemoved,
        [EnumMember(Value = "lost_or_stolen")]
        LostOrStolen,
        [EnumMember(Value = "removed")]
        Removed
    }

    #endregion

    #region configuration item relation

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConfigurationitemRelationType
    {
        [EnumMember(Value = "parent")]
        Parent,
        [EnumMember(Value = "child")]
        Child,
        [EnumMember(Value = "network_connection")]
        NetworkConnection,
        [EnumMember(Value = "redundancy")]
        Redundancy,
        [EnumMember(Value = "continuity")]
        Continuity,
        [EnumMember(Value = "software_dependency")]
        SoftwareDependency
    }

    #endregion

    #region change

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeCompletionReasonType
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "rolled_back")]
        RolledBack,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "disruptive")]
        Disruptive,
        [EnumMember(Value = "complete")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeImpactType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeCategoryType
    {
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "non_standard")]
        NonStandard,
        [EnumMember(Value = "emergency")]
        Emergency
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeType
    {
        [EnumMember(Value = "application_change")]
        ApplicationChange,
        [EnumMember(Value = "infrastructure_change")]
        InfrastructureChange
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeJustificationType
    {
        [EnumMember(Value = "compliance")]
        Compliance,
        [EnumMember(Value = "correction")]
        Correction,
        [EnumMember(Value = "expansion")]
        Expansion,
        [EnumMember(Value = "improvement")]
        Improvement,
        [EnumMember(Value = "maintenance")]
        Maintenance,
        [EnumMember(Value = "move")]
        Move,
        [EnumMember(Value = "removal")]
        Removal,
        [EnumMember(Value = "replacement")]
        Replacement
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChangeStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "implementation")]
        Implementation,
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "being_created")]
        BeingCreated
    }

    #endregion

    #region task

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskCategoryType
    {
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "implementation")]
        Implementation
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskImpactType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "declined")]
        Declined,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "failed")]
        failed,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "approved")]
        Approved,
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region problem

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProblemCategoryType
    {
        [EnumMember(Value = "reactive")]
        Reactive,
        [EnumMember(Value = "proactive")]
        Proactive
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProblemImpactType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProblemStatusType
    {
        [EnumMember(Value = "declined")]
        Declined,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "analyzed")]
        Analyzed,
        [EnumMember(Value = "change_requested")]
        ChangeRequested,
        [EnumMember(Value = "change_pending")]
        ChangePending,
        [EnumMember(Value = "project_pending")]
        ProjectPending,
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        [EnumMember(Value = "solved")]
        Solved,
    }

    #endregion

    #region release

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReleaseCompletionReasonType
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "rolled_back")]
        RolledBack,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "disruptive")]
        Disruptive,
        [EnumMember(Value = "complete")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReleaseImpactType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReleaseStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "implementation")]
        Implementation,
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region knowledge article

    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnowledgeArticleStatusType
    {
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "internal")]
        Internal,
        [EnumMember(Value = "public")]
        Public,
        [EnumMember(Value = "archived")]
        Archived
    }

    #endregion

    #region time allocation

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAllocationCustomerCategoryType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "selected")]
        Selected,
        [EnumMember(Value = "any")]
        Any
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAllocationDescriptionCategoryType
    {
        [EnumMember(Value = "hidden")]
        Hidden,
        [EnumMember(Value = "optional")]
        Optional,
        [EnumMember(Value = "required")]
        Required
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeAllocationServiceCategoryType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "selected")]
        Selected,
        [EnumMember(Value = "any")]
        Any
    }

    #endregion

    #region notes

    [JsonConverter(typeof(StringEnumConverter))]
    public enum NoteMediumType
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "system")]
        System,
        [EnumMember(Value = "redacted")]
        Redacted,
        [EnumMember(Value = "automation")]
        Automation
    }

    #endregion

    #region ui extension

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UIExtensionApprovalStatusType
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "approved")]
        Approved
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UIExtensionStatusType
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "archived")]
        Archived
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UIExtensionCategoryType
    {
        [EnumMember(Value = "request_template")]
        RequestTemplate,
        [EnumMember(Value = "change_template")]
        ChangeTemplate,
        [EnumMember(Value = "task_template")]
        TaskTemplate,
        [EnumMember(Value = "project")]
        Project,
        [EnumMember(Value = "project_task_template")]
        ProjectTaskTemplate,
        [EnumMember(Value = "product")]
        Product,
        [EnumMember(Value = "contract")]
        Contract,
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "person")]
        Person,
        [EnumMember(Value = "site")]
        Site,
        [EnumMember(Value = "problem")]
        Problem
    }

    #endregion

    #region account

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountPlanType
    {
        [EnumMember(Value = "basic")]
        Basic,
        [EnumMember(Value = "premium")]
        Premium,
        [EnumMember(Value = "premium_plus")]
        PremiumPlus
    }

    #endregion

    #region SLA

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SLACoverageType
    {
        [EnumMember(Value = "customer_account")]
        CustomerAccount,
        [EnumMember(Value = "organizations_and_descendants")]
        OrganizationsAndDescendants,
        [EnumMember(Value = "organizations")]
        Organizations,
        [EnumMember(Value = "sites")]
        Sites,
        [EnumMember(Value = "organizations_and_sites")]
        OrganizationsAndSites,
        [EnumMember(Value = "people")]
        People,
        [EnumMember(Value = "cis_of_service_instance")]
        ConfigurationItemsAndServiceInstances,
        [EnumMember(Value = "service_instances")]
        ServiceInstances
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceLevelAgreementStatusType
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region service offering

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceOfferingFrequencyType
    {
        [EnumMember(Value = "daily")]
        Daily,
        [EnumMember(Value = "weekly")]
        Weekly,
        [EnumMember(Value = "once_every_2_weeks")]
        OnceEvery2Weeks,
        [EnumMember(Value = "monthly")]
        Monthly,
        [EnumMember(Value = "once_every_2_months")]
        OnceEvery2Months,
        [EnumMember(Value = "quarterly")]
        Quarterly,
        [EnumMember(Value = "once_every_6_months")]
        OnceEvery6Months,
        [EnumMember(Value = "yearly")]
        Yearly,
        [EnumMember(Value = "once_every_2_years")]
        OnceEvery2Years,
        [EnumMember(Value = "no_commitment")]
        NoCommitment
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceOfferingStatusType
    {
        [EnumMember(Value = "planned")]
        Planned,
        [EnumMember(Value = "unpublished")]
        Unpublished,
        [EnumMember(Value = "available")]
        Available,
        [EnumMember(Value = "temporarily_unavailable")]
        TemporarilyUnavailable,
        [EnumMember(Value = "discontinued")]
        Discontinued
    }

    #endregion

    #region broadcast

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BroadcastMessageType
    {
        [EnumMember(Value = "outage")]
        Outage,
        [EnumMember(Value = "available")]
        Available,
        [EnumMember(Value = "warning")]
        Warning,
        [EnumMember(Value = "info")]
        Info
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BroadcastVisibilityType
    {
        [EnumMember(Value = "all_of_account")]
        AllOfAccount,
        [EnumMember(Value = "account_specialists")]
        AccountSpecialists,
        [EnumMember(Value = "members_of_teams")]
        MemberOfTeams,
        [EnumMember(Value = "covered_for_any")]
        CoveredForAny,
        [EnumMember(Value = "covered_for")]
        CoveredFor,
        [EnumMember(Value = "customers")]
        Customers
    }

    #endregion

    #region affected service level agreement

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AffectedServiceLevelAgreementAccountabilityType
    {
        [EnumMember(Value = "provider")]
        Provider,
        [EnumMember(Value = "supplier")]
        Supplier,
        [EnumMember(Value = "sla_not_affected")]
        SlaNotAffected
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AffectedServiceLevelAgreementImpactType
    {
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region projects

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectCompletionReasonType
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "abandoned")]
        Abandoned,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "complete")]
        Complete
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectJustificationType
    {
        [EnumMember(Value = "compliance")]
        Compliance,
        [EnumMember(Value = "correction")]
        Correction,
        [EnumMember(Value = "expansion")]
        Expansion,
        [EnumMember(Value = "improvement")]
        Improvement,
        [EnumMember(Value = "maintenance")]
        Maintenance,
        [EnumMember(Value = "move")]
        Move,
        [EnumMember(Value = "removal")]
        Removal,
        [EnumMember(Value = "replacement")]
        Replacement
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region project tasks

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectCategoryType
    {
        [EnumMember(Value = "activity")]
        Activity,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "milestone")]
        Milestone
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectTaskStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "approved")]
        Approved,
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region project phases

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectPhaseStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region assignment

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignmentStatusType
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "approved")]
        Approved,
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region first line support agreements

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FirstLineSupportAgreementStatusType
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "scheduled_for_activation")]
        Scheduled_for_activation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region people

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PeopleEmailNotificationPreferenceType
    {
        [EnumMember(Value = "always")]
        Always,
        [EnumMember(Value = "when_offline")]
        WhenOffline,
        [EnumMember(Value = "never")]
        Never
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PeoplePopupNotificationPreferenceType
    {
        [EnumMember(Value = "always")]
        Always,
        [EnumMember(Value = "important_only")]
        WhenOffline,
        [EnumMember(Value = "never")]
        Never
    }

    #endregion

    #region timesheet settings

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimesheetSettingsUnitType
    {
        [EnumMember(Value = "hours_and_minutes")]
        HoursAndMinutes,
        [EnumMember(Value = "percentage_of_workday")]
        PercentageOfWorkday
    }

    #endregion

    #region change templates

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecurrenceFrequencyType
    {
        [EnumMember(Value = "no_repeat")]
        NoRepeat,
        [EnumMember(Value = "daily")]
        Daily,
        [EnumMember(Value = "weekly")]
        Weekly,
        [EnumMember(Value = "monthly")]
        Monthly,
        [EnumMember(Value = "yearly")]
        Yearly
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecurrenceDayOfWeekType
    {
        [EnumMember(Value = "first")]
        First,
        [EnumMember(Value = "second")]
        Second,
        [EnumMember(Value = "third")]
        Third,
        [EnumMember(Value = "fourth")]
        Fourth,
        [EnumMember(Value = "last")]
        Last
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecurrenceDayOfWeekDayType
    {
        [EnumMember(Value = "monday")]
        Monday,
        [EnumMember(Value = "tuesday")]
        Tuesday,
        [EnumMember(Value = "wednesday")]
        Wednesday,
        [EnumMember(Value = "thursday")]
        Thursday,
        [EnumMember(Value = "friday")]
        Friday,
        [EnumMember(Value = "saturday")]
        Saturday,
        [EnumMember(Value = "sunday")]
        Sunday
    }

    #endregion
}
