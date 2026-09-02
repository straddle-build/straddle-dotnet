using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(JsonModelConverter<ReputationCheck, ReputationCheckFromRaw>))]
public sealed record class ReputationCheck : JsonModel
{
    /// <summary>
    /// Specific codes related to the Straddle reputation screening results.
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

    public ReputationInsights? Insights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReputationInsights>("insights");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("insights", value);
        }
    }

    /// <summary>
    /// Risk score produced by the reputation check.
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
        this.Decision?.Validate();
        this.Insights?.Validate();
        _ = this.RiskScore;
    }

    public ReputationCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationCheck(ReputationCheck reputationCheck)
        : base(reputationCheck) { }
#pragma warning restore CS8618

    public ReputationCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReputationCheckFromRaw.FromRawUnchecked"/>
    public static ReputationCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReputationCheckFromRaw : IFromRawJson<ReputationCheck>
{
    /// <inheritdoc/>
    public ReputationCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReputationCheck.FromRawUnchecked(rawData);
}
