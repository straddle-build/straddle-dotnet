using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(AccountTypeConverter))]
public enum AccountType
{
    Checking,
    Savings,
}

sealed class AccountTypeConverter : JsonConverter<AccountType>
{
    public override AccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AccountType.Checking,
            "savings" => AccountType.Savings,
            _ => (AccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountType.Checking => "checking",
                AccountType.Savings => "savings",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
