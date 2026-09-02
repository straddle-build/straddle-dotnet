using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerConfiguration, CustomerConfigurationFromRaw>))]
public sealed record class CustomerConfiguration : JsonModel
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

    public ApiEnum<string, SimulatedCustomerOutcome>? SandboxOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimulatedCustomerOutcome>>(
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

    public CustomerConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerConfiguration(CustomerConfiguration customerConfiguration)
        : base(customerConfiguration) { }
#pragma warning restore CS8618

    public CustomerConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerConfigurationFromRaw.FromRawUnchecked"/>
    public static CustomerConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerConfigurationFromRaw : IFromRawJson<CustomerConfiguration>
{
    /// <inheritdoc/>
    public CustomerConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerConfiguration.FromRawUnchecked(rawData);
}
