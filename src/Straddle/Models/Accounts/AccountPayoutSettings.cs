using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountPayoutSettings, AccountPayoutSettingsFromRaw>))]
public sealed record class AccountPayoutSettings : JsonModel
{
    /// <summary>
    /// Daily payout amount limit in cents.
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
    /// Funding schedule for payouts. Straddle sets this value.
    /// </summary>
    public required ApiEnum<string, AccountPayoutSettingsFundingTime> FundingTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountPayoutSettingsFundingTime>>(
                "funding_time"
            );
        }
        init { this._rawData.Set("funding_time", value); }
    }

    /// <summary>
    /// ID of the linked bank account used for payout settlement.
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
    /// Maximum amount in cents for one payout.
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
    /// Monthly payout amount limit in cents.
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
    /// Maximum number of payouts per calendar month.
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

    public AccountPayoutSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountPayoutSettings(AccountPayoutSettings accountPayoutSettings)
        : base(accountPayoutSettings) { }
#pragma warning restore CS8618

    public AccountPayoutSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountPayoutSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountPayoutSettingsFromRaw.FromRawUnchecked"/>
    public static AccountPayoutSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountPayoutSettingsFromRaw : IFromRawJson<AccountPayoutSettings>
{
    /// <inheritdoc/>
    public AccountPayoutSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountPayoutSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Funding schedule for payouts. Straddle sets this value.
/// </summary>
[JsonConverter(typeof(AccountPayoutSettingsFundingTimeConverter))]
public enum AccountPayoutSettingsFundingTime
{
    Immediate,
    NextDay,
    OneDay,
    TwoDay,
    ThreeDay,
    FourDay,
    FiveDay,
}

sealed class AccountPayoutSettingsFundingTimeConverter
    : JsonConverter<AccountPayoutSettingsFundingTime>
{
    public override AccountPayoutSettingsFundingTime Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => AccountPayoutSettingsFundingTime.Immediate,
            "next_day" => AccountPayoutSettingsFundingTime.NextDay,
            "one_day" => AccountPayoutSettingsFundingTime.OneDay,
            "two_day" => AccountPayoutSettingsFundingTime.TwoDay,
            "three_day" => AccountPayoutSettingsFundingTime.ThreeDay,
            "four_day" => AccountPayoutSettingsFundingTime.FourDay,
            "five_day" => AccountPayoutSettingsFundingTime.FiveDay,
            _ => (AccountPayoutSettingsFundingTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountPayoutSettingsFundingTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountPayoutSettingsFundingTime.Immediate => "immediate",
                AccountPayoutSettingsFundingTime.NextDay => "next_day",
                AccountPayoutSettingsFundingTime.OneDay => "one_day",
                AccountPayoutSettingsFundingTime.TwoDay => "two_day",
                AccountPayoutSettingsFundingTime.ThreeDay => "three_day",
                AccountPayoutSettingsFundingTime.FourDay => "four_day",
                AccountPayoutSettingsFundingTime.FiveDay => "five_day",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
