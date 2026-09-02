using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Models.Paykeys;

[JsonConverter(
    typeof(JsonModelConverter<UnmaskedPaykeyBankDetails, UnmaskedPaykeyBankDetailsFromRaw>)
)]
public sealed record class UnmaskedPaykeyBankDetails : JsonModel
{
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

    public required ApiEnum<string, AccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountType>>("account_type");
        }
        init { this._rawData.Set("account_type", value); }
    }

    /// <summary>
    /// Bank routing number.
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
        _ = this.AccountNumber;
        this.AccountType.Validate();
        _ = this.RoutingNumber;
    }

    public UnmaskedPaykeyBankDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedPaykeyBankDetails(UnmaskedPaykeyBankDetails unmaskedPaykeyBankDetails)
        : base(unmaskedPaykeyBankDetails) { }
#pragma warning restore CS8618

    public UnmaskedPaykeyBankDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedPaykeyBankDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedPaykeyBankDetailsFromRaw.FromRawUnchecked"/>
    public static UnmaskedPaykeyBankDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedPaykeyBankDetailsFromRaw : IFromRawJson<UnmaskedPaykeyBankDetails>
{
    /// <inheritdoc/>
    public UnmaskedPaykeyBankDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedPaykeyBankDetails.FromRawUnchecked(rawData);
}
