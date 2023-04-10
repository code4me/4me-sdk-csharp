using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/knowledge_article_templates/">knowledge article templates</see> API endpoint.
    /// </summary>
    public class KnowledgeArticleTemplateHandler : BaseHandler<KnowledgeArticleTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me knowledge article template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public KnowledgeArticleTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/knowledge_article_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me knowledge article template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public KnowledgeArticleTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/knowledge_article_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Knowledge articles

        /// <summary>
        /// Get all related knowledge articles.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<KnowledgeArticle> GetKnowledgeArticles(KnowledgeArticleTemplate knowledgeArticleTemplate, params string[] fieldNames)
        {
            return GetChildHandler<KnowledgeArticle>(knowledgeArticleTemplate, "knowledge_articles").Get(fieldNames);

        }

        /// <summary>
        /// Get all related knowledge articles.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<KnowledgeArticle> GetKnowledgeArticles(PredefinedKnowledgeArticleFilter filter, KnowledgeArticleTemplate knowledgeArticleTemplate, params string[] fieldNames)
        {
            return GetChildHandler<KnowledgeArticle>(knowledgeArticleTemplate, $"knowledge_articles/{filter.To4meString()}").Get(fieldNames);

        }

        #endregion

        #region Service instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(KnowledgeArticleTemplate knowledgeArticleTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticleTemplate, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, KnowledgeArticleTemplate knowledgeArticleTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticleTemplate, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool AddServiceInstance(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstance serviceInstance)
        {
            return CreateRelation(knowledgeArticleTemplate, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool RemoveServiceInstance(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstance serviceInstance)
        {
            return DeleteRelation(knowledgeArticleTemplate, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove all service instances.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template.</param>
        /// <returns>True in case of success;otherwise false.</returns>
        public bool RemoveAllServiceInstances(KnowledgeArticleTemplate knowledgeArticleTemplate)
        {
            return DeleteAllRelations(knowledgeArticleTemplate, "service_instances");
        }

        #endregion
    }
}