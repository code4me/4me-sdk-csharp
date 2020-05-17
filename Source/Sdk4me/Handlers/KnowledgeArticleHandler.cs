using System.Collections.Generic;

namespace Sdk4me
{
    public class KnowledgeArticleHandler : BaseHandler<KnowledgeArticle, PredefinedKnowledgeArticleFilter>
    {
        public KnowledgeArticleHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/knowledge_articles", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public KnowledgeArticleHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/knowledge_articles", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instance

        public List<ServiceInstance> GetServiceInstances(KnowledgeArticle knowledgeArticle, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{knowledgeArticle.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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

        #region requests

        public List<Request> GetRequests(KnowledgeArticle knowledgeArticle, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{URL}/{knowledgeArticle.ID}/requests", this.AuthenticationTokens, this.AccountID, ItemsPerRequest, MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region translations

        public List<KnowledgeArticleTranslation> GetTranslations(KnowledgeArticle knowledgeArticle, params string[] attributeNames)
        {
            DefaultHandler<KnowledgeArticleTranslation> handler = new DefaultHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public KnowledgeArticleTranslation AddTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            DefaultHandler<KnowledgeArticleTranslation> handler = new DefaultHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(knowledgeArticleTranslation);
        }

        public KnowledgeArticleTranslation UpdateTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            DefaultHandler<KnowledgeArticleTranslation> handler = new DefaultHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(knowledgeArticleTranslation);
        }

        public bool DeleteTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            DefaultHandler<KnowledgeArticleTranslation> handler = new DefaultHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(knowledgeArticleTranslation);
        }

        public bool DeleteAllTranslations(KnowledgeArticle knowledgeArticle)
        {
            DefaultHandler<KnowledgeArticleTranslation> handler = new DefaultHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion
    }
}
