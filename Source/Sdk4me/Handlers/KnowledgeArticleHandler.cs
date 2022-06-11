using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/knowledge_articles/">knowledge article</see> API endpoint.
    /// </summary>
    public class KnowledgeArticleHandler : DefaultBaseHandler<KnowledgeArticle>
    {
        /// <summary>
        /// Create a new instance of the 4me knowledge article handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public KnowledgeArticleHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/knowledge_articles", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me knowledge article handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public KnowledgeArticleHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/knowledge_articles", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Service instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticle, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticle, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool AddServiceInstance(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance)
        {
            return CreateRelation(knowledgeArticle, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool RemoveServiceInstance(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance)
        {
            return DeleteRelation(knowledgeArticle, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove all service instances.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool RemoveAllServiceInstances(KnowledgeArticle knowledgeArticle)
        {
            return DeleteAllRelations(knowledgeArticle, "service_instances");
        }

        #endregion

        #region Translations

        /// <summary>
        /// Get all knowledge article translations.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of knowledge articles.</returns>
        public List<KnowledgeArticleTranslation> GetTranslations(KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            DefaultBaseHandler<KnowledgeArticleTranslation> handler = GetChildHandler<KnowledgeArticleTranslation>(knowledgeArticle, "translations");
            handler.AlwaysAsList = true;
            return handler.Get(fieldNames);
        }

        #endregion
    }
}
