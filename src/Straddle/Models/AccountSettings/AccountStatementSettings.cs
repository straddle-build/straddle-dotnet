using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.AccountSettings;

[JsonConverter(
    typeof(JsonModelConverter<AccountStatementSettings, AccountStatementSettingsFromRaw>)
)]
public sealed record class AccountStatementSettings : JsonModel
{
    /// <summary>
    /// Company identifier used in ACH records.
    /// </summary>
    public string? CompanyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_id");
        }
        init { this._rawData.Set("company_id", value); }
    }

    /// <summary>
    /// Company name used in statement records.
    /// </summary>
    public string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init { this._rawData.Set("company_name", value); }
    }

    /// <summary>
    /// Default descriptor for account payments.
    /// </summary>
    public string? DefaultDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_descriptor");
        }
        init { this._rawData.Set("default_descriptor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompanyID;
        _ = this.CompanyName;
        _ = this.DefaultDescriptor;
    }

    public AccountStatementSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatementSettings(AccountStatementSettings accountStatementSettings)
        : base(accountStatementSettings) { }
#pragma warning restore CS8618

    public AccountStatementSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatementSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatementSettingsFromRaw.FromRawUnchecked"/>
    public static AccountStatementSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountStatementSettingsFromRaw : IFromRawJson<AccountStatementSettings>
{
    /// <inheritdoc/>
    public AccountStatementSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountStatementSettings.FromRawUnchecked(rawData);
}
