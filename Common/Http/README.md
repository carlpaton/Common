# Http

[Back](../../../../)

**Interface**: `IHttpWebRequestFactory`

### Create

```c#
IHttpWebRequest Create(string uri);
```

Example use

```c#
var request = _httpWebRequestFactory.Create(endPoint);
request.Method = WebRequestMethods.Http.Get;
request.ContentType = HttpConstants.JsonContentType;

// Optional headers
// Use `HttpHeaderService` and `AuthorizationModelService` to create `httpHeaderModel`
HttpHeaderModel httpHeaderModel;
request.SetHeader(httpHeaderModel)

using (var response = request.GetResponse())
{
    using (var streamReader = new StreamReader(response.GetResponseStream()))
    {
        var responseString = streamReader.ReadToEnd();
		...
```

