using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<ChargeConfiguration, ChargeConfigurationFromRaw>))]
public sealed record class ChargeConfiguration : JsonModel
{
    /// <summary>
    /// Balance check mode to use before processing the charge.
    /// </summary>
    public required ApiEnum<string, BalanceCheckMode> BalanceCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BalanceCheckMode>>(
                "balance_check"
            );
        }
        init { this._rawData.Set("balance_check", value); }
    }

    /// <summary>
    /// Whether to place the charge on hold automatically after creation.
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
    /// Reason for placing the charge on hold automatically.
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
        this.BalanceCheck.Validate();
        _ = this.AutoHold;
        _ = this.AutoHoldMessage;
        this.SandboxOutcome?.Validate();
    }

    public ChargeConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeConfiguration(ChargeConfiguration chargeConfiguration)
        : base(chargeConfiguration) { }
#pragma warning restore CS8618

    public ChargeConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeConfigurationFromRaw.FromRawUnchecked"/>
    public static ChargeConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChargeConfiguration(ApiEnum<string, BalanceCheckMode> balanceCheck)
        : this()
    {
        this.BalanceCheck = balanceCheck;
    }
}

class ChargeConfigurationFromRaw : IFromRawJson<ChargeConfiguration>
{
    /// <inheritdoc/>
    public ChargeConfiguration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargeConfiguration.FromRawUnchecked(rawData);
}
