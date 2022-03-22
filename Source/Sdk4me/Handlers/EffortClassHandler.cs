using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class EffortClassHandler : BaseHandler<EffortClass, PredefinedEnabledDisabledFilter>
    {
        public EffortClassHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/effort_classes", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public EffortClassHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/effort_classes", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Timesheet Settings

        public List<TimesheetSetting> GetTimesheetSettings(EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<TimesheetSetting>(effortClass, "timesheet_settings").Get(fieldNames);
        }

        public List<TimesheetSetting> GetTimesheetSettings(PredefinedEnabledDisabledFilter filter, EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<TimesheetSetting>(effortClass, $"timesheet_settings/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddTimesheetSetting(EffortClass effortClass, TimesheetSetting timesheetSetting)
        {
            return CreateRelation(effortClass, "timesheet_settings", timesheetSetting);
        }

        public bool RemoveTimesheetSetting(EffortClass effortClass, TimesheetSetting timesheetSetting)
        {
            return DeleteRelation(effortClass, "timesheet_settings", timesheetSetting);
        }

        public bool RemoveTimesheetSettings(EffortClass effortClass)
        {
            return DeleteAllRelations(effortClass, "timesheet_settings");
        }
        #endregion
    }
}
