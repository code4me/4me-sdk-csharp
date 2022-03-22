using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class KnowledgeArticleHandler : DefaultBaseHandler<KnowledgeArticle>
    {
        public KnowledgeArticleHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/knowledge_articles", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public KnowledgeArticleHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/knowledge_articles", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Service instances

        public List<ServiceInstance> GetServiceInstances(KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticle, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(knowledgeArticle, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance)
        {
            return CreateRelation(knowledgeArticle, "service_instances", serviceInstance);
        }

        public bool RemoveServiceInstance(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance)
        {
            return DeleteRelation(knowledgeArticle, "service_instances", serviceInstance);
        }

        public bool RemoveAllServiceInstances(KnowledgeArticle knowledgeArticle)
        {
            return DeleteAllRelations(knowledgeArticle, "service_instances");
        }

        #endregion

        #region Translations

        public List<KnowledgeArticleTranslation> GetTranslations(KnowledgeArticle knowledgeArticle, params string[] fieldNames)
        {
            DefaultBaseHandler<KnowledgeArticleTranslation> handler = GetChildHandler<KnowledgeArticleTranslation>(knowledgeArticle, "translations");
            handler.AlwaysAsList = true;
            return handler.Get(fieldNames);
        }

        #endregion
    }
}
