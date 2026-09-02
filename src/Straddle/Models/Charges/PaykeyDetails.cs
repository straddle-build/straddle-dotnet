using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<PaykeyDetails, PaykeyDetailsFromRaw>))]
public sealed record class PaykeyDetails : JsonModel
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
    /// Unique identifier for the customer associated with the paykey.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
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
    /// The most recent available balance in the smallest currency unit, if a
    /// balance check was performed.
    /// </summary>
    public int? Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CustomerID;
        _ = this.Label;
        _ = this.Balance;
    }

    public PaykeyDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyDetails(PaykeyDetails paykeyDetails)
        : base(paykeyDetails) { }
#pragma warning restore CS8618

    public PaykeyDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyDetailsFromRaw.FromRawUnchecked"/>
    public static PaykeyDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyDetailsFromRaw : IFromRawJson<PaykeyDetails>
{
    /// <inheritdoc/>
    public PaykeyDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaykeyDetails.FromRawUnchecked(rawData);
}
