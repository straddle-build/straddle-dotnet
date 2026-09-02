using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountCustomerCapabilities, AccountCustomerCapabilitiesFromRaw>)
)]
public sealed record class AccountCustomerCapabilities : JsonModel
{
    public required AccountCapability Businesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("businesses");
        }
        init { this._rawData.Set("businesses", value); }
    }

    public required AccountCapability Individuals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("individuals");
        }
        init { this._rawData.Set("individuals", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Businesses.Validate();
        this.Individuals.Validate();
    }

    public AccountCustomerCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCustomerCapabilities(AccountCustomerCapabilities accountCustomerCapabilities)
        : base(accountCustomerCapabilities) { }
#pragma warning restore CS8618

    public AccountCustomerCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCustomerCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCustomerCapabilitiesFromRaw.FromRawUnchecked"/>
    public static AccountCustomerCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountCustomerCapabilitiesFromRaw : IFromRawJson<AccountCustomerCapabilities>
{
    /// <inheritdoc/>
    public AccountCustomerCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountCustomerCapabilities.FromRawUnchecked(rawData);
}
