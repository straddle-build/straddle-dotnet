using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountStatusDetail, AccountStatusDetailFromRaw>))]
public sealed record class AccountStatusDetail : JsonModel
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
    /// Human-readable description of the account's status.
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
    /// Machine-readable reason for the account's status.
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
    /// System that produced the account status detail.
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

    public AccountStatusDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatusDetail(AccountStatusDetail accountStatusDetail)
        : base(accountStatusDetail) { }
#pragma warning restore CS8618

    public AccountStatusDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatusDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatusDetailFromRaw.FromRawUnchecked"/>
    public static AccountStatusDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountStatusDetailFromRaw : IFromRawJson<AccountStatusDetail>
{
    /// <inheritdoc/>
    public AccountStatusDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountStatusDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Machine-readable reason for the account's status.
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
    Terminated,
    New,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            "terminated" => Reason.Terminated,
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
                Reason.Terminated => "terminated",
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
/// System that produced the account status detail.
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
        System::Type typeToConvert,
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
