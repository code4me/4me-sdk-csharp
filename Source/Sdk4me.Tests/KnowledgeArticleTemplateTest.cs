using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        }
    }
}
