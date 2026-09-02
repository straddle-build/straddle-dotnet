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
    typeof(JsonModelConverter<CustomerEventV1WebhookEvent, CustomerEventV1WebhookEventFromRaw>)
)]
public sealed record class CustomerEventV1WebhookEvent : JsonModel
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

    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
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

    public CustomerEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerEventV1WebhookEvent(CustomerEventV1WebhookEvent customerEventV1WebhookEvent)
        : base(customerEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public CustomerEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static CustomerEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerEventV1WebhookEventFromRaw : IFromRawJson<CustomerEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public CustomerEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public Address? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("address");
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

    public global::Straddle.Models.Webhooks.ComplianceProfile? ComplianceProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Straddle.Models.Webhooks.ComplianceProfile>(
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Review,
    Verified,
    Inactive,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "review" => Status.Review,
            "verified" => Status.Verified,
            "inactive" => Status.Inactive,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Review => "review",
                Status.Verified => "verified",
                Status.Inactive => "inactive",
                Status.Rejected => "rejected",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
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

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ComplianceProfile, ComplianceProfileFromRaw>))]
public sealed record class ComplianceProfile : JsonModel
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

    public ComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceProfile(ComplianceProfile complianceProfile)
        : base(complianceProfile) { }
#pragma warning restore CS8618

    public ComplianceProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceProfileFromRaw.FromRawUnchecked"/>
    public static ComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceProfileFromRaw : IFromRawJson<ComplianceProfile>
{
    /// <inheritdoc/>
    public ComplianceProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComplianceProfile.FromRawUnchecked(rawData);
}
