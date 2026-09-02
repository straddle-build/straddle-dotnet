---
name: straddle-api-csharp-sdk
description: "C# SDK for Straddle API. Use when writing C# code that calls Straddle API with the Straddle package: installing it, constructing and authenticating the client, and calling API operations."
---

# Straddle API C# SDK

Generated C# client for Straddle API, published as `Straddle`. Use the generated client instead of hand-writing HTTP requests.

## Install

```sh
dotnet add package Straddle
```

## Client setup and authentication

```csharp
using Straddle;

// Configured using the BEARER environment variable
var client = new StraddleClient();
```

Provide credentials using the options below. Environment variables are read automatically when the target runtime supports them:

- `Bearer` (env: `BEARER`) — Send the API key as a bearer token in the `Authorization` header.

## Calling operations

```csharp
using Straddle;
using Straddle.Models.Accounts;

// Configured using the BEARER environment variable
var client = new StraddleClient();

var result = await client.Accounts.List(new AccountListParams());
```

Method names, parameter shapes, and response types are generated from the API description — do not guess them. Look up the exact call signature in [api.md](./api.md) before writing a call.

## Error handling

A non-success response throws a subclass of `StraddleApiException`, chosen by the status:

| Status | Exception |
| --- | --- |
| 400 | `StraddleBadRequestException` |
| 401 | `StraddleUnauthorizedException` |
| 403 | `StraddleForbiddenException` |
| 404 | `StraddleNotFoundException` |
| 422 | `StraddleUnprocessableEntityException` |
| 429 | `StraddleRateLimitException` |
| 5xx | `Straddle5xxException` |
| others | `StraddleUnexpectedStatusCodeException` |

Every 4xx subclass additionally inherits from `Straddle4xxException`. Outside that hierarchy:

- `StraddleIOException` — transport failures, so a connection error is never mistaken for an API error.
- `StraddleInvalidDataException` — a successfully parsed response that does not match the expected type, thrown when the mismatched property is read.
- `StraddleException` — base class for every exception above.

```csharp
using System;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

try
{
    var result = await client.Accounts.List(new AccountListParams());
}
catch (StraddleApiException exception)
{
    Console.WriteLine(exception.StatusCode);
    Console.WriteLine(exception.ResponseBody);
}
```

## Requirements

- .NET 8.0 or newer, or any runtime supporting .NET Standard 2.0

## Reference files

- [README.md](./README.md) — full feature tour: client options, retries and timeouts.
- [api.md](./api.md) — complete catalogue of every operation with request and response types.
