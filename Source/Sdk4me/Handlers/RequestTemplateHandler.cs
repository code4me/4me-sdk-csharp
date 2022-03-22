using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestTemplateHandler : BaseHandler<RequestTemplate, PredefinedEnabledDisabledFilter>
    {
        public RequestTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/request_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/request_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Request

        public List<Request> GetRequests(RequestTemplate requestTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestTemplate, "requests").Get(fieldNames);
        }

        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, RequestTemplate requestTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestTemplate, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Reservation offerings

        public List<ReservationOffering> GetReservationOfferings(RequestTemplate requestTemplate)
        {
            return GetChildHandler<ReservationOffering>(requestTemplate, "reservation_offerings").Get();
        }

        #endregion
    }
}
