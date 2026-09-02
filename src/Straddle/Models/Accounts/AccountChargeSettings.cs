using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountChargeSettings, AccountChargeSettingsFromRaw>))]
public sealed record class AccountChargeSettings : JsonModel
{
    /// <summary>
    /// Daily charge amount limit in cents.
    /// </summary>
    public required int DailyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("daily_amount");
        }
        init { this._rawData.Set("daily_amount", value); }
    }

    /// <summary>
    /// Funding schedule for charges. Straddle sets this value.
    /// </summary>
    public required ApiEnum<string, FundingTime> FundingTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FundingTime>>("funding_time");
        }
        init { this._rawData.Set("funding_time", value); }
    }

    /// <summary>
    /// ID of the linked bank account used for charge settlement. Straddle sets this value.
    /// </summary>
    public required string LinkedBankAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("linked_bank_account_id");
        }
        init { this._rawData.Set("linked_bank_account_id", value); }
    }

    /// <summary>
    /// Maximum amount in cents for one charge.
    /// </summary>
    public required int MaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("max_amount");
        }
        init { this._rawData.Set("max_amount", value); }
    }

    /// <summary>
    /// Monthly charge amount limit in cents.
    /// </summary>
    public required int MonthlyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("monthly_amount");
        }
        init { this._rawData.Set("monthly_amount", value); }
    }

    /// <summary>
    /// Maximum number of charges per calendar month.
    /// </summary>
    public required int MonthlyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("monthly_count");
        }
        init { this._rawData.Set("monthly_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAmount;
        this.FundingTime.Validate();
        _ = this.LinkedBankAccountID;
        _ = this.MaxAmount;
        _ = this.MonthlyAmount;
        _ = this.MonthlyCount;
    }

    public AccountChargeSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountChargeSettings(AccountChargeSettings accountChargeSettings)
        : base(accountChargeSettings) { }
#pragma warning restore CS8618

    public AccountChargeSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountChargeSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountChargeSettingsFromRaw.FromRawUnchecked"/>
    public static AccountChargeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountChargeSettingsFromRaw : IFromRawJson<AccountChargeSettings>
{
    /// <inheritdoc/>
    public AccountChargeSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountChargeSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Funding schedule for charges. Straddle sets this value.
/// </summary>
[JsonConverter(typeof(FundingTimeConverter))]
public enum FundingTime
{
    Immediate,
    NextDay,
    OneDay,
    TwoDay,
    ThreeDay,
    FourDay,
    FiveDay,
}

sealed class FundingTimeConverter : JsonConverter<FundingTime>
{
    public override FundingTime Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => FundingTime.Immediate,
            "next_day" => FundingTime.NextDay,
            "one_day" => FundingTime.OneDay,
            "two_day" => FundingTime.TwoDay,
            "three_day" => FundingTime.ThreeDay,
            "four_day" => FundingTime.FourDay,
            "five_day" => FundingTime.FiveDay,
            _ => (FundingTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingTime.Immediate => "immediate",
                FundingTime.NextDay => "next_day",
                FundingTime.OneDay => "one_day",
                FundingTime.TwoDay => "two_day",
                FundingTime.ThreeDay => "three_day",
                FundingTime.FourDay => "four_day",
                FundingTime.FiveDay => "five_day",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
