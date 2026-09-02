using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.Representatives;

[JsonConverter(
    typeof(JsonModelConverter<
        UnmaskedRepresentativeResponse,
        UnmaskedRepresentativeResponseFromRaw
    >)
)]
public sealed record class UnmaskedRepresentativeResponse : JsonModel
{
    public required UnmaskedRepresentative Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnmaskedRepresentative>("data");
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
    public required ApiEnum<string, UnmaskedRepresentativeResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UnmaskedRepresentativeResponseResponseType>
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

    public UnmaskedRepresentativeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedRepresentativeResponse(
        UnmaskedRepresentativeResponse unmaskedRepresentativeResponse
    )
        : base(unmaskedRepresentativeResponse) { }
#pragma warning restore CS8618

    public UnmaskedRepresentativeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedRepresentativeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedRepresentativeResponseFromRaw.FromRawUnchecked"/>
    public static UnmaskedRepresentativeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedRepresentativeResponseFromRaw : IFromRawJson<UnmaskedRepresentativeResponse>
{
    /// <inheritdoc/>
    public UnmaskedRepresentativeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedRepresentativeResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(UnmaskedRepresentativeResponseResponseTypeConverter))]
public enum UnmaskedRepresentativeResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class UnmaskedRepresentativeResponseResponseTypeConverter
    : JsonConverter<UnmaskedRepresentativeResponseResponseType>
{
    public override UnmaskedRepresentativeResponseResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => UnmaskedRepresentativeResponseResponseType.Object,
            "array" => UnmaskedRepresentativeResponseResponseType.Array,
            "error" => UnmaskedRepresentativeResponseResponseType.Error,
            "none" => UnmaskedRepresentativeResponseResponseType.None,
            _ => (UnmaskedRepresentativeResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnmaskedRepresentativeResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnmaskedRepresentativeResponseResponseType.Object => "object",
                UnmaskedRepresentativeResponseResponseType.Array => "array",
                UnmaskedRepresentativeResponseResponseType.Error => "error",
                UnmaskedRepresentativeResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
