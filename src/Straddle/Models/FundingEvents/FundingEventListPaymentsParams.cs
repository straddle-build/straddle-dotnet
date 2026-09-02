using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.FundingEvents;

/// <summary>
/// Returns a paginated list of payments included in the funding event.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FundingEventListPaymentsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Default number of results returned per page.
    /// </summary>
    public int? DefaultPageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("default_page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("default_page_size", value);
        }
    }

    /// <summary>
    /// Default field used to sort the results.
    /// </summary>
    public ApiEnum<string, DefaultSort>? DefaultSort
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, DefaultSort>>(
                "default_sort"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("default_sort", value);
        }
    }

    /// <summary>
    /// Default order in which to sort the results.
    /// </summary>
    public ApiEnum<string, AccountSortOrder>? DefaultSortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, AccountSortOrder>>(
                "default_sort_order"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("default_sort_order", value);
        }
    }

    /// <summary>
    /// When `true`, includes each payment's metadata. Defaults to `false`.
    /// </summary>
    public bool? IncludeMetadata
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_metadata", value);
        }
    }

    /// <summary>
    /// Results page number. Starts at 1. Defaults to 1.
    /// </summary>
    public int? PageNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Number of results per page. Maximum 1,000. Defaults to 100.
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Field used to sort the results.
    /// </summary>
    public ApiEnum<string, FundingEventListPaymentsParamsSortBy>? SortBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, FundingEventListPaymentsParamsSortBy>
            >("sort_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort_by", value);
        }
    }

    /// <summary>
    /// Order in which to sort the results.
    /// </summary>
    public ApiEnum<string, AccountSortOrder>? SortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, AccountSortOrder>>(
                "sort_order"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort_order", value);
        }
    }

    public string? CorrelationID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Correlation-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Correlation-Id", value);
        }
    }

    public string? RequestID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Request-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Request-Id", value);
        }
    }

    public string? StraddleAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Straddle-Account-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Straddle-Account-Id", value);
        }
    }

    public FundingEventListPaymentsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventListPaymentsParams(
        FundingEventListPaymentsParams fundingEventListPaymentsParams
    )
        : base(fundingEventListPaymentsParams)
    {
        this.ID = fundingEventListPaymentsParams.ID;
    }
#pragma warning restore CS8618

    public FundingEventListPaymentsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventListPaymentsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FundingEventListPaymentsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FundingEventListPaymentsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/funding_event_payments/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Default field used to sort the results.
/// </summary>
[JsonConverter(typeof(DefaultSortConverter))]
public enum DefaultSort
{
    CreatedAt,
    PaymentDate,
    EffectiveAt,
    ID,
}

sealed class DefaultSortConverter : JsonConverter<DefaultSort>
{
    public override DefaultSort Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at" => DefaultSort.CreatedAt,
            "payment_date" => DefaultSort.PaymentDate,
            "effective_at" => DefaultSort.EffectiveAt,
            "id" => DefaultSort.ID,
            _ => (DefaultSort)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultSort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DefaultSort.CreatedAt => "created_at",
                DefaultSort.PaymentDate => "payment_date",
                DefaultSort.EffectiveAt => "effective_at",
                DefaultSort.ID => "id",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Field used to sort the results.
/// </summary>
[JsonConverter(typeof(FundingEventListPaymentsParamsSortByConverter))]
public enum FundingEventListPaymentsParamsSortBy
{
    CreatedAt,
    PaymentDate,
    EffectiveAt,
    ID,
}

sealed class FundingEventListPaymentsParamsSortByConverter
    : JsonConverter<FundingEventListPaymentsParamsSortBy>
{
    public override FundingEventListPaymentsParamsSortBy Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at" => FundingEventListPaymentsParamsSortBy.CreatedAt,
            "payment_date" => FundingEventListPaymentsParamsSortBy.PaymentDate,
            "effective_at" => FundingEventListPaymentsParamsSortBy.EffectiveAt,
            "id" => FundingEventListPaymentsParamsSortBy.ID,
            _ => (FundingEventListPaymentsParamsSortBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FundingEventListPaymentsParamsSortBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FundingEventListPaymentsParamsSortBy.CreatedAt => "created_at",
                FundingEventListPaymentsParamsSortBy.PaymentDate => "payment_date",
                FundingEventListPaymentsParamsSortBy.EffectiveAt => "effective_at",
                FundingEventListPaymentsParamsSortBy.ID => "id",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
