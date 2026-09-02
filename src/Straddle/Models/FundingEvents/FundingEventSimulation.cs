using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Accounts;

namespace Straddle.Models.FundingEvents;

[JsonConverter(typeof(JsonModelConverter<FundingEventSimulation, FundingEventSimulationFromRaw>))]
public sealed record class FundingEventSimulation : JsonModel
{
    public required FundingEventSimulationResult Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FundingEventSimulationResult>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Metadata for an API request.
    /// </summary>
    public required ResponseMetadata Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ResponseMetadata>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <summary>
    /// Shape of the response envelope.
    /// - `object` means `data` contains one JSON object.
    /// - `array` means `data` contains an array of JSON objects.
    /// - `error` means `error` contains the error details.
    /// - `none` means the response contains no data.
    /// </summary>
    public required ApiEnum<string, global::Straddle.Models.Bridge.ResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Bridge.ResponseType>
            >("response_type");
        }
        init { this._rawData.Set("response_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Meta.Validate();
        this.ResponseType.Validate();
    }

    public FundingEventSimulation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventSimulation(FundingEventSimulation fundingEventSimulation)
        : base(fundingEventSimulation) { }
#pragma warning restore CS8618

    public FundingEventSimulation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventSimulation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventSimulationFromRaw.FromRawUnchecked"/>
    public static FundingEventSimulation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventSimulationFromRaw : IFromRawJson<FundingEventSimulation>
{
    /// <inheritdoc/>
    public FundingEventSimulation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventSimulation.FromRawUnchecked(rawData);
}
