using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(typeof(JsonModelConverter<PaykeyReview, PaykeyReviewFromRaw>))]
public sealed record class PaykeyReview : JsonModel
{
    public required Paykey PaykeyDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paykey>("paykey_details");
        }
        init { this._rawData.Set("paykey_details", value); }
    }

    public PaykeyVerificationDetails? VerificationDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaykeyVerificationDetails>(
                "verification_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verification_details", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PaykeyDetails.Validate();
        this.VerificationDetails?.Validate();
    }

    public PaykeyReview() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyReview(PaykeyReview paykeyReview)
        : base(paykeyReview) { }
#pragma warning restore CS8618

    public PaykeyReview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyReview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyReviewFromRaw.FromRawUnchecked"/>
    public static PaykeyReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaykeyReview(Paykey paykeyDetails)
        : this()
    {
        this.PaykeyDetails = paykeyDetails;
    }
}

class PaykeyReviewFromRaw : IFromRawJson<PaykeyReview>
{
    /// <inheritdoc/>
    public PaykeyReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaykeyReview.FromRawUnchecked(rawData);
}
