using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.CapabilityRequests;

[JsonConverter(typeof(JsonModelConverter<CapabilityRequest, CapabilityRequestFromRaw>))]
public sealed record class CapabilityRequest : JsonModel
{
    /// <summary>
    /// Straddle's unique ID for the capability request.
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
    /// ID of the account associated with the capability request.
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
    /// Groups the requested capability. `payment_type` covers `charges` and
    /// `payouts`. `customer_type` covers `individuals` and `businesses`.
    /// `consent_type` covers `signed_agreement` and `internet` authorization.
    /// </summary>
    public required ApiEnum<string, CapabilityRequestCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CapabilityRequestCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Date and time when Straddle created the capability request.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Whether the request enables or disables the capability.
    /// </summary>
    public required bool Enable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enable");
        }
        init { this._rawData.Set("enable", value); }
    }

    /// <summary>
    /// Status of the capability request.
    /// </summary>
    public required ApiEnum<string, CapabilityRequestStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CapabilityRequestStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Capability type requested within the category.
    /// </summary>
    public required ApiEnum<string, CapabilityRequestType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CapabilityRequestType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Date and time of the most recent capability request update.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Limits and other settings requested for the capability.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.Category.Validate();
        _ = this.CreatedAt;
        _ = this.Enable;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.Settings;
    }

    public CapabilityRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequest(CapabilityRequest capabilityRequest)
        : base(capabilityRequest) { }
#pragma warning restore CS8618

    public CapabilityRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityRequestFromRaw.FromRawUnchecked"/>
    public static CapabilityRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityRequestFromRaw : IFromRawJson<CapabilityRequest>
{
    /// <inheritdoc/>
    public CapabilityRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CapabilityRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Groups the requested capability. `payment_type` covers `charges` and `payouts`.
/// `customer_type` covers `individuals` and `businesses`. `consent_type` covers
/// `signed_agreement` and `internet` authorization.
/// </summary>
[JsonConverter(typeof(CapabilityRequestCategoryConverter))]
public enum CapabilityRequestCategory
{
    PaymentType,
    CustomerType,
    ConsentType,
}

sealed class CapabilityRequestCategoryConverter : JsonConverter<CapabilityRequestCategory>
{
    public override CapabilityRequestCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_type" => CapabilityRequestCategory.PaymentType,
            "customer_type" => CapabilityRequestCategory.CustomerType,
            "consent_type" => CapabilityRequestCategory.ConsentType,
            _ => (CapabilityRequestCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CapabilityRequestCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CapabilityRequestCategory.PaymentType => "payment_type",
                CapabilityRequestCategory.CustomerType => "customer_type",
                CapabilityRequestCategory.ConsentType => "consent_type",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of the capability request.
/// </summary>
[JsonConverter(typeof(CapabilityRequestStatusConverter))]
public enum CapabilityRequestStatus
{
    Active,
    Inactive,
    InReview,
    Rejected,
    Approved,
    Reviewing,
}

sealed class CapabilityRequestStatusConverter : JsonConverter<CapabilityRequestStatus>
{
    public override CapabilityRequestStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => CapabilityRequestStatus.Active,
            "inactive" => CapabilityRequestStatus.Inactive,
            "in_review" => CapabilityRequestStatus.InReview,
            "rejected" => CapabilityRequestStatus.Rejected,
            "approved" => CapabilityRequestStatus.Approved,
            "reviewing" => CapabilityRequestStatus.Reviewing,
            _ => (CapabilityRequestStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CapabilityRequestStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CapabilityRequestStatus.Active => "active",
                CapabilityRequestStatus.Inactive => "inactive",
                CapabilityRequestStatus.InReview => "in_review",
                CapabilityRequestStatus.Rejected => "rejected",
                CapabilityRequestStatus.Approved => "approved",
                CapabilityRequestStatus.Reviewing => "reviewing",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Capability type requested within the category.
/// </summary>
[JsonConverter(typeof(CapabilityRequestTypeConverter))]
public enum CapabilityRequestType
{
    Charges,
    Payouts,
    Individuals,
    Businesses,
    SignedAgreement,
    Internet,
}

sealed class CapabilityRequestTypeConverter : JsonConverter<CapabilityRequestType>
{
    public override CapabilityRequestType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charges" => CapabilityRequestType.Charges,
            "payouts" => CapabilityRequestType.Payouts,
            "individuals" => CapabilityRequestType.Individuals,
            "businesses" => CapabilityRequestType.Businesses,
            "signed_agreement" => CapabilityRequestType.SignedAgreement,
            "internet" => CapabilityRequestType.Internet,
            _ => (CapabilityRequestType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CapabilityRequestType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CapabilityRequestType.Charges => "charges",
                CapabilityRequestType.Payouts => "payouts",
                CapabilityRequestType.Individuals => "individuals",
                CapabilityRequestType.Businesses => "businesses",
                CapabilityRequestType.SignedAgreement => "signed_agreement",
                CapabilityRequestType.Internet => "internet",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
