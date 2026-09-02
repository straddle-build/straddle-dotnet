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
/// Personally identifiable information used for Patriot Act-compliant Know Your
/// Customer (KYC) verification.
/// </summary>
[JsonConverter(typeof(UnmaskedComplianceProfileConverter))]
public record class UnmaskedComplianceProfile : ModelBase
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

    public UnmaskedComplianceProfile(
        UnmaskedComplianceProfileIndividualComplianceProfile value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnmaskedComplianceProfile(
        UnmaskedComplianceProfileBusinessComplianceProfile value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnmaskedComplianceProfile(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnmaskedComplianceProfileIndividualComplianceProfile"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickIndividual(out var value)) {
    ///     // `value` is of type `UnmaskedComplianceProfileIndividualComplianceProfile`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickIndividual(
        [NotNullWhen(true)] out UnmaskedComplianceProfileIndividualComplianceProfile? value
    )
    {
        value = this.Value as UnmaskedComplianceProfileIndividualComplianceProfile;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnmaskedComplianceProfileBusinessComplianceProfile"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBusiness(out var value)) {
    ///     // `value` is of type `UnmaskedComplianceProfileBusinessComplianceProfile`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBusiness(
        [NotNullWhen(true)] out UnmaskedComplianceProfileBusinessComplianceProfile? value
    )
    {
        value = this.Value as UnmaskedComplianceProfileBusinessComplianceProfile;
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
    ///     (UnmaskedComplianceProfileIndividualComplianceProfile value) =&gt; {...},
    ///     (UnmaskedComplianceProfileBusinessComplianceProfile value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UnmaskedComplianceProfileIndividualComplianceProfile> individual,
        Action<UnmaskedComplianceProfileBusinessComplianceProfile> business
    )
    {
        switch (this.Value)
        {
            case UnmaskedComplianceProfileIndividualComplianceProfile value:
                individual(value);
                break;
            case UnmaskedComplianceProfileBusinessComplianceProfile value:
                business(value);
                break;
            default:
                throw new StraddleInvalidDataException(
                    "Data did not match any variant of UnmaskedComplianceProfile"
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
    ///     (UnmaskedComplianceProfileIndividualComplianceProfile value) =&gt; {...},
    ///     (UnmaskedComplianceProfileBusinessComplianceProfile value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UnmaskedComplianceProfileIndividualComplianceProfile, T> individual,
        Func<UnmaskedComplianceProfileBusinessComplianceProfile, T> business
    )
    {
        return this.Value switch
        {
            UnmaskedComplianceProfileIndividualComplianceProfile value => individual(value),
            UnmaskedComplianceProfileBusinessComplianceProfile value => business(value),
            _ => throw new StraddleInvalidDataException(
                "Data did not match any variant of UnmaskedComplianceProfile"
            ),
        };
    }

    public static implicit operator UnmaskedComplianceProfile(
        UnmaskedComplianceProfileIndividualComplianceProfile value
    ) => new(value);

    public static implicit operator UnmaskedComplianceProfile(
        UnmaskedComplianceProfileBusinessComplianceProfile value
    ) => new(value);

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
                "Data did not match any variant of UnmaskedComplianceProfile"
            );
        }
        this.Switch((individual) => individual.Validate(), (business) => business.Validate());
    }

    public virtual bool Equals(UnmaskedComplianceProfile? other) =>
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
            UnmaskedComplianceProfileIndividualComplianceProfile _ => 0,
            UnmaskedComplianceProfileBusinessComplianceProfile _ => 1,
            _ => -1,
        };
    }
}

sealed class UnmaskedComplianceProfileConverter : JsonConverter<UnmaskedComplianceProfile>
{
    public override UnmaskedComplianceProfile? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<UnmaskedComplianceProfileIndividualComplianceProfile>(
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
            var deserialized =
                JsonSerializer.Deserialize<UnmaskedComplianceProfileBusinessComplianceProfile>(
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
        UnmaskedComplianceProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Personally identifiable information used for Patriot Act-compliant Know Your
/// Customer (KYC) verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UnmaskedComplianceProfileIndividualComplianceProfile,
        UnmaskedComplianceProfileIndividualComplianceProfileFromRaw
    >)
)]
public sealed record class UnmaskedComplianceProfileIndividualComplianceProfile : JsonModel
{
    /// <summary>
    /// Date of birth in `YYYY-MM-DD` format. Required for Patriot Act-compliant KYC verification.
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
    /// Social Security number in `XXX-XX-XXXX` format. Required for Patriot
    /// Act-compliant KYC verification.
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

    public UnmaskedComplianceProfileIndividualComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedComplianceProfileIndividualComplianceProfile(
        UnmaskedComplianceProfileIndividualComplianceProfile unmaskedComplianceProfileIndividualComplianceProfile
    )
        : base(unmaskedComplianceProfileIndividualComplianceProfile) { }
#pragma warning restore CS8618

    public UnmaskedComplianceProfileIndividualComplianceProfile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedComplianceProfileIndividualComplianceProfile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedComplianceProfileIndividualComplianceProfileFromRaw.FromRawUnchecked"/>
    public static UnmaskedComplianceProfileIndividualComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedComplianceProfileIndividualComplianceProfileFromRaw
    : IFromRawJson<UnmaskedComplianceProfileIndividualComplianceProfile>
{
    /// <inheritdoc/>
    public UnmaskedComplianceProfileIndividualComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedComplianceProfileIndividualComplianceProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// Business registration information used for Patriot Act-compliant Know Your
/// Business (KYB) verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UnmaskedComplianceProfileBusinessComplianceProfile,
        UnmaskedComplianceProfileBusinessComplianceProfileFromRaw
    >)
)]
public sealed record class UnmaskedComplianceProfileBusinessComplianceProfile : JsonModel
{
    /// <summary>
    /// Employer Identification Number in `XX-XXXXXXX` format. Required for Patriot
    /// Act-compliant KYB verification.
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
    /// Official business name registered with the IRS.
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

    public UnmaskedComplianceProfileBusinessComplianceProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnmaskedComplianceProfileBusinessComplianceProfile(
        UnmaskedComplianceProfileBusinessComplianceProfile unmaskedComplianceProfileBusinessComplianceProfile
    )
        : base(unmaskedComplianceProfileBusinessComplianceProfile) { }
#pragma warning restore CS8618

    public UnmaskedComplianceProfileBusinessComplianceProfile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnmaskedComplianceProfileBusinessComplianceProfile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnmaskedComplianceProfileBusinessComplianceProfileFromRaw.FromRawUnchecked"/>
    public static UnmaskedComplianceProfileBusinessComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnmaskedComplianceProfileBusinessComplianceProfileFromRaw
    : IFromRawJson<UnmaskedComplianceProfileBusinessComplianceProfile>
{
    /// <inheritdoc/>
    public UnmaskedComplianceProfileBusinessComplianceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnmaskedComplianceProfileBusinessComplianceProfile.FromRawUnchecked(rawData);
}
