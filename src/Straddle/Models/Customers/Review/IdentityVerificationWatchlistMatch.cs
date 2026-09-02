using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(
    typeof(JsonModelConverter<
        IdentityVerificationWatchlistMatch,
        IdentityVerificationWatchlistMatchFromRaw
    >)
)]
public sealed record class IdentityVerificationWatchlistMatch : JsonModel
{
    public required ApiEnum<string, CorrelationBucket> Correlation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CorrelationBucket>>("correlation");
        }
        init { this._rawData.Set("correlation", value); }
    }

    /// <summary>
    /// Name of the watchlist that contains the matching record.
    /// </summary>
    public required string ListName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("list_name");
        }
        init { this._rawData.Set("list_name", value); }
    }

    /// <summary>
    /// Customer fields that match the watchlist record.
    /// </summary>
    public required IReadOnlyList<string> MatchFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("match_fields");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "match_fields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Source URLs associated with the match.
    /// </summary>
    public required IReadOnlyList<string> Urls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("urls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "urls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Correlation.Validate();
        _ = this.ListName;
        _ = this.MatchFields;
        _ = this.Urls;
    }

    public IdentityVerificationWatchlistMatch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IdentityVerificationWatchlistMatch(
        IdentityVerificationWatchlistMatch identityVerificationWatchlistMatch
    )
        : base(identityVerificationWatchlistMatch) { }
#pragma warning restore CS8618

    public IdentityVerificationWatchlistMatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityVerificationWatchlistMatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityVerificationWatchlistMatchFromRaw.FromRawUnchecked"/>
    public static IdentityVerificationWatchlistMatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityVerificationWatchlistMatchFromRaw : IFromRawJson<IdentityVerificationWatchlistMatch>
{
    /// <inheritdoc/>
    public IdentityVerificationWatchlistMatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IdentityVerificationWatchlistMatch.FromRawUnchecked(rawData);
}
