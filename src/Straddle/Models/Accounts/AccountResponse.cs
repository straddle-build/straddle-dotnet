using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using System = System;

namespace Straddle.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountResponse, AccountResponseFromRaw>))]
public sealed record class AccountResponse : JsonModel
{
    public required Account Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Account>("data");
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
    public required ApiEnum<string, AccountResponseResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountResponseResponseType>>(
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

    public AccountResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountResponse(AccountResponse accountResponse)
        : base(accountResponse) { }
#pragma warning restore CS8618

    public AccountResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountResponseFromRaw.FromRawUnchecked"/>
    public static AccountResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountResponseFromRaw : IFromRawJson<AccountResponse>
{
    /// <inheritdoc/>
    public AccountResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(AccountResponseResponseTypeConverter))]
public enum AccountResponseResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class AccountResponseResponseTypeConverter : JsonConverter<AccountResponseResponseType>
{
    public override AccountResponseResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => AccountResponseResponseType.Object,
            "array" => AccountResponseResponseType.Array,
            "error" => AccountResponseResponseType.Error,
            "none" => AccountResponseResponseType.None,
            _ => (AccountResponseResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountResponseResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountResponseResponseType.Object => "object",
                AccountResponseResponseType.Array => "array",
                AccountResponseResponseType.Error => "error",
                AccountResponseResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
