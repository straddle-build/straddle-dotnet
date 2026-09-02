using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.Organizations;

[JsonConverter(typeof(JsonModelConverter<OrganizationList, OrganizationListFromRaw>))]
public sealed record class OrganizationList : JsonModel
{
    /// <summary>
    /// Organizations returned for this page.
    /// </summary>
    public required IReadOnlyList<Organization> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Organization>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Organization>>(
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
    public required ApiEnum<string, global::Straddle.Models.Organizations.ResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Organizations.ResponseType>
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

    public OrganizationList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationList(OrganizationList organizationList)
        : base(organizationList) { }
#pragma warning restore CS8618

    public OrganizationList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationListFromRaw.FromRawUnchecked"/>
    public static OrganizationList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationListFromRaw : IFromRawJson<OrganizationList>
{
    /// <inheritdoc/>
    public OrganizationList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrganizationList.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(global::Straddle.Models.Organizations.ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter
    : JsonConverter<global::Straddle.Models.Organizations.ResponseType>
{
    public override global::Straddle.Models.Organizations.ResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Straddle.Models.Organizations.ResponseType.Object,
            "array" => global::Straddle.Models.Organizations.ResponseType.Array,
            "error" => global::Straddle.Models.Organizations.ResponseType.Error,
            "none" => global::Straddle.Models.Organizations.ResponseType.None,
            _ => (global::Straddle.Models.Organizations.ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.Organizations.ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.Organizations.ResponseType.Object => "object",
                global::Straddle.Models.Organizations.ResponseType.Array => "array",
                global::Straddle.Models.Organizations.ResponseType.Error => "error",
                global::Straddle.Models.Organizations.ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
