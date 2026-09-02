using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.AccountSettings;

[JsonConverter(typeof(JsonModelConverter<AccountPolicyControls, AccountPolicyControlsFromRaw>))]
public sealed record class AccountPolicyControls : JsonModel
{
    /// <summary>
    /// Whether customer identity verification can be skipped.
    /// </summary>
    public required bool AllowCustomerIdentitySkip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_customer_identity_skip");
        }
        init { this._rawData.Set("allow_customer_identity_skip", value); }
    }

    /// <summary>
    /// Whether the account can retrieve unmasked sensitive fields.
    /// </summary>
    public required bool AllowDataUnmask
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_data_unmask");
        }
        init { this._rawData.Set("allow_data_unmask", value); }
    }

    /// <summary>
    /// Whether multiple customers can share one email address.
    /// </summary>
    public required bool AllowDuplicateEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_duplicate_email");
        }
        init { this._rawData.Set("allow_duplicate_email", value); }
    }

    /// <summary>
    /// Whether paykey verification can be skipped.
    /// </summary>
    public required bool AllowPaykeyVerificationSkip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_paykey_verification_skip");
        }
        init { this._rawData.Set("allow_paykey_verification_skip", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowCustomerIdentitySkip;
        _ = this.AllowDataUnmask;
        _ = this.AllowDuplicateEmail;
        _ = this.AllowPaykeyVerificationSkip;
    }

    public AccountPolicyControls() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountPolicyControls(AccountPolicyControls accountPolicyControls)
        : base(accountPolicyControls) { }
#pragma warning restore CS8618

    public AccountPolicyControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountPolicyControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountPolicyControlsFromRaw.FromRawUnchecked"/>
    public static AccountPolicyControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountPolicyControlsFromRaw : IFromRawJson<AccountPolicyControls>
{
    /// <inheritdoc/>
    public AccountPolicyControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountPolicyControls.FromRawUnchecked(rawData);
}
