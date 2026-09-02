using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PlatformCreatedV1WebhookEvent, PlatformCreatedV1WebhookEventFromRaw>)
)]
public sealed record class PlatformCreatedV1WebhookEvent : JsonModel
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

    public required PlatformCreatedV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlatformCreatedV1WebhookEventData>("data");
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

    public PlatformCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEvent(
        PlatformCreatedV1WebhookEvent platformCreatedV1WebhookEvent
    )
        : base(platformCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventFromRaw : IFromRawJson<PlatformCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlatformCreatedV1WebhookEventData,
        PlatformCreatedV1WebhookEventDataFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for the platform.
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
    /// Current lifecycle status of the platform.
    /// </summary>
    public required ApiEnum<string, PlatformCreatedV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlatformCreatedV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required PlatformCreatedV1WebhookEventDataStatusDetail StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlatformCreatedV1WebhookEventDataStatusDetail>(
                "status_detail"
            );
        }
        init { this._rawData.Set("status_detail", value); }
    }

    public PlatformCreatedV1WebhookEventDataBusinessProfile? BusinessProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlatformCreatedV1WebhookEventDataBusinessProfile>(
                "business_profile"
            );
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

    /// <summary>
    /// Timestamp when the platform was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Your unique identifier for the platform.
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
    /// Key-value metadata associated with the platform.
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
    /// Timestamp when the platform was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        this.StatusDetail.Validate();
        this.BusinessProfile?.Validate();
        _ = this.CreatedAt;
        _ = this.ExternalID;
        _ = this.Metadata;
        _ = this.UpdatedAt;
    }

    public PlatformCreatedV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventData(
        PlatformCreatedV1WebhookEventData platformCreatedV1WebhookEventData
    )
        : base(platformCreatedV1WebhookEventData) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataFromRaw : IFromRawJson<PlatformCreatedV1WebhookEventData>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Current lifecycle status of the platform.
/// </summary>
[JsonConverter(typeof(PlatformCreatedV1WebhookEventDataStatusConverter))]
public enum PlatformCreatedV1WebhookEventDataStatus
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
}

sealed class PlatformCreatedV1WebhookEventDataStatusConverter
    : JsonConverter<PlatformCreatedV1WebhookEventDataStatus>
{
    public override PlatformCreatedV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PlatformCreatedV1WebhookEventDataStatus.Created,
            "onboarding" => PlatformCreatedV1WebhookEventDataStatus.Onboarding,
            "active" => PlatformCreatedV1WebhookEventDataStatus.Active,
            "rejected" => PlatformCreatedV1WebhookEventDataStatus.Rejected,
            "inactive" => PlatformCreatedV1WebhookEventDataStatus.Inactive,
            _ => (PlatformCreatedV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlatformCreatedV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlatformCreatedV1WebhookEventDataStatus.Created => "created",
                PlatformCreatedV1WebhookEventDataStatus.Onboarding => "onboarding",
                PlatformCreatedV1WebhookEventDataStatus.Active => "active",
                PlatformCreatedV1WebhookEventDataStatus.Rejected => "rejected",
                PlatformCreatedV1WebhookEventDataStatus.Inactive => "inactive",
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
        PlatformCreatedV1WebhookEventDataStatusDetail,
        PlatformCreatedV1WebhookEventDataStatusDetailFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventDataStatusDetail : JsonModel
{
    /// <summary>
    /// Machine-readable code for the current platform status.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Human-readable explanation of the current platform status.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Machine-readable reason for the current platform status.
    /// </summary>
    public required ApiEnum<string, PlatformCreatedV1WebhookEventDataStatusDetailReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlatformCreatedV1WebhookEventDataStatusDetailReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Source that produced the current platform status.
    /// </summary>
    public required ApiEnum<string, PlatformCreatedV1WebhookEventDataStatusDetailSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlatformCreatedV1WebhookEventDataStatusDetailSource>
            >("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Message;
        this.Reason.Validate();
        this.Source.Validate();
    }

    public PlatformCreatedV1WebhookEventDataStatusDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventDataStatusDetail(
        PlatformCreatedV1WebhookEventDataStatusDetail platformCreatedV1WebhookEventDataStatusDetail
    )
        : base(platformCreatedV1WebhookEventDataStatusDetail) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventDataStatusDetail(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventDataStatusDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataStatusDetailFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventDataStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataStatusDetailFromRaw
    : IFromRawJson<PlatformCreatedV1WebhookEventDataStatusDetail>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventDataStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventDataStatusDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Machine-readable reason for the current platform status.
/// </summary>
[JsonConverter(typeof(PlatformCreatedV1WebhookEventDataStatusDetailReasonConverter))]
public enum PlatformCreatedV1WebhookEventDataStatusDetailReason
{
    Unverified,
    New,
    InReview,
    Pending,
    Stuck,
    Verified,
    FailedVerification,
    Disabled,
    Terminated,
}

sealed class PlatformCreatedV1WebhookEventDataStatusDetailReasonConverter
    : JsonConverter<PlatformCreatedV1WebhookEventDataStatusDetailReason>
{
    public override PlatformCreatedV1WebhookEventDataStatusDetailReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unverified" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Unverified,
            "new" => PlatformCreatedV1WebhookEventDataStatusDetailReason.New,
            "in_review" => PlatformCreatedV1WebhookEventDataStatusDetailReason.InReview,
            "pending" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Pending,
            "stuck" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Stuck,
            "verified" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Verified,
            "failed_verification" =>
                PlatformCreatedV1WebhookEventDataStatusDetailReason.FailedVerification,
            "disabled" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Disabled,
            "terminated" => PlatformCreatedV1WebhookEventDataStatusDetailReason.Terminated,
            _ => (PlatformCreatedV1WebhookEventDataStatusDetailReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlatformCreatedV1WebhookEventDataStatusDetailReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Unverified => "unverified",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.New => "new",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.InReview => "in_review",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Pending => "pending",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Stuck => "stuck",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Verified => "verified",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.FailedVerification =>
                    "failed_verification",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Disabled => "disabled",
                PlatformCreatedV1WebhookEventDataStatusDetailReason.Terminated => "terminated",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Source that produced the current platform status.
/// </summary>
[JsonConverter(typeof(PlatformCreatedV1WebhookEventDataStatusDetailSourceConverter))]
public enum PlatformCreatedV1WebhookEventDataStatusDetailSource
{
    Watchtower,
}

sealed class PlatformCreatedV1WebhookEventDataStatusDetailSourceConverter
    : JsonConverter<PlatformCreatedV1WebhookEventDataStatusDetailSource>
{
    public override PlatformCreatedV1WebhookEventDataStatusDetailSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "watchtower" => PlatformCreatedV1WebhookEventDataStatusDetailSource.Watchtower,
            _ => (PlatformCreatedV1WebhookEventDataStatusDetailSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlatformCreatedV1WebhookEventDataStatusDetailSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlatformCreatedV1WebhookEventDataStatusDetailSource.Watchtower => "watchtower",
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
        PlatformCreatedV1WebhookEventDataBusinessProfile,
        PlatformCreatedV1WebhookEventDataBusinessProfileFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventDataBusinessProfile : JsonModel
{
    /// <summary>
    /// Display name of the business.
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
    /// URL of the business website.
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

    public PlatformCreatedV1WebhookEventDataBusinessProfileAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlatformCreatedV1WebhookEventDataBusinessProfileAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Description of the business.
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

    public PlatformCreatedV1WebhookEventDataBusinessProfileIndustry? Industry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlatformCreatedV1WebhookEventDataBusinessProfileIndustry>(
                "industry"
            );
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
    /// Registered legal name of the business.
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
    /// Primary phone number for the business.
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

    public PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels? SupportChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels>(
                "support_channels"
            );
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
    /// Tax identification number of the business.
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
    /// Description of how the business uses Straddle.
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

    public PlatformCreatedV1WebhookEventDataBusinessProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventDataBusinessProfile(
        PlatformCreatedV1WebhookEventDataBusinessProfile platformCreatedV1WebhookEventDataBusinessProfile
    )
        : base(platformCreatedV1WebhookEventDataBusinessProfile) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventDataBusinessProfile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventDataBusinessProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataBusinessProfileFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventDataBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataBusinessProfileFromRaw
    : IFromRawJson<PlatformCreatedV1WebhookEventDataBusinessProfile>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventDataBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventDataBusinessProfile.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlatformCreatedV1WebhookEventDataBusinessProfileAddress,
        PlatformCreatedV1WebhookEventDataBusinessProfileAddressFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventDataBusinessProfileAddress : JsonModel
{
    /// <summary>
    /// City for the address.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Two-letter ISO 3166-1 country code.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Primary street address.
    /// </summary>
    public string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// Additional address information, such as a suite or unit.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// Postal code for the address.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// State or region for the address.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public PlatformCreatedV1WebhookEventDataBusinessProfileAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventDataBusinessProfileAddress(
        PlatformCreatedV1WebhookEventDataBusinessProfileAddress platformCreatedV1WebhookEventDataBusinessProfileAddress
    )
        : base(platformCreatedV1WebhookEventDataBusinessProfileAddress) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventDataBusinessProfileAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventDataBusinessProfileAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataBusinessProfileAddressFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventDataBusinessProfileAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataBusinessProfileAddressFromRaw
    : IFromRawJson<PlatformCreatedV1WebhookEventDataBusinessProfileAddress>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventDataBusinessProfileAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventDataBusinessProfileAddress.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlatformCreatedV1WebhookEventDataBusinessProfileIndustry,
        PlatformCreatedV1WebhookEventDataBusinessProfileIndustryFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventDataBusinessProfileIndustry : JsonModel
{
    /// <summary>
    /// Industry category of the business.
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Merchant Category Code assigned to the business.
    /// </summary>
    public string? Mcc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mcc");
        }
        init { this._rawData.Set("mcc", value); }
    }

    /// <summary>
    /// Industry sector of the business.
    /// </summary>
    public string? Sector
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sector");
        }
        init { this._rawData.Set("sector", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Category;
        _ = this.Mcc;
        _ = this.Sector;
    }

    public PlatformCreatedV1WebhookEventDataBusinessProfileIndustry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventDataBusinessProfileIndustry(
        PlatformCreatedV1WebhookEventDataBusinessProfileIndustry platformCreatedV1WebhookEventDataBusinessProfileIndustry
    )
        : base(platformCreatedV1WebhookEventDataBusinessProfileIndustry) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventDataBusinessProfileIndustry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventDataBusinessProfileIndustry(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataBusinessProfileIndustryFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventDataBusinessProfileIndustry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataBusinessProfileIndustryFromRaw
    : IFromRawJson<PlatformCreatedV1WebhookEventDataBusinessProfileIndustry>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventDataBusinessProfileIndustry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventDataBusinessProfileIndustry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels,
        PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannelsFromRaw
    >)
)]
public sealed record class PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels
    : JsonModel
{
    /// <summary>
    /// Customer support email address.
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
    /// Customer support phone number.
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
    /// URL of the customer support page or contact form.
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

    public PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels(
        PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels platformCreatedV1WebhookEventDataBusinessProfileSupportChannels
    )
        : base(platformCreatedV1WebhookEventDataBusinessProfileSupportChannels) { }
#pragma warning restore CS8618

    public PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannelsFromRaw.FromRawUnchecked"/>
    public static PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannelsFromRaw
    : IFromRawJson<PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels>
{
    /// <inheritdoc/>
    public PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformCreatedV1WebhookEventDataBusinessProfileSupportChannels.FromRawUnchecked(rawData);
}
