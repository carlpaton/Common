# Http

[Back](../../../../)

**Interface**: `IHttpService`

### Get

```c#
T Get<T>(string endPoint);
```

### Post

`payLoad` parameter is serialized with `JsonConvert`

```c#
T Post<T>(string endPoint, object payLoad);
```

### Post

`serializedPayLoad` parameter needs to be serialized with `DataContractJsonSerializer`

```c#
T Post<T>(string endPoint, string serializedPayLoad);
```

