using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/calendars/">calendar</see> API endpoint.
    /// </summary>
    public class CalendarHandler : BaseHandler<Calendar, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me calendar handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public CalendarHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/calendars", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me calendar handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public CalendarHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/calendars", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Calendar hours

        /// <summary>
        /// Get all related calendar hours.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of calendar hours.</returns>
        public List<CalendarHours> GetCalendarHours(Calendar calendar, params string[] fieldNames)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add calendar hours.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="calendarHours">The calendar hours to add.</param>
        /// <returns>The updated calendar hours.</returns>
        public CalendarHours AddCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Insert(calendarHours);
        }

        /// <summary>
        /// Update calendar hours.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="calendarHours">The calendar hours to update.</param>
        /// <returns>The updated calendar hours.</returns>
        public CalendarHours UpdateCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Update(calendarHours);
        }

        /// <summary>
        /// Delete calendar hours.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="calendarHours">The calendar hours to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteCalendarHours(Calendar calendar, CalendarHours calendarHours)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").Delete(calendarHours);
        }

        /// <summary>
        /// Delete all calendar hours.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllCalendarHours(Calendar calendar)
        {
            return GetChildHandler<CalendarHours>(calendar, "calendar_hours").DeleteAll();
        }

        #endregion

        #region Holidays

        /// <summary>
        /// Get all related holidays.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of holidays.</returns>
        public List<Holiday> GetHolidays(Calendar calendar, params string[] fieldNames)
        {
            return GetChildHandler<Holiday>(calendar, "holidays").Get(fieldNames);
        }

        /// <summary>
        /// Add holidays.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="holiday">The holiday to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddHoliday(Calendar calendar, Holiday holiday)
        {
            return CreateRelation(calendar, "holidays", holiday);
        }

        /// <summary>
        /// Remove holidays.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <param name="holiday">The holiday to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveHoliday(Calendar calendar, Holiday holiday)
        {
            return DeleteRelation(calendar, "holidays", holiday);
        }

        /// <summary>
        /// Remove all holidays.
        /// </summary>
        /// <param name="calendar">The calendar.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllHolidays(Calendar calendar)
        {
            return DeleteAllRelations(calendar, "holidays");
        }

        #endregion
    }
}
