using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.LinkedBankAccounts;

[JsonConverter(
    typeof(JsonModelConverter<LinkedBankAccountResponse, LinkedBankAccountResponseFromRaw>)
)]
public sealed record class LinkedBankAccountResponse : JsonModel
{
    public required LinkedBankAccount Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LinkedBankAccount>("data");
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
    public required ApiEnum<string, LinkedBankAccountResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, LinkedBankAccountResponseResponseType>
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

    public LinkedBankAccountResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountResponse(LinkedBankAccountResponse linkedBankAccountResponse)
        : base(linkedBankAccountResponse) { }
#pragma warning restore CS8618

    public LinkedBankAccountResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountResponseFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountResponseFromRaw : IFromRawJson<LinkedBankAccountResponse>
{
    /// <inheritdoc/>
    public LinkedBankAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedBankAccountResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(LinkedBankAccountResponseResponseTypeConverter))]
public enum LinkedBankAccountResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class LinkedBankAccountResponseResponseTypeConverter
    : JsonConverter<LinkedBankAccountResponseResponseType>
{
    public override LinkedBankAccountResponseResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => LinkedBankAccountResponseResponseType.Object,
            "array" => LinkedBankAccountResponseResponseType.Array,
            "error" => LinkedBankAccountResponseResponseType.Error,
            "none" => LinkedBankAccountResponseResponseType.None,
            _ => (LinkedBankAccountResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LinkedBankAccountResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LinkedBankAccountResponseResponseType.Object => "object",
                LinkedBankAccountResponseResponseType.Array => "array",
                LinkedBankAccountResponseResponseType.Error => "error",
                LinkedBankAccountResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
