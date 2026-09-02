using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Accounts;

namespace Straddle.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<UnmaskedCustomerResponse, UnmaskedCustomerResponseFromRaw>)
)]
public sealed record class UnmaskedCustomerResponse : JsonModel
{
    public required UnmaskedCustomer Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnmaskedCustomer>("data");
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
    /// Shape of the response envelope.
    /// - `object` means `data` contains one JSON object.
    /// - `array` means `data` contains an array of JSON objects.
    /// - `error` means `error` contains the error details.
    /// - `none` means the response contains no data.
    /// </summary>
    public required ApiEnum<string, global::Straddle.Models.Bridge.ResponseType> ResponseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Straddle.Models.Bridge.ResponseType>
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

    public UnmaskedCustomerResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedCustomerResponse(UnmaskedCustomerResponse unmaskedCustomerResponse)
        : base(unmaskedCustomerResponse) { }
#pragma warning restore CS8618

    public UnmaskedCustomerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedCustomerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedCustomerResponseFromRaw.FromRawUnchecked"/>
    public static UnmaskedCustomerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedCustomerResponseFromRaw : IFromRawJson<UnmaskedCustomerResponse>
{
    /// <inheritdoc/>
    public UnmaskedCustomerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedCustomerResponse.FromRawUnchecked(rawData);
}
