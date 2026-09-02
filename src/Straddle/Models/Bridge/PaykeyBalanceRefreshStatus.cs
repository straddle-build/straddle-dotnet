using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaykeyBalanceRefreshStatusConverter))]
public enum PaykeyBalanceRefreshStatus
{
    Pending,
    Completed,
    Failed,
}

sealed class PaykeyBalanceRefreshStatusConverter : JsonConverter<PaykeyBalanceRefreshStatus>
{
    public override PaykeyBalanceRefreshStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PaykeyBalanceRefreshStatus.Pending,
            "completed" => PaykeyBalanceRefreshStatus.Completed,
            "failed" => PaykeyBalanceRefreshStatus.Failed,
            _ => (PaykeyBalanceRefreshStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyBalanceRefreshStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyBalanceRefreshStatus.Pending => "pending",
                PaykeyBalanceRefreshStatus.Completed => "completed",
                PaykeyBalanceRefreshStatus.Failed => "failed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
