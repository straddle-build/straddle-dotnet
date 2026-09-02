using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountCapabilities, AccountCapabilitiesFromRaw>))]
public sealed record class AccountCapabilities : JsonModel
{
    public required AccountConsentCapabilities ConsentTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountConsentCapabilities>("consent_types");
        }
        init { this._rawData.Set("consent_types", value); }
    }

    public required AccountCustomerCapabilities CustomerTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCustomerCapabilities>("customer_types");
        }
        init { this._rawData.Set("customer_types", value); }
    }

    public required AccountPaymentCapabilities PaymentTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountPaymentCapabilities>("payment_types");
        }
        init { this._rawData.Set("payment_types", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ConsentTypes.Validate();
        this.CustomerTypes.Validate();
        this.PaymentTypes.Validate();
    }

    public AccountCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCapabilities(AccountCapabilities accountCapabilities)
        : base(accountCapabilities) { }
#pragma warning restore CS8618

    public AccountCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCapabilitiesFromRaw.FromRawUnchecked"/>
    public static AccountCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountCapabilitiesFromRaw : IFromRawJson<AccountCapabilities>
{
    /// <inheritdoc/>
    public AccountCapabilities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountCapabilities.FromRawUnchecked(rawData);
}
