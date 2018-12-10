using System.Collections.Generic;

namespace Sdk4me
{
    public class HolidayHandler : BaseHandler<Holiday>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/holidays";
        private static readonly string productionUrl = "https://api.4me.com/v1/holidays";

        public HolidayHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public HolidayHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region calendars

        public List<Calendar> GetCalendars(Holiday holiday, params string[] attributeNames)
        {
            BaseHandler<Calendar> handler = new BaseHandler<Calendar>($"{URL}/{holiday.ID}/calendars", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddCalendar(Holiday holiday, Calendar calendar)
        {
            return CreateRelation(holiday, "calendars", calendar);
        }

        public bool RemoveCalendar(Holiday holiday, Calendar calendar)
        {
            return DeleteRelation(holiday, "calendars", calendar);
        }

        public bool RemoveAllCalendars(Holiday holiday)
        {
            return DeleteAllRelations(holiday, "calendars");
        }

        #endregion

    }
}
