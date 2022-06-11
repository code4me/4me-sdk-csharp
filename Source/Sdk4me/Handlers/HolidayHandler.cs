using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/holidays/">holiday</see> API endpoint.
    /// </summary>
    public class HolidayHandler : DefaultBaseHandler<Holiday>
    {
        /// <summary>
        /// Create a new instance of the 4me holiday handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public HolidayHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/holidays", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me holiday handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public HolidayHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/holidays", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Calendar

        /// <summary>
        /// Get all related calendars.
        /// </summary>
        /// <param name="holiday">The holiday.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of holidays.</returns>
        public List<Calendar> GetCalendars(Holiday holiday, params string[] fieldNames)
        {
            return GetChildHandler<Calendar>(holiday, "calendars").Get(fieldNames);
        }

        /// <summary>
        /// Add a calendar.
        /// </summary>
        /// <param name="holiday">The holiday.</param>
        /// <param name="calendar">The calendar to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddCalendar(Holiday holiday, Calendar calendar)
        {
            return CreateRelation(holiday, "calendars", calendar);
        }

        /// <summary>
        /// Remove a calendar.
        /// </summary>
        /// <param name="holiday">The holiday.</param>
        /// <param name="calendar">The calendar to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveCalendar(Holiday holiday, Calendar calendar)
        {
            return DeleteRelation(holiday, "calendars", calendar);
        }

        /// <summary>
        /// Remove all calendars.
        /// </summary>
        /// <param name="holiday">The holiday.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllCalendars(Holiday holiday)
        {
            return DeleteAllRelations(holiday, "calendars");
        }

        #endregion
    }
}
