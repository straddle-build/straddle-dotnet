using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(
    typeof(JsonModelConverter<IdentityVerificationAlerts, IdentityVerificationAlertsFromRaw>)
)]
public sealed record class IdentityVerificationAlerts : JsonModel
{
    /// <summary>
    /// Any alerts or flags raised during the consortium alert screening.
    /// </summary>
    public IReadOnlyList<string>? Alerts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("alerts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "alerts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of specific result codes from the consortium alert screening.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alerts;
        _ = this.Codes;
        this.Decision?.Validate();
    }

    public IdentityVerificationAlerts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IdentityVerificationAlerts(IdentityVerificationAlerts identityVerificationAlerts)
        : base(identityVerificationAlerts) { }
#pragma warning restore CS8618

    public IdentityVerificationAlerts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityVerificationAlerts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityVerificationAlertsFromRaw.FromRawUnchecked"/>
    public static IdentityVerificationAlerts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityVerificationAlertsFromRaw : IFromRawJson<IdentityVerificationAlerts>
{
    /// <inheritdoc/>
    public IdentityVerificationAlerts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IdentityVerificationAlerts.FromRawUnchecked(rawData);
}
