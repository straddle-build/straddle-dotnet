using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Customers;

/// <summary>
/// Masked personally identifiable information used for Patriot Act-compliant KYC verification.
/// </summary>
[JsonConverter(typeof(ComplianceProfileConverter))]
public record class ComplianceProfile : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ComplianceProfile(IndividualComplianceProfile value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComplianceProfile(BusinessComplianceProfile value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComplianceProfile(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IndividualComplianceProfile"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickIndividual(out var value)) {
    ///     // `value` is of type `IndividualComplianceProfile`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickIndividual([NotNullWhen(true)] out IndividualComplianceProfile? value)
    {
        value = this.Value as IndividualComplianceProfile;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BusinessComplianceProfile"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBusiness(out var value)) {
    ///     // `value` is of type `BusinessComplianceProfile`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBusiness([NotNullWhen(true)] out BusinessComplianceProfile? value)
    {
        value = this.Value as BusinessComplianceProfile;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IndividualComplianceProfile value) =&gt; {...},
    ///     (BusinessComplianceProfile value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IndividualComplianceProfile> individual,
        Action<BusinessComplianceProfile> business
    )
    {
        switch (this.Value)
        {
            case IndividualComplianceProfile value:
                individual(value);
                break;
            case BusinessComplianceProfile value:
                business(value);
                break;
            default:
                throw new StraddleInvalidDataException(
                    "Data did not match any variant of ComplianceProfile"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IndividualComplianceProfile value) =&gt; {...},
    ///     (BusinessComplianceProfile value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IndividualComplianceProfile, T> individual,
        Func<BusinessComplianceProfile, T> business
    )
    {
        return this.Value switch
        {
            IndividualComplianceProfile value => individual(value),
            BusinessComplianceProfile value => business(value),
            _ => throw new StraddleInvalidDataException(
                "Data did not match any variant of ComplianceProfile"
            ),
        };
    }

    public static implicit operator ComplianceProfile(IndividualComplianceProfile value) =>
        new(value);

    public static implicit operator ComplianceProfile(BusinessComplianceProfile value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StraddleInvalidDataException(
                "Data did not match any variant of ComplianceProfile"
            );
        }
        this.Switch((individual) => individual.Validate(), (business) => business.Validate());
    }

    public virtual bool Equals(ComplianceProfile? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IndividualComplianceProfile _ => 0,
            BusinessComplianceProfile _ => 1,
            _ => -1,
        };
    }
}

sealed class ComplianceProfileConverter : JsonConverter<ComplianceProfile>
{
    public override ComplianceProfile? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<IndividualComplianceProfile>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BusinessComplianceProfile>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComplianceProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Masked personally identifiable information used for Patriot Act-compliant KYC verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IndividualComplianceProfile, IndividualComplianceProfileFromRaw>)
)]
public sealed record class IndividualComplianceProfile : JsonModel
{
    /// <summary>
    /// Masked date of birth in `****-**-**` format.
    /// </summary>
    public required string? Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dob");
        }
        init { this._rawData.Set("dob", value); }
    }

    /// <summary>
    /// Masked Social Security number in `***-**-****` format.
    /// </summary>
    public required string? Ssn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ssn");
        }
        init { this._rawData.Set("ssn", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dob;
        _ = this.Ssn;
    }

    public IndividualComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IndividualComplianceProfile(IndividualComplianceProfile individualComplianceProfile)
        : base(individualComplianceProfile) { }
#pragma warning restore CS8618

    public IndividualComplianceProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualComplianceProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualComplianceProfileFromRaw.FromRawUnchecked"/>
    public static IndividualComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualComplianceProfileFromRaw : IFromRawJson<IndividualComplianceProfile>
{
    /// <inheritdoc/>
    public IndividualComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IndividualComplianceProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// Masked business registration information used for Patriot Act-compliant KYB verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BusinessComplianceProfile, BusinessComplianceProfileFromRaw>)
)]
public sealed record class BusinessComplianceProfile : JsonModel
{
    /// <summary>
    /// Masked Employer Identification Number in `**-*******` format.
    /// </summary>
    public required string? Ein
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ein");
        }
        init { this._rawData.Set("ein", value); }
    }

    /// <summary>
    /// Official registered business name associated with `ein`.
    /// </summary>
    public required string? LegalBusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_business_name");
        }
        init { this._rawData.Set("legal_business_name", value); }
    }

    /// <summary>
    /// Representatives associated with the business. Valid only for `business` customers.
    /// </summary>
    public IReadOnlyList<BusinessCustomerRepresentative>? Representatives
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BusinessCustomerRepresentative>>(
                "representatives"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BusinessCustomerRepresentative>?>(
                "representatives",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Official business website URL.
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ein;
        _ = this.LegalBusinessName;
        foreach (var item in this.Representatives ?? [])
        {
            item.Validate();
        }
        _ = this.Website;
    }

    public BusinessComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessComplianceProfile(BusinessComplianceProfile businessComplianceProfile)
        : base(businessComplianceProfile) { }
#pragma warning restore CS8618

    public BusinessComplianceProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessComplianceProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessComplianceProfileFromRaw.FromRawUnchecked"/>
    public static BusinessComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BusinessComplianceProfileFromRaw : IFromRawJson<BusinessComplianceProfile>
{
    /// <inheritdoc/>
    public BusinessComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BusinessComplianceProfile.FromRawUnchecked(rawData);
}
