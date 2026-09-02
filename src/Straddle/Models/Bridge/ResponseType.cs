using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

/// <summary>
/// Shape of the response envelope.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of JSON objects.
/// - `error` means `error` contains the error details.
/// - `none` means the response contains no data.
/// </summary>
[JsonConverter(typeof(ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter : JsonConverter<ResponseType>
{
    public override ResponseType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => ResponseType.Object,
            "array" => ResponseType.Array,
            "error" => ResponseType.Error,
            "none" => ResponseType.None,
            _ => (ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseType.Object => "object",
                ResponseType.Array => "array",
                ResponseType.Error => "error",
                ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
