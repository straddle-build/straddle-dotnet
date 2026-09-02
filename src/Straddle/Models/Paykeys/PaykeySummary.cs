using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Models.Paykeys;

[JsonConverter(typeof(JsonModelConverter<PaykeySummary, PaykeySummaryFromRaw>))]
public sealed record class PaykeySummary : JsonModel
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

    public required PaykeyConfiguration Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaykeyConfiguration>("config");
        }
        init { this._rawData.Set("config", value); }
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
    /// Masked paykey value.
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

    public required ApiEnum<string, PaykeyStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaykeyStatus>>("status");
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

    public PaykeyBankDetails? BankData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyBankDetails>("bank_data");
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
    /// Unique identifier for the paykey in your system.
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

    public PaymentStatusDetails? StatusDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentStatusDetails>("status_details");
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

    /// <summary>
    /// Whether the paykey is eligible for client-initiated unblocking. `true` only
    /// when the paykey is blocked by an `R29` return and has not been unblocked
    /// before. `false` for other blocked paykeys. `null` when the paykey is not
    /// blocked.
    /// </summary>
    public bool? UnblockEligible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("unblock_eligible");
        }
        init { this._rawData.Set("unblock_eligible", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Config.Validate();
        _ = this.CreatedAt;
        _ = this.Label;
        _ = this.Paykey;
        this.Source.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        this.BankData?.Validate();
        _ = this.CustomerID;
        _ = this.ExpiresAt;
        _ = this.ExternalID;
        _ = this.InstitutionName;
        this.StatusDetails?.Validate();
        _ = this.UnblockEligible;
    }

    public PaykeySummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeySummary(PaykeySummary paykeySummary)
        : base(paykeySummary) { }
#pragma warning restore CS8618

    public PaykeySummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeySummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeySummaryFromRaw.FromRawUnchecked"/>
    public static PaykeySummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeySummaryFromRaw : IFromRawJson<PaykeySummary>
{
    /// <inheritdoc/>
    public PaykeySummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaykeySummary.FromRawUnchecked(rawData);
}
