using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Customers;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<CustomerCreatedV1WebhookEvent, CustomerCreatedV1WebhookEventFromRaw>)
)]
public sealed record class CustomerCreatedV1WebhookEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the account associated with this event.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required CustomerCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerCreatedV1WebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// Type of this event.
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.Data.Validate();
        _ = this.EventID;
        _ = this.EventType;
    }

    public CustomerCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerCreatedV1WebhookEvent(
        CustomerCreatedV1WebhookEvent customerCreatedV1WebhookEvent
    )
        : base(customerCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public CustomerCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static CustomerCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerCreatedV1WebhookEventFromRaw : IFromRawJson<CustomerCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public CustomerCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerCreatedV1WebhookEventData,
        CustomerCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class CustomerCreatedV1WebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for the customer.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp of when the customer record was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required MaskedCustomerDevice Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MaskedCustomerDevice>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// Customer email address.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Full name for an individual customer or business name for a business customer.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Customer phone number in E.164 format.
    /// </summary>
    public required string Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    public required ApiEnum<string, CustomerCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, CustomerType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomerType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp of the most recent update to the customer record.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public CustomerCreatedV1WebhookEventDataAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerCreatedV1WebhookEventDataAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public CustomerCreatedV1WebhookEventDataComplianceProfile? ComplianceProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerCreatedV1WebhookEventDataComplianceProfile>(
                "compliance_profile"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("compliance_profile", value);
        }
    }

    /// <summary>
    /// Unique identifier for the customer in your system.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// Up to 20 user-defined key-value pairs associated with the customer.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Device.Validate();
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.Address?.Validate();
        this.ComplianceProfile?.Validate();
        _ = this.ExternalID;
        _ = this.Metadata;
    }

    public CustomerCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerCreatedV1WebhookEventData(
        CustomerCreatedV1WebhookEventData customerCreatedV1WebhookEventData
    )
        : base(customerCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public CustomerCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CustomerCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerCreatedV1WebhookEventDataFromRaw : IFromRawJson<CustomerCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public CustomerCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CustomerCreatedV1WebhookEventDataStatusConverter))]
public enum CustomerCreatedV1WebhookEventDataStatus
{
    Pending,
    Review,
    Verified,
    Inactive,
    Rejected,
}

sealed class CustomerCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<CustomerCreatedV1WebhookEventDataStatus>
{
    public override CustomerCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => CustomerCreatedV1WebhookEventDataStatus.Pending,
            "review" => CustomerCreatedV1WebhookEventDataStatus.Review,
            "verified" => CustomerCreatedV1WebhookEventDataStatus.Verified,
            "inactive" => CustomerCreatedV1WebhookEventDataStatus.Inactive,
            "rejected" => CustomerCreatedV1WebhookEventDataStatus.Rejected,
            _ => (CustomerCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerCreatedV1WebhookEventDataStatus.Pending => "pending",
                CustomerCreatedV1WebhookEventDataStatus.Review => "review",
                CustomerCreatedV1WebhookEventDataStatus.Verified => "verified",
                CustomerCreatedV1WebhookEventDataStatus.Inactive => "inactive",
                CustomerCreatedV1WebhookEventDataStatus.Rejected => "rejected",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerCreatedV1WebhookEventDataAddress,
        CustomerCreatedV1WebhookEventDataAddressFromRaw
    >)
)]
public sealed record class CustomerCreatedV1WebhookEventDataAddress : JsonModel
{
    /// <summary>
    /// Primary address line, such as a street address or PO Box.
    /// </summary>
    public required string Address1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("address1");
        }
        init { this._rawData.Set("address1", value); }
    }

    /// <summary>
    /// City, district, suburb, town, or village.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Two-letter state code.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// ZIP or postal code.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// Secondary address line, such as an apartment, suite, unit, or building.
    /// </summary>
    public string? Address2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address2");
        }
        init { this._rawData.Set("address2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address1;
        _ = this.City;
        _ = this.State;
        _ = this.Zip;
        _ = this.Address2;
    }

    public CustomerCreatedV1WebhookEventDataAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerCreatedV1WebhookEventDataAddress(
        CustomerCreatedV1WebhookEventDataAddress customerCreatedV1WebhookEventDataAddress
    )
        : base(customerCreatedV1WebhookEventDataAddress) { }
#pragma warning restore CS8618

    public CustomerCreatedV1WebhookEventDataAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerCreatedV1WebhookEventDataAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerCreatedV1WebhookEventDataAddressFromRaw.FromRawUnchecked"/>
    public static CustomerCreatedV1WebhookEventDataAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerCreatedV1WebhookEventDataAddressFromRaw
    : IFromRawJson<CustomerCreatedV1WebhookEventDataAddress>
{
    /// <inheritdoc/>
    public CustomerCreatedV1WebhookEventDataAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerCreatedV1WebhookEventDataAddress.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerCreatedV1WebhookEventDataComplianceProfile,
        CustomerCreatedV1WebhookEventDataComplianceProfileFromRaw
    >)
)]
public sealed record class CustomerCreatedV1WebhookEventDataComplianceProfile : JsonModel
{
    /// <summary>
    /// Masked date of birth for an individual customer in `****-**-**` format.
    /// </summary>
    public string? Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dob");
        }
        init { this._rawData.Set("dob", value); }
    }

    /// <summary>
    /// Masked Employer Identification Number for a business customer in `**-*******` format.
    /// </summary>
    public string? Ein
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ein");
        }
        init { this._rawData.Set("ein", value); }
    }

    /// <summary>
    /// Official registered name of the business customer.
    /// </summary>
    public string? LegalBusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_business_name");
        }
        init { this._rawData.Set("legal_business_name", value); }
    }

    /// <summary>
    /// Masked Social Security number for an individual customer in `***-**-****` format.
    /// </summary>
    public string? Ssn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ssn");
        }
        init { this._rawData.Set("ssn", value); }
    }

    /// <summary>
    /// Official website URL for the business customer.
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dob;
        _ = this.Ein;
        _ = this.LegalBusinessName;
        _ = this.Ssn;
        _ = this.Website;
    }

    public CustomerCreatedV1WebhookEventDataComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerCreatedV1WebhookEventDataComplianceProfile(
        CustomerCreatedV1WebhookEventDataComplianceProfile customerCreatedV1WebhookEventDataComplianceProfile
    )
        : base(customerCreatedV1WebhookEventDataComplianceProfile) { }
#pragma warning restore CS8618

    public CustomerCreatedV1WebhookEventDataComplianceProfile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerCreatedV1WebhookEventDataComplianceProfile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerCreatedV1WebhookEventDataComplianceProfileFromRaw.FromRawUnchecked"/>
    public static CustomerCreatedV1WebhookEventDataComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerCreatedV1WebhookEventDataComplianceProfileFromRaw
    : IFromRawJson<CustomerCreatedV1WebhookEventDataComplianceProfile>
{
    /// <inheritdoc/>
    public CustomerCreatedV1WebhookEventDataComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerCreatedV1WebhookEventDataComplianceProfile.FromRawUnchecked(rawData);
}
