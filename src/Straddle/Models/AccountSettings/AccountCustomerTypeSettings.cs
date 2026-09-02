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
    typeof(JsonModelConverter<AccountCustomerTypeSettings, AccountCustomerTypeSettingsFromRaw>)
)]
public sealed record class AccountCustomerTypeSettings : JsonModel
{
    /// <summary>
    /// Status of business-customer support for the account.
    /// </summary>
    public required ApiEnum<string, Businesses> Businesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Businesses>>("businesses");
        }
        init { this._rawData.Set("businesses", value); }
    }

    /// <summary>
    /// Status of individual-customer support for the account.
    /// </summary>
    public required ApiEnum<string, Individuals> Individuals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Individuals>>("individuals");
        }
        init { this._rawData.Set("individuals", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Businesses.Validate();
        this.Individuals.Validate();
    }

    public AccountCustomerTypeSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCustomerTypeSettings(AccountCustomerTypeSettings accountCustomerTypeSettings)
        : base(accountCustomerTypeSettings) { }
#pragma warning restore CS8618

    public AccountCustomerTypeSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCustomerTypeSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCustomerTypeSettingsFromRaw.FromRawUnchecked"/>
    public static AccountCustomerTypeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountCustomerTypeSettingsFromRaw : IFromRawJson<AccountCustomerTypeSettings>
{
    /// <inheritdoc/>
    public AccountCustomerTypeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountCustomerTypeSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of business-customer support for the account.
/// </summary>
[JsonConverter(typeof(BusinessesConverter))]
public enum Businesses
{
    Active,
    Inactive,
}

sealed class BusinessesConverter : JsonConverter<Businesses>
{
    public override Businesses Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Businesses.Active,
            "inactive" => Businesses.Inactive,
            _ => (Businesses)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Businesses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Businesses.Active => "active",
                Businesses.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of individual-customer support for the account.
/// </summary>
[JsonConverter(typeof(IndividualsConverter))]
public enum Individuals
{
    Active,
    Inactive,
}

sealed class IndividualsConverter : JsonConverter<Individuals>
{
    public override Individuals Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Individuals.Active,
            "inactive" => Individuals.Inactive,
            _ => (Individuals)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Individuals value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Individuals.Active => "active",
                Individuals.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
