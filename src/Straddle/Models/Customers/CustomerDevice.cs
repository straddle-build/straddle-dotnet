using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerDevice, CustomerDeviceFromRaw>))]
public sealed record class CustomerDevice : JsonModel
{
    /// <summary>
    /// Customer IP address at profile creation. `0.0.0.0` represents an offline registration.
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

    public CustomerDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerDevice(CustomerDevice customerDevice)
        : base(customerDevice) { }
#pragma warning restore CS8618

    public CustomerDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerDeviceFromRaw.FromRawUnchecked"/>
    public static CustomerDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerDevice(string ipAddress)
        : this()
    {
        this.IPAddress = ipAddress;
    }
}

class CustomerDeviceFromRaw : IFromRawJson<CustomerDevice>
{
    /// <inheritdoc/>
    public CustomerDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerDevice.FromRawUnchecked(rawData);
}
