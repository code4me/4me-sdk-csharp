using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/request_templates/">request template</see> API endpoint.
    /// </summary>
    public class RequestTemplateHandler : BaseHandler<RequestTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me request template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/request_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me request template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/request_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Request

        /// <summary>
        /// Get all related requests.
        /// </summary>
        /// <param name="requestTemplate">The request template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<Request> GetRequests(RequestTemplate requestTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestTemplate, "requests").Get(fieldNames);
        }

        /// <summary>
        /// Get all related requests.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="requestTemplate">The request template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, RequestTemplate requestTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestTemplate, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Reservation offerings

        /// <summary>
        /// Get all related reservation offerings.
        /// </summary>
        /// <param name="requestTemplate">The request template.</param>
        /// <returns>A collection of reservation offerings.</returns>
        public List<ReservationOffering> GetReservationOfferings(RequestTemplate requestTemplate)
        {
            return GetChildHandler<ReservationOffering>(requestTemplate, "reservation_offerings").Get();
        }

        #endregion
    }
}
