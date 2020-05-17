using System.Collections.Generic;

namespace Sdk4me
{
    public class TimesheetSettingHandler : BaseHandler<TimesheetSetting, PredefinedTimesheetSettingFilter>
    {
        public TimesheetSettingHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/timesheet_settings",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimesheetSettingHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/timesheet_settings",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region effort class

        public List<EffortClass> GetEffortClasses(TimesheetSetting timesheetSetting, params string[] attributeNames)
        {
            DefaultHandler<EffortClass> handler = new DefaultHandler<EffortClass>($"{URL}/{timesheetSetting.ID}/effort_classes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return CreateRelation(timesheetSetting, "effort_classes", effortClass);
        }

        public bool RemoveEffortClass(TimesheetSetting timesheetSetting, EffortClass effortClass)
        {
            return DeleteRelation(timesheetSetting, "effort_classes", effortClass);
        }
    
        public bool RemoveAllEffortClasses(TimesheetSetting timesheetSetting)
        {
            return DeleteAllRelations(timesheetSetting, "effort_classes");
        }

        #endregion

        #region organization

        public List<Organization> GetOrganizations(TimesheetSetting timesheetSetting, params string[] attributeNames)
        {
            DefaultHandler<Organization> handler = new DefaultHandler<Organization>($"{URL}/{timesheetSetting.ID}/organizations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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
