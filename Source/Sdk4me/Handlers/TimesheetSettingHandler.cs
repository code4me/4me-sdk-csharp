using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public class TimesheetSettingHandler : BaseHandler<TimesheetSetting>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/timesheet_settings";
        private static readonly string productionUrl = "https://api.4me.com/v1/timesheet_settings";

        public TimesheetSettingHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimesheetSettingHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region effort class

        public List<EffortClass> GetEffortClasses(TimesheetSetting timesheetSetting, params string[] attributeNames)
        {
            BaseHandler<EffortClass> handler = new BaseHandler<EffortClass>($"{URL}/{timesheetSetting.ID}/effort_classes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Organization> handler = new BaseHandler<Organization>($"{URL}/{timesheetSetting.ID}/organizations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
