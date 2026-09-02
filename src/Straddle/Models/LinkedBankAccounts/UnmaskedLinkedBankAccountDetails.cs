using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(
    typeof(JsonModelConverter<
        UnmaskedLinkedBankAccountDetails,
        UnmaskedLinkedBankAccountDetailsFromRaw
    >)
)]
public sealed record class UnmaskedLinkedBankAccountDetails : JsonModel
{
    /// <summary>
    /// Name of the account holder as it appears on the bank account.
    /// </summary>
    public required string AccountHolder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_holder");
        }
        init { this._rawData.Set("account_holder", value); }
    }

    /// <summary>
    /// Bank account number.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// Name of the financial institution.
    /// </summary>
    public required string InstitutionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("institution_name");
        }
        init { this._rawData.Set("institution_name", value); }
    }

    /// <summary>
    /// Nine-digit ABA routing number for the bank account.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountHolder;
        _ = this.AccountNumber;
        _ = this.InstitutionName;
        _ = this.RoutingNumber;
    }

    public UnmaskedLinkedBankAccountDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedLinkedBankAccountDetails(
        UnmaskedLinkedBankAccountDetails unmaskedLinkedBankAccountDetails
    )
        : base(unmaskedLinkedBankAccountDetails) { }
#pragma warning restore CS8618

    public UnmaskedLinkedBankAccountDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedLinkedBankAccountDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedLinkedBankAccountDetailsFromRaw.FromRawUnchecked"/>
    public static UnmaskedLinkedBankAccountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedLinkedBankAccountDetailsFromRaw : IFromRawJson<UnmaskedLinkedBankAccountDetails>
{
    /// <inheritdoc/>
    public UnmaskedLinkedBankAccountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedLinkedBankAccountDetails.FromRawUnchecked(rawData);
}
