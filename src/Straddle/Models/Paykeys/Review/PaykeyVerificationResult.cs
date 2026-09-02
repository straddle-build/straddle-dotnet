using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(typeof(PaykeyVerificationResultConverter))]
public enum PaykeyVerificationResult
{
    Accept,
    Reject,
    Review,
}

sealed class PaykeyVerificationResultConverter : JsonConverter<PaykeyVerificationResult>
{
    public override PaykeyVerificationResult Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accept" => PaykeyVerificationResult.Accept,
            "reject" => PaykeyVerificationResult.Reject,
            "review" => PaykeyVerificationResult.Review,
            _ => (PaykeyVerificationResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyVerificationResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyVerificationResult.Accept => "accept",
                PaykeyVerificationResult.Reject => "reject",
                PaykeyVerificationResult.Review => "review",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
