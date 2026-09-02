using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.AccountSettings;

[JsonConverter(
    typeof(JsonModelConverter<
        AccountSettingsAccountSettings,
        AccountSettingsAccountSettingsFromRaw
    >)
)]
public sealed record class AccountSettingsAccountSettings : JsonModel
{
    public required ChargeSettings Charges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeSettings>("charges");
        }
        init { this._rawData.Set("charges", value); }
    }

    public required AccountPolicyControls Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountPolicyControls>("configuration");
        }
        init { this._rawData.Set("configuration", value); }
    }

    public required AccountConsentSettings ConsentTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountConsentSettings>("consent_types");
        }
        init { this._rawData.Set("consent_types", value); }
    }

    public required AccountCustomerTypeSettings CustomerTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountCustomerTypeSettings>("customer_types");
        }
        init { this._rawData.Set("customer_types", value); }
    }

    public required AccountPaymentTypeSettings PaymentTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountPaymentTypeSettings>("payment_types");
        }
        init { this._rawData.Set("payment_types", value); }
    }

    public required PayoutSettings Payouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutSettings>("payouts");
        }
        init { this._rawData.Set("payouts", value); }
    }

    public required AccountStatementSettings StatementSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountStatementSettings>("statement_settings");
        }
        init { this._rawData.Set("statement_settings", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Charges.Validate();
        this.Configuration.Validate();
        this.ConsentTypes.Validate();
        this.CustomerTypes.Validate();
        this.PaymentTypes.Validate();
        this.Payouts.Validate();
        this.StatementSettings.Validate();
    }

    public AccountSettingsAccountSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSettingsAccountSettings(
        AccountSettingsAccountSettings accountSettingsAccountSettings
    )
        : base(accountSettingsAccountSettings) { }
#pragma warning restore CS8618

    public AccountSettingsAccountSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSettingsAccountSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSettingsAccountSettingsFromRaw.FromRawUnchecked"/>
    public static AccountSettingsAccountSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountSettingsAccountSettingsFromRaw : IFromRawJson<AccountSettingsAccountSettings>
{
    /// <inheritdoc/>
    public AccountSettingsAccountSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountSettingsAccountSettings.FromRawUnchecked(rawData);
}
