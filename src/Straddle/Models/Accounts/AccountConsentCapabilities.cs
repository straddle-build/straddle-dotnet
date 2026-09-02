using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountConsentCapabilities, AccountConsentCapabilitiesFromRaw>)
)]
public sealed record class AccountConsentCapabilities : JsonModel
{
    /// <summary>
    /// Internet payment authorization capability for the account.
    /// </summary>
    public required AccountCapability Internet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("internet");
        }
        init { this._rawData.Set("internet", value); }
    }

    /// <summary>
    /// Signed-agreement payment authorization capability for the account.
    /// </summary>
    public required AccountCapability SignedAgreement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCapability>("signed_agreement");
        }
        init { this._rawData.Set("signed_agreement", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Internet.Validate();
        this.SignedAgreement.Validate();
    }

    public AccountConsentCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConsentCapabilities(AccountConsentCapabilities accountConsentCapabilities)
        : base(accountConsentCapabilities) { }
#pragma warning restore CS8618

    public AccountConsentCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConsentCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConsentCapabilitiesFromRaw.FromRawUnchecked"/>
    public static AccountConsentCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConsentCapabilitiesFromRaw : IFromRawJson<AccountConsentCapabilities>
{
    /// <inheritdoc/>
    public AccountConsentCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConsentCapabilities.FromRawUnchecked(rawData);
}
