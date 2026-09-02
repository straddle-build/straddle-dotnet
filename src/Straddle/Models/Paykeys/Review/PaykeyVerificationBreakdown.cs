using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Paykeys.Review;

[JsonConverter(
    typeof(JsonModelConverter<PaykeyVerificationBreakdown, PaykeyVerificationBreakdownFromRaw>)
)]
public sealed record class PaykeyVerificationBreakdown : JsonModel
{
    public AccountValidationDetails? AccountValidation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountValidationDetails>("account_validation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_validation", value);
        }
    }

    public AccountNameMatchDetails? NameMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountNameMatchDetails>("name_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name_match", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccountValidation?.Validate();
        this.NameMatch?.Validate();
    }

    public PaykeyVerificationBreakdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaykeyVerificationBreakdown(PaykeyVerificationBreakdown paykeyVerificationBreakdown)
        : base(paykeyVerificationBreakdown) { }
#pragma warning restore CS8618

    public PaykeyVerificationBreakdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaykeyVerificationBreakdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaykeyVerificationBreakdownFromRaw.FromRawUnchecked"/>
    public static PaykeyVerificationBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaykeyVerificationBreakdownFromRaw : IFromRawJson<PaykeyVerificationBreakdown>
{
    /// <inheritdoc/>
    public PaykeyVerificationBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaykeyVerificationBreakdown.FromRawUnchecked(rawData);
}
