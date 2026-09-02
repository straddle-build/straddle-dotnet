using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers;

/// <summary>
/// Customer postal address. When provided, the object must include all required fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerAddress, CustomerAddressFromRaw>))]
public sealed record class CustomerAddress : JsonModel
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

    public CustomerAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerAddress(CustomerAddress customerAddress)
        : base(customerAddress) { }
#pragma warning restore CS8618

    public CustomerAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerAddressFromRaw.FromRawUnchecked"/>
    public static CustomerAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerAddressFromRaw : IFromRawJson<CustomerAddress>
{
    /// <inheritdoc/>
    public CustomerAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerAddress.FromRawUnchecked(rawData);
}
