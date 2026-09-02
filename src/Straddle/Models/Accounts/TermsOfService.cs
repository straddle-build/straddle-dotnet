using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<TermsOfService, TermsOfServiceFromRaw>))]
public sealed record class TermsOfService : JsonModel
{
    /// <summary>
    /// Date and time when the account accepted the Terms of Service.
    /// </summary>
    public required System::DateTimeOffset AcceptedDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("accepted_date");
        }
        init { this._rawData.Set("accepted_date", value); }
    }

    /// <summary>
    /// Agreement type. Use `embedded` unless Straddle has enabled the platform for
    /// `direct` agreements.
    /// </summary>
    public required ApiEnum<string, AgreementType> AgreementType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AgreementType>>("agreement_type");
        }
        init { this._rawData.Set("agreement_type", value); }
    }

    /// <summary>
    /// URL of the accepted agreement.
    /// </summary>
    public required string? AgreementUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agreement_url");
        }
        init { this._rawData.Set("agreement_url", value); }
    }

    /// <summary>
    /// IP address used to accept the Terms of Service.
    /// </summary>
    public string? AcceptedIP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accepted_ip");
        }
        init { this._rawData.Set("accepted_ip", value); }
    }

    /// <summary>
    /// User agent of the browser or application that accepted the Terms of Service.
    /// </summary>
    public string? AcceptedUserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accepted_user_agent");
        }
        init { this._rawData.Set("accepted_user_agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedDate;
        this.AgreementType.Validate();
        _ = this.AgreementUrl;
        _ = this.AcceptedIP;
        _ = this.AcceptedUserAgent;
    }

    public TermsOfService() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TermsOfService(TermsOfService termsOfService)
        : base(termsOfService) { }
#pragma warning restore CS8618

    public TermsOfService(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TermsOfService(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TermsOfServiceFromRaw.FromRawUnchecked"/>
    public static TermsOfService FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TermsOfServiceFromRaw : IFromRawJson<TermsOfService>
{
    /// <inheritdoc/>
    public TermsOfService FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TermsOfService.FromRawUnchecked(rawData);
}

/// <summary>
/// Agreement type. Use `embedded` unless Straddle has enabled the platform for `direct` agreements.
/// </summary>
[JsonConverter(typeof(AgreementTypeConverter))]
public enum AgreementType
{
    Embedded,
    Direct,
}

sealed class AgreementTypeConverter : JsonConverter<AgreementType>
{
    public override AgreementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "embedded" => AgreementType.Embedded,
            "direct" => AgreementType.Direct,
            _ => (AgreementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgreementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgreementType.Embedded => "embedded",
                AgreementType.Direct => "direct",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
