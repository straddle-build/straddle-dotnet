using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountBusinessProfile, AccountBusinessProfileFromRaw>))]
public sealed record class AccountBusinessProfile : JsonModel
{
    /// <summary>
    /// The operating or trade name of the business.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// URL of the business's primary website.
    /// </summary>
    public required string Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <summary>
    /// Optional business address. If provided, `line1`, `city`, `state`, and
    /// `postal_code` are required.
    /// </summary>
    public AccountAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Description of the business and its products or services.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public AccountIndustry? Industry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountIndustry>("industry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("industry", value);
        }
    }

    /// <summary>
    /// The official registered name of the business.
    /// </summary>
    public string? LegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_name");
        }
        init { this._rawData.Set("legal_name", value); }
    }

    /// <summary>
    /// Primary business phone number in E.164 format.
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

    public AccountSupportChannels? SupportChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountSupportChannels>("support_channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("support_channels", value);
        }
    }

    /// <summary>
    /// Business tax identification number, such as a US Employer Identification Number (EIN).
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <summary>
    /// How the business plans to use Straddle.
    /// </summary>
    public string? UseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("use_case");
        }
        init { this._rawData.Set("use_case", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Website;
        this.Address?.Validate();
        _ = this.Description;
        this.Industry?.Validate();
        _ = this.LegalName;
        _ = this.Phone;
        this.SupportChannels?.Validate();
        _ = this.TaxID;
        _ = this.UseCase;
    }

    public AccountBusinessProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountBusinessProfile(AccountBusinessProfile accountBusinessProfile)
        : base(accountBusinessProfile) { }
#pragma warning restore CS8618

    public AccountBusinessProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountBusinessProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountBusinessProfileFromRaw.FromRawUnchecked"/>
    public static AccountBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountBusinessProfileFromRaw : IFromRawJson<AccountBusinessProfile>
{
    /// <inheritdoc/>
    public AccountBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountBusinessProfile.FromRawUnchecked(rawData);
}
