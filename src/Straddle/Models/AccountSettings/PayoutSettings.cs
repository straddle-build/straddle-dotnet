using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.AccountSettings;

[JsonConverter(typeof(JsonModelConverter<PayoutSettings, PayoutSettingsFromRaw>))]
public sealed record class PayoutSettings : JsonModel
{
    /// <summary>
    /// Daily payout amount limit in cents.
    /// </summary>
    public required long DailyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("daily_amount");
        }
        init { this._rawData.Set("daily_amount", value); }
    }

    /// <summary>
    /// Maximum amount in cents for one payout.
    /// </summary>
    public required long MaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_amount");
        }
        init { this._rawData.Set("max_amount", value); }
    }

    /// <summary>
    /// Monthly payout amount limit in cents.
    /// </summary>
    public required long MonthlyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("monthly_amount");
        }
        init { this._rawData.Set("monthly_amount", value); }
    }

    /// <summary>
    /// Maximum number of payouts per calendar month.
    /// </summary>
    public required long MonthlyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("monthly_count");
        }
        init { this._rawData.Set("monthly_count", value); }
    }

    /// <summary>
    /// Funding schedule applied to payouts.
    /// </summary>
    public string? FundingTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("funding_time");
        }
        init { this._rawData.Set("funding_time", value); }
    }

    /// <summary>
    /// ID of the linked bank account used for payout settlement.
    /// </summary>
    public string? LinkedBankAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("linked_bank_account_id");
        }
        init { this._rawData.Set("linked_bank_account_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAmount;
        _ = this.MaxAmount;
        _ = this.MonthlyAmount;
        _ = this.MonthlyCount;
        _ = this.FundingTime;
        _ = this.LinkedBankAccountID;
    }

    public PayoutSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutSettings(PayoutSettings payoutSettings)
        : base(payoutSettings) { }
#pragma warning restore CS8618

    public PayoutSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutSettingsFromRaw.FromRawUnchecked"/>
    public static PayoutSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutSettingsFromRaw : IFromRawJson<PayoutSettings>
{
    /// <inheritdoc/>
    public PayoutSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayoutSettings.FromRawUnchecked(rawData);
}
