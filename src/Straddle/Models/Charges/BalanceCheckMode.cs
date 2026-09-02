using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(BalanceCheckModeConverter))]
public enum BalanceCheckMode
{
    Required,
    Enabled,
    Disabled,
}

sealed class BalanceCheckModeConverter : JsonConverter<BalanceCheckMode>
{
    public override BalanceCheckMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "required" => BalanceCheckMode.Required,
            "enabled" => BalanceCheckMode.Enabled,
            "disabled" => BalanceCheckMode.Disabled,
            _ => (BalanceCheckMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceCheckMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceCheckMode.Required => "required",
                BalanceCheckMode.Enabled => "enabled",
                BalanceCheckMode.Disabled => "disabled",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
