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
    typeof(JsonModelConverter<ChargeEventV1WebhookEvent, ChargeEventV1WebhookEventFromRaw>)
)]
public sealed record class ChargeEventV1WebhookEvent : JsonModel
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

    public required ChargeEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeEventV1WebhookEventData>("data");
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

    public ChargeEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEvent(ChargeEventV1WebhookEvent chargeEventV1WebhookEvent)
        : base(chargeEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventFromRaw : IFromRawJson<ChargeEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ChargeEventV1WebhookEventData, ChargeEventV1WebhookEventDataFromRaw>)
)]
public sealed record class ChargeEventV1WebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for this charge.
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

    public required ChargeEventV1WebhookEventDataConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeEventV1WebhookEventDataConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    public required ApiEnum<string, ChargeEventV1WebhookEventDataConsentType> ConsentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataConsentType>
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
    /// A human-readable description of the charge.
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
    /// IDs of the funding events that included this charge.
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
    /// Whether an associated payout has refunded this charge.
    /// </summary>
    public required bool HasRefund
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_refund");
        }
        init { this._rawData.Set("has_refund", value); }
    }

    /// <summary>
    /// Whether this charge has been resubmitted.
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
    /// Whether this charge resubmits an original charge.
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
    /// The masked paykey token used for this charge.
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
    /// Date when Straddle submits the charge for processing.
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

    public required ApiEnum<string, ChargeEventV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ChargeEventV1WebhookEventDataStatusDetails StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeEventV1WebhookEventDataStatusDetails>(
                "status_details"
            );
        }
        init { this._rawData.Set("status_details", value); }
    }

    /// <summary>
    /// Complete ordered history of all status changes for this charge.
    /// </summary>
    public required IReadOnlyList<ChargeEventV1WebhookEventDataStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ChargeEventV1WebhookEventDataStatusHistory>
            >("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChargeEventV1WebhookEventDataStatusHistory>>(
                "status_history",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when this charge was created.
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

    public ChargeEventV1WebhookEventDataCustomerDetails? CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeEventV1WebhookEventDataCustomerDetails>(
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
    /// Authorization documents for this charge, ordered by upload time.
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
    /// Your unique identifier for this charge, used to correlate with your internal records.
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
    /// Key-value metadata stored with this charge.
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

    public ChargeEventV1WebhookEventDataPaykeyDetails? PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeEventV1WebhookEventDataPaykeyDetails>(
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

    public ApiEnum<string, ChargeEventV1WebhookEventDataPaymentRail>? PaymentRail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataPaymentRail>
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
    /// Timestamp when this charge was submitted to the payment network. Null until processed.
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
    /// Related payments and their relationship to this charge.
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
    /// Timestamp when this charge was last updated.
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
        this.Config.Validate();
        this.ConsentType.Validate();
        _ = this.Currency;
        _ = this.Description;
        this.Device.Validate();
        _ = this.FundingIds;
        _ = this.HasRefund;
        _ = this.HasResubmit;
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

    public ChargeEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventData(
        ChargeEventV1WebhookEventData chargeEventV1WebhookEventData
    )
        : base(chargeEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventDataFromRaw : IFromRawJson<ChargeEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ChargeEventV1WebhookEventDataConfig,
        ChargeEventV1WebhookEventDataConfigFromRaw
    >)
)]
public sealed record class ChargeEventV1WebhookEventDataConfig : JsonModel
{
    public required ApiEnum<string, BalanceCheckMode> BalanceCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BalanceCheckMode>>(
                "balance_check"
            );
        }
        init { this._rawData.Set("balance_check", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BalanceCheck.Validate();
    }

    public ChargeEventV1WebhookEventDataConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataConfig(
        ChargeEventV1WebhookEventDataConfig chargeEventV1WebhookEventDataConfig
    )
        : base(chargeEventV1WebhookEventDataConfig) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventDataConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventDataConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataConfigFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventDataConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataConfig(ApiEnum<string, BalanceCheckMode> balanceCheck)
        : this()
    {
        this.BalanceCheck = balanceCheck;
    }
}

class ChargeEventV1WebhookEventDataConfigFromRaw : IFromRawJson<ChargeEventV1WebhookEventDataConfig>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventDataConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventDataConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataConsentTypeConverter))]
public enum ChargeEventV1WebhookEventDataConsentType
{
    Internet,
    Signed,
}

sealed class ChargeEventV1WebhookEventDataConsentTypeConverter
    : JsonConverter<ChargeEventV1WebhookEventDataConsentType>
{
    public override ChargeEventV1WebhookEventDataConsentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internet" => ChargeEventV1WebhookEventDataConsentType.Internet,
            "signed" => ChargeEventV1WebhookEventDataConsentType.Signed,
            _ => (ChargeEventV1WebhookEventDataConsentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataConsentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataConsentType.Internet => "internet",
                ChargeEventV1WebhookEventDataConsentType.Signed => "signed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataStatusConverter))]
public enum ChargeEventV1WebhookEventDataStatus
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

sealed class ChargeEventV1WebhookEventDataStatusConverter
    : JsonConverter<ChargeEventV1WebhookEventDataStatus>
{
    public override ChargeEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => ChargeEventV1WebhookEventDataStatus.Created,
            "scheduled" => ChargeEventV1WebhookEventDataStatus.Scheduled,
            "failed" => ChargeEventV1WebhookEventDataStatus.Failed,
            "cancelled" => ChargeEventV1WebhookEventDataStatus.Cancelled,
            "on_hold" => ChargeEventV1WebhookEventDataStatus.OnHold,
            "pending" => ChargeEventV1WebhookEventDataStatus.Pending,
            "paid" => ChargeEventV1WebhookEventDataStatus.Paid,
            "reversed" => ChargeEventV1WebhookEventDataStatus.Reversed,
            _ => (ChargeEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataStatus.Created => "created",
                ChargeEventV1WebhookEventDataStatus.Scheduled => "scheduled",
                ChargeEventV1WebhookEventDataStatus.Failed => "failed",
                ChargeEventV1WebhookEventDataStatus.Cancelled => "cancelled",
                ChargeEventV1WebhookEventDataStatus.OnHold => "on_hold",
                ChargeEventV1WebhookEventDataStatus.Pending => "pending",
                ChargeEventV1WebhookEventDataStatus.Paid => "paid",
                ChargeEventV1WebhookEventDataStatus.Reversed => "reversed",
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
        ChargeEventV1WebhookEventDataStatusDetails,
        ChargeEventV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class ChargeEventV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, ChargeEventV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataStatusDetailsReason>
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

    public ChargeEventV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataStatusDetails(
        ChargeEventV1WebhookEventDataStatusDetails chargeEventV1WebhookEventDataStatusDetails
    )
        : base(chargeEventV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<ChargeEventV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataStatusDetailsReasonConverter))]
public enum ChargeEventV1WebhookEventDataStatusDetailsReason
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

sealed class ChargeEventV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<ChargeEventV1WebhookEventDataStatusDetailsReason>
{
    public override ChargeEventV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" => ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => ChargeEventV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" => ChargeEventV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" => ChargeEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => ChargeEventV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => ChargeEventV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" => ChargeEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" => ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" => ChargeEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" => ChargeEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" => ChargeEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => ChargeEventV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => ChargeEventV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                ChargeEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" => ChargeEventV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => ChargeEventV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => ChargeEventV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (ChargeEventV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                ChargeEventV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                ChargeEventV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                ChargeEventV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                ChargeEventV1WebhookEventDataStatusDetailsReason.OwnerDeceased => "owner_deceased",
                ChargeEventV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                ChargeEventV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                ChargeEventV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                ChargeEventV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                ChargeEventV1WebhookEventDataStatusDetailsReason.InvalidPaykey => "invalid_paykey",
                ChargeEventV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                ChargeEventV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                ChargeEventV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                ChargeEventV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                ChargeEventV1WebhookEventDataStatusDetailsReason.UserRequest => "user_request",
                ChargeEventV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                ChargeEventV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                ChargeEventV1WebhookEventDataStatusDetailsReason.PayoutRefused => "payout_refused",
                ChargeEventV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                ChargeEventV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
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
        ChargeEventV1WebhookEventDataStatusHistory,
        ChargeEventV1WebhookEventDataStatusHistoryFromRaw
    >)
)]
public sealed record class ChargeEventV1WebhookEventDataStatusHistory : JsonModel
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

    public required ApiEnum<string, ChargeEventV1WebhookEventDataStatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataStatusHistoryReason>
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

    public required ApiEnum<string, ChargeEventV1WebhookEventDataStatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeEventV1WebhookEventDataStatusHistoryStatus>
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

    public ChargeEventV1WebhookEventDataStatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataStatusHistory(
        ChargeEventV1WebhookEventDataStatusHistory chargeEventV1WebhookEventDataStatusHistory
    )
        : base(chargeEventV1WebhookEventDataStatusHistory) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventDataStatusHistory(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventDataStatusHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataStatusHistoryFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventDataStatusHistoryFromRaw
    : IFromRawJson<ChargeEventV1WebhookEventDataStatusHistory>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventDataStatusHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventDataStatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataStatusHistoryReasonConverter))]
public enum ChargeEventV1WebhookEventDataStatusHistoryReason
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

sealed class ChargeEventV1WebhookEventDataStatusHistoryReasonConverter
    : JsonConverter<ChargeEventV1WebhookEventDataStatusHistoryReason>
{
    public override ChargeEventV1WebhookEventDataStatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds,
            "closed_bank_account" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount,
            "invalid_routing" => ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidRouting,
            "disputed" => ChargeEventV1WebhookEventDataStatusHistoryReason.Disputed,
            "payment_stopped" => ChargeEventV1WebhookEventDataStatusHistoryReason.PaymentStopped,
            "owner_deceased" => ChargeEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount,
            "risk_review" => ChargeEventV1WebhookEventDataStatusHistoryReason.RiskReview,
            "fraudulent" => ChargeEventV1WebhookEventDataStatusHistoryReason.Fraudulent,
            "duplicate_entry" => ChargeEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry,
            "invalid_paykey" => ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey,
            "payment_blocked" => ChargeEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked,
            "amount_too_large" => ChargeEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge,
            "too_many_attempts" => ChargeEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts,
            "internal_system_error" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.InternalSystemError,
            "user_request" => ChargeEventV1WebhookEventDataStatusHistoryReason.UserRequest,
            "ok" => ChargeEventV1WebhookEventDataStatusHistoryReason.Ok,
            "other_network_return" =>
                ChargeEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn,
            "payout_refused" => ChargeEventV1WebhookEventDataStatusHistoryReason.PayoutRefused,
            "validating" => ChargeEventV1WebhookEventDataStatusHistoryReason.Validating,
            "auto_hold" => ChargeEventV1WebhookEventDataStatusHistoryReason.AutoHold,
            _ => (ChargeEventV1WebhookEventDataStatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataStatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataStatusHistoryReason.InsufficientFunds =>
                    "insufficient_funds",
                ChargeEventV1WebhookEventDataStatusHistoryReason.ClosedBankAccount =>
                    "closed_bank_account",
                ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidBankAccount =>
                    "invalid_bank_account",
                ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidRouting =>
                    "invalid_routing",
                ChargeEventV1WebhookEventDataStatusHistoryReason.Disputed => "disputed",
                ChargeEventV1WebhookEventDataStatusHistoryReason.PaymentStopped =>
                    "payment_stopped",
                ChargeEventV1WebhookEventDataStatusHistoryReason.OwnerDeceased => "owner_deceased",
                ChargeEventV1WebhookEventDataStatusHistoryReason.FrozenBankAccount =>
                    "frozen_bank_account",
                ChargeEventV1WebhookEventDataStatusHistoryReason.RiskReview => "risk_review",
                ChargeEventV1WebhookEventDataStatusHistoryReason.Fraudulent => "fraudulent",
                ChargeEventV1WebhookEventDataStatusHistoryReason.DuplicateEntry =>
                    "duplicate_entry",
                ChargeEventV1WebhookEventDataStatusHistoryReason.InvalidPaykey => "invalid_paykey",
                ChargeEventV1WebhookEventDataStatusHistoryReason.PaymentBlocked =>
                    "payment_blocked",
                ChargeEventV1WebhookEventDataStatusHistoryReason.AmountTooLarge =>
                    "amount_too_large",
                ChargeEventV1WebhookEventDataStatusHistoryReason.TooManyAttempts =>
                    "too_many_attempts",
                ChargeEventV1WebhookEventDataStatusHistoryReason.InternalSystemError =>
                    "internal_system_error",
                ChargeEventV1WebhookEventDataStatusHistoryReason.UserRequest => "user_request",
                ChargeEventV1WebhookEventDataStatusHistoryReason.Ok => "ok",
                ChargeEventV1WebhookEventDataStatusHistoryReason.OtherNetworkReturn =>
                    "other_network_return",
                ChargeEventV1WebhookEventDataStatusHistoryReason.PayoutRefused => "payout_refused",
                ChargeEventV1WebhookEventDataStatusHistoryReason.Validating => "validating",
                ChargeEventV1WebhookEventDataStatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataStatusHistoryStatusConverter))]
public enum ChargeEventV1WebhookEventDataStatusHistoryStatus
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

sealed class ChargeEventV1WebhookEventDataStatusHistoryStatusConverter
    : JsonConverter<ChargeEventV1WebhookEventDataStatusHistoryStatus>
{
    public override ChargeEventV1WebhookEventDataStatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Created,
            "scheduled" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Scheduled,
            "failed" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Failed,
            "cancelled" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Cancelled,
            "on_hold" => ChargeEventV1WebhookEventDataStatusHistoryStatus.OnHold,
            "pending" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Pending,
            "paid" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Paid,
            "reversed" => ChargeEventV1WebhookEventDataStatusHistoryStatus.Reversed,
            _ => (ChargeEventV1WebhookEventDataStatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataStatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Created => "created",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Scheduled => "scheduled",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Failed => "failed",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Cancelled => "cancelled",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.OnHold => "on_hold",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Pending => "pending",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Paid => "paid",
                ChargeEventV1WebhookEventDataStatusHistoryStatus.Reversed => "reversed",
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
        ChargeEventV1WebhookEventDataCustomerDetails,
        ChargeEventV1WebhookEventDataCustomerDetailsFromRaw
    >)
)]
public sealed record class ChargeEventV1WebhookEventDataCustomerDetails : JsonModel
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

    public ChargeEventV1WebhookEventDataCustomerDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataCustomerDetails(
        ChargeEventV1WebhookEventDataCustomerDetails chargeEventV1WebhookEventDataCustomerDetails
    )
        : base(chargeEventV1WebhookEventDataCustomerDetails) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventDataCustomerDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventDataCustomerDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataCustomerDetailsFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventDataCustomerDetailsFromRaw
    : IFromRawJson<ChargeEventV1WebhookEventDataCustomerDetails>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventDataCustomerDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventDataCustomerDetails.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ChargeEventV1WebhookEventDataPaykeyDetails,
        ChargeEventV1WebhookEventDataPaykeyDetailsFromRaw
    >)
)]
public sealed record class ChargeEventV1WebhookEventDataPaykeyDetails : JsonModel
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

    public ChargeEventV1WebhookEventDataPaykeyDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeEventV1WebhookEventDataPaykeyDetails(
        ChargeEventV1WebhookEventDataPaykeyDetails chargeEventV1WebhookEventDataPaykeyDetails
    )
        : base(chargeEventV1WebhookEventDataPaykeyDetails) { }
#pragma warning restore CS8618

    public ChargeEventV1WebhookEventDataPaykeyDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeEventV1WebhookEventDataPaykeyDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeEventV1WebhookEventDataPaykeyDetailsFromRaw.FromRawUnchecked"/>
    public static ChargeEventV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeEventV1WebhookEventDataPaykeyDetailsFromRaw
    : IFromRawJson<ChargeEventV1WebhookEventDataPaykeyDetails>
{
    /// <inheritdoc/>
    public ChargeEventV1WebhookEventDataPaykeyDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeEventV1WebhookEventDataPaykeyDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChargeEventV1WebhookEventDataPaymentRailConverter))]
public enum ChargeEventV1WebhookEventDataPaymentRail
{
    Ach,
}

sealed class ChargeEventV1WebhookEventDataPaymentRailConverter
    : JsonConverter<ChargeEventV1WebhookEventDataPaymentRail>
{
    public override ChargeEventV1WebhookEventDataPaymentRail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach" => ChargeEventV1WebhookEventDataPaymentRail.Ach,
            _ => (ChargeEventV1WebhookEventDataPaymentRail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeEventV1WebhookEventDataPaymentRail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeEventV1WebhookEventDataPaymentRail.Ach => "ach",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
