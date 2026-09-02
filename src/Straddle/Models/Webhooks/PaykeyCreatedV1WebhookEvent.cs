using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Bridge;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PaykeyCreatedV1WebhookEvent, PaykeyCreatedV1WebhookEventFromRaw>)
)]
public sealed record class PaykeyCreatedV1WebhookEvent : JsonModel
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

    public required PaykeyCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaykeyCreatedV1WebhookEventData>("data");
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

    public PaykeyCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEvent(PaykeyCreatedV1WebhookEvent paykeyCreatedV1WebhookEvent)
        : base(paykeyCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public PaykeyCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PaykeyCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyCreatedV1WebhookEventFromRaw : IFromRawJson<PaykeyCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public PaykeyCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PaykeyCreatedV1WebhookEventData,
        PaykeyCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class PaykeyCreatedV1WebhookEventData : JsonModel
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
    /// Timestamp of when the paykey was created.
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
    /// Human-readable label for the paykey.
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
    /// Full paykey value for creating payments. Store this value securely.
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

    public required ApiEnum<string, PaykeySource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaykeySource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required ApiEnum<string, PaykeyCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PaykeyCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of the most recent update to the paykey.
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

    public PaykeyCreatedV1WebhookEventDataBalance? Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyCreatedV1WebhookEventDataBalance>(
                "balance"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("balance", value);
        }
    }

    public PaykeyCreatedV1WebhookEventDataBankData? BankData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyCreatedV1WebhookEventDataBankData>(
                "bank_data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bank_data", value);
        }
    }

    /// <summary>
    /// Unique identifier for the customer associated with the paykey.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// Expiration date and time of the paykey, if applicable.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name of the financial institution.
    /// </summary>
    public string? InstitutionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("institution_name");
        }
        init { this._rawData.Set("institution_name", value); }
    }

    /// <summary>
    /// Up to 20 user-defined key-value pairs associated with the paykey.
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

    public PaykeyCreatedV1WebhookEventDataStatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyCreatedV1WebhookEventDataStatusDetails>(
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
        _ = this.CreatedAt;
        _ = this.Label;
        _ = this.Paykey;
        this.Source.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        this.Balance?.Validate();
        this.BankData?.Validate();
        _ = this.CustomerID;
        _ = this.ExpiresAt;
        _ = this.InstitutionName;
        _ = this.Metadata;
        this.StatusDetails?.Validate();
    }

    public PaykeyCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEventData(
        PaykeyCreatedV1WebhookEventData paykeyCreatedV1WebhookEventData
    )
        : base(paykeyCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public PaykeyCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PaykeyCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyCreatedV1WebhookEventDataFromRaw : IFromRawJson<PaykeyCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public PaykeyCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PaykeyCreatedV1WebhookEventDataStatusConverter))]
public enum PaykeyCreatedV1WebhookEventDataStatus
{
    Pending,
    Active,
    Inactive,
    Rejected,
    Review,
    Blocked,
}

sealed class PaykeyCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<PaykeyCreatedV1WebhookEventDataStatus>
{
    public override PaykeyCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PaykeyCreatedV1WebhookEventDataStatus.Pending,
            "active" => PaykeyCreatedV1WebhookEventDataStatus.Active,
            "inactive" => PaykeyCreatedV1WebhookEventDataStatus.Inactive,
            "rejected" => PaykeyCreatedV1WebhookEventDataStatus.Rejected,
            "review" => PaykeyCreatedV1WebhookEventDataStatus.Review,
            "blocked" => PaykeyCreatedV1WebhookEventDataStatus.Blocked,
            _ => (PaykeyCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyCreatedV1WebhookEventDataStatus.Pending => "pending",
                PaykeyCreatedV1WebhookEventDataStatus.Active => "active",
                PaykeyCreatedV1WebhookEventDataStatus.Inactive => "inactive",
                PaykeyCreatedV1WebhookEventDataStatus.Rejected => "rejected",
                PaykeyCreatedV1WebhookEventDataStatus.Review => "review",
                PaykeyCreatedV1WebhookEventDataStatus.Blocked => "blocked",
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
        PaykeyCreatedV1WebhookEventDataBalance,
        PaykeyCreatedV1WebhookEventDataBalanceFromRaw
    >)
)]
public sealed record class PaykeyCreatedV1WebhookEventDataBalance : JsonModel
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
    /// Most recently retrieved account balance in dollars.
    /// </summary>
    public double? AccountBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("account_balance");
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

    public PaykeyCreatedV1WebhookEventDataBalance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEventDataBalance(
        PaykeyCreatedV1WebhookEventDataBalance paykeyCreatedV1WebhookEventDataBalance
    )
        : base(paykeyCreatedV1WebhookEventDataBalance) { }
#pragma warning restore CS8618

    public PaykeyCreatedV1WebhookEventDataBalance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyCreatedV1WebhookEventDataBalance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyCreatedV1WebhookEventDataBalanceFromRaw.FromRawUnchecked"/>
    public static PaykeyCreatedV1WebhookEventDataBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEventDataBalance(
        ApiEnum<string, PaykeyBalanceRefreshStatus> status
    )
        : this()
    {
        this.Status = status;
    }
}

class PaykeyCreatedV1WebhookEventDataBalanceFromRaw
    : IFromRawJson<PaykeyCreatedV1WebhookEventDataBalance>
{
    /// <inheritdoc/>
    public PaykeyCreatedV1WebhookEventDataBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyCreatedV1WebhookEventDataBalance.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PaykeyCreatedV1WebhookEventDataBankData,
        PaykeyCreatedV1WebhookEventDataBankDataFromRaw
    >)
)]
public sealed record class PaykeyCreatedV1WebhookEventDataBankData : JsonModel
{
    /// <summary>
    /// Masked bank account number.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    public required ApiEnum<string, AccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountType>>("account_type");
        }
        init { this._rawData.Set("account_type", value); }
    }

    /// <summary>
    /// Bank routing number.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        this.AccountType.Validate();
        _ = this.RoutingNumber;
    }

    public PaykeyCreatedV1WebhookEventDataBankData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEventDataBankData(
        PaykeyCreatedV1WebhookEventDataBankData paykeyCreatedV1WebhookEventDataBankData
    )
        : base(paykeyCreatedV1WebhookEventDataBankData) { }
#pragma warning restore CS8618

    public PaykeyCreatedV1WebhookEventDataBankData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyCreatedV1WebhookEventDataBankData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyCreatedV1WebhookEventDataBankDataFromRaw.FromRawUnchecked"/>
    public static PaykeyCreatedV1WebhookEventDataBankData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyCreatedV1WebhookEventDataBankDataFromRaw
    : IFromRawJson<PaykeyCreatedV1WebhookEventDataBankData>
{
    /// <inheritdoc/>
    public PaykeyCreatedV1WebhookEventDataBankData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyCreatedV1WebhookEventDataBankData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PaykeyCreatedV1WebhookEventDataStatusDetails,
        PaykeyCreatedV1WebhookEventDataStatusDetailsFromRaw
    >)
)]
public sealed record class PaykeyCreatedV1WebhookEventDataStatusDetails : JsonModel
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

    public required ApiEnum<string, PaykeyCreatedV1WebhookEventDataStatusDetailsReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PaykeyCreatedV1WebhookEventDataStatusDetailsReason>
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

    public PaykeyCreatedV1WebhookEventDataStatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyCreatedV1WebhookEventDataStatusDetails(
        PaykeyCreatedV1WebhookEventDataStatusDetails paykeyCreatedV1WebhookEventDataStatusDetails
    )
        : base(paykeyCreatedV1WebhookEventDataStatusDetails) { }
#pragma warning restore CS8618

    public PaykeyCreatedV1WebhookEventDataStatusDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyCreatedV1WebhookEventDataStatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyCreatedV1WebhookEventDataStatusDetailsFromRaw.FromRawUnchecked"/>
    public static PaykeyCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyCreatedV1WebhookEventDataStatusDetailsFromRaw
    : IFromRawJson<PaykeyCreatedV1WebhookEventDataStatusDetails>
{
    /// <inheritdoc/>
    public PaykeyCreatedV1WebhookEventDataStatusDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyCreatedV1WebhookEventDataStatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PaykeyCreatedV1WebhookEventDataStatusDetailsReasonConverter))]
public enum PaykeyCreatedV1WebhookEventDataStatusDetailsReason
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

sealed class PaykeyCreatedV1WebhookEventDataStatusDetailsReasonConverter
    : JsonConverter<PaykeyCreatedV1WebhookEventDataStatusDetailsReason>
{
    public override PaykeyCreatedV1WebhookEventDataStatusDetailsReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds,
            "closed_bank_account" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount,
            "invalid_bank_account" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount,
            "invalid_routing" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting,
            "disputed" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Disputed,
            "payment_stopped" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped,
            "owner_deceased" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased,
            "frozen_bank_account" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount,
            "risk_review" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.RiskReview,
            "fraudulent" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent,
            "duplicate_entry" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry,
            "invalid_paykey" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey,
            "payment_blocked" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked,
            "amount_too_large" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge,
            "too_many_attempts" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts,
            "internal_system_error" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError,
            "user_request" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.UserRequest,
            "ok" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Ok,
            "other_network_return" =>
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn,
            "payout_refused" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused,
            "validating" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Validating,
            "auto_hold" => PaykeyCreatedV1WebhookEventDataStatusDetailsReason.AutoHold,
            _ => (PaykeyCreatedV1WebhookEventDataStatusDetailsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyCreatedV1WebhookEventDataStatusDetailsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InsufficientFunds =>
                    "insufficient_funds",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.ClosedBankAccount =>
                    "closed_bank_account",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidBankAccount =>
                    "invalid_bank_account",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidRouting =>
                    "invalid_routing",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Disputed => "disputed",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PaymentStopped =>
                    "payment_stopped",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.OwnerDeceased =>
                    "owner_deceased",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.FrozenBankAccount =>
                    "frozen_bank_account",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.RiskReview => "risk_review",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Fraudulent => "fraudulent",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.DuplicateEntry =>
                    "duplicate_entry",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InvalidPaykey =>
                    "invalid_paykey",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PaymentBlocked =>
                    "payment_blocked",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.AmountTooLarge =>
                    "amount_too_large",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.TooManyAttempts =>
                    "too_many_attempts",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.InternalSystemError =>
                    "internal_system_error",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.UserRequest => "user_request",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Ok => "ok",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.OtherNetworkReturn =>
                    "other_network_return",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.PayoutRefused =>
                    "payout_refused",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.Validating => "validating",
                PaykeyCreatedV1WebhookEventDataStatusDetailsReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
