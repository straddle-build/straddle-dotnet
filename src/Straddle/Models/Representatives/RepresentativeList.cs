using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.Representatives;

[JsonConverter(typeof(JsonModelConverter<RepresentativeList, RepresentativeListFromRaw>))]
public sealed record class RepresentativeList : JsonModel
{
    /// <summary>
    /// Representatives returned for this page.
    /// </summary>
    public required IReadOnlyList<Representative> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Representative>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Representative>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata for an API request and a page of results.
    /// </summary>
    public required PageMetadata Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageMetadata>("meta");
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
    public required ApiEnum<
        string,
        global::Straddle.Models.Representatives.ResponseType
    > ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Representatives.ResponseType>
            >("response_type");
        }
        init { this._rawData.Set("response_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
        this.ResponseType.Validate();
    }

    public RepresentativeList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeList(RepresentativeList representativeList)
        : base(representativeList) { }
#pragma warning restore CS8618

    public RepresentativeList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeListFromRaw.FromRawUnchecked"/>
    public static RepresentativeList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeListFromRaw : IFromRawJson<RepresentativeList>
{
    /// <inheritdoc/>
    public RepresentativeList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RepresentativeList.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(global::Straddle.Models.Representatives.ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter
    : JsonConverter<global::Straddle.Models.Representatives.ResponseType>
{
    public override global::Straddle.Models.Representatives.ResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Straddle.Models.Representatives.ResponseType.Object,
            "array" => global::Straddle.Models.Representatives.ResponseType.Array,
            "error" => global::Straddle.Models.Representatives.ResponseType.Error,
            "none" => global::Straddle.Models.Representatives.ResponseType.None,
            _ => (global::Straddle.Models.Representatives.ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.Representatives.ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.Representatives.ResponseType.Object => "object",
                global::Straddle.Models.Representatives.ResponseType.Array => "array",
                global::Straddle.Models.Representatives.ResponseType.Error => "error",
                global::Straddle.Models.Representatives.ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
