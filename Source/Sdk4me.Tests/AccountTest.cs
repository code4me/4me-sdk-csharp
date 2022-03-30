using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sdk4me.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Get()
        {
            Sdk4meClient client = Client.Get();
            Account account = client.Account.Get();
            Assert.IsNotNull(account);
            Assert.IsInstanceOfType(account, typeof(Account));

            List<UsageStatement> usageStatements = client.Account.GetUsageStatements();
            Assert.IsNotNull(usageStatements);
            Assert.IsInstanceOfType(usageStatements, typeof(List<UsageStatement>));

            usageStatements = client.Account.GetUsageStatements(DateTime.Now.AddMonths(-1));
            Assert.IsNotNull(usageStatements);
            Assert.IsInstanceOfType(usageStatements, typeof(List<UsageStatement>));

            usageStatements = client.Account.GetUsageStatements();
            Assert.IsNotNull(usageStatements);
            Assert.IsInstanceOfType(usageStatements, typeof(List<UsageStatement>));

            List<BillableUser> billableUsers = client.Account.GetBillableUsers();
            Assert.IsNotNull(billableUsers);
            Assert.IsInstanceOfType(billableUsers, typeof(List<BillableUser>));

            billableUsers = client.Account.GetBillableUsers(DateTime.Now.AddMonths(-1));
            Assert.IsNotNull(billableUsers);
            Assert.IsInstanceOfType(billableUsers, typeof(List<BillableUser>));

            List<Person> people = client.Account.GetPeopleWithRoles(AccessRoles.AccountAdministrator, AccountSelection.CurrentAccountAndDirectoryAccount, "*");
            Assert.IsNotNull(people);
            Assert.IsInstanceOfType(people, typeof(List<Person>));
        }
    }
}
