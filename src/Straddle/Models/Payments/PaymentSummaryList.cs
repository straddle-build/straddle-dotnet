using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Accounts;

namespace Straddle.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentSummaryList, PaymentSummaryListFromRaw>))]
public sealed record class PaymentSummaryList : JsonModel
{
    /// <summary>
    /// Payments returned for this page.
    /// </summary>
    public required IReadOnlyList<PaymentSummary> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PaymentSummary>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PaymentSummary>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata for an API request and a page of results.
    /// </summary>
    public required PageMetadata Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageMetadata>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <summary>
    /// Shape of the response envelope.
    /// - `object` means `data` contains one JSON object.
    /// - `array` means `data` contains an array of JSON objects.
    /// - `error` means `error` contains the error details.
    /// - `none` means the response contains no data.
    /// </summary>
    public required ApiEnum<string, global::Straddle.Models.Bridge.ResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Bridge.ResponseType>
            >("response_type");
        }
        init { this._rawData.Set("response_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
        this.ResponseType.Validate();
    }

    public PaymentSummaryList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentSummaryList(PaymentSummaryList paymentSummaryList)
        : base(paymentSummaryList) { }
#pragma warning restore CS8618

    public PaymentSummaryList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSummaryList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSummaryListFromRaw.FromRawUnchecked"/>
    public static PaymentSummaryList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSummaryListFromRaw : IFromRawJson<PaymentSummaryList>
{
    /// <inheritdoc/>
    public PaymentSummaryList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentSummaryList.FromRawUnchecked(rawData);
}
