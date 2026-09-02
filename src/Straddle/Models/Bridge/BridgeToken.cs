using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Bridge;

[JsonConverter(typeof(JsonModelConverter<BridgeToken, BridgeTokenFromRaw>))]
public sealed record class BridgeToken : JsonModel
{
    /// <summary>
    /// JSON Web Token (JWT) for the Bridge widget.
    /// </summary>
    public required string BridgeTokenValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bridge_token");
        }
        init { this._rawData.Set("bridge_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BridgeTokenValue;
    }

    public BridgeToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BridgeToken(BridgeToken bridgeToken)
        : base(bridgeToken) { }
#pragma warning restore CS8618

    public BridgeToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BridgeToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BridgeTokenFromRaw.FromRawUnchecked"/>
    public static BridgeToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BridgeToken(string bridgeTokenValue)
        : this()
    {
        this.BridgeTokenValue = bridgeTokenValue;
    }
}

class BridgeTokenFromRaw : IFromRawJson<BridgeToken>
{
    /// <inheritdoc/>
    public BridgeToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BridgeToken.FromRawUnchecked(rawData);
}
