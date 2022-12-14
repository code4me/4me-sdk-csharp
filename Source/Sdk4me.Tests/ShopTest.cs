using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me.Tests
{
    [TestClass]
    public class ShopTest
    {
        [TestMethod]
        public void GetArticles()
        {
            Sdk4meClient client = Client.Get();
            List<ShopArticle> articles = client.ShopArticles.Get("*");
            Assert.IsNotNull(articles);
            Assert.IsInstanceOfType(articles, typeof(List<ShopArticle>));

            if (articles.Count == 0)
                return;
            ShopArticle article = articles[Random.Shared.Next(articles.Count)];
            Trace.WriteLine($"Continue relation tests on shop article: {article.Name}");

            List<AuditTrail> auditTrails = client.ShopArticles.GetAuditTrail(article);
            Assert.IsNotNull(auditTrails);
            Assert.IsInstanceOfType(auditTrails, typeof(List<AuditTrail>));
        }

        [TestMethod]
        public void GetAllArticles()
        {
            Sdk4meClient client = Client.Get();
            List<ShopOrderLine> orderLines = client.ShopOrderLines.Get("*");
            Assert.IsNotNull(orderLines);
            Assert.IsInstanceOfType(orderLines, typeof(List<ShopOrderLine>));

            if (orderLines.Count == 0)
                return;
            ShopOrderLine orderLine = orderLines[Random.Shared.Next(orderLines.Count)];
            Trace.WriteLine($"Continue relation tests on order line: {orderLine.Name}");

            List<AuditTrail> auditTrails = client.ShopOrderLines.GetAuditTrail(orderLine);
            Assert.IsNotNull(auditTrails);
            Assert.IsInstanceOfType(auditTrails, typeof(List<AuditTrail>));
        }
    }
}
