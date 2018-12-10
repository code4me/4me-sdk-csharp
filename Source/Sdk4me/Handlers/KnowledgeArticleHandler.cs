using System.Collections.Generic;

namespace Sdk4me
{
    public class KnowledgeArticleHandler : BaseHandler<KnowledgeArticle>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/knowledge_articles";
        private static readonly string productionUrl = "https://api.4me.com/v1/knowledge_articles";

        public KnowledgeArticleHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public KnowledgeArticleHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region requests

        public List<Request> GetRequests(KnowledgeArticle knowledgeArticle, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{knowledgeArticle.ID}/requests", this.AuthenticationTokens, this.AccountID, ItemsPerRequest, MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region translations

        public List<KnowledgeArticleTranslation> GetTranslations(KnowledgeArticle knowledgeArticle, params string[] attributeNames)
        {
            BaseHandler<KnowledgeArticleTranslation> handler = new BaseHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public KnowledgeArticleTranslation AddTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            BaseHandler<KnowledgeArticleTranslation> handler = new BaseHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(knowledgeArticleTranslation);
        }

        public KnowledgeArticleTranslation UpdateTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            BaseHandler<KnowledgeArticleTranslation> handler = new BaseHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(knowledgeArticleTranslation);
        }

        public bool DeleteTranslation(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslation knowledgeArticleTranslation)
        {
            BaseHandler<KnowledgeArticleTranslation> handler = new BaseHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(knowledgeArticleTranslation);
        }

        public bool DeleteAllTranslations(KnowledgeArticle knowledgeArticle)
        {
            BaseHandler<KnowledgeArticleTranslation> handler = new BaseHandler<KnowledgeArticleTranslation>($"{URL}/{knowledgeArticle.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion
    }
}
