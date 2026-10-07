# Straddle .NET SDK advanced usage

Configure the HTTP client, inspect raw responses, and work with response fields beyond the typed model. Start with the [README](./README.md) to install the SDK and make a sandbox request. The snippets here assume that configured `client` and the namespaces `System`, `Straddle`, and `Straddle.Models.Customers`.

## Client options

Set options as init-only properties when you create a client. Use `WithOptions` to derive a client or service with different settings and the same connection pool.

| Option | Type | Default | Purpose |
| --- | --- | --- | --- |
| `Bearer` | `string` | `BEARER` | API key |
| `BaseUrl` | `string` | `STRADDLE_BASE_URL`, then sandbox | API base URL |
| `MaxRetries` | `int?` | `2` when null | Retry count |
| `Timeout` | `TimeSpan?` | One minute when null | Timeout for each attempt |
| `HttpClient` | `HttpClient` | SDK-managed client | Custom HTTP transport |
| `ResponseValidation` | `bool` | `false` | Validate each deserialized response up front |

The `EnvironmentUrl.StraddleApiServer` constant in `Straddle.Core` selects `https://sandbox.straddle.com`.

## Inspect raw responses

Use `WithRawResponse` to read the HTTP status and headers before deserializing the body:

```csharp
using var response = await client.WithRawResponse.Customers.List(
    new CustomerListParams { PageSize = 10 }
);
Console.WriteLine(response.StatusCode);
var headers = response.Headers;
var page = await response.Deserialize();
```

`response.RawMessage` exposes the underlying `HttpResponseMessage`.

## Exception types

HTTP error responses raise a `StraddleApiException` subclass according to the status.

| Status | Exception |
| --- | --- |
| `400` | `StraddleBadRequestException` |
| `401` | `StraddleUnauthorizedException` |
| `403` | `StraddleForbiddenException` |
| `404` | `StraddleNotFoundException` |
| `422` | `StraddleUnprocessableEntityException` |
| `429` | `StraddleRateLimitException` |
| Other `4xx` statuses | `Straddle4xxException` |
| `5xx` | `Straddle5xxException` |
| Other error statuses | `StraddleUnexpectedStatusCodeException` |

All `4xx` subclasses also inherit from `Straddle4xxException`. `StraddleIOException` reports a transport error. `StraddleInvalidDataException` reports response data that doesn't match the expected type. `StraddleException` is the base class for these SDK exceptions.

## Configure a proxy

Supply an `HttpClient` to use your own proxy or message handler:

```csharp
using System.Net;
using System.Net.Http;
using System.Threading;

using var httpClient = new HttpClient(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://proxy.example.com:8080"),
    }
)
{
    Timeout = Timeout.InfiniteTimeSpan,
};

var proxyClient = client.WithOptions(options => options with { HttpClient = httpClient });
```

Setting the HTTP client's timeout to infinite leaves the SDK's `Timeout` in control. Keep a supplied client alive for the requests that use it.

## Read and validate models

Response models read properties from raw JSON when you use them. A mismatched field raises `StraddleInvalidDataException` when that property is read. To validate the entire response up front, call `Validate()` on a model or set `ResponseValidation = true` on the client.

```csharp
var validatingClient = client.WithOptions(options => options with { ResponseValidation = true });
var page = await validatingClient.Customers.List(new CustomerListParams { PageSize = 10 });
```

Raw-response methods perform this validation when you call `Deserialize()`. XML documentation includes the descriptions supplied by the API contract.

## Send additional parameters

Parameter records accept raw header and query dictionaries. Operations with a body also accept a raw body dictionary:

```csharp
using System.Collections.Generic;
using System.Text.Json;

var parameters = new CustomerListParams(
    rawHeaderData: new Dictionary<string, JsonElement>
    {
        { "Custom-Header", JsonSerializer.SerializeToElement("example") },
    },
    rawQueryData: new Dictionary<string, JsonElement>
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) },
    }
);
```

Read these values through `RawHeaderData`, `RawQueryData`, and, where present, `RawBodyData`. A `required` property must be set in an object initializer. To construct parameters entirely from raw dictionaries, use `FromRawUnchecked`. Nested parameter records provide the same constructors.

## Read additional response fields

Object-shaped response models expose all returned fields through `RawData`, an `IReadOnlyDictionary<string, JsonElement>`:

```csharp
using System.Text.Json;

var page = await client.Customers.List(new CustomerListParams { PageSize = 10 });
if (page.RawData.TryGetValue("custom_field", out JsonElement value))
{
    Console.WriteLine(value);
}
```

## Versioning

The package follows [Semantic Versioning](https://semver.org/spec/v2.0.0.html), with two documented exceptions that can ship in a minor release:

1. Changes to technically public internals that aren't intended or documented for external use.
2. Changes that aren't expected to affect most users.

See [VERSIONING.md](./VERSIONING.md) for the release workflow and [reference.md](./reference.md) for operation signatures. The generated [snippets.md](./snippets.md) contains the generator's account-list example.
