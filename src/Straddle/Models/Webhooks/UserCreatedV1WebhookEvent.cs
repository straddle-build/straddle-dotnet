using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<UserCreatedV1WebhookEvent, UserCreatedV1WebhookEventFromRaw>)
)]
public sealed record class UserCreatedV1WebhookEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the account associated with this event.
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

    public required UserCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserCreatedV1WebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// Type of this event.
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.Data.Validate();
        _ = this.EventID;
        _ = this.EventType;
    }

    public UserCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserCreatedV1WebhookEvent(UserCreatedV1WebhookEvent userCreatedV1WebhookEvent)
        : base(userCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public UserCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static UserCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserCreatedV1WebhookEventFromRaw : IFromRawJson<UserCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public UserCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UserCreatedV1WebhookEventData, UserCreatedV1WebhookEventDataFromRaw>)
)]
public sealed record class UserCreatedV1WebhookEventData : JsonModel
{
    /// <summary>
    /// The unique identifier of the user.
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
    /// Timestamp of when the user was created.
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
    /// The email address of the user.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The first name of the user.
    /// </summary>
    public required string FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_name");
        }
        init { this._rawData.Set("first_name", value); }
    }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public required string LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_name");
        }
        init { this._rawData.Set("last_name", value); }
    }

    /// <summary>
    /// The current status of the user.
    /// </summary>
    public required ApiEnum<string, UserCreatedV1WebhookEventDataLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserCreatedV1WebhookEventDataLevel>
            >("level");
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Memberships that grant the user access to Straddle entities.
    /// </summary>
    public required IReadOnlyList<UserCreatedV1WebhookEventDataMembership> Memberships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<UserCreatedV1WebhookEventDataMembership>
            >("memberships");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserCreatedV1WebhookEventDataMembership>>(
                "memberships",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The role assigned to the user, determining their permissions within the system.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, UserCreatedV1WebhookEventDataRole>> Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, UserCreatedV1WebhookEventDataRole>>
            >("roles");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, UserCreatedV1WebhookEventDataRole>>>(
                "roles",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The current status of the user.
    /// </summary>
    public required ApiEnum<string, UserCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of the most recent update to the user.
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
    /// The unique identifier used for authentication purposes.
    /// </summary>
    public string? AuthenticatorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authenticator_id");
        }
        init { this._rawData.Set("authenticator_id", value); }
    }

    /// <summary>
    /// The unique identifier of the organization this user belongs to.
    /// </summary>
    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// The unique identifier of the organization this user belongs to.
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
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        this.Level.Validate();
        foreach (var item in this.Memberships)
        {
            item.Validate();
        }
        foreach (var item in this.Roles)
        {
            item.Validate();
        }
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.AuthenticatorID;
        _ = this.OrganizationID;
        _ = this.PlatformID;
    }

    public UserCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserCreatedV1WebhookEventData(
        UserCreatedV1WebhookEventData userCreatedV1WebhookEventData
    )
        : base(userCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public UserCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static UserCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserCreatedV1WebhookEventDataFromRaw : IFromRawJson<UserCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public UserCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the user.
/// </summary>
[JsonConverter(typeof(UserCreatedV1WebhookEventDataLevelConverter))]
public enum UserCreatedV1WebhookEventDataLevel
{
    None,
    Onboarding,
    Straddle,
    Platform,
    Organization,
}

sealed class UserCreatedV1WebhookEventDataLevelConverter
    : JsonConverter<UserCreatedV1WebhookEventDataLevel>
{
    public override UserCreatedV1WebhookEventDataLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => UserCreatedV1WebhookEventDataLevel.None,
            "onboarding" => UserCreatedV1WebhookEventDataLevel.Onboarding,
            "straddle" => UserCreatedV1WebhookEventDataLevel.Straddle,
            "platform" => UserCreatedV1WebhookEventDataLevel.Platform,
            "organization" => UserCreatedV1WebhookEventDataLevel.Organization,
            _ => (UserCreatedV1WebhookEventDataLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserCreatedV1WebhookEventDataLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserCreatedV1WebhookEventDataLevel.None => "none",
                UserCreatedV1WebhookEventDataLevel.Onboarding => "onboarding",
                UserCreatedV1WebhookEventDataLevel.Straddle => "straddle",
                UserCreatedV1WebhookEventDataLevel.Platform => "platform",
                UserCreatedV1WebhookEventDataLevel.Organization => "organization",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UserCreatedV1WebhookEventDataMembership,
        UserCreatedV1WebhookEventDataMembershipFromRaw
    >)
)]
public sealed record class UserCreatedV1WebhookEventDataMembership : JsonModel
{
    /// <summary>
    /// Organization identifier used by the authentication provider.
    /// </summary>
    public required string AuthenticatorOrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authenticator_organization_id");
        }
        init { this._rawData.Set("authenticator_organization_id", value); }
    }

    /// <summary>
    /// Display name of the entity associated with the membership.
    /// </summary>
    public required string EntityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entity_name");
        }
        init { this._rawData.Set("entity_name", value); }
    }

    /// <summary>
    /// Entity level at which the membership applies.
    /// </summary>
    public required ApiEnum<string, UserCreatedV1WebhookEventDataMembershipLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserCreatedV1WebhookEventDataMembershipLevel>
            >("level");
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Roles granted by the membership.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, UserCreatedV1WebhookEventDataMembershipRole>
    > Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, UserCreatedV1WebhookEventDataMembershipRole>>
            >("roles");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, UserCreatedV1WebhookEventDataMembershipRole>>
            >("roles", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Unique identifier of the entity associated with the membership.
    /// </summary>
    public string? EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthenticatorOrganizationID;
        _ = this.EntityName;
        this.Level.Validate();
        foreach (var item in this.Roles)
        {
            item.Validate();
        }
        _ = this.EntityID;
    }

    public UserCreatedV1WebhookEventDataMembership() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserCreatedV1WebhookEventDataMembership(
        UserCreatedV1WebhookEventDataMembership userCreatedV1WebhookEventDataMembership
    )
        : base(userCreatedV1WebhookEventDataMembership) { }
#pragma warning restore CS8618

    public UserCreatedV1WebhookEventDataMembership(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserCreatedV1WebhookEventDataMembership(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserCreatedV1WebhookEventDataMembershipFromRaw.FromRawUnchecked"/>
    public static UserCreatedV1WebhookEventDataMembership FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserCreatedV1WebhookEventDataMembershipFromRaw
    : IFromRawJson<UserCreatedV1WebhookEventDataMembership>
{
    /// <inheritdoc/>
    public UserCreatedV1WebhookEventDataMembership FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserCreatedV1WebhookEventDataMembership.FromRawUnchecked(rawData);
}

/// <summary>
/// Entity level at which the membership applies.
/// </summary>
[JsonConverter(typeof(UserCreatedV1WebhookEventDataMembershipLevelConverter))]
public enum UserCreatedV1WebhookEventDataMembershipLevel
{
    None,
    Onboarding,
    Account,
    Organization,
    Platform,
    Straddle,
}

sealed class UserCreatedV1WebhookEventDataMembershipLevelConverter
    : JsonConverter<UserCreatedV1WebhookEventDataMembershipLevel>
{
    public override UserCreatedV1WebhookEventDataMembershipLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => UserCreatedV1WebhookEventDataMembershipLevel.None,
            "onboarding" => UserCreatedV1WebhookEventDataMembershipLevel.Onboarding,
            "account" => UserCreatedV1WebhookEventDataMembershipLevel.Account,
            "organization" => UserCreatedV1WebhookEventDataMembershipLevel.Organization,
            "platform" => UserCreatedV1WebhookEventDataMembershipLevel.Platform,
            "straddle" => UserCreatedV1WebhookEventDataMembershipLevel.Straddle,
            _ => (UserCreatedV1WebhookEventDataMembershipLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserCreatedV1WebhookEventDataMembershipLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserCreatedV1WebhookEventDataMembershipLevel.None => "none",
                UserCreatedV1WebhookEventDataMembershipLevel.Onboarding => "onboarding",
                UserCreatedV1WebhookEventDataMembershipLevel.Account => "account",
                UserCreatedV1WebhookEventDataMembershipLevel.Organization => "organization",
                UserCreatedV1WebhookEventDataMembershipLevel.Platform => "platform",
                UserCreatedV1WebhookEventDataMembershipLevel.Straddle => "straddle",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(UserCreatedV1WebhookEventDataMembershipRoleConverter))]
public enum UserCreatedV1WebhookEventDataMembershipRole
{
    None,
    Member,
    Developer,
    Admin,
}

sealed class UserCreatedV1WebhookEventDataMembershipRoleConverter
    : JsonConverter<UserCreatedV1WebhookEventDataMembershipRole>
{
    public override UserCreatedV1WebhookEventDataMembershipRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => UserCreatedV1WebhookEventDataMembershipRole.None,
            "member" => UserCreatedV1WebhookEventDataMembershipRole.Member,
            "developer" => UserCreatedV1WebhookEventDataMembershipRole.Developer,
            "admin" => UserCreatedV1WebhookEventDataMembershipRole.Admin,
            _ => (UserCreatedV1WebhookEventDataMembershipRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserCreatedV1WebhookEventDataMembershipRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserCreatedV1WebhookEventDataMembershipRole.None => "none",
                UserCreatedV1WebhookEventDataMembershipRole.Member => "member",
                UserCreatedV1WebhookEventDataMembershipRole.Developer => "developer",
                UserCreatedV1WebhookEventDataMembershipRole.Admin => "admin",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(UserCreatedV1WebhookEventDataRoleConverter))]
public enum UserCreatedV1WebhookEventDataRole
{
    None,
    Member,
    Developer,
    Admin,
}

sealed class UserCreatedV1WebhookEventDataRoleConverter
    : JsonConverter<UserCreatedV1WebhookEventDataRole>
{
    public override UserCreatedV1WebhookEventDataRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => UserCreatedV1WebhookEventDataRole.None,
            "member" => UserCreatedV1WebhookEventDataRole.Member,
            "developer" => UserCreatedV1WebhookEventDataRole.Developer,
            "admin" => UserCreatedV1WebhookEventDataRole.Admin,
            _ => (UserCreatedV1WebhookEventDataRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserCreatedV1WebhookEventDataRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserCreatedV1WebhookEventDataRole.None => "none",
                UserCreatedV1WebhookEventDataRole.Member => "member",
                UserCreatedV1WebhookEventDataRole.Developer => "developer",
                UserCreatedV1WebhookEventDataRole.Admin => "admin",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The current status of the user.
/// </summary>
[JsonConverter(typeof(UserCreatedV1WebhookEventDataStatusConverter))]
public enum UserCreatedV1WebhookEventDataStatus
{
    Invited,
    Active,
    Onboarding,
    Inactive,
}

sealed class UserCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<UserCreatedV1WebhookEventDataStatus>
{
    public override UserCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invited" => UserCreatedV1WebhookEventDataStatus.Invited,
            "active" => UserCreatedV1WebhookEventDataStatus.Active,
            "onboarding" => UserCreatedV1WebhookEventDataStatus.Onboarding,
            "inactive" => UserCreatedV1WebhookEventDataStatus.Inactive,
            _ => (UserCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserCreatedV1WebhookEventDataStatus.Invited => "invited",
                UserCreatedV1WebhookEventDataStatus.Active => "active",
                UserCreatedV1WebhookEventDataStatus.Onboarding => "onboarding",
                UserCreatedV1WebhookEventDataStatus.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
