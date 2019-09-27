using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    /// <summary>
    /// The default predefined filter values.
    /// </summary>
    public enum PredefinedDefaultFilter
    {
        /// <summary>
        /// No predefined filter.
        /// </summary>
        None
    }

    /// <summary>
    /// Predefined broadcast filters.
    /// </summary>
    public enum PredefinedBroadcastFilter
    {
        /// <summary>
        /// All active broadcasts.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive broadcasts.
        /// </summary>
        Inactive
    }

    /// <summary>
    /// Predefined calendar filters.
    /// </summary>
    public enum PredefinedCalendarFilter
    {
        /// <summary>
        /// All disabled calendars.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled calendars.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined change filter.
    /// </summary>
    public enum PredefinedChangeFilter
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
        /// All changes which manager is the API user.
        /// </summary>
        ManagedByMe
    }

    /// <summary>
    /// Predefined change template filter.
    /// </summary>
    public enum PredefinedChangeTemplateFilter
    {
        /// <summary>
        /// All disabled change template.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled change template.
        /// </summary>
        Enabled
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
    /// Predefined contract filter.
    /// </summary>
    public enum PredefinedContractFilter
    {
        /// <summary>
        /// All active contracts.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive contracts.
        /// </summary>
        Inactive
    }

    /// <summary>
    /// Predefined first line support agreement filter.
    /// </summary>
    public enum PredefinedFirstLineSupportArgreementFilter
    {
        /// <summary>
        /// All active first line support agreements.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive first line support agreements.
        /// </summary>
        Inactive
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
        /// All external organizations.
        /// </summary>
        Internal,
        /// <summary>
        /// All internal organizations.
        /// </summary>
        External,
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
    /// Predefined project task template filter.
    /// </summary>
    public enum PredefinedProjectTaskTemplateFilter
    {
        /// <summary>
        /// All disabled project task templates.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled project task templates.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined project template filter.
    /// </summary>
    public enum PredefinedProjectTemplateFilter
    {
        /// <summary>
        /// All disabled project templates.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled project templates.
        /// </summary>
        Enabled
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
        RequestsOfMyOrganization,
        /// <summary>
        /// All requests that are assigned to one of the teams that the API user is a member of.
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
    /// Predefined request template filter.
    /// </summary>
    public enum PredefinedRequestTemplateFilter
    {
        /// <summary>
        /// All disabled request templates.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled request templates.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined service filter.
    /// </summary>
    public enum PredefinedServiceFilter
    {
        /// <summary>
        /// All disabled services.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled services.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined service instance filter.
    /// </summary>
    public enum PredefinedServiceInstanceFilter
    {
        /// <summary>
        /// All active service instances.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive service instances.
        /// </summary>
        Inactive
    }

    /// <summary>
    /// Predefined service level agreement filter.
    /// </summary>
    public enum PredefinedServiceLevelArgreementFilter
    {
        /// <summary>
        /// All active service level agreements.
        /// </summary>
        Active,
        /// <summary>
        /// All inactive service level agreements.
        /// </summary>
        Inactive
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
    /// Predefined task template filter.
    /// </summary>
    public enum PredefinedTaskTemplateFilter
    {
        /// <summary>
        /// All disabled task templates.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled task templates.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined team filter.
    /// </summary>
    public enum PredefinedTeamFilter
    {
        /// <summary>
        /// All disabled teams.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled teams.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined time allocation filter.
    /// </summary>
    public enum PredefinedTimeAllocationFilter
    {
        /// <summary>
        /// All disabled time allocations.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled time allocations.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Predefined timesheet setting filter.
    /// </summary>
    public enum PredefinedTimesheetSettingFilter
    {
        /// <summary>
        /// All disabled timesheet settings.
        /// </summary>
        Disabled,
        /// <summary>
        /// All enabled timesheet settings.
        /// </summary>
        Enabled
    }
}
