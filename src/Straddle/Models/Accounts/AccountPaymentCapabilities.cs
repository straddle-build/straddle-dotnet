using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountPaymentCapabilities, AccountPaymentCapabilitiesFromRaw>)
)]
public sealed record class AccountPaymentCapabilities : JsonModel
{
    public required AccountCapability Charges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("charges");
        }
        init { this._rawData.Set("charges", value); }
    }

    public required AccountCapability Payouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("payouts");
        }
        init { this._rawData.Set("payouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Charges.Validate();
        this.Payouts.Validate();
    }

    public AccountPaymentCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountPaymentCapabilities(AccountPaymentCapabilities accountPaymentCapabilities)
        : base(accountPaymentCapabilities) { }
#pragma warning restore CS8618

    public AccountPaymentCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountPaymentCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountPaymentCapabilitiesFromRaw.FromRawUnchecked"/>
    public static AccountPaymentCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountPaymentCapabilitiesFromRaw : IFromRawJson<AccountPaymentCapabilities>
{
    /// <inheritdoc/>
    public AccountPaymentCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountPaymentCapabilities.FromRawUnchecked(rawData);
}
