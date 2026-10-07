# Straddle .NET SDK

Use Straddle's Pay by Bank and Embed APIs from C#. The SDK provides typed requests and responses, async methods, authentication, and retries.

## Install

Use .NET 8.0 or later, or a runtime that supports .NET Standard 2.0. Add the package to your .NET project:

```sh
dotnet add package Straddle
```

The NuGet package is [`Straddle`](https://www.nuget.org/packages/Straddle). Its source lives in `straddle-build/straddle-dotnet`.

## Make your first request

Create a sandbox API key in the [Straddle Dashboard](https://dashboard.straddle.com), then set it in your environment. See [API authentication](https://docs.straddle.com/api-reference/authentication) for the setup steps.

```sh
export STRADDLE_API_KEY="YOUR_SANDBOX_API_KEY"
```

Use the following code in a console application's `Program.cs`. It requests the first page of customers from the sandbox:

```csharp
using System;
using Straddle;
using Straddle.Models.Customers;

var apiKey = Environment.GetEnvironmentVariable("STRADDLE_API_KEY")
    ?? throw new InvalidOperationException("Set STRADDLE_API_KEY to your sandbox API key.");

var client = new StraddleClient
{
    Bearer = apiKey,
    BaseUrl = "https://sandbox.straddle.com",
};

var page = await client.Customers.List(new CustomerListParams
{
    PageNumber = 1,
    PageSize = 10,
});

Console.WriteLine($"Customers on this page: {page.Data.Count}");
```

For a SaaS platform key, add `StraddleAccountID = "YOUR_EMBEDDED_ACCOUNT_ID"` to `CustomerListParams` before running the example. This selects the embedded account whose customers you want to read. Direct accounts and marketplaces list customers without that header. See [platform account scoping](https://docs.straddle.com/guides/embed/api-headers).

Run the console application:

```sh
dotnet run
```

A successful request prints the number of customers on the page. `Customers on this page: 0` is valid for an empty account. Customer records are in `page.Data`; pagination and request metadata are in `page.Meta`.

The remaining examples use this `client`.

## Configure authentication and environments

The example passes `STRADDLE_API_KEY` explicitly as `Bearer`. If you omit `Bearer`, the client reads `BEARER`.

Set `BaseUrl` explicitly to select an environment. If you omit it, the client reads `STRADDLE_BASE_URL`, then defaults to `https://sandbox.straddle.com`. Production uses `https://production.straddle.com` and a production API key. See [environments](https://docs.straddle.com/api-reference/environments).

## Read additional pages

List methods return one response page. Choose the next `PageNumber` using `page.Meta.TotalPages`, and keep your filters and account scope the same between requests:

```csharp
var nextPage = await client.Customers.List(new CustomerListParams
{
    PageNumber = 2,
    PageSize = 10,
});
```

Each operation takes a parameter record and returns a typed model. See the [method reference](./api.md) for each resource's filters and response types.

## Handle errors

Catch `StraddleApiException` for an HTTP error response. Its `StatusCode` and `ResponseBody` describe the response:

```csharp
using Straddle.Exceptions;

try
{
    var page = await client.Customers.List(new CustomerListParams { PageSize = 10 });
}
catch (StraddleApiException error)
{
    Console.Error.WriteLine(error.StatusCode);
    throw;
}
```

For a `401`, check that the key matches the selected environment. For a `403`, check the key's permissions and account scope. Connection errors raise `StraddleIOException`. See [exception types](./USAGE.md#exception-types) and [API errors](https://docs.straddle.com/api-reference/errors) for details.

## Set retries and timeouts

The client retries connection errors, `408`, `409`, `429`, and `5xx` responses twice by default. It uses exponential backoff and honors supported `Retry-After` values. The default timeout is one minute per attempt, so retries can extend the total request duration.

Use `WithOptions` to change settings while sharing the same HTTP connection pool:

```csharp
var page = await client
    .WithOptions(options => options with
    {
        MaxRetries = 0,
        Timeout = TimeSpan.FromSeconds(30),
    })
    .Customers.List(new CustomerListParams { PageSize = 10 });
```

For write operations that accept an idempotency key, set the operation's `IdempotencyKey` property. Reuse that value when retrying the same operation. See [idempotency](https://docs.straddle.com/api-reference/idempotency).

## Reference and support

Use the following resources as you build your integration:

- [SDK method reference](./api.md) and [operation signatures](./reference.md).
- [Advanced usage](./USAGE.md): client options, raw responses, proxies, and response validation.
- [Straddle guides](https://docs.straddle.com): payment flows, sandbox testing, and API concepts.
- [GitHub issues](https://github.com/straddle-build/straddle-dotnet/issues): SDK bugs and feature requests.
- [Local development](./CONTRIBUTING.md) and [versioning](./VERSIONING.md): submit customizations against `scalar-next` so Scalar carries them through regeneration.
- [Security policy](./SECURITY.md) and [Apache 2.0 license](./LICENSE).

Straddle generates this SDK with Scalar and maintains repository customizations through the workflow in `VERSIONING.md`.
