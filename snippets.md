# Straddle C# Snippets

```csharp
using Straddle;
using Straddle.Models.Accounts;

// Configured using the BEARER environment variable
var client = new StraddleClient();

var result = await client.Accounts.List(new AccountListParams());
```
