using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

/// <summary>
/// Metadata for an API request and a page of results.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PageMetadata, PageMetadataFromRaw>))]
public sealed record class PageMetadata : JsonModel
{
    /// <summary>
    /// Unique identifier for the API request.
    /// </summary>
    public required string ApiRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_request_id");
        }
        init { this._rawData.Set("api_request_id", value); }
    }

    /// <summary>
    /// UTC timestamp for the API request.
    /// </summary>
    public required DateTimeOffset ApiRequestTimestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("api_request_timestamp");
        }
        init { this._rawData.Set("api_request_timestamp", value); }
    }

    /// <summary>
    /// Maximum page size allowed for this endpoint.
    /// </summary>
    public required int MaxPageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("max_page_size");
        }
        init { this._rawData.Set("max_page_size", value); }
    }

    /// <summary>
    /// Current page number.
    /// </summary>
    public required int PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public required int PageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("page_size");
        }
        init { this._rawData.Set("page_size", value); }
    }

    /// <summary>
    /// Field used to sort the results.
    /// </summary>
    public required string SortBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sort_by");
        }
        init { this._rawData.Set("sort_by", value); }
    }

    /// <summary>
    /// Sort direction for the results.
    /// </summary>
    public required ApiEnum<string, AccountSortOrder> SortOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountSortOrder>>("sort_order");
        }
        init { this._rawData.Set("sort_order", value); }
    }

    /// <summary>
    /// Total number of items available across all pages.
    /// </summary>
    public required int TotalItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_items");
        }
        init { this._rawData.Set("total_items", value); }
    }

    /// <summary>
    /// Total number of pages available.
    /// </summary>
    public required int TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_pages");
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiRequestID;
        _ = this.ApiRequestTimestamp;
        _ = this.MaxPageSize;
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.SortBy;
        this.SortOrder.Validate();
        _ = this.TotalItems;
        _ = this.TotalPages;
    }

    public PageMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageMetadata(PageMetadata pageMetadata)
        : base(pageMetadata) { }
#pragma warning restore CS8618

    public PageMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageMetadataFromRaw.FromRawUnchecked"/>
    public static PageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageMetadataFromRaw : IFromRawJson<PageMetadata>
{
    /// <inheritdoc/>
    public PageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PageMetadata.FromRawUnchecked(rawData);
}
