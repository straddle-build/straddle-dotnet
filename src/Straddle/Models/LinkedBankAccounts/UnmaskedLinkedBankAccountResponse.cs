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
    typeof(JsonModelConverter<
        UnmaskedLinkedBankAccountResponse,
        UnmaskedLinkedBankAccountResponseFromRaw
    >)
)]
public sealed record class UnmaskedLinkedBankAccountResponse : JsonModel
{
    public required UnmaskedLinkedBankAccount Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnmaskedLinkedBankAccount>("data");
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
    public required ApiEnum<string, UnmaskedLinkedBankAccountResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UnmaskedLinkedBankAccountResponseResponseType>
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

    public UnmaskedLinkedBankAccountResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedLinkedBankAccountResponse(
        UnmaskedLinkedBankAccountResponse unmaskedLinkedBankAccountResponse
    )
        : base(unmaskedLinkedBankAccountResponse) { }
#pragma warning restore CS8618

    public UnmaskedLinkedBankAccountResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedLinkedBankAccountResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedLinkedBankAccountResponseFromRaw.FromRawUnchecked"/>
    public static UnmaskedLinkedBankAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedLinkedBankAccountResponseFromRaw : IFromRawJson<UnmaskedLinkedBankAccountResponse>
{
    /// <inheritdoc/>
    public UnmaskedLinkedBankAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedLinkedBankAccountResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(UnmaskedLinkedBankAccountResponseResponseTypeConverter))]
public enum UnmaskedLinkedBankAccountResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class UnmaskedLinkedBankAccountResponseResponseTypeConverter
    : JsonConverter<UnmaskedLinkedBankAccountResponseResponseType>
{
    public override UnmaskedLinkedBankAccountResponseResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => UnmaskedLinkedBankAccountResponseResponseType.Object,
            "array" => UnmaskedLinkedBankAccountResponseResponseType.Array,
            "error" => UnmaskedLinkedBankAccountResponseResponseType.Error,
            "none" => UnmaskedLinkedBankAccountResponseResponseType.None,
            _ => (UnmaskedLinkedBankAccountResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnmaskedLinkedBankAccountResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnmaskedLinkedBankAccountResponseResponseType.Object => "object",
                UnmaskedLinkedBankAccountResponseResponseType.Array => "array",
                UnmaskedLinkedBankAccountResponseResponseType.Error => "error",
                UnmaskedLinkedBankAccountResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
