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
    typeof(JsonModelConverter<ChargeCreatedV1WebhookEvent, ChargeCreatedV1WebhookEventFromRaw>)
)]
public sealed record class ChargeCreatedV1WebhookEvent : JsonModel
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

    public required ChargeCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeCreatedV1WebhookEventData>("data");
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

    public ChargeCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeCreatedV1WebhookEvent(ChargeCreatedV1WebhookEvent chargeCreatedV1WebhookEvent)
        : base(chargeCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public ChargeCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static ChargeCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeCreatedV1WebhookEventFromRaw : IFromRawJson<ChargeCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public ChargeCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ChargeCreatedV1WebhookEventData,
        ChargeCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class ChargeCreatedV1WebhookEventData : JsonModel
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

    public required Config Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Config>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    public required ApiEnum<string, global::Straddle.Models.Webhooks.ConsentType> ConsentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Webhooks.ConsentType>
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

    public required ApiEnum<string, ChargeCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ChargeCreatedV1WebhookEventDataStatusDetails StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChargeCreatedV1WebhookEventDataStatusDetails>(
                "status_details"
            );
        }
        init { this._rawData.Set("status_details", value); }
    }

    /// <summary>
    /// Complete ordered history of all status changes for this charge.
    /// </summary>
    public required IReadOnlyList<StatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StatusHistory>>("status_history");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StatusHistory>>(
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

    public global::Straddle.Models.Webhooks.CustomerDetails? CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Straddle.Models.Webhooks.CustomerDetails>(
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

    public global::Straddle.Models.Webhooks.PaykeyDetails? PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Straddle.Models.Webhooks.PaykeyDetails>(
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

    public ApiEnum<string, global::Straddle.Models.Webhooks.PaymentRail>? PaymentRail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Straddle.Models.Webhooks.PaymentRail>
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

    public ChargeCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeCreatedV1WebhookEventData(
        ChargeCreatedV1WebhookEventData chargeCreatedV1WebhookEventData
    )
        : base(chargeCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public ChargeCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static ChargeCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeCreatedV1WebhookEventDataFromRaw : IFromRawJson<ChargeCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public ChargeCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : JsonModel
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

    public Config() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Config(Config config)
        : base(config) { }
#pragma warning restore CS8618

    public Config(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Config(ApiEnum<string, BalanceCheckMode> balanceCheck)
        : this()
    {
        this.BalanceCheck = balanceCheck;
    }
}

class ConfigFromRaw : IFromRawJson<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Straddle.Models.Webhooks.ConsentTypeConverter))]
public enum ConsentType
{
    Internet,
    Signed,
}

sealed class ConsentTypeConverter : JsonConverter<global::Straddle.Models.Webhooks.ConsentType>
{
    public override global::Straddle.Models.Webhooks.ConsentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internet" => global::Straddle.Models.Webhooks.ConsentType.Internet,
            "signed" => global::Straddle.Models.Webhooks.ConsentType.Signed,
            _ => (global::Straddle.Models.Webhooks.ConsentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.Webhooks.ConsentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.Webhooks.ConsentType.Internet => "internet",
                global::Straddle.Models.Webhooks.ConsentType.Signed => "signed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ChargeCreatedV1WebhookEventDataStatusConverter))]
public enum ChargeCreatedV1WebhookEventDataStatus
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

sealed class ChargeCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<ChargeCreatedV1WebhookEventDataStatus>
{
    public override ChargeCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => ChargeCreatedV1WebhookEventDataStatus.Created,
            "scheduled" => ChargeCreatedV1WebhookEventDataStatus.Scheduled,
            "failed" => ChargeCreatedV1WebhookEventDataStatus.Failed,
            "cancelled" => ChargeCreatedV1WebhookEventDataStatus.Cancelled,
            "on_hold" => ChargeCreatedV1WebhookEventDataStatus.OnHold,
            "pending" => ChargeCreatedV1WebhookEventDataStatus.Pending,
            "paid" => ChargeCreatedV1WebhookEventDataStatus.Paid,
            "reversed" => ChargeCreatedV1WebhookEventDataStatus.Reversed,
            _ => (ChargeCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeCreatedV1WebhookEventDataStatus.Created => "created",
                ChargeCreatedV1WebhookEventDataStatus.Scheduled => "scheduled",
                ChargeCreatedV1WebhookEventDataStatus.Failed => "failed",
                ChargeCreatedV1WebhookEventDataStatus.Cancelled => "cancelled",
                ChargeCreatedV1WebhookEventDataStatus.OnHold => "on_hold",
                ChargeCreatedV1WebhookEventDataStatus.Pending => "pending",
                ChargeCreatedV1WebhookEventDataStatus.Paid => "paid",
                ChargeCreatedV1WebhookEventDataStatus.Reversed => "reversed",
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
        ChargeCreatedV1WebhookEventDataStatusDetails,
        ChargeCreatedV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class ChargeCreatedV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, ChargeCreatedV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeCreatedV1WebhookEventDataStatusDetailsReason>
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

    public ChargeCreatedV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeCreatedV1WebhookEventDataStatusDetails(
        ChargeCreatedV1WebhookEventDataStatusDetails chargeCreatedV1WebhookEventDataStatusDetails
    )
        : base(chargeCreatedV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public ChargeCreatedV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeCreatedV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeCreatedV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static ChargeCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeCreatedV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<ChargeCreatedV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public ChargeCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeCreatedV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChargeCreatedV1WebhookEventDataStatusDetailsReasonConverter))]
public enum ChargeCreatedV1WebhookEventDataStatusDetailsReason
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

sealed class ChargeCreatedV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<ChargeCreatedV1WebhookEventDataStatusDetailsReason>
{
    public override ChargeCreatedV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => ChargeCreatedV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (ChargeCreatedV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeCreatedV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased =>
                    "owner_deceased",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey =>
                    "invalid_paykey",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.UserRequest => "user_request",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused =>
                    "payout_refused",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                ChargeCreatedV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<StatusHistory, StatusHistoryFromRaw>))]
public sealed record class StatusHistory : JsonModel
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

    public required ApiEnum<string, StatusHistoryReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StatusHistoryReason>>("reason");
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

    public required ApiEnum<string, StatusHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StatusHistoryStatus>>("status");
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

    public StatusHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StatusHistory(StatusHistory statusHistory)
        : base(statusHistory) { }
#pragma warning restore CS8618

    public StatusHistory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StatusHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusHistoryFromRaw.FromRawUnchecked"/>
    public static StatusHistory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusHistoryFromRaw : IFromRawJson<StatusHistory>
{
    /// <inheritdoc/>
    public StatusHistory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StatusHistory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusHistoryReasonConverter))]
public enum StatusHistoryReason
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

sealed class StatusHistoryReasonConverter : JsonConverter<StatusHistoryReason>
{
    public override StatusHistoryReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => StatusHistoryReason.InsufficientFunds,
            "closed_bank_account" => StatusHistoryReason.ClosedBankAccount,
            "invalid_bank_account" => StatusHistoryReason.InvalidBankAccount,
            "invalid_routing" => StatusHistoryReason.InvalidRouting,
            "disputed" => StatusHistoryReason.Disputed,
            "payment_stopped" => StatusHistoryReason.PaymentStopped,
            "owner_deceased" => StatusHistoryReason.OwnerDeceased,
            "frozen_bank_account" => StatusHistoryReason.FrozenBankAccount,
            "risk_review" => StatusHistoryReason.RiskReview,
            "fraudulent" => StatusHistoryReason.Fraudulent,
            "duplicate_entry" => StatusHistoryReason.DuplicateEntry,
            "invalid_paykey" => StatusHistoryReason.InvalidPaykey,
            "payment_blocked" => StatusHistoryReason.PaymentBlocked,
            "amount_too_large" => StatusHistoryReason.AmountTooLarge,
            "too_many_attempts" => StatusHistoryReason.TooManyAttempts,
            "internal_system_error" => StatusHistoryReason.InternalSystemError,
            "user_request" => StatusHistoryReason.UserRequest,
            "ok" => StatusHistoryReason.Ok,
            "other_network_return" => StatusHistoryReason.OtherNetworkReturn,
            "payout_refused" => StatusHistoryReason.PayoutRefused,
            "validating" => StatusHistoryReason.Validating,
            "auto_hold" => StatusHistoryReason.AutoHold,
            _ => (StatusHistoryReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusHistoryReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusHistoryReason.InsufficientFunds => "insufficient_funds",
                StatusHistoryReason.ClosedBankAccount => "closed_bank_account",
                StatusHistoryReason.InvalidBankAccount => "invalid_bank_account",
                StatusHistoryReason.InvalidRouting => "invalid_routing",
                StatusHistoryReason.Disputed => "disputed",
                StatusHistoryReason.PaymentStopped => "payment_stopped",
                StatusHistoryReason.OwnerDeceased => "owner_deceased",
                StatusHistoryReason.FrozenBankAccount => "frozen_bank_account",
                StatusHistoryReason.RiskReview => "risk_review",
                StatusHistoryReason.Fraudulent => "fraudulent",
                StatusHistoryReason.DuplicateEntry => "duplicate_entry",
                StatusHistoryReason.InvalidPaykey => "invalid_paykey",
                StatusHistoryReason.PaymentBlocked => "payment_blocked",
                StatusHistoryReason.AmountTooLarge => "amount_too_large",
                StatusHistoryReason.TooManyAttempts => "too_many_attempts",
                StatusHistoryReason.InternalSystemError => "internal_system_error",
                StatusHistoryReason.UserRequest => "user_request",
                StatusHistoryReason.Ok => "ok",
                StatusHistoryReason.OtherNetworkReturn => "other_network_return",
                StatusHistoryReason.PayoutRefused => "payout_refused",
                StatusHistoryReason.Validating => "validating",
                StatusHistoryReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusHistoryStatusConverter))]
public enum StatusHistoryStatus
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

sealed class StatusHistoryStatusConverter : JsonConverter<StatusHistoryStatus>
{
    public override StatusHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => StatusHistoryStatus.Created,
            "scheduled" => StatusHistoryStatus.Scheduled,
            "failed" => StatusHistoryStatus.Failed,
            "cancelled" => StatusHistoryStatus.Cancelled,
            "on_hold" => StatusHistoryStatus.OnHold,
            "pending" => StatusHistoryStatus.Pending,
            "paid" => StatusHistoryStatus.Paid,
            "reversed" => StatusHistoryStatus.Reversed,
            _ => (StatusHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusHistoryStatus.Created => "created",
                StatusHistoryStatus.Scheduled => "scheduled",
                StatusHistoryStatus.Failed => "failed",
                StatusHistoryStatus.Cancelled => "cancelled",
                StatusHistoryStatus.OnHold => "on_hold",
                StatusHistoryStatus.Pending => "pending",
                StatusHistoryStatus.Paid => "paid",
                StatusHistoryStatus.Reversed => "reversed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CustomerDetails, CustomerDetailsFromRaw>))]
public sealed record class CustomerDetails : JsonModel
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

    public CustomerDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerDetails(CustomerDetails customerDetails)
        : base(customerDetails) { }
#pragma warning restore CS8618

    public CustomerDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerDetailsFromRaw.FromRawUnchecked"/>
    public static CustomerDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerDetailsFromRaw : IFromRawJson<CustomerDetails>
{
    /// <inheritdoc/>
    public CustomerDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PaykeyDetails, PaykeyDetailsFromRaw>))]
public sealed record class PaykeyDetails : JsonModel
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

    public PaykeyDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyDetails(PaykeyDetails paykeyDetails)
        : base(paykeyDetails) { }
#pragma warning restore CS8618

    public PaykeyDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyDetailsFromRaw.FromRawUnchecked"/>
    public static PaykeyDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyDetailsFromRaw : IFromRawJson<PaykeyDetails>
{
    /// <inheritdoc/>
    public PaykeyDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaykeyDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Straddle.Models.Webhooks.PaymentRailConverter))]
public enum PaymentRail
{
    Ach,
}

sealed class PaymentRailConverter : JsonConverter<global::Straddle.Models.Webhooks.PaymentRail>
{
    public override global::Straddle.Models.Webhooks.PaymentRail Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ach" => global::Straddle.Models.Webhooks.PaymentRail.Ach,
            _ => (global::Straddle.Models.Webhooks.PaymentRail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.Webhooks.PaymentRail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.Webhooks.PaymentRail.Ach => "ach",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
