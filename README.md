# Cross-Cutting
Cross-Cutting is a common methods provided by a specific layer or service used by all layers of an application. It would be like a layer/service that crosses the entire hierarchy.


| Package |  Version | Downloads |
| ------- | ----- | ----- |
| `Cross-Cutting` | [![NuGet](https://img.shields.io/nuget/v/Cross-Cutting.svg)](https://nuget.org/packages/cross-ctting) | [![Nuget](https://img.shields.io/nuget/dt/cross-cutting.svg)](https://nuget.org/packages/Cross-Cutting) |


### Dependencies
.NET Standard 2.1

You can check supported frameworks here:

https://learn.microsoft.com/pt-br/dotnet/standard/net-standard?tabs=net-standard-2-1

### Instalation
This package is available through Nuget Packages: https://www.nuget.org/packages/cross-cutting


**Nuget**
```
Install-Package Cross-Cutting
```

**.NET CLI**
```
dotnet add package Cross-Cutting
```

## How to use
### Serialize
```csharp
Person person = new Person("Raphael", "Bressam");
var jsonString = JsonParser.Serialize(person);
```
### Deserialize
```csharp
string jsonString = "{ \"first_name\":\"Raphael\", \"last_name\":\"Bressam\" }";
Person person = JsonParser.Deserialize<Person>(jsonString);
```
