using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(JsonModelConverter<PaykeyBalanceDetails, PaykeyBalanceDetailsFromRaw>))]
public sealed record class PaykeyBalanceDetails : JsonModel
{
    public required ApiEnum<string, PaykeyBalanceRefreshStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaykeyBalanceRefreshStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Most recently retrieved account balance in cents.
    /// </summary>
    public int? AccountBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("account_balance");
        }
        init { this._rawData.Set("account_balance", value); }
    }

    /// <summary>
    /// Timestamp of the most recent account balance update.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.AccountBalance;
        _ = this.UpdatedAt;
    }

    public PaykeyBalanceDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyBalanceDetails(PaykeyBalanceDetails paykeyBalanceDetails)
        : base(paykeyBalanceDetails) { }
#pragma warning restore CS8618

    public PaykeyBalanceDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyBalanceDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyBalanceDetailsFromRaw.FromRawUnchecked"/>
    public static PaykeyBalanceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaykeyBalanceDetails(ApiEnum<string, PaykeyBalanceRefreshStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class PaykeyBalanceDetailsFromRaw : IFromRawJson<PaykeyBalanceDetails>
{
    /// <inheritdoc/>
    public PaykeyBalanceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyBalanceDetails.FromRawUnchecked(rawData);
}
