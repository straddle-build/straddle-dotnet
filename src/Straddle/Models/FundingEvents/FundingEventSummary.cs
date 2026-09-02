using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;
using Straddle.Models.Charges;

namespace Straddle.Models.FundingEvents;

[JsonConverter(typeof(JsonModelConverter<FundingEventSummary, FundingEventSummaryFromRaw>))]
public sealed record class FundingEventSummary : JsonModel
{
    /// <summary>
    /// Unique identifier for this funding event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Total funding event amount in the smallest currency unit. For example, `1000` is $10.00 USD.
    /// </summary>
    public required int Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Timestamp when this funding event was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Transfer direction relative to the linked bank account. `deposit` moves
    /// funds into the account, and `withdrawal` moves funds out.
    /// </summary>
    public required ApiEnum<string, TransferDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransferDirection>>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// Reason for the funding event. `charge_deposit` settles collected charges to
    /// the linked bank account. `charge_reversal` withdraws funds for reversed
    /// charges. `payout_withdrawal` withdraws funds for payouts. `payout_return`
    /// deposits returned payout funds.
    /// </summary>
    public required ApiEnum<string, FundingEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FundingEventType>>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <summary>
    /// Number of payments included in this funding event.
    /// </summary>
    public required int PaymentCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("payment_count");
        }
        init { this._rawData.Set("payment_count", value); }
    }

    /// <summary>
    /// Network-level trace identifiers assigned during processing. Keys vary by payment rail.
    /// </summary>
    public required IReadOnlyDictionary<string, string> TraceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("trace_ids");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "trace_ids",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Network trace numbers associated with payments in this funding event.
    /// </summary>
    public required IReadOnlyList<string> TraceNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("trace_numbers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "trace_numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date the funds transfer was initiated.
    /// </summary>
    public required string TransferDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transfer_date");
        }
        init { this._rawData.Set("transfer_date", value); }
    }

    /// <summary>
    /// Timestamp when this funding event was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Current status of this funding event.
    /// </summary>
    public ApiEnum<string, PaymentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Reason, source, and message for the most recent status change.
    /// </summary>
    public PaymentStatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentStatusDetails>("status_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status_details", value);
        }
    }

    /// <summary>
    /// The trace number of the funding event.
    /// </summary>
    public string? TraceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trace_number");
        }
        init { this._rawData.Set("trace_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Direction.Validate();
        this.EventType.Validate();
        _ = this.PaymentCount;
        _ = this.TraceIds;
        _ = this.TraceNumbers;
        _ = this.TransferDate;
        _ = this.UpdatedAt;
        this.Status?.Validate();
        this.StatusDetails?.Validate();
        _ = this.TraceNumber;
    }

    public FundingEventSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventSummary(FundingEventSummary fundingEventSummary)
        : base(fundingEventSummary) { }
#pragma warning restore CS8618

    public FundingEventSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventSummaryFromRaw.FromRawUnchecked"/>
    public static FundingEventSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventSummaryFromRaw : IFromRawJson<FundingEventSummary>
{
    /// <inheritdoc/>
    public FundingEventSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FundingEventSummary.FromRawUnchecked(rawData);
}
