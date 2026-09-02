using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Bridge;
using Straddle.Models.Paykeys.Review;

namespace Straddle.Services.Paykeys;

/// <summary>
/// A paykey links a verified customer to a bank account without exposing bank
/// account details. Use a paykey to create charges and payouts.
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
    /// Returns a paykey verification review, including the decision, score breakdowns, and result codes.
    /// </summary>
    Task<PaykeyReviewResponse> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewListParams, CancellationToken)"/>
    Task<PaykeyReviewResponse> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the verification decision for a paykey. The paykey's current `status` must be `review`.
    /// </summary>
    Task<PaykeyResponse> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>
    Task<PaykeyResponse> SetVerificationDecision(
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
    /// Returns a raw HTTP response for <c>get /v1/paykeys/{id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.List(ReviewListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyReviewResponse>> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ReviewListParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyReviewResponse>> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/paykeys/{id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetVerificationDecision(ReviewSetVerificationDecisionParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    );
}
