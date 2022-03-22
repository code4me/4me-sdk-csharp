using System.Collections.Generic;

namespace Sdk4me
{
    public class HolidayHandler : DefaultBaseHandler<Holiday>
    {
        public HolidayHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/holidays", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public HolidayHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/holidays", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Calendar

        public List<Calendar> GetCalendars(Holiday holiday, params string[] fieldNames)
        {
            return GetChildHandler<Calendar>(holiday, "calendars").Get(fieldNames);
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
