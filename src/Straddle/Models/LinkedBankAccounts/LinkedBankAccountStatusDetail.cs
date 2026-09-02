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
    typeof(JsonModelConverter<LinkedBankAccountStatusDetail, LinkedBankAccountStatusDetailFromRaw>)
)]
public sealed record class LinkedBankAccountStatusDetail : JsonModel
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
    /// Human-readable description of the linked bank account's status.
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
    /// Machine-readable reason for the linked bank account's status.
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
    /// System that produced the linked bank account status detail.
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

    public LinkedBankAccountStatusDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountStatusDetail(
        LinkedBankAccountStatusDetail linkedBankAccountStatusDetail
    )
        : base(linkedBankAccountStatusDetail) { }
#pragma warning restore CS8618

    public LinkedBankAccountStatusDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountStatusDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountStatusDetailFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccountStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountStatusDetailFromRaw : IFromRawJson<LinkedBankAccountStatusDetail>
{
    /// <inheritdoc/>
    public LinkedBankAccountStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedBankAccountStatusDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Machine-readable reason for the linked bank account's status.
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
/// System that produced the linked bank account status detail.
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
