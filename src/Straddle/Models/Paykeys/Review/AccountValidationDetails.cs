using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(
    typeof(JsonModelConverter<AccountValidationDetails, AccountValidationDetailsFromRaw>)
)]
public sealed record class AccountValidationDetails : JsonModel
{
    /// <summary>
    /// Result codes returned by the account-validation check.
    /// </summary>
    public required IReadOnlyList<string> Codes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "codes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, PaykeyVerificationResult> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaykeyVerificationResult>>(
                "decision"
            );
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// Reason for the account-validation decision.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Codes;
        this.Decision.Validate();
        _ = this.Reason;
    }

    public AccountValidationDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountValidationDetails(AccountValidationDetails accountValidationDetails)
        : base(accountValidationDetails) { }
#pragma warning restore CS8618

    public AccountValidationDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountValidationDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountValidationDetailsFromRaw.FromRawUnchecked"/>
    public static AccountValidationDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountValidationDetailsFromRaw : IFromRawJson<AccountValidationDetails>
{
    /// <inheritdoc/>
    public AccountValidationDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountValidationDetails.FromRawUnchecked(rawData);
}
