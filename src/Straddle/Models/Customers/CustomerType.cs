using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(CustomerTypeConverter))]
public enum CustomerType
{
    Individual,
    Business,
}

sealed class CustomerTypeConverter : JsonConverter<CustomerType>
{
    public override CustomerType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => CustomerType.Individual,
            "business" => CustomerType.Business,
            _ => (CustomerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerType.Individual => "individual",
                CustomerType.Business => "business",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
