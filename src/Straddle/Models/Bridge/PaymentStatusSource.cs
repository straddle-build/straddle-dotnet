using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaymentStatusSourceConverter))]
public enum PaymentStatusSource
{
    Watchtower,
    BankDecline,
    CustomerDispute,
    UserAction,
    System,
}

sealed class PaymentStatusSourceConverter : JsonConverter<PaymentStatusSource>
{
    public override PaymentStatusSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "watchtower" => PaymentStatusSource.Watchtower,
            "bank_decline" => PaymentStatusSource.BankDecline,
            "customer_dispute" => PaymentStatusSource.CustomerDispute,
            "user_action" => PaymentStatusSource.UserAction,
            "system" => PaymentStatusSource.System,
            _ => (PaymentStatusSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentStatusSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentStatusSource.Watchtower => "watchtower",
                PaymentStatusSource.BankDecline => "bank_decline",
                PaymentStatusSource.CustomerDispute => "customer_dispute",
                PaymentStatusSource.UserAction => "user_action",
                PaymentStatusSource.System => "system",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
