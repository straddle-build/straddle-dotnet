using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<PaymentDevice, PaymentDeviceFromRaw>))]
public sealed record class PaymentDevice : JsonModel
{
    /// <summary>
    /// The IP address of the device used when the customer authorized the charge or
    /// payout. Use `0.0.0.0` to represent an offline consent interaction.
    /// </summary>
    public required string IPAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ip_address");
        }
        init { this._rawData.Set("ip_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IPAddress;
    }

    public PaymentDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentDevice(PaymentDevice paymentDevice)
        : base(paymentDevice) { }
#pragma warning restore CS8618

    public PaymentDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentDeviceFromRaw.FromRawUnchecked"/>
    public static PaymentDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaymentDevice(string ipAddress)
        : this()
    {
        this.IPAddress = ipAddress;
    }
}

class PaymentDeviceFromRaw : IFromRawJson<PaymentDevice>
{
    /// <inheritdoc/>
    public PaymentDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentDevice.FromRawUnchecked(rawData);
}
