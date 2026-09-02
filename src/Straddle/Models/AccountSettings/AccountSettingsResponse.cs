using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Models.AccountSettings;

[JsonConverter(typeof(JsonModelConverter<AccountSettingsResponse, AccountSettingsResponseFromRaw>))]
public sealed record class AccountSettingsResponse : JsonModel
{
    public required AccountSettingsAccountSettings Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountSettingsAccountSettings>("data");
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
    public required ApiEnum<
        string,
        global::Straddle.Models.AccountSettings.ResponseType
    > ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.AccountSettings.ResponseType>
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

    public AccountSettingsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSettingsResponse(AccountSettingsResponse accountSettingsResponse)
        : base(accountSettingsResponse) { }
#pragma warning restore CS8618

    public AccountSettingsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSettingsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSettingsResponseFromRaw.FromRawUnchecked"/>
    public static AccountSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountSettingsResponseFromRaw : IFromRawJson<AccountSettingsResponse>
{
    /// <inheritdoc/>
    public AccountSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountSettingsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the response content is structured.
/// - `object` means `data` contains one JSON object.
/// - `array` means `data` contains an array of objects.
/// - `error` means `error` contains error details.
/// - `none` means the response has no data.
/// </summary>
[JsonConverter(typeof(global::Straddle.Models.AccountSettings.ResponseTypeConverter))]
public enum ResponseType
{
    Object,
    Array,
    Error,
    None,
}

sealed class ResponseTypeConverter
    : JsonConverter<global::Straddle.Models.AccountSettings.ResponseType>
{
    public override global::Straddle.Models.AccountSettings.ResponseType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Straddle.Models.AccountSettings.ResponseType.Object,
            "array" => global::Straddle.Models.AccountSettings.ResponseType.Array,
            "error" => global::Straddle.Models.AccountSettings.ResponseType.Error,
            "none" => global::Straddle.Models.AccountSettings.ResponseType.None,
            _ => (global::Straddle.Models.AccountSettings.ResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Straddle.Models.AccountSettings.ResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Straddle.Models.AccountSettings.ResponseType.Object => "object",
                global::Straddle.Models.AccountSettings.ResponseType.Array => "array",
                global::Straddle.Models.AccountSettings.ResponseType.Error => "error",
                global::Straddle.Models.AccountSettings.ResponseType.None => "none",
                _ => throw new StraddleInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
