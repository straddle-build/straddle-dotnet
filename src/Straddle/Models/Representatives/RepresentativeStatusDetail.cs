using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Representatives;

[JsonConverter(
    typeof(JsonModelConverter<RepresentativeStatusDetail, RepresentativeStatusDetailFromRaw>)
)]
public sealed record class RepresentativeStatusDetail : JsonModel
{
    /// <summary>
    /// Machine-readable status code from the source.
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
    /// Human-readable description of the representative's status.
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
    /// Machine-readable reason for the representative's status.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// System that produced the representative status detail.
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

    public RepresentativeStatusDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeStatusDetail(RepresentativeStatusDetail representativeStatusDetail)
        : base(representativeStatusDetail) { }
#pragma warning restore CS8618

    public RepresentativeStatusDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeStatusDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeStatusDetailFromRaw.FromRawUnchecked"/>
    public static RepresentativeStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeStatusDetailFromRaw : IFromRawJson<RepresentativeStatusDetail>
{
    /// <inheritdoc/>
    public RepresentativeStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentativeStatusDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Machine-readable reason for the representative's status.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Unverified,
    InReview,
    Pending,
    Stuck,
    Verified,
    FailedVerification,
    Disabled,
    New,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unverified" => Reason.Unverified,
            "in_review" => Reason.InReview,
            "pending" => Reason.Pending,
            "stuck" => Reason.Stuck,
            "verified" => Reason.Verified,
            "failed_verification" => Reason.FailedVerification,
            "disabled" => Reason.Disabled,
            "new" => Reason.New,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Unverified => "unverified",
                Reason.InReview => "in_review",
                Reason.Pending => "pending",
                Reason.Stuck => "stuck",
                Reason.Verified => "verified",
                Reason.FailedVerification => "failed_verification",
                Reason.Disabled => "disabled",
                Reason.New => "new",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// System that produced the representative status detail.
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
