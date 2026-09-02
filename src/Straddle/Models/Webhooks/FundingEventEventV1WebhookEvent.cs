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
        FundingEventEventV1WebhookEvent,
        FundingEventEventV1WebhookEventFromRaw
    >)
)]
public sealed record class FundingEventEventV1WebhookEvent : JsonModel
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

    public required FundingEventEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FundingEventEventV1WebhookEventData>("data");
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

    public FundingEventEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventEventV1WebhookEvent(
        FundingEventEventV1WebhookEvent fundingEventEventV1WebhookEvent
    )
        : base(fundingEventEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public FundingEventEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static FundingEventEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventEventV1WebhookEventFromRaw : IFromRawJson<FundingEventEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public FundingEventEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventEventV1WebhookEventData,
        FundingEventEventV1WebhookEventDataFromRaw
    >)
)]
public sealed record class FundingEventEventV1WebhookEventData : JsonModel
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
    public required IReadOnlyList<FundingEventEventV1WebhookEventDataStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FundingEventEventV1WebhookEventDataStatusHistory>
            >("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FundingEventEventV1WebhookEventDataStatusHistory>>(
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
    public ApiEnum<string, FundingEventEventV1WebhookEventDataStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FundingEventEventV1WebhookEventDataStatus>
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
    public FundingEventEventV1WebhookEventDataStatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FundingEventEventV1WebhookEventDataStatusDetails>(
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

    public FundingEventEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventEventV1WebhookEventData(
        FundingEventEventV1WebhookEventData fundingEventEventV1WebhookEventData
    )
        : base(fundingEventEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public FundingEventEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static FundingEventEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventEventV1WebhookEventDataFromRaw : IFromRawJson<FundingEventEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public FundingEventEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventEventV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FundingEventEventV1WebhookEventDataStatusHistory,
        FundingEventEventV1WebhookEventDataStatusHistoryFromRaw
    >)
)]
public sealed record class FundingEventEventV1WebhookEventDataStatusHistory : JsonModel
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

    public required ApiEnum<string, FundingEventEventV1WebhookEventDataStatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventEventV1WebhookEventDataStatusHistoryReason>
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

    public required ApiEnum<string, FundingEventEventV1WebhookEventDataStatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventEventV1WebhookEventDataStatusHistoryStatus>
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

    public FundingEventEventV1WebhookEventDataStatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventEventV1WebhookEventDataStatusHistory(
        FundingEventEventV1WebhookEventDataStatusHistory fundingEventEventV1WebhookEventDataStatusHistory
    )
        : base(fundingEventEventV1WebhookEventDataStatusHistory) { }
#pragma warning restore CS8618

    public FundingEventEventV1WebhookEventDataStatusHistory(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventEventV1WebhookEventDataStatusHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventEventV1WebhookEventDataStatusHistoryFromRaw.FromRawUnchecked"/>
    public static FundingEventEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventEventV1WebhookEventDataStatusHistoryFromRaw
    : IFromRawJson<FundingEventEventV1WebhookEventDataStatusHistory>
{
    /// <inheritdoc/>
    public FundingEventEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventEventV1WebhookEventDataStatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FundingEventEventV1WebhookEventDataStatusHistoryReasonConverter))]
public enum FundingEventEventV1WebhookEventDataStatusHistoryReason
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

sealed class FundingEventEventV1WebhookEventDataStatusHistoryReasonConverter
    : JsonConverter<FundingEventEventV1WebhookEventDataStatusHistoryReason>
{
    public override FundingEventEventV1WebhookEventDataStatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds,
            "closed_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount,
            "invalid_routing" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidRouting,
            "disputed" => FundingEventEventV1WebhookEventDataStatusHistoryReason.Disputed,
            "payment_stopped" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PaymentStopped,
            "owner_deceased" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount,
            "risk_review" => FundingEventEventV1WebhookEventDataStatusHistoryReason.RiskReview,
            "fraudulent" => FundingEventEventV1WebhookEventDataStatusHistoryReason.Fraudulent,
            "duplicate_entry" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry,
            "invalid_paykey" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey,
            "payment_blocked" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked,
            "amount_too_large" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge,
            "too_many_attempts" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts,
            "internal_system_error" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InternalSystemError,
            "user_request" => FundingEventEventV1WebhookEventDataStatusHistoryReason.UserRequest,
            "ok" => FundingEventEventV1WebhookEventDataStatusHistoryReason.Ok,
            "other_network_return" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn,
            "payout_refused" =>
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PayoutRefused,
            "validating" => FundingEventEventV1WebhookEventDataStatusHistoryReason.Validating,
            "auto_hold" => FundingEventEventV1WebhookEventDataStatusHistoryReason.AutoHold,
            _ => (FundingEventEventV1WebhookEventDataStatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventEventV1WebhookEventDataStatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds =>
                    "insufficient_funds",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount =>
                    "closed_bank_account",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount =>
                    "invalid_bank_account",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidRouting =>
                    "invalid_routing",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.Disputed => "disputed",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PaymentStopped =>
                    "payment_stopped",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased =>
                    "owner_deceased",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount =>
                    "frozen_bank_account",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.RiskReview => "risk_review",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.Fraudulent => "fraudulent",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry =>
                    "duplicate_entry",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey =>
                    "invalid_paykey",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked =>
                    "payment_blocked",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge =>
                    "amount_too_large",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts =>
                    "too_many_attempts",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.InternalSystemError =>
                    "internal_system_error",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.UserRequest =>
                    "user_request",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.Ok => "ok",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn =>
                    "other_network_return",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.PayoutRefused =>
                    "payout_refused",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.Validating => "validating",
                FundingEventEventV1WebhookEventDataStatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FundingEventEventV1WebhookEventDataStatusHistoryStatusConverter))]
public enum FundingEventEventV1WebhookEventDataStatusHistoryStatus
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

sealed class FundingEventEventV1WebhookEventDataStatusHistoryStatusConverter
    : JsonConverter<FundingEventEventV1WebhookEventDataStatusHistoryStatus>
{
    public override FundingEventEventV1WebhookEventDataStatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Created,
            "scheduled" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Scheduled,
            "failed" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Failed,
            "cancelled" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Cancelled,
            "on_hold" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.OnHold,
            "pending" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Pending,
            "paid" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Paid,
            "reversed" => FundingEventEventV1WebhookEventDataStatusHistoryStatus.Reversed,
            _ => (FundingEventEventV1WebhookEventDataStatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventEventV1WebhookEventDataStatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Created => "created",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Scheduled => "scheduled",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Failed => "failed",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Cancelled => "cancelled",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.OnHold => "on_hold",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Pending => "pending",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Paid => "paid",
                FundingEventEventV1WebhookEventDataStatusHistoryStatus.Reversed => "reversed",
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
[JsonConverter(typeof(FundingEventEventV1WebhookEventDataStatusConverter))]
public enum FundingEventEventV1WebhookEventDataStatus
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

sealed class FundingEventEventV1WebhookEventDataStatusConverter
    : JsonConverter<FundingEventEventV1WebhookEventDataStatus>
{
    public override FundingEventEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => FundingEventEventV1WebhookEventDataStatus.Created,
            "scheduled" => FundingEventEventV1WebhookEventDataStatus.Scheduled,
            "failed" => FundingEventEventV1WebhookEventDataStatus.Failed,
            "cancelled" => FundingEventEventV1WebhookEventDataStatus.Cancelled,
            "on_hold" => FundingEventEventV1WebhookEventDataStatus.OnHold,
            "pending" => FundingEventEventV1WebhookEventDataStatus.Pending,
            "paid" => FundingEventEventV1WebhookEventDataStatus.Paid,
            "reversed" => FundingEventEventV1WebhookEventDataStatus.Reversed,
            _ => (FundingEventEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventEventV1WebhookEventDataStatus.Created => "created",
                FundingEventEventV1WebhookEventDataStatus.Scheduled => "scheduled",
                FundingEventEventV1WebhookEventDataStatus.Failed => "failed",
                FundingEventEventV1WebhookEventDataStatus.Cancelled => "cancelled",
                FundingEventEventV1WebhookEventDataStatus.OnHold => "on_hold",
                FundingEventEventV1WebhookEventDataStatus.Pending => "pending",
                FundingEventEventV1WebhookEventDataStatus.Paid => "paid",
                FundingEventEventV1WebhookEventDataStatus.Reversed => "reversed",
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
        FundingEventEventV1WebhookEventDataStatusDetails,
        FundingEventEventV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class FundingEventEventV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, FundingEventEventV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FundingEventEventV1WebhookEventDataStatusDetailsReason>
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

    public FundingEventEventV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventEventV1WebhookEventDataStatusDetails(
        FundingEventEventV1WebhookEventDataStatusDetails fundingEventEventV1WebhookEventDataStatusDetails
    )
        : base(fundingEventEventV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public FundingEventEventV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventEventV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventEventV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static FundingEventEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventEventV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<FundingEventEventV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public FundingEventEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventEventV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FundingEventEventV1WebhookEventDataStatusDetailsReasonConverter))]
public enum FundingEventEventV1WebhookEventDataStatusDetailsReason
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

sealed class FundingEventEventV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<FundingEventEventV1WebhookEventDataStatusDetailsReason>
{
    public override FundingEventEventV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => FundingEventEventV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => FundingEventEventV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => FundingEventEventV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => FundingEventEventV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => FundingEventEventV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" =>
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => FundingEventEventV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => FundingEventEventV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (FundingEventEventV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventEventV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased =>
                    "owner_deceased",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey =>
                    "invalid_paykey",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.UserRequest =>
                    "user_request",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.PayoutRefused =>
                    "payout_refused",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                FundingEventEventV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
