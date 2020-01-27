# Authorization

[Back](../../../../../)

HTTP header Authorization.

**Interface**: `IAuthorizationModelService`

### GetBasicAuthModel

Parameters come from `Configuration.GetSection("X").Value` in the consumers `Startup.cs`

If null or empty reads `Environment.GetEnvironmentVariable("X")`

```c#
BasicAuthModel GetBasicAuthModel(string usernameBasic,  string passwordBasic);
```

### GetOAuthModel

Parameter object values come from `Configuration.GetSection("X").Value` in the consumers `Startup.cs`

If null or empty reads `Environment.GetEnvironmentVariable("X")`

```c#
OAuthModel GetOAuthModel(OAuthAppsettingsModel oAuthAppsettingsModel, System.DateTime dateTimeNow, IElapsedTimeService elapsedTimeService, IEncodingService encodingService);
```

**Interface**: `IHttpHeaderService`

### OAuth

OAuth is an authorization method used to provide access to resources over the HTTP protocol.

https://oauth.net/core/1.0/

```c#
HttpHeaderModel OAuth(OAuthModel oAuthModel);
```

### BasicAuth

The Basic authentication is a common method to provide a username and password to a service.

* encodedAuthorization

Base64 Encoded string in format `username:password`

```c#
HttpHeaderModel BasicAuth(string encodedAuthorization);
```

