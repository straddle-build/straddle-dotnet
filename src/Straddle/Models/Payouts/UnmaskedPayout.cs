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

namespace Straddle.Models.Payouts;

[JsonConverter(typeof(JsonModelConverter<UnmaskedPayout, UnmaskedPayoutFromRaw>))]
public sealed record class UnmaskedPayout : JsonModel
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

    public required PayoutConfiguration Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayoutConfiguration>("config");
        }
        init { this._rawData.Set("config", value); }
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

    public required PaymentDevice Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaymentDevice>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// Your unique identifier for this payout, used to correlate with your internal records.
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
    /// Unmasked paykey token used for this payout.
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

    /// <summary>
    /// The current status of the `charge` or `payout`.
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
    /// Complete ordered history of all status changes for this payout.
    /// </summary>
    public required IReadOnlyList<PaymentStatusHistory> StatusHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PaymentStatusHistory>>(
                "status_history"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PaymentStatusHistory>>(
                "status_history",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Trace identifiers from the payment network. Keys depend on the payment rail.
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
    /// Key-value metadata stored with this payout.
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
    /// The payment rail used for the charge or payout.
    /// </summary>
    public ApiEnum<string, PaymentRail>? PaymentRail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentRail>>("payment_rail");
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
        this.Config.Validate();
        _ = this.Currency;
        _ = this.Description;
        this.Device.Validate();
        _ = this.ExternalID;
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
        _ = this.TraceIds;
        _ = this.CreatedAt;
        this.CustomerDetails?.Validate();
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.EffectiveAt;
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

    public UnmaskedPayout() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedPayout(UnmaskedPayout unmaskedPayout)
        : base(unmaskedPayout) { }
#pragma warning restore CS8618

    public UnmaskedPayout(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedPayout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedPayoutFromRaw.FromRawUnchecked"/>
    public static UnmaskedPayout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedPayoutFromRaw : IFromRawJson<UnmaskedPayout>
{
    /// <inheritdoc/>
    public UnmaskedPayout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnmaskedPayout.FromRawUnchecked(rawData);
}
