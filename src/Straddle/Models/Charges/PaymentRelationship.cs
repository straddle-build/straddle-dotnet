using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(PaymentRelationshipConverter))]
public enum PaymentRelationship
{
    Original,
    Resubmit,
    Refund,
}

sealed class PaymentRelationshipConverter : JsonConverter<PaymentRelationship>
{
    public override PaymentRelationship Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "original" => PaymentRelationship.Original,
            "resubmit" => PaymentRelationship.Resubmit,
            "refund" => PaymentRelationship.Refund,
            _ => (PaymentRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentRelationship.Original => "original",
                PaymentRelationship.Resubmit => "resubmit",
                PaymentRelationship.Refund => "refund",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
