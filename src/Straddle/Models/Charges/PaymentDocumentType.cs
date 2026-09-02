using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(PaymentDocumentTypeConverter))]
public enum PaymentDocumentType
{
    PaymentAuthorization,
}

sealed class PaymentDocumentTypeConverter : JsonConverter<PaymentDocumentType>
{
    public override PaymentDocumentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_authorization" => PaymentDocumentType.PaymentAuthorization,
            _ => (PaymentDocumentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentDocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentDocumentType.PaymentAuthorization => "payment_authorization",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
