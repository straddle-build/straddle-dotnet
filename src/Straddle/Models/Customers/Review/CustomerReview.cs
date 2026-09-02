using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(JsonModelConverter<CustomerReview, CustomerReviewFromRaw>))]
public sealed record class CustomerReview : JsonModel
{
    public required Customer CustomerDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Customer>("customer_details");
        }
        init { this._rawData.Set("customer_details", value); }
    }

    public CustomerIdentityVerification? IdentityDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerIdentityVerification>("identity_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identity_details", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CustomerDetails.Validate();
        this.IdentityDetails?.Validate();
    }

    public CustomerReview() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerReview(CustomerReview customerReview)
        : base(customerReview) { }
#pragma warning restore CS8618

    public CustomerReview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerReview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerReviewFromRaw.FromRawUnchecked"/>
    public static CustomerReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerReview(Customer customerDetails)
        : this()
    {
        this.CustomerDetails = customerDetails;
    }
}

class CustomerReviewFromRaw : IFromRawJson<CustomerReview>
{
    /// <inheritdoc/>
    public CustomerReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerReview.FromRawUnchecked(rawData);
}
