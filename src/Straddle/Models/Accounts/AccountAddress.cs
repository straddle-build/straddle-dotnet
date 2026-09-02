using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

/// <summary>
/// Optional business address. If provided, `line1`, `city`, `state`, and
/// `postal_code` are required.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountAddress, AccountAddressFromRaw>))]
public sealed record class AccountAddress : JsonModel
{
    /// <summary>
    /// City, district, suburb, town, or village.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Primary address line, such as a street address or PO Box.
    /// </summary>
    public required string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// Postal or ZIP code.
    /// </summary>
    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// Two-letter state code.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Two-letter ISO 3166-1 country code. If omitted, Straddle applies US address validation.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Secondary address line, such as an apartment, suite, unit, or building.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Country;
        _ = this.Line2;
    }

    public AccountAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountAddress(AccountAddress accountAddress)
        : base(accountAddress) { }
#pragma warning restore CS8618

    public AccountAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountAddressFromRaw.FromRawUnchecked"/>
    public static AccountAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountAddressFromRaw : IFromRawJson<AccountAddress>
{
    /// <inheritdoc/>
    public AccountAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountAddress.FromRawUnchecked(rawData);
}
