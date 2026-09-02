using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.AccountSettings;

[JsonConverter(typeof(JsonModelConverter<AccountConsentSettings, AccountConsentSettingsFromRaw>))]
public sealed record class AccountConsentSettings : JsonModel
{
    /// <summary>
    /// Status of internet authorization support for the account.
    /// </summary>
    public required ApiEnum<string, Internet> Internet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Internet>>("internet");
        }
        init { this._rawData.Set("internet", value); }
    }

    /// <summary>
    /// Status of signed-agreement authorization support for the account.
    /// </summary>
    public required ApiEnum<string, SignedAgreement> SignedAgreement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SignedAgreement>>(
                "signed_agreement"
            );
        }
        init { this._rawData.Set("signed_agreement", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Internet.Validate();
        this.SignedAgreement.Validate();
    }

    public AccountConsentSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConsentSettings(AccountConsentSettings accountConsentSettings)
        : base(accountConsentSettings) { }
#pragma warning restore CS8618

    public AccountConsentSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConsentSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConsentSettingsFromRaw.FromRawUnchecked"/>
    public static AccountConsentSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConsentSettingsFromRaw : IFromRawJson<AccountConsentSettings>
{
    /// <inheritdoc/>
    public AccountConsentSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConsentSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of internet authorization support for the account.
/// </summary>
[JsonConverter(typeof(InternetConverter))]
public enum Internet
{
    Active,
    Inactive,
}

sealed class InternetConverter : JsonConverter<Internet>
{
    public override Internet Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Internet.Active,
            "inactive" => Internet.Inactive,
            _ => (Internet)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Internet value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Internet.Active => "active",
                Internet.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of signed-agreement authorization support for the account.
/// </summary>
[JsonConverter(typeof(SignedAgreementConverter))]
public enum SignedAgreement
{
    Active,
    Inactive,
}

sealed class SignedAgreementConverter : JsonConverter<SignedAgreement>
{
    public override SignedAgreement Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => SignedAgreement.Active,
            "inactive" => SignedAgreement.Inactive,
            _ => (SignedAgreement)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SignedAgreement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SignedAgreement.Active => "active",
                SignedAgreement.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
