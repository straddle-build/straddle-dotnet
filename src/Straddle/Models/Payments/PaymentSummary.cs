using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;
using Straddle.Models.Charges;

namespace Straddle.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentSummary, PaymentSummaryFromRaw>))]
public sealed record class PaymentSummary : JsonModel
{
    /// <summary>
    /// Unique identifier for this charge or payout.
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

    /// <summary>
    /// Timestamp when the charge or payout was created.
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
    /// Human-readable description of the payment.
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

    /// <summary>
    /// Your unique identifier for the charge or payout.
    /// </summary>
    public required string ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// IDs of the funding events that included this payment.
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
    /// Whether this payment is a charge refunded by an associated payout.
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
    /// Whether this payment has been resubmitted.
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
    /// Whether this payment is a payout that refunds an original charge.
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
    /// Whether this payment resubmits an original payment.
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
    /// Masked paykey token used for the charge or payout.
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
    /// Date when Straddle submits the payment for processing.
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

    /// <summary>
    /// Whether this payment is a charge or payout.
    /// </summary>
    public required ApiEnum<string, PaymentType> PaymentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentType>>("payment_type");
        }
        init { this._rawData.Set("payment_type", value); }
    }

    /// <summary>
    /// Current status of the charge or payout.
    /// </summary>
    public required ApiEnum<string, PaymentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Reason, source, and message for the most recent status change.
    /// </summary>
    public required PaymentStatusDetails StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaymentStatusDetails>("status_details");
        }
        init { this._rawData.Set("status_details", value); }
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
    /// Timestamp when the charge or payout was last updated.
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
    /// Information about the customer associated with the charge or payout.
    /// </summary>
    public CustomerDetails? CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerDetails>("customer_details");
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
    /// Timestamp when funds settled. Null until settlement is confirmed.
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
    /// Unique identifier for the funding event associated with the `charge` or `payout`.
    /// </summary>
    public string? FundingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("funding_id");
        }
        init { this._rawData.Set("funding_id", value); }
    }

    /// <summary>
    /// Key-value metadata for the payment. Included only when `include_metadata` is true.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Details of the paykey used for the charge or payout.
    /// </summary>
    public PaykeyDetails? PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyDetails>("paykey_details");
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

    /// <summary>
    /// Related payments and their relationship to this charge or payout.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.Description;
        _ = this.ExternalID;
        _ = this.FundingIds;
        _ = this.HasRefund;
        _ = this.HasResubmit;
        _ = this.IsRefund;
        _ = this.IsResubmit;
        _ = this.Paykey;
        _ = this.PaymentDate;
        this.PaymentType.Validate();
        this.Status.Validate();
        this.StatusDetails.Validate();
        _ = this.TraceIds;
        _ = this.UpdatedAt;
        this.CustomerDetails?.Validate();
        _ = this.EffectiveAt;
        _ = this.FundingID;
        _ = this.Metadata;
        this.PaykeyDetails?.Validate();
        foreach (var item in this.RelatedPayments ?? [])
        {
            item.Validate();
        }
    }

    public PaymentSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentSummary(PaymentSummary paymentSummary)
        : base(paymentSummary) { }
#pragma warning restore CS8618

    public PaymentSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSummaryFromRaw.FromRawUnchecked"/>
    public static PaymentSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSummaryFromRaw : IFromRawJson<PaymentSummary>
{
    /// <inheritdoc/>
    public PaymentSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentSummary.FromRawUnchecked(rawData);
}
