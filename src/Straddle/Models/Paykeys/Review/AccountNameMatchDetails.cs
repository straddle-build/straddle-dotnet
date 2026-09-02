using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(typeof(JsonModelConverter<AccountNameMatchDetails, AccountNameMatchDetailsFromRaw>))]
public sealed record class AccountNameMatchDetails : JsonModel
{
    /// <summary>
    /// Result codes returned by the name-match check.
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
    /// Strength of the match between the customer name and account-holder names.
    /// </summary>
    public double? CorrelationScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("correlation_score");
        }
        init { this._rawData.Set("correlation_score", value); }
    }

    /// <summary>
    /// Customer name evaluated during account verification.
    /// </summary>
    public string? CustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_name");
        }
        init { this._rawData.Set("customer_name", value); }
    }

    /// <summary>
    /// Account-holder name that matched the customer record.
    /// </summary>
    public string? MatchedName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("matched_name");
        }
        init { this._rawData.Set("matched_name", value); }
    }

    /// <summary>
    /// Account-holder names returned by the financial institution.
    /// </summary>
    public IReadOnlyList<string>? NamesOnAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("names_on_account");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "names_on_account",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Reason for the name-match decision.
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
        _ = this.CorrelationScore;
        _ = this.CustomerName;
        _ = this.MatchedName;
        _ = this.NamesOnAccount;
        _ = this.Reason;
    }

    public AccountNameMatchDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNameMatchDetails(AccountNameMatchDetails accountNameMatchDetails)
        : base(accountNameMatchDetails) { }
#pragma warning restore CS8618

    public AccountNameMatchDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNameMatchDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNameMatchDetailsFromRaw.FromRawUnchecked"/>
    public static AccountNameMatchDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountNameMatchDetailsFromRaw : IFromRawJson<AccountNameMatchDetails>
{
    /// <inheritdoc/>
    public AccountNameMatchDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNameMatchDetails.FromRawUnchecked(rawData);
}
