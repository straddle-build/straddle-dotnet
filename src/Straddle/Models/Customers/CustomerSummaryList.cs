using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Accounts;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerSummaryList, CustomerSummaryListFromRaw>))]
public sealed record class CustomerSummaryList : JsonModel
{
    /// <summary>
    /// Customers returned for this page.
    /// </summary>
    public required IReadOnlyList<CustomerSummary> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerSummary>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerSummary>>(
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

    public CustomerSummaryList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerSummaryList(CustomerSummaryList customerSummaryList)
        : base(customerSummaryList) { }
#pragma warning restore CS8618

    public CustomerSummaryList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerSummaryList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerSummaryListFromRaw.FromRawUnchecked"/>
    public static CustomerSummaryList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerSummaryListFromRaw : IFromRawJson<CustomerSummaryList>
{
    /// <inheritdoc/>
    public CustomerSummaryList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerSummaryList.FromRawUnchecked(rawData);
}
