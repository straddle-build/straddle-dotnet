using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(
    typeof(JsonModelConverter<
        MaskedLinkedBankAccountDetails,
        MaskedLinkedBankAccountDetailsFromRaw
    >)
)]
public sealed record class MaskedLinkedBankAccountDetails : JsonModel
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
    /// Last four digits of the bank account number.
    /// </summary>
    public required string AccountMask
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_mask");
        }
        init { this._rawData.Set("account_mask", value); }
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
        _ = this.AccountMask;
        _ = this.InstitutionName;
        _ = this.RoutingNumber;
    }

    public MaskedLinkedBankAccountDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaskedLinkedBankAccountDetails(
        MaskedLinkedBankAccountDetails maskedLinkedBankAccountDetails
    )
        : base(maskedLinkedBankAccountDetails) { }
#pragma warning restore CS8618

    public MaskedLinkedBankAccountDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaskedLinkedBankAccountDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaskedLinkedBankAccountDetailsFromRaw.FromRawUnchecked"/>
    public static MaskedLinkedBankAccountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaskedLinkedBankAccountDetailsFromRaw : IFromRawJson<MaskedLinkedBankAccountDetails>
{
    /// <inheritdoc/>
    public MaskedLinkedBankAccountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaskedLinkedBankAccountDetails.FromRawUnchecked(rawData);
}
