using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.AccountSettings;

[JsonConverter(
    typeof(JsonModelConverter<AccountPaymentTypeSettings, AccountPaymentTypeSettingsFromRaw>)
)]
public sealed record class AccountPaymentTypeSettings : JsonModel
{
    /// <summary>
    /// Status of charge support for the account.
    /// </summary>
    public required ApiEnum<string, AccountPaymentTypeSettingsCharges> Charges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountPaymentTypeSettingsCharges>
            >("charges");
        }
        init { this._rawData.Set("charges", value); }
    }

    /// <summary>
    /// Status of payout support for the account.
    /// </summary>
    public required ApiEnum<string, AccountPaymentTypeSettingsPayouts> Payouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountPaymentTypeSettingsPayouts>
            >("payouts");
        }
        init { this._rawData.Set("payouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Charges.Validate();
        this.Payouts.Validate();
    }

    public AccountPaymentTypeSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountPaymentTypeSettings(AccountPaymentTypeSettings accountPaymentTypeSettings)
        : base(accountPaymentTypeSettings) { }
#pragma warning restore CS8618

    public AccountPaymentTypeSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountPaymentTypeSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountPaymentTypeSettingsFromRaw.FromRawUnchecked"/>
    public static AccountPaymentTypeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountPaymentTypeSettingsFromRaw : IFromRawJson<AccountPaymentTypeSettings>
{
    /// <inheritdoc/>
    public AccountPaymentTypeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountPaymentTypeSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of charge support for the account.
/// </summary>
[JsonConverter(typeof(AccountPaymentTypeSettingsChargesConverter))]
public enum AccountPaymentTypeSettingsCharges
{
    Active,
    Inactive,
}

sealed class AccountPaymentTypeSettingsChargesConverter
    : JsonConverter<AccountPaymentTypeSettingsCharges>
{
    public override AccountPaymentTypeSettingsCharges Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountPaymentTypeSettingsCharges.Active,
            "inactive" => AccountPaymentTypeSettingsCharges.Inactive,
            _ => (AccountPaymentTypeSettingsCharges)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountPaymentTypeSettingsCharges value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountPaymentTypeSettingsCharges.Active => "active",
                AccountPaymentTypeSettingsCharges.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of payout support for the account.
/// </summary>
[JsonConverter(typeof(AccountPaymentTypeSettingsPayoutsConverter))]
public enum AccountPaymentTypeSettingsPayouts
{
    Active,
    Inactive,
}

sealed class AccountPaymentTypeSettingsPayoutsConverter
    : JsonConverter<AccountPaymentTypeSettingsPayouts>
{
    public override AccountPaymentTypeSettingsPayouts Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountPaymentTypeSettingsPayouts.Active,
            "inactive" => AccountPaymentTypeSettingsPayouts.Inactive,
            _ => (AccountPaymentTypeSettingsPayouts)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountPaymentTypeSettingsPayouts value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountPaymentTypeSettingsPayouts.Active => "active",
                AccountPaymentTypeSettingsPayouts.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
