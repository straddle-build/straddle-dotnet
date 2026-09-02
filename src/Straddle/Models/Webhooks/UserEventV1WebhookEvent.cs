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

[JsonConverter(typeof(JsonModelConverter<UserEventV1WebhookEvent, UserEventV1WebhookEventFromRaw>))]
public sealed record class UserEventV1WebhookEvent : JsonModel
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

    public required UserEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserEventV1WebhookEventData>("data");
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

    public UserEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserEventV1WebhookEvent(UserEventV1WebhookEvent userEventV1WebhookEvent)
        : base(userEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public UserEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static UserEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserEventV1WebhookEventFromRaw : IFromRawJson<UserEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public UserEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UserEventV1WebhookEventData, UserEventV1WebhookEventDataFromRaw>)
)]
public sealed record class UserEventV1WebhookEventData : JsonModel
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
    public required ApiEnum<string, Level> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Level>>("level");
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Memberships that grant the user access to Straddle entities.
    /// </summary>
    public required IReadOnlyList<Membership> Memberships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Membership>>("memberships");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Membership>>(
                "memberships",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The role assigned to the user, determining their permissions within the system.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, UserEventV1WebhookEventDataRole>> Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, UserEventV1WebhookEventDataRole>>
            >("roles");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, UserEventV1WebhookEventDataRole>>>(
                "roles",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The current status of the user.
    /// </summary>
    public required ApiEnum<string, UserEventV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserEventV1WebhookEventDataStatus>
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

    public UserEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserEventV1WebhookEventData(UserEventV1WebhookEventData userEventV1WebhookEventData)
        : base(userEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public UserEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static UserEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserEventV1WebhookEventDataFromRaw : IFromRawJson<UserEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public UserEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserEventV1WebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the user.
/// </summary>
[JsonConverter(typeof(LevelConverter))]
public enum Level
{
    None,
    Onboarding,
    Straddle,
    Platform,
    Organization,
}

sealed class LevelConverter : JsonConverter<Level>
{
    public override Level Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Level.None,
            "onboarding" => Level.Onboarding,
            "straddle" => Level.Straddle,
            "platform" => Level.Platform,
            "organization" => Level.Organization,
            _ => (Level)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Level.None => "none",
                Level.Onboarding => "onboarding",
                Level.Straddle => "straddle",
                Level.Platform => "platform",
                Level.Organization => "organization",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Membership, MembershipFromRaw>))]
public sealed record class Membership : JsonModel
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
    public required ApiEnum<string, MembershipLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MembershipLevel>>("level");
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Roles granted by the membership.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Role>> Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Role>>>("roles");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Role>>>(
                "roles",
                ImmutableArray.ToImmutableArray(value)
            );
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

    public Membership() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Membership(Membership membership)
        : base(membership) { }
#pragma warning restore CS8618

    public Membership(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Membership(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MembershipFromRaw.FromRawUnchecked"/>
    public static Membership FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MembershipFromRaw : IFromRawJson<Membership>
{
    /// <inheritdoc/>
    public Membership FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Membership.FromRawUnchecked(rawData);
}

/// <summary>
/// Entity level at which the membership applies.
/// </summary>
[JsonConverter(typeof(MembershipLevelConverter))]
public enum MembershipLevel
{
    None,
    Onboarding,
    Account,
    Organization,
    Platform,
    Straddle,
}

sealed class MembershipLevelConverter : JsonConverter<MembershipLevel>
{
    public override MembershipLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => MembershipLevel.None,
            "onboarding" => MembershipLevel.Onboarding,
            "account" => MembershipLevel.Account,
            "organization" => MembershipLevel.Organization,
            "platform" => MembershipLevel.Platform,
            "straddle" => MembershipLevel.Straddle,
            _ => (MembershipLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MembershipLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MembershipLevel.None => "none",
                MembershipLevel.Onboarding => "onboarding",
                MembershipLevel.Account => "account",
                MembershipLevel.Organization => "organization",
                MembershipLevel.Platform => "platform",
                MembershipLevel.Straddle => "straddle",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    None,
    Member,
    Developer,
    Admin,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Role.None,
            "member" => Role.Member,
            "developer" => Role.Developer,
            "admin" => Role.Admin,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.None => "none",
                Role.Member => "member",
                Role.Developer => "developer",
                Role.Admin => "admin",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(UserEventV1WebhookEventDataRoleConverter))]
public enum UserEventV1WebhookEventDataRole
{
    None,
    Member,
    Developer,
    Admin,
}

sealed class UserEventV1WebhookEventDataRoleConverter
    : JsonConverter<UserEventV1WebhookEventDataRole>
{
    public override UserEventV1WebhookEventDataRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => UserEventV1WebhookEventDataRole.None,
            "member" => UserEventV1WebhookEventDataRole.Member,
            "developer" => UserEventV1WebhookEventDataRole.Developer,
            "admin" => UserEventV1WebhookEventDataRole.Admin,
            _ => (UserEventV1WebhookEventDataRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserEventV1WebhookEventDataRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserEventV1WebhookEventDataRole.None => "none",
                UserEventV1WebhookEventDataRole.Member => "member",
                UserEventV1WebhookEventDataRole.Developer => "developer",
                UserEventV1WebhookEventDataRole.Admin => "admin",
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
[JsonConverter(typeof(UserEventV1WebhookEventDataStatusConverter))]
public enum UserEventV1WebhookEventDataStatus
{
    Invited,
    Active,
    Onboarding,
    Inactive,
}

sealed class UserEventV1WebhookEventDataStatusConverter
    : JsonConverter<UserEventV1WebhookEventDataStatus>
{
    public override UserEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invited" => UserEventV1WebhookEventDataStatus.Invited,
            "active" => UserEventV1WebhookEventDataStatus.Active,
            "onboarding" => UserEventV1WebhookEventDataStatus.Onboarding,
            "inactive" => UserEventV1WebhookEventDataStatus.Inactive,
            _ => (UserEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserEventV1WebhookEventDataStatus.Invited => "invited",
                UserEventV1WebhookEventDataStatus.Active => "active",
                UserEventV1WebhookEventDataStatus.Onboarding => "onboarding",
                UserEventV1WebhookEventDataStatus.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
