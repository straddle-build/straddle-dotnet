using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.Organizations;

[JsonConverter(typeof(JsonModelConverter<OrganizationResponse, OrganizationResponseFromRaw>))]
public sealed record class OrganizationResponse : JsonModel
{
    public required Organization Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Organization>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Metadata for an API request.
    /// </summary>
    public required ResponseMetadata Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ResponseMetadata>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <summary>
    /// Indicates how the response content is structured.
    /// - `object` means `data` contains one JSON object.
    /// - `array` means `data` contains an array of objects.
    /// - `error` means `error` contains error details.
    /// - `none` means the response has no data.
    /// </summary>
    public required ApiEnum<string, OrganizationResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OrganizationResponseResponseType>>(
                "response_type"
            );
        }
        init { this._rawData.Set("response_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Meta.Validate();
        this.ResponseType.Validate();
    }

    public OrganizationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationResponse(OrganizationResponse organizationResponse)
        : base(organizationResponse) { }
#pragma warning restore CS8618

    public OrganizationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationResponseFromRaw.FromRawUnchecked"/>
    public static OrganizationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationResponseFromRaw : IFromRawJson<OrganizationResponse>
{
    /// <inheritdoc/>
    public OrganizationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(OrganizationResponseResponseTypeConverter))]
public enum OrganizationResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class OrganizationResponseResponseTypeConverter
    : JsonConverter<OrganizationResponseResponseType>
{
    public override OrganizationResponseResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => OrganizationResponseResponseType.Object,
            "array" => OrganizationResponseResponseType.Array,
            "error" => OrganizationResponseResponseType.Error,
            "none" => OrganizationResponseResponseType.None,
            _ => (OrganizationResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrganizationResponseResponseType.Object => "object",
                OrganizationResponseResponseType.Array => "array",
                OrganizationResponseResponseType.Error => "error",
                OrganizationResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
