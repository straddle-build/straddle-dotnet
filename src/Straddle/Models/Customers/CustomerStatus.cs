using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(CustomerStatusConverter))]
public enum CustomerStatus
{
    Pending,
    Review,
    Verified,
    Inactive,
    Rejected,
}

sealed class CustomerStatusConverter : JsonConverter<CustomerStatus>
{
    public override CustomerStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => CustomerStatus.Pending,
            "review" => CustomerStatus.Review,
            "verified" => CustomerStatus.Verified,
            "inactive" => CustomerStatus.Inactive,
            "rejected" => CustomerStatus.Rejected,
            _ => (CustomerStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerStatus.Pending => "pending",
                CustomerStatus.Review => "review",
                CustomerStatus.Verified => "verified",
                CustomerStatus.Inactive => "inactive",
                CustomerStatus.Rejected => "rejected",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
