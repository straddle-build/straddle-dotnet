using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Charges;

namespace Straddle.Models.FundingEvents;

[JsonConverter(
    typeof(JsonModelConverter<FundingEventConfiguration, FundingEventConfigurationFromRaw>)
)]
public sealed record class FundingEventConfiguration : JsonModel
{
    /// <summary>
    /// Processing outcome configured for this simulated funding event.
    /// </summary>
    public ApiEnum<string, SimulatedPaymentOutcome>? SandboxOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimulatedPaymentOutcome>>(
                "sandbox_outcome"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sandbox_outcome", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SandboxOutcome?.Validate();
    }

    public FundingEventConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingEventConfiguration(FundingEventConfiguration fundingEventConfiguration)
        : base(fundingEventConfiguration) { }
#pragma warning restore CS8618

    public FundingEventConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingEventConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingEventConfigurationFromRaw.FromRawUnchecked"/>
    public static FundingEventConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FundingEventConfigurationFromRaw : IFromRawJson<FundingEventConfiguration>
{
    /// <inheritdoc/>
    public FundingEventConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FundingEventConfiguration.FromRawUnchecked(rawData);
}
