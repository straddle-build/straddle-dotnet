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
using Straddle.Models.Charges;

namespace Straddle.Models.Payments;

/// <summary>
/// Returns a paged list of charges and payouts that match the filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PaymentListParams : ParamsBase
{
    /// <summary>
    /// Filter by the unique identifier of the customer.
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
    /// Filter by your external identifier for the payment.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("external_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("external_id", value);
        }
    }

    /// <summary>
    /// Filter by the unique identifier of a funding event.
    /// </summary>
    public string? FundingID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("funding_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("funding_id", value);
        }
    }

    /// <summary>
    /// Filter charges by whether an associated payout has refunded them.
    /// </summary>
    public bool? HasRefund
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("has_refund");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("has_refund", value);
        }
    }

    /// <summary>
    /// Filter payments by whether they have been resubmitted.
    /// </summary>
    public bool? HasResubmit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("has_resubmit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("has_resubmit", value);
        }
    }

    /// <summary>
    /// Whether to include metadata in each returned payment. Defaults to false.
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
    /// Filter payouts by whether they refund an original charge.
    /// </summary>
    public bool? IsRefund
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("is_refund");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("is_refund", value);
        }
    }

    /// <summary>
    /// Filter payments by whether they resubmit an original payment.
    /// </summary>
    public bool? IsResubmit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("is_resubmit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("is_resubmit", value);
        }
    }

    /// <summary>
    /// Filter to payments with an amount in cents less than or equal to this value.
    /// </summary>
    public int? MaxAmount
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("max_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_amount", value);
        }
    }

    /// <summary>
    /// Filter to payments created at or before this timestamp.
    /// </summary>
    public DateTimeOffset? MaxCreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("max_created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_created_at", value);
        }
    }

    /// <summary>
    /// Filter to payments effective at or before this timestamp.
    /// </summary>
    public DateTimeOffset? MaxEffectiveAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("max_effective_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_effective_at", value);
        }
    }

    /// <summary>
    /// Filter to payments with a payment date on or before this date.
    /// </summary>
    public string? MaxPaymentDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("max_payment_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_payment_date", value);
        }
    }

    /// <summary>
    /// Filter to payments last updated on or before this timestamp.
    /// </summary>
    public DateTimeOffset? MaxUpdatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("max_updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_updated_at", value);
        }
    }

    /// <summary>
    /// Filter to payments with an amount in cents greater than or equal to this value.
    /// </summary>
    public int? MinAmount
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("min_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_amount", value);
        }
    }

    /// <summary>
    /// Filter to payments created at or after this timestamp.
    /// </summary>
    public DateTimeOffset? MinCreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("min_created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_created_at", value);
        }
    }

    /// <summary>
    /// Filter to payments effective at or after this timestamp.
    /// </summary>
    public DateTimeOffset? MinEffectiveAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("min_effective_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_effective_at", value);
        }
    }

    /// <summary>
    /// Filter to payments with a payment date on or after this date.
    /// </summary>
    public string? MinPaymentDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("min_payment_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_payment_date", value);
        }
    }

    /// <summary>
    /// Filter to payments last updated on or after this timestamp.
    /// </summary>
    public DateTimeOffset? MinUpdatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("min_updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_updated_at", value);
        }
    }

    /// <summary>
    /// Page number to return.
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
    /// Number of results to return per page.
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
    /// Filter by the paykey token.
    /// </summary>
    public string? Paykey
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("paykey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("paykey", value);
        }
    }

    /// <summary>
    /// Filter by the unique identifier of the paykey.
    /// </summary>
    public string? PaykeyID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("paykey_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("paykey_id", value);
        }
    }

    /// <summary>
    /// Filter by the payment's unique identifier.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("payment_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("payment_id", value);
        }
    }

    /// <summary>
    /// Filter by payment status.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaymentStatus>>? PaymentStatus
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentStatus>>
            >("payment_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaymentStatus>>?>(
                "payment_status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by payment type.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaymentType>>? PaymentType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentType>>
            >("payment_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaymentType>>?>(
                "payment_type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Free-text search across payment fields.
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
    /// Filter by the reason for the most recent payment status change.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaymentStatusReason>>? StatusReason
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentStatusReason>>
            >("status_reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaymentStatusReason>>?>(
                "status_reason",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by the source of the most recent payment status change.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PaymentStatusSource>>? StatusSource
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PaymentStatusSource>>
            >("status_source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, PaymentStatusSource>>?>(
                "status_source",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public PaymentListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentListParams(PaymentListParams paymentListParams)
        : base(paymentListParams) { }
#pragma warning restore CS8618

    public PaymentListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PaymentListParams FromRawUnchecked(
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

    public virtual bool Equals(PaymentListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/payments")
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
    Amount,
    UpdatedAt,
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
            "amount" => DefaultSort.Amount,
            "updated_at" => DefaultSort.UpdatedAt,
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
                DefaultSort.Amount => "amount",
                DefaultSort.UpdatedAt => "updated_at",
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
[JsonConverter(typeof(SortByConverter))]
public enum SortBy
{
    CreatedAt,
    PaymentDate,
    EffectiveAt,
    ID,
    Amount,
    UpdatedAt,
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
            "created_at" => SortBy.CreatedAt,
            "payment_date" => SortBy.PaymentDate,
            "effective_at" => SortBy.EffectiveAt,
            "id" => SortBy.ID,
            "amount" => SortBy.Amount,
            "updated_at" => SortBy.UpdatedAt,
            _ => (SortBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, SortBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortBy.CreatedAt => "created_at",
                SortBy.PaymentDate => "payment_date",
                SortBy.EffectiveAt => "effective_at",
                SortBy.ID => "id",
                SortBy.Amount => "amount",
                SortBy.UpdatedAt => "updated_at",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
