using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.FundingEvents;

/// <summary>
/// Transfer direction relative to the linked bank account. `deposit` moves funds
/// into the account, and `withdrawal` moves funds out.
/// </summary>
[JsonConverter(typeof(TransferDirectionConverter))]
public enum TransferDirection
{
    Deposit,
    Withdrawal,
}

sealed class TransferDirectionConverter : JsonConverter<TransferDirection>
{
    public override TransferDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => TransferDirection.Deposit,
            "withdrawal" => TransferDirection.Withdrawal,
            _ => (TransferDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransferDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransferDirection.Deposit => "deposit",
                TransferDirection.Withdrawal => "withdrawal",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
