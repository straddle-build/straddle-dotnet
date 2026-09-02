using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.FundingEvents;

[JsonConverter(
    typeof(JsonModelConverter<FundingEventSimulationResult, FundingEventSimulationResultFromRaw>)
)]
public sealed record class FundingEventSimulationResult : JsonModel
{
    /// <summary>
    /// Unique identifier for the created funding event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public FundingEventSimulationResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventSimulationResult(FundingEventSimulationResult fundingEventSimulationResult)
        : base(fundingEventSimulationResult) { }
#pragma warning restore CS8618

    public FundingEventSimulationResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventSimulationResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventSimulationResultFromRaw.FromRawUnchecked"/>
    public static FundingEventSimulationResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FundingEventSimulationResult(string id)
        : this()
    {
        this.ID = id;
    }
}

class FundingEventSimulationResultFromRaw : IFromRawJson<FundingEventSimulationResult>
{
    /// <inheritdoc/>
    public FundingEventSimulationResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventSimulationResult.FromRawUnchecked(rawData);
}
