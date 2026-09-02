using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(JsonModelConverter<CustomerKycVerification, CustomerKycVerificationFromRaw>))]
public sealed record class CustomerKycVerification : JsonModel
{
    /// <summary>
    /// Results for each Know Your Customer (KYC) validation.
    /// </summary>
    public required Validations Validations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Validations>("validations");
        }
        init { this._rawData.Set("validations", value); }
    }

    /// <summary>
    /// Result codes from Know Your Customer (KYC) screening.
    /// </summary>
    public IReadOnlyList<string>? Codes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, VerificationDecision>? Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VerificationDecision>>(
                "decision"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decision", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Validations.Validate();
        _ = this.Codes;
        this.Decision?.Validate();
    }

    public CustomerKycVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerKycVerification(CustomerKycVerification customerKycVerification)
        : base(customerKycVerification) { }
#pragma warning restore CS8618

    public CustomerKycVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerKycVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerKycVerificationFromRaw.FromRawUnchecked"/>
    public static CustomerKycVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerKycVerification(Validations validations)
        : this()
    {
        this.Validations = validations;
    }
}

class CustomerKycVerificationFromRaw : IFromRawJson<CustomerKycVerification>
{
    /// <inheritdoc/>
    public CustomerKycVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerKycVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// Results for each Know Your Customer (KYC) validation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Validations, ValidationsFromRaw>))]
public sealed record class Validations : JsonModel
{
    /// <summary>
    /// Whether the customer's address passed validation.
    /// </summary>
    public bool? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Whether the customer's city passed validation.
    /// </summary>
    public bool? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// Whether the customer's date of birth passed validation.
    /// </summary>
    public bool? Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("dob");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dob", value);
        }
    }

    /// <summary>
    /// Whether the customer's email passed validation.
    /// </summary>
    public bool? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Whether the customer's first name passed validation.
    /// </summary>
    public bool? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("first_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    /// <summary>
    /// Whether the customer's last name passed validation.
    /// </summary>
    public bool? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("last_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    /// <summary>
    /// Whether the customer's phone passed validation.
    /// </summary>
    public bool? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <summary>
    /// Whether the customer's Social Security number passed validation.
    /// </summary>
    public bool? Ssn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ssn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ssn", value);
        }
    }

    /// <summary>
    /// Whether the customer's state passed validation.
    /// </summary>
    public bool? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Whether the customer's ZIP code passed validation.
    /// </summary>
    public bool? Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("zip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("zip", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.City;
        _ = this.Dob;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.Phone;
        _ = this.Ssn;
        _ = this.State;
        _ = this.Zip;
    }

    public Validations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Validations(Validations validations)
        : base(validations) { }
#pragma warning restore CS8618

    public Validations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Validations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationsFromRaw.FromRawUnchecked"/>
    public static Validations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationsFromRaw : IFromRawJson<Validations>
{
    /// <inheritdoc/>
    public Validations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Validations.FromRawUnchecked(rawData);
}
