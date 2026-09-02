using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Charges;

namespace Straddle.Models.FundingEvents;

[JsonConverter(typeof(JsonModelConverter<FundingEventPayment, FundingEventPaymentFromRaw>))]
public sealed record class FundingEventPayment : JsonModel
{
    /// <summary>
    /// Unique identifier for this payment.
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
    /// Three-letter ISO 4217 currency code.
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
    /// Your unique identifier for this payment, used to correlate with your internal records.
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
    /// Portion of the payment amount included in this funding event, in the smallest currency unit.
    /// </summary>
    public required int FundingAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("funding_amount");
        }
        init { this._rawData.Set("funding_amount", value); }
    }

    /// <summary>
    /// Total payment amount in the smallest currency unit (e.g. 1000 = $10.00 USD).
    /// </summary>
    public required int PaymentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("payment_amount");
        }
        init { this._rawData.Set("payment_amount", value); }
    }

    /// <summary>
    /// The date on which this payment was submitted for processing.
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
    /// Reason this payment was included in the funding event.
    /// </summary>
    public required ApiEnum<string, FundingEventPaymentReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FundingEventPaymentReason>>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Current status of this payment.
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
    /// Details of the customer associated with this payment.
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
    /// Key-value metadata for this payment. Included only when `include_metadata` is `true`.
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
    /// Details of the paykey used for this payment.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Currency;
        _ = this.ExternalID;
        _ = this.FundingAmount;
        _ = this.PaymentAmount;
        _ = this.PaymentDate;
        this.PaymentType.Validate();
        this.Reason.Validate();
        this.Status.Validate();
        _ = this.TraceIds;
        this.CustomerDetails?.Validate();
        _ = this.Metadata;
        this.PaykeyDetails?.Validate();
    }

    public FundingEventPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventPayment(FundingEventPayment fundingEventPayment)
        : base(fundingEventPayment) { }
#pragma warning restore CS8618

    public FundingEventPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventPaymentFromRaw.FromRawUnchecked"/>
    public static FundingEventPayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventPaymentFromRaw : IFromRawJson<FundingEventPayment>
{
    /// <inheritdoc/>
    public FundingEventPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FundingEventPayment.FromRawUnchecked(rawData);
}
