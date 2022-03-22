using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class TimesheetSettingHandler : BaseHandler<TimesheetSetting, PredefinedEnabledDisabledFilter>
    {
        public TimesheetSettingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/timesheet_settings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimesheetSettingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/timesheet_settings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region EffortClass

        public List<EffortClass> GetEfforClasses(TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<EffortClass>(timesheetSetting, "effort_classes").Get(fieldNames);
        }

        public List<EffortClass> GetEfforClasses(PredefinedEnabledDisabledFilter filter, TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<EffortClass>(timesheetSetting, $"effort_classes/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return CreateRelation(timesheetSetting, "effort_classes", effortClass);
        }

        public bool RemoveEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return DeleteRelation(timesheetSetting, "effort_classes", effortClass);
        }

        public bool RemoveEffortClasses(TimesheetSetting timesheetSetting)
        {
            return DeleteAllRelations(timesheetSetting, "effort_classes");
        }

        #endregion

        #region Organizations

        public List<Organization> GetOrganizations(TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timesheetSetting, "organizations").Get(fieldNames);
        }

        public List<Organization> GetOrganizations(PredefinedEnabledDisabledFilter filter, TimesheetSetting timesheetSetting, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timesheetSetting, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddOrganization(TimesheetSetting timesheetSetting, Organization organization)
        {
            return CreateRelation(timesheetSetting, "organizations", organization);
        }

        public bool RemoveOrganization(TimesheetSetting timesheetSetting, Organization organization)
        {
            return DeleteRelation(timesheetSetting, "organizations", organization);
        }

        public bool RemoveAllOrganizations(TimesheetSetting timesheetSetting)
        {
            return DeleteAllRelations(timesheetSetting, "organizations");
        }

        #endregion
    }
}
