# C# SDK for 4me
A .NET client for accessing the [4me v1 REST API](https://developer.4me.com/)

### Licensing
The C# SDK for 4me uses the [Newtonsoft.Json framework](https://github.com/JamesNK/Newtonsoft.Json) NuGet Package, which is a high-performance JSON framework for .NET and available under [MIT licensing](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md).


# Getting started
The solution has 2 main objects, BaseItem which is a data type with the minimum object attributes for a 4me data object; and the BaseHandler which contains all methods to handle http requests and responses to and from the 4me REST API.

Almost all data types and handlers have been implemented. As an example, the solution contains a data object Person and a handler PeopleHandler. The data type contains all known and documented attributes, the handler exposes methods for all known functions on the /people endpoint.

Finally, there is an overall class, the Sdk4meClient, which implemented all available handlers. Using it like this is simple and can be done with very limited amount of code.

### BaseHandler Built-in features
The default implementation has some built-in functionality to optimize the 4me REST API usage.

#### Filtering
The Get method allows predefined filtering, custom filtering and response field selection. More information about filters can be found on the [4me developer website](https://developer.4me.com/v1/general/filtering/).

#### Field selection
The Get method allows filtering and response attribute selection. If no fields are specified it will return the default field selection as documented on the [4me developer website](https://developer.4me.com/v1/general/field_selection/). To return all field values an asterisk (*) can be used.

#### Pagination
The API requests returning a collection are always paginated. A single API request will return at most 100 records. The BaseHandler allows you to set the number of items per page, as well as the number of pages to be requested. More information about pagination is available on the [4me developer website](https://developer.4me.com/v1/general/pagination/).

#### Case conversion
Filtering and field selection require references to fields. All endpoints and fields are in snake case; the BaseHandler will convert camel case to snake case.

#### Multi-token support
The BaseHandler supports the usage of multiple authentication tokens. The amount of API request is limited to 3600 request per hour, which in some cases in not enough. When multiple tokens are used, the BaseHandler will always use the token with the highest remaining request value. More information about Rate Limiting can be found on the [4me developer website](https://developer.4me.com/v1/#rate-limiting).

#### Response timing
The 4me REST API limits the amount of requests to 10 per second.  The BaseHandler will keep track of the response time and lock the process to make sure it takes at lease 116 milliseconds per request.

#### Exception handling
A custom, Sdk4meException, is implemented. It will convert an API exception response to a string value.


# Sdk4meClient
### Minimum example
```csharp
using Sdk4me;

AuthenticationToken token = new AuthenticationToken("TheBearerToken");
Sdk4meClient client = new Sdk4meClient(token);
Person me = client.People.GetMe();
Console.WriteLine($"{me.Name} ({me.PrimaryEmail})");
```

### Retrieve a single record
```csharp
Site site = client.Site.Get(1324);
Console.WriteLine(site.Name);
```
By default, this will return all fields of the [site](https://developer.4me.com/v1/sites/#fields).

### Browse through a collection of records
```csharp
List<Site> sites = client.Site.Get();
foreach (Site site in sites)
    Console.WriteLine(site.Name);
Console.WriteLine($"Sites found: {sites.Count}");
```
This will return the default fields for a [site](https://developer.4me.com/v1/sites/#fields).

### Filtering
```csharp
var cis = client.ConfigurationItem.Get(
    new FilterCollection()
    {
        new Filter("Status", FilterCondition.Equality, ConfigurationItemStatusType.BrokenDown),
        new Filter("CreatedAt", FilterCondition.GreaterThanOrEqualsTo, new DateTime(2017,1,1))
    }
);
foreach (ConfigurationItem ci in cis)
    Console.WriteLine(ci.Name);
```
This will return all [configuration items](https://developer.4me.com/v1/configuration_items/) created before 1 January 2017 with a broken down status.

```csharp
var projectTaskTemplates = client.ProjectTaskTemplates.Get(PredefinedProjectTaskTemplateFilter.Enabled);
foreach (ProjectTaskTemplate projectTaskTemplate in projectTaskTemplates)
	Console.WriteLine(projectTaskTemplate.Subject);
```
This will return all enabled [project task templates](https://developer.4me.com/v1/project_task_templates/) using a predefined filter.

```csharp
var people = client.People.Get(PredefinedPeopleFilter.Directory, new Filter("sourceID", FilterCondition.Present));
foreach (Person person in people)
    Console.WriteLine(person.PrimaryEmail);
```
This will return all [people](https://developer.4me.com/v1/people/) registered in the directory account of the support domain account from which the data is requested that have a sourceID value.

### Field selection
```csharp
List<Person> people = client.People.Get("CustomFields", "Manager", "SourceID");
foreach (Person person in people)
    Console.WriteLine(person);
```
This will return all people but only load the CustomFields, Manager and SourceID properties values.

```csharp
people = client.People.Get("*");
foreach (Person person in people)
    Console.WriteLine(person);
```
This will return all people with load all properties values.

### Creating a record
```csharp
Person person = new Person()
{
    PrimaryEmail = "new.user@example.com",
    Organization = new Organization() { ID = 123 },
    Name = "New User (Example)"
};
person = client.People.Insert(person);
```

### Update a record
```csharp
Organization organization = client.Organization.Get(1234);
organization.Name = "A new name";
organization = client.Organization.Update(organization);
```

### Delete a record
```csharp
Organization organization = client.Organization.Get(1234);
List<Address> addresses = client.Organization.GetAddresses(organization);
bool result = client.Organization.DeleteAddress(organization, addresses[1]);
```
The BaseHandler has a Delete and DeleteAll method. Those can only be used to remove a resource from a collection not to delete content. 

### Exception handling
```csharp
try
{
    AuthenticationToken token = new AuthenticationToken("3TheBearerToken");
    Sdk4meClient client = new Sdk4meClient(token);
    Person me = client.People.GetMe();
    List<Team> myTeams = client.People.GetTeams(me, "*");
    foreach (Team team in myTeams)
        Console.WriteLine(team.Name);
}
catch (Sdk4meException ex)
{
    Console.WriteLine($"Message: {ex.Message}\r\nDetails: {ex.DetailedMessage}");
}
```

### Multi-token, accounts and environment usage
```csharp
AuthenticationTokenCollection tokens = new AuthenticationTokenCollection()
{
    new AuthenticationToken("TheFirstBearerToken"),
    new AuthenticationToken("TheSecondBearerToken")
};
var client1 = new Sdk4meClient(tokens, "account-name-1", EnvironmentType.Production);
```