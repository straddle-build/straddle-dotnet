using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(PaymentStatusReasonConverter))]
public enum PaymentStatusReason
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
    CancelRequest,
    FailedVerification,
    RequireReview,
    BlockedBySystem,
    WatchtowerReview,
    Validating,
    AutoHold,
}

sealed class PaymentStatusReasonConverter : JsonConverter<PaymentStatusReason>
{
    public override PaymentStatusReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => PaymentStatusReason.InsufficientFunds,
            "closed_bank_account" => PaymentStatusReason.ClosedBankAccount,
            "invalid_bank_account" => PaymentStatusReason.InvalidBankAccount,
            "invalid_routing" => PaymentStatusReason.InvalidRouting,
            "disputed" => PaymentStatusReason.Disputed,
            "payment_stopped" => PaymentStatusReason.PaymentStopped,
            "owner_deceased" => PaymentStatusReason.OwnerDeceased,
            "frozen_bank_account" => PaymentStatusReason.FrozenBankAccount,
            "risk_review" => PaymentStatusReason.RiskReview,
            "fraudulent" => PaymentStatusReason.Fraudulent,
            "duplicate_entry" => PaymentStatusReason.DuplicateEntry,
            "invalid_paykey" => PaymentStatusReason.InvalidPaykey,
            "payment_blocked" => PaymentStatusReason.PaymentBlocked,
            "amount_too_large" => PaymentStatusReason.AmountTooLarge,
            "too_many_attempts" => PaymentStatusReason.TooManyAttempts,
            "internal_system_error" => PaymentStatusReason.InternalSystemError,
            "user_request" => PaymentStatusReason.UserRequest,
            "ok" => PaymentStatusReason.Ok,
            "other_network_return" => PaymentStatusReason.OtherNetworkReturn,
            "payout_refused" => PaymentStatusReason.PayoutRefused,
            "cancel_request" => PaymentStatusReason.CancelRequest,
            "failed_verification" => PaymentStatusReason.FailedVerification,
            "require_review" => PaymentStatusReason.RequireReview,
            "blocked_by_system" => PaymentStatusReason.BlockedBySystem,
            "watchtower_review" => PaymentStatusReason.WatchtowerReview,
            "validating" => PaymentStatusReason.Validating,
            "auto_hold" => PaymentStatusReason.AutoHold,
            _ => (PaymentStatusReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentStatusReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentStatusReason.InsufficientFunds => "insufficient_funds",
                PaymentStatusReason.ClosedBankAccount => "closed_bank_account",
                PaymentStatusReason.InvalidBankAccount => "invalid_bank_account",
                PaymentStatusReason.InvalidRouting => "invalid_routing",
                PaymentStatusReason.Disputed => "disputed",
                PaymentStatusReason.PaymentStopped => "payment_stopped",
                PaymentStatusReason.OwnerDeceased => "owner_deceased",
                PaymentStatusReason.FrozenBankAccount => "frozen_bank_account",
                PaymentStatusReason.RiskReview => "risk_review",
                PaymentStatusReason.Fraudulent => "fraudulent",
                PaymentStatusReason.DuplicateEntry => "duplicate_entry",
                PaymentStatusReason.InvalidPaykey => "invalid_paykey",
                PaymentStatusReason.PaymentBlocked => "payment_blocked",
                PaymentStatusReason.AmountTooLarge => "amount_too_large",
                PaymentStatusReason.TooManyAttempts => "too_many_attempts",
                PaymentStatusReason.InternalSystemError => "internal_system_error",
                PaymentStatusReason.UserRequest => "user_request",
                PaymentStatusReason.Ok => "ok",
                PaymentStatusReason.OtherNetworkReturn => "other_network_return",
                PaymentStatusReason.PayoutRefused => "payout_refused",
                PaymentStatusReason.CancelRequest => "cancel_request",
                PaymentStatusReason.FailedVerification => "failed_verification",
                PaymentStatusReason.RequireReview => "require_review",
                PaymentStatusReason.BlockedBySystem => "blocked_by_system",
                PaymentStatusReason.WatchtowerReview => "watchtower_review",
                PaymentStatusReason.Validating => "validating",
                PaymentStatusReason.AutoHold => "auto_hold",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
