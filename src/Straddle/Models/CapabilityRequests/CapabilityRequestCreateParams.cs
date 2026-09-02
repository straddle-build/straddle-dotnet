using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.CapabilityRequests;

/// <summary>
/// Creates one or more capability requests for an account and returns the resulting requests.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CapabilityRequestCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AccountID { get; init; }

    /// <summary>
    /// Request to enable or disable payments from businesses.
    /// </summary>
    public Businesses? Businesses
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Businesses>("businesses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("businesses", value);
        }
    }

    /// <summary>
    /// Requested charge capability and limits.
    /// </summary>
    public CapabilityRequestCreateParamsCharges? Charges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CapabilityRequestCreateParamsCharges>(
                "charges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("charges", value);
        }
    }

    /// <summary>
    /// Request to enable or disable payments from individuals.
    /// </summary>
    public Individuals? Individuals
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Individuals>("individuals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("individuals", value);
        }
    }

    /// <summary>
    /// Request to enable or disable internet and mobile payment authorization.
    /// </summary>
    public Internet? Internet
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Internet>("internet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("internet", value);
        }
    }

    /// <summary>
    /// Requested payout capability and limits.
    /// </summary>
    public CapabilityRequestCreateParamsPayouts? Payouts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CapabilityRequestCreateParamsPayouts>(
                "payouts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("payouts", value);
        }
    }

    /// <summary>
    /// Request to enable or disable signed-agreement payment authorization.
    /// </summary>
    public SignedAgreement? SignedAgreement
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SignedAgreement>("signed_agreement");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("signed_agreement", value);
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

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
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

    public CapabilityRequestCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequestCreateParams(
        CapabilityRequestCreateParams capabilityRequestCreateParams
    )
        : base(capabilityRequestCreateParams)
    {
        this.AccountID = capabilityRequestCreateParams.AccountID;

        this._rawBodyData = new(capabilityRequestCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CapabilityRequestCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequestCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountID = accountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CapabilityRequestCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AccountID"] = JsonSerializer.SerializeToElement(this.AccountID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CapabilityRequestCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountID?.Equals(other.AccountID) ?? other.AccountID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/{0}/capability_requests", this.AccountID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
/// Request to enable or disable payments from businesses.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Businesses, BusinessesFromRaw>))]
public sealed record class Businesses : JsonModel
{
    /// <summary>
    /// Whether the request enables or disables the capability.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
    }

    public Businesses() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Businesses(Businesses businesses)
        : base(businesses) { }
#pragma warning restore CS8618

    public Businesses(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Businesses(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessesFromRaw.FromRawUnchecked"/>
    public static Businesses FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Businesses(bool enable)
        : this()
    {
        this.Enable = enable;
    }
}

class BusinessesFromRaw : IFromRawJson<Businesses>
{
    /// <inheritdoc/>
    public Businesses FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Businesses.FromRawUnchecked(rawData);
}

/// <summary>
/// Requested charge capability and limits.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CapabilityRequestCreateParamsCharges,
        CapabilityRequestCreateParamsChargesFromRaw
    >)
)]
public sealed record class CapabilityRequestCreateParamsCharges : JsonModel
{
    /// <summary>
    /// Daily charge amount limit in cents.
    /// </summary>
    public required double DailyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("daily_amount");
        }
        init { this._rawData.Set("daily_amount", value); }
    }

    /// <summary>
    /// Whether to enable or disable charges for the account.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <summary>
    /// Maximum amount in cents for one charge.
    /// </summary>
    public required double MaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("max_amount");
        }
        init { this._rawData.Set("max_amount", value); }
    }

    /// <summary>
    /// Monthly charge amount limit in cents.
    /// </summary>
    public required double MonthlyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("monthly_amount");
        }
        init { this._rawData.Set("monthly_amount", value); }
    }

    /// <summary>
    /// Maximum number of charges per calendar month.
    /// </summary>
    public required int MonthlyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("monthly_count");
        }
        init { this._rawData.Set("monthly_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAmount;
        _ = this.Enable;
        _ = this.MaxAmount;
        _ = this.MonthlyAmount;
        _ = this.MonthlyCount;
    }

    public CapabilityRequestCreateParamsCharges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequestCreateParamsCharges(
        CapabilityRequestCreateParamsCharges capabilityRequestCreateParamsCharges
    )
        : base(capabilityRequestCreateParamsCharges) { }
#pragma warning restore CS8618

    public CapabilityRequestCreateParamsCharges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequestCreateParamsCharges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityRequestCreateParamsChargesFromRaw.FromRawUnchecked"/>
    public static CapabilityRequestCreateParamsCharges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityRequestCreateParamsChargesFromRaw
    : IFromRawJson<CapabilityRequestCreateParamsCharges>
{
    /// <inheritdoc/>
    public CapabilityRequestCreateParamsCharges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CapabilityRequestCreateParamsCharges.FromRawUnchecked(rawData);
}

/// <summary>
/// Request to enable or disable payments from individuals.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Individuals, IndividualsFromRaw>))]
public sealed record class Individuals : JsonModel
{
    /// <summary>
    /// Whether the request enables or disables the capability.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
    }

    public Individuals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Individuals(Individuals individuals)
        : base(individuals) { }
#pragma warning restore CS8618

    public Individuals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Individuals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualsFromRaw.FromRawUnchecked"/>
    public static Individuals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Individuals(bool enable)
        : this()
    {
        this.Enable = enable;
    }
}

class IndividualsFromRaw : IFromRawJson<Individuals>
{
    /// <inheritdoc/>
    public Individuals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Individuals.FromRawUnchecked(rawData);
}

/// <summary>
/// Request to enable or disable internet and mobile payment authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Internet, InternetFromRaw>))]
public sealed record class Internet : JsonModel
{
    /// <summary>
    /// Whether the request enables or disables the capability.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
    }

    public Internet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Internet(Internet internet)
        : base(internet) { }
#pragma warning restore CS8618

    public Internet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Internet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InternetFromRaw.FromRawUnchecked"/>
    public static Internet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Internet(bool enable)
        : this()
    {
        this.Enable = enable;
    }
}

class InternetFromRaw : IFromRawJson<Internet>
{
    /// <inheritdoc/>
    public Internet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Internet.FromRawUnchecked(rawData);
}

/// <summary>
/// Requested payout capability and limits.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CapabilityRequestCreateParamsPayouts,
        CapabilityRequestCreateParamsPayoutsFromRaw
    >)
)]
public sealed record class CapabilityRequestCreateParamsPayouts : JsonModel
{
    /// <summary>
    /// Daily payout amount limit in cents.
    /// </summary>
    public required double DailyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("daily_amount");
        }
        init { this._rawData.Set("daily_amount", value); }
    }

    /// <summary>
    /// Whether to enable or disable payouts for the account.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <summary>
    /// Maximum amount in cents for one payout.
    /// </summary>
    public required double MaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("max_amount");
        }
        init { this._rawData.Set("max_amount", value); }
    }

    /// <summary>
    /// Monthly payout amount limit in cents.
    /// </summary>
    public required double MonthlyAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("monthly_amount");
        }
        init { this._rawData.Set("monthly_amount", value); }
    }

    /// <summary>
    /// Maximum number of payouts per calendar month.
    /// </summary>
    public required int MonthlyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("monthly_count");
        }
        init { this._rawData.Set("monthly_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAmount;
        _ = this.Enable;
        _ = this.MaxAmount;
        _ = this.MonthlyAmount;
        _ = this.MonthlyCount;
    }

    public CapabilityRequestCreateParamsPayouts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequestCreateParamsPayouts(
        CapabilityRequestCreateParamsPayouts capabilityRequestCreateParamsPayouts
    )
        : base(capabilityRequestCreateParamsPayouts) { }
#pragma warning restore CS8618

    public CapabilityRequestCreateParamsPayouts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequestCreateParamsPayouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityRequestCreateParamsPayoutsFromRaw.FromRawUnchecked"/>
    public static CapabilityRequestCreateParamsPayouts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityRequestCreateParamsPayoutsFromRaw
    : IFromRawJson<CapabilityRequestCreateParamsPayouts>
{
    /// <inheritdoc/>
    public CapabilityRequestCreateParamsPayouts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CapabilityRequestCreateParamsPayouts.FromRawUnchecked(rawData);
}

/// <summary>
/// Request to enable or disable signed-agreement payment authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SignedAgreement, SignedAgreementFromRaw>))]
public sealed record class SignedAgreement : JsonModel
{
    /// <summary>
    /// Whether the request enables or disables the capability.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
    }

    public SignedAgreement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SignedAgreement(SignedAgreement signedAgreement)
        : base(signedAgreement) { }
#pragma warning restore CS8618

    public SignedAgreement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SignedAgreement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SignedAgreementFromRaw.FromRawUnchecked"/>
    public static SignedAgreement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SignedAgreement(bool enable)
        : this()
    {
        this.Enable = enable;
    }
}

class SignedAgreementFromRaw : IFromRawJson<SignedAgreement>
{
    /// <inheritdoc/>
    public SignedAgreement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SignedAgreement.FromRawUnchecked(rawData);
}
