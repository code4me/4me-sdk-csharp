using System.Collections.Generic;

namespace Sdk4me
{
    public class CalendarHandler : BaseHandler<Calendar, PredefinedEnabledDisabledFilter>
    {
        public CalendarHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/calendars", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public CalendarHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/calendars", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Calendar hours

        public List<CalendarHours> GetCalendarHours(Calendar calendar, params string[] fieldNames)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours", SortOrder.None).Get(fieldNames);
        }

        public CalendarHours AddCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Insert(calendarHours);
        }

        public CalendarHours UpdateCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Update(calendarHours);
        }

        public bool DeleteCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Delete(calendarHours);
        }

        public bool DeleteAllCalendarHours(Calendar calendar)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").DeleteAll();
        }

        #endregion

        #region Holidays

        public List<Holiday> GetHolidays(Calendar calendar, params string[] fieldNames)
        {
            return GetChildHandler<Holiday>(calendar, "holidays").Get(fieldNames);
        }

        public bool AddHoliday(Calendar calendar, Holiday holiday)
        {
            return CreateRelation(calendar, "holidays", holiday);
        }

        public bool RemoveHoliday(Calendar calendar, Holiday holiday)
        {
            return DeleteRelation(calendar, "holidays", holiday);
        }

        public bool RemoveAllHolidays(Calendar calendar)
        {
            return DeleteAllRelations(calendar, "holidays");
        }

        #endregion
    }
}
