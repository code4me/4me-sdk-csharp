using System;
using System.Runtime.Serialization;

namespace Sdk4me
{
    #region Account

    public enum AccountPlan
    {
        [EnumMember(Value = "freemium")]
        Freemium = 1,
        [EnumMember(Value = "basic")]
        Basic,
        [EnumMember(Value = "premium")]
        Premium,
        [EnumMember(Value = "premium_plus")]
        PremiumPlus
    }

    [Flags]
    public enum AccessRoles
    {
        None = 0x00000000,
        [EnumMember(Value = "key_contact")]
        KeyContact = 0x00000001,
        [EnumMember(Value = "auditor")]
        Auditor = 0x00000002,
        [EnumMember(Value = "directory_auditor")]
        DirectoryAuditor = 0x00000004,
        [EnumMember(Value = "specialist")]
        Specialist = 0x00000008,
        [EnumMember(Value = "service_desk_analyst")]
        ServiceDeskAnalyst = 0x00000010,
        [EnumMember(Value = "service_desk_manager")]
        ServiceDeskManager = 0x00000020,
        [EnumMember(Value = "knowledge_manager")]
        KnowledgeManager = 0x00000040,
        [EnumMember(Value = "problem_manager")]
        ProblemManager = 0x00000080,
        [EnumMember(Value = "workflow_manager")]
        WorkflowManager = 0x00000100,
        [EnumMember(Value = "release_manager")]
        ReleaseManager = 0x00000200,
        [EnumMember(Value = "project_manager")]
        ProjectManager = 0x00000400,
        [EnumMember(Value = "service_level_manager")]
        ServiceLevelManager = 0x00000800,
        [EnumMember(Value = "configuration_manager")]
        ConfigurationManager = 0x00001000,
        [EnumMember(Value = "account_designer")]
        AccountDesigner = 0x00002000,
        [EnumMember(Value = "account_administrator")]
        AccountAdministrator = 0x00004000,
        [EnumMember(Value = "directory_designer")]
        DirectoryDesigner = 0x00008000,
        [EnumMember(Value = "directory_administrator")]
        DirectoryAdministrator = 0x00010000,
        [EnumMember(Value = "account_owner")]
        AccountOwner = 0x00020000,
        [EnumMember(Value = "financial_manager")]
        FinancialManager = 0x00040000,

        [Obsolete("Change manager is deprecated use workflow manager instead.")]
        [EnumMember(Value = "change_manager")]
        ChangeManager = 0x00080000,
    }

    public enum AccountSelection
    {
        CurrentAccount = 1,
        CurrentAccountAndDirectoryAccount = 2
    }

    #endregion

    #region Address

    public enum AddressType
    {
        [EnumMember(Value = "mailing")]
        Mailing = 1,
        [EnumMember(Value = "home")]
        Home,
        [EnumMember(Value = "street")]
        Street,
        [EnumMember(Value = "billing")]
        Billing
    }

    #endregion

    #region affected service level agreement

    public enum AffectedServiceLevelAgreementAccountability
    {
        [EnumMember(Value = "provider")]
        Provider = 1,
        [EnumMember(Value = "supplier")]
        Supplier,
        [EnumMember(Value = "sla_not_affected")]
        SlaNotAffected
    }

    public enum AffectedServiceLevelAgreementImpact
    {
        [EnumMember(Value = "low")]
        Low = 1,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Agile board

    public enum AgileBoardColumnAction
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "assign")]
        Assign,
        [EnumMember(Value = "accept")]
        Accept,
        [EnumMember(Value = "start")]
        Start,
        [EnumMember(Value = "complete")]
        Complete
    }

    public enum AgileBoardColumnDialogType
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "minimal")]
        Minimal,
        [EnumMember(Value = "full")]
        Full
    }

    #endregion

    #region Broadcast

    public enum BroadcastMessageType
    {
        [EnumMember(Value = "outage")]
        Outage = 1,
        [EnumMember(Value = "available")]
        Available,
        [EnumMember(Value = "warning")]
        Warning,
        [EnumMember(Value = "info")]
        Info
    }

    public enum BroadcastVisibility
    {
        [EnumMember(Value = "all_of_account")]
        AllOfAccount = 1,
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

    #region Calendar

    public enum CalendarWeekDay
    {
        [EnumMember(Value = "mon")]
        Monday = 1,
        [EnumMember(Value = "tue")]
        Tuesday,
        [EnumMember(Value = "wed")]
        Wednesday,
        [EnumMember(Value = "thu")]
        Thursday,
        [EnumMember(Value = "fri")]
        Friday,
        [EnumMember(Value = "sat")]
        Saturday,
        [EnumMember(Value = "sun")]
        Sunday
    }

    #endregion

    #region Contract

    public enum ContractCategory
    {
        [EnumMember(Value = "lease_contract")]
        LeaseContract = 1,
        [EnumMember(Value = "maintenance_contract")]
        MaintenanceContract,
        [EnumMember(Value = "support_contract")]
        SupportContract,
        [EnumMember(Value = "support_and_maintenance_contract")]
        SupportAndMaintenanceSupport,
        [EnumMember(Value = "other_type_of_contract")]
        OtherTypeOfContract
    }

    public enum ContractStatus
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Configuration item

    public enum ConfigurationitemLicenseType
    {
        [EnumMember(Value = "concurrent_user_license")]
        ConcurrentUserLicense = 1,
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

    public enum ConfigurationItemRuleSet
    {
        [EnumMember(Value = "license_certificate")]
        LicenseCertificate = 1,
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

    public enum ConfigurationItemStatus
    {
        [EnumMember(Value = "ordered")]
        Ordered = 1,
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

    #region Configuration item relations

    public enum ConfigurationitemRelationType
    {
        [EnumMember(Value = "parent")]
        Parent = 1,
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

    #region Contact

    public enum ContactType
    {
        [EnumMember(Value = "chat_hipchat")]
        ChatHipChat = 1,
        [EnumMember(Value = "chat_skype")]
        ChatSkype,
        [EnumMember(Value = "chat_slack")]
        ChatSlack,
        [EnumMember(Value = "chat_workchat")]
        ChatWorkChat,
        [EnumMember(Value = "chat_teams")]
        ChatTeams,
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

    #region First line support agreement

    public enum FirstLineSupportAgreementStatus
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        [EnumMember(Value = "scheduled_for_activation")]
        Scheduled_for_activation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Invoice

    public enum InvoiceDepreciationMethod
    {
        [EnumMember(Value = "not_depreciated")]
        NotDepreciated = 1,
        [EnumMember(Value = "double_declining_balance")]
        DoubleDecliningBalance,
        [EnumMember(Value = "reducing_balance")]
        ReducingBalance,
        [EnumMember(Value = "straight_line")]
        StraightLine,
        [EnumMember(Value = "sum_of_the_years_digits")]
        SumOfTheYearDigits
    }

    #endregion

    #region Knowledge article

    public enum KnowledgeArticleStatus
    {
        [EnumMember(Value = "not_validated")]
        NotValidated = 1,
        [EnumMember(Value = "work_in_progress")]
        WorkInProgress,
        [EnumMember(Value = "validated")]
        Validated,
        [EnumMember(Value = "archived")]
        Archived
    }

    #endregion

    #region Note

    public enum NoteMedium
    {
        [EnumMember(Value = "default")]
        Default = 1,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "outbound_email")]
        OutboundEmail,
        [EnumMember(Value = "system")]
        System,
        [EnumMember(Value = "redacted")]
        Redacted,
        [EnumMember(Value = "automation")]
        Automation
    }

    #endregion

    #region People

    public enum PeopleEmailNotificationPreference
    {
        [EnumMember(Value = "always")]
        Always = 1,
        [EnumMember(Value = "when_offline")]
        WhenOffline,
        [EnumMember(Value = "never")]
        Never
    }

    public enum PeoplePopupNotificationPreference
    {
        [EnumMember(Value = "always")]
        Always = 1,
        [EnumMember(Value = "important_only")]
        WhenOffline,
        [EnumMember(Value = "never")]
        Never
    }

    #endregion

    #region Problem

    public enum ProblemCategory
    {
        [EnumMember(Value = "reactive")]
        Reactive = 1,
        [EnumMember(Value = "proactive")]
        Proactive
    }

    public enum ProblemImpact
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    public enum ProblemStatus
    {
        [EnumMember(Value = "declined")]
        Declined = 1,
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
        [EnumMember(Value = "on_backlog")]
        OnBacklog
    }

    #endregion

    #region Product

    public enum ProductDepreciationMethod
    {
        [EnumMember(Value = "na_cost_is_zero")]
        NotApplicableCostIsZero = 1,
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

    public enum ProductRuleSet
    {
        [EnumMember(Value = "logical_asset_with_financial_data")]
        LogicalAssitWithFinancialData = 1,
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

    #region Project

    public enum ProjectCompletionReason
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "abandoned")]
        Abandoned,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "complete")]
        Complete
    }

    public enum ProjectJustification
    {
        [EnumMember(Value = "compliance")]
        Compliance = 1,
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

    public enum ProjectStatus
    {
        [EnumMember(Value = "registered")]
        Registered = 1,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region Project phase

    public enum ProjectPhaseStatus
    {
        [EnumMember(Value = "registered")]
        Registered,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region Project task

    public enum ProjectTaskCategory
    {
        [EnumMember(Value = "activity")]
        Activity = 1,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "milestone")]
        Milestone
    }

    public enum ProjectTaskStatus
    {
        [EnumMember(Value = "registered")]
        Registered = 1,
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

    #region Release

    public enum ReleaseCompletionReason
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "rolled_back")]
        Rolled_back,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "disruptive")]
        Disruptive,
        [EnumMember(Value = "complete")]
        Complete
    }

    public enum ReleaseImpact
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    public enum ReleaseStatus
    {
        [EnumMember(Value = "registered")]
        Registered = 1,
        [EnumMember(Value = "risk_and_impact")]
        RiskAndimpact,
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

    #region Requests

    public enum RequestCategory
    {
        [EnumMember(Value = "incident")]
        Incident = 1,
        [EnumMember(Value = "rfc")]
        RFC,
        [EnumMember(Value = "rfi")]
        RFI,
        [EnumMember(Value = "reservation")]
        Reservation,
        [EnumMember(Value = "complaint")]
        Complaint,
        [EnumMember(Value = "compliment")]
        Compliment,
        [EnumMember(Value = "other")]
        Other
    }

    public enum RequestCompletionReason
    {
        [EnumMember(Value = "solved")]
        Solved = 1,
        [EnumMember(Value = "workaround")]
        Workaround,
        [EnumMember(Value = "gone")]
        Gone,
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        [EnumMember(Value = "conflict")]
        Conflict,
        [EnumMember(Value = "unsolvable")]
        Unsolvable,
        [EnumMember(Value = "duplicate")]
        Duplicate
    }

    public enum RequestImpact
    {
        [EnumMember(Value = "low")]
        Low = 1,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    public enum RequestGroupingType
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "grouped")]
        Grouped
    }

    public enum RequestMajorIncidentStatus
    {
        [EnumMember(Value = "proposed")]
        Proposed = 1,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "resolved")]
        Resolved,
        [EnumMember(Value = "canceled")]
        Canceled
    }

    public enum RequestSatisfaction
    {
        [EnumMember(Value = "dissatisfied")]
        Dissatisfied = 1,
        [EnumMember(Value = "satisfied")]
        Satisfied
    }

    public enum RequestStatus
    {
        [EnumMember(Value = "declined")]
        Declined = 1,
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "accepted")]
        Accepted,
        [Obsolete("To continue using the id change_pending in the REST API, GraphQL API, Export API and Webhooks API, enable the account setting “Use deprecated change_pending status in API responses”.")]
        [EnumMember(Value = "change_pending")]
        ChangePending,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        [EnumMember(Value = "waiting_for_customer")]
        WaitingForCustomer,
        [EnumMember(Value = "workflow_pending")]
        WorkflowPending,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "on_backlog")]
        OnBacklog,
        [EnumMember(Value = "reservation_pending")]
        ReservationPending
    }

    #endregion

    #region Reservation

    public enum ReservationStatus
    {
        [EnumMember(Value = "assigned")]
        Assigned = 1,
        [EnumMember(Value = "provisional")]
        Provisional,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "confirmed")]
        Confirmed,
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "ended")]
        Ended,
    }

    #endregion

    #region Reservation offering

    public enum ReservationOfferingStatus
    {
        [EnumMember(Value = "pending")]
        Pending = 1,
        [EnumMember(Value = "confirmed")]
        Confirmed
    }

    [Flags]
    public enum ReserverationOfferingFilters
    {
        None = 0x00000000,
        [EnumMember(Value = "account")]
        Account = 0x00000001,
        [EnumMember(Value = "alternate_name")]
        AlternateName = 0x00000002,
        [EnumMember(Value = "assetID")]
        AssetID = 0x00000004,
        [EnumMember(Value = "contract")]
        Contract = 0x00000008,
        [EnumMember(Value = "created_at")]
        CreatedAt = 0x00000010,
        [EnumMember(Value = "financial_owner")]
        FinancialOwner = 0x00000020,
        [EnumMember(Value = "in_use_since")]
        InUseSince = 0x00000040,
        [EnumMember(Value = "license_expiry_date")]
        LicenseExpiryDate = 0x00000080,
        [EnumMember(Value = "location")]
        Location = 0x00000100,
        [EnumMember(Value = "product")]
        Product = 0x00000200,
        [EnumMember(Value = "product_brand")]
        ProductBrand = 0x00000400,
        [EnumMember(Value = "product_category")]
        ProductCategory = 0x00000800,
        [EnumMember(Value = "product_model")]
        ProductModel = 0x00001000,
        [EnumMember(Value = "rule_set")]
        RuleSet = 0x00002000,
        [EnumMember(Value = "serial_nr")]
        SerialNumber = 0x00004000,
        [EnumMember(Value = "service")]
        Service = 0x00008000,
        [EnumMember(Value = "service_instance")]
        ServiceInstance = 0x00010000,
        [EnumMember(Value = "service_owner")]
        ServiceOwner = 0x00020000,
        [EnumMember(Value = "site")]
        Site = 0x00040000,
        [EnumMember(Value = "source")]
        Source = 0x00080000,
        [EnumMember(Value = "status")]
        Status = 0x00100000,
        [EnumMember(Value = "supplier")]
        Supplier = 0x00200000,
        [EnumMember(Value = "support_account")]
        SupportAccount = 0x00400000,
        [EnumMember(Value = "support_team")]
        SupportTeam = 0x00800000,
        [EnumMember(Value = "systemID")]
        SystemID = 0x01000000,
        [EnumMember(Value = "updated_at")]
        UpdatedAt = 0x02000000,
        [EnumMember(Value = "user")]
        User = 0x04000000,
        [EnumMember(Value = "user_organization")]
        UserOrganization = 0x08000000,
        [EnumMember(Value = "warranty_expiry_date")]
        WarrantyExpiryDate = 0x10000000
    }

    #endregion

    #region Risk

    public enum RiskClosureReason
    {
        [EnumMember(Value = "eliminated")]
        Eliminated = 1,
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "mitigated")]
        Mitigated,
        [EnumMember(Value = "transferred")]
        Transferred,
        [EnumMember(Value = "no_risk")]
        NoRisk
    }

    public enum RiskStatus
    {
        [EnumMember(Value = "anticipated")]
        Anticipated = 1,
        [EnumMember(Value = "materialized")]
        Materialized,
        [EnumMember(Value = "closed")]
        Closed
    }

    #endregion

    #region Service

    public enum ServiceImpact
    {
        [EnumMember(Value = "low")]
        Low = 1,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Service instance

    public enum ServiceInstanceStatus
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        [EnumMember(Value = "in_production")]
        InProduction,
        [EnumMember(Value = "discontinued")]
        Discontinued
    }

    public enum ServiceInstanceImpact
    {
        [EnumMember(Value = "low")]
        Low = 1,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Service level agreement

    public enum ServiceLevelCoverage
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
        ServiceInstances,
        [EnumMember(Value = "skill_pools")]
        SkillPools
    }

    public enum ServiceLevelAgreementStatus
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Service offering
    public enum ServiceOfferingFrequency
    {
        [EnumMember(Value = "daily")]
        Daily = 1,
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

    public enum ServiceOfferingStatus
    {
        [EnumMember(Value = "planned")]
        Planned = 1,
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

    #region Survey

    public enum SurveyQuestionType
    {
        [EnumMember(Value = "star_rating")]
        StarRating = 1,
        [EnumMember(Value = "text")]
        Text
    }

    #endregion

    #region Task

    public enum TaskCategory
    {
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact = 1,
        [EnumMember(Value = "approval")]
        Approval,
        [EnumMember(Value = "implementation")]
        Implementation
    }

    public enum TaskImpact
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    public enum TaskStatus
    {
        [EnumMember(Value = "registered")]
        Registered = 1,
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
        [EnumMember(Value = "request_pending")]
        RequestPending,
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

    #region Time allocation

    public enum TimeAllocationCustomerCategory
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "selected")]
        Selected,
        [EnumMember(Value = "any")]
        Any
    }

    public enum TimeAllocationDescriptionCategory
    {
        [EnumMember(Value = "hidden")]
        Hidden = 1,
        [EnumMember(Value = "optional")]
        Optional,
        [EnumMember(Value = "required")]
        Required
    }

    public enum TimeAllocationServiceCategory
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "selected")]
        Selected,
        [EnumMember(Value = "any")]
        Any
    }

    #endregion

    #region Timesheet settings

    public enum TimesheetPercentageIncrement
    {
        [EnumMember(Value = "12.5")]
        TwelveAndHalf = 1,
        [EnumMember(Value = "25")]
        twentyFive,
        [EnumMember(Value = "50")]
        Fifty,
        [EnumMember(Value = "100")]
        Hundred
    }

    public enum TimesheetUnit
    {
        [EnumMember(Value = "hours_and_minutes")]
        HoursAndMinutes = 1,
        [EnumMember(Value = "percentage_of_workday")]
        PercentageOfWorkday
    }

    #endregion

    #region UI Extension

    public enum UIExtensionCategory
    {
        [EnumMember(Value = "request_template")]
        RequestTemplate = 1,
        [EnumMember(Value = "problem")]
        Problem,
        [EnumMember(Value = "release")]
        Release,
        [EnumMember(Value = "workflow_template")]
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
        [EnumMember(Value = "risk")]
        Risk,
        [EnumMember(Value = "custom_collection")]
        CustomCollection,
        [EnumMember(Value = "scim_user")]
        ScimUser
    }

    public enum UIExtensionVersionStatus
    {
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "archived")]
        Archived
    }

    #endregion

    #region Workflows

    public enum WorkflowCategory
    {
        [EnumMember(Value = "standard")]
        Standard = 1,
        [EnumMember(Value = "non_standard")]
        NonStandard,
        [EnumMember(Value = "emergency")]
        Emergency
    }

    public enum WorkflowCompletionReason
    {
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
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

    public enum WorkflowImpact
    {
        [EnumMember(Value = "none")]
        None = 1,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "top")]
        Top
    }

    public enum WorkflowJustification
    {
        [EnumMember(Value = "compliance")]
        Compliance = 1,
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

    public enum WorkflowPhaseStatus
    {
        [EnumMember(Value = "registered")]
        Registered = 1,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
    }

    public enum WorkflowStatus
    {
        [EnumMember(Value = "being_created")]
        BeingCreated = 1,
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
}
