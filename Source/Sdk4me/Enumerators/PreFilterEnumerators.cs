namespace Sdk4me
{
    /// <summary>
    /// The default predefined filter value.
    /// </summary>
    public enum PredefinedDefaultFilter
    {
        /// <summary>
        /// No predefined filter.
        /// </summary>
        None
    }

    /// <summary>
    /// Predefined enable and disable filters.
    /// </summary>
    public enum PredefinedEnabledDisabledFilter
    {
        /// <summary>
        /// All enabled items.
        /// </summary>
        Enabled,
        /// <summary>
        /// All disabled items.
        /// </summary>
        Disabled
    }

    /// <summary>
    /// Predefined open and closed filters.
    /// </summary>
    public enum PredefinedOpenClosedFilter
    {
        /// <summary>
        /// All open items.
        /// </summary>
        Open,
        /// <summary>
        /// All closed items.
        /// </summary>
        Closed
    }

    /// <summary>
    /// Predefined active and inactive filters.
    /// </summary>
    public enum PredefinedActiveInactiveFilter
    {
        /// <summary>
        /// All active items.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive items.
        /// </summary>
        Inactive
    }

    /// <summary>
    /// Predefined workflow filter.
    /// </summary>
    public enum PredefinedWorkflowFilter
    {
        /// <summary>
        /// All completed changes.
        /// </summary>
        Completed,
        /// <summary>
        /// All open changes.
        /// </summary>
        Open,
        /// <summary>
        /// All changes where the manager is the API user.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined workflow problem filter.
    /// </summary>
    public enum PredefinedWorkflowProblemFilter
    {
        /// <summary>
        /// All active problems.
        /// </summary>
        Active,
        /// <summary>
        /// All known error problems.
        /// </summary>
        KnownErrors,
        /// <summary>
        /// All known error problems.
        /// </summary>
        ProgressHalted,
        /// <summary>
        /// All progress halted problems.
        /// </summary>
        Solved,
    }

    /// <summary>
    /// Predefined configuration item filter.
    /// </summary>
    public enum PredefinedConfigurationItemFilter
    {
        /// <summary>
        /// All active configuration items.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive configuration items.
        /// </summary>
        Inactive,
        /// <summary>
        /// All configuration items which support team is one of the teams that the API user is a member of.
        /// </summary>
        SupportedByMyTeams
    }

    /// <summary>
    ///  Predefined configuration item user filter.
    /// </summary>
    public enum PredefinedConfigurationItemUserFilter
    {
        /// <summary>
        /// All disabled users.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled users.
        /// </summary>
        Enabled,
        /// <summary>
        /// All internal users.
        /// </summary>
        Internal
    }

    /// <summary>
    /// Predefined knowledge article item filter.
    /// </summary>
    public enum PredefinedKnowledgeArticleFilter
    {
        /// <summary>
        /// All active knowledge articles.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive knowledge articles.
        /// </summary>
        Inactive,
        /// <summary>
        /// All knowledge articles that are linked to a service for which the API user is the knowledge manager.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined organization filter.
    /// </summary>
    public enum PredefinedOrganizationFilter
    {
        /// <summary>
        /// All disabled organizations.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled organizations.
        /// </summary>
        Enabled,
        /// <summary>
        /// All internal organizations.
        /// </summary>
        External,
        /// <summary>
        /// All external organizations.
        /// </summary>
        Internal,
        /// <summary>
        /// All organizations registered in the directory account of the support domain account from which the data is requested.
        /// </summary>
        Directory,
        /// <summary>
        /// All organizations registered in the account from which the data is requested.
        /// </summary>
        SupportDomain,
        /// <summary>
        /// All organizations which manager or substitute is the API user.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined open or completed filter.
    /// </summary>
    public enum PredefinedOpenCompletedFilter
    {
        /// <summary>
        /// All open out of office periods.
        /// </summary>
        Open,
        /// <summary>
        /// All completed out of office periods.
        /// </summary>
        Completed
    }

    /// <summary>
    /// Predefined people filter.
    /// </summary>
    public enum PredefinedPeopleFilter
    {
        /// <summary>
        /// All disabled people.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled people.
        /// </summary>
        Enabled,
        /// <summary>
        /// All internal people.
        /// </summary>
        Internal,
        /// <summary>
        /// All people registered in the directory account of the support domain account from which the data is requested.
        /// </summary>
        Directory,
        /// <summary>
        /// All people registered in the account from which the data is requested (and not the related directory account).
        /// </summary>
        SupportDomain
    }

    /// <summary>
    /// Predefined problem filter.
    /// </summary>
    public enum PredefinedProblemFilter
    {
        /// <summary>
        /// All active problems.
        /// </summary>
        Active,
        /// <summary>
        /// All known_errors problems.
        /// </summary>
        KnownErrors,
        /// <summary>
        /// All progress_halted problems.
        /// </summary>
        ProgressHalted,
        /// <summary>
        /// All solved problems.
        /// </summary>
        Solved,
        /// <summary>
        /// All problems which manager is the API user.
        /// </summary>
        ManagedByMe,
        /// <summary>
        /// All problems that are assigned to one of the teams that the API user is a member of.
        /// </summary>
        AssignedToMyTeam,
        /// <summary>
        /// All problems that are assigned to the API user.
        /// </summary>
        AssignedToMe
    }

    /// <summary>
    /// Predefined product filter.
    /// </summary>
    public enum PredefinedProductFilter
    {
        /// <summary>
        /// All disabled products.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled products.
        /// </summary>
        Enabled,
        /// <summary>
        /// All products which support team is one of the teams that the API user is a member of.
        /// </summary>
        SupportedByMyTeams
    }

    /// <summary>
    /// Predefined project filter.
    /// </summary>
    public enum PredefinedProjectFilter
    {
        /// <summary>
        /// All completed projects.
        /// </summary>
        Completed,
        /// <summary>
        /// All open projects.
        /// </summary>
        Open,
        /// <summary>
        /// All projects which manager is the API user.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined project task filter.
    /// </summary>
    public enum PredefinedProjectTaskFilter
    {
        /// <summary>
        /// All finished project tasks.
        /// </summary>
        Finished,
        /// <summary>
        /// All open project tasks.
        /// </summary>
        Open,
        /// <summary>
        /// All project tasks which manager is the API user.
        /// </summary>
        ManagedByMe,
        /// <summary>
        /// All project tasks that are assigned to the API user.
        /// </summary>
        AssignedToMe,
        /// <summary>
        /// All project tasks that are assigned to the API user and which status is 'Assigned', 'Accepted', 'In Progress' or 'Waiting for...'.
        /// </summary>
        OpenToMe
    }

    /// <summary>
    /// Predefined release filter.
    /// </summary>
    public enum PredefinedReleaseFilter
    {
        /// <summary>
        /// All completed releases.
        /// </summary>
        Completed,
        /// <summary>
        /// All open releases.
        /// </summary>
        Open,
        /// <summary>
        /// All releases which manager is the API user.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined request filter.
    /// </summary>
    public enum PredefinedRequestFilter
    {
        /// <summary>
        /// All completed requests.
        /// </summary>
        Completed,
        /// <summary>
        /// All open requests.
        /// </summary>
        Open,
        /// <summary>
        /// All requests which requested by person or requested for person is the API user.
        /// </summary>
        RequestedByOrForMe,
        /// <summary>
        /// All requests which requested for person belonged to the same organization as the API user at the time the request was created.
        /// </summary>
        AssignedToMyTeam,
        /// <summary>
        /// All requests that are assigned to the API user.
        /// </summary>
        AssignedToMe,
        /// <summary>
        /// All requests which requested by person is the API user and which status is 'Waiting for Customer'.
        /// </summary>
        WaitingForMe,
        /// <summary>
        /// All requests that were completed less than 6 months ago and which are linked to a service instance of a service for which the API user is the problem manager.
        /// </summary>
        ProblemManagementReview,
        /// <summary>
        /// All requests that one of the teams of the API user can be held accountable for.
        /// </summary>
        SlaAccountability
    }

    /// <summary>
    /// Predefined request note filter.
    /// </summary>
    public enum PredefinedRequestNoteFilter
    {
        /// <summary>
        /// All public notes.
        /// </summary>
        Public,
        /// <summary>
        /// All internal notes.
        /// </summary>
        Internal
    }

    /// <summary>
    /// Predefined service offering filter.
    /// </summary>
    public enum PredefinedServiceOfferingFilter
    {
        /// <summary>
        /// All catalog service offerings.
        /// </summary>
        Catalog,
        /// <summary>
        /// All portfolio service offerings.
        /// </summary>
        Portfolio
    }

    /// <summary>
    /// Predefined service level agreement organization filter.
    /// </summary>
    public enum PredefinedServiceLevelAgreementOrganizationFilter
    {
        /// <summary>
        /// All disabled organizations.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled organizations.
        /// </summary>
        Enabled,
        /// <summary>
        /// All internal organizations.
        /// </summary>
        External,
        /// <summary>
        /// All external organizations.
        /// </summary>
        Internal
    }

    /// <summary>
    /// Predefined service level agreement people filter.
    /// </summary>
    public enum PredefinedServiceLevelAgreementPeopleFilter
    {
        /// <summary>
        /// All disabled people.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled people.
        /// </summary>
        Enabled,
        /// <summary>
        /// All internal people.
        /// </summary>
        Internal
    }

    /// <summary>
    /// Predefined site filter.
    /// </summary>
    public enum PredefinedSiteFilter
    {
        /// <summary>
        /// All disabled sites.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled sites.
        /// </summary>
        Enabled,
        /// <summary>
        /// All sites registered in the directory account of the support domain account from which the data is requested.
        /// </summary>
        Directory,
        /// <summary>
        /// All sites registered in the account from which the data is requested.
        /// </summary>
        SupportDomain
    }

    /// <summary>
    /// Predefined task status filter.
    /// </summary>
    public enum PredefinedTaskStatusFilter
    {
        /// <summary>
        /// All finished tasks.
        /// </summary>
        Finished,
        /// <summary>
        /// All open tasks.
        /// </summary>
        Open
    }

    /// <summary>
    /// Predefined task filter.
    /// </summary>
    public enum PredefinedTaskFilter
    {
        /// <summary>
        /// All finished tasks.
        /// </summary>
        Finished,
        /// <summary>
        /// All open tasks.
        /// </summary>
        Open,
        /// <summary>
        /// All tasks that are part of a change which manager is the API user.
        /// </summary>
        ManagedByMe,
        /// <summary>
        /// All tasks that are assigned to one of the teams that the API user is a member of.
        /// </summary>
        AssignedToMyTeam,
        /// <summary>
        /// All tasks that are assigned to the API user.
        /// </summary>
        AssignedToMe,
        /// <summary>
        /// All approval tasks that are assigned to the API user and which status in different from 'Registered'.
        /// </summary>
        ApprovalByMe
    }

    /// <summary>
    /// Predefined team member filter.
    /// </summary>
    public enum PredefinedTeamMemberFilter
    {
        /// <summary>
        /// All disabled teams.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled teams.
        /// </summary>
        Enabled,
        /// <summary>
        /// All external organizations.
        /// </summary>
        Internal
    }

    /// <summary>
    /// Predefined shop article filter.
    /// </summary>
    public enum PredefinedShopArticleFilter
    {
        /// <summary>
        /// List all shop articles that are enabled.
        /// </summary>
        Disabled,
        /// <summary>
        /// List all shop articles that are disabled.
        /// </summary>
        Enabled,
        /// <summary>
        /// List all shop articles with the information (name, pricing, etc.) as it is on offer in the shop.
        /// </summary>
        OnOffer
    }

    /// <summary>
    /// Predefined shop order line filter.
    /// </summary>
    public enum PredefinedShopOrderLineFilter
    {
        /// <summary>
        /// List all shop order lines that are not completed.
        /// </summary>
        Open,
        /// <summary>
        /// List all shop order lines that are completed.
        /// </summary>
        Completed,
        /// <summary>
        /// List all shop order lines that are canceled.
        /// </summary>
        Canceled,
        /// <summary>
        /// List all shop order lines that are requested by me.
        /// </summary>
        Personal
    }
}
