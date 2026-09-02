using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(SimulatedPaykeyOutcomeConverter))]
public enum SimulatedPaykeyOutcome
{
    Standard,
    Active,
    Rejected,
    Review,
}

sealed class SimulatedPaykeyOutcomeConverter : JsonConverter<SimulatedPaykeyOutcome>
{
    public override SimulatedPaykeyOutcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => SimulatedPaykeyOutcome.Standard,
            "active" => SimulatedPaykeyOutcome.Active,
            "rejected" => SimulatedPaykeyOutcome.Rejected,
            "review" => SimulatedPaykeyOutcome.Review,
            _ => (SimulatedPaykeyOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimulatedPaykeyOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SimulatedPaykeyOutcome.Standard => "standard",
                SimulatedPaykeyOutcome.Active => "active",
                SimulatedPaykeyOutcome.Rejected => "rejected",
                SimulatedPaykeyOutcome.Review => "review",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
