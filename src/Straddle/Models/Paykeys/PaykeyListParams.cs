using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;
using Straddle.Models.Bridge;

namespace Straddle.Models.Paykeys;

/// <summary>
/// Returns a paginated list of paykeys for the account. Optional query parameters
/// filter, search, and sort the results.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PaykeyListParams : ParamsBase
{
    /// <summary>
    /// Start date for filtering by creation date.
    /// </summary>
    public DateTimeOffset? CreatedFrom
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_from", value);
        }
    }

    /// <summary>
    /// End date for filtering by creation date.
    /// </summary>
    public DateTimeOffset? CreatedTo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_to", value);
        }
    }

    /// <summary>
    /// Filter paykeys by related customer ID.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("customer_id", value);
        }
    }

    /// <summary>
    /// Page number for paginated results. Starts at 1.
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
    /// Number of results per page. Maximum: 1000.
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
    /// General search term to filter paykeys.
    /// </summary>
    public string? SearchText
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search_text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search_text", value);
        }
    }

    /// <summary>
    /// Field used to sort the results.
    /// </summary>
    public ApiEnum<string, SortBy>? SortBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortBy>>("sort_by");
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

    /// <summary>
    /// Filter paykeys by their source.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaykeySource>>? Source
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaykeySource>>
            >("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaykeySource>>?>(
                "source",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter paykeys by their current status.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaykeyStatus>>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaykeyStatus>>
            >("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaykeyStatus>>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filters paykeys by unblock eligibility. `true` returns blocked paykeys that
    /// are eligible because of an `R29` return and have not been unblocked before.
    /// `false` returns blocked paykeys that are not eligible.
    /// </summary>
    public bool? UnblockEligible
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("unblock_eligible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("unblock_eligible", value);
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

    public PaykeyListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyListParams(PaykeyListParams paykeyListParams)
        : base(paykeyListParams) { }
#pragma warning restore CS8618

    public PaykeyListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PaykeyListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(PaykeyListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/paykeys")
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
/// Field used to sort the results.
/// </summary>
[JsonConverter(typeof(SortByConverter))]
public enum SortBy
{
    InstitutionName,
    ExpiresAt,
    CreatedAt,
}

sealed class SortByConverter : JsonConverter<SortBy>
{
    public override SortBy Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "institution_name" => SortBy.InstitutionName,
            "expires_at" => SortBy.ExpiresAt,
            "created_at" => SortBy.CreatedAt,
            _ => (SortBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, SortBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortBy.InstitutionName => "institution_name",
                SortBy.ExpiresAt => "expires_at",
                SortBy.CreatedAt => "created_at",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
