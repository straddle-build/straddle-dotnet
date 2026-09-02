using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaykeyStatusConverter))]
public enum PaykeyStatus
{
    Pending,
    Active,
    Inactive,
    Rejected,
    Review,
    Blocked,
}

sealed class PaykeyStatusConverter : JsonConverter<PaykeyStatus>
{
    public override PaykeyStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PaykeyStatus.Pending,
            "active" => PaykeyStatus.Active,
            "inactive" => PaykeyStatus.Inactive,
            "rejected" => PaykeyStatus.Rejected,
            "review" => PaykeyStatus.Review,
            "blocked" => PaykeyStatus.Blocked,
            _ => (PaykeyStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyStatus.Pending => "pending",
                PaykeyStatus.Active => "active",
                PaykeyStatus.Inactive => "inactive",
                PaykeyStatus.Rejected => "rejected",
                PaykeyStatus.Review => "review",
                PaykeyStatus.Blocked => "blocked",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
