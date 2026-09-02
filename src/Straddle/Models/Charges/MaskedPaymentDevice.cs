using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(typeof(JsonModelConverter<MaskedPaymentDevice, MaskedPaymentDeviceFromRaw>))]
public sealed record class MaskedPaymentDevice : JsonModel
{
    /// <summary>
    /// Masked IP address of the device used when the customer authorized the charge or payout.
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

    public MaskedPaymentDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaskedPaymentDevice(MaskedPaymentDevice maskedPaymentDevice)
        : base(maskedPaymentDevice) { }
#pragma warning restore CS8618

    public MaskedPaymentDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaskedPaymentDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaskedPaymentDeviceFromRaw.FromRawUnchecked"/>
    public static MaskedPaymentDevice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MaskedPaymentDevice(string ipAddress)
        : this()
    {
        this.IPAddress = ipAddress;
    }
}

class MaskedPaymentDeviceFromRaw : IFromRawJson<MaskedPaymentDevice>
{
    /// <inheritdoc/>
    public MaskedPaymentDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MaskedPaymentDevice.FromRawUnchecked(rawData);
}
