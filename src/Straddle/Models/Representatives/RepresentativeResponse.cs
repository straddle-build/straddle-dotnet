using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.Representatives;

[JsonConverter(typeof(JsonModelConverter<RepresentativeResponse, RepresentativeResponseFromRaw>))]
public sealed record class RepresentativeResponse : JsonModel
{
    public required Representative Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Representative>("data");
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
    public required ApiEnum<string, RepresentativeResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RepresentativeResponseResponseType>
            >("response_type");
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

    public RepresentativeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeResponse(RepresentativeResponse representativeResponse)
        : base(representativeResponse) { }
#pragma warning restore CS8618

    public RepresentativeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeResponseFromRaw.FromRawUnchecked"/>
    public static RepresentativeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeResponseFromRaw : IFromRawJson<RepresentativeResponse>
{
    /// <inheritdoc/>
    public RepresentativeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentativeResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(RepresentativeResponseResponseTypeConverter))]
public enum RepresentativeResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class RepresentativeResponseResponseTypeConverter
    : JsonConverter<RepresentativeResponseResponseType>
{
    public override RepresentativeResponseResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => RepresentativeResponseResponseType.Object,
            "array" => RepresentativeResponseResponseType.Array,
            "error" => RepresentativeResponseResponseType.Error,
            "none" => RepresentativeResponseResponseType.None,
            _ => (RepresentativeResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RepresentativeResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RepresentativeResponseResponseType.Object => "object",
                RepresentativeResponseResponseType.Array => "array",
                RepresentativeResponseResponseType.Error => "error",
                RepresentativeResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
