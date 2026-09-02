using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountSupportChannels, AccountSupportChannelsFromRaw>))]
public sealed record class AccountSupportChannels : JsonModel
{
    /// <summary>
    /// Email address for customer support.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Customer support phone number in E.164 format.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// URL of the business's customer support page or contact form.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Phone;
        _ = this.Url;
    }

    public AccountSupportChannels() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSupportChannels(AccountSupportChannels accountSupportChannels)
        : base(accountSupportChannels) { }
#pragma warning restore CS8618

    public AccountSupportChannels(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSupportChannels(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSupportChannelsFromRaw.FromRawUnchecked"/>
    public static AccountSupportChannels FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountSupportChannelsFromRaw : IFromRawJson<AccountSupportChannels>
{
    /// <inheritdoc/>
    public AccountSupportChannels FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountSupportChannels.FromRawUnchecked(rawData);
}
