using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<MaskedCustomerDevice, MaskedCustomerDeviceFromRaw>))]
public sealed record class MaskedCustomerDevice : JsonModel
{
    /// <summary>
    /// Masked IP address of the customer's device at the time of profile creation.
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

    public MaskedCustomerDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaskedCustomerDevice(MaskedCustomerDevice maskedCustomerDevice)
        : base(maskedCustomerDevice) { }
#pragma warning restore CS8618

    public MaskedCustomerDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaskedCustomerDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaskedCustomerDeviceFromRaw.FromRawUnchecked"/>
    public static MaskedCustomerDevice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MaskedCustomerDevice(string ipAddress)
        : this()
    {
        this.IPAddress = ipAddress;
    }
}

class MaskedCustomerDeviceFromRaw : IFromRawJson<MaskedCustomerDevice>
{
    /// <inheritdoc/>
    public MaskedCustomerDevice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaskedCustomerDevice.FromRawUnchecked(rawData);
}
