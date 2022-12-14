using System;
using System.Runtime.Serialization;

namespace Sdk4me
{
    #region Account

    /// <summary>
    /// A 4me account plan.
    /// </summary>
    public enum AccountPlan
    {
        /// <summary>
        /// The freemium plan.
        /// </summary>
        [EnumMember(Value = "freemium")]
        Freemium = 1,
        /// <summary>
        /// The basic plan.
        /// </summary>
        [EnumMember(Value = "basic")]
        Basic,
        /// <summary>
        /// The premium plan.
        /// </summary>
        [EnumMember(Value = "premium")]
        Premium,
        /// <summary>
        /// The premium plus plan.
        /// </summary>
        [EnumMember(Value = "premium_plus")]
        PremiumPlus
    }

    /// <summary>
    /// The 4me access roles.
    /// </summary>
    [Flags]
    public enum AccessRoles
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// A key contact.
        /// </summary>
        [EnumMember(Value = "key_contact")]
        KeyContact = 0x00000001,
        /// <summary>
        /// An auditor.
        /// </summary>
        [EnumMember(Value = "auditor")]
        Auditor = 0x00000002,
        /// <summary>
        /// A directory auditor.
        /// </summary>
        [EnumMember(Value = "directory_auditor")]
        DirectoryAuditor = 0x00000004,
        /// <summary>
        /// A specialist.
        /// </summary>
        [EnumMember(Value = "specialist")]
        Specialist = 0x00000008,
        /// <summary>
        /// A service desk analyst.
        /// </summary>
        [EnumMember(Value = "service_desk_analyst")]
        ServiceDeskAnalyst = 0x00000010,
        /// <summary>
        /// A service desk manager.
        /// </summary>
        [EnumMember(Value = "service_desk_manager")]
        ServiceDeskManager = 0x00000020,
        /// <summary>
        /// A knowledge manager.
        /// </summary>
        [EnumMember(Value = "knowledge_manager")]
        KnowledgeManager = 0x00000040,
        /// <summary>
        /// A problem manager.
        /// </summary>
        [EnumMember(Value = "problem_manager")]
        ProblemManager = 0x00000080,
        /// <summary>
        /// A workflow manager.
        /// </summary>
        [EnumMember(Value = "workflow_manager")]
        WorkflowManager = 0x00000100,
        /// <summary>
        /// Release manager.
        /// </summary>
        [EnumMember(Value = "release_manager")]
        ReleaseManager = 0x00000200,
        /// <summary>
        /// A project manager.
        /// </summary>
        [EnumMember(Value = "project_manager")]
        ProjectManager = 0x00000400,
        /// <summary>
        /// A service level manager.
        /// </summary>
        [EnumMember(Value = "service_level_manager")]
        ServiceLevelManager = 0x00000800,
        /// <summary>
        /// A configuration manager.
        /// </summary>
        [EnumMember(Value = "configuration_manager")]
        ConfigurationManager = 0x00001000,
        /// <summary>
        /// An account designer.
        /// </summary>
        [EnumMember(Value = "account_designer")]
        AccountDesigner = 0x00002000,
        /// <summary>
        /// An account administrator.
        /// </summary>
        [EnumMember(Value = "account_administrator")]
        AccountAdministrator = 0x00004000,
        /// <summary>
        /// A directory designer.
        /// </summary>
        [EnumMember(Value = "directory_designer")]
        DirectoryDesigner = 0x00008000,
        /// <summary>
        /// A directory administrator.
        /// </summary>
        [EnumMember(Value = "directory_administrator")]
        DirectoryAdministrator = 0x00010000,
        /// <summary>
        /// An account owner.
        /// </summary>
        [EnumMember(Value = "account_owner")]
        AccountOwner = 0x00020000,
        /// <summary>
        /// A financial manager.
        /// </summary>
        [EnumMember(Value = "financial_manager")]
        FinancialManager = 0x00040000,
        /// <summary>
        /// A change manager.
        /// </summary>
        [Obsolete("Change manager is deprecated use workflow manager instead.")]
        [EnumMember(Value = "change_manager")]
        ChangeManager = 0x00080000,
    }

    /// <summary>
    /// The account selection filter.
    /// </summary>
    public enum AccountSelection
    {
        /// <summary>
        /// Current account only.
        /// </summary>
        CurrentAccount = 1,
        /// <summary>
        /// The current and directory account.
        /// </summary>
        CurrentAccountAndDirectoryAccount = 2
    }

    #endregion

    #region Address

    /// <summary>
    /// A 4me address type.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        /// Mailing address.
        /// </summary>
        [EnumMember(Value = "mailing")]
        Mailing = 1,
        /// <summary>
        /// Home address.
        /// </summary>
        [EnumMember(Value = "home")]
        Home,
        /// <summary>
        /// Street address.
        /// </summary>
        [EnumMember(Value = "street")]
        Street,
        /// <summary>
        /// Billing address.
        /// </summary>
        [EnumMember(Value = "billing")]
        Billing
    }

    #endregion

    #region affected service level agreement

    /// <summary>
    /// The 4me affected service level agreement accountability.
    /// </summary>
    public enum AffectedServiceLevelAgreementAccountability
    {
        /// <summary>
        /// The provider.
        /// </summary>
        [EnumMember(Value = "provider")]
        Provider = 1,
        /// <summary>
        /// The supplier.
        /// </summary>
        [EnumMember(Value = "supplier")]
        Supplier,
        /// <summary>
        /// No SLA affected.
        /// </summary>
        [EnumMember(Value = "sla_not_affected")]
        SlaNotAffected
    }

    /// <summary>
    /// The 4me affected service level agreement impact.
    /// </summary>
    public enum AffectedServiceLevelAgreementImpact
    {
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 1,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Agile board

    /// <summary>
    /// A 4me agile board column action.
    /// </summary>
    public enum AgileBoardColumnAction
    {
        /// <summary>
        /// No action.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Assign action.
        /// </summary>
        [EnumMember(Value = "assign")]
        Assign,
        /// <summary>
        /// Accept action.
        /// </summary>
        [EnumMember(Value = "accept")]
        Accept,
        /// <summary>
        /// Start action.
        /// </summary>
        [EnumMember(Value = "start")]
        Start,
        /// <summary>
        /// Completed action.
        /// </summary>
        [EnumMember(Value = "complete")]
        Complete
    }

    /// <summary>
    /// A 4me agile board column dialog type.
    /// </summary>
    public enum AgileBoardColumnDialogType
    {
        /// <summary>
        /// No dialog.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Minimal dialog.
        /// </summary>
        [EnumMember(Value = "minimal")]
        Minimal,
        /// <summary>
        /// Full dialog.
        /// </summary>
        [EnumMember(Value = "full")]
        Full
    }

    #endregion

    #region Broadcast

    /// <summary>
    /// A 4me broadcast message type.
    /// </summary>
    public enum BroadcastMessageType
    {
        /// <summary>
        /// An outage.
        /// </summary>
        [EnumMember(Value = "outage")]
        Outage = 1,
        /// <summary>
        /// Available.
        /// </summary>
        [EnumMember(Value = "available")]
        Available,
        /// <summary>
        /// A warning.
        /// </summary>
        [EnumMember(Value = "warning")]
        Warning,
        /// <summary>
        /// An information.
        /// </summary>
        [EnumMember(Value = "info")]
        Info
    }

    /// <summary>
    /// A 4me broadcast visibility.
    /// </summary>
    public enum BroadcastVisibility
    {
        /// <summary>
        /// Visible for all accounts.
        /// </summary>
        [EnumMember(Value = "all_of_account")]
        AllOfAccount = 1,
        /// <summary>
        /// Visible for account specialists.
        /// </summary>
        [EnumMember(Value = "account_specialists")]
        AccountSpecialists,
        /// <summary>
        /// Visible for team members.
        /// </summary>
        [EnumMember(Value = "members_of_teams")]
        MemberOfTeams,
        /// <summary>
        /// Visible for any covered.
        /// </summary>
        [EnumMember(Value = "covered_for_any")]
        CoveredForAny,
        /// <summary>
        /// Visible for covered.
        /// </summary>
        [EnumMember(Value = "covered_for")]
        CoveredFor,
        /// <summary>
        /// Visible for customers.
        /// </summary>
        [EnumMember(Value = "customers")]
        Customers
    }

    #endregion

    #region Calendar

    /// <summary>
    /// A 4me calendar week day.
    /// </summary>
    public enum CalendarWeekDay
    {
        /// <summary>
        /// Monday.
        /// </summary>
        [EnumMember(Value = "mon")]
        Monday = 1,
        /// <summary>
        /// Tuesday.
        /// </summary>
        [EnumMember(Value = "tue")]
        Tuesday,
        /// <summary>
        /// Wednesday.
        /// </summary>
        [EnumMember(Value = "wed")]
        Wednesday,
        /// <summary>
        /// Thursday.
        /// </summary>
        [EnumMember(Value = "thu")]
        Thursday,
        /// <summary>
        /// Friday.
        /// </summary>
        [EnumMember(Value = "fri")]
        Friday,
        /// <summary>
        /// Saturday.
        /// </summary>
        [EnumMember(Value = "sat")]
        Saturday,
        /// <summary>
        /// Sunday.
        /// </summary>
        [EnumMember(Value = "sun")]
        Sunday
    }

    #endregion

    #region Contract

    /// <summary>
    /// A 4me contract category.
    /// </summary>
    public enum ContractCategory
    {
        /// <summary>
        /// A lease contract.
        /// </summary>
        [EnumMember(Value = "lease_contract")]
        LeaseContract = 1,
        /// <summary>
        /// A maintenance contract.
        /// </summary>
        [EnumMember(Value = "maintenance_contract")]
        MaintenanceContract,
        /// <summary>
        /// A support contract.
        /// </summary>
        [EnumMember(Value = "support_contract")]
        SupportContract,
        /// <summary>
        /// A support and maintenance contract.
        /// </summary>
        [EnumMember(Value = "support_and_maintenance_contract")]
        SupportAndMaintenanceSupport,
        /// <summary>
        /// An other type of contract.
        /// </summary>
        [EnumMember(Value = "other_type_of_contract")]
        OtherTypeOfContract
    }

    /// <summary>
    /// A 4me contract status type.
    /// </summary>
    public enum ContractStatus
    {
        /// <summary>
        /// Contract being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        /// <summary>
        /// Contract scheduled for activation.
        /// </summary>
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        /// <summary>
        /// Contract is active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Contact expired.
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Configuration item

    /// <summary>
    /// A 4me configuration item license status.
    /// </summary>
    public enum ConfigurationitemLicenseType
    {
        /// <summary>
        /// A concurrent user license.
        /// </summary>
        [EnumMember(Value = "concurrent_user_license")]
        ConcurrentUserLicense = 1,
        /// <summary>
        /// A CPU license.
        /// </summary>
        [EnumMember(Value = "cpu_license")]
        CpuLicense,
        /// <summary>
        /// An installed user license.
        /// </summary>
        [EnumMember(Value = "installed_user_license")]
        InstalledUserLicense,
        /// <summary>
        /// A named user license.
        /// </summary>
        [EnumMember(Value = "named_user_license")]
        NamedUserLicense,
        /// <summary>
        /// Unlimited licenses.
        /// </summary>
        [EnumMember(Value = "unlimited_user_license")]
        UnlimitedUserLicense,
        /// <summary>
        /// An other type of license.
        /// </summary>
        [EnumMember(Value = "other_type_of_license")]
        OtherTypeOfLicense
    }

    /// <summary>
    /// A 4me configuration item rule set.
    /// </summary>
    public enum ConfigurationItemRuleSet
    {
        /// <summary>
        /// A license certificate
        /// </summary>
        [EnumMember(Value = "license_certificate")]
        LicenseCertificate = 1,
        /// <summary>
        /// A logical asset with financial data.
        /// </summary>
        [EnumMember(Value = "logical_asset_with_financial_data")]
        LogicalAssitWithFinancialData,
        /// <summary>
        /// A logical asset without financial data.
        /// </summary>
        [EnumMember(Value = "logical_asset_without_financial_data")]
        LogicalAssetWithoutFinancialData,
        /// <summary>
        /// A physical asset.
        /// </summary>
        [EnumMember(Value = "physical_asset")]
        PhysicalAsset,
        /// <summary>
        /// A server.
        /// </summary>
        [EnumMember(Value = "server")]
        Server,
        /// <summary>
        /// Software.
        /// </summary>
        [EnumMember(Value = "software")]
        Software,
        /// <summary>
        /// Software distribution package.
        /// </summary>
        [EnumMember(Value = "software_distribution_package")]
        SoftwareDistributionPackage
    }

    /// <summary>
    /// A 4me configuration item status.
    /// </summary>
    public enum ConfigurationItemStatus
    {
        /// <summary>
        /// Ordered status.
        /// </summary>
        [EnumMember(Value = "ordered")]
        Ordered = 1,
        /// <summary>
        /// Being built status.
        /// </summary>
        [EnumMember(Value = "being_built")]
        BeingBuilt,
        /// <summary>
        /// In stock status.
        /// </summary>
        [EnumMember(Value = "in_stock")]
        InStock,
        /// <summary>
        /// Reserved status.
        /// </summary>
        [EnumMember(Value = "reserved")]
        Reserved,
        /// <summary>
        /// In transit status.
        /// </summary>
        [EnumMember(Value = "in_transit")]
        InTransit,
        /// <summary>
        /// Installed status.
        /// </summary>
        [EnumMember(Value = "installed")]
        Installed,
        /// <summary>
        /// Being tested status.
        /// </summary>
        [EnumMember(Value = "being_tested")]
        BeingTested,
        /// <summary>
        /// Standby for continuity status.
        /// </summary>
        [EnumMember(Value = "standby_for_continuity")]
        StandbyForContinuity,
        /// <summary>
        /// Lent out status.
        /// </summary>
        [EnumMember(Value = "lent_out")]
        LentOut,
        /// <summary>
        /// In production status.
        /// </summary>
        [EnumMember(Value = "in_production")]
        InProduction,
        /// <summary>
        /// Undergoing maintenance status.
        /// </summary>
        [EnumMember(Value = "undergoing_maintenance")]
        UndergoingMaintenance,
        /// <summary>
        /// Broken down status.
        /// </summary>
        [EnumMember(Value = "broken_down")]
        BrokenDown,
        /// <summary>
        /// Being repaired status.
        /// </summary>
        [EnumMember(Value = "being_repaired")]
        BeingRepaired,
        /// <summary>
        /// Archived status.
        /// </summary>
        [EnumMember(Value = "archived")]
        Archived,
        /// <summary>
        /// To be removed status.
        /// </summary>
        [EnumMember(Value = "to_be_removed")]
        ToBeRemoved,
        /// <summary>
        /// Lost or stolen status.
        /// </summary>
        [EnumMember(Value = "lost_or_stolen")]
        LostOrStolen,
        /// <summary>
        /// Removed status.
        /// </summary>
        [EnumMember(Value = "removed")]
        Removed
    }

    #endregion

    #region Configuration item relations

    /// <summary>
    /// A 4me configuration item relation type.
    /// </summary>
    public enum ConfigurationitemRelationType
    {
        /// <summary>
        /// A parent relation.
        /// </summary>
        [EnumMember(Value = "parent")]
        Parent = 1,
        /// <summary>
        /// A child relation.
        /// </summary>
        [EnumMember(Value = "child")]
        Child,
        /// <summary>
        /// A network connection relation.
        /// </summary>
        [EnumMember(Value = "network_connection")]
        NetworkConnection,
        /// <summary>
        /// A redundancy relation.
        /// </summary>
        [EnumMember(Value = "redundancy")]
        Redundancy,
        /// <summary>
        /// A continuity relation.
        /// </summary>
        [EnumMember(Value = "continuity")]
        Continuity,
        /// <summary>
        /// A software dependency relation.
        /// </summary>
        [EnumMember(Value = "software_dependency")]
        SoftwareDependency
    }

    #endregion

    #region Contact

    /// <summary>
    /// A 4me contact type.
    /// </summary>
    public enum ContactType
    {
        /// <summary>
        /// A HipChat contact.
        /// </summary>
        [EnumMember(Value = "chat_hipchat")]
        ChatHipChat = 1,
        /// <summary>
        /// A Skype chat contact.
        /// </summary>
        [EnumMember(Value = "chat_skype")]
        ChatSkype,
        /// <summary>
        /// A Slack chat contact.
        /// </summary>
        [EnumMember(Value = "chat_slack")]
        ChatSlack,
        /// <summary>
        /// A work chat contact.
        /// </summary>
        [EnumMember(Value = "chat_workchat")]
        ChatWorkChat,
        /// <summary>
        /// A teams chat contact.
        /// </summary>
        [EnumMember(Value = "chat_teams")]
        ChatTeams,
        /// <summary>
        /// A fax contact.
        /// </summary>
        [EnumMember(Value = "fax")]
        Fax,
        /// <summary>
        /// A home phone contact.
        /// </summary>
        [EnumMember(Value = "home")]
        Home,
        /// <summary>
        /// A mobile phone contact.
        /// </summary>
        [EnumMember(Value = "mobile")]
        Mobile,
        /// <summary>
        /// A personal phone contact.
        /// </summary>
        [EnumMember(Value = "personal")]
        Personal,
        /// <summary>
        /// A work phone contact.
        /// </summary>
        [EnumMember(Value = "work")]
        Work,
        /// <summary>
        /// A general phone contact.
        /// </summary>
        [EnumMember(Value = "general")]
        General,
        /// <summary>
        /// A service desk phone contact.
        /// </summary>
        [EnumMember(Value = "service_desk")]
        ServiceDesk,
        /// <summary>
        /// A service desk fax contact.
        /// </summary>
        [EnumMember(Value = "service_desk_fax")]
        ServiceDeskFax
    }

    #endregion

    #region First line support agreement

    /// <summary>
    /// A 4me first line support agreement status.
    /// </summary>
    public enum FirstLineSupportAgreementStatus
    {
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        /// <summary>
        /// Scheduled for activation.
        /// </summary>
        [EnumMember(Value = "scheduled_for_activation")]
        Scheduled_for_activation,
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Expired.
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Invoice

    /// <summary>
    /// An 4me invoice depreciation method.
    /// </summary>
    public enum InvoiceDepreciationMethod
    {
        /// <summary>
        /// Not depreciated.
        /// </summary>
        [EnumMember(Value = "not_depreciated")]
        NotDepreciated = 1,
        /// <summary>
        /// Double declining balance.
        /// </summary>
        [EnumMember(Value = "double_declining_balance")]
        DoubleDecliningBalance,
        /// <summary>
        /// Reducing balance.
        /// </summary>
        [EnumMember(Value = "reducing_balance")]
        ReducingBalance,
        /// <summary>
        /// Straight line.
        /// </summary>
        [EnumMember(Value = "straight_line")]
        StraightLine,
        /// <summary>
        /// Sum of years digits.
        /// </summary>
        [EnumMember(Value = "sum_of_the_years_digits")]
        SumOfTheYearDigits
    }

    #endregion

    #region Knowledge article

    /// <summary>
    /// A 4me knowledge article status.
    /// </summary>
    public enum KnowledgeArticleStatus
    {
        /// <summary>
        /// Not validated.
        /// </summary>
        [EnumMember(Value = "not_validated")]
        NotValidated = 1,
        /// <summary>
        /// Work in progress.
        /// </summary>
        [EnumMember(Value = "work_in_progress")]
        WorkInProgress,
        /// <summary>
        /// Validated.
        /// </summary>
        [EnumMember(Value = "validated")]
        Validated,
        /// <summary>
        /// Archived.
        /// </summary>
        [EnumMember(Value = "archived")]
        Archived
    }

    #endregion

    #region Note

    /// <summary>
    /// A 4me note medium type.
    /// </summary>
    public enum NoteMedium
    {
        /// <summary>
        /// Default.
        /// </summary>
        [EnumMember(Value = "default")]
        Default = 1,
        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,
        /// <summary>
        /// Outbound email.
        /// </summary>
        [EnumMember(Value = "outbound_email")]
        OutboundEmail,
        /// <summary>
        /// System.
        /// </summary>
        [EnumMember(Value = "system")]
        System,
        /// <summary>
        /// Redacted.
        /// </summary>
        [EnumMember(Value = "redacted")]
        Redacted,
        /// <summary>
        /// Automation.
        /// </summary>
        [EnumMember(Value = "automation")]
        Automation
    }

    #endregion

    #region People

    /// <summary>
    /// A 4me people email notification preference.
    /// </summary>
    public enum PeopleEmailNotificationPreference
    {
        /// <summary>
        /// Always.
        /// </summary>
        [EnumMember(Value = "always")]
        Always = 1,
        /// <summary>
        /// Only when offline.
        /// </summary>
        [EnumMember(Value = "when_offline")]
        WhenOffline,
        /// <summary>
        /// Never.
        /// </summary>
        [EnumMember(Value = "never")]
        Never
    }

    /// <summary>
    /// A 4me people pop up notification preference.
    /// </summary>
    public enum PeoplePopupNotificationPreference
    {
        /// <summary>
        /// Always.
        /// </summary>
        [EnumMember(Value = "always")]
        Always = 1,
        /// <summary>
        /// Only when it is important.
        /// </summary>
        [EnumMember(Value = "important_only")]
        WhenOffline,
        /// <summary>
        /// Never.
        /// </summary>
        [EnumMember(Value = "never")]
        Never
    }

    #endregion

    #region Problem

    /// <summary>
    /// A 4me problem category.
    /// </summary>
    public enum ProblemCategory
    {
        /// <summary>
        /// Reactive problem.
        /// </summary>
        [EnumMember(Value = "reactive")]
        Reactive = 1,
        /// <summary>
        /// Proactive problem.
        /// </summary>
        [EnumMember(Value = "proactive")]
        Proactive
    }

    /// <summary>
    /// A 4me problem impact.
    /// </summary>
    public enum ProblemImpact
    {
        /// <summary>
        /// No impact.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    /// <summary>
    /// A 4me problem status.
    /// </summary>
    public enum ProblemStatus
    {
        /// <summary>
        /// A declined status.
        /// </summary>
        [EnumMember(Value = "declined")]
        Declined = 1,
        /// <summary>
        /// An assigned status.
        /// </summary>
        [EnumMember(Value = "assigned")]
        Assigned,
        /// <summary>
        /// An accepted status.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// An in progress status.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// A wait for status.
        /// </summary>
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        /// <summary>
        /// An analyzed status.
        /// </summary>
        [EnumMember(Value = "analyzed")]
        Analyzed,
        /// <summary>
        /// A change requested status.
        /// </summary>
        [EnumMember(Value = "change_requested")]
        ChangeRequested,
        /// <summary>
        /// A change pending status.
        /// </summary>
        [EnumMember(Value = "change_pending")]
        ChangePending,
        /// <summary>
        /// A project pending status.
        /// </summary>
        [EnumMember(Value = "project_pending")]
        ProjectPending,
        /// <summary>
        /// A progress halted status.
        /// </summary>
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        /// <summary>
        /// A solved status.
        /// </summary>
        [EnumMember(Value = "solved")]
        Solved,
        /// <summary>
        /// An on backlog status.
        /// </summary>
        [EnumMember(Value = "on_backlog")]
        OnBacklog
    }

    #endregion

    #region Product

    /// <summary>
    /// A 4me product depreciation method.
    /// </summary>
    public enum ProductDepreciationMethod
    {
        /// <summary>
        /// Not depreciated.
        /// </summary>
        [EnumMember(Value = "not_depreciated")]
        NotDepreciated = 1,
        /// <summary>
        /// Double Declining Balance.
        /// </summary>
        [EnumMember(Value = "double_declining_balance")]
        DoubleDecliningBalance,
        /// <summary>
        /// Reducing Balance (or Diminishing Value)
        /// </summary>
        [EnumMember(Value = "reducing_balance")]
        ReducingBalance,
        /// <summary>
        /// Straight Line (or Prime Cost)
        /// </summary>
        [EnumMember(Value = "straight_line")]
        StraightLine,
        /// <summary>
        /// Sum of the Year’s Digits
        /// </summary>
        [EnumMember(Value = "sum_of_the_years_digits")]
        SumOfTheYearsDigits,
    }

    /// <summary>
    /// A product rule set.
    /// </summary>
    public enum ProductRuleSet
    {
        /// <summary>
        /// A logical asset with financial data.
        /// </summary>
        [EnumMember(Value = "logical_asset_with_financial_data")]
        LogicalAssitWithFinancialData = 1,
        /// <summary>
        /// A logical asset without financial data.
        /// </summary>
        [EnumMember(Value = "logical_asset_without_financial_data")]
        LogicalAssetWithoutFinancialData,
        /// <summary>
        /// A physical asset.
        /// </summary>
        [EnumMember(Value = "physical_asset")]
        PhysicalAsset,
        /// <summary>
        /// A server.
        /// </summary>
        [EnumMember(Value = "server")]
        Server,
        /// <summary>
        /// A software.
        /// </summary>
        [EnumMember(Value = "software")]
        Software,
        /// <summary>
        /// A software distribution package.
        /// </summary>
        [EnumMember(Value = "software_distribution_package")]
        SoftwareDistributionPackage
    }

    #endregion

    #region Project

    /// <summary>
    /// A 4me project completion reason.
    /// </summary>
    public enum ProjectCompletionReason
    {
        /// <summary>
        /// Withdrawn.
        /// </summary>
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
        /// <summary>
        /// Rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Abandoned.
        /// </summary>
        [EnumMember(Value = "abandoned")]
        Abandoned,
        /// <summary>
        /// Partial.
        /// </summary>
        [EnumMember(Value = "partial")]
        Partial,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "complete")]
        Complete
    }

    /// <summary>
    /// A 4me project justification.
    /// </summary>
    public enum ProjectJustification
    {
        /// <summary>
        /// Compliance.
        /// </summary>
        [EnumMember(Value = "compliance")]
        Compliance = 1,
        /// <summary>
        /// Correction.
        /// </summary>
        [EnumMember(Value = "correction")]
        Correction,
        /// <summary>
        /// Expansion.
        /// </summary>
        [EnumMember(Value = "expansion")]
        Expansion,
        /// <summary>
        /// Improvement.
        /// </summary>
        [EnumMember(Value = "improvement")]
        Improvement,
        /// <summary>
        /// Maintenance.
        /// </summary>
        [EnumMember(Value = "maintenance")]
        Maintenance,
        /// <summary>
        /// Move.
        /// </summary>
        [EnumMember(Value = "move")]
        Move,
        /// <summary>
        /// Removal.
        /// </summary>
        [EnumMember(Value = "removal")]
        Removal,
        /// <summary>
        /// Replacement.
        /// </summary>
        [EnumMember(Value = "replacement")]
        Replacement
    }

    /// <summary>
    /// A 4me project status.
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// Registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// In progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Progress halted.
        /// </summary>
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region Project phase

    /// <summary>
    /// A 4me project phase status.
    /// </summary>
    public enum ProjectPhaseStatus
    {
        /// <summary>
        /// Project phase registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered,
        /// <summary>
        /// Project phase in progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Project phase completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region Project task

    /// <summary>
    /// A 4me project task category.
    /// </summary>
    public enum ProjectTaskCategory
    {
        /// <summary>
        /// Activity.
        /// </summary>
        [EnumMember(Value = "activity")]
        Activity = 1,
        /// <summary>
        /// Approval.
        /// </summary>
        [EnumMember(Value = "approval")]
        Approval,
        /// <summary>
        /// Milestone.
        /// </summary>
        [EnumMember(Value = "milestone")]
        Milestone
    }

    /// <summary>
    /// A 4me project task status.
    /// </summary>
    public enum ProjectTaskStatus
    {
        /// <summary>
        /// Project task registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// Project task assigned.
        /// </summary>
        [EnumMember(Value = "assigned")]
        Assigned,
        /// <summary>
        /// Project task accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// Project task in progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Project task waiting for.
        /// </summary>
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        /// <summary>
        /// Project task failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,
        /// <summary>
        /// Project task rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Project task completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
        /// <summary>
        /// Project task approved.
        /// </summary>
        [EnumMember(Value = "approved")]
        Approved,
        /// <summary>
        /// Project task canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region Release

    /// <summary>
    /// A 4me release completion reason.
    /// </summary>
    public enum ReleaseCompletionReason
    {
        /// <summary>
        /// Withdrawn.
        /// </summary>
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
        /// <summary>
        /// Rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Rolled back.
        /// </summary>
        [EnumMember(Value = "rolled_back")]
        Rolled_back,
        /// <summary>
        /// Failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,
        /// <summary>
        /// Partial.
        /// </summary>
        [EnumMember(Value = "partial")]
        Partial,
        /// <summary>
        /// Disruptive.
        /// </summary>
        [EnumMember(Value = "disruptive")]
        Disruptive,
        /// <summary>
        /// Complete.
        /// </summary>
        [EnumMember(Value = "complete")]
        Complete
    }

    /// <summary>
    /// A 4me release impact.
    /// </summary>
    public enum ReleaseImpact
    {
        /// <summary>
        /// No impact.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    /// <summary>
    /// A 4me release status.
    /// </summary>
    public enum ReleaseStatus
    {
        /// <summary>
        /// Registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// Risk and impact.
        /// </summary>
        [EnumMember(Value = "risk_and_impact")]
        RiskAndimpact,
        /// <summary>
        /// Approval
        /// </summary>
        [EnumMember(Value = "approval")]
        Approval,
        /// <summary>
        /// Implementation
        /// </summary>
        [EnumMember(Value = "implementation")]
        Implementation,
        /// <summary>
        /// Progress halted.
        /// </summary>
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        /// <summary>
        /// Completed
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion

    #region Requests
    /// <summary>
    /// A 4me request category.
    /// </summary>
    public enum RequestCategory
    {
        /// <summary>
        /// An incident.
        /// </summary>
        [EnumMember(Value = "incident")]
        Incident = 1,
        /// <summary>
        /// A request for change.
        /// </summary>
        [EnumMember(Value = "rfc")]
        RFC,
        /// <summary>
        /// A request for information.
        /// </summary>
        [EnumMember(Value = "rfi")]
        RFI,
        /// <summary>
        /// A reservation.
        /// </summary>
        [EnumMember(Value = "reservation")]
        Reservation,
        /// <summary>
        /// An order.
        /// </summary>
        [EnumMember(Value = "order")]
        Order,
        /// <summary>
        /// An order fulfillment.
        /// </summary>
        [EnumMember(Value = "fulfillment")]
        Fulfillment,
        /// <summary>
        /// A complaint.
        /// </summary>
        [EnumMember(Value = "complaint")]
        Complaint,
        /// <summary>
        /// A compliment.
        /// </summary>
        [EnumMember(Value = "compliment")]
        Compliment,
        /// <summary>
        /// Something else.
        /// </summary>
        [EnumMember(Value = "other")]
        Other
    }

    /// <summary>
    /// A 4me request completion reason.
    /// </summary>
    public enum RequestCompletionReason
    {
        /// <summary>
        /// Solved.
        /// </summary>
        [EnumMember(Value = "solved")]
        Solved = 1,
        /// <summary>
        /// Workaround.
        /// </summary>
        [EnumMember(Value = "workaround")]
        Workaround,
        /// <summary>
        /// Gone.
        /// </summary>
        [EnumMember(Value = "gone")]
        Gone,
        /// <summary>
        /// Withdrawn.
        /// </summary>
        [EnumMember(Value = "withdrawn")]
        Withdrawn,
        /// <summary>
        /// Conflict.
        /// </summary>
        [EnumMember(Value = "conflict")]
        Conflict,
        /// <summary>
        /// Unsolvable.
        /// </summary>
        [EnumMember(Value = "unsolvable")]
        Unsolvable,
        /// <summary>
        /// Duplicate.
        /// </summary>
        [EnumMember(Value = "duplicate")]
        Duplicate
    }

    /// <summary>
    /// A 4me request impact type.
    /// </summary>
    public enum RequestImpact
    {
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 1,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    /// <summary>
    /// A 4me request grouping type.
    /// </summary>
    public enum RequestGroupingType
    {
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Group.
        /// </summary>
        [EnumMember(Value = "group")]
        Group,
        /// <summary>
        /// Grouped.
        /// </summary>
        [EnumMember(Value = "grouped")]
        Grouped
    }

    /// <summary>
    /// A 4me request major incident status.
    /// </summary>
    public enum RequestMajorIncidentStatus
    {
        /// <summary>
        /// Proposed.
        /// </summary>
        [EnumMember(Value = "proposed")]
        Proposed = 1,
        /// <summary>
        /// Rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// Resolved.
        /// </summary>
        [EnumMember(Value = "resolved")]
        Resolved,
        /// <summary>
        /// Canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled
    }

    /// <summary>
    /// A request satisfaction type.
    /// </summary>
    public enum RequestSatisfaction
    {
        /// <summary>
        /// Dissatisfied.
        /// </summary>
        [EnumMember(Value = "dissatisfied")]
        Dissatisfied = 1,
        /// <summary>
        /// Satisfied.
        /// </summary>
        [EnumMember(Value = "satisfied")]
        Satisfied
    }

    /// <summary>
    /// A 4me request status.
    /// </summary>
    public enum RequestStatus
    {
        /// <summary>
        /// Declined.
        /// </summary>
        [EnumMember(Value = "declined")]
        Declined = 1,
        /// <summary>
        /// Assigned.
        /// </summary>
        [EnumMember(Value = "assigned")]
        Assigned,
        /// <summary>
        /// Accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// Change pending.
        /// </summary>
        [Obsolete("To continue using the id change_pending in the REST API, GraphQL API, Export API and Webhooks API, enable the account setting “Use deprecated change_pending status in API responses”.")]
        [EnumMember(Value = "change_pending")]
        ChangePending,
        /// <summary>
        /// In progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Waiting for.
        /// </summary>
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        /// <summary>
        /// Waiting for customer.
        /// </summary>
        [EnumMember(Value = "waiting_for_customer")]
        WaitingForCustomer,
        /// <summary>
        /// Workflow pending.
        /// </summary>
        [EnumMember(Value = "workflow_pending")]
        WorkflowPending,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
        /// <summary>
        /// On back log.
        /// </summary>
        [EnumMember(Value = "on_backlog")]
        OnBacklog,
        /// <summary>
        /// Reservation pending.
        /// </summary>
        [EnumMember(Value = "reservation_pending")]
        ReservationPending,
        /// <summary>
        /// Project pending.
        /// </summary>
        [EnumMember(Value = "project_pending")]
        ProjectPending
    }

    #endregion

    #region Reservation

    /// <summary>
    /// A 4me reservation status.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// Assigned.
        /// </summary>
        [EnumMember(Value = "assigned")]
        Assigned = 1,
        /// <summary>
        /// Provisional.
        /// </summary>
        [EnumMember(Value = "provisional")]
        Provisional,
        /// <summary>
        /// Pending.
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,
        /// <summary>
        /// Confirmed.
        /// </summary>
        [EnumMember(Value = "confirmed")]
        Confirmed,
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared,
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled,
        /// <summary>
        /// Ended.
        /// </summary>
        [EnumMember(Value = "ended")]
        Ended,
    }

    #endregion

    #region Reservation offering

    /// <summary>
    /// A 4me reservation offering status.
    /// </summary>
    public enum ReservationOfferingStatus
    {
        /// <summary>
        /// Pending.
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending = 1,
        /// <summary>
        /// Confirmed.
        /// </summary>
        [EnumMember(Value = "confirmed")]
        Confirmed
    }

    /// <summary>
    /// A 4me reservation offering filter.
    /// </summary>
    [Flags]
    public enum ReserverationOfferingFilters
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// Account.
        /// </summary>
        [EnumMember(Value = "account")]
        Account = 0x00000001,
        /// <summary>
        /// Alternate name.
        /// </summary>
        [EnumMember(Value = "alternate_name")]
        AlternateName = 0x00000002,
        /// <summary>
        /// Asset identifier.
        /// </summary>
        [EnumMember(Value = "assetID")]
        AssetID = 0x00000004,
        /// <summary>
        /// Contract.
        /// </summary>
        [EnumMember(Value = "contract")]
        Contract = 0x00000008,
        /// <summary>
        /// Created at.
        /// </summary>
        [EnumMember(Value = "created_at")]
        CreatedAt = 0x00000010,
        /// <summary>
        /// Financial owner.
        /// </summary>
        [EnumMember(Value = "financial_owner")]
        FinancialOwner = 0x00000020,
        /// <summary>
        /// In use since.
        /// </summary>
        [EnumMember(Value = "in_use_since")]
        InUseSince = 0x00000040,
        /// <summary>
        /// License expiry date.
        /// </summary>
        [EnumMember(Value = "license_expiry_date")]
        LicenseExpiryDate = 0x00000080,
        /// <summary>
        /// Location.
        /// </summary>
        [EnumMember(Value = "location")]
        Location = 0x00000100,
        /// <summary>
        /// Product.
        /// </summary>
        [EnumMember(Value = "product")]
        Product = 0x00000200,
        /// <summary>
        /// Product brand.
        /// </summary>
        [EnumMember(Value = "product_brand")]
        ProductBrand = 0x00000400,
        /// <summary>
        /// Product category.
        /// </summary>
        [EnumMember(Value = "product_category")]
        ProductCategory = 0x00000800,
        /// <summary>
        /// Product model.
        /// </summary>
        [EnumMember(Value = "product_model")]
        ProductModel = 0x00001000,
        /// <summary>
        /// Rule set.
        /// </summary>
        [EnumMember(Value = "rule_set")]
        RuleSet = 0x00002000,
        /// <summary>
        /// Serial number.
        /// </summary>
        [EnumMember(Value = "serial_nr")]
        SerialNumber = 0x00004000,
        /// <summary>
        /// Service.
        /// </summary>
        [EnumMember(Value = "service")]
        Service = 0x00008000,
        /// <summary>
        /// Service instance.
        /// </summary>
        [EnumMember(Value = "service_instance")]
        ServiceInstance = 0x00010000,
        /// <summary>
        /// Service owner.
        /// </summary>
        [EnumMember(Value = "service_owner")]
        ServiceOwner = 0x00020000,
        /// <summary>
        /// Site.
        /// </summary>
        [EnumMember(Value = "site")]
        Site = 0x00040000,
        /// <summary>
        /// Source.
        /// </summary>
        [EnumMember(Value = "source")]
        Source = 0x00080000,
        /// <summary>
        /// Status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status = 0x00100000,
        /// <summary>
        /// Supplier.
        /// </summary>
        [EnumMember(Value = "supplier")]
        Supplier = 0x00200000,
        /// <summary>
        /// Support account.
        /// </summary>
        [EnumMember(Value = "support_account")]
        SupportAccount = 0x00400000,
        /// <summary>
        /// Support team.
        /// </summary>
        [EnumMember(Value = "support_team")]
        SupportTeam = 0x00800000,
        /// <summary>
        /// System identifier.
        /// </summary>
        [EnumMember(Value = "systemID")]
        SystemID = 0x01000000,
        /// <summary>
        /// Updated at.
        /// </summary>
        [EnumMember(Value = "updated_at")]
        UpdatedAt = 0x02000000,
        /// <summary>
        /// User.
        /// </summary>
        [EnumMember(Value = "user")]
        User = 0x04000000,
        /// <summary>
        /// User organization.
        /// </summary>
        [EnumMember(Value = "user_organization")]
        UserOrganization = 0x08000000,
        /// <summary>
        /// Warranty expiry date.
        /// </summary>
        [EnumMember(Value = "warranty_expiry_date")]
        WarrantyExpiryDate = 0x10000000
    }

    #endregion

    #region Risk

    /// <summary>
    /// A 4me risk closure reason.
    /// </summary>
    public enum RiskClosureReason
    {
        /// <summary>
        /// Eliminated.
        /// </summary>
        [EnumMember(Value = "eliminated")]
        Eliminated = 1,
        /// <summary>
        /// Accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// Mitigated.
        /// </summary>
        [EnumMember(Value = "mitigated")]
        Mitigated,
        /// <summary>
        /// Transferred.
        /// </summary>
        [EnumMember(Value = "transferred")]
        Transferred,
        /// <summary>
        /// No risk.
        /// </summary>
        [EnumMember(Value = "no_risk")]
        NoRisk
    }

    /// <summary>
    /// A 4me risk status.
    /// </summary>
    public enum RiskStatus
    {
        /// <summary>
        /// Anticipated.
        /// </summary>
        [EnumMember(Value = "anticipated")]
        Anticipated = 1,
        /// <summary>
        /// Materialized.
        /// </summary>
        [EnumMember(Value = "materialized")]
        Materialized,
        /// <summary>
        /// Closed.
        /// </summary>
        [EnumMember(Value = "closed")]
        Closed
    }

    #endregion

    #region Service

    /// <summary>
    /// A 4me service impact.
    /// </summary>
    public enum ServiceImpact
    {
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 1,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Service instance

    /// <summary>
    /// A 4me service instance status.
    /// </summary>
    public enum ServiceInstanceStatus
    {
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        /// <summary>
        /// In production.
        /// </summary>
        [EnumMember(Value = "in_production")]
        InProduction,
        /// <summary>
        /// Discontinued.
        /// </summary>
        [EnumMember(Value = "discontinued")]
        Discontinued
    }

    /// <summary>
    /// A 4me service instance impact.
    /// </summary>
    public enum ServiceInstanceImpact
    {
        /// <summary>
        /// Low impact.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 1,
        /// <summary>
        /// Medium impact.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High impact.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top impact.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    #endregion

    #region Service level agreement

    /// <summary>
    /// A 4me service level coverage.
    /// </summary>
    public enum ServiceLevelCoverage
    {
        /// <summary>
        /// Customer account.
        /// </summary>
        [EnumMember(Value = "customer_account")]
        CustomerAccount,
        /// <summary>
        /// Organizations and descendants.
        /// </summary>
        [EnumMember(Value = "organizations_and_descendants")]
        OrganizationsAndDescendants,
        /// <summary>
        /// Organizations.
        /// </summary>
        [EnumMember(Value = "organizations")]
        Organizations,
        /// <summary>
        /// Sites.
        /// </summary>
        [EnumMember(Value = "sites")]
        Sites,
        /// <summary>
        /// Organization and sites.
        /// </summary>
        [EnumMember(Value = "organizations_and_sites")]
        OrganizationsAndSites,
        /// <summary>
        /// People.
        /// </summary>
        [EnumMember(Value = "people")]
        People,
        /// <summary>
        /// Configuration items and services instances.
        /// </summary>
        [EnumMember(Value = "cis_of_service_instance")]
        ConfigurationItemsAndServiceInstances,
        /// <summary>
        /// Service instances.
        /// </summary>
        [EnumMember(Value = "service_instances")]
        ServiceInstances,
        /// <summary>
        /// Skill pools.
        /// </summary>
        [EnumMember(Value = "skill_pools")]
        SkillPools
    }

    /// <summary>
    /// A 4me service level agreement status.
    /// </summary>
    public enum ServiceLevelAgreementStatus
    {
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        /// <summary>
        /// Scheduled for activation.
        /// </summary>
        [EnumMember(Value = "scheduled_for_activation")]
        ScheduledForActivation,
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Expired.
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired
    }

    #endregion

    #region Service offering

    /// <summary>
    /// A 4me service offering frequency.
    /// </summary>
    public enum ServiceOfferingFrequency
    {
        /// <summary>
        /// Daily.
        /// </summary>
        [EnumMember(Value = "daily")]
        Daily = 1,
        /// <summary>
        /// Weekly.
        /// </summary>
        [EnumMember(Value = "weekly")]
        Weekly,
        /// <summary>
        /// Once every two weeks.
        /// </summary>
        [EnumMember(Value = "once_every_2_weeks")]
        OnceEvery2Weeks,
        /// <summary>
        /// Monthly.
        /// </summary>
        [EnumMember(Value = "monthly")]
        Monthly,
        /// <summary>
        /// Once very 2 months.
        /// </summary>
        [EnumMember(Value = "once_every_2_months")]
        OnceEvery2Months,
        /// <summary>
        /// Quarterly.
        /// </summary>
        [EnumMember(Value = "quarterly")]
        Quarterly,
        /// <summary>
        /// Once every 6 months.
        /// </summary>
        [EnumMember(Value = "once_every_6_months")]
        OnceEvery6Months,
        /// <summary>
        /// Yearly.
        /// </summary>
        [EnumMember(Value = "yearly")]
        Yearly,
        /// <summary>
        /// Once very two years.
        /// </summary>
        [EnumMember(Value = "once_every_2_years")]
        OnceEvery2Years,
        /// <summary>
        /// No commitment.
        /// </summary>
        [EnumMember(Value = "no_commitment")]
        NoCommitment
    }

    /// <summary>
    /// A 4me service offering status.
    /// </summary>
    public enum ServiceOfferingStatus
    {
        /// <summary>
        /// Planned.
        /// </summary>
        [EnumMember(Value = "planned")]
        Planned = 1,
        /// <summary>
        /// Unpublished.
        /// </summary>
        [EnumMember(Value = "unpublished")]
        Unpublished,
        /// <summary>
        /// Available.
        /// </summary>
        [EnumMember(Value = "available")]
        Available,
        /// <summary>
        /// Temporarily unavailable.
        /// </summary>
        [EnumMember(Value = "temporarily_unavailable")]
        TemporarilyUnavailable,
        /// <summary>
        /// Discontinued.
        /// </summary>
        [EnumMember(Value = "discontinued")]
        Discontinued
    }

    #endregion

    #region Shop

    /// <summary>
    /// A 4me shop recurring period.
    /// </summary>
    public enum ShopRecurringPeriod
    {
        /// <summary>
        /// Monthly.
        /// </summary>
        [EnumMember(Value = "monthly")]
        Monthly = 1,
        /// <summary>
        /// Yearly.
        /// </summary>
        [EnumMember(Value = "yearly")]
        Yearly
    }

    /// <summary>
    /// A 4me shop order line status
    /// </summary>
    public enum ShopOrderLineStatus
    {
        /// <summary>
        /// In cart.
        /// </summary>
        [EnumMember(Value = "in_cart")]
        InCart = 1,
        /// <summary>
        /// Workflow pending.
        /// </summary>
        [EnumMember(Value = "workflow_pending")]
        WorkflowPending,
        /// <summary>
        /// Fulfillment pending.
        /// </summary>
        [EnumMember(Value = "fulfillment_pending")]
        FulfillmentPending,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
        /// <summary>
        /// Canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region Sprint

    /// <summary>
    /// A 4me survey question type.
    /// </summary>
    public enum SprintStatus
    {
        /// <summary>
        /// Registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
    }

    #endregion

    #region Survey

    /// <summary>
    /// A 4me survey question type.
    /// </summary>
    public enum SurveyQuestionType
    {
        /// <summary>
        /// Star rating.
        /// </summary>
        [EnumMember(Value = "star_rating")]
        StarRating = 1,
        /// <summary>
        /// Text.
        /// </summary>
        [EnumMember(Value = "text")]
        Text
    }

    #endregion

    #region Task

    /// <summary>
    /// A 4me task category.
    /// </summary>
    public enum TaskCategory
    {
        /// <summary>
        /// Risk and impact.
        /// </summary>
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact = 1,
        /// <summary>
        /// Approval.
        /// </summary>
        [EnumMember(Value = "approval")]
        Approval,
        /// <summary>
        /// Implementation.
        /// </summary>
        [EnumMember(Value = "implementation")]
        Implementation,
        /// <summary>
        /// Fulfillment placeholder.
        /// </summary>
        [EnumMember(Value = "fulfillment_placeholder")]
        FulfillmentPlaceholder
    }

    /// <summary>
    /// A 4me task impact.
    /// </summary>
    public enum TaskImpact
    {
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Low.
        /// </summary>
        [EnumMember(Value = "low")]
        Low,
        /// <summary>
        /// Medium.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    /// <summary>
    /// A 4me task status.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Task registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// Task declined.
        /// </summary>
        [EnumMember(Value = "declined")]
        Declined,
        /// <summary>
        /// Task assigned.
        /// </summary>
        [EnumMember(Value = "assigned")]
        Assigned,
        /// <summary>
        /// Task accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,
        /// <summary>
        /// Task in progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Task waiting for.
        /// </summary>
        [EnumMember(Value = "waiting_for")]
        WaitingFor,
        /// <summary>
        /// Task waiting for customer.
        /// </summary>
        [EnumMember(Value = "waiting_for_customer")]
        WaitingForCustomer,
        /// <summary>
        /// Task request pending.
        /// </summary>
        [EnumMember(Value = "request_pending")]
        RequestPending,
        /// <summary>
        /// Task failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,
        /// <summary>
        /// Task rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Task completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
        /// <summary>
        /// Task approved.
        /// </summary>
        [EnumMember(Value = "approved")]
        Approved,
        /// <summary>
        /// Task canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled
    }

    #endregion

    #region Time allocation

    /// <summary>
    /// A 4me time allocation customer category.
    /// </summary>
    public enum TimeAllocationCustomerCategory
    {
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Selected.
        /// </summary>
        [EnumMember(Value = "selected")]
        Selected,
        /// <summary>
        /// Any.
        /// </summary>
        [EnumMember(Value = "any")]
        Any
    }

    /// <summary>
    /// A 4me time allocation description category.
    /// </summary>
    public enum TimeAllocationDescriptionCategory
    {
        /// <summary>
        /// Hidden.
        /// </summary>
        [EnumMember(Value = "hidden")]
        Hidden = 1,
        /// <summary>
        /// Optional.
        /// </summary>
        [EnumMember(Value = "optional")]
        Optional,
        /// <summary>
        /// Required.
        /// </summary>
        [EnumMember(Value = "required")]
        Required
    }

    /// <summary>
    /// A 4me time allocation service category.
    /// </summary>
    public enum TimeAllocationServiceCategory
    {
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Select.
        /// </summary>
        [EnumMember(Value = "selected")]
        Selected,
        /// <summary>
        /// Any.
        /// </summary>
        [EnumMember(Value = "any")]
        Any
    }

    #endregion

    #region Timesheet settings

    /// <summary>
    /// A 4me timesheet percentage increment.
    /// </summary>
    public enum TimesheetPercentageIncrement
    {
        /// <summary>
        /// Twelve and half.
        /// </summary>
        [EnumMember(Value = "12.5")]
        TwelveAndHalf = 1,
        /// <summary>
        /// Twenty five.
        /// </summary>
        [EnumMember(Value = "25")]
        TwentyFive,
        /// <summary>
        /// Fifty.
        /// </summary>
        [EnumMember(Value = "50")]
        Fifty,
        /// <summary>
        /// Hundred.
        /// </summary>
        [EnumMember(Value = "100")]
        Hundred
    }

    /// <summary>
    /// A 4me timesheet unit.
    /// </summary>
    public enum TimesheetUnit
    {
        /// <summary>
        /// Hours and minutes.
        /// </summary>
        [EnumMember(Value = "hours_and_minutes")]
        HoursAndMinutes = 1,
        /// <summary>
        /// Percentage of work day.
        /// </summary>
        [EnumMember(Value = "percentage_of_workday")]
        PercentageOfWorkday
    }

    #endregion

    #region UI Extension
    
    /// <summary>
    /// A 4me user interface extension category.
    /// </summary>
    public enum UIExtensionCategory
    {
        /// <summary>
        /// Request template.
        /// </summary>
        [EnumMember(Value = "request_template")]
        RequestTemplate = 1,
        /// <summary>
        /// Problem.
        /// </summary>
        [EnumMember(Value = "problem")]
        Problem,
        /// <summary>
        /// Release.
        /// </summary>
        [EnumMember(Value = "release")]
        Release,
        /// <summary>
        /// Workflow template.
        /// </summary>
        [EnumMember(Value = "workflow_template")]
        WorkflowTemplate,
        /// <summary>
        /// Task template.
        /// </summary>
        [EnumMember(Value = "task_template")]
        TaskTemplate,
        /// <summary>
        /// Project.
        /// </summary>
        [EnumMember(Value = "project")]
        Project,
        /// <summary>
        /// Project task template.
        /// </summary>
        [EnumMember(Value = "project_task_template")]
        ProjectTaskTemplate,
        /// <summary>
        /// Service.
        /// </summary>
        [EnumMember(Value = "service")]
        Service,
        /// <summary>
        /// Service Instance.
        /// </summary>
        [EnumMember(Value = "service_instance")]
        ServiceInstance,
        /// <summary>
        /// Product.
        /// </summary>
        [EnumMember(Value = "product")]
        Product,
        /// <summary>
        /// Product category.
        /// </summary>
        [EnumMember(Value = "product_category")]
        ProductCategory,
        /// <summary>
        /// Contract.
        /// </summary>
        [EnumMember(Value = "contract")]
        Contract,
        /// <summary>
        /// Organization.
        /// </summary>
        [EnumMember(Value = "organization")]
        Organization,
        /// <summary>
        /// Person.
        /// </summary>
        [EnumMember(Value = "person")]
        Person,
        /// <summary>
        /// Site.
        /// </summary>
        [EnumMember(Value = "site")]
        Site,
        /// <summary>
        /// Risk.
        /// </summary>
        [EnumMember(Value = "risk")]
        Risk,
        /// <summary>
        /// Custom collection.
        /// </summary>
        [EnumMember(Value = "custom_collection")]
        CustomCollection,
        /// <summary>
        /// SCIM user.
        /// </summary>
        [EnumMember(Value = "scim_user")]
        ScimUser,
        /// <summary>
        /// App offering.
        /// </summary>
        [EnumMember(Value = "app_offering")]
        AppOffering
    }

    /// <summary>
    /// A 4me user interface version status.
    /// </summary>
    public enum UIExtensionVersionStatus
    {
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_prepared")]
        BeingPrepared = 1,
        /// <summary>
        /// Active.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Archived.
        /// </summary>
        [EnumMember(Value = "archived")]
        Archived
    }

    #endregion

    #region Workflows

    /// <summary>
    /// A 4me workflow category.
    /// </summary>
    public enum WorkflowCategory
    {
        /// <summary>
        /// Standard - Approved Workflow Template Was Used.
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard = 1,
        /// <summary>
        /// Non-Standard - Approved Workflow Template Not Available.
        /// </summary>
        [EnumMember(Value = "non_standard")]
        NonStandard,
        /// <summary>
        /// Standard - Approved Workflow Template Was Used.
        /// </summary>
        [EnumMember(Value = "emergency")]
        Emergency,
        /// <summary>
        /// Order - Organization Order Workflow.
        /// </summary>
        [EnumMember(Value = "order")]
        Order
    }

    /// <summary>
    /// A 4me workflow completion reason.
    /// </summary>
    public enum WorkflowCompletionReason
    {
        /// <summary>
        /// Workflow withdrawn.
        /// </summary>
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 1,
        /// <summary>
        /// Workflow rejected.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// Workflow rolled back.
        /// </summary>
        [EnumMember(Value = "rolled_back")]
        RolledBack,
        /// <summary>
        /// Workflow failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,
        /// <summary>
        /// Workflow partial.
        /// </summary>
        [EnumMember(Value = "partial")]
        Partial,
        /// <summary>
        /// Workflow disruptive.
        /// </summary>
        [EnumMember(Value = "disruptive")]
        Disruptive,
        /// <summary>
        /// Workflow completed.
        /// </summary>
        [EnumMember(Value = "complete")]
        Completed
    }

    /// <summary>
    /// A 4me workflow impact.
    /// </summary>
    public enum WorkflowImpact
    {
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,
        /// <summary>
        /// Low.
        /// </summary>
        [EnumMember(Value = "low")]
        Low,
        /// <summary>
        /// Medium.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>
        /// High.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>
        /// Top.
        /// </summary>
        [EnumMember(Value = "top")]
        Top
    }

    /// <summary>
    /// A 4me workflow justification.
    /// </summary>
    public enum WorkflowJustification
    {
        /// <summary>
        /// Compliance.
        /// </summary>
        [EnumMember(Value = "compliance")]
        Compliance = 1,
        /// <summary>
        /// Correction.
        /// </summary>
        [EnumMember(Value = "correction")]
        Correction,
        /// <summary>
        /// Expansion.
        /// </summary>
        [EnumMember(Value = "expansion")]
        Expansion,
        /// <summary>
        /// Improvement.
        /// </summary>
        [EnumMember(Value = "improvement")]
        Improvement,
        /// <summary>
        /// Maintenance.
        /// </summary>
        [EnumMember(Value = "maintenance")]
        Maintenance,
        /// <summary>
        /// Move.
        /// </summary>
        [EnumMember(Value = "move")]
        Move,
        /// <summary>
        /// Removal.
        /// </summary>
        [EnumMember(Value = "removal")]
        Removal,
        /// <summary>
        /// Replacement.
        /// </summary>
        [EnumMember(Value = "replacement")]
        Replacement
    }

    /// <summary>
    /// A 4me workflow phase status.
    /// </summary>
    public enum WorkflowPhaseStatus
    {
        /// <summary>
        /// Workflow registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 1,
        /// <summary>
        /// Workflow in progress.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress,
        /// <summary>
        /// Workflow completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,
    }

    /// <summary>
    /// A 4me workflow status.
    /// </summary>
    public enum WorkflowStatus
    {
        /// <summary>
        /// Being prepared.
        /// </summary>
        [EnumMember(Value = "being_created")]
        BeingCreated = 1,
        /// <summary>
        /// Registered.
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered,
        /// <summary>
        /// Risk and impact.
        /// </summary>
        [EnumMember(Value = "risk_and_impact")]
        RiskAndImpact,
        /// <summary>
        /// Approval.
        /// </summary>
        [EnumMember(Value = "approval")]
        Approval,
        /// <summary>
        /// Implementation.
        /// </summary>
        [EnumMember(Value = "implementation")]
        Implementation,
        /// <summary>
        /// Progress halted.
        /// </summary>
        [EnumMember(Value = "progress_halted")]
        ProgressHalted,
        /// <summary>
        /// Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed
    }

    #endregion
}
