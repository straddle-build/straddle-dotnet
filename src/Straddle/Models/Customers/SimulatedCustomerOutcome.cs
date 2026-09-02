using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(SimulatedCustomerOutcomeConverter))]
public enum SimulatedCustomerOutcome
{
    Standard,
    Verified,
    Rejected,
    Review,
}

sealed class SimulatedCustomerOutcomeConverter : JsonConverter<SimulatedCustomerOutcome>
{
    public override SimulatedCustomerOutcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => SimulatedCustomerOutcome.Standard,
            "verified" => SimulatedCustomerOutcome.Verified,
            "rejected" => SimulatedCustomerOutcome.Rejected,
            "review" => SimulatedCustomerOutcome.Review,
            _ => (SimulatedCustomerOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimulatedCustomerOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SimulatedCustomerOutcome.Standard => "standard",
                SimulatedCustomerOutcome.Verified => "verified",
                SimulatedCustomerOutcome.Rejected => "rejected",
                SimulatedCustomerOutcome.Review => "review",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
