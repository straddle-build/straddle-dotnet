using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Customers;
using Straddle.Models.Customers.Review;

namespace Straddle.Services.Customers;

/// <summary>
/// Customers are individuals or businesses that send or receive payments through your integration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the results of a customer's identity and fraud review. The response
    /// includes decisions, risk and correlation scores, reason codes, watchlist matches,
    /// and network alerts.
    /// </summary>
    Task<CustomerReviewResponse> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewListParams, CancellationToken)"/>
    Task<CustomerReviewResponse> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the verification decision for a customer. The customer's current `status`
    /// must be `review`.
    /// </summary>
    Task<CustomerResponse> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>
    Task<CustomerResponse> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/customers/{id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.List(ReviewListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerReviewResponse>> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewListParams, CancellationToken)"/>
    Task<HttpResponse<CustomerReviewResponse>> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/customers/{id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );
}
