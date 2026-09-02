using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(
    typeof(JsonModelConverter<PaykeyVerificationDetails, PaykeyVerificationDetailsFromRaw>)
)]
public sealed record class PaykeyVerificationDetails : JsonModel
{
    /// <summary>
    /// Unique identifier for the verification details.
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

    public required PaykeyVerificationBreakdown Breakdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaykeyVerificationBreakdown>("breakdown");
        }
        init { this._rawData.Set("breakdown", value); }
    }

    /// <summary>
    /// Timestamp of when the verification was initiated.
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

    public required ApiEnum<string, PaykeyVerificationResult> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaykeyVerificationResult>>(
                "decision"
            );
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// Messages returned by the paykey verification process.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("messages");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "messages",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Timestamp of the most recent update to the verification details.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Breakdown.Validate();
        _ = this.CreatedAt;
        this.Decision.Validate();
        _ = this.Messages;
        _ = this.UpdatedAt;
    }

    public PaykeyVerificationDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyVerificationDetails(PaykeyVerificationDetails paykeyVerificationDetails)
        : base(paykeyVerificationDetails) { }
#pragma warning restore CS8618

    public PaykeyVerificationDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyVerificationDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyVerificationDetailsFromRaw.FromRawUnchecked"/>
    public static PaykeyVerificationDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyVerificationDetailsFromRaw : IFromRawJson<PaykeyVerificationDetails>
{
    /// <inheritdoc/>
    public PaykeyVerificationDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyVerificationDetails.FromRawUnchecked(rawData);
}
