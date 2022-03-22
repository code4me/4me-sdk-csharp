using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ReservationOfferingHandler : BaseHandler<ReservationOffering, PredefinedEnabledDisabledFilter>
    {
        public ReservationOfferingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/reservation_offerings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ReservationOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/reservation_offerings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(reservationOffering, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(reservationOffering, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Request templates

        public List<RequestTemplate> GetRequestTemplates(ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(reservationOffering, "request_templates").Get(fieldNames);
        }

        public List<RequestTemplate> GetRequestTemplates(PredefinedEnabledDisabledFilter filter, ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(reservationOffering, $"request_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
