using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<
        BusinessCustomerRepresentative,
        BusinessCustomerRepresentativeFromRaw
    >)
)]
public sealed record class BusinessCustomerRepresentative : JsonModel
{
    /// <summary>
    /// Full name of the representative.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Email address of the representative.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Phone number of the representative.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Email;
        _ = this.Phone;
    }

    public BusinessCustomerRepresentative() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessCustomerRepresentative(
        BusinessCustomerRepresentative businessCustomerRepresentative
    )
        : base(businessCustomerRepresentative) { }
#pragma warning restore CS8618

    public BusinessCustomerRepresentative(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessCustomerRepresentative(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessCustomerRepresentativeFromRaw.FromRawUnchecked"/>
    public static BusinessCustomerRepresentative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BusinessCustomerRepresentative(string name)
        : this()
    {
        this.Name = name;
    }
}

class BusinessCustomerRepresentativeFromRaw : IFromRawJson<BusinessCustomerRepresentative>
{
    /// <inheritdoc/>
    public BusinessCustomerRepresentative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BusinessCustomerRepresentative.FromRawUnchecked(rawData);
}
