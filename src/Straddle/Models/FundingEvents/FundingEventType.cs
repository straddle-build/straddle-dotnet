using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.FundingEvents;

/// <summary>
/// Reason for the funding event. `charge_deposit` settles collected charges to the
/// linked bank account. `charge_reversal` withdraws funds for reversed charges.
/// `payout_withdrawal` withdraws funds for payouts. `payout_return` deposits
/// returned payout funds.
/// </summary>
[JsonConverter(typeof(FundingEventTypeConverter))]
public enum FundingEventType
{
    ChargeDeposit,
    ChargeReversal,
    PayoutReturn,
    PayoutWithdrawal,
}

sealed class FundingEventTypeConverter : JsonConverter<FundingEventType>
{
    public override FundingEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charge_deposit" => FundingEventType.ChargeDeposit,
            "charge_reversal" => FundingEventType.ChargeReversal,
            "payout_return" => FundingEventType.PayoutReturn,
            "payout_withdrawal" => FundingEventType.PayoutWithdrawal,
            _ => (FundingEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventType.ChargeDeposit => "charge_deposit",
                FundingEventType.ChargeReversal => "charge_reversal",
                FundingEventType.PayoutReturn => "payout_return",
                FundingEventType.PayoutWithdrawal => "payout_withdrawal",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
