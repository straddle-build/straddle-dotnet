using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;
using System = System;

namespace Straddle.Models.CapabilityRequests;

[JsonConverter(typeof(JsonModelConverter<CapabilityRequestList, CapabilityRequestListFromRaw>))]
public sealed record class CapabilityRequestList : JsonModel
{
    /// <summary>
    /// Capability requests returned for this page.
    /// </summary>
    public required IReadOnlyList<CapabilityRequest> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CapabilityRequest>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CapabilityRequest>>(
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
        global::Straddle.Models.CapabilityRequests.ResponseType
    > ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.CapabilityRequests.ResponseType>
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

    public CapabilityRequestList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequestList(CapabilityRequestList capabilityRequestList)
        : base(capabilityRequestList) { }
#pragma warning restore CS8618

    public CapabilityRequestList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequestList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityRequestListFromRaw.FromRawUnchecked"/>
    public static CapabilityRequestList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityRequestListFromRaw : IFromRawJson<CapabilityRequestList>
{
    /// <inheritdoc/>
    public CapabilityRequestList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CapabilityRequestList.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(global::Straddle.Models.CapabilityRequests.ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter
    : JsonConverter<global::Straddle.Models.CapabilityRequests.ResponseType>
{
    public override global::Straddle.Models.CapabilityRequests.ResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Straddle.Models.CapabilityRequests.ResponseType.Object,
            "array" => global::Straddle.Models.CapabilityRequests.ResponseType.Array,
            "error" => global::Straddle.Models.CapabilityRequests.ResponseType.Error,
            "none" => global::Straddle.Models.CapabilityRequests.ResponseType.None,
            _ => (global::Straddle.Models.CapabilityRequests.ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.CapabilityRequests.ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.CapabilityRequests.ResponseType.Object => "object",
                global::Straddle.Models.CapabilityRequests.ResponseType.Array => "array",
                global::Straddle.Models.CapabilityRequests.ResponseType.Error => "error",
                global::Straddle.Models.CapabilityRequests.ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
