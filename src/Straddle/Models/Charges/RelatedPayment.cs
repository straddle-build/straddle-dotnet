using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<RelatedPayment, RelatedPaymentFromRaw>))]
public sealed record class RelatedPayment : JsonModel
{
    /// <summary>
    /// Unique identifier of the related payment.
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
    /// The type of payment.
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

    public required ApiEnum<string, PaymentRelationship> Relationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentRelationship>>(
                "relationship"
            );
        }
        init { this._rawData.Set("relationship", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.PaymentType.Validate();
        this.Relationship.Validate();
    }

    public RelatedPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RelatedPayment(RelatedPayment relatedPayment)
        : base(relatedPayment) { }
#pragma warning restore CS8618

    public RelatedPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RelatedPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RelatedPaymentFromRaw.FromRawUnchecked"/>
    public static RelatedPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RelatedPaymentFromRaw : IFromRawJson<RelatedPayment>
{
    /// <inheritdoc/>
    public RelatedPayment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RelatedPayment.FromRawUnchecked(rawData);
}
