using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdk4me.Tests
{
    [TestClass]
    public class KnowledgeArticleTemplateTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            List<KnowledgeArticleTemplate> knowledgeArticleTemplates = client.KnowledgeArticleTemplates.Get("*");
            Console.WriteLine($"Count: {knowledgeArticleTemplates.Count}");
            Assert.IsNotNull(knowledgeArticleTemplates);
            Assert.IsInstanceOfType(knowledgeArticleTemplates, typeof(List<KnowledgeArticleTemplate>));

            if (knowledgeArticleTemplates.Count == 0)
                return;
            KnowledgeArticleTemplate knowledgeArticleTemplate = knowledgeArticleTemplates[Random.Shared.Next(knowledgeArticleTemplates.Count)];
            Trace.WriteLine($"Continue tests on knowledge article #{knowledgeArticleTemplate.ID}, {knowledgeArticleTemplate.Subject}");

            Trace.WriteLine($"Get service instance for knowledge article template #{knowledgeArticleTemplate.ID}");
            List<ServiceInstance> serviceInstances = client.KnowledgeArticleTemplates.GetServiceInstances(knowledgeArticleTemplate, "*");
            Console.WriteLine($"Count: {serviceInstances.Count}");
            Assert.IsNotNull(serviceInstances);
            Assert.IsInstanceOfType(serviceInstances, typeof(List<ServiceInstance>));

            Trace.WriteLine($"Get knowledge article for knowledge article template #{knowledgeArticleTemplate.ID}");
            List<KnowledgeArticle> knowledgeArticles = client.KnowledgeArticleTemplates.GetKnowledgeArticles(knowledgeArticleTemplate);
            Console.WriteLine($"Count: {knowledgeArticles.Count}");
            Assert.IsNotNull(knowledgeArticles);
            Assert.IsInstanceOfType(knowledgeArticles, typeof(List<KnowledgeArticle>));
        }
    }
}
