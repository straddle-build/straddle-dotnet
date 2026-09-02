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
    typeof(JsonModelConverter<PlatformEventV1WebhookEvent, PlatformEventV1WebhookEventFromRaw>)
)]
public sealed record class PlatformEventV1WebhookEvent : JsonModel
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

    public required PlatformEventV1WebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlatformEventV1WebhookEventData>("data");
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

    public PlatformEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformEventV1WebhookEvent(PlatformEventV1WebhookEvent platformEventV1WebhookEvent)
        : base(platformEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public PlatformEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static PlatformEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformEventV1WebhookEventFromRaw : IFromRawJson<PlatformEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public PlatformEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformEventV1WebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlatformEventV1WebhookEventData,
        PlatformEventV1WebhookEventDataFromRaw
    >)
)]
public sealed record class PlatformEventV1WebhookEventData : JsonModel
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
    public required ApiEnum<string, PlatformEventV1WebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlatformEventV1WebhookEventDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required StatusDetail StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StatusDetail>("status_detail");
        }
        init { this._rawData.Set("status_detail", value); }
    }

    public BusinessProfile? BusinessProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BusinessProfile>("business_profile");
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

    public PlatformEventV1WebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformEventV1WebhookEventData(
        PlatformEventV1WebhookEventData platformEventV1WebhookEventData
    )
        : base(platformEventV1WebhookEventData) { }
#pragma warning restore CS8618

    public PlatformEventV1WebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformEventV1WebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformEventV1WebhookEventDataFromRaw.FromRawUnchecked"/>
    public static PlatformEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformEventV1WebhookEventDataFromRaw : IFromRawJson<PlatformEventV1WebhookEventData>
{
    /// <inheritdoc/>
    public PlatformEventV1WebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformEventV1WebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Current lifecycle status of the platform.
/// </summary>
[JsonConverter(typeof(PlatformEventV1WebhookEventDataStatusConverter))]
public enum PlatformEventV1WebhookEventDataStatus
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
}

sealed class PlatformEventV1WebhookEventDataStatusConverter
    : JsonConverter<PlatformEventV1WebhookEventDataStatus>
{
    public override PlatformEventV1WebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => PlatformEventV1WebhookEventDataStatus.Created,
            "onboarding" => PlatformEventV1WebhookEventDataStatus.Onboarding,
            "active" => PlatformEventV1WebhookEventDataStatus.Active,
            "rejected" => PlatformEventV1WebhookEventDataStatus.Rejected,
            "inactive" => PlatformEventV1WebhookEventDataStatus.Inactive,
            _ => (PlatformEventV1WebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlatformEventV1WebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlatformEventV1WebhookEventDataStatus.Created => "created",
                PlatformEventV1WebhookEventDataStatus.Onboarding => "onboarding",
                PlatformEventV1WebhookEventDataStatus.Active => "active",
                PlatformEventV1WebhookEventDataStatus.Rejected => "rejected",
                PlatformEventV1WebhookEventDataStatus.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<StatusDetail, StatusDetailFromRaw>))]
public sealed record class StatusDetail : JsonModel
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
    public required ApiEnum<string, StatusDetailReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StatusDetailReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Source that produced the current platform status.
    /// </summary>
    public required ApiEnum<string, Source> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Source>>("source");
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

    public StatusDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StatusDetail(StatusDetail statusDetail)
        : base(statusDetail) { }
#pragma warning restore CS8618

    public StatusDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StatusDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusDetailFromRaw.FromRawUnchecked"/>
    public static StatusDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusDetailFromRaw : IFromRawJson<StatusDetail>
{
    /// <inheritdoc/>
    public StatusDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StatusDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Machine-readable reason for the current platform status.
/// </summary>
[JsonConverter(typeof(StatusDetailReasonConverter))]
public enum StatusDetailReason
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

sealed class StatusDetailReasonConverter : JsonConverter<StatusDetailReason>
{
    public override StatusDetailReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unverified" => StatusDetailReason.Unverified,
            "new" => StatusDetailReason.New,
            "in_review" => StatusDetailReason.InReview,
            "pending" => StatusDetailReason.Pending,
            "stuck" => StatusDetailReason.Stuck,
            "verified" => StatusDetailReason.Verified,
            "failed_verification" => StatusDetailReason.FailedVerification,
            "disabled" => StatusDetailReason.Disabled,
            "terminated" => StatusDetailReason.Terminated,
            _ => (StatusDetailReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusDetailReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusDetailReason.Unverified => "unverified",
                StatusDetailReason.New => "new",
                StatusDetailReason.InReview => "in_review",
                StatusDetailReason.Pending => "pending",
                StatusDetailReason.Stuck => "stuck",
                StatusDetailReason.Verified => "verified",
                StatusDetailReason.FailedVerification => "failed_verification",
                StatusDetailReason.Disabled => "disabled",
                StatusDetailReason.Terminated => "terminated",
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
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Watchtower,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "watchtower" => Source.Watchtower,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Watchtower => "watchtower",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<BusinessProfile, BusinessProfileFromRaw>))]
public sealed record class BusinessProfile : JsonModel
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

    public BusinessProfileAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BusinessProfileAddress>("address");
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

    public Industry? Industry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Industry>("industry");
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

    public SupportChannels? SupportChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SupportChannels>("support_channels");
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

    public BusinessProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessProfile(BusinessProfile businessProfile)
        : base(businessProfile) { }
#pragma warning restore CS8618

    public BusinessProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessProfileFromRaw.FromRawUnchecked"/>
    public static BusinessProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BusinessProfileFromRaw : IFromRawJson<BusinessProfile>
{
    /// <inheritdoc/>
    public BusinessProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BusinessProfile.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BusinessProfileAddress, BusinessProfileAddressFromRaw>))]
public sealed record class BusinessProfileAddress : JsonModel
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

    public BusinessProfileAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessProfileAddress(BusinessProfileAddress businessProfileAddress)
        : base(businessProfileAddress) { }
#pragma warning restore CS8618

    public BusinessProfileAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessProfileAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessProfileAddressFromRaw.FromRawUnchecked"/>
    public static BusinessProfileAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BusinessProfileAddressFromRaw : IFromRawJson<BusinessProfileAddress>
{
    /// <inheritdoc/>
    public BusinessProfileAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BusinessProfileAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Industry, IndustryFromRaw>))]
public sealed record class Industry : JsonModel
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

    public Industry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Industry(Industry industry)
        : base(industry) { }
#pragma warning restore CS8618

    public Industry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Industry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndustryFromRaw.FromRawUnchecked"/>
    public static Industry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndustryFromRaw : IFromRawJson<Industry>
{
    /// <inheritdoc/>
    public Industry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Industry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SupportChannels, SupportChannelsFromRaw>))]
public sealed record class SupportChannels : JsonModel
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

    public SupportChannels() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SupportChannels(SupportChannels supportChannels)
        : base(supportChannels) { }
#pragma warning restore CS8618

    public SupportChannels(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SupportChannels(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SupportChannelsFromRaw.FromRawUnchecked"/>
    public static SupportChannels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SupportChannelsFromRaw : IFromRawJson<SupportChannels>
{
    /// <inheritdoc/>
    public SupportChannels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SupportChannels.FromRawUnchecked(rawData);
}
