
# C# SDK for 4me
A .NET client for accessing the [4me v1 REST API](https://developer.4me.com/)

### Licensing
The C# SDK for 4me uses the [Newtonsoft.Json framework](https://github.com/JamesNK/Newtonsoft.Json) NuGet Package, which is a high-performance JSON framework for .NET and available under [MIT licensing](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md).


# Getting started
The solution has 2 main objects, BaseItem which is a data type with the minimum object attributes for a 4me data object; and the BaseHandler which contains all methods to handle http requests and responses to and from the 4me REST API.

Almost all data types and handlers have been implemented. As an example, the solution contains a data object Person and a handler PeopleHandler. The data type contains all known and documented fields, the handler exposes methods for all known functions on the /people endpoint.

Finally, there is an overall class, the Sdk4meClient, which exposes all available handlers. Using it like this is simple and can be done with very limited set of code.

### BaseHandler Built-in features
The default implementation has a set of built-in functionalities to optimize the 4me REST API usage.

#### Filtering
The Get method allows predefined and custom filtering. More information about filters can be found on the [4me developer website](https://developer.4me.com/v1/general/filtering/).

#### Field selection
The Get method allows field selection. If no fields are specified it will return the default field selection as documented on the [4me developer website](https://developer.4me.com/v1/general/field_selection/). To return all field values an asterisk (*) can be used.

#### Pagination
The API requests returning a collection are always paginated. A single API request will return at most 100 records. The client allows you to set the number of items per page, as well as the number of pages to be requested. More information about pagination is available on the [4me developer website](https://developer.4me.com/v1/general/pagination/).

#### Attachments
The UploadAttachment method makes it possible to upload attachments, which can be referenced later when inserting or updating an object.
The DeleteAttachment methods can be used to delete any attachment listed in the Attachments property.
More information about attachments can be found on the [4me developer website](https://developer.4me.com/v1/general/data_types/#attachments).

#### Case conversion
Filtering and field selection requires references to fields. All endpoints and fields are in snake case; the client will convert camel case to snake case.

#### Multi-token support
The client supports the usage of multiple authentication tokens. The number of API requests is limited to 3600 request per hour, which in some cases in not enough. When multiple tokens are used, the client will always use the token with the highest remaining request value. More information about rate limiting can be found on the [4me developer website](https://developer.4me.com/v1/#rate-limiting).

#### Response timing
The 4me REST API limits the number of requests to 10 per second.  The client will keep track of the response time and lock the process to make sure it takes at lease 116 milliseconds per request.

#### Exception handling
A custom, Sdk4meException, is implemented. It will convert the API exception response to a string value.


# Sdk4meClient
### Minimum example
```csharp
using Sdk4me;

AuthenticationToken token = new AuthenticationToken("TheBearerToken");
Sdk4meClient client = new Sdk4meClient(token);
Person me = client.Me.Get();
Console.WriteLine($"{me.Name} ({me.PrimaryEmail})");
```

### Retrieve a single record
```csharp
Site site = client.Sites.Get(1324);
Console.WriteLine(site.Name);
```
By default, this will return all fields of the [site](https://developer.4me.com/v1/sites/#fields).

### Browse through a collection of items
```csharp
List<Request> requests = client.Requests.Get();
foreach (Request request in requests)
    Console.WriteLine(request.Subject);
Console.WriteLine($"Requests found: {requests.Count}");
```
This will return the default fields for a [request](https://developer.4me.com/v1/requests/#fields).

### Filtering
```csharp
List<ConfigurationItems> cis = client.ConfigurationItems.Get(
    new FilterCollection()
    {
        new Filter("Status", FilterCondition.Equality, ConfigurationItemStatus.BrokenDown),
        new Filter("CreatedAt", FilterCondition.GreaterThanOrEqualToAndLessThanOrEqualTo, new DateTime(2017, 1, 1), new DateTime(2019, 12, 31))
    }
);
foreach (ConfigurationItem ci in cis)
    Console.WriteLine(ci.Name);
```
This will return all [configuration items](https://developer.4me.com/v1/configuration_items/) created between 1 January 2017 and 31 December 2019 with a broken down status.

&nbsp;
```csharp
List<ProjectTaskTemplate> projectTaskTemplates = client.ProjectTaskTemplates.Get(PredefinedEnabledDisabledFilter.Enabled);
foreach (ProjectTaskTemplate projectTaskTemplate in projectTaskTemplates)
    Console.WriteLine(projectTaskTemplate.Subject);
```
This will return all enabled [project task templates](https://developer.4me.com/v1/project_task_templates/) using a predefined filter.

&nbsp;
```csharp
List<Person> people = client.People.Get(PredefinedPeopleFilter.Directory, new Filter("sourceID", FilterCondition.Present));
foreach (Person person in people)
    Console.WriteLine(person.PrimaryEmail);
```
This will return all [people](https://developer.4me.com/v1/people/) registered in the directory account of the support domain account from which the data is requested that have a sourceID value.

### Field selection
```csharp
List<Person> people = client.People.Get("CustomFields", "Manager", "SourceID");
foreach (Person person in people)
    Console.WriteLine($"The manager of {person.Name} is {(person.Manager != null ? person.Manager.Name : "unknown")}");
```
This will return all people and only load the CustomFields, Manager and SourceID fields.

&nbsp;
```csharp
people = client.People.Get("*");
foreach (Person person in people)
    Console.WriteLine($"{person.Name} {person.JobTitle}");
```
This will return all people and load all fields.

### Creating a record
```csharp
Person person = new Person()
{
    PrimaryEmail = "new.user@example.com",
    Organization = new Organization() { ID = 123 },
    Name = "New User (Example)"
    Site = new Site() { ID = 123 }
};
person = client.People.Insert(person);
```

### Update a record
```csharp
Organization organization = client.Organizations.Get(1234);
organization.Name = "A new name";
organization = client.Organizations.Update(organization);
```

### Delete a record
```csharp
Organization organization = client.Organizations.Get(1234);
List<Address> addresses = client.Organizations.GetAddresses(organization);
bool result = client.Organizations.DeleteAddress(organization, addresses[0]);
```
The client exposes a Delete and DeleteAll method. Those can only be used to delete child or relational objects not an object itself.

### Upload an attachment
```csharp
Request request = client.Requests.Get(123);
client.Requests.UploadAttachment(".\\HelloWorld.txt", "text/plain", out string key, out long size);
request.Note = "Please review the attached document";
request.ReferenceNoteAttachment(key, size, false);
request = client.Requests.Update(request);
```
The client will add a note with an attachment to the request.

&nbsp;
```csharp
Service service = client.Services.Get(123);
client.Services.UploadAttachment(".\\HelloWorld2.txt", "text/plain", out string key, out long size);
if (service.CustomFields.ContainsKey("an_attachment"))
    service.CustomFields["an_attachment"] = key;
else
    service.CustomFields.Add("an_attachment", key);
service.ReferenceCustomFieldAttachment(key, size);
service = client.Services.Update(service);
```
The client will add an attachment to a custom field of an existing service.

### Upload an inline attachment
```csharp
ProductBacklog backlog = client.ProductBacklogs.Get(123);
client.ProductBacklogs.UploadAttachment(".\\picture.png", "image/png", out string key, out long size);
backlog.ReferenceProductGoalAttachment(key, size, true);
backlog.ProductGoal = $"This is an embedded image. ![]({key}){{:filesize=\"{size}\" size=\"32x32\"}}";
backlog = client.ProductBacklogs.Update(backlog);
```
The client will updated the product goal description with a inline attachment.

### Deleting an attachment
```csharp
Person person = client.People.Get(123);
client.People.DeleteAttachment(person, AttachmentType.Information, person.Attachments[0]);
```
The client will delete the first information attachment.

### Exception handling
```csharp
try
{
    AuthenticationToken token = new AuthenticationToken("TheBearerToken");
    Sdk4meClient client = new Sdk4meClient(token);
    Person person = client.People.Get(new Filter("SourceID", FilterCondition.Equality, "123456"), "Team", "ThrowAnExceptionField").FirstOrDefault();
    List<Team> teams = client.People.GetTeams(person);
    foreach (Team team in teams)
        Console.WriteLine(team.Name);
}
catch (Sdk4meException ex)
{
    Console.WriteLine(ex.Message);
}
```
Returns a Sdk4meException with the following message: ```Unknown fields: throw_an_exception_field```

### Multi-token, accounts, environment usage and environment regions
```csharp
AuthenticationTokenCollection tokens = new AuthenticationTokenCollection()
{
    new AuthenticationToken("TheFirstBearerToken"),
    new AuthenticationToken("TheSecondBearerToken")
};
Sdk4meClient client = new Sdk4meClient(tokens, "account-name", EnvironmentType.Production, EnvironmentRegion.Global);
```
