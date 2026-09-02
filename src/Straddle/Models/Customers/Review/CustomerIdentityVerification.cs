using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(
    typeof(JsonModelConverter<CustomerIdentityVerification, CustomerIdentityVerificationFromRaw>)
)]
public sealed record class CustomerIdentityVerification : JsonModel
{
    /// <summary>
    /// Results for each customer verification check, including decisions, risk
    /// scores, and correlation scores.
    /// </summary>
    public required Breakdown Breakdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Breakdown>("breakdown");
        }
        init { this._rawData.Set("breakdown", value); }
    }

    /// <summary>
    /// Timestamp of when the review was initiated.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, VerificationDecision> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerificationDecision>>("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// Unique identifier for the review.
    /// </summary>
    public required string ReviewID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("review_id");
        }
        init { this._rawData.Set("review_id", value); }
    }

    /// <summary>
    /// Timestamp of the most recent update to the review.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public CustomerKycVerification? Kyc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerKycVerification>("kyc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kyc", value);
        }
    }

    /// <summary>
    /// Messages returned by the customer verification process.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("messages");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "messages",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IdentityVerificationAlerts? NetworkAlerts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationAlerts>("network_alerts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("network_alerts", value);
        }
    }

    public ReputationCheck? Reputation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReputationCheck>("reputation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reputation", value);
        }
    }

    public IdentityVerificationWatchlist? WatchList
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationWatchlist>("watch_list");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("watch_list", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Breakdown.Validate();
        _ = this.CreatedAt;
        this.Decision.Validate();
        _ = this.ReviewID;
        _ = this.UpdatedAt;
        this.Kyc?.Validate();
        _ = this.Messages;
        this.NetworkAlerts?.Validate();
        this.Reputation?.Validate();
        this.WatchList?.Validate();
    }

    public CustomerIdentityVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerIdentityVerification(CustomerIdentityVerification customerIdentityVerification)
        : base(customerIdentityVerification) { }
#pragma warning restore CS8618

    public CustomerIdentityVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerIdentityVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerIdentityVerificationFromRaw.FromRawUnchecked"/>
    public static CustomerIdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerIdentityVerificationFromRaw : IFromRawJson<CustomerIdentityVerification>
{
    /// <inheritdoc/>
    public CustomerIdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerIdentityVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Results for each customer verification check, including decisions, risk scores,
/// and correlation scores.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Breakdown, BreakdownFromRaw>))]
public sealed record class Breakdown : JsonModel
{
    public IdentityVerificationBreakdown? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public IdentityVerificationBreakdown? BusinessEvaluation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>(
                "business_evaluation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business_evaluation", value);
        }
    }

    public IdentityVerificationBreakdown? BusinessIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>(
                "business_identification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business_identification", value);
        }
    }

    public IdentityVerificationBreakdown? BusinessValidation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>(
                "business_validation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business_validation", value);
        }
    }

    public IdentityVerificationBreakdown? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    public IdentityVerificationBreakdown? Fraud
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>("fraud");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fraud", value);
        }
    }

    public IdentityVerificationBreakdown? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public IdentityVerificationBreakdown? Synthetic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerificationBreakdown>("synthetic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("synthetic", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        this.BusinessEvaluation?.Validate();
        this.BusinessIdentification?.Validate();
        this.BusinessValidation?.Validate();
        this.Email?.Validate();
        this.Fraud?.Validate();
        this.Phone?.Validate();
        this.Synthetic?.Validate();
    }

    public Breakdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Breakdown(Breakdown breakdown)
        : base(breakdown) { }
#pragma warning restore CS8618

    public Breakdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Breakdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BreakdownFromRaw.FromRawUnchecked"/>
    public static Breakdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BreakdownFromRaw : IFromRawJson<Breakdown>
{
    /// <inheritdoc/>
    public Breakdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Breakdown.FromRawUnchecked(rawData);
}
