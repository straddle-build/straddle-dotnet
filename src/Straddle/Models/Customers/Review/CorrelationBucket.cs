using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(CorrelationBucketConverter))]
public enum CorrelationBucket
{
    LowConfidence,
    PotentialMatch,
    LikelyMatch,
    HighConfidence,
}

sealed class CorrelationBucketConverter : JsonConverter<CorrelationBucket>
{
    public override CorrelationBucket Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low_confidence" => CorrelationBucket.LowConfidence,
            "potential_match" => CorrelationBucket.PotentialMatch,
            "likely_match" => CorrelationBucket.LikelyMatch,
            "high_confidence" => CorrelationBucket.HighConfidence,
            _ => (CorrelationBucket)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CorrelationBucket value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CorrelationBucket.LowConfidence => "low_confidence",
                CorrelationBucket.PotentialMatch => "potential_match",
                CorrelationBucket.LikelyMatch => "likely_match",
                CorrelationBucket.HighConfidence => "high_confidence",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
