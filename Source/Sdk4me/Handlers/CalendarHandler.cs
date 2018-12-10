using System.Collections.Generic;

namespace Sdk4me
{
    public class CalendarHandler : BaseHandler<Calendar>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/calendars";
        private static readonly string productionUrl = "https://api.4me.com/v1/calendars";

        public CalendarHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public CalendarHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region holidays

        public List<Holiday> GetHolidays(Calendar calendar, params string[] attributeNames)
        {
            BaseHandler<Holiday> handler = new BaseHandler<Holiday>($"{URL}/{calendar.ID}/holidays", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddHoliday(Calendar calendar, Holiday holiday)
        {
            return CreateRelation(calendar, "holidays", calendar);
        }

        public bool RemoveHoliday(Holiday holiday, Calendar calendar)
        {
            return DeleteRelation(calendar, "holidays", holiday);
        }

        public bool RemoveAllHolidays(Calendar calendar)
        {
            return DeleteAllRelations(calendar, "holidays");
        }

        #endregion

        #region service offering

        public List<ServiceOffering> GetServiceOfferings(Calendar calendar, params string[] attributeNames)
        {
            BaseHandler<ServiceOffering> handler = new BaseHandler<ServiceOffering>($"{URL}/{calendar.ID}/service_offerings", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region teams

        public List<Team> GetTeams(Calendar calendar, params string[] attributeNames)
        {
            BaseHandler<Team> handler = new BaseHandler<Team>($"{URL}/{calendar.ID}/teams", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
