using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountIndustry, AccountIndustryFromRaw>))]
public sealed record class AccountIndustry : JsonModel
{
    /// <summary>
    /// Industry category. Required when `mcc` is omitted.
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Merchant category code (MCC) that best describes the business. If omitted,
    /// provide both `sector` and `category`.
    /// </summary>
    public string? Mcc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mcc");
        }
        init { this._rawData.Set("mcc", value); }
    }

    /// <summary>
    /// Business sector. Required when `mcc` is omitted.
    /// </summary>
    public string? Sector
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sector");
        }
        init { this._rawData.Set("sector", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Category;
        _ = this.Mcc;
        _ = this.Sector;
    }

    public AccountIndustry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountIndustry(AccountIndustry accountIndustry)
        : base(accountIndustry) { }
#pragma warning restore CS8618

    public AccountIndustry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountIndustry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountIndustryFromRaw.FromRawUnchecked"/>
    public static AccountIndustry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountIndustryFromRaw : IFromRawJson<AccountIndustry>
{
    /// <inheritdoc/>
    public AccountIndustry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountIndustry.FromRawUnchecked(rawData);
}
