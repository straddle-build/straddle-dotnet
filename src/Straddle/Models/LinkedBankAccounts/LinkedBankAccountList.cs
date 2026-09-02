using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(typeof(JsonModelConverter<LinkedBankAccountList, LinkedBankAccountListFromRaw>))]
public sealed record class LinkedBankAccountList : JsonModel
{
    /// <summary>
    /// Linked bank accounts returned for this page.
    /// </summary>
    public required IReadOnlyList<LinkedBankAccount> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LinkedBankAccount>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LinkedBankAccount>>(
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
        global::Straddle.Models.LinkedBankAccounts.ResponseType
    > ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.LinkedBankAccounts.ResponseType>
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

    public LinkedBankAccountList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountList(LinkedBankAccountList linkedBankAccountList)
        : base(linkedBankAccountList) { }
#pragma warning restore CS8618

    public LinkedBankAccountList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountListFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccountList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountListFromRaw : IFromRawJson<LinkedBankAccountList>
{
    /// <inheritdoc/>
    public LinkedBankAccountList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedBankAccountList.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(global::Straddle.Models.LinkedBankAccounts.ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter
    : JsonConverter<global::Straddle.Models.LinkedBankAccounts.ResponseType>
{
    public override global::Straddle.Models.LinkedBankAccounts.ResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Straddle.Models.LinkedBankAccounts.ResponseType.Object,
            "array" => global::Straddle.Models.LinkedBankAccounts.ResponseType.Array,
            "error" => global::Straddle.Models.LinkedBankAccounts.ResponseType.Error,
            "none" => global::Straddle.Models.LinkedBankAccounts.ResponseType.None,
            _ => (global::Straddle.Models.LinkedBankAccounts.ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.LinkedBankAccounts.ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.LinkedBankAccounts.ResponseType.Object => "object",
                global::Straddle.Models.LinkedBankAccounts.ResponseType.Array => "array",
                global::Straddle.Models.LinkedBankAccounts.ResponseType.Error => "error",
                global::Straddle.Models.LinkedBankAccounts.ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
