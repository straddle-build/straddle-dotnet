using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(typeof(JsonModelConverter<LinkedBankAccount, LinkedBankAccountFromRaw>))]
public sealed record class LinkedBankAccount : JsonModel
{
    /// <summary>
    /// Straddle's unique ID for the linked bank account.
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
    /// ID of the related account, if this is an account-level linked bank account.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required MaskedLinkedBankAccountDetails BankAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MaskedLinkedBankAccountDetails>("bank_account");
        }
        init { this._rawData.Set("bank_account", value); }
    }

    /// <summary>
    /// Date and time when Straddle created the linked bank account.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Payment purposes assigned to the linked bank account.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, LinkedBankAccountPurpose>> Purposes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, LinkedBankAccountPurpose>>
            >("purposes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, LinkedBankAccountPurpose>>>(
                "purposes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Status of the linked bank account.
    /// </summary>
    public required ApiEnum<string, LinkedBankAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LinkedBankAccountStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required LinkedBankAccountStatusDetail StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LinkedBankAccountStatusDetail>("status_detail");
        }
        init { this._rawData.Set("status_detail", value); }
    }

    /// <summary>
    /// Date and time of the most recent linked bank account update.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Your description for the linked bank account.
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

    /// <summary>
    /// ID of the related platform, if this is a platform-level linked bank account.
    /// </summary>
    public string? PlatformID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("platform_id");
        }
        init { this._rawData.Set("platform_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.BankAccount.Validate();
        _ = this.CreatedAt;
        foreach (var item in this.Purposes)
        {
            item.Validate();
        }
        this.Status.Validate();
        this.StatusDetail.Validate();
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.PlatformID;
    }

    public LinkedBankAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccount(LinkedBankAccount linkedBankAccount)
        : base(linkedBankAccount) { }
#pragma warning restore CS8618

    public LinkedBankAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountFromRaw : IFromRawJson<LinkedBankAccount>
{
    /// <inheritdoc/>
    public LinkedBankAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkedBankAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LinkedBankAccountPurposeConverter))]
public enum LinkedBankAccountPurpose
{
    Charges,
    Payouts,
    Billing,
}

sealed class LinkedBankAccountPurposeConverter : JsonConverter<LinkedBankAccountPurpose>
{
    public override LinkedBankAccountPurpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charges" => LinkedBankAccountPurpose.Charges,
            "payouts" => LinkedBankAccountPurpose.Payouts,
            "billing" => LinkedBankAccountPurpose.Billing,
            _ => (LinkedBankAccountPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LinkedBankAccountPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LinkedBankAccountPurpose.Charges => "charges",
                LinkedBankAccountPurpose.Payouts => "payouts",
                LinkedBankAccountPurpose.Billing => "billing",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of the linked bank account.
/// </summary>
[JsonConverter(typeof(LinkedBankAccountStatusConverter))]
public enum LinkedBankAccountStatus
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
    Canceled,
}

sealed class LinkedBankAccountStatusConverter : JsonConverter<LinkedBankAccountStatus>
{
    public override LinkedBankAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => LinkedBankAccountStatus.Created,
            "onboarding" => LinkedBankAccountStatus.Onboarding,
            "active" => LinkedBankAccountStatus.Active,
            "rejected" => LinkedBankAccountStatus.Rejected,
            "inactive" => LinkedBankAccountStatus.Inactive,
            "canceled" => LinkedBankAccountStatus.Canceled,
            _ => (LinkedBankAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LinkedBankAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LinkedBankAccountStatus.Created => "created",
                LinkedBankAccountStatus.Onboarding => "onboarding",
                LinkedBankAccountStatus.Active => "active",
                LinkedBankAccountStatus.Rejected => "rejected",
                LinkedBankAccountStatus.Inactive => "inactive",
                LinkedBankAccountStatus.Canceled => "canceled",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
