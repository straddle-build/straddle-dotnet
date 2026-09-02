using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.FundingEvents;

/// <summary>
/// Transfer direction relative to the linked bank account. `deposit` moves funds
/// into the account, and `withdrawal` moves funds out.
/// </summary>
[JsonConverter(typeof(FundingEventTransferDirectionConverter))]
public enum FundingEventTransferDirection
{
    Deposit,
    Withdrawal,
}

sealed class FundingEventTransferDirectionConverter : JsonConverter<FundingEventTransferDirection>
{
    public override FundingEventTransferDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => FundingEventTransferDirection.Deposit,
            "withdrawal" => FundingEventTransferDirection.Withdrawal,
            _ => (FundingEventTransferDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventTransferDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventTransferDirection.Deposit => "deposit",
                FundingEventTransferDirection.Withdrawal => "withdrawal",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
