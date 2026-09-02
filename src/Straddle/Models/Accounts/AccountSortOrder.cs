using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

/// <summary>
/// Sort direction for the results.
/// </summary>
[JsonConverter(typeof(AccountSortOrderConverter))]
public enum AccountSortOrder
{
    Asc,
    Desc,
}

sealed class AccountSortOrderConverter : JsonConverter<AccountSortOrder>
{
    public override AccountSortOrder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => AccountSortOrder.Asc,
            "desc" => AccountSortOrder.Desc,
            _ => (AccountSortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountSortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountSortOrder.Asc => "asc",
                AccountSortOrder.Desc => "desc",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
