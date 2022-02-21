using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdk4me;

namespace Configuration_Item_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //AUTHENTICATION TOKENS
            AuthenticationTokenCollection tokens = new AuthenticationTokenCollection {
                new AuthenticationToken("31fd31927a8b..."),
                new AuthenticationToken("28fd31927a8c...")
            };

            //INIT CLIENT
            Sdk4meClient client = new Sdk4meClient(tokens, "wna", EnvironmentType.Quality);

            //FIND A CONFIGURATION ITEM AND ASSIGNED USERS
            Example1(client);
            foreach (AuthenticationToken token in tokens)
                Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}");
            Console.WriteLine();

            //RELATIONS (PEOPLE - CI)
            Example2(client);
            foreach (AuthenticationToken token in tokens)
                Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}");
            Console.WriteLine();
        }

        private static void Example1(Sdk4meClient client)
        {
            try
            {
                //SEARCH
                List<ConfigurationItem> configurationItems = client.ConfigurationItems.Get(new Filter("product_id", FilterCondition.Equality, 123456), "name", "SerialNr");

                foreach (ConfigurationItem configurationItem in configurationItems)
                {
                    Console.WriteLine($"{configurationItem.Name} ({configurationItem.SerialNr ?? ""})");

                    //GET USERS
                    List<Person> people = client.ConfigurationItems.GetUsers(configurationItem);
                    foreach (Person person in people)
                    {
                        Console.WriteLine($"  assigned to: {person.Name}");
                    }
                    Console.WriteLine();
                }
            }
            catch (Sdk4meException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Details: {ex.DetailedMessage}");
            }
        }

        private static void Example2(Sdk4meClient client)
        {
            try
            {
                //DEVICE SERIAL
                string serial = "CD12FF33ED1";

                //SEARCH
                List<ConfigurationItem> configurationItems = client.ConfigurationItems.Get(new Filter("SerialNr", FilterCondition.Equality, serial));
                if (!configurationItems.Count.Equals(1))
                    return;

                //GET ME
                Person me = client.People.GetMe();
                if (me == null)
                    return;

                //SHOW EXISTING RELATIONS
                Console.WriteLine($"All relations for {configurationItems[0].Name}");
                List<Person> people = client.ConfigurationItems.GetUsers(configurationItems[0]);
                foreach (Person person in people)
                    Console.WriteLine($"  {person.Name}");
                Console.WriteLine();

                //ADD CI TO PERSON (CREATE RELATION)
                Console.WriteLine($"Add {configurationItems[0].Name} to {me.Name}");
                client.ConfigurationItems.AddUser(configurationItems[0], me);

                //SHOW EXISTING RELATIONS
                Console.WriteLine($"All relations for {configurationItems[0].Name}");
                people = client.ConfigurationItems.GetUsers(configurationItems[0]);
                foreach (Person person in people)
                    Console.WriteLine($"  {person.Name}");
                Console.WriteLine();

                //REMOVE CI FROM PERSON (DELETE RELATION)
                Console.WriteLine($"Remove {configurationItems[0].Name} from {me.Name}");
                client.ConfigurationItems.RemoveUser(configurationItems[0], me);

                //SHOW EXISTING RELATIONS
                Console.WriteLine($"All relations for {configurationItems[0].Name}");
                people = client.ConfigurationItems.GetUsers(configurationItems[0]);
                foreach (Person person in people)
                    Console.WriteLine($"  {person.Name}");
                Console.WriteLine();

            }
            catch (Sdk4meException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Details: {ex.DetailedMessage}");
            }
        }
    }
}
