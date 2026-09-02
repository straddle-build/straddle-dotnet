using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<PayoutConfiguration, PayoutConfigurationFromRaw>))]
public sealed record class PayoutConfiguration : JsonModel
{
    /// <summary>
    /// Whether to place the payout on hold automatically after creation.
    /// </summary>
    public bool? AutoHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_hold");
        }
        init { this._rawData.Set("auto_hold", value); }
    }

    /// <summary>
    /// Reason for placing the payout on hold automatically.
    /// </summary>
    public string? AutoHoldMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auto_hold_message");
        }
        init { this._rawData.Set("auto_hold_message", value); }
    }

    /// <summary>
    /// Payment will simulate processing if not Standard.
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
        _ = this.AutoHold;
        _ = this.AutoHoldMessage;
        this.SandboxOutcome?.Validate();
    }

    public PayoutConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayoutConfiguration(PayoutConfiguration payoutConfiguration)
        : base(payoutConfiguration) { }
#pragma warning restore CS8618

    public PayoutConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayoutConfigurationFromRaw.FromRawUnchecked"/>
    public static PayoutConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayoutConfigurationFromRaw : IFromRawJson<PayoutConfiguration>
{
    /// <inheritdoc/>
    public PayoutConfiguration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayoutConfiguration.FromRawUnchecked(rawData);
}
