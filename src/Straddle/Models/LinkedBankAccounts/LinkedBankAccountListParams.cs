using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.LinkedBankAccounts;

/// <summary>
/// Returns a paginated list of linked bank accounts. Filter the list by account,
/// scope, purpose, or status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LinkedBankAccountListParams : ParamsBase
{
    /// <summary>
    /// Account ID used to filter the results.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Scope of linked bank accounts to return.
    /// </summary>
    public ApiEnum<string, Level>? Level
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Level>>("level");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("level", value);
        }
    }

    /// <summary>
    /// Page number. Defaults to `1`.
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
    /// Number of results per page. Defaults to `100`. Maximum `1000`.
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
    /// Linked bank account purpose. Accepted values are `charges`, `payouts`, and `billing`.
    /// </summary>
    public ApiEnum<string, LinkedBankAccountListParamsPurpose>? Purpose
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, LinkedBankAccountListParamsPurpose>
            >("purpose");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("purpose", value);
        }
    }

    /// <summary>
    /// Field used to sort results. Defaults to `id`.
    /// </summary>
    public string? SortBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sort_by");
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
    /// Sort direction. Defaults to `asc`.
    /// </summary>
    public ApiEnum<string, SortOrder>? SortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortOrder>>("sort_order");
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
    /// Linked bank account status. Accepted values are `created`, `onboarding`,
    /// `active`, `rejected`, `inactive`, and `canceled`.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
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

    public LinkedBankAccountListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountListParams(LinkedBankAccountListParams linkedBankAccountListParams)
        : base(linkedBankAccountListParams) { }
#pragma warning restore CS8618

    public LinkedBankAccountListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LinkedBankAccountListParams FromRawUnchecked(
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

    public virtual bool Equals(LinkedBankAccountListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/linked_bank_accounts")
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
/// Scope of linked bank accounts to return.
/// </summary>
[JsonConverter(typeof(LevelConverter))]
public enum Level
{
    Account,
    Platform,
}

sealed class LevelConverter : JsonConverter<Level>
{
    public override Level Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => Level.Account,
            "platform" => Level.Platform,
            _ => (Level)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Level.Account => "account",
                Level.Platform => "platform",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Linked bank account purpose. Accepted values are `charges`, `payouts`, and `billing`.
/// </summary>
[JsonConverter(typeof(LinkedBankAccountListParamsPurposeConverter))]
public enum LinkedBankAccountListParamsPurpose
{
    Charges,
    Payouts,
    Billing,
}

sealed class LinkedBankAccountListParamsPurposeConverter
    : JsonConverter<LinkedBankAccountListParamsPurpose>
{
    public override LinkedBankAccountListParamsPurpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charges" => LinkedBankAccountListParamsPurpose.Charges,
            "payouts" => LinkedBankAccountListParamsPurpose.Payouts,
            "billing" => LinkedBankAccountListParamsPurpose.Billing,
            _ => (LinkedBankAccountListParamsPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LinkedBankAccountListParamsPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LinkedBankAccountListParamsPurpose.Charges => "charges",
                LinkedBankAccountListParamsPurpose.Payouts => "payouts",
                LinkedBankAccountListParamsPurpose.Billing => "billing",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort direction. Defaults to `asc`.
/// </summary>
[JsonConverter(typeof(SortOrderConverter))]
public enum SortOrder
{
    Asc,
    Desc,
}

sealed class SortOrderConverter : JsonConverter<SortOrder>
{
    public override SortOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => (SortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortOrder.Asc => "asc",
                SortOrder.Desc => "desc",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Linked bank account status. Accepted values are `created`, `onboarding`,
/// `active`, `rejected`, `inactive`, and `canceled`.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
    Canceled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => Status.Created,
            "onboarding" => Status.Onboarding,
            "active" => Status.Active,
            "rejected" => Status.Rejected,
            "inactive" => Status.Inactive,
            "canceled" => Status.Canceled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Created => "created",
                Status.Onboarding => "onboarding",
                Status.Active => "active",
                Status.Rejected => "rejected",
                Status.Inactive => "inactive",
                Status.Canceled => "canceled",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
