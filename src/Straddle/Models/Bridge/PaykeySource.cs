using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaykeySourceConverter))]
public enum PaykeySource
{
    BankAccount,
    Straddle,
    Mx,
    Plaid,
    Tan,
    Quiltt,
}

sealed class PaykeySourceConverter : JsonConverter<PaykeySource>
{
    public override PaykeySource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bank_account" => PaykeySource.BankAccount,
            "straddle" => PaykeySource.Straddle,
            "mx" => PaykeySource.Mx,
            "plaid" => PaykeySource.Plaid,
            "tan" => PaykeySource.Tan,
            "quiltt" => PaykeySource.Quiltt,
            _ => (PaykeySource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeySource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeySource.BankAccount => "bank_account",
                PaykeySource.Straddle => "straddle",
                PaykeySource.Mx => "mx",
                PaykeySource.Plaid => "plaid",
                PaykeySource.Tan => "tan",
                PaykeySource.Quiltt => "quiltt",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
