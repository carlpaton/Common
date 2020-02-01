# Serialization

[Back](../../../../)

Serialization is the conversion of a in-memory .NET object to another format such as XML, JSON, etc. so that they can be stored or transmitted. This format is usually text i.e. a string of characters.

> Serialization is the process of translating data structures or object state into a format that can be stored (for example, in a file or memory buffer, or transmitted across a network connection link) and reconstructed later in the same or another computer environment. - Wikipedia

**Interface**: `IDataContractJsonSerializerService`

### ToJson

System.Runtime.Serialization.Json.DataContractJsonSerializer

An older, Microsoft-developed serializer that was integrated in previous ASP.NET versions until Newtonsoft.Json replaced it.

https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/json-serialization

```c#
string ToJson<T>(object obj);
```

**Interface**: `IJsonConvertService`

### ToJson

Newtonsoft.Json.JsonConvert

Serializes the specified object to a JSON string.

```c#
string ToJson(object obj);
```

### ToObject

Newtonsoft.Json.JsonConvert

Deserializes the JSON to the specified .NET type.

```c#
T ToObject<T>(string responseString);
```

### XmlFileToObject

Newtonsoft.Json.JsonConvert

This was useful when converting XML files (packages.config, [x].csproj) to object

* postedFile: IFormFile used in .net core 2x MVC project

```c#
T XmlFileToObject<T>(IFormFile postedFile);
```

