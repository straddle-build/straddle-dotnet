using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Exceptions;

namespace Straddle.Models.Charges;

/// <summary>
/// Payment will simulate processing if not Standard.
/// </summary>
[JsonConverter(typeof(SimulatedPaymentOutcomeConverter))]
public enum SimulatedPaymentOutcome
{
    Standard,
    Paid,
    OnHoldDailyLimit,
    CancelledForFraudRisk,
    CancelledForBalanceCheck,
    FailedInsufficientFunds,
    ReversedInsufficientFunds,
    FailedCustomerDispute,
    ReversedCustomerDispute,
    FailedClosedBankAccount,
    ReversedClosedBankAccount,
    FailedNotAuthorized,
    ReversedNotAuthorized,
}

sealed class SimulatedPaymentOutcomeConverter : JsonConverter<SimulatedPaymentOutcome>
{
    public override SimulatedPaymentOutcome Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => SimulatedPaymentOutcome.Standard,
            "paid" => SimulatedPaymentOutcome.Paid,
            "on_hold_daily_limit" => SimulatedPaymentOutcome.OnHoldDailyLimit,
            "cancelled_for_fraud_risk" => SimulatedPaymentOutcome.CancelledForFraudRisk,
            "cancelled_for_balance_check" => SimulatedPaymentOutcome.CancelledForBalanceCheck,
            "failed_insufficient_funds" => SimulatedPaymentOutcome.FailedInsufficientFunds,
            "reversed_insufficient_funds" => SimulatedPaymentOutcome.ReversedInsufficientFunds,
            "failed_customer_dispute" => SimulatedPaymentOutcome.FailedCustomerDispute,
            "reversed_customer_dispute" => SimulatedPaymentOutcome.ReversedCustomerDispute,
            "failed_closed_bank_account" => SimulatedPaymentOutcome.FailedClosedBankAccount,
            "reversed_closed_bank_account" => SimulatedPaymentOutcome.ReversedClosedBankAccount,
            "failed_not_authorized" => SimulatedPaymentOutcome.FailedNotAuthorized,
            "reversed_not_authorized" => SimulatedPaymentOutcome.ReversedNotAuthorized,
            _ => (SimulatedPaymentOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimulatedPaymentOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SimulatedPaymentOutcome.Standard => "standard",
                SimulatedPaymentOutcome.Paid => "paid",
                SimulatedPaymentOutcome.OnHoldDailyLimit => "on_hold_daily_limit",
                SimulatedPaymentOutcome.CancelledForFraudRisk => "cancelled_for_fraud_risk",
                SimulatedPaymentOutcome.CancelledForBalanceCheck => "cancelled_for_balance_check",
                SimulatedPaymentOutcome.FailedInsufficientFunds => "failed_insufficient_funds",
                SimulatedPaymentOutcome.ReversedInsufficientFunds => "reversed_insufficient_funds",
                SimulatedPaymentOutcome.FailedCustomerDispute => "failed_customer_dispute",
                SimulatedPaymentOutcome.ReversedCustomerDispute => "reversed_customer_dispute",
                SimulatedPaymentOutcome.FailedClosedBankAccount => "failed_closed_bank_account",
                SimulatedPaymentOutcome.ReversedClosedBankAccount => "reversed_closed_bank_account",
                SimulatedPaymentOutcome.FailedNotAuthorized => "failed_not_authorized",
                SimulatedPaymentOutcome.ReversedNotAuthorized => "reversed_not_authorized",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
