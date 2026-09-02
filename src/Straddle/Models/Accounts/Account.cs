using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<Account, AccountFromRaw>))]
public sealed record class Account : JsonModel
{
    /// <summary>
    /// Straddle's unique ID for the account.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The account access level. `standard` provides normal account access,
    /// including access to the Straddle dashboard. `managed` means the platform
    /// manages the account and account users cannot access the Straddle dashboard.
    /// </summary>
    public required ApiEnum<string, AccountAccessLevel> AccessLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountAccessLevel>>(
                "access_level"
            );
        }
        init { this._rawData.Set("access_level", value); }
    }

    /// <summary>
    /// ID of the organization that owns the account.
    /// </summary>
    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// The current lifecycle status of the account.
    /// </summary>
    public required ApiEnum<string, AccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required AccountStatusDetail StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountStatusDetail>("status_detail");
        }
        init { this._rawData.Set("status_detail", value); }
    }

    /// <summary>
    /// The account type. Only `business` is supported.
    /// </summary>
    public required ApiEnum<string, AccountType2> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountType2>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public AccountBusinessProfile? BusinessProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountBusinessProfile>("business_profile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business_profile", value);
        }
    }

    public AccountCapabilities? Capabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountCapabilities>("capabilities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("capabilities", value);
        }
    }

    /// <summary>
    /// Date and time when Straddle created the account.
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Your unique ID for the account.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// Up to 20 user-defined key-value pairs.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public AccountPaymentSettings? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountPaymentSettings>("settings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    public TermsOfService? TermsOfService
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TermsOfService>("terms_of_service");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("terms_of_service", value);
        }
    }

    /// <summary>
    /// Date and time of the most recent account update.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AccessLevel.Validate();
        _ = this.OrganizationID;
        this.Status.Validate();
        this.StatusDetail.Validate();
        this.Type.Validate();
        this.BusinessProfile?.Validate();
        this.Capabilities?.Validate();
        _ = this.CreatedAt;
        _ = this.ExternalID;
        _ = this.Metadata;
        this.Settings?.Validate();
        this.TermsOfService?.Validate();
        _ = this.UpdatedAt;
    }

    public Account() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Account(Account account)
        : base(account) { }
#pragma warning restore CS8618

    public Account(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Account(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountFromRaw.FromRawUnchecked"/>
    public static Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountFromRaw : IFromRawJson<Account>
{
    /// <inheritdoc/>
    public Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Account.FromRawUnchecked(rawData);
}

/// <summary>
/// The account access level. `standard` provides normal account access, including
/// access to the Straddle dashboard. `managed` means the platform manages the
/// account and account users cannot access the Straddle dashboard.
/// </summary>
[JsonConverter(typeof(AccountAccessLevelConverter))]
public enum AccountAccessLevel
{
    Standard,
    Managed,
}

sealed class AccountAccessLevelConverter : JsonConverter<AccountAccessLevel>
{
    public override AccountAccessLevel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => AccountAccessLevel.Standard,
            "managed" => AccountAccessLevel.Managed,
            _ => (AccountAccessLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountAccessLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountAccessLevel.Standard => "standard",
                AccountAccessLevel.Managed => "managed",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The current lifecycle status of the account.
/// </summary>
[JsonConverter(typeof(AccountStatusConverter))]
public enum AccountStatus
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
}

sealed class AccountStatusConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => AccountStatus.Created,
            "onboarding" => AccountStatus.Onboarding,
            "active" => AccountStatus.Active,
            "rejected" => AccountStatus.Rejected,
            "inactive" => AccountStatus.Inactive,
            _ => (AccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountStatus.Created => "created",
                AccountStatus.Onboarding => "onboarding",
                AccountStatus.Active => "active",
                AccountStatus.Rejected => "rejected",
                AccountStatus.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The account type. Only `business` is supported.
/// </summary>
[JsonConverter(typeof(AccountType2Converter))]
public enum AccountType2
{
    Business,
}

sealed class AccountType2Converter : JsonConverter<AccountType2>
{
    public override AccountType2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => AccountType2.Business,
            _ => (AccountType2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountType2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountType2.Business => "business",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
