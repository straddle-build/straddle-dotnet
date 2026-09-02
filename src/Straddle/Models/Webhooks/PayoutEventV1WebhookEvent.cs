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
using Straddle.Models.Charges;
using Straddle.Models.Customers;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PayoutEventV1WebhookEvent, PayoutEventV1WebhookEventFromRaw>)
)]
public sealed record class PayoutEventV1WebhookEvent : JsonModel
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

    public required PayoutEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutEventV1WebhookEventData>("data");
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

    public PayoutEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEvent(PayoutEventV1WebhookEvent payoutEventV1WebhookEvent)
        : base(payoutEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventFromRaw : IFromRawJson<PayoutEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PayoutEventV1WebhookEventData, PayoutEventV1WebhookEventDataFromRaw>)
)]
public sealed record class PayoutEventV1WebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for this payout.
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
    /// Amount in cents.
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

    public required JsonElement Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotAbsentElement("config");
        }
        init { this._rawData.Set("config", value); }
    }

    public required ApiEnum<string, PayoutEventV1WebhookEventDataConsentType> ConsentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataConsentType>
            >("consent_type");
        }
        init { this._rawData.Set("consent_type", value); }
    }

    /// <summary>
    /// Currency code. Only `USD` is supported.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// A human-readable description of the payout.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required MaskedPaymentDevice Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MaskedPaymentDevice>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// IDs of the funding events that included this payout.
    /// </summary>
    public required IReadOnlyList<string> FundingIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("funding_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "funding_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether this payout has been resubmitted.
    /// </summary>
    public required bool HasResubmit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_resubmit");
        }
        init { this._rawData.Set("has_resubmit", value); }
    }

    /// <summary>
    /// Whether this payout refunds an original charge.
    /// </summary>
    public required bool IsRefund
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_refund");
        }
        init { this._rawData.Set("is_refund", value); }
    }

    /// <summary>
    /// Whether this payout resubmits an original payout.
    /// </summary>
    public required bool IsResubmit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_resubmit");
        }
        init { this._rawData.Set("is_resubmit", value); }
    }

    /// <summary>
    /// The masked paykey token used for this payout.
    /// </summary>
    public required string Paykey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("paykey");
        }
        init { this._rawData.Set("paykey", value); }
    }

    /// <summary>
    /// Date when Straddle submits the payout for processing.
    /// </summary>
    public required string PaymentDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_date");
        }
        init { this._rawData.Set("payment_date", value); }
    }

    public required ApiEnum<string, PayoutEventV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required PayoutEventV1WebhookEventDataStatusDetails StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutEventV1WebhookEventDataStatusDetails>(
                "status_details"
            );
        }
        init { this._rawData.Set("status_details", value); }
    }

    /// <summary>
    /// Complete ordered history of all status changes for this payout.
    /// </summary>
    public required IReadOnlyList<PayoutEventV1WebhookEventDataStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PayoutEventV1WebhookEventDataStatusHistory>
            >("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PayoutEventV1WebhookEventDataStatusHistory>>(
                "status_history",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when this payout was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public PayoutEventV1WebhookEventDataCustomerDetails? CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayoutEventV1WebhookEventDataCustomerDetails>(
                "customer_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customer_details", value);
        }
    }

    /// <summary>
    /// Authorization documents for this payout, ordered by upload time.
    /// </summary>
    public IReadOnlyList<PaymentAuthorizationProof>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PaymentAuthorizationProof>>(
                "documents"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PaymentAuthorizationProof>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when funds were settled. Null until settlement is confirmed.
    /// </summary>
    public DateTimeOffset? EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("effective_at");
        }
        init { this._rawData.Set("effective_at", value); }
    }

    /// <summary>
    /// Your unique identifier for this payout, used to correlate with your internal records.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// Key-value metadata stored with this payout.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public PayoutEventV1WebhookEventDataPaykeyDetails? PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayoutEventV1WebhookEventDataPaykeyDetails>(
                "paykey_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paykey_details", value);
        }
    }

    public ApiEnum<string, PayoutEventV1WebhookEventDataPaymentRail>? PaymentRail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataPaymentRail>
            >("payment_rail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("payment_rail", value);
        }
    }

    /// <summary>
    /// Timestamp when this payout was submitted to the payment network. Null until processed.
    /// </summary>
    public DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <summary>
    /// Related payments and their relationship to this payout.
    /// </summary>
    public IReadOnlyList<RelatedPayment>? RelatedPayments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RelatedPayment>>(
                "related_payments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<RelatedPayment>?>(
                "related_payments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when this payout was last updated.
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
        _ = this.ID;
        _ = this.Amount;
        _ = this.Config;
        this.ConsentType.Validate();
        _ = this.Currency;
        _ = this.Description;
        this.Device.Validate();
        _ = this.FundingIds;
        _ = this.HasResubmit;
        _ = this.IsRefund;
        _ = this.IsResubmit;
        _ = this.Paykey;
        _ = this.PaymentDate;
        this.Status.Validate();
        this.StatusDetails.Validate();
        foreach (var item in this.StatusHistory)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.CustomerDetails?.Validate();
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.EffectiveAt;
        _ = this.ExternalID;
        _ = this.Metadata;
        this.PaykeyDetails?.Validate();
        this.PaymentRail?.Validate();
        _ = this.ProcessedAt;
        foreach (var item in this.RelatedPayments ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public PayoutEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEventData(
        PayoutEventV1WebhookEventData payoutEventV1WebhookEventData
    )
        : base(payoutEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventDataFromRaw : IFromRawJson<PayoutEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataConsentTypeConverter))]
public enum PayoutEventV1WebhookEventDataConsentType
{
    Internet,
    Signed,
}

sealed class PayoutEventV1WebhookEventDataConsentTypeConverter
    : JsonConverter<PayoutEventV1WebhookEventDataConsentType>
{
    public override PayoutEventV1WebhookEventDataConsentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internet" => PayoutEventV1WebhookEventDataConsentType.Internet,
            "signed" => PayoutEventV1WebhookEventDataConsentType.Signed,
            _ => (PayoutEventV1WebhookEventDataConsentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataConsentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataConsentType.Internet => "internet",
                PayoutEventV1WebhookEventDataConsentType.Signed => "signed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataStatusConverter))]
public enum PayoutEventV1WebhookEventDataStatus
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

sealed class PayoutEventV1WebhookEventDataStatusConverter
    : JsonConverter<PayoutEventV1WebhookEventDataStatus>
{
    public override PayoutEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PayoutEventV1WebhookEventDataStatus.Created,
            "scheduled" => PayoutEventV1WebhookEventDataStatus.Scheduled,
            "failed" => PayoutEventV1WebhookEventDataStatus.Failed,
            "cancelled" => PayoutEventV1WebhookEventDataStatus.Cancelled,
            "on_hold" => PayoutEventV1WebhookEventDataStatus.OnHold,
            "pending" => PayoutEventV1WebhookEventDataStatus.Pending,
            "paid" => PayoutEventV1WebhookEventDataStatus.Paid,
            "reversed" => PayoutEventV1WebhookEventDataStatus.Reversed,
            _ => (PayoutEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataStatus.Created => "created",
                PayoutEventV1WebhookEventDataStatus.Scheduled => "scheduled",
                PayoutEventV1WebhookEventDataStatus.Failed => "failed",
                PayoutEventV1WebhookEventDataStatus.Cancelled => "cancelled",
                PayoutEventV1WebhookEventDataStatus.OnHold => "on_hold",
                PayoutEventV1WebhookEventDataStatus.Pending => "pending",
                PayoutEventV1WebhookEventDataStatus.Paid => "paid",
                PayoutEventV1WebhookEventDataStatus.Reversed => "reversed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutEventV1WebhookEventDataStatusDetails,
        PayoutEventV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class PayoutEventV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, PayoutEventV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataStatusDetailsReason>
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

    public PayoutEventV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEventDataStatusDetails(
        PayoutEventV1WebhookEventDataStatusDetails payoutEventV1WebhookEventDataStatusDetails
    )
        : base(payoutEventV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<PayoutEventV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataStatusDetailsReasonConverter))]
public enum PayoutEventV1WebhookEventDataStatusDetailsReason
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

sealed class PayoutEventV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<PayoutEventV1WebhookEventDataStatusDetailsReason>
{
    public override PayoutEventV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" => PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => PayoutEventV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" => PayoutEventV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" => PayoutEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => PayoutEventV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => PayoutEventV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" => PayoutEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" => PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" => PayoutEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" => PayoutEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" => PayoutEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => PayoutEventV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => PayoutEventV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                PayoutEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" => PayoutEventV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => PayoutEventV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => PayoutEventV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (PayoutEventV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                PayoutEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                PayoutEventV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                PayoutEventV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                PayoutEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased => "owner_deceased",
                PayoutEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                PayoutEventV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                PayoutEventV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                PayoutEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                PayoutEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey => "invalid_paykey",
                PayoutEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                PayoutEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                PayoutEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                PayoutEventV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                PayoutEventV1WebhookEventDataStatusDetailsReason.UserRequest => "user_request",
                PayoutEventV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                PayoutEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                PayoutEventV1WebhookEventDataStatusDetailsReason.PayoutRefused => "payout_refused",
                PayoutEventV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                PayoutEventV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutEventV1WebhookEventDataStatusHistory,
        PayoutEventV1WebhookEventDataStatusHistoryFromRaw
    >)
)]
public sealed record class PayoutEventV1WebhookEventDataStatusHistory : JsonModel
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

    public required ApiEnum<string, PayoutEventV1WebhookEventDataStatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataStatusHistoryReason>
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

    public required ApiEnum<string, PayoutEventV1WebhookEventDataStatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutEventV1WebhookEventDataStatusHistoryStatus>
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

    public PayoutEventV1WebhookEventDataStatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEventDataStatusHistory(
        PayoutEventV1WebhookEventDataStatusHistory payoutEventV1WebhookEventDataStatusHistory
    )
        : base(payoutEventV1WebhookEventDataStatusHistory) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEventDataStatusHistory(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEventDataStatusHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventDataStatusHistoryFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventDataStatusHistoryFromRaw
    : IFromRawJson<PayoutEventV1WebhookEventDataStatusHistory>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEventDataStatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataStatusHistoryReasonConverter))]
public enum PayoutEventV1WebhookEventDataStatusHistoryReason
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

sealed class PayoutEventV1WebhookEventDataStatusHistoryReasonConverter
    : JsonConverter<PayoutEventV1WebhookEventDataStatusHistoryReason>
{
    public override PayoutEventV1WebhookEventDataStatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds,
            "closed_bank_account" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount,
            "invalid_routing" => PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidRouting,
            "disputed" => PayoutEventV1WebhookEventDataStatusHistoryReason.Disputed,
            "payment_stopped" => PayoutEventV1WebhookEventDataStatusHistoryReason.PaymentStopped,
            "owner_deceased" => PayoutEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount,
            "risk_review" => PayoutEventV1WebhookEventDataStatusHistoryReason.RiskReview,
            "fraudulent" => PayoutEventV1WebhookEventDataStatusHistoryReason.Fraudulent,
            "duplicate_entry" => PayoutEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry,
            "invalid_paykey" => PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey,
            "payment_blocked" => PayoutEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked,
            "amount_too_large" => PayoutEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge,
            "too_many_attempts" => PayoutEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts,
            "internal_system_error" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.InternalSystemError,
            "user_request" => PayoutEventV1WebhookEventDataStatusHistoryReason.UserRequest,
            "ok" => PayoutEventV1WebhookEventDataStatusHistoryReason.Ok,
            "other_network_return" =>
                PayoutEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn,
            "payout_refused" => PayoutEventV1WebhookEventDataStatusHistoryReason.PayoutRefused,
            "validating" => PayoutEventV1WebhookEventDataStatusHistoryReason.Validating,
            "auto_hold" => PayoutEventV1WebhookEventDataStatusHistoryReason.AutoHold,
            _ => (PayoutEventV1WebhookEventDataStatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataStatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds =>
                    "insufficient_funds",
                PayoutEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount =>
                    "closed_bank_account",
                PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount =>
                    "invalid_bank_account",
                PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidRouting =>
                    "invalid_routing",
                PayoutEventV1WebhookEventDataStatusHistoryReason.Disputed => "disputed",
                PayoutEventV1WebhookEventDataStatusHistoryReason.PaymentStopped =>
                    "payment_stopped",
                PayoutEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased => "owner_deceased",
                PayoutEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount =>
                    "frozen_bank_account",
                PayoutEventV1WebhookEventDataStatusHistoryReason.RiskReview => "risk_review",
                PayoutEventV1WebhookEventDataStatusHistoryReason.Fraudulent => "fraudulent",
                PayoutEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry =>
                    "duplicate_entry",
                PayoutEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey => "invalid_paykey",
                PayoutEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked =>
                    "payment_blocked",
                PayoutEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge =>
                    "amount_too_large",
                PayoutEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts =>
                    "too_many_attempts",
                PayoutEventV1WebhookEventDataStatusHistoryReason.InternalSystemError =>
                    "internal_system_error",
                PayoutEventV1WebhookEventDataStatusHistoryReason.UserRequest => "user_request",
                PayoutEventV1WebhookEventDataStatusHistoryReason.Ok => "ok",
                PayoutEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn =>
                    "other_network_return",
                PayoutEventV1WebhookEventDataStatusHistoryReason.PayoutRefused => "payout_refused",
                PayoutEventV1WebhookEventDataStatusHistoryReason.Validating => "validating",
                PayoutEventV1WebhookEventDataStatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataStatusHistoryStatusConverter))]
public enum PayoutEventV1WebhookEventDataStatusHistoryStatus
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

sealed class PayoutEventV1WebhookEventDataStatusHistoryStatusConverter
    : JsonConverter<PayoutEventV1WebhookEventDataStatusHistoryStatus>
{
    public override PayoutEventV1WebhookEventDataStatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Created,
            "scheduled" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Scheduled,
            "failed" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Failed,
            "cancelled" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Cancelled,
            "on_hold" => PayoutEventV1WebhookEventDataStatusHistoryStatus.OnHold,
            "pending" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Pending,
            "paid" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Paid,
            "reversed" => PayoutEventV1WebhookEventDataStatusHistoryStatus.Reversed,
            _ => (PayoutEventV1WebhookEventDataStatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataStatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Created => "created",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Scheduled => "scheduled",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Failed => "failed",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Cancelled => "cancelled",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.OnHold => "on_hold",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Pending => "pending",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Paid => "paid",
                PayoutEventV1WebhookEventDataStatusHistoryStatus.Reversed => "reversed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutEventV1WebhookEventDataCustomerDetails,
        PayoutEventV1WebhookEventDataCustomerDetailsFromRaw
    >)
)]
public sealed record class PayoutEventV1WebhookEventDataCustomerDetails : JsonModel
{
    /// <summary>
    /// Unique identifier for the customer.
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
    /// Whether the customer is an individual or a business.
    /// </summary>
    public required ApiEnum<string, CustomerType> CustomerType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomerType>>("customer_type");
        }
        init { this._rawData.Set("customer_type", value); }
    }

    /// <summary>
    /// Customer's email address.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Customer's full name or business name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Customer's phone number in E.164 format.
    /// </summary>
    public required string Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.CustomerType.Validate();
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
    }

    public PayoutEventV1WebhookEventDataCustomerDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEventDataCustomerDetails(
        PayoutEventV1WebhookEventDataCustomerDetails payoutEventV1WebhookEventDataCustomerDetails
    )
        : base(payoutEventV1WebhookEventDataCustomerDetails) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEventDataCustomerDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEventDataCustomerDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventDataCustomerDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventDataCustomerDetailsFromRaw
    : IFromRawJson<PayoutEventV1WebhookEventDataCustomerDetails>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEventDataCustomerDetails.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutEventV1WebhookEventDataPaykeyDetails,
        PayoutEventV1WebhookEventDataPaykeyDetailsFromRaw
    >)
)]
public sealed record class PayoutEventV1WebhookEventDataPaykeyDetails : JsonModel
{
    /// <summary>
    /// Unique identifier for the paykey.
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
    /// Unique identifier for the customer associated with the paykey.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// Display label combining the bank name and masked account number.
    /// </summary>
    public required string Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Available balance in cents when a balance check was performed. Null otherwise.
    /// </summary>
    public int? Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CustomerID;
        _ = this.Label;
        _ = this.Balance;
    }

    public PayoutEventV1WebhookEventDataPaykeyDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutEventV1WebhookEventDataPaykeyDetails(
        PayoutEventV1WebhookEventDataPaykeyDetails payoutEventV1WebhookEventDataPaykeyDetails
    )
        : base(payoutEventV1WebhookEventDataPaykeyDetails) { }
#pragma warning restore CS8618

    public PayoutEventV1WebhookEventDataPaykeyDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutEventV1WebhookEventDataPaykeyDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutEventV1WebhookEventDataPaykeyDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutEventV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutEventV1WebhookEventDataPaykeyDetailsFromRaw
    : IFromRawJson<PayoutEventV1WebhookEventDataPaykeyDetails>
{
    /// <inheritdoc/>
    public PayoutEventV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutEventV1WebhookEventDataPaykeyDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutEventV1WebhookEventDataPaymentRailConverter))]
public enum PayoutEventV1WebhookEventDataPaymentRail
{
    Ach,
}

sealed class PayoutEventV1WebhookEventDataPaymentRailConverter
    : JsonConverter<PayoutEventV1WebhookEventDataPaymentRail>
{
    public override PayoutEventV1WebhookEventDataPaymentRail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach" => PayoutEventV1WebhookEventDataPaymentRail.Ach,
            _ => (PayoutEventV1WebhookEventDataPaymentRail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutEventV1WebhookEventDataPaymentRail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutEventV1WebhookEventDataPaymentRail.Ach => "ach",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
