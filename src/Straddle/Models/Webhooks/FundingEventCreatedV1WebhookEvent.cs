using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Bridge;
using Straddle.Models.FundingEvents;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventCreatedV1WebhookEvent,
        FundingEventCreatedV1WebhookEventFromRaw
    >)
)]
public sealed record class FundingEventCreatedV1WebhookEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the account associated with this event.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required FundingEventCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FundingEventCreatedV1WebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// Type of this event.
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.Data.Validate();
        _ = this.EventID;
        _ = this.EventType;
    }

    public FundingEventCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventCreatedV1WebhookEvent(
        FundingEventCreatedV1WebhookEvent fundingEventCreatedV1WebhookEvent
    )
        : base(fundingEventCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public FundingEventCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static FundingEventCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventCreatedV1WebhookEventFromRaw : IFromRawJson<FundingEventCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public FundingEventCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventCreatedV1WebhookEventData,
        FundingEventCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class FundingEventCreatedV1WebhookEventData : JsonModel
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
    public required IReadOnlyList<FundingEventCreatedV1WebhookEventDataStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FundingEventCreatedV1WebhookEventDataStatusHistory>
            >("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FundingEventCreatedV1WebhookEventDataStatusHistory>>(
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
    public ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatus>
            >("status");
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
    public FundingEventCreatedV1WebhookEventDataStatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FundingEventCreatedV1WebhookEventDataStatusDetails>(
                "status_details"
            );
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
        _ = this.TransferDate;
        _ = this.UpdatedAt;
        this.Status?.Validate();
        this.StatusDetails?.Validate();
    }

    public FundingEventCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventCreatedV1WebhookEventData(
        FundingEventCreatedV1WebhookEventData fundingEventCreatedV1WebhookEventData
    )
        : base(fundingEventCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public FundingEventCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static FundingEventCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventCreatedV1WebhookEventDataFromRaw
    : IFromRawJson<FundingEventCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public FundingEventCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventCreatedV1WebhookEventDataStatusHistory,
        FundingEventCreatedV1WebhookEventDataStatusHistoryFromRaw
    >)
)]
public sealed record class FundingEventCreatedV1WebhookEventDataStatusHistory : JsonModel
{
    /// <summary>
    /// The time the status change occurred.
    /// </summary>
    public required DateTimeOffset ChangedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("changed_at");
        }
        init { this._rawData.Set("changed_at", value); }
    }

    /// <summary>
    /// A human-readable description of the status.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusHistoryReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    public required ApiEnum<string, PaymentStatusSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentStatusSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusHistoryStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The status code if applicable.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChangedAt;
        _ = this.Message;
        this.Reason.Validate();
        this.Source.Validate();
        this.Status.Validate();
        _ = this.Code;
    }

    public FundingEventCreatedV1WebhookEventDataStatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventCreatedV1WebhookEventDataStatusHistory(
        FundingEventCreatedV1WebhookEventDataStatusHistory fundingEventCreatedV1WebhookEventDataStatusHistory
    )
        : base(fundingEventCreatedV1WebhookEventDataStatusHistory) { }
#pragma warning restore CS8618

    public FundingEventCreatedV1WebhookEventDataStatusHistory(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventCreatedV1WebhookEventDataStatusHistory(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventCreatedV1WebhookEventDataStatusHistoryFromRaw.FromRawUnchecked"/>
    public static FundingEventCreatedV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventCreatedV1WebhookEventDataStatusHistoryFromRaw
    : IFromRawJson<FundingEventCreatedV1WebhookEventDataStatusHistory>
{
    /// <inheritdoc/>
    public FundingEventCreatedV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventCreatedV1WebhookEventDataStatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FundingEventCreatedV1WebhookEventDataStatusHistoryReasonConverter))]
public enum FundingEventCreatedV1WebhookEventDataStatusHistoryReason
{
    InsufficientFunds,
    ClosedBankAccount,
    InvalidBankAccount,
    InvalidRouting,
    Disputed,
    PaymentStopped,
    OwnerDeceased,
    FrozenBankAccount,
    RiskReview,
    Fraudulent,
    DuplicateEntry,
    InvalidPaykey,
    PaymentBlocked,
    AmountTooLarge,
    TooManyAttempts,
    InternalSystemError,
    UserRequest,
    Ok,
    OtherNetworkReturn,
    PayoutRefused,
    Validating,
    AutoHold,
}

sealed class FundingEventCreatedV1WebhookEventDataStatusHistoryReasonConverter
    : JsonConverter<FundingEventCreatedV1WebhookEventDataStatusHistoryReason>
{
    public override FundingEventCreatedV1WebhookEventDataStatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InsufficientFunds,
            "closed_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidBankAccount,
            "invalid_routing" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidRouting,
            "disputed" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Disputed,
            "payment_stopped" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PaymentStopped,
            "owner_deceased" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.FrozenBankAccount,
            "risk_review" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.RiskReview,
            "fraudulent" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Fraudulent,
            "duplicate_entry" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.DuplicateEntry,
            "invalid_paykey" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidPaykey,
            "payment_blocked" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PaymentBlocked,
            "amount_too_large" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.AmountTooLarge,
            "too_many_attempts" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.TooManyAttempts,
            "internal_system_error" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InternalSystemError,
            "user_request" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.UserRequest,
            "ok" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Ok,
            "other_network_return" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn,
            "payout_refused" =>
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PayoutRefused,
            "validating" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Validating,
            "auto_hold" => FundingEventCreatedV1WebhookEventDataStatusHistoryReason.AutoHold,
            _ => (FundingEventCreatedV1WebhookEventDataStatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventCreatedV1WebhookEventDataStatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InsufficientFunds =>
                    "insufficient_funds",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.ClosedBankAccount =>
                    "closed_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidBankAccount =>
                    "invalid_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidRouting =>
                    "invalid_routing",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Disputed => "disputed",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PaymentStopped =>
                    "payment_stopped",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.OwnerDeceased =>
                    "owner_deceased",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.FrozenBankAccount =>
                    "frozen_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.RiskReview =>
                    "risk_review",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Fraudulent => "fraudulent",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.DuplicateEntry =>
                    "duplicate_entry",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InvalidPaykey =>
                    "invalid_paykey",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PaymentBlocked =>
                    "payment_blocked",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.AmountTooLarge =>
                    "amount_too_large",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.TooManyAttempts =>
                    "too_many_attempts",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.InternalSystemError =>
                    "internal_system_error",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.UserRequest =>
                    "user_request",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Ok => "ok",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn =>
                    "other_network_return",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.PayoutRefused =>
                    "payout_refused",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.Validating => "validating",
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FundingEventCreatedV1WebhookEventDataStatusHistoryStatusConverter))]
public enum FundingEventCreatedV1WebhookEventDataStatusHistoryStatus
{
    Created,
    Scheduled,
    Failed,
    Cancelled,
    OnHold,
    Pending,
    Paid,
    Reversed,
}

sealed class FundingEventCreatedV1WebhookEventDataStatusHistoryStatusConverter
    : JsonConverter<FundingEventCreatedV1WebhookEventDataStatusHistoryStatus>
{
    public override FundingEventCreatedV1WebhookEventDataStatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Created,
            "scheduled" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Scheduled,
            "failed" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Failed,
            "cancelled" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Cancelled,
            "on_hold" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.OnHold,
            "pending" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Pending,
            "paid" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Paid,
            "reversed" => FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Reversed,
            _ => (FundingEventCreatedV1WebhookEventDataStatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventCreatedV1WebhookEventDataStatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Created => "created",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Scheduled => "scheduled",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Failed => "failed",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Cancelled => "cancelled",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.OnHold => "on_hold",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Pending => "pending",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Paid => "paid",
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus.Reversed => "reversed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current status of this funding event.
/// </summary>
[JsonConverter(typeof(FundingEventCreatedV1WebhookEventDataStatusConverter))]
public enum FundingEventCreatedV1WebhookEventDataStatus
{
    Created,
    Scheduled,
    Failed,
    Cancelled,
    OnHold,
    Pending,
    Paid,
    Reversed,
}

sealed class FundingEventCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<FundingEventCreatedV1WebhookEventDataStatus>
{
    public override FundingEventCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => FundingEventCreatedV1WebhookEventDataStatus.Created,
            "scheduled" => FundingEventCreatedV1WebhookEventDataStatus.Scheduled,
            "failed" => FundingEventCreatedV1WebhookEventDataStatus.Failed,
            "cancelled" => FundingEventCreatedV1WebhookEventDataStatus.Cancelled,
            "on_hold" => FundingEventCreatedV1WebhookEventDataStatus.OnHold,
            "pending" => FundingEventCreatedV1WebhookEventDataStatus.Pending,
            "paid" => FundingEventCreatedV1WebhookEventDataStatus.Paid,
            "reversed" => FundingEventCreatedV1WebhookEventDataStatus.Reversed,
            _ => (FundingEventCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventCreatedV1WebhookEventDataStatus.Created => "created",
                FundingEventCreatedV1WebhookEventDataStatus.Scheduled => "scheduled",
                FundingEventCreatedV1WebhookEventDataStatus.Failed => "failed",
                FundingEventCreatedV1WebhookEventDataStatus.Cancelled => "cancelled",
                FundingEventCreatedV1WebhookEventDataStatus.OnHold => "on_hold",
                FundingEventCreatedV1WebhookEventDataStatus.Pending => "pending",
                FundingEventCreatedV1WebhookEventDataStatus.Paid => "paid",
                FundingEventCreatedV1WebhookEventDataStatus.Reversed => "reversed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reason, source, and message for the most recent status change.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventCreatedV1WebhookEventDataStatusDetails,
        FundingEventCreatedV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class FundingEventCreatedV1WebhookEventDataStatusDetails : JsonModel
{
    /// <summary>
    /// The time the status change occurred.
    /// </summary>
    public required DateTimeOffset ChangedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("changed_at");
        }
        init { this._rawData.Set("changed_at", value); }
    }

    /// <summary>
    /// The status code if applicable.
    /// </summary>
    public required string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// A human-readable description of the current status.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventCreatedV1WebhookEventDataStatusDetailsReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    public required ApiEnum<string, PaymentStatusSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentStatusSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChangedAt;
        _ = this.Code;
        _ = this.Message;
        this.Reason.Validate();
        this.Source.Validate();
    }

    public FundingEventCreatedV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventCreatedV1WebhookEventDataStatusDetails(
        FundingEventCreatedV1WebhookEventDataStatusDetails fundingEventCreatedV1WebhookEventDataStatusDetails
    )
        : base(fundingEventCreatedV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public FundingEventCreatedV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventCreatedV1WebhookEventDataStatusDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventCreatedV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static FundingEventCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventCreatedV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<FundingEventCreatedV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public FundingEventCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventCreatedV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FundingEventCreatedV1WebhookEventDataStatusDetailsReasonConverter))]
public enum FundingEventCreatedV1WebhookEventDataStatusDetailsReason
{
    InsufficientFunds,
    ClosedBankAccount,
    InvalidBankAccount,
    InvalidRouting,
    Disputed,
    PaymentStopped,
    OwnerDeceased,
    FrozenBankAccount,
    RiskReview,
    Fraudulent,
    DuplicateEntry,
    InvalidPaykey,
    PaymentBlocked,
    AmountTooLarge,
    TooManyAttempts,
    InternalSystemError,
    UserRequest,
    Ok,
    OtherNetworkReturn,
    PayoutRefused,
    Validating,
    AutoHold,
}

sealed class FundingEventCreatedV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<FundingEventCreatedV1WebhookEventDataStatusDetailsReason>
{
    public override FundingEventCreatedV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" =>
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => FundingEventCreatedV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (FundingEventCreatedV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventCreatedV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased =>
                    "owner_deceased",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.RiskReview =>
                    "risk_review",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey =>
                    "invalid_paykey",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.UserRequest =>
                    "user_request",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused =>
                    "payout_refused",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
