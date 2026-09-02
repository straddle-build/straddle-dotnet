using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.FundingEvents;

/// <summary>
/// Reason the payment was included in the funding event.
/// </summary>
[JsonConverter(typeof(FundingEventPaymentReasonConverter))]
public enum FundingEventPaymentReason
{
    Credit,
    Debit,
    Reversal,
    Failed,
}

sealed class FundingEventPaymentReasonConverter : JsonConverter<FundingEventPaymentReason>
{
    public override FundingEventPaymentReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => FundingEventPaymentReason.Credit,
            "debit" => FundingEventPaymentReason.Debit,
            "reversal" => FundingEventPaymentReason.Reversal,
            "failed" => FundingEventPaymentReason.Failed,
            _ => (FundingEventPaymentReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventPaymentReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventPaymentReason.Credit => "credit",
                FundingEventPaymentReason.Debit => "debit",
                FundingEventPaymentReason.Reversal => "reversal",
                FundingEventPaymentReason.Failed => "failed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
