# Namespace: RestSharp
## Class `DeserializationException`

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `System.Exception`

### Inherited members

### Syntax
```csharp
public class DeserializationException : Exception, ISerializable
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `DeserializationException(IRestResponse, Exception)`

#### Syntax
```csharp
public DeserializationException(IRestResponse response, Exception innerException)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`response` | `RestSharp.IRestResponse` | 
`innerException` | `System.Exception` | 



### Property `Response`

#### Syntax
```csharp
public IRestResponse Response { get; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



## Enum `ParameterType`

Types of parameters that can be added to requests

### Syntax
```csharp
public enum ParameterType
```

### Fields
Name | Description
--- | ---
Cookie | Cookie parameter
GetOrPost | 
UrlSegment | 
HttpHeader | 
RequestBody | 
QueryString | 
QueryStringWithoutEncode | 
## Enum `DataFormat`

Data formats

### Syntax
```csharp
public enum DataFormat
```

### Fields
Name | Description
--- | ---
Json | 
Xml | 
None | 
## Enum `Method`

HTTP method to use when making requests

### Syntax
```csharp
public enum Method
```

### Fields
Name | Description
--- | ---
GET | 
POST | 
PUT | 
DELETE | 
HEAD | 
OPTIONS | 
PATCH | 
MERGE | 
COPY | 
Struct: RestSharp.DateFormat
ISO_8601 | .NET format string for ISO 8601 date format
ROUND_TRIP | .NET format string for roundtrip date format
## Enum `ResponseStatus`

Status for responses (surprised?)

### Syntax
```csharp
public enum ResponseStatus
```

### Fields
Name | Description
--- | ---
None | 
Completed | 
Error | 
TimedOut | 
Aborted | 
## Class `FileParameter`

Container for files to be uploaded with requests

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class FileParameter
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `ContentLength`

The length of data to be sent

#### Syntax
```csharp
public long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `Writer`

Provides raw data for file

#### Syntax
```csharp
public Action<Stream> Writer { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `FileName`

Name of the file to use when uploading

#### Syntax
```csharp
public string FileName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentType`

MIME content type of file

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Name`

Name of the parameter

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Method `Create(String, Byte[], String, String)`

#### Syntax
```csharp
public static FileParameter Create(string name, byte[] data, string filename, string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`data` | `byte[]` | 
`filename` | `string` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.FileParameter` | 



### Method `Create(String, Byte[], String)`

#### Syntax
```csharp
public static FileParameter Create(string name, byte[] data, string filename)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`data` | `byte[]` | 
`filename` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.FileParameter` | 



### Method `Create(String, Action<Stream>, Int64, String, String)`

#### Syntax
```csharp
public static FileParameter Create(string name, Action<Stream> writer, long contentLength, string fileName, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`writer` | `System.Action<System.IO.Stream>` | 
`contentLength` | `long` | 
`fileName` | `string` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.FileParameter` | 



## Class `Http`

HttpWebRequest wrapper (async methods)

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class Http : IHttp
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Method `AsPostAsync(Action<HttpResponse>, String)`

Execute an async POST-style request with the specified HTTP Method.

#### Syntax
```csharp
public HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 
`httpMethod` | `string` | The HTTP method to execute.

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `AsGetAsync(Action<HttpResponse>, String)`

Execute an async GET-style request with the specified HTTP Method.

#### Syntax
```csharp
public HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 
`httpMethod` | `string` | The HTTP method to execute.

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Constructor `Http()`

Default constructor

#### Syntax
```csharp
public Http()
```


### Property `HasParameters`

True if this HTTP request has any HTTP parameters

#### Syntax
```csharp
protected bool HasParameters { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `HasCookies`

True if this HTTP request has any HTTP cookies

#### Syntax
```csharp
protected bool HasCookies { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `HasBody`

True if a request body has been specified

#### Syntax
```csharp
protected bool HasBody { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `HasFiles`

True if files have been set to be uploaded

#### Syntax
```csharp
protected bool HasFiles { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `AutomaticDecompression`

Enable or disable automatic gzip/deflate decompression

#### Syntax
```csharp
public bool AutomaticDecompression { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `AlwaysMultipartFormData`

Always send a multipart/form-data request - even when no Files are present.

#### Syntax
```csharp
public bool AlwaysMultipartFormData { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UserAgent`

UserAgent to be sent with request

#### Syntax
```csharp
public string UserAgent { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Timeout`

Timeout in milliseconds to be used for the request

#### Syntax
```csharp
public int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

The number of milliseconds before the writing or reading times out.

#### Syntax
```csharp
public int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `Credentials`

System.Net.ICredentials to be sent with request

#### Syntax
```csharp
public ICredentials Credentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`ICredentials` | 



### Property `CookieContainer`

The System.Net.CookieContainer to be used for the request

#### Syntax
```csharp
public CookieContainer CookieContainer { get; set; }
```
#### Property value
Type | Description
--- | ---
`CookieContainer` | 



### Property `AdvancedResponseWriter`

The delegate to use to write the response instead of reading into RawBytes
Here you can also check the request details

#### Syntax
```csharp
public Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream, RestSharp.IHttpResponse>` | 



### Property `ResponseWriter`

The delegate to use to write the response instead of reading into RawBytes

#### Syntax
```csharp
public Action<Stream> ResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `Files`

Collection of files to be sent with request

#### Syntax
```csharp
public IList<HttpFile> Files { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpFile>` | 



### Property `FollowRedirects`

Whether or not HTTP 3xx response redirects should be automatically followed

#### Syntax
```csharp
public bool FollowRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Pipelined`

Whether or not to use pipelined connections

#### Syntax
```csharp
public bool Pipelined { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ClientCertificates`

X509CertificateCollection to be sent with request

#### Syntax
```csharp
public X509CertificateCollection ClientCertificates { get; set; }
```
#### Property value
Type | Description
--- | ---
`X509CertificateCollection` | 



### Property `MaxRedirects`

Maximum number of automatic redirects to follow if FollowRedirects is true

#### Syntax
```csharp
public int? MaxRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`int?` | 



### Property `UseDefaultCredentials`

Determine whether or not the &quot;default credentials&quot; (e.g. the user account under which the current process is
running) ///     will be sent along to the server.

#### Syntax
```csharp
public bool UseDefaultCredentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ConnectionGroupName`

The ConnectionGroupName property enables you to associate a request with a connection group.

#### Syntax
```csharp
public string ConnectionGroupName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Encoding`

Encoding for the request, UTF8 is the default

#### Syntax
```csharp
public Encoding Encoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Text.Encoding` | 



### Property `Headers`

HTTP headers to be sent with request

#### Syntax
```csharp
public IList<HttpHeader> Headers { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpHeader>` | 



### Property `Parameters`

HTTP parameters (QueryString or Form values) to be sent with request

#### Syntax
```csharp
public IList<HttpParameter> Parameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpParameter>` | 



### Property `Cookies`

HTTP cookies to be sent with request

#### Syntax
```csharp
public IList<HttpCookie> Cookies { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpCookie>` | 



### Property `RequestBody`

Request body to be sent with request

#### Syntax
```csharp
public string RequestBody { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestContentType`

Content type of the request body.

#### Syntax
```csharp
public string RequestContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestBodyBytes`

An alternative to RequestBody, for when the caller already has the byte array.

#### Syntax
```csharp
public byte[] RequestBodyBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `Url`

URL to call for this request

#### Syntax
```csharp
public Uri Url { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Host`

Explicit Host header value to use in requests independent from the request URI.
If null, default host value extracted from URI is used.

#### Syntax
```csharp
public string Host { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `AllowedDecompressionMethods`

List of Allowed Decompression Methods

#### Syntax
```csharp
public IList<DecompressionMethods> AllowedDecompressionMethods { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<DecompressionMethods>` | 



### Property `PreAuthenticate`

Flag to send authorisation header with the HttpWebRequest

#### Syntax
```csharp
public bool PreAuthenticate { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UnsafeAuthenticatedConnectionSharing`

Flag to reuse same connection in the HttpWebRequest

#### Syntax
```csharp
public bool UnsafeAuthenticatedConnectionSharing { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Proxy`

Proxy info to be sent with request

#### Syntax
```csharp
public IWebProxy Proxy { get; set; }
```
#### Property value
Type | Description
--- | ---
`IWebProxy` | 



### Property `CachePolicy`

Caching policy for requests created with this wrapper.

#### Syntax
```csharp
public RequestCachePolicy CachePolicy { get; set; }
```
#### Property value
Type | Description
--- | ---
`RequestCachePolicy` | 



### Property `RemoteCertificateValidationCallback`

Callback function for handling the validation of remote certificates.

#### Syntax
```csharp
public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
```
#### Property value
Type | Description
--- | ---
`RemoteCertificateValidationCallback` | 



### Property `WebRequestConfigurator`

#### Syntax
```csharp
public Action<HttpWebRequest> WebRequestConfigurator { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<HttpWebRequest>` | 



### Method `Create()`

Creates an IHttp

#### Syntax
```csharp
[Obsolete]
public static IHttp Create()
```
#### Returns
Type | Description
--- | ---
`RestSharp.IHttp` | 



### Method `CreateWebRequest(Uri)`

#### Syntax
```csharp
[Obsolete("Overriding this method won't be possible in future version")]
protected virtual HttpWebRequest CreateWebRequest(Uri url)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`url` | `Uri` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `Post()`

Execute a POST request

#### Syntax
```csharp
public HttpResponse Post()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Put()`

Execute a PUT request

#### Syntax
```csharp
public HttpResponse Put()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Get()`

Execute a GET request

#### Syntax
```csharp
public HttpResponse Get()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Head()`

Execute a HEAD request

#### Syntax
```csharp
public HttpResponse Head()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Options()`

Execute an OPTIONS request

#### Syntax
```csharp
public HttpResponse Options()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Delete()`

Execute a DELETE request

#### Syntax
```csharp
public HttpResponse Delete()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Patch()`

Execute a PATCH request

#### Syntax
```csharp
public HttpResponse Patch()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Merge()`

Execute a MERGE request

#### Syntax
```csharp
public HttpResponse Merge()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `AsGet(String)`

Execute a GET-style request with the specified HTTP Method.

#### Syntax
```csharp
public HttpResponse AsGet(string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`httpMethod` | `string` | The HTTP method to execute.

#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `AsPost(String)`

Execute a POST-style request with the specified HTTP Method.

#### Syntax
```csharp
public HttpResponse AsPost(string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`httpMethod` | `string` | The HTTP method to execute.

#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `ConfigureWebRequest(String, Uri)`

#### Syntax
```csharp
[Obsolete("Use the WebRequestConfigurator delegate instead of overriding this method")]
protected virtual HttpWebRequest ConfigureWebRequest(string method, Uri url)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`method` | `string` | 
`url` | `Uri` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `DeleteAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest DeleteAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `GetAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest GetAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `HeadAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest HeadAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `OptionsAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest OptionsAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PostAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest PostAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PutAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest PutAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PatchAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest PatchAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `MergeAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
public HttpWebRequest MergeAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `ConfigureAsyncWebRequest(String, Uri)`

#### Syntax
```csharp
[Obsolete("Use the WebRequestConfigurator delegate instead of overriding this method")]
protected virtual HttpWebRequest ConfigureAsyncWebRequest(string method, Uri url)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`method` | `string` | 
`url` | `Uri` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



## Class `HttpCookie`

Representation of an HTTP cookie

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class HttpCookie
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `Comment`

Comment of the cookie

#### Syntax
```csharp
public string Comment { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `CommentUri`

Comment of the cookie

#### Syntax
```csharp
public Uri CommentUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Discard`

Indicates whether the cookie should be discarded at the end of the session

#### Syntax
```csharp
public bool Discard { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Domain`

Domain of the cookie

#### Syntax
```csharp
public string Domain { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Expired`

Indicates whether the cookie is expired

#### Syntax
```csharp
public bool Expired { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Expires`

Date and time that the cookie expires

#### Syntax
```csharp
public DateTime Expires { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.DateTime` | 



### Property `HttpOnly`

Indicates that this cookie should only be accessed by the server

#### Syntax
```csharp
public bool HttpOnly { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Name`

Name of the cookie

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Path`

Path of the cookie

#### Syntax
```csharp
public string Path { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Port`

Port of the cookie

#### Syntax
```csharp
public string Port { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Secure`

Indicates that the cookie should only be sent over secure channels

#### Syntax
```csharp
public bool Secure { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `TimeStamp`

Date and time the cookie was created

#### Syntax
```csharp
public DateTime TimeStamp { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.DateTime` | 



### Property `Value`

Value of the cookie

#### Syntax
```csharp
public string Value { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Version`

Version of the cookie

#### Syntax
```csharp
public int Version { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



## Class `HttpFile`

Container for HTTP file

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class HttpFile
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `ContentLength`

The length of data to be sent

#### Syntax
```csharp
public long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `Writer`

Provides raw data for file

#### Syntax
```csharp
public Action<Stream> Writer { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `FileName`

Name of the file to use when uploading

#### Syntax
```csharp
public string FileName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentType`

MIME content type of file

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Name`

Name of the parameter

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



## Class `HttpHeader`

Representation of an HTTP header

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class HttpHeader
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `Name`

Name of the header

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Value`

Value of the header

#### Syntax
```csharp
public string Value { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



## Class `HttpParameter`

Representation of an HTTP parameter (QueryString or Form value)

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class HttpParameter
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `Name`

Name of the parameter

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Value`

Value of the parameter

#### Syntax
```csharp
public string Value { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentType`

Content-Type of the parameter

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



## Class `HttpResponse`

HTTP response data

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class HttpResponse : IHttpResponse
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `HttpResponse()`

Default constructor

#### Syntax
```csharp
public HttpResponse()
```


### Property `ContentType`

MIME content type of response

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentLength`

Length in bytes of the response content

#### Syntax
```csharp
public long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `ContentEncoding`

Encoding of the response content

#### Syntax
```csharp
public string ContentEncoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Content`

Lazy-loaded string representation of response content

#### Syntax
```csharp
public string Content { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `StatusCode`

HTTP response status code

#### Syntax
```csharp
public HttpStatusCode StatusCode { get; set; }
```
#### Property value
Type | Description
--- | ---
`HttpStatusCode` | 



### Property `StatusDescription`

Description of HTTP status returned

#### Syntax
```csharp
public string StatusDescription { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RawBytes`

Response content

#### Syntax
```csharp
public byte[] RawBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `ResponseUri`

The URL that actually responded to the content (different from request if redirected)

#### Syntax
```csharp
public Uri ResponseUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Server`

HttpWebResponse.Server

#### Syntax
```csharp
public string Server { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Headers`

Headers returned by server with the response

#### Syntax
```csharp
public IList<HttpHeader> Headers { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpHeader>` | 



### Property `Cookies`

Cookies returned by server with the response

#### Syntax
```csharp
public IList<HttpCookie> Cookies { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpCookie>` | 



### Property `ResponseStatus`

Status of the request. Will return Error for transport errors.
HTTP errors will still return ResponseStatus.Completed, check StatusCode instead

#### Syntax
```csharp
public ResponseStatus ResponseStatus { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.ResponseStatus` | 



### Property `ErrorMessage`

Transport or other non-HTTP error generated while attempting request

#### Syntax
```csharp
public string ErrorMessage { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ErrorException`

Exception thrown when error is encountered.

#### Syntax
```csharp
public Exception ErrorException { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Exception` | 



### Property `ProtocolVersion`

The HTTP protocol version (1.0, 1.1, etc)

#### Remarks
Only set when underlying framework supports it.
#### Syntax
```csharp
public Version ProtocolVersion { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Version` | 



## Interface `IHttp`


### Inherited members

### Syntax
```csharp
public interface IHttp
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `ResponseWriter`

#### Syntax
```csharp
Action<Stream> ResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `AdvancedResponseWriter`

#### Syntax
```csharp
Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream, RestSharp.IHttpResponse>` | 



### Property `CookieContainer`

#### Syntax
```csharp
CookieContainer CookieContainer { get; set; }
```
#### Property value
Type | Description
--- | ---
`CookieContainer` | 



### Property `Credentials`

#### Syntax
```csharp
ICredentials Credentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`ICredentials` | 



### Property `AutomaticDecompression`

Enable or disable automatic gzip/deflate decompression

#### Syntax
```csharp
bool AutomaticDecompression { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `AlwaysMultipartFormData`

Always send a multipart/form-data request - even when no Files are present.

#### Syntax
```csharp
bool AlwaysMultipartFormData { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UserAgent`

#### Syntax
```csharp
string UserAgent { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Timeout`

#### Syntax
```csharp
int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

#### Syntax
```csharp
int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `FollowRedirects`

#### Syntax
```csharp
bool FollowRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Pipelined`

#### Syntax
```csharp
bool Pipelined { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ClientCertificates`

#### Syntax
```csharp
X509CertificateCollection ClientCertificates { get; set; }
```
#### Property value
Type | Description
--- | ---
`X509CertificateCollection` | 



### Property `MaxRedirects`

#### Syntax
```csharp
int? MaxRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`int?` | 



### Property `UseDefaultCredentials`

#### Syntax
```csharp
bool UseDefaultCredentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Encoding`

#### Syntax
```csharp
Encoding Encoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Text.Encoding` | 



### Property `Headers`

#### Syntax
```csharp
IList<HttpHeader> Headers { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpHeader>` | 



### Property `Parameters`

#### Syntax
```csharp
IList<HttpParameter> Parameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpParameter>` | 



### Property `Files`

#### Syntax
```csharp
IList<HttpFile> Files { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpFile>` | 



### Property `Cookies`

#### Syntax
```csharp
IList<HttpCookie> Cookies { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpCookie>` | 



### Property `RequestBody`

#### Syntax
```csharp
string RequestBody { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestContentType`

#### Syntax
```csharp
string RequestContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `PreAuthenticate`

#### Syntax
```csharp
bool PreAuthenticate { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UnsafeAuthenticatedConnectionSharing`

#### Syntax
```csharp
bool UnsafeAuthenticatedConnectionSharing { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `CachePolicy`

#### Syntax
```csharp
RequestCachePolicy CachePolicy { get; set; }
```
#### Property value
Type | Description
--- | ---
`RequestCachePolicy` | 



### Property `ConnectionGroupName`

#### Syntax
```csharp
string ConnectionGroupName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestBodyBytes`

An alternative to RequestBody, for when the caller already has the byte array.

#### Syntax
```csharp
byte[] RequestBodyBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `Url`

#### Syntax
```csharp
Uri Url { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Host`

#### Syntax
```csharp
string Host { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `AllowedDecompressionMethods`

#### Syntax
```csharp
IList<DecompressionMethods> AllowedDecompressionMethods { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<DecompressionMethods>` | 



### Property `Proxy`

#### Syntax
```csharp
IWebProxy Proxy { get; set; }
```
#### Property value
Type | Description
--- | ---
`IWebProxy` | 



### Property `RemoteCertificateValidationCallback`

#### Syntax
```csharp
RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
```
#### Property value
Type | Description
--- | ---
`RemoteCertificateValidationCallback` | 



### Property `WebRequestConfigurator`

#### Syntax
```csharp
Action<HttpWebRequest> WebRequestConfigurator { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<HttpWebRequest>` | 



### Method `DeleteAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest DeleteAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `GetAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest GetAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `HeadAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest HeadAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `OptionsAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest OptionsAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PostAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest PostAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PutAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest PutAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `PatchAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest PatchAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `MergeAsync(Action<HttpResponse>)`

#### Syntax
```csharp
[Obsolete]
HttpWebRequest MergeAsync(Action<HttpResponse> action)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `AsPostAsync(Action<HttpResponse>, String)`

#### Syntax
```csharp
HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `AsGetAsync(Action<HttpResponse>, String)`

#### Syntax
```csharp
HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`action` | `System.Action<RestSharp.HttpResponse>` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`HttpWebRequest` | 



### Method `Delete()`

#### Syntax
```csharp
HttpResponse Delete()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Get()`

#### Syntax
```csharp
HttpResponse Get()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Head()`

#### Syntax
```csharp
HttpResponse Head()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Options()`

#### Syntax
```csharp
HttpResponse Options()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Post()`

#### Syntax
```csharp
HttpResponse Post()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Put()`

#### Syntax
```csharp
HttpResponse Put()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Patch()`

#### Syntax
```csharp
HttpResponse Patch()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `Merge()`

#### Syntax
```csharp
HttpResponse Merge()
```
#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `AsPost(String)`

#### Syntax
```csharp
HttpResponse AsPost(string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



### Method `AsGet(String)`

#### Syntax
```csharp
HttpResponse AsGet(string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.HttpResponse` | 



## Interface `IHttpResponse`

HTTP response data


### Inherited members

### Syntax
```csharp
public interface IHttpResponse
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `ContentType`

MIME content type of response

#### Syntax
```csharp
string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentLength`

Length in bytes of the response content

#### Syntax
```csharp
long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `ContentEncoding`

Encoding of the response content

#### Syntax
```csharp
string ContentEncoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Content`

String representation of response content

#### Syntax
```csharp
string Content { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `StatusCode`

HTTP response status code

#### Syntax
```csharp
HttpStatusCode StatusCode { get; set; }
```
#### Property value
Type | Description
--- | ---
`HttpStatusCode` | 



### Property `StatusDescription`

Description of HTTP status returned

#### Syntax
```csharp
string StatusDescription { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RawBytes`

Response content

#### Syntax
```csharp
byte[] RawBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `ResponseUri`

The URL that actually responded to the content (different from request if redirected)

#### Syntax
```csharp
Uri ResponseUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Server`

HttpWebResponse.Server

#### Syntax
```csharp
string Server { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Headers`

Headers returned by server with the response

#### Syntax
```csharp
IList<HttpHeader> Headers { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpHeader>` | 



### Property `Cookies`

Cookies returned by server with the response

#### Syntax
```csharp
IList<HttpCookie> Cookies { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.HttpCookie>` | 



### Property `ResponseStatus`

Status of the request. Will return Error for transport errors.
HTTP errors will still return ResponseStatus.Completed, check StatusCode instead

#### Syntax
```csharp
ResponseStatus ResponseStatus { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.ResponseStatus` | 



### Property `ErrorMessage`

Transport or other non-HTTP error generated while attempting request

#### Syntax
```csharp
string ErrorMessage { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ErrorException`

Exception thrown when error is encountered.

#### Syntax
```csharp
Exception ErrorException { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Exception` | 



### Property `ProtocolVersion`

The HTTP protocol version (1.0, 1.1, etc)

#### Remarks
Only set when underlying framework supports it.
#### Syntax
```csharp
Version ProtocolVersion { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Version` | 



## Interface `IRestClient`


### Inherited members

### Syntax
```csharp
public interface IRestClient
```

### Extension methods
-  `RestSharp.RestClientExtensions.ExecuteAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse>)`
-  `RestSharp.RestClientExtensions.ExecuteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>>)`
-  `RestSharp.RestClientExtensions.GetAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PostAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PutAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.HeadAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.OptionsAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PatchAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.DeleteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.GetAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PostAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PutAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.HeadAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.OptionsAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PatchAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.DeleteAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.GetTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PostTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PutTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.HeadTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.OptionsTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PatchTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.DeleteTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.ExecuteDynamic(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.GetAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PostAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PutAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.HeadAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.OptionsAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PatchAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.DeleteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.Get<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Post<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Put<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Head<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Options<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Patch<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Delete<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Get(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Post(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Put(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Head(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Options(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Patch(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Delete(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, RestSharp.Parameter)`
-  `RestSharp.RestClientExtensions.AddOrUpdateDefaultParameter(RestSharp.IRestClient, RestSharp.Parameter)`
-  `RestSharp.RestClientExtensions.RemoveDefaultParameter(RestSharp.IRestClient, string)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, string, object)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, string, object, RestSharp.ParameterType)`
-  `RestSharp.RestClientExtensions.AddDefaultHeader(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientExtensions.AddDefaultHeaders(RestSharp.IRestClient, System.Collections.Generic.Dictionary<string, string>)`
-  `RestSharp.RestClientExtensions.AddDefaultUrlSegment(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientExtensions.AddDefaultQueryParameter(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientJsonRequest.Get<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Post<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Put<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Head<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Options<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Patch<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Delete<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Serialization.Xml.DotNetXmlSerializerClientExtensions.UseDotNetXmlSerializer(RestSharp.IRestClient, string, System.Text.Encoding)`
### Method `UseSerializer(Func<IRestSerializer>)`

The UseSerializer method.

#### Syntax
```csharp
IRestClient UseSerializer(Func<IRestSerializer> serializerFactory)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`serializerFactory` | `System.Func<RestSharp.Serialization.IRestSerializer>` | The serializer factory

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseSerializer<T>()`

Replace the default serializer with a custom one

#### Syntax
```csharp
IRestClient UseSerializer<T>()
    where T : IRestSerializer, new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | The type that implements IRestSerializer

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Property `CookieContainer`

#### Syntax
```csharp
CookieContainer CookieContainer { get; set; }
```
#### Property value
Type | Description
--- | ---
`CookieContainer` | 



### Property `AutomaticDecompression`

#### Syntax
```csharp
bool AutomaticDecompression { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `MaxRedirects`

#### Syntax
```csharp
int? MaxRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`int?` | 



### Property `UserAgent`

#### Syntax
```csharp
string UserAgent { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Timeout`

#### Syntax
```csharp
int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

#### Syntax
```csharp
int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `UseSynchronizationContext`

#### Syntax
```csharp
bool UseSynchronizationContext { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Authenticator`

#### Syntax
```csharp
IAuthenticator Authenticator { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Authenticators.IAuthenticator` | 



### Property `BaseUrl`

#### Syntax
```csharp
Uri BaseUrl { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Encoding`

#### Syntax
```csharp
Encoding Encoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Text.Encoding` | 



### Property `ThrowOnDeserializationError`

#### Syntax
```csharp
bool ThrowOnDeserializationError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `FailOnDeserializationError`

Modifies the default behavior of RestSharp to swallow exceptions.
When set to <pre><code>true</code></pre>, RestSharp will consider the request as unsuccessful
in case it fails to deserialize the response.

#### Syntax
```csharp
bool FailOnDeserializationError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ThrowOnAnyError`

Modifies the default behavior of RestSharp to swallow exceptions.
When set to <pre><code>true</code></pre>, exceptions will be re-thrown.

#### Syntax
```csharp
bool ThrowOnAnyError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ConnectionGroupName`

#### Syntax
```csharp
string ConnectionGroupName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `PreAuthenticate`

Flag to send authorisation header with the HttpWebRequest

#### Syntax
```csharp
bool PreAuthenticate { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UnsafeAuthenticatedConnectionSharing`

Flag to reuse same connection in the HttpWebRequest

#### Syntax
```csharp
bool UnsafeAuthenticatedConnectionSharing { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `DefaultParameters`

A list of parameters that will be set for all requests made
by the RestClient instance.

#### Syntax
```csharp
IList<Parameter> DefaultParameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.Parameter>` | 



### Property `BaseHost`

Explicit Host header value to use in requests independent from the request URI.
If null, default host value extracted from URI is used.

#### Syntax
```csharp
string BaseHost { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `AllowMultipleDefaultParametersWithSameName`

By default, RestSharp doesn&apos;t allow multiple parameters to have the same name.
This properly allows to override the default behavior.

#### Syntax
```csharp
bool AllowMultipleDefaultParametersWithSameName { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ClientCertificates`

X509CertificateCollection to be sent with request

#### Syntax
```csharp
X509CertificateCollection ClientCertificates { get; set; }
```
#### Property value
Type | Description
--- | ---
`X509CertificateCollection` | 



### Property `Proxy`

#### Syntax
```csharp
IWebProxy Proxy { get; set; }
```
#### Property value
Type | Description
--- | ---
`IWebProxy` | 



### Property `CachePolicy`

#### Syntax
```csharp
RequestCachePolicy CachePolicy { get; set; }
```
#### Property value
Type | Description
--- | ---
`RequestCachePolicy` | 



### Property `Pipelined`

#### Syntax
```csharp
bool Pipelined { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `FollowRedirects`

#### Syntax
```csharp
bool FollowRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `RemoteCertificateValidationCallback`

Callback function for handling the validation of remote certificates. Useful for certificate pinning and
overriding certificate errors in the scope of a request.

#### Syntax
```csharp
RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
```
#### Property value
Type | Description
--- | ---
`RemoteCertificateValidationCallback` | 



### Method `Deserialize<T>(IRestResponse)`

#### Syntax
```csharp
IRestResponse<T> Deserialize<T>(IRestResponse response)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`response` | `RestSharp.IRestResponse` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `UseUrlEncoder(Func<String, String>)`

Allows to use a custom way to encode URL parameters

#### Examples
```csharp
client.UseUrlEncoder(s => HttpUtility.UrlEncode(s));
```
#### Syntax
```csharp
IRestClient UseUrlEncoder(Func<string, string> encoder)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`encoder` | `System.Func<string, string>` | A delegate to encode URL parameters

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseQueryEncoder(Func<String, Encoding, String>)`

Allows to use a custom way to encode query parameters

#### Examples
```csharp
client.UseUrlEncoder((s, encoding) => HttpUtility.UrlEncode(s, encoding));
```
#### Syntax
```csharp
IRestClient UseQueryEncoder(Func<string, Encoding, string> queryEncoder)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`queryEncoder` | `System.Func<string, System.Text.Encoding, string>` | A delegate to encode query parameters

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `Execute(IRestRequest)`

Executes the given request and returns an untyped response.

#### Syntax
```csharp
IRestResponse Execute(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Pre-configured request instance.

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | Untyped response.



### Method `Execute(IRestRequest, Method)`

Executes the given request and returns an untyped response.
Allows to specify the HTTP method (GET, POST, etc) so you won&apos;t need to set it on the request.

#### Syntax
```csharp
IRestResponse Execute(IRestRequest request, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Pre-configured request instance.
`httpMethod` | `RestSharp.Method` | The HTTP method (GET, POST, etc) to be used when making the request.

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | Untyped response.



### Method `Execute<T>(IRestRequest)`

Executes the given request and returns a typed response.
RestSharp will deserialize the response and it will be available in the <pre><code>Data</code></pre>
property of the response instance.

#### Syntax
```csharp
IRestResponse<T> Execute<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Pre-configured request instance.

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | Typed response.



### Method `Execute<T>(IRestRequest, Method)`

Executes the given request and returns a typed response.
RestSharp will deserialize the response and it will be available in the <pre><code>Data</code></pre>
property of the response instance.
Allows to specify the HTTP method (GET, POST, etc) so you won&apos;t need to set it on the request.

#### Syntax
```csharp
IRestResponse<T> Execute<T>(IRestRequest request, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Pre-configured request instance.
`httpMethod` | `RestSharp.Method` | The HTTP method (GET, POST, etc) to be used when making the request.

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | Typed response.



### Method `DownloadData(IRestRequest)`

A specialized method to download files.

#### Syntax
```csharp
byte[] DownloadData(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Pre-configured request instance.

#### Returns
Type | Description
--- | ---
`byte[]` | The downloaded file.



### Method `DownloadData(IRestRequest, Boolean)`

#### Syntax
```csharp
[Obsolete("Use ThrowOnAnyError property to instruct RestSharp to rethrow exceptions")]
byte[] DownloadData(IRestRequest request, bool throwOnError)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`throwOnError` | `bool` | 

#### Returns
Type | Description
--- | ---
`byte[]` | 



### Method `BuildUri(IRestRequest)`

#### Syntax
```csharp
Uri BuildUri(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`Uri` | 



### Method `BuildUriWithoutQueryParameters(IRestRequest)`

#### Syntax
```csharp
string BuildUriWithoutQueryParameters(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`string` | 



### Method `ConfigureWebRequest(Action<HttpWebRequest>)`

Add a delegate to apply custom configuration to HttpWebRequest before making a call

#### Syntax
```csharp
void ConfigureWebRequest(Action<HttpWebRequest> configurator)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`configurator` | `System.Action<HttpWebRequest>` | Configuration delegate for HttpWebRequest



### Method `AddHandler(String, Func<IDeserializer>)`

Adds or replaces a deserializer for the specified content type

#### Syntax
```csharp
void AddHandler(string contentType, Func<IDeserializer> deserializerFactory)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | Content type for which the deserializer will be replaced
`deserializerFactory` | `System.Func<RestSharp.Deserializers.IDeserializer>` | Custom deserializer factory



### Method `RemoveHandler(String)`

Removes custom deserialzier for the specified content type

#### Syntax
```csharp
void RemoveHandler(string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | Content type for which deserializer needs to be removed



### Method `ClearHandlers()`

Remove deserializers for all content types

#### Syntax
```csharp
void ClearHandlers()
```


### Method `ExecuteAsGet(IRestRequest, String)`

#### Syntax
```csharp
IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `ExecuteAsPost(IRestRequest, String)`

#### Syntax
```csharp
IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `ExecuteAsGet<T>(IRestRequest, String)`

#### Syntax
```csharp
IRestResponse<T> ExecuteAsGet<T>(IRestRequest request, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `ExecuteAsPost<T>(IRestRequest, String)`

#### Syntax
```csharp
IRestResponse<T> ExecuteAsPost<T>(IRestRequest request, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `ExecuteAsync<T>(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteAsync<T>(IRestRequest, Method, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteAsync(IRestRequest, Method, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse> ExecuteAsync(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteAsync(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetAsync<T>(IRestRequest, CancellationToken)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse<T>> ExecuteGetAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostAsync<T>(IRestRequest, CancellationToken)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse<T>> ExecutePostAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteGetAsync(IRestRequest, CancellationToken)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse> ExecuteGetAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecutePostAsync(IRestRequest, CancellationToken)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
Task<IRestResponse> ExecutePostAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `UseSerializer(IRestSerializer)`

#### Syntax
```csharp
[Obsolete("Use the overload that accepts the delegate factory")]
IRestClient UseSerializer(IRestSerializer serializer)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`serializer` | `RestSharp.Serialization.IRestSerializer` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `ExecuteAsync(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, Method)`

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 
`httpMethod` | `RestSharp.Method` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, Method)`

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 
`httpMethod` | `RestSharp.Method` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncGet(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, String)`

Executes a GET-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncPost(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, String)`

Executes a POST-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncGet<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, String)`

Executes a GET-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsyncGet<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncPost<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, String)`

Executes a GET-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
RestRequestAsyncHandle ExecuteAsyncPost<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteTaskAsync<T>(IRestRequest)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be renamed to ExecuteAsync soon")]
Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest, CancellationToken)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("UseExecuteAsync instead")]
Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest, Method)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteGetTaskAsync<T>(IRestRequest)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteGetTaskAsync<T>(IRestRequest, CancellationToken)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostTaskAsync<T>(IRestRequest)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostTaskAsync<T>(IRestRequest, CancellationToken)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync(IRestRequest, CancellationToken)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteTaskAsync(IRestRequest, CancellationToken, Method)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token
`httpMethod` | `RestSharp.Method` | Override the request method

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteTaskAsync(IRestRequest)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetTaskAsync(IRestRequest)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetTaskAsync(IRestRequest, CancellationToken)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecutePostTaskAsync(IRestRequest)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecutePostTaskAsync(IRestRequest, CancellationToken)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `AddHandler(String, IDeserializer)`

Adds or replaces a deserializer for the specified content type

#### Syntax
```csharp
[Obsolete("Use the overload that accepts a factory delegate")]
void AddHandler(string contentType, IDeserializer deserializer)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | Content type for which the deserializer will be replaced
`deserializer` | `RestSharp.Deserializers.IDeserializer` | Custom deserializer



## Interface `IRestRequest`


### Inherited members

### Syntax
```csharp
public interface IRestRequest
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `AlwaysMultipartFormData`

Always send a multipart/form-data request - even when no Files are present.

#### Syntax
```csharp
bool AlwaysMultipartFormData { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `JsonSerializer`

Serializer to use when writing JSON request bodies. Used if RequestFormat is Json.
By default the included JsonSerializer is used (currently using SimpleJson default serialization).

#### Syntax
```csharp
ISerializer JsonSerializer { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Serializers.ISerializer` | 



### Property `XmlSerializer`

Serializer to use when writing XML request bodies. Used if RequestFormat is Xml.
By default the included XmlSerializer is used.

#### Syntax
```csharp
IXmlSerializer XmlSerializer { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Serialization.Xml.IXmlSerializer` | 



### Property `AdvancedResponseWriter`

Set this to handle the response stream yourself, based on the response details

#### Syntax
```csharp
Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream, RestSharp.IHttpResponse>` | 



### Property `ResponseWriter`

Set this to write response to Stream rather than reading into memory.

#### Syntax
```csharp
Action<Stream> ResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `Parameters`

Container of all HTTP parameters to be passed with the request.
See AddParameter() for explanation of the types of parameters that can be passed

#### Syntax
```csharp
List<Parameter> Parameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.List<RestSharp.Parameter>` | 



### Property `Files`

Container of all the files to be uploaded with the request.

#### Syntax
```csharp
List<FileParameter> Files { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.List<RestSharp.FileParameter>` | 



### Property `Method`

Determines what HTTP method to use for this request. Supported methods: GET, POST, PUT, DELETE, HEAD, OPTIONS
Default is GET

#### Syntax
```csharp
Method Method { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Method` | 



### Property `Resource`

The Resource URL to make the request against.
Tokens are substituted with UrlSegment parameters and match by name.
Should not include the scheme or domain. Do not include leading slash.
Combined with RestClient.BaseUrl to assemble final URL:
{BaseUrl}/{Resource} (BaseUrl is scheme + domain, e.g. http://example.com)

#### Examples
```csharp

// example for url token replacement
request.Resource = &quot;Products/{ProductId}&quot;;
request.AddParameter(&quot;ProductId&quot;, 123, ParameterType.UrlSegment);

```
#### Syntax
```csharp
string Resource { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestFormat`

Serializer to use when writing request bodies.

#### Syntax
```csharp
[Obsolete("Use AddJsonBody or AddXmlBody to tell RestSharp how to serialize the request body")]
DataFormat RequestFormat { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.DataFormat` | 



### Property `RootElement`

Used by the default deserializers to determine where to start deserializing from.
Can be used to skip container or root elements that do not have corresponding deserialzation targets.

#### Syntax
```csharp
string RootElement { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `DateFormat`

Used by the default deserializers to explicitly set which date format string to use when parsing dates.

#### Syntax
```csharp
string DateFormat { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `XmlNamespace`

Used by XmlDeserializer. If not specified, XmlDeserializer will flatten response by removing namespaces from
element names.

#### Syntax
```csharp
string XmlNamespace { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Credentials`

In general you would not need to set this directly. Used by the NtlmAuthenticator.

#### Syntax
```csharp
[Obsolete("Use one of authenticators provided")]
ICredentials Credentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`ICredentials` | 



### Property `Timeout`

Timeout in milliseconds to be used for the request. This timeout value overrides a timeout set on the RestClient.

#### Syntax
```csharp
int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

The number of milliseconds before the writing or reading times out. This timeout value overrides a timeout set on
the RestClient.

#### Syntax
```csharp
int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `Attempts`

How many attempts were made to send this Request?

#### Remarks

This number is incremented each time the RestClient sends the request.

#### Syntax
```csharp
int Attempts { get; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `UseDefaultCredentials`

Determine whether or not the &quot;default credentials&quot; (e.g. the user account under which the current process is
running) will be sent along to the server. The default is false.

#### Syntax
```csharp
bool UseDefaultCredentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `AllowedDecompressionMethods`

List of allowed decompression methods

#### Syntax
```csharp
IList<DecompressionMethods> AllowedDecompressionMethods { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<DecompressionMethods>` | 



### Property `OnBeforeDeserialization`

When supplied, the function will be called before calling the deserializer

#### Syntax
```csharp
Action<IRestResponse> OnBeforeDeserialization { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<RestSharp.IRestResponse>` | 



### Property `OnBeforeRequest`

When supplied, the function will be called before making a request

#### Syntax
```csharp
Action<IHttp> OnBeforeRequest { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<RestSharp.IHttp>` | 



### Property `Body`

Serialized request body to be accessed in authenticators

#### Syntax
```csharp
RequestBody Body { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.RequestBody` | 



### Method `AddFile(String, String, String)`

Adds a file to the Files collection to be included with a POST or PUT request
(other methods do not support file uploads).

#### Syntax
```csharp
IRestRequest AddFile(string name, string path, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | The parameter name to use in the request
`path` | `string` | Full path to file to upload
`contentType` | `string` | The MIME type of the file to upload

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddFile(String, Byte[], String, String)`

Adds the bytes to the Files collection with the specified file name and content type

#### Syntax
```csharp
IRestRequest AddFile(string name, byte[] bytes, string fileName, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | The parameter name to use in the request
`bytes` | `byte[]` | The file data
`fileName` | `string` | The file name to use for the uploaded file
`contentType` | `string` | The MIME type of the file to upload

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddFile(String, Action<Stream>, String, Int64, String)`

Adds the bytes to the Files collection with the specified file name and content type

#### Syntax
```csharp
IRestRequest AddFile(string name, Action<Stream> writer, string fileName, long contentLength, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | The parameter name to use in the request
`writer` | `System.Action<System.IO.Stream>` | A function that writes directly to the stream.  Should NOT close the stream.
`fileName` | `string` | The file name to use for the uploaded file
`contentLength` | `long` | The length (in bytes) of the file content.
`contentType` | `string` | The MIME type of the file to upload

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddFileBytes(String, Byte[], String, String)`

Add bytes to the Files collection as if it was a file of specific type

#### Syntax
```csharp
IRestRequest AddFileBytes(string name, byte[] bytes, string filename, string contentType = "application/x-gzip")
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | A form parameter name
`bytes` | `byte[]` | The file data
`filename` | `string` | The file name to use for the uploaded file
`contentType` | `string` | Specific content type. Es: application/x-gzip 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddBody(Object, String)`

Serializes obj to format specified by RequestFormat, but passes XmlNamespace if using the default XmlSerializer
The default format is XML. Change RequestFormat if you wish to use a different serialization format.

#### Syntax
```csharp
[Obsolete("Use AddJsonBody or AddXmlBody instead")]
IRestRequest AddBody(object obj, string xmlNamespace)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize
`xmlNamespace` | `string` | The XML namespace to use when serializing

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddBody(Object)`

Serializes obj to data format specified by RequestFormat and adds it to the request body.
The default format is XML. Change RequestFormat if you wish to use a different serialization format.

#### Syntax
```csharp
[Obsolete("Use AddJsonBody or AddXmlBody instead")]
IRestRequest AddBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddJsonBody(Object)`

Instructs RestSharp to send a given object in the request body, serialized as JSON.

#### Syntax
```csharp
IRestRequest AddJsonBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddJsonBody(Object, String)`

Instructs RestSharp to send a given object in the request body, serialized as JSON.
Allows specifying a custom content type. Usually, this method is used to support PATCH
requests that require application/json-patch+json content type.

#### Syntax
```csharp
IRestRequest AddJsonBody(object obj, string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize
`contentType` | `string` | Custom content type to override the default application/json

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddXmlBody(Object)`

Instructs RestSharp to send a given object in the request body, serialized as XML.

#### Syntax
```csharp
IRestRequest AddXmlBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddXmlBody(Object, String)`

Instructs RestSharp to send a given object in the request body, serialized as XML
but passes XmlNamespace if using the default XmlSerializer.

#### Syntax
```csharp
IRestRequest AddXmlBody(object obj, string xmlNamespace)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object to serialize
`xmlNamespace` | `string` | The XML namespace to use when serializing

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddObject(Object, String[])`

Calls AddParameter() for all public, readable properties specified in the includedProperties list

#### Examples
```csharp

request.AddObject(product, &quot;ProductId&quot;, &quot;Price&quot;, ...);

```
#### Syntax
```csharp
IRestRequest AddObject(object obj, params string[] includedProperties)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object with properties to add as parameters
`includedProperties` | `string[]` | The names of the properties to include

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddObject(Object)`

Calls AddParameter() for all public, readable properties of obj

#### Syntax
```csharp
IRestRequest AddObject(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | The object with properties to add as parameters

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddParameter(Parameter)`

Add the parameter to the request

#### Syntax
```csharp
IRestRequest AddParameter(Parameter p)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`p` | `RestSharp.Parameter` | Parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddParameter(String, Object)`

Adds a HTTP parameter to the request (QueryString for GET, DELETE, OPTIONS and HEAD; Encoded form for POST and PUT)

#### Syntax
```csharp
IRestRequest AddParameter(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddParameter(String, Object, ParameterType)`

Adds a parameter to the request. There are five types of parameters:
- GetOrPost: Either a QueryString value or encoded form value based on method
- HttpHeader: Adds the name/value pair to the HTTP request&apos;s Headers collection
- UrlSegment: Inserted into URL if there is a matching url token e.g. {AccountId}
- Cookie: Adds the name/value pair to the HTTP request&apos;s Cookies collection
- RequestBody: Used by AddBody() (not recommended to use directly)

#### Syntax
```csharp
IRestRequest AddParameter(string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter
`type` | `RestSharp.ParameterType` | The type of parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddParameter(String, Object, String, ParameterType)`

Adds a parameter to the request. There are five types of parameters:
- GetOrPost: Either a QueryString value or encoded form value based on method
- HttpHeader: Adds the name/value pair to the HTTP request&apos;s Headers collection
- UrlSegment: Inserted into URL if there is a matching url token e.g. {AccountId}
- Cookie: Adds the name/value pair to the HTTP request&apos;s Cookies collection
- RequestBody: Used by AddBody() (not recommended to use directly)

#### Syntax
```csharp
IRestRequest AddParameter(string name, object value, string contentType, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter
`contentType` | `string` | Content-Type of the parameter
`type` | `RestSharp.ParameterType` | The type of parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddOrUpdateParameter(Parameter)`

Adds a parameter to the request or updates it with the given argument, if the parameter already exists in the
request.

#### Syntax
```csharp
IRestRequest AddOrUpdateParameter(Parameter parameter)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`parameter` | `RestSharp.Parameter` | Parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameters(IEnumerable<Parameter>)`

Add or update parameters to the request

#### Syntax
```csharp
IRestRequest AddOrUpdateParameters(IEnumerable<Parameter> parameters)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`parameters` | `System.Collections.Generic.IEnumerable<RestSharp.Parameter>` | Collection of parameters to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameter(String, Object)`

Adds a HTTP parameter to the request (QueryString for GET, DELETE, OPTIONS and HEAD; Encoded form for POST and PUT)

#### Syntax
```csharp
IRestRequest AddOrUpdateParameter(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddOrUpdateParameter(String, Object, ParameterType)`

Adds a parameter to the request. There are five types of parameters:
- GetOrPost: Either a QueryString value or encoded form value based on method
- HttpHeader: Adds the name/value pair to the HTTP request Headers collection
- UrlSegment: Inserted into URL if there is a matching url token e.g. {AccountId}
- Cookie: Adds the name/value pair to the HTTP request Cookies collection
- RequestBody: Used by AddBody() (not recommended to use directly)

#### Syntax
```csharp
IRestRequest AddOrUpdateParameter(string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter
`type` | `RestSharp.ParameterType` | The type of parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddOrUpdateParameter(String, Object, String, ParameterType)`

Adds a parameter to the request. There are five types of parameters:
- GetOrPost: Either a QueryString value or encoded form value based on method
- HttpHeader: Adds the name/value pair to the HTTP request Headers collection
- UrlSegment: Inserted into URL if there is a matching url token e.g. {AccountId}
- Cookie: Adds the name/value pair to the HTTP request Cookies collection
- RequestBody: Used by AddBody() (not recommended to use directly)

#### Syntax
```csharp
IRestRequest AddOrUpdateParameter(string name, object value, string contentType, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter
`contentType` | `string` | Content-Type of the parameter
`type` | `RestSharp.ParameterType` | The type of parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddHeader(String, String)`

Shortcut to AddParameter(name, value, HttpHeader) overload

#### Syntax
```csharp
IRestRequest AddHeader(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the header to add
`value` | `string` | Value of the header to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddHeaders(ICollection<KeyValuePair<String, String>>)`

Uses AddHeader(name, value) in a convenient way to pass
in multiple headers at once.

#### Syntax
```csharp
IRestRequest AddHeaders(ICollection<KeyValuePair<string, string>> headers)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`headers` | `System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, string>>` | Key/Value pairs containing the name: value of the headers

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | This request



### Method `AddCookie(String, String)`

Shortcut to AddParameter(name, value, Cookie) overload

#### Syntax
```csharp
IRestRequest AddCookie(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the cookie to add
`value` | `string` | Value of the cookie to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddUrlSegment(String, String)`

Shortcut to AddParameter(name, value, UrlSegment) overload

#### Syntax
```csharp
IRestRequest AddUrlSegment(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the segment to add
`value` | `string` | Value of the segment to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddUrlSegment(String, Object)`

Shortcut to AddParameter(name, value, UrlSegment) overload

#### Syntax
```csharp
IRestRequest AddUrlSegment(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the segment to add
`value` | `object` | Value of the segment to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddQueryParameter(String, String)`

Shortcut to AddParameter(name, value, QueryString) overload

#### Syntax
```csharp
IRestRequest AddQueryParameter(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter to add
`value` | `string` | Value of the parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddQueryParameter(String, String, Boolean)`

Shortcut to AddParameter(name, value, QueryString) overload

#### Syntax
```csharp
IRestRequest AddQueryParameter(string name, string value, bool encode)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | Name of the parameter to add
`value` | `string` | Value of the parameter to add
`encode` | `bool` | Whether parameter should be encoded or not

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddDecompressionMethod(DecompressionMethods)`

#### Syntax
```csharp
IRestRequest AddDecompressionMethod(DecompressionMethods decompressionMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`decompressionMethod` | `DecompressionMethods` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `IncreaseNumAttempts()`

#### Syntax
```csharp
void IncreaseNumAttempts()
```


## Interface `IRestResponse`

Container for data sent back from API


### Inherited members

### Syntax
```csharp
public interface IRestResponse
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Extensions.ResponseExtensions.ToAsyncResponse<T>(RestSharp.IRestResponse)`
### Property `Request`

The RestRequest that was made to get this RestResponse

#### Remarks

Mainly for debugging if ResponseStatus is not OK

#### Syntax
```csharp
IRestRequest Request { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Property `ContentType`

MIME content type of response

#### Syntax
```csharp
string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentLength`

Length in bytes of the response content

#### Syntax
```csharp
long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `ContentEncoding`

Encoding of the response content

#### Syntax
```csharp
string ContentEncoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Content`

String representation of response content

#### Syntax
```csharp
string Content { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `StatusCode`

HTTP response status code

#### Syntax
```csharp
HttpStatusCode StatusCode { get; set; }
```
#### Property value
Type | Description
--- | ---
`HttpStatusCode` | 



### Property `IsSuccessful`

Whether or not the response status code indicates success

#### Syntax
```csharp
bool IsSuccessful { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `StatusDescription`

Description of HTTP status returned

#### Syntax
```csharp
string StatusDescription { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RawBytes`

Response content

#### Syntax
```csharp
byte[] RawBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `ResponseUri`

The URL that actually responded to the content (different from request if redirected)

#### Syntax
```csharp
Uri ResponseUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Server`

HttpWebResponse.Server

#### Syntax
```csharp
string Server { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Cookies`

Cookies returned by server with the response

#### Syntax
```csharp
IList<RestResponseCookie> Cookies { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.RestResponseCookie>` | 



### Property `Headers`

Headers returned by server with the response

#### Syntax
```csharp
IList<Parameter> Headers { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.Parameter>` | 



### Property `ResponseStatus`

Status of the request. Will return Error for transport errors.
HTTP errors will still return ResponseStatus.Completed, check StatusCode instead

#### Syntax
```csharp
ResponseStatus ResponseStatus { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.ResponseStatus` | 



### Property `ErrorMessage`

Transport or other non-HTTP error generated while attempting request

#### Syntax
```csharp
string ErrorMessage { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ErrorException`

Exceptions thrown during the request, if any.

#### Remarks

Will contain only network transport or framework exceptions thrown during the request.
HTTP protocol errors are handled by RestSharp and will not appear here.

#### Syntax
```csharp
Exception ErrorException { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Exception` | 



### Property `ProtocolVersion`

The HTTP protocol version (1.0, 1.1, etc)

#### Remarks
Only set when underlying framework supports it.
#### Syntax
```csharp
Version ProtocolVersion { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Version` | 



## Interface `IRestResponse<T>`

Container for data sent back from API including deserialized data


### Inherited members

### Syntax
```csharp
public interface IRestResponse : IRestResponse
```
### Generic parameters
Name | Description
--- | ---
`T` | Type of data to deserialize to


### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Extensions.ResponseExtensions.ToAsyncResponse<T>(RestSharp.IRestResponse)`
### Property `Data`

Deserialized entity data

#### Syntax
```csharp
T Data { get; set; }
```
#### Property value
Type | Description
--- | ---
`T` | 



## Class `JsonRequest<TRequest, TResponse>`

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `RestSharp.RestRequest`

### Inherited members

### Syntax
```csharp
public class JsonRequest : RestRequest, IRestRequest
```
### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 


### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `JsonRequest(String, TRequest)`

#### Syntax
```csharp
public JsonRequest(string resource, TRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `string` | 
`request` | `TRequest` | 



### Method `ResponseForStatusCode(HttpStatusCode, TResponse)`

#### Syntax
```csharp
public JsonRequest<TRequest, TResponse> ResponseForStatusCode(HttpStatusCode statusCode, TResponse response)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`statusCode` | `HttpStatusCode` | 
`response` | `TResponse` | 

#### Returns
Type | Description
--- | ---
`RestSharp.JsonRequest<TRequest, TResponse>` | 



### Method `ResponseForStatusCode(HttpStatusCode, Func<TResponse>)`

#### Syntax
```csharp
public JsonRequest<TRequest, TResponse> ResponseForStatusCode(HttpStatusCode statusCode, Func<TResponse> getResponse)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`statusCode` | `HttpStatusCode` | 
`getResponse` | `System.Func<TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.JsonRequest<TRequest, TResponse>` | 



### Method `ChangeResponse(Action<IRestResponse<TResponse>>)`

#### Syntax
```csharp
public JsonRequest<TRequest, TResponse> ChangeResponse(Action<IRestResponse<TResponse>> change)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`change` | `System.Action<RestSharp.IRestResponse<TResponse>>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.JsonRequest<TRequest, TResponse>` | 



## Class `RestClient`

Client to translate RestRequests into Http requests and process response result

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class RestClient : IRestClient
```

### Extension methods
-  `RestSharp.RestClientExtensions.ExecuteAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse>)`
-  `RestSharp.RestClientExtensions.ExecuteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>>)`
-  `RestSharp.RestClientExtensions.GetAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PostAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PutAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.HeadAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.OptionsAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PatchAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.DeleteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.GetAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PostAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PutAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.HeadAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.OptionsAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.PatchAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.DeleteAsync(RestSharp.IRestClient, RestSharp.IRestRequest, System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>)`
-  `RestSharp.RestClientExtensions.GetTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PostTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PutTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.HeadTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.OptionsTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.PatchTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.DeleteTaskAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.ExecuteDynamic(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.GetAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PostAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PutAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.HeadAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.OptionsAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.PatchAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.DeleteAsync<T>(RestSharp.IRestClient, RestSharp.IRestRequest, System.Threading.CancellationToken)`
-  `RestSharp.RestClientExtensions.Get<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Post<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Put<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Head<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Options<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Patch<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Delete<T>(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Get(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Post(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Put(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Head(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Options(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Patch(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.Delete(RestSharp.IRestClient, RestSharp.IRestRequest)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, RestSharp.Parameter)`
-  `RestSharp.RestClientExtensions.AddOrUpdateDefaultParameter(RestSharp.IRestClient, RestSharp.Parameter)`
-  `RestSharp.RestClientExtensions.RemoveDefaultParameter(RestSharp.IRestClient, string)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, string, object)`
-  `RestSharp.RestClientExtensions.AddDefaultParameter(RestSharp.IRestClient, string, object, RestSharp.ParameterType)`
-  `RestSharp.RestClientExtensions.AddDefaultHeader(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientExtensions.AddDefaultHeaders(RestSharp.IRestClient, System.Collections.Generic.Dictionary<string, string>)`
-  `RestSharp.RestClientExtensions.AddDefaultUrlSegment(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientExtensions.AddDefaultQueryParameter(RestSharp.IRestClient, string, string)`
-  `RestSharp.RestClientExtensions.UseJson(RestSharp.RestClient)`
-  `RestSharp.RestClientExtensions.UseXml(RestSharp.RestClient)`
-  `RestSharp.RestClientJsonRequest.Get<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Post<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Put<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Head<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Options<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Patch<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.RestClientJsonRequest.Delete<TRequest, TResponse>(RestSharp.IRestClient, RestSharp.JsonRequest<TRequest, TResponse>)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Serialization.Xml.DotNetXmlSerializerClientExtensions.UseDotNetXmlSerializer(RestSharp.IRestClient, string, System.Text.Encoding)`
### Method `ExecuteTaskAsync(IRestRequest, CancellationToken, Method)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token
`httpMethod` | `RestSharp.Method` | Override the request method

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteAsync(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, Method)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.
`httpMethod` | `RestSharp.Method` | HTTP call method (GET, PUT, etc)

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncGet(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, String)`

Executes a GET-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncPost(IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>, String)`

Executes a POST-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion providing access to the async handle.
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, Method)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion
`httpMethod` | `RestSharp.Method` | Override the request http method

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncGet<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, String)`

Executes a GET-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsyncGet<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsyncPost<T>(IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>, String)`

Executes a POST-style request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be removed soon in favour of the proper async call")]
public virtual RestRequestAsyncHandle ExecuteAsyncPost<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | Callback function to be executed upon completion
`httpMethod` | `string` | The HTTP method to execute

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteGetTaskAsync<T>(IRestRequest)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be renamed to ExecuteGetAsync soon")]
public virtual Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest, CancellationToken, Method)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
public virtual Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token
`httpMethod` | `RestSharp.Method` | Override the request method

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteGetTaskAsync<T>(IRestRequest, CancellationToken)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
public virtual Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostTaskAsync<T>(IRestRequest, CancellationToken)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
public virtual Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostTaskAsync<T>(IRestRequest)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
public virtual Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest, Method)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Please use ExecuteAsync instead")]
public virtual Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Please use ExecuteAsync instead")]
public virtual Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteTaskAsync<T>(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Please use ExecuteAsync instead")]
public virtual Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostTaskAsync(IRestRequest, CancellationToken)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("This method will be renamed to ExecutePostAsync soon")]
public virtual Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecutePostTaskAsync(IRestRequest)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecutePostAsync instead")]
public virtual Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteTaskAsync(IRestRequest)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync instead")]
public virtual Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetTaskAsync(IRestRequest)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
public virtual Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetTaskAsync(IRestRequest, CancellationToken)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteGetAsync instead")]
public virtual Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteGetAsync<T>(IRestRequest, CancellationToken)`

Executes a GET-style request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse<T>> ExecuteGetAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecutePostAsync<T>(IRestRequest, CancellationToken)`

Executes a POST-style request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse<T>> ExecutePostAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteGetAsync(IRestRequest, CancellationToken)`

Executes a GET-style asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse> ExecuteGetAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecutePostAsync(IRestRequest, CancellationToken)`

Executes a POST-style asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse> ExecutePostAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteAsync<T>(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteAsync(IRestRequest, Method, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse> ExecuteAsync(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Method `ExecuteAsync<T>(IRestRequest, Method, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the request method
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse<T>>` | 



### Method `ExecuteAsync(IRestRequest, CancellationToken)`

Executes the request asynchronously, authenticating if needed

#### Syntax
```csharp
public Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken token = default(CancellationToken))
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`token` | `System.Threading.CancellationToken` | The cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<RestSharp.IRestResponse>` | 



### Constructor `RestClient()`

Default constructor that registers default content handlers

#### Syntax
```csharp
public RestClient()
```


### Constructor `RestClient(Uri)`

Sets the BaseUrl property for requests made by this client instance

#### Syntax
```csharp
public RestClient(Uri baseUrl)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`baseUrl` | `Uri` | 



### Constructor `RestClient(String)`

Sets the BaseUrl property for requests made by this client instance

#### Syntax
```csharp
public RestClient(string baseUrl)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`baseUrl` | `string` | 



### Method `UseSerializer(IRestSerializer)`

#### Syntax
```csharp
[Obsolete("Use the overload that accepts the delegate factory")]
public IRestClient UseSerializer(IRestSerializer serializer)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`serializer` | `RestSharp.Serialization.IRestSerializer` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseUrlEncoder(Func<String, String>)`

#### Syntax
```csharp
public IRestClient UseUrlEncoder(Func<string, string> encoder)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`encoder` | `System.Func<string, string>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseQueryEncoder(Func<String, Encoding, String>)`

#### Syntax
```csharp
public IRestClient UseQueryEncoder(Func<string, Encoding, string> queryEncoder)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`queryEncoder` | `System.Func<string, System.Text.Encoding, string>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Property `AutomaticDecompression`

#### Syntax
```csharp
public bool AutomaticDecompression { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `MaxRedirects`

#### Syntax
```csharp
public int? MaxRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`int?` | 



### Property `ClientCertificates`

#### Syntax
```csharp
public X509CertificateCollection ClientCertificates { get; set; }
```
#### Property value
Type | Description
--- | ---
`X509CertificateCollection` | 



### Property `Proxy`

#### Syntax
```csharp
public IWebProxy Proxy { get; set; }
```
#### Property value
Type | Description
--- | ---
`IWebProxy` | 



### Property `CachePolicy`

#### Syntax
```csharp
public RequestCachePolicy CachePolicy { get; set; }
```
#### Property value
Type | Description
--- | ---
`RequestCachePolicy` | 



### Property `Pipelined`

#### Syntax
```csharp
public bool Pipelined { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `FollowRedirects`

#### Syntax
```csharp
public bool FollowRedirects { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `CookieContainer`

#### Syntax
```csharp
public CookieContainer CookieContainer { get; set; }
```
#### Property value
Type | Description
--- | ---
`CookieContainer` | 



### Property `UserAgent`

#### Syntax
```csharp
public string UserAgent { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Timeout`

#### Syntax
```csharp
public int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

#### Syntax
```csharp
public int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `UseSynchronizationContext`

#### Syntax
```csharp
public bool UseSynchronizationContext { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Authenticator`

#### Syntax
```csharp
public IAuthenticator Authenticator { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Authenticators.IAuthenticator` | 



### Property `BaseUrl`

#### Syntax
```csharp
public virtual Uri BaseUrl { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Encoding`

#### Syntax
```csharp
public Encoding Encoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Text.Encoding` | 



### Property `PreAuthenticate`

#### Syntax
```csharp
public bool PreAuthenticate { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ThrowOnDeserializationError`

#### Syntax
```csharp
public bool ThrowOnDeserializationError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `FailOnDeserializationError`

#### Syntax
```csharp
public bool FailOnDeserializationError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ThrowOnAnyError`

#### Syntax
```csharp
public bool ThrowOnAnyError { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `UnsafeAuthenticatedConnectionSharing`

#### Syntax
```csharp
public bool UnsafeAuthenticatedConnectionSharing { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `ConnectionGroupName`

#### Syntax
```csharp
public string ConnectionGroupName { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RemoteCertificateValidationCallback`

#### Syntax
```csharp
public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
```
#### Property value
Type | Description
--- | ---
`RemoteCertificateValidationCallback` | 



### Property `DefaultParameters`

#### Syntax
```csharp
public IList<Parameter> DefaultParameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.Parameter>` | 



### Property `BaseHost`

#### Syntax
```csharp
public string BaseHost { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `AllowMultipleDefaultParametersWithSameName`

#### Syntax
```csharp
public bool AllowMultipleDefaultParametersWithSameName { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Method `AddHandler(String, Func<IDeserializer>)`

#### Syntax
```csharp
public void AddHandler(string contentType, Func<IDeserializer> deserializerFactory)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | 
`deserializerFactory` | `System.Func<RestSharp.Deserializers.IDeserializer>` | 



### Method `AddHandler(String, IDeserializer)`

#### Syntax
```csharp
[Obsolete("Use the overload that accepts a factory delegate")]
public void AddHandler(string contentType, IDeserializer deserializer)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | 
`deserializer` | `RestSharp.Deserializers.IDeserializer` | 



### Method `RemoveHandler(String)`

#### Syntax
```csharp
public void RemoveHandler(string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | 



### Method `ClearHandlers()`

#### Syntax
```csharp
public void ClearHandlers()
```


### Method `Deserialize<T>(IRestResponse)`

#### Syntax
```csharp
public IRestResponse<T> Deserialize<T>(IRestResponse response)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`response` | `RestSharp.IRestResponse` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `ConfigureWebRequest(Action<HttpWebRequest>)`

#### Syntax
```csharp
public void ConfigureWebRequest(Action<HttpWebRequest> configurator)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`configurator` | `System.Action<HttpWebRequest>` | 



### Method `BuildUri(IRestRequest)`

#### Syntax
```csharp
public Uri BuildUri(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`Uri` | 



### Method `IRestClient.BuildUriWithoutQueryParameters(IRestRequest)`

#### Syntax
```csharp
string IRestClient.BuildUriWithoutQueryParameters(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`string` | 



### Method `UseSerializer(Func<IRestSerializer>)`

#### Syntax
```csharp
public IRestClient UseSerializer(Func<IRestSerializer> serializerFactory)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`serializerFactory` | `System.Func<RestSharp.Serialization.IRestSerializer>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseSerializer<T>()`

#### Syntax
```csharp
public IRestClient UseSerializer<T>()
    where T : IRestSerializer, new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `DownloadData(IRestRequest)`

Executes the specified request and downloads the response data

#### Syntax
```csharp
public byte[] DownloadData(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to execute

#### Returns
Type | Description
--- | ---
`byte[]` | Response data



### Method `DownloadData(IRestRequest, Boolean)`

Executes the specified request and downloads the response data

#### Syntax
```csharp
public byte[] DownloadData(IRestRequest request, bool throwOnError)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to execute
`throwOnError` | `bool` | Throw an exception if download fails.

#### Returns
Type | Description
--- | ---
`byte[]` | Response data



### Method `Execute(IRestRequest, Method)`

Executes the request and returns a response, authenticating if needed

#### Syntax
```csharp
public virtual IRestResponse Execute(IRestRequest request, Method httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed
`httpMethod` | `RestSharp.Method` | Override the http method in the request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | RestResponse



### Method `Execute(IRestRequest)`

Executes the request and returns a response, authenticating if needed

#### Syntax
```csharp
public virtual IRestResponse Execute(IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to be executed

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | RestResponse



### Method `ExecuteAsGet(IRestRequest, String)`

#### Syntax
```csharp
public IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `ExecuteAsPost(IRestRequest, String)`

#### Syntax
```csharp
public IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Execute<T>(IRestRequest, Method)`

#### Syntax
```csharp
public virtual IRestResponse<T> Execute<T>(IRestRequest request, Method httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `RestSharp.Method` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Execute<T>(IRestRequest)`

Executes the specified request and deserializes the response content using the appropriate content handler

#### Syntax
```csharp
public virtual IRestResponse<T> Execute<T>(IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | Request to execute

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | RestResponse[[T]] with deserialized data in Data property



### Method `ExecuteAsGet<T>(IRestRequest, String)`

#### Syntax
```csharp
public IRestResponse<T> ExecuteAsGet<T>(IRestRequest request, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `ExecuteAsPost<T>(IRestRequest, String)`

#### Syntax
```csharp
public IRestResponse<T> ExecuteAsPost<T>(IRestRequest request, string httpMethod)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`request` | `RestSharp.IRestRequest` | 
`httpMethod` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



## Class `RestClientExtensions`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public static class RestClientExtensions
```

### Method `ExecuteAsync(IRestClient, IRestRequest, Action<IRestResponse>)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync that returns Task")]
public static RestRequestAsyncHandle ExecuteAsync(this IRestClient client, IRestRequest request, Action<IRestResponse> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | The IRestClient this method extends
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse>` | Callback function to be executed upon completion

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `ExecuteAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>>)`

Executes the request and callback asynchronously, authenticating if needed

#### Syntax
```csharp
[Obsolete("Use ExecuteAsync that returns Task")]
public static RestRequestAsyncHandle ExecuteAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | Target deserialization type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | The IRestClient this method extends
`request` | `RestSharp.IRestRequest` | Request to be executed
`callback` | `System.Action<RestSharp.IRestResponse<T>>` | Callback function to be executed upon completion providing access to the async handle

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `GetAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use GetAsync that returns Task")]
public static RestRequestAsyncHandle GetAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PostAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PostAsync that returns Task")]
public static RestRequestAsyncHandle PostAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PutAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PutAsync that returns Task")]
public static RestRequestAsyncHandle PutAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `HeadAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use HeadAsync that returns Task")]
public static RestRequestAsyncHandle HeadAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `OptionsAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use OptionsAsync that returns Task")]
public static RestRequestAsyncHandle OptionsAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PatchAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PatchAsync that returns Task")]
public static RestRequestAsyncHandle PatchAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `DeleteAsync<T>(IRestClient, IRestRequest, Action<IRestResponse<T>, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use DeleteAsync that returns Task")]
public static RestRequestAsyncHandle DeleteAsync<T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
    where T : new()
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse<T>, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `GetAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use GetAsync that returns Task")]
public static RestRequestAsyncHandle GetAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PostAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PostAsync that returns Task")]
public static RestRequestAsyncHandle PostAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PutAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PutAsync that returns Task")]
public static RestRequestAsyncHandle PutAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `HeadAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use HeadAsync that returns Task")]
public static RestRequestAsyncHandle HeadAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `OptionsAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use OptionsAsync that returns Task")]
public static RestRequestAsyncHandle OptionsAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `PatchAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use PatchAsync that returns Task")]
public static RestRequestAsyncHandle PatchAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `DeleteAsync(IRestClient, IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>)`

#### Syntax
```csharp
[Obsolete("Use DeleteAsync that returns Task")]
public static RestRequestAsyncHandle DeleteAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 
`callback` | `System.Action<RestSharp.IRestResponse, RestSharp.RestRequestAsyncHandle>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestRequestAsyncHandle` | 



### Method `GetTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use GetAsync")]
public static Task<T> GetTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PostTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use PostAsync")]
public static Task<T> PostTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PutTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use PutAsync")]
public static Task<T> PutTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `HeadTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use HeadAsync")]
public static Task<T> HeadTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `OptionsTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use OptionsAsync")]
public static Task<T> OptionsTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PatchTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use PatchAsync")]
public static Task<T> PatchTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `DeleteTaskAsync<T>(IRestClient, IRestRequest)`

#### Syntax
```csharp
[Obsolete("Use DeleteAsync")]
public static Task<T> DeleteTaskAsync<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.IRestRequest` | 

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `ExecuteDynamic(IRestClient, IRestRequest)`

Execute the request and returns a response with the dynamic object as Data

#### Syntax
```csharp
public static IRestResponse<dynamic> ExecuteDynamic(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<dynamic>` | 



### Method `GetAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using GET HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> GetAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PostAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using POST HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> PostAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PutAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using PUT HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> PutAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `HeadAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using HEAD HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> HeadAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `OptionsAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using OPTIONS HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> OptionsAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `PatchAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using PATCH HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> PatchAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `DeleteAsync<T>(IRestClient, IRestRequest, CancellationToken)`

Execute the request using DELETE HTTP method. Exception will be thrown if the request does not succeed.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static Task<T> DeleteAsync<T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request
`cancellationToken` | `System.Threading.CancellationToken` | Cancellation token

#### Returns
Type | Description
--- | ---
`System.Threading.Tasks.Task<T>` | 



### Method `Get<T>(IRestClient, IRestRequest)`

Execute the request using GET HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Get<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Post<T>(IRestClient, IRestRequest)`

Execute the request using POST HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Post<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Put<T>(IRestClient, IRestRequest)`

Execute the request using PUT HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Put<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Head<T>(IRestClient, IRestRequest)`

Execute the request using HEAD HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Head<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Options<T>(IRestClient, IRestRequest)`

Execute the request using OPTIONS HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Options<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Patch<T>(IRestClient, IRestRequest)`

Execute the request using PATCH HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Patch<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Delete<T>(IRestClient, IRestRequest)`

Execute the request using DELETE HTTP method.
The response data is deserialzied to the Data property of the returned response object.

#### Syntax
```csharp
public static IRestResponse<T> Delete<T>(this IRestClient client, IRestRequest request)
```
#### Generic parameters
Name | Description
--- | ---
`T` | Expected result type

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<T>` | 



### Method `Get(IRestClient, IRestRequest)`

Execute the request using GET HTTP method.

#### Syntax
```csharp
public static IRestResponse Get(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Post(IRestClient, IRestRequest)`

Execute the request using POST HTTP method.

#### Syntax
```csharp
public static IRestResponse Post(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Put(IRestClient, IRestRequest)`

Execute the request using PUT HTTP method.

#### Syntax
```csharp
public static IRestResponse Put(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Head(IRestClient, IRestRequest)`

Execute the request using HEAD HTTP method.

#### Syntax
```csharp
public static IRestResponse Head(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Options(IRestClient, IRestRequest)`

Execute the request using OPTIONS HTTP method.

#### Syntax
```csharp
public static IRestResponse Options(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Patch(IRestClient, IRestRequest)`

Execute the request using PATCH HTTP method.

#### Syntax
```csharp
public static IRestResponse Patch(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `Delete(IRestClient, IRestRequest)`

Execute the request using DELETE HTTP method.

#### Syntax
```csharp
public static IRestResponse Delete(this IRestClient client, IRestRequest request)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | RestClient instance
`request` | `RestSharp.IRestRequest` | The request

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse` | 



### Method `AddDefaultParameter(IRestClient, Parameter)`

Add a parameter to use on every request made with this client instance

#### Syntax
```csharp
public static IRestClient AddDefaultParameter(this IRestClient restClient, Parameter p)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`p` | `RestSharp.Parameter` | Parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `AddOrUpdateDefaultParameter(IRestClient, Parameter)`

Add a new or update an existing parameter to use on every request made with this client instance

#### Syntax
```csharp
public static IRestClient AddOrUpdateDefaultParameter(this IRestClient restClient, Parameter p)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | 
`p` | `RestSharp.Parameter` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `RemoveDefaultParameter(IRestClient, String)`

Removes a parameter from the default parameters that are used on every request made with this client instance

#### Syntax
```csharp
public static IRestClient RemoveDefaultParameter(this IRestClient restClient, string name)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | The name of the parameter that needs to be removed

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `AddDefaultParameter(IRestClient, String, Object)`

Adds a default HTTP parameter (QueryString for GET, DELETE, OPTIONS and HEAD; Encoded form for POST and PUT)
Used on every request made by this client instance

#### Syntax
```csharp
public static IRestClient AddDefaultParameter(this IRestClient restClient, string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | This request



### Method `AddDefaultParameter(IRestClient, String, Object, ParameterType)`

Adds a default parameter to the request. There are four types of parameters:
- GetOrPost: Either a QueryString value or encoded form value based on method
- HttpHeader: Adds the name/value pair to the HTTP request&apos;s Headers collection
- UrlSegment: Inserted into URL if there is a matching url token e.g. {AccountId}
- RequestBody: Used by AddBody() (not recommended to use directly)
Used on every request made by this client instance

#### Syntax
```csharp
public static IRestClient AddDefaultParameter(this IRestClient restClient, string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | Name of the parameter
`value` | `object` | Value of the parameter
`type` | `RestSharp.ParameterType` | The type of parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | This request



### Method `AddDefaultHeader(IRestClient, String, String)`

Adds a default header to the RestClient. Used on every request made by this client instance.

#### Syntax
```csharp
public static IRestClient AddDefaultHeader(this IRestClient restClient, string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | Name of the header to add
`value` | `string` | Value of the header to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `AddDefaultHeaders(IRestClient, Dictionary<String, String>)`

Adds default headers to the RestClient. Used on every request made by this client instance.

#### Syntax
```csharp
public static IRestClient AddDefaultHeaders(this IRestClient restClient, Dictionary<string, string> headers)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`headers` | `System.Collections.Generic.Dictionary<string, string>` | Dictionary containing the Names and Values of the headers to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `AddDefaultUrlSegment(IRestClient, String, String)`

Adds a default URL segment parameter to the RestClient. Used on every request made by this client instance.

#### Syntax
```csharp
public static IRestClient AddDefaultUrlSegment(this IRestClient restClient, string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | Name of the segment to add
`value` | `string` | Value of the segment to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `AddDefaultQueryParameter(IRestClient, String, String)`

Adds a default URL query parameter to the RestClient. Used on every request made by this client instance.

#### Syntax
```csharp
public static IRestClient AddDefaultQueryParameter(this IRestClient restClient, string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`restClient` | `RestSharp.IRestClient` | The IRestClient instance
`name` | `string` | Name of the query parameter to add
`value` | `string` | Value of the query parameter to add

#### Returns
Type | Description
--- | ---
`RestSharp.IRestClient` | 



### Method `UseJson(RestClient)`

#### Syntax
```csharp
public static RestClient UseJson(this RestClient client)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.RestClient` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestClient` | 



### Method `UseXml(RestClient)`

#### Syntax
```csharp
public static RestClient UseXml(this RestClient client)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.RestClient` | 

#### Returns
Type | Description
--- | ---
`RestSharp.RestClient` | 



## Class `NameValuePair`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class NameValuePair
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
Empty | 
### Constructor `NameValuePair(String, String)`

#### Syntax
```csharp
public NameValuePair(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 



### Property `Name`

#### Syntax
```csharp
public string Name { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Value`

#### Syntax
```csharp
public string Value { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `IsEmpty`

#### Syntax
```csharp
public bool IsEmpty { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



## Class `Parameter`

Parameter container for REST requests

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class Parameter : IEquatable<Parameter>
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `Parameter(String, Object, ParameterType)`

#### Syntax
```csharp
public Parameter(string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`type` | `RestSharp.ParameterType` | 



### Constructor `Parameter(String, Object, String, ParameterType)`

#### Syntax
```csharp
public Parameter(string name, object value, string contentType, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`contentType` | `string` | 
`type` | `RestSharp.ParameterType` | 



### Property `Name`

Name of the parameter

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Value`

Value of the parameter

#### Syntax
```csharp
public object Value { get; set; }
```
#### Property value
Type | Description
--- | ---
`object` | 



### Property `Type`

Type of the parameter

#### Syntax
```csharp
public ParameterType Type { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.ParameterType` | 



### Property `DataFormat`

Body parameter data type

#### Syntax
```csharp
public DataFormat DataFormat { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.DataFormat` | 



### Property `ContentType`

MIME content type of the parameter

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Method `ToString()`

Return a human-readable representation of this parameter

#### Syntax
```csharp
public override string ToString()
```
#### Returns
Type | Description
--- | ---
`string` | String



### Method `Equals(Parameter)`

#### Syntax
```csharp
public bool Equals(Parameter other)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`other` | `RestSharp.Parameter` | 

#### Returns
Type | Description
--- | ---
`bool` | 



### Method `Equals(Object)`

#### Syntax
```csharp
public override bool Equals(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 

#### Returns
Type | Description
--- | ---
`bool` | 



### Method `GetHashCode()`

#### Syntax
```csharp
public override int GetHashCode()
```
#### Returns
Type | Description
--- | ---
`int` | 



## Class `XmlParameter`

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `RestSharp.Parameter`

### Inherited members

### Syntax
```csharp
public class XmlParameter : Parameter, IEquatable<Parameter>
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `XmlParameter(String, Object, String)`

#### Syntax
```csharp
public XmlParameter(string name, object value, string xmlNamespace = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`xmlNamespace` | `string` | 



### Property `XmlNamespace`

#### Syntax
```csharp
public string XmlNamespace { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



## Class `JsonParameter`

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `RestSharp.Parameter`

### Inherited members
-  `RestSharp.Parameter.Name`
### Syntax
```csharp
public class JsonParameter : Parameter, IEquatable<Parameter>
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `JsonParameter(String, Object)`

#### Syntax
```csharp
public JsonParameter(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 



### Constructor `JsonParameter(String, Object, String)`

#### Syntax
```csharp
public JsonParameter(string name, object value, string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`contentType` | `string` | 



## Class `RequestBody`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class RequestBody
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `ContentType`

#### Syntax
```csharp
public string ContentType { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Name`

#### Syntax
```csharp
public string Name { get; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Value`

#### Syntax
```csharp
public object Value { get; }
```
#### Property value
Type | Description
--- | ---
`object` | 



### Constructor `RequestBody(String, String, Object)`

#### Syntax
```csharp
public RequestBody(string contentType, string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`contentType` | `string` | 
`name` | `string` | 
`value` | `object` | 



## Class `RestClientJsonRequest`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public static class RestClientJsonRequest
```

### Method `Get<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Get<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Post<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Post<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Put<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Put<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Head<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Head<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Options<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Options<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Patch<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Patch<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



### Method `Delete<TRequest, TResponse>(IRestClient, JsonRequest<TRequest, TResponse>)`

#### Syntax
```csharp
public static IRestResponse<TResponse> Delete<TRequest, TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request)
    where TResponse : new()
```
#### Generic parameters
Name | Description
--- | ---
`TRequest` | 
`TResponse` | 

#### Parameters
Name | Type | Description
--- | --- | ---
`client` | `RestSharp.IRestClient` | 
`request` | `RestSharp.JsonRequest<TRequest, TResponse>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestResponse<TResponse>` | 



## Class `RestRequest`

Container for data used to make requests

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class RestRequest : IRestRequest
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `RestRequest()`

Default constructor

#### Syntax
```csharp
public RestRequest()
```


### Constructor `RestRequest(Method)`

Sets Method property to value of method

#### Syntax
```csharp
public RestRequest(Method method)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`method` | `RestSharp.Method` | Method to use for this request



### Constructor `RestRequest(String, Method)`

#### Syntax
```csharp
public RestRequest(string resource, Method method)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `string` | 
`method` | `RestSharp.Method` | 



### Constructor `RestRequest(String, DataFormat)`

#### Syntax
```csharp
public RestRequest(string resource, DataFormat dataFormat)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `string` | 
`dataFormat` | `RestSharp.DataFormat` | 



### Constructor `RestRequest(String)`

#### Syntax
```csharp
public RestRequest(string resource)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `string` | 



### Constructor `RestRequest(String, Method, DataFormat)`

#### Syntax
```csharp
public RestRequest(string resource, Method method, DataFormat dataFormat)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `string` | 
`method` | `RestSharp.Method` | 
`dataFormat` | `RestSharp.DataFormat` | 



### Constructor `RestRequest(Uri, Method, DataFormat)`

#### Syntax
```csharp
public RestRequest(Uri resource, Method method, DataFormat dataFormat)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `Uri` | 
`method` | `RestSharp.Method` | 
`dataFormat` | `RestSharp.DataFormat` | 



### Constructor `RestRequest(Uri, Method)`

#### Syntax
```csharp
public RestRequest(Uri resource, Method method)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `Uri` | 
`method` | `RestSharp.Method` | 



### Constructor `RestRequest(Uri)`

#### Syntax
```csharp
public RestRequest(Uri resource)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`resource` | `Uri` | 



### Property `AllowedDecompressionMethods`

#### Syntax
```csharp
public IList<DecompressionMethods> AllowedDecompressionMethods { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<DecompressionMethods>` | 



### Property `AlwaysMultipartFormData`

#### Syntax
```csharp
public bool AlwaysMultipartFormData { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `JsonSerializer`

#### Syntax
```csharp
public ISerializer JsonSerializer { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Serializers.ISerializer` | 



### Property `XmlSerializer`

#### Syntax
```csharp
public IXmlSerializer XmlSerializer { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Serialization.Xml.IXmlSerializer` | 



### Property `Body`

#### Syntax
```csharp
public RequestBody Body { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.RequestBody` | 



### Property `ResponseWriter`

#### Syntax
```csharp
public Action<Stream> ResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream>` | 



### Property `AdvancedResponseWriter`

#### Syntax
```csharp
public Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<System.IO.Stream, RestSharp.IHttpResponse>` | 



### Property `UseDefaultCredentials`

#### Syntax
```csharp
public bool UseDefaultCredentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Method `AddFile(String, String, String)`

#### Syntax
```csharp
public IRestRequest AddFile(string name, string path, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`path` | `string` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddFile(String, Byte[], String, String)`

#### Syntax
```csharp
public IRestRequest AddFile(string name, byte[] bytes, string fileName, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`bytes` | `byte[]` | 
`fileName` | `string` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddFile(String, Action<Stream>, String, Int64, String)`

#### Syntax
```csharp
public IRestRequest AddFile(string name, Action<Stream> writer, string fileName, long contentLength, string contentType = null)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`writer` | `System.Action<System.IO.Stream>` | 
`fileName` | `string` | 
`contentLength` | `long` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddFileBytes(String, Byte[], String, String)`

#### Syntax
```csharp
public IRestRequest AddFileBytes(string name, byte[] bytes, string filename, string contentType = "application/x-gzip")
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`bytes` | `byte[]` | 
`filename` | `string` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddBody(Object, String)`

#### Syntax
```csharp
[Obsolete("Use AddXmlBody")]
public IRestRequest AddBody(object obj, string xmlNamespace)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 
`xmlNamespace` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddBody(Object)`

#### Syntax
```csharp
[Obsolete("Use AddXmlBody or AddJsonBody")]
public IRestRequest AddBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddJsonBody(Object)`

#### Syntax
```csharp
public IRestRequest AddJsonBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddJsonBody(Object, String)`

#### Syntax
```csharp
public IRestRequest AddJsonBody(object obj, string contentType)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 
`contentType` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddXmlBody(Object)`

#### Syntax
```csharp
public IRestRequest AddXmlBody(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddXmlBody(Object, String)`

#### Syntax
```csharp
public IRestRequest AddXmlBody(object obj, string xmlNamespace)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 
`xmlNamespace` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddObject(Object, String[])`

#### Syntax
```csharp
public IRestRequest AddObject(object obj, params string[] includedProperties)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 
`includedProperties` | `string[]` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddObject(Object)`

#### Syntax
```csharp
public IRestRequest AddObject(object obj)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`obj` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddParameter(Parameter)`

#### Syntax
```csharp
public IRestRequest AddParameter(Parameter p)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`p` | `RestSharp.Parameter` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddParameter(String, Object)`

#### Syntax
```csharp
public IRestRequest AddParameter(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddParameter(String, Object, ParameterType)`

#### Syntax
```csharp
public IRestRequest AddParameter(string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`type` | `RestSharp.ParameterType` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddParameter(String, Object, String, ParameterType)`

#### Syntax
```csharp
public IRestRequest AddParameter(string name, object value, string contentType, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`contentType` | `string` | 
`type` | `RestSharp.ParameterType` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameter(Parameter)`

#### Syntax
```csharp
public IRestRequest AddOrUpdateParameter(Parameter parameter)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`parameter` | `RestSharp.Parameter` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameters(IEnumerable<Parameter>)`

#### Syntax
```csharp
public IRestRequest AddOrUpdateParameters(IEnumerable<Parameter> parameters)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`parameters` | `System.Collections.Generic.IEnumerable<RestSharp.Parameter>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameter(String, Object)`

#### Syntax
```csharp
public IRestRequest AddOrUpdateParameter(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameter(String, Object, ParameterType)`

#### Syntax
```csharp
public IRestRequest AddOrUpdateParameter(string name, object value, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`type` | `RestSharp.ParameterType` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddOrUpdateParameter(String, Object, String, ParameterType)`

#### Syntax
```csharp
public IRestRequest AddOrUpdateParameter(string name, object value, string contentType, ParameterType type)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 
`contentType` | `string` | 
`type` | `RestSharp.ParameterType` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddHeader(String, String)`

#### Syntax
```csharp
public IRestRequest AddHeader(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddHeaders(ICollection<KeyValuePair<String, String>>)`

#### Syntax
```csharp
public IRestRequest AddHeaders(ICollection<KeyValuePair<string, string>> headers)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`headers` | `System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, string>>` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddCookie(String, String)`

#### Syntax
```csharp
public IRestRequest AddCookie(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddUrlSegment(String, String)`

#### Syntax
```csharp
public IRestRequest AddUrlSegment(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddQueryParameter(String, String)`

#### Syntax
```csharp
public IRestRequest AddQueryParameter(string name, string value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddQueryParameter(String, String, Boolean)`

#### Syntax
```csharp
public IRestRequest AddQueryParameter(string name, string value, bool encode)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `string` | 
`encode` | `bool` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Method `AddDecompressionMethod(DecompressionMethods)`

#### Syntax
```csharp
public IRestRequest AddDecompressionMethod(DecompressionMethods decompressionMethod)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`decompressionMethod` | `DecompressionMethods` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Property `Parameters`

#### Syntax
```csharp
public List<Parameter> Parameters { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.List<RestSharp.Parameter>` | 



### Property `Files`

#### Syntax
```csharp
public List<FileParameter> Files { get; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.List<RestSharp.FileParameter>` | 



### Property `Method`

#### Syntax
```csharp
public Method Method { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.Method` | 



### Property `Resource`

#### Syntax
```csharp
public string Resource { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RequestFormat`

#### Syntax
```csharp
public DataFormat RequestFormat { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.DataFormat` | 



### Property `RootElement`

#### Syntax
```csharp
[Obsolete("Add custom content handler instead. This property will be removed.")]
public string RootElement { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `OnBeforeDeserialization`

#### Syntax
```csharp
public Action<IRestResponse> OnBeforeDeserialization { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<RestSharp.IRestResponse>` | 



### Property `OnBeforeRequest`

#### Syntax
```csharp
public Action<IHttp> OnBeforeRequest { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Action<RestSharp.IHttp>` | 



### Property `DateFormat`

#### Syntax
```csharp
[Obsolete("Add custom content handler instead. This property will be removed.")]
public string DateFormat { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `XmlNamespace`

#### Syntax
```csharp
[Obsolete("Add custom content handler instead. This property will be removed.")]
public string XmlNamespace { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Credentials`

#### Syntax
```csharp
public ICredentials Credentials { get; set; }
```
#### Property value
Type | Description
--- | ---
`ICredentials` | 



### Property `Timeout`

#### Syntax
```csharp
public int Timeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `ReadWriteTimeout`

#### Syntax
```csharp
public int ReadWriteTimeout { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Method `IncreaseNumAttempts()`

#### Syntax
```csharp
public void IncreaseNumAttempts()
```


### Property `Attempts`

#### Syntax
```csharp
public int Attempts { get; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Method `AddUrlSegment(String, Object)`

#### Syntax
```csharp
public IRestRequest AddUrlSegment(string name, object value)
```
#### Parameters
Name | Type | Description
--- | --- | ---
`name` | `string` | 
`value` | `object` | 

#### Returns
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



## Class `RestRequestAsyncHandle`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
public class RestRequestAsyncHandle
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
WebRequest | 
### Method `Abort()`

#### Syntax
```csharp
public void Abort()
```


## Class `RestResponseBase`

Base class for common properties shared by RestResponse and RestResponse[[T]]

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
[DebuggerDisplay("{DebuggerDisplay()}")]
public abstract class RestResponseBase
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Constructor `RestResponseBase()`

Default constructor

#### Syntax
```csharp
protected RestResponseBase()
```


### Property `Request`

The RestRequest that was made to get this RestResponse

#### Remarks

Mainly for debugging if ResponseStatus is not OK

#### Syntax
```csharp
public IRestRequest Request { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.IRestRequest` | 



### Property `ContentType`

MIME content type of response

#### Syntax
```csharp
public string ContentType { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ContentLength`

Length in bytes of the response content

#### Syntax
```csharp
public long ContentLength { get; set; }
```
#### Property value
Type | Description
--- | ---
`long` | 



### Property `ContentEncoding`

Encoding of the response content

#### Syntax
```csharp
public string ContentEncoding { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Content`

String representation of response content

#### Syntax
```csharp
public string Content { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `StatusCode`

HTTP response status code

#### Syntax
```csharp
public HttpStatusCode StatusCode { get; set; }
```
#### Property value
Type | Description
--- | ---
`HttpStatusCode` | 



### Property `IsSuccessful`

Whether or not the response status code indicates success

#### Syntax
```csharp
public bool IsSuccessful { get; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `StatusDescription`

Description of HTTP status returned

#### Syntax
```csharp
public string StatusDescription { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `RawBytes`

Response content

#### Syntax
```csharp
public byte[] RawBytes { get; set; }
```
#### Property value
Type | Description
--- | ---
`byte[]` | 



### Property `ResponseUri`

The URL that actually responded to the content (different from request if redirected)

#### Syntax
```csharp
public Uri ResponseUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Server`

HttpWebResponse.Server

#### Syntax
```csharp
public string Server { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Cookies`

Cookies returned by server with the response

#### Syntax
```csharp
public IList<RestResponseCookie> Cookies { get; protected set; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.RestResponseCookie>` | 



### Property `Headers`

Headers returned by server with the response

#### Syntax
```csharp
public IList<Parameter> Headers { get; protected set; }
```
#### Property value
Type | Description
--- | ---
`System.Collections.Generic.IList<RestSharp.Parameter>` | 



### Property `ResponseStatus`

Status of the request. Will return Error for transport errors.
HTTP errors will still return ResponseStatus.Completed, check StatusCode instead

#### Syntax
```csharp
public ResponseStatus ResponseStatus { get; set; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.ResponseStatus` | 



### Property `ErrorMessage`

Transport or other non-HTTP error generated while attempting request

#### Syntax
```csharp
public string ErrorMessage { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `ErrorException`

The exception thrown during the request, if any

#### Syntax
```csharp
public Exception ErrorException { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Exception` | 



### Property `ProtocolVersion`

The HTTP protocol version (1.0, 1.1, etc)

#### Remarks
Only set when underlying framework supports it.
#### Syntax
```csharp
public Version ProtocolVersion { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.Version` | 



### Method `DebuggerDisplay()`

Assists with debugging responses by displaying in the debugger output

#### Syntax
```csharp
protected string DebuggerDisplay()
```
#### Returns
Type | Description
--- | ---
`string` | 



## Class `RestResponse<T>`

Container for data sent back from API including deserialized data

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `RestSharp.RestResponseBase`

### Inherited members

### Syntax
```csharp
[DebuggerDisplay("{DebuggerDisplay()}")]
public class RestResponse : RestResponseBase, IRestResponse<T>, IRestResponse
```
### Generic parameters
Name | Description
--- | ---
`T` | Type of data to deserialize to


### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Extensions.ResponseExtensions.ToAsyncResponse<T>(RestSharp.IRestResponse)`
### Property `Data`

Deserialized entity data

#### Syntax
```csharp
public T Data { get; set; }
```
#### Property value
Type | Description
--- | ---
`T` | 



Operator: RestSharp.RestResponse`1.op_Explicit(RestSharp.RestResponse)~RestSharp.RestResponse{`0}

## Class `RestResponse`

Container for data sent back from API

### Inheritance
↳ `object`<br>&nbsp;&nbsp;↳ `RestSharp.RestResponseBase`

### Inherited members
-  `RestSharp.RestResponseBase.Request`
### Syntax
```csharp
[DebuggerDisplay("{DebuggerDisplay()}")]
public class RestResponse : RestResponseBase, IRestResponse
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
-  `RestSharp.Extensions.ResponseExtensions.ToAsyncResponse<T>(RestSharp.IRestResponse)`

## Class `RestResponseCookie`

### Inheritance
↳ `object`

### Inherited members

### Syntax
```csharp
[Obsolete("We will use HttpCookie in the response as well in the next major version")]
public class RestResponseCookie
```

### Extension methods
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Reflection.TypeInfo)`
-  `RestSharp.Extensions.ReflectionExtensions.ChangeType(object, System.Type, System.Globalization.CultureInfo)`
### Property `Comment`

Comment of the cookie

#### Syntax
```csharp
public string Comment { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `CommentUri`

Comment of the cookie

#### Syntax
```csharp
public Uri CommentUri { get; set; }
```
#### Property value
Type | Description
--- | ---
`Uri` | 



### Property `Discard`

Indicates whether the cookie should be discarded at the end of the session

#### Syntax
```csharp
public bool Discard { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Domain`

Domain of the cookie

#### Syntax
```csharp
public string Domain { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Expired`

Indicates whether the cookie is expired

#### Syntax
```csharp
public bool Expired { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Expires`

Date and time that the cookie expires

#### Syntax
```csharp
public DateTime Expires { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.DateTime` | 



### Property `HttpOnly`

Indicates that this cookie should only be accessed by the server

#### Syntax
```csharp
public bool HttpOnly { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `Name`

Name of the cookie

#### Syntax
```csharp
public string Name { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Path`

Path of the cookie

#### Syntax
```csharp
public string Path { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Port`

Port of the cookie

#### Syntax
```csharp
public string Port { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Secure`

Indicates that the cookie should only be sent over secure channels

#### Syntax
```csharp
public bool Secure { get; set; }
```
#### Property value
Type | Description
--- | ---
`bool` | 



### Property `TimeStamp`

Date and time the cookie was created

#### Syntax
```csharp
public DateTime TimeStamp { get; set; }
```
#### Property value
Type | Description
--- | ---
`System.DateTime` | 



### Property `Value`

Value of the cookie

#### Syntax
```csharp
public string Value { get; set; }
```
#### Property value
Type | Description
--- | ---
`string` | 



### Property `Version`

Version of the cookie

#### Syntax
```csharp
public int Version { get; set; }
```
#### Property value
Type | Description
--- | ---
`int` | 



### Property `HttpCookie`

#### Syntax
```csharp
public HttpCookie HttpCookie { get; }
```
#### Property value
Type | Description
--- | ---
`RestSharp.HttpCookie` | 


