using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/timesheet_settings/">timesheet setting</see> API endpoint.
    /// </summary>
    public class TimesheetSettingHandler : BaseHandler<TimesheetSetting, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me timesheet setting handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimesheetSettingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/timesheet_settings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me timesheet setting handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimesheetSettingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/timesheet_settings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region EffortClass

        /// <summary>
        /// Get all related effort classes.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of effort classes.</returns>
        public List<EffortClass> GetEfforClasses(TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<EffortClass>(timesheetSetting, "effort_classes").Get(fieldNames);
        }

        /// <summary>
        /// Get all related effort classes.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of effort classes.</returns>
        public List<EffortClass> GetEfforClasses(PredefinedEnabledDisabledFilter filter, TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<EffortClass>(timesheetSetting, $"effort_classes/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add an effort class to a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="effortClass">The effort class to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return CreateRelation(timesheetSetting, "effort_classes", effortClass);
        }

        /// <summary>
        /// Remove an effort class from a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="effortClass">The effort class to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return DeleteRelation(timesheetSetting, "effort_classes", effortClass);
        }

        /// <summary>
        /// Remove all effort classes from a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveEffortClasses(TimesheetSetting timesheetSetting)
        {
            return DeleteAllRelations(timesheetSetting, "effort_classes");
        }

        #endregion

        #region Organizations

        /// <summary>
        /// Get all related organizations.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timesheetSetting, "organizations").Get(fieldNames);
        }

        /// <summary>
        /// Get all related organizations.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(PredefinedEnabledDisabledFilter filter, TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timesheetSetting, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add an organization to a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="organization">The organization to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddOrganization(TimesheetSetting timesheetSetting, Organization organization)
        {
            return CreateRelation(timesheetSetting, "organizations", organization);
        }

        /// <summary>
        /// Remove an organization from a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <param name="organization">The organization to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveOrganization(TimesheetSetting timesheetSetting, Organization organization)
        {
            return DeleteRelation(timesheetSetting, "organizations", organization);
        }

        /// <summary>
        /// Remove all organizations from a timesheet setting.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet settings.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllOrganizations(TimesheetSetting timesheetSetting)
        {
            return DeleteAllRelations(timesheetSetting, "organizations");
        }

        #endregion
    }
}
