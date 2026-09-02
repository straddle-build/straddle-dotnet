using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountPaymentSettings, AccountPaymentSettingsFromRaw>))]
public sealed record class AccountPaymentSettings : JsonModel
{
    public required AccountChargeSettings Charges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountChargeSettings>("charges");
        }
        init { this._rawData.Set("charges", value); }
    }

    public required AccountPayoutSettings Payouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountPayoutSettings>("payouts");
        }
        init { this._rawData.Set("payouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Charges.Validate();
        this.Payouts.Validate();
    }

    public AccountPaymentSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountPaymentSettings(AccountPaymentSettings accountPaymentSettings)
        : base(accountPaymentSettings) { }
#pragma warning restore CS8618

    public AccountPaymentSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountPaymentSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountPaymentSettingsFromRaw.FromRawUnchecked"/>
    public static AccountPaymentSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountPaymentSettingsFromRaw : IFromRawJson<AccountPaymentSettings>
{
    /// <inheritdoc/>
    public AccountPaymentSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountPaymentSettings.FromRawUnchecked(rawData);
}
