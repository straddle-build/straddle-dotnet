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
    typeof(JsonModelConverter<PayoutCreatedV1WebhookEvent, PayoutCreatedV1WebhookEventFromRaw>)
)]
public sealed record class PayoutCreatedV1WebhookEvent : JsonModel
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

    public required PayoutCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutCreatedV1WebhookEventData>("data");
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

    public PayoutCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEvent(PayoutCreatedV1WebhookEvent payoutCreatedV1WebhookEvent)
        : base(payoutCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventFromRaw : IFromRawJson<PayoutCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutCreatedV1WebhookEventData,
        PayoutCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class PayoutCreatedV1WebhookEventData : JsonModel
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

    public required ApiEnum<string, PayoutCreatedV1WebhookEventDataConsentType> ConsentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataConsentType>
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

    public required ApiEnum<string, PayoutCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required PayoutCreatedV1WebhookEventDataStatusDetails StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutCreatedV1WebhookEventDataStatusDetails>(
                "status_details"
            );
        }
        init { this._rawData.Set("status_details", value); }
    }

    /// <summary>
    /// Complete ordered history of all status changes for this payout.
    /// </summary>
    public required IReadOnlyList<PayoutCreatedV1WebhookEventDataStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PayoutCreatedV1WebhookEventDataStatusHistory>
            >("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PayoutCreatedV1WebhookEventDataStatusHistory>>(
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

    public PayoutCreatedV1WebhookEventDataCustomerDetails? CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayoutCreatedV1WebhookEventDataCustomerDetails>(
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

    public PayoutCreatedV1WebhookEventDataPaykeyDetails? PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayoutCreatedV1WebhookEventDataPaykeyDetails>(
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

    public ApiEnum<string, PayoutCreatedV1WebhookEventDataPaymentRail>? PaymentRail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataPaymentRail>
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

    public PayoutCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEventData(
        PayoutCreatedV1WebhookEventData payoutCreatedV1WebhookEventData
    )
        : base(payoutCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventDataFromRaw : IFromRawJson<PayoutCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataConsentTypeConverter))]
public enum PayoutCreatedV1WebhookEventDataConsentType
{
    Internet,
    Signed,
}

sealed class PayoutCreatedV1WebhookEventDataConsentTypeConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataConsentType>
{
    public override PayoutCreatedV1WebhookEventDataConsentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internet" => PayoutCreatedV1WebhookEventDataConsentType.Internet,
            "signed" => PayoutCreatedV1WebhookEventDataConsentType.Signed,
            _ => (PayoutCreatedV1WebhookEventDataConsentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataConsentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataConsentType.Internet => "internet",
                PayoutCreatedV1WebhookEventDataConsentType.Signed => "signed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataStatusConverter))]
public enum PayoutCreatedV1WebhookEventDataStatus
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

sealed class PayoutCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataStatus>
{
    public override PayoutCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PayoutCreatedV1WebhookEventDataStatus.Created,
            "scheduled" => PayoutCreatedV1WebhookEventDataStatus.Scheduled,
            "failed" => PayoutCreatedV1WebhookEventDataStatus.Failed,
            "cancelled" => PayoutCreatedV1WebhookEventDataStatus.Cancelled,
            "on_hold" => PayoutCreatedV1WebhookEventDataStatus.OnHold,
            "pending" => PayoutCreatedV1WebhookEventDataStatus.Pending,
            "paid" => PayoutCreatedV1WebhookEventDataStatus.Paid,
            "reversed" => PayoutCreatedV1WebhookEventDataStatus.Reversed,
            _ => (PayoutCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataStatus.Created => "created",
                PayoutCreatedV1WebhookEventDataStatus.Scheduled => "scheduled",
                PayoutCreatedV1WebhookEventDataStatus.Failed => "failed",
                PayoutCreatedV1WebhookEventDataStatus.Cancelled => "cancelled",
                PayoutCreatedV1WebhookEventDataStatus.OnHold => "on_hold",
                PayoutCreatedV1WebhookEventDataStatus.Pending => "pending",
                PayoutCreatedV1WebhookEventDataStatus.Paid => "paid",
                PayoutCreatedV1WebhookEventDataStatus.Reversed => "reversed",
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
        PayoutCreatedV1WebhookEventDataStatusDetails,
        PayoutCreatedV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class PayoutCreatedV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusDetailsReason>
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

    public PayoutCreatedV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEventDataStatusDetails(
        PayoutCreatedV1WebhookEventDataStatusDetails payoutCreatedV1WebhookEventDataStatusDetails
    )
        : base(payoutCreatedV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<PayoutCreatedV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataStatusDetailsReasonConverter))]
public enum PayoutCreatedV1WebhookEventDataStatusDetailsReason
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

sealed class PayoutCreatedV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataStatusDetailsReason>
{
    public override PayoutCreatedV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => PayoutCreatedV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (PayoutCreatedV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased =>
                    "owner_deceased",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey =>
                    "invalid_paykey",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.UserRequest => "user_request",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused =>
                    "payout_refused",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                PayoutCreatedV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
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
        PayoutCreatedV1WebhookEventDataStatusHistory,
        PayoutCreatedV1WebhookEventDataStatusHistoryFromRaw
    >)
)]
public sealed record class PayoutCreatedV1WebhookEventDataStatusHistory : JsonModel
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

    public required ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusHistoryReason>
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

    public required ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PayoutCreatedV1WebhookEventDataStatusHistoryStatus>
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

    public PayoutCreatedV1WebhookEventDataStatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEventDataStatusHistory(
        PayoutCreatedV1WebhookEventDataStatusHistory payoutCreatedV1WebhookEventDataStatusHistory
    )
        : base(payoutCreatedV1WebhookEventDataStatusHistory) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEventDataStatusHistory(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEventDataStatusHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventDataStatusHistoryFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventDataStatusHistoryFromRaw
    : IFromRawJson<PayoutCreatedV1WebhookEventDataStatusHistory>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEventDataStatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataStatusHistoryReasonConverter))]
public enum PayoutCreatedV1WebhookEventDataStatusHistoryReason
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

sealed class PayoutCreatedV1WebhookEventDataStatusHistoryReasonConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataStatusHistoryReason>
{
    public override PayoutCreatedV1WebhookEventDataStatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InsufficientFunds,
            "closed_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidBankAccount,
            "invalid_routing" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidRouting,
            "disputed" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.Disputed,
            "payment_stopped" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.PaymentStopped,
            "owner_deceased" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.FrozenBankAccount,
            "risk_review" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.RiskReview,
            "fraudulent" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.Fraudulent,
            "duplicate_entry" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.DuplicateEntry,
            "invalid_paykey" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidPaykey,
            "payment_blocked" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.PaymentBlocked,
            "amount_too_large" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.AmountTooLarge,
            "too_many_attempts" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.TooManyAttempts,
            "internal_system_error" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InternalSystemError,
            "user_request" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.UserRequest,
            "ok" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.Ok,
            "other_network_return" =>
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn,
            "payout_refused" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.PayoutRefused,
            "validating" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.Validating,
            "auto_hold" => PayoutCreatedV1WebhookEventDataStatusHistoryReason.AutoHold,
            _ => (PayoutCreatedV1WebhookEventDataStatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataStatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InsufficientFunds =>
                    "insufficient_funds",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.ClosedBankAccount =>
                    "closed_bank_account",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidBankAccount =>
                    "invalid_bank_account",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidRouting =>
                    "invalid_routing",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.Disputed => "disputed",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.PaymentStopped =>
                    "payment_stopped",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.OwnerDeceased =>
                    "owner_deceased",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.FrozenBankAccount =>
                    "frozen_bank_account",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.RiskReview => "risk_review",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.Fraudulent => "fraudulent",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.DuplicateEntry =>
                    "duplicate_entry",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InvalidPaykey =>
                    "invalid_paykey",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.PaymentBlocked =>
                    "payment_blocked",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.AmountTooLarge =>
                    "amount_too_large",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.TooManyAttempts =>
                    "too_many_attempts",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.InternalSystemError =>
                    "internal_system_error",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.UserRequest => "user_request",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.Ok => "ok",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn =>
                    "other_network_return",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.PayoutRefused =>
                    "payout_refused",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.Validating => "validating",
                PayoutCreatedV1WebhookEventDataStatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataStatusHistoryStatusConverter))]
public enum PayoutCreatedV1WebhookEventDataStatusHistoryStatus
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

sealed class PayoutCreatedV1WebhookEventDataStatusHistoryStatusConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataStatusHistoryStatus>
{
    public override PayoutCreatedV1WebhookEventDataStatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Created,
            "scheduled" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Scheduled,
            "failed" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Failed,
            "cancelled" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Cancelled,
            "on_hold" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.OnHold,
            "pending" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Pending,
            "paid" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Paid,
            "reversed" => PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Reversed,
            _ => (PayoutCreatedV1WebhookEventDataStatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataStatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Created => "created",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Scheduled => "scheduled",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Failed => "failed",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Cancelled => "cancelled",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.OnHold => "on_hold",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Pending => "pending",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Paid => "paid",
                PayoutCreatedV1WebhookEventDataStatusHistoryStatus.Reversed => "reversed",
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
        PayoutCreatedV1WebhookEventDataCustomerDetails,
        PayoutCreatedV1WebhookEventDataCustomerDetailsFromRaw
    >)
)]
public sealed record class PayoutCreatedV1WebhookEventDataCustomerDetails : JsonModel
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

    public PayoutCreatedV1WebhookEventDataCustomerDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEventDataCustomerDetails(
        PayoutCreatedV1WebhookEventDataCustomerDetails payoutCreatedV1WebhookEventDataCustomerDetails
    )
        : base(payoutCreatedV1WebhookEventDataCustomerDetails) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEventDataCustomerDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEventDataCustomerDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventDataCustomerDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventDataCustomerDetailsFromRaw
    : IFromRawJson<PayoutCreatedV1WebhookEventDataCustomerDetails>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEventDataCustomerDetails.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PayoutCreatedV1WebhookEventDataPaykeyDetails,
        PayoutCreatedV1WebhookEventDataPaykeyDetailsFromRaw
    >)
)]
public sealed record class PayoutCreatedV1WebhookEventDataPaykeyDetails : JsonModel
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

    public PayoutCreatedV1WebhookEventDataPaykeyDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutCreatedV1WebhookEventDataPaykeyDetails(
        PayoutCreatedV1WebhookEventDataPaykeyDetails payoutCreatedV1WebhookEventDataPaykeyDetails
    )
        : base(payoutCreatedV1WebhookEventDataPaykeyDetails) { }
#pragma warning restore CS8618

    public PayoutCreatedV1WebhookEventDataPaykeyDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutCreatedV1WebhookEventDataPaykeyDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutCreatedV1WebhookEventDataPaykeyDetailsFromRaw.FromRawUnchecked"/>
    public static PayoutCreatedV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutCreatedV1WebhookEventDataPaykeyDetailsFromRaw
    : IFromRawJson<PayoutCreatedV1WebhookEventDataPaykeyDetails>
{
    /// <inheritdoc/>
    public PayoutCreatedV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PayoutCreatedV1WebhookEventDataPaykeyDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PayoutCreatedV1WebhookEventDataPaymentRailConverter))]
public enum PayoutCreatedV1WebhookEventDataPaymentRail
{
    Ach,
}

sealed class PayoutCreatedV1WebhookEventDataPaymentRailConverter
    : JsonConverter<PayoutCreatedV1WebhookEventDataPaymentRail>
{
    public override PayoutCreatedV1WebhookEventDataPaymentRail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach" => PayoutCreatedV1WebhookEventDataPaymentRail.Ach,
            _ => (PayoutCreatedV1WebhookEventDataPaymentRail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayoutCreatedV1WebhookEventDataPaymentRail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayoutCreatedV1WebhookEventDataPaymentRail.Ach => "ach",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
