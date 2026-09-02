using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

/// <summary>
/// The payment rail used for the charge or payout.
/// </summary>
[JsonConverter(typeof(PaymentRailConverter))]
public enum PaymentRail
{
    Ach,
}

sealed class PaymentRailConverter : JsonConverter<PaymentRail>
{
    public override PaymentRail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach" => PaymentRail.Ach,
            _ => (PaymentRail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentRail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentRail.Ach => "ach",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
