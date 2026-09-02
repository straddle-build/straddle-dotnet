using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

/// <summary>
/// The type of payment.
/// </summary>
[JsonConverter(typeof(PaymentTypeConverter))]
public enum PaymentType
{
    Charge,
    Payout,
}

sealed class PaymentTypeConverter : JsonConverter<PaymentType>
{
    public override PaymentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charge" => PaymentType.Charge,
            "payout" => PaymentType.Payout,
            _ => (PaymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentType.Charge => "charge",
                PaymentType.Payout => "payout",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
