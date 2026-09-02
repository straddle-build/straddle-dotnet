using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(
    typeof(JsonModelConverter<IdentityVerificationBreakdown, IdentityVerificationBreakdownFromRaw>)
)]
public sealed record class IdentityVerificationBreakdown : JsonModel
{
    /// <summary>
    /// List of specific result codes from the fraud and risk screening.
    /// </summary>
    public IReadOnlyList<string>? Codes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, CorrelationBucket>? Correlation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CorrelationBucket>>(
                "correlation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("correlation", value);
        }
    }

    /// <summary>
    /// Represents the strength of the correlation between provided and known
    /// information. A higher score indicates a stronger correlation.
    /// </summary>
    public double? CorrelationScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("correlation_score");
        }
        init { this._rawData.Set("correlation_score", value); }
    }

    public ApiEnum<string, VerificationDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VerificationDecision>>(
                "decision"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decision", value);
        }
    }

    /// <summary>
    /// Predicts the inherent risk associated with the customer for a given module.
    /// A higher score indicates a greater likelihood of fraud.
    /// </summary>
    public double? RiskScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("risk_score");
        }
        init { this._rawData.Set("risk_score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Codes;
        this.Correlation?.Validate();
        _ = this.CorrelationScore;
        this.Decision?.Validate();
        _ = this.RiskScore;
    }

    public IdentityVerificationBreakdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IdentityVerificationBreakdown(
        IdentityVerificationBreakdown identityVerificationBreakdown
    )
        : base(identityVerificationBreakdown) { }
#pragma warning restore CS8618

    public IdentityVerificationBreakdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityVerificationBreakdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityVerificationBreakdownFromRaw.FromRawUnchecked"/>
    public static IdentityVerificationBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityVerificationBreakdownFromRaw : IFromRawJson<IdentityVerificationBreakdown>
{
    /// <inheritdoc/>
    public IdentityVerificationBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IdentityVerificationBreakdown.FromRawUnchecked(rawData);
}
