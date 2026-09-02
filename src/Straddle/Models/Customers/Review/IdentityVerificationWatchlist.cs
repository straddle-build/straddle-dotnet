using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(
    typeof(JsonModelConverter<IdentityVerificationWatchlist, IdentityVerificationWatchlistFromRaw>)
)]
public sealed record class IdentityVerificationWatchlist : JsonModel
{
    /// <summary>
    /// Result codes from Straddle watchlist screening.
    /// </summary>
    public IReadOnlyList<string>? Codes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, VerificationDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VerificationDecision>>(
                "decision"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decision", value);
        }
    }

    /// <summary>
    /// Names of watchlists with matches.
    /// </summary>
    public IReadOnlyList<string>? Matched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("matched");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "matched",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Details for matches found during watchlist screening.
    /// </summary>
    public IReadOnlyList<IdentityVerificationWatchlistMatch>? Matches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<IdentityVerificationWatchlistMatch>
            >("matches");
        }
        init
        {
            this._rawData.Set<ImmutableArray<IdentityVerificationWatchlistMatch>?>(
                "matches",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Codes;
        this.Decision?.Validate();
        _ = this.Matched;
        foreach (var item in this.Matches ?? [])
        {
            item.Validate();
        }
    }

    public IdentityVerificationWatchlist() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IdentityVerificationWatchlist(
        IdentityVerificationWatchlist identityVerificationWatchlist
    )
        : base(identityVerificationWatchlist) { }
#pragma warning restore CS8618

    public IdentityVerificationWatchlist(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityVerificationWatchlist(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityVerificationWatchlistFromRaw.FromRawUnchecked"/>
    public static IdentityVerificationWatchlist FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityVerificationWatchlistFromRaw : IFromRawJson<IdentityVerificationWatchlist>
{
    /// <inheritdoc/>
    public IdentityVerificationWatchlist FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IdentityVerificationWatchlist.FromRawUnchecked(rawData);
}
