using System;
using System.Collections.Generic;
using Sdk4me;

namespace People_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //AUTHENTICATION TOKENS
            AuthenticationToken token = new AuthenticationToken("31fd31927a8b...", AuthenticationType.BearerAuthentication);

            //INIT CLIENT
            Sdk4meClient client = new Sdk4meClient(token, null, EnvironmentType.Quality);

            //GET /people/me EXAMPLE
            Example1(client);
            Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}");
            Console.WriteLine();

            //SEARCH EXAMPLE
            Example2(client);
            Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}");
            Console.WriteLine();

            //UPDATE
            Example3(client);
            Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}");
            Console.WriteLine();
        }

        private static void Example1(Sdk4meClient client)
        {
            try
            {
                //GET ME
                Person me = client.People.GetMe();

                if (me != null)
                {
                    //DEFAULT INFORMATION
                    Console.WriteLine($"Name: {me.Name}");
                    Console.WriteLine($"Primary email: {me.PrimaryEmail}");
                    Console.WriteLine();

                    //ADDRESSES
                    foreach (Address address in me.Addresses)
                    {
                        Console.WriteLine($"Address type: {address.Label}");
                        Console.WriteLine($"Street: {address.Street}");
                        Console.WriteLine($"City: {address.Zip} {address.City}");
                        Console.WriteLine($"Country: {address.Country}");
                    }
                    Console.WriteLine();

                    //CONTACTS
                    foreach (Contact contact in me.Contacts)
                    {
                        Console.WriteLine($"{contact.Label}: {contact.Chat ?? contact.Email ?? contact.Telephone ?? contact.Website}");
                    }
                    Console.WriteLine();

                    //CUSTOM FIELDS
                    foreach (string key in me.CustomFields?.Keys)
                    {
                        Console.WriteLine($"{key}: {me.CustomFields[key]}");
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
                //SEARCH FILTER
                FilterCollection filters = new FilterCollection()
                {
                    { "CreatedAt", FilterCondition.GreaterThanOrEqualsTo, new DateTime(2018, 06, 01) },
                    { "CreatedAt", FilterCondition.LessThanOrEqualsTo, new DateTime(2018, 07, 01) }

                };

                //SEARCH AND ONLY LOAD SPECIFIED ATTRIBUTES
                List<Person> people = client.People.Get(filters, "Name", "PrimaryEmail", "CustomFields");

                //PEOPLE
                foreach (Person person in people)
                {
                    Console.WriteLine($"{person.Name} ({person.PrimaryEmail})");
                    Console.WriteLine($"Custom fields count: {person.CustomFields.Count}");
                }
                Console.WriteLine();

            }
            catch (Sdk4meException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Details: {ex.DetailedMessage}");
            }


        }

        private static void Example3(Sdk4meClient client)
        {
            try
            {
                //GET ME
                Person me = client.People.GetMe();

                //SET FIELDS
                me.Information = "Additional information about myself";
                me.JobTitle = "My new job title";

                //UPDATE
                me = client.People.Update(me);

                //ADD AN ADDRESS
                Address address = new Address()
                {
                    Label = AddressType.Home,
                    Street = "Broadway 12456b",
                    Zip = "123456",
                    City = "Bangkok",
                    Country = "Thailand"
                };
                address = client.People.AddAddress(me, address);
                Console.WriteLine($"Address {address.ID} successfully created.");

                //UPDATE AN ADDRESS
                List<Address> addresses = client.People.GetAddresses(me);
                for (int i = 0; i < addresses.Count; i++)
                {
                    //UPDATE COUNTRY OF EXISTING ADDRESS
                    addresses[i].Country = "CN";

                    //UPDATE ADDRESS
                    addresses[i] = client.People.UpdateAddress(me, addresses[i]);
                    Console.WriteLine($"Address {addresses[i]} successfully updated.");

                }
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
