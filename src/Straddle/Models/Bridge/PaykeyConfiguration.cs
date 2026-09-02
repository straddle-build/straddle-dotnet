using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(JsonModelConverter<PaykeyConfiguration, PaykeyConfigurationFromRaw>))]
public sealed record class PaykeyConfiguration : JsonModel
{
    public ApiEnum<string, PaykeyProcessingMode>? ProcessingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaykeyProcessingMode>>(
                "processing_method"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("processing_method", value);
        }
    }

    public ApiEnum<string, SimulatedPaykeyOutcome>? SandboxOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimulatedPaykeyOutcome>>(
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
        this.ProcessingMethod?.Validate();
        this.SandboxOutcome?.Validate();
    }

    public PaykeyConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyConfiguration(PaykeyConfiguration paykeyConfiguration)
        : base(paykeyConfiguration) { }
#pragma warning restore CS8618

    public PaykeyConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyConfigurationFromRaw.FromRawUnchecked"/>
    public static PaykeyConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyConfigurationFromRaw : IFromRawJson<PaykeyConfiguration>
{
    /// <inheritdoc/>
    public PaykeyConfiguration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaykeyConfiguration.FromRawUnchecked(rawData);
}
