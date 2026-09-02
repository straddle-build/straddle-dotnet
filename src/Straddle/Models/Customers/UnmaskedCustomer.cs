using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<UnmaskedCustomer, UnmaskedCustomerFromRaw>))]
public sealed record class UnmaskedCustomer : JsonModel
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

    /// <summary>
    /// The customer's email address.
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
    /// The customer's phone number in E.164 format.
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

    public required ApiEnum<string, CustomerStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomerStatus>>("status");
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

    /// <summary>
    /// Customer postal address. When provided, the object must include all required fields.
    /// </summary>
    public CustomerAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public UnmaskedComplianceProfile? ComplianceProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnmaskedComplianceProfile>("compliance_profile");
        }
        init { this._rawData.Set("compliance_profile", value); }
    }

    public CustomerConfiguration? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerConfiguration>("config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("config", value);
        }
    }

    public CustomerDevice? Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerDevice>("device");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("device", value);
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
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
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
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.Address?.Validate();
        this.ComplianceProfile?.Validate();
        this.Config?.Validate();
        this.Device?.Validate();
        _ = this.ExternalID;
        _ = this.Metadata;
    }

    public UnmaskedCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedCustomer(UnmaskedCustomer unmaskedCustomer)
        : base(unmaskedCustomer) { }
#pragma warning restore CS8618

    public UnmaskedCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedCustomerFromRaw.FromRawUnchecked"/>
    public static UnmaskedCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedCustomerFromRaw : IFromRawJson<UnmaskedCustomer>
{
    /// <inheritdoc/>
    public UnmaskedCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnmaskedCustomer.FromRawUnchecked(rawData);
}
