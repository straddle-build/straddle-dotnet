using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Customers;
using Straddle.Services.Customers;

namespace Straddle.Services;

/// <summary>
/// Customers are individuals or businesses that send or receive payments through your integration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewService Review { get; }

    /// <summary>
    /// Creates a customer and starts identity, fraud, and risk assessments.
    /// </summary>
    Task<CustomerResponse> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a customer by `id`.
    /// </summary>
    Task<CustomerResponse> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<CustomerResponse> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing customer's profile, status, and metadata.
    /// </summary>
    Task<CustomerResponse> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<CustomerResponse> Update(
        string id,
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of customers for the account. Optional query parameters
    /// filter, search, and sort the results.
    /// </summary>
    Task<CustomerSummaryList> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a customer record. The deletion cannot be undone. Use this
    /// endpoint only to meet regulatory or privacy requirements.
    /// </summary>
    Task<CustomerResponse> Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task<CustomerResponse> Delete(
        string id,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns unmasked details for a customer, including personally identifiable
    /// information. Straddle must enable this endpoint for your account. Use this
    /// endpoint only when unmasked data is necessary.
    /// </summary>
    Task<UnmaskedCustomerResponse> ListUnmasked(
        CustomerListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(CustomerListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedCustomerResponse> ListUnmasked(
        string id,
        CustomerListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts a new identity review for a customer. The review runs asynchronously.
    /// Webhooks and the customer review endpoint return updated results.
    /// </summary>
    Task<CustomerResponse> RefreshReview(
        CustomerRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshReview(CustomerRefreshReviewParams, CancellationToken)"/>
    Task<CustomerResponse> RefreshReview(
        string id,
        CustomerRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewServiceWithRawResponse Review { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Create(CustomerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/customers/{id}</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Retrieve(CustomerRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/customers/{id}</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Update(CustomerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Update(
        string id,
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.List(CustomerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerSummaryList>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/customers/{id}</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Delete(CustomerDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Delete(
        string id,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/customers/{id}/unmasked</c>, but is otherwise the
    /// same as <see cref="ICustomerService.ListUnmasked(CustomerListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedCustomerResponse>> ListUnmasked(
        CustomerListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(CustomerListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedCustomerResponse>> ListUnmasked(
        string id,
        CustomerListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/customers/{id}/refresh_review</c>, but is otherwise the
    /// same as <see cref="ICustomerService.RefreshReview(CustomerRefreshReviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> RefreshReview(
        CustomerRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshReview(CustomerRefreshReviewParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> RefreshReview(
        string id,
        CustomerRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
