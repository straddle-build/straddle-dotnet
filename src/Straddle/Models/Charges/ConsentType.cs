using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

/// <summary>
/// How the customer authorized the charge. `internet` covers online and mobile
/// authorization. `signed` covers written or PDF-signed agreements.
/// </summary>
[JsonConverter(typeof(ConsentTypeConverter))]
public enum ConsentType
{
    Internet,
    Signed,
}

sealed class ConsentTypeConverter : JsonConverter<ConsentType>
{
    public override ConsentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internet" => ConsentType.Internet,
            "signed" => ConsentType.Signed,
            _ => (ConsentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConsentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConsentType.Internet => "internet",
                ConsentType.Signed => "signed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
