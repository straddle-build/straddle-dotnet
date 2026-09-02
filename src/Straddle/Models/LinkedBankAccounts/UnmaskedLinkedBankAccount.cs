using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(
    typeof(JsonModelConverter<UnmaskedLinkedBankAccount, UnmaskedLinkedBankAccountFromRaw>)
)]
public sealed record class UnmaskedLinkedBankAccount : JsonModel
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
    /// ID of the Straddle account associated with the linked bank account.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Unmasked bank account details.
    /// </summary>
    public required UnmaskedLinkedBankAccountDetails BankAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnmaskedLinkedBankAccountDetails>("bank_account");
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
    /// Status of the linked bank account.
    /// </summary>
    public required ApiEnum<string, UnmaskedLinkedBankAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnmaskedLinkedBankAccountStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Details about the linked bank account's status.
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.BankAccount.Validate();
        _ = this.CreatedAt;
        this.Status.Validate();
        this.StatusDetail.Validate();
        _ = this.UpdatedAt;
        _ = this.Metadata;
    }

    public UnmaskedLinkedBankAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedLinkedBankAccount(UnmaskedLinkedBankAccount unmaskedLinkedBankAccount)
        : base(unmaskedLinkedBankAccount) { }
#pragma warning restore CS8618

    public UnmaskedLinkedBankAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedLinkedBankAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedLinkedBankAccountFromRaw.FromRawUnchecked"/>
    public static UnmaskedLinkedBankAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedLinkedBankAccountFromRaw : IFromRawJson<UnmaskedLinkedBankAccount>
{
    /// <inheritdoc/>
    public UnmaskedLinkedBankAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedLinkedBankAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the linked bank account.
/// </summary>
[JsonConverter(typeof(UnmaskedLinkedBankAccountStatusConverter))]
public enum UnmaskedLinkedBankAccountStatus
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
    Canceled,
}

sealed class UnmaskedLinkedBankAccountStatusConverter
    : JsonConverter<UnmaskedLinkedBankAccountStatus>
{
    public override UnmaskedLinkedBankAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => UnmaskedLinkedBankAccountStatus.Created,
            "onboarding" => UnmaskedLinkedBankAccountStatus.Onboarding,
            "active" => UnmaskedLinkedBankAccountStatus.Active,
            "rejected" => UnmaskedLinkedBankAccountStatus.Rejected,
            "inactive" => UnmaskedLinkedBankAccountStatus.Inactive,
            "canceled" => UnmaskedLinkedBankAccountStatus.Canceled,
            _ => (UnmaskedLinkedBankAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnmaskedLinkedBankAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnmaskedLinkedBankAccountStatus.Created => "created",
                UnmaskedLinkedBankAccountStatus.Onboarding => "onboarding",
                UnmaskedLinkedBankAccountStatus.Active => "active",
                UnmaskedLinkedBankAccountStatus.Rejected => "rejected",
                UnmaskedLinkedBankAccountStatus.Inactive => "inactive",
                UnmaskedLinkedBankAccountStatus.Canceled => "canceled",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
