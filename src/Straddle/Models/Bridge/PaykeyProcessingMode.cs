using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaykeyProcessingModeConverter))]
public enum PaykeyProcessingMode
{
    Inline,
    Background,
    Skip,
}

sealed class PaykeyProcessingModeConverter : JsonConverter<PaykeyProcessingMode>
{
    public override PaykeyProcessingMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inline" => PaykeyProcessingMode.Inline,
            "background" => PaykeyProcessingMode.Background,
            "skip" => PaykeyProcessingMode.Skip,
            _ => (PaykeyProcessingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyProcessingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyProcessingMode.Inline => "inline",
                PaykeyProcessingMode.Background => "background",
                PaykeyProcessingMode.Skip => "skip",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
