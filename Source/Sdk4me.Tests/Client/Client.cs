using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sdk4me.Tests
{
    internal class Client
    {
        private static Sdk4meClient client;

        public static Sdk4meClient Get()
        {
            if (client != null)
                return client;

            //get account and token
            IConfigurationProvider secretProvider = new ConfigurationBuilder().AddUserSecrets<ConnectionSecret>().Build().Providers.First();
            if (!secretProvider.TryGet("Account", out string account) || !secretProvider.TryGet("Token", out string token))
            {
                Assert.Fail("No account of token information available via the user secret file");
                return null;
            }

            //connect to the client
            client = new(new AuthenticationToken(token), account, EnvironmentType.Demo, 25, 3);
            return client;
        }
    }
}
