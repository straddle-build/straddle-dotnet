using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(VerificationDecisionConverter))]
public enum VerificationDecision
{
    Accept,
    Reject,
    Review,
}

sealed class VerificationDecisionConverter : JsonConverter<VerificationDecision>
{
    public override VerificationDecision Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accept" => VerificationDecision.Accept,
            "reject" => VerificationDecision.Reject,
            "review" => VerificationDecision.Review,
            _ => (VerificationDecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationDecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationDecision.Accept => "accept",
                VerificationDecision.Reject => "reject",
                VerificationDecision.Review => "review",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
