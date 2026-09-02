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
using Straddle.Models.LinkedBankAccounts;

namespace Straddle.Models.FundingEvents;

[JsonConverter(typeof(JsonModelConverter<FundingEvent, FundingEventFromRaw>))]
public sealed record class FundingEvent : JsonModel
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
    public required ApiEnum<string, FundingEventTransferDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FundingEventTransferDirection>>(
                "direction"
            );
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
    /// Complete ordered history of all status changes for this funding event.
    /// </summary>
    public required IReadOnlyList<PaymentStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PaymentStatusHistory>>(
                "status_history"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PaymentStatusHistory>>(
                "status_history",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Configuration used to process this funding event.
    /// </summary>
    public FundingEventConfiguration? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FundingEventConfiguration>("config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("config", value);
        }
    }

    /// <summary>
    /// Details of the linked bank account used for this funding event.
    /// </summary>
    public UnmaskedLinkedBankAccountDetails? LinkedBankAccountDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnmaskedLinkedBankAccountDetails>(
                "linked_bank_account_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("linked_bank_account_details", value);
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Direction.Validate();
        this.EventType.Validate();
        _ = this.PaymentCount;
        foreach (var item in this.StatusHistory)
        {
            item.Validate();
        }
        _ = this.TraceIds;
        _ = this.TraceNumbers;
        _ = this.TransferDate;
        _ = this.UpdatedAt;
        this.Config?.Validate();
        this.LinkedBankAccountDetails?.Validate();
        this.Status?.Validate();
        this.StatusDetails?.Validate();
    }

    public FundingEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEvent(FundingEvent fundingEvent)
        : base(fundingEvent) { }
#pragma warning restore CS8618

    public FundingEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventFromRaw.FromRawUnchecked"/>
    public static FundingEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventFromRaw : IFromRawJson<FundingEvent>
{
    /// <inheritdoc/>
    public FundingEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FundingEvent.FromRawUnchecked(rawData);
}
