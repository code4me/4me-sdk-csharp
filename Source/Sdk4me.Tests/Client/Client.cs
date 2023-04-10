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

            //get all information
            IConfigurationProvider secretProvider = new ConfigurationBuilder().AddUserSecrets<ConnectionSecret>().Build().Providers.First();
            if (!secretProvider.TryGet("Account", out string account)
                || !secretProvider.TryGet("Token", out string token)
                || !secretProvider.TryGet("ClientID", out string clientID)
                || !secretProvider.TryGet("ClientSecret", out string clientSecret))
            {
                Assert.Fail("Missing information in the user secret file");
                return null;
            }

            if (!string.IsNullOrEmpty(clientID) && !string.IsNullOrWhiteSpace(clientSecret))
            {
                client = new(new AuthenticationToken(clientID, clientSecret), account, EnvironmentType.Demo, EnvironmentRegion.EU, 5);
            }
            else if (!string.IsNullOrEmpty(token))
            {
                client = new(new AuthenticationToken(token), account, EnvironmentType.Demo, EnvironmentRegion.EU, 5);
            }
            else
            {
                Assert.Fail("Invalid information in the user secret file");
                return null;
            }
            return client;
        }
    }
}
