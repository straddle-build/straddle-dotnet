using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

/// <summary>
/// The current status of the `charge` or `payout`.
/// </summary>
[JsonConverter(typeof(PaymentStatusConverter))]
public enum PaymentStatus
{
    Created,
    Scheduled,
    Failed,
    Cancelled,
    OnHold,
    Pending,
    Paid,
    Reversed,
    Validating,
}

sealed class PaymentStatusConverter : JsonConverter<PaymentStatus>
{
    public override PaymentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PaymentStatus.Created,
            "scheduled" => PaymentStatus.Scheduled,
            "failed" => PaymentStatus.Failed,
            "cancelled" => PaymentStatus.Cancelled,
            "on_hold" => PaymentStatus.OnHold,
            "pending" => PaymentStatus.Pending,
            "paid" => PaymentStatus.Paid,
            "reversed" => PaymentStatus.Reversed,
            "validating" => PaymentStatus.Validating,
            _ => (PaymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentStatus.Created => "created",
                PaymentStatus.Scheduled => "scheduled",
                PaymentStatus.Failed => "failed",
                PaymentStatus.Cancelled => "cancelled",
                PaymentStatus.OnHold => "on_hold",
                PaymentStatus.Pending => "pending",
                PaymentStatus.Paid => "paid",
                PaymentStatus.Reversed => "reversed",
                PaymentStatus.Validating => "validating",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
