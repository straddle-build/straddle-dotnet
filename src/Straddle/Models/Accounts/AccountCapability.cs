using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountCapability, AccountCapabilityFromRaw>))]
public sealed record class AccountCapability : JsonModel
{
    /// <summary>
    /// Status of the capability for the account.
    /// </summary>
    public required ApiEnum<string, CapabilityStatus> CapabilityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CapabilityStatus>>(
                "capability_status"
            );
        }
        init { this._rawData.Set("capability_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CapabilityStatus.Validate();
    }

    public AccountCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCapability(AccountCapability accountCapability)
        : base(accountCapability) { }
#pragma warning restore CS8618

    public AccountCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCapabilityFromRaw.FromRawUnchecked"/>
    public static AccountCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountCapability(ApiEnum<string, CapabilityStatus> capabilityStatus)
        : this()
    {
        this.CapabilityStatus = capabilityStatus;
    }
}

class AccountCapabilityFromRaw : IFromRawJson<AccountCapability>
{
    /// <inheritdoc/>
    public AccountCapability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountCapability.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the capability for the account.
/// </summary>
[JsonConverter(typeof(CapabilityStatusConverter))]
public enum CapabilityStatus
{
    Active,
    Inactive,
}

sealed class CapabilityStatusConverter : JsonConverter<CapabilityStatus>
{
    public override CapabilityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => CapabilityStatus.Active,
            "inactive" => CapabilityStatus.Inactive,
            _ => (CapabilityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CapabilityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CapabilityStatus.Active => "active",
                CapabilityStatus.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
