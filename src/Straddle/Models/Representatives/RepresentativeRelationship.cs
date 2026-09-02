using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Representatives;

[JsonConverter(
    typeof(JsonModelConverter<RepresentativeRelationship, RepresentativeRelationshipFromRaw>)
)]
public sealed record class RepresentativeRelationship : JsonModel
{
    /// <summary>
    /// Whether the representative controls, manages, or directs the business. Each
    /// legal entity must have one representative with `control` set to `true`.
    /// </summary>
    public required bool Control
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("control");
        }
        init { this._rawData.Set("control", value); }
    }

    /// <summary>
    /// Whether the representative owns any equity in the business.
    /// </summary>
    public required bool Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("owner");
        }
        init { this._rawData.Set("owner", value); }
    }

    /// <summary>
    /// Whether this person is the account's primary representative. The primary
    /// representative provides personal and business information and accepts the
    /// services agreement. An account can have only one primary representative.
    /// </summary>
    public required bool Primary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("primary");
        }
        init { this._rawData.Set("primary", value); }
    }

    /// <summary>
    /// The representative's ownership percentage. Required when `owner` is `true`.
    /// </summary>
    public double? PercentOwnership
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percent_ownership");
        }
        init { this._rawData.Set("percent_ownership", value); }
    }

    /// <summary>
    /// The representative's job title.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Control;
        _ = this.Owner;
        _ = this.Primary;
        _ = this.PercentOwnership;
        _ = this.Title;
    }

    public RepresentativeRelationship() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeRelationship(RepresentativeRelationship representativeRelationship)
        : base(representativeRelationship) { }
#pragma warning restore CS8618

    public RepresentativeRelationship(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeRelationship(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeRelationshipFromRaw.FromRawUnchecked"/>
    public static RepresentativeRelationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeRelationshipFromRaw : IFromRawJson<RepresentativeRelationship>
{
    /// <inheritdoc/>
    public RepresentativeRelationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentativeRelationship.FromRawUnchecked(rawData);
}
