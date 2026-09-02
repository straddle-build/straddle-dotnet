using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Representatives;

[JsonConverter(typeof(JsonModelConverter<Representative, RepresentativeFromRaw>))]
public sealed record class Representative : JsonModel
{
    /// <summary>
    /// Straddle's unique ID for the representative.
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
    /// ID of the account associated with the representative.
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
    /// Date and time when Straddle created the representative.
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
    /// Representative's date of birth in `YYYY-MM-DD` format.
    /// </summary>
    public required string Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dob");
        }
        init { this._rawData.Set("dob", value); }
    }

    /// <summary>
    /// Representative's email address.
    /// </summary>
    public required string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Representative's first name.
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
    /// Representative's last name.
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
    /// Representative's mobile phone number in E.164 format.
    /// </summary>
    public required string MobileNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mobile_number");
        }
        init { this._rawData.Set("mobile_number", value); }
    }

    /// <summary>
    /// Representative's display name.
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

    public required RepresentativeRelationship Relationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RepresentativeRelationship>("relationship");
        }
        init { this._rawData.Set("relationship", value); }
    }

    /// <summary>
    /// Last four digits of the representative's Social Security number.
    /// </summary>
    public required string SsnLast4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ssn_last4");
        }
        init { this._rawData.Set("ssn_last4", value); }
    }

    /// <summary>
    /// Status of the representative.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required RepresentativeStatusDetail StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RepresentativeStatusDetail>("status_detail");
        }
        init { this._rawData.Set("status_detail", value); }
    }

    /// <summary>
    /// Date and time of the most recent representative update.
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
    /// Your unique ID for the representative.
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
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Representative's phone number.
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
    /// ID of the Straddle user linked to the representative, if any.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.CreatedAt;
        _ = this.Dob;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.MobileNumber;
        _ = this.Name;
        this.Relationship.Validate();
        _ = this.SsnLast4;
        this.Status.Validate();
        this.StatusDetail.Validate();
        _ = this.UpdatedAt;
        _ = this.ExternalID;
        _ = this.Metadata;
        _ = this.Phone;
        _ = this.UserID;
    }

    public Representative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Representative(Representative representative)
        : base(representative) { }
#pragma warning restore CS8618

    public Representative(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Representative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeFromRaw.FromRawUnchecked"/>
    public static Representative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeFromRaw : IFromRawJson<Representative>
{
    /// <inheritdoc/>
    public Representative FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Representative.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the representative.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created,
    Onboarding,
    Active,
    Rejected,
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => Status.Created,
            "onboarding" => Status.Onboarding,
            "active" => Status.Active,
            "rejected" => Status.Rejected,
            "inactive" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Created => "created",
                Status.Onboarding => "onboarding",
                Status.Active => "active",
                Status.Rejected => "rejected",
                Status.Inactive => "inactive",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
