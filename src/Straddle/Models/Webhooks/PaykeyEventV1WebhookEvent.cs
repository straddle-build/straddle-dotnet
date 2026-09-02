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
    typeof(JsonModelConverter<PaykeyEventV1WebhookEvent, PaykeyEventV1WebhookEventFromRaw>)
)]
public sealed record class PaykeyEventV1WebhookEvent : JsonModel
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

    public required PaykeyEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaykeyEventV1WebhookEventData>("data");
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

    public PaykeyEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyEventV1WebhookEvent(PaykeyEventV1WebhookEvent paykeyEventV1WebhookEvent)
        : base(paykeyEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public PaykeyEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PaykeyEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyEventV1WebhookEventFromRaw : IFromRawJson<PaykeyEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public PaykeyEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PaykeyEventV1WebhookEventData, PaykeyEventV1WebhookEventDataFromRaw>)
)]
public sealed record class PaykeyEventV1WebhookEventData : JsonModel
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

    public required ApiEnum<string, PaykeyEventV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PaykeyEventV1WebhookEventDataStatus>
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

    public Balance? Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Balance>("balance");
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

    public BankData? BankData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BankData>("bank_data");
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

    public StatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StatusDetails>("status_details");
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

    public PaykeyEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyEventV1WebhookEventData(
        PaykeyEventV1WebhookEventData paykeyEventV1WebhookEventData
    )
        : base(paykeyEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public PaykeyEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PaykeyEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyEventV1WebhookEventDataFromRaw : IFromRawJson<PaykeyEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public PaykeyEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyEventV1WebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PaykeyEventV1WebhookEventDataStatusConverter))]
public enum PaykeyEventV1WebhookEventDataStatus
{
    Pending,
    Active,
    Inactive,
    Rejected,
    Review,
    Blocked,
}

sealed class PaykeyEventV1WebhookEventDataStatusConverter
    : JsonConverter<PaykeyEventV1WebhookEventDataStatus>
{
    public override PaykeyEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PaykeyEventV1WebhookEventDataStatus.Pending,
            "active" => PaykeyEventV1WebhookEventDataStatus.Active,
            "inactive" => PaykeyEventV1WebhookEventDataStatus.Inactive,
            "rejected" => PaykeyEventV1WebhookEventDataStatus.Rejected,
            "review" => PaykeyEventV1WebhookEventDataStatus.Review,
            "blocked" => PaykeyEventV1WebhookEventDataStatus.Blocked,
            _ => (PaykeyEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaykeyEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaykeyEventV1WebhookEventDataStatus.Pending => "pending",
                PaykeyEventV1WebhookEventDataStatus.Active => "active",
                PaykeyEventV1WebhookEventDataStatus.Inactive => "inactive",
                PaykeyEventV1WebhookEventDataStatus.Rejected => "rejected",
                PaykeyEventV1WebhookEventDataStatus.Review => "review",
                PaykeyEventV1WebhookEventDataStatus.Blocked => "blocked",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Balance, BalanceFromRaw>))]
public sealed record class Balance : JsonModel
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

    public Balance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Balance(Balance balance)
        : base(balance) { }
#pragma warning restore CS8618

    public Balance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Balance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceFromRaw.FromRawUnchecked"/>
    public static Balance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Balance(ApiEnum<string, PaykeyBalanceRefreshStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class BalanceFromRaw : IFromRawJson<Balance>
{
    /// <inheritdoc/>
    public Balance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Balance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BankData, BankDataFromRaw>))]
public sealed record class BankData : JsonModel
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

    public BankData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BankData(BankData bankData)
        : base(bankData) { }
#pragma warning restore CS8618

    public BankData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BankData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BankDataFromRaw.FromRawUnchecked"/>
    public static BankData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BankDataFromRaw : IFromRawJson<BankData>
{
    /// <inheritdoc/>
    public BankData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BankData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StatusDetails, StatusDetailsFromRaw>))]
public sealed record class StatusDetails : JsonModel
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

    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
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

    public StatusDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StatusDetails(StatusDetails statusDetails)
        : base(statusDetails) { }
#pragma warning restore CS8618

    public StatusDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StatusDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusDetailsFromRaw.FromRawUnchecked"/>
    public static StatusDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusDetailsFromRaw : IFromRawJson<StatusDetails>
{
    /// <inheritdoc/>
    public StatusDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StatusDetails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReasonConverter))]
public enum Reason
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

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => Reason.InsufficientFunds,
            "closed_bank_account" => Reason.ClosedBankAccount,
            "invalid_bank_account" => Reason.InvalidBankAccount,
            "invalid_routing" => Reason.InvalidRouting,
            "disputed" => Reason.Disputed,
            "payment_stopped" => Reason.PaymentStopped,
            "owner_deceased" => Reason.OwnerDeceased,
            "frozen_bank_account" => Reason.FrozenBankAccount,
            "risk_review" => Reason.RiskReview,
            "fraudulent" => Reason.Fraudulent,
            "duplicate_entry" => Reason.DuplicateEntry,
            "invalid_paykey" => Reason.InvalidPaykey,
            "payment_blocked" => Reason.PaymentBlocked,
            "amount_too_large" => Reason.AmountTooLarge,
            "too_many_attempts" => Reason.TooManyAttempts,
            "internal_system_error" => Reason.InternalSystemError,
            "user_request" => Reason.UserRequest,
            "ok" => Reason.Ok,
            "other_network_return" => Reason.OtherNetworkReturn,
            "payout_refused" => Reason.PayoutRefused,
            "validating" => Reason.Validating,
            "auto_hold" => Reason.AutoHold,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.ClosedBankAccount => "closed_bank_account",
                Reason.InvalidBankAccount => "invalid_bank_account",
                Reason.InvalidRouting => "invalid_routing",
                Reason.Disputed => "disputed",
                Reason.PaymentStopped => "payment_stopped",
                Reason.OwnerDeceased => "owner_deceased",
                Reason.FrozenBankAccount => "frozen_bank_account",
                Reason.RiskReview => "risk_review",
                Reason.Fraudulent => "fraudulent",
                Reason.DuplicateEntry => "duplicate_entry",
                Reason.InvalidPaykey => "invalid_paykey",
                Reason.PaymentBlocked => "payment_blocked",
                Reason.AmountTooLarge => "amount_too_large",
                Reason.TooManyAttempts => "too_many_attempts",
                Reason.InternalSystemError => "internal_system_error",
                Reason.UserRequest => "user_request",
                Reason.Ok => "ok",
                Reason.OtherNetworkReturn => "other_network_return",
                Reason.PayoutRefused => "payout_refused",
                Reason.Validating => "validating",
                Reason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
