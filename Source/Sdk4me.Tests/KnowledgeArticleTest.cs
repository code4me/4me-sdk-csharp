using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class KnowledgeArticleTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<KnowledgeArticle> knowledgeArticles = client.KnowledgeArticles.Get("*");
            Console.WriteLine($"Count: {knowledgeArticles.Count}");
            Assert.IsNotNull(knowledgeArticles);
            Assert.IsInstanceOfType(knowledgeArticles, typeof(List<KnowledgeArticle>));
        }
    }
}
