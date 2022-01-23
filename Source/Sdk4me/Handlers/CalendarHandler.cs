using System.Collections.Generic;

namespace Sdk4me
{
    public class CalendarHandler : BaseHandler<Calendar, PredefinedCalendarFilter>
    {
        public CalendarHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/calendars", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public CalendarHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/calendars", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region holidays

        public List<Holiday> GetHolidays(Calendar calendar, params string[] attributeNames)
        {
            DefaultHandler<Holiday> handler = new DefaultHandler<Holiday>($"{this.URL}/{calendar.ID}/holidays", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddHoliday(Calendar calendar, Holiday holiday)
        {
            return CreateRelation(calendar, "holidays", holiday);
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
            DefaultHandler<ServiceOffering> handler = new DefaultHandler<ServiceOffering>($"{this.URL}/{calendar.ID}/service_offerings", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region teams

        public List<Team> GetTeams(Calendar calendar, params string[] attributeNames)
        {
            DefaultHandler<Team> handler = new DefaultHandler<Team>($"{this.URL}/{calendar.ID}/teams", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
