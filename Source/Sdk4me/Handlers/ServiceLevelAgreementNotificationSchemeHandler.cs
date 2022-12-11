using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/sla_notification_schemes/">service level agreement notification scheme</see> API endpoint.
    /// </summary>
    public class ServiceLevelAgreementNotificationSchemeHandler : DefaultBaseHandler<ServiceLevelAgreementNotificationScheme>
    {
        /// <summary>
        /// Create a new instance of the 4me service level agreement notification scheme handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceLevelAgreementNotificationSchemeHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/sla_notification_schemes", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service level agreement notification scheme handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceLevelAgreementNotificationSchemeHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/sla_notification_schemes", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Service level agreement notification rules

        /// <summary>
        /// Get all service level agreement notification rules.
        /// </summary>
        /// <param name="serviceLevelAgreementNotificationScheme">The service level agreement notification scheme.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreement notification rule.</returns>
        public List<ServiceLevelAgreementNotificationRule> GetNotificationRules(ServiceLevelAgreementNotificationScheme serviceLevelAgreementNotificationScheme, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreementNotificationRule>(serviceLevelAgreementNotificationScheme, "sla_notification_rules").Get(fieldNames);
        }

        /// <summary>
        /// Add an service level agreement notification rule.
        /// </summary>
        /// <param name="serviceLevelAgreementNotificationScheme">The service level agreement notification scheme.</param>
        /// <param name="serviceLevelAgreementNotificationRule">The service level agreement notification rule to add.</param>
        /// <returns>The updated address.</returns>
        public ServiceLevelAgreementNotificationRule AddNotificationRule(ServiceLevelAgreementNotificationScheme serviceLevelAgreementNotificationScheme, ServiceLevelAgreementNotificationRule serviceLevelAgreementNotificationRule)
        {
            return GetChildHandler<ServiceLevelAgreementNotificationRule>(serviceLevelAgreementNotificationScheme, "sla_notification_rules").Insert(serviceLevelAgreementNotificationRule);
        }

        /// <summary>
        /// Delete a service level agreement notification rule.
        /// </summary>
        /// <param name="serviceLevelAgreementNotificationScheme">The service level agreement notification scheme.</param>
        /// <param name="serviceLevelAgreementNotificationRule">The service level agreement notification rule to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteNotificationRule(ServiceLevelAgreementNotificationScheme serviceLevelAgreementNotificationScheme, ServiceLevelAgreementNotificationRule serviceLevelAgreementNotificationRule)
        {
            return GetChildHandler<ServiceLevelAgreementNotificationRule>(serviceLevelAgreementNotificationScheme, "sla_notification_rules").Delete(serviceLevelAgreementNotificationRule);
        }

        /// <summary>
        /// Delete all a service level agreement notification rules.
        /// </summary>
        /// <param name="serviceLevelAgreementNotificationScheme">The service level agreement notification scheme.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllNotificationRules(ServiceLevelAgreementNotificationScheme serviceLevelAgreementNotificationScheme)
        {
            return GetChildHandler<ServiceLevelAgreementNotificationRule>(serviceLevelAgreementNotificationScheme, "sla_notification_rules").DeleteAll();
        }

        #endregion
    }
}
