using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Bridge;
using Straddle.Models.Paykeys;
using Straddle.Services.Paykeys;

namespace Straddle.Services;

/// <summary>
/// A paykey links a verified customer to a bank account without exposing bank
/// account details. Use a paykey to create charges and payouts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPaykeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPaykeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaykeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewService Review { get; }

    /// <summary>
    /// Returns a paykey by `id`, including the masked paykey value and bank account details.
    /// </summary>
    Task<PaykeyResponse> Retrieve(
        PaykeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaykeyRetrieveParams, CancellationToken)"/>
    Task<PaykeyResponse> Retrieve(
        string id,
        PaykeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of paykeys for the account. Optional query parameters
    /// filter, search, and sort the results.
    /// </summary>
    Task<PaykeySummaryList> List(
        PaykeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a paykey so it cannot be used for new payments.
    /// </summary>
    Task<PaykeyResponse> Cancel(
        PaykeyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PaykeyCancelParams, CancellationToken)"/>
    Task<PaykeyResponse> Cancel(
        string id,
        PaykeyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paykey by `id`, including the full paykey value and unmasked bank
    /// account details. Straddle must enable this endpoint for your account. Use this
    /// endpoint only when unmasked data is necessary.
    /// </summary>
    Task<UnmaskedPaykeyResponse> ListUnmasked(
        PaykeyListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(PaykeyListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedPaykeyResponse> ListUnmasked(
        string id,
        PaykeyListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts an asynchronous balance refresh for a paykey. The response returns the
    /// paykey before the refresh finishes.
    /// </summary>
    Task<PaykeyResponse> RefreshBalance(
        PaykeyRefreshBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshBalance(PaykeyRefreshBalanceParams, CancellationToken)"/>
    Task<PaykeyResponse> RefreshBalance(
        string id,
        PaykeyRefreshBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts a new verification review for a paykey. The review runs asynchronously.
    /// Webhooks and the paykey review endpoint return updated results.
    /// </summary>
    Task<PaykeyResponse> RefreshReview(
        PaykeyRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshReview(PaykeyRefreshReviewParams, CancellationToken)"/>
    Task<PaykeyResponse> RefreshReview(
        string id,
        PaykeyRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paykey by `id`, including the full paykey value and masked bank account details.
    /// </summary>
    Task<RevealedPaykeyResponse> Reveal(
        PaykeyRevealParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reveal(PaykeyRevealParams, CancellationToken)"/>
    Task<RevealedPaykeyResponse> Reveal(
        string id,
        PaykeyRevealParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unblocks a paykey that was blocked by an `R29` return. The paykey must not have
    /// been unblocked before.
    /// </summary>
    Task<PaykeyResponse> Unblock(
        PaykeyUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unblock(PaykeyUnblockParams, CancellationToken)"/>
    Task<PaykeyResponse> Unblock(
        string id,
        PaykeyUnblockParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPaykeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaykeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaykeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IReviewServiceWithRawResponse Review { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/paykeys/{id}</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.Retrieve(PaykeyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> Retrieve(
        PaykeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaykeyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> Retrieve(
        string id,
        PaykeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/paykeys</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.List(PaykeyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeySummaryList>> List(
        PaykeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/paykeys/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.Cancel(PaykeyCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> Cancel(
        PaykeyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PaykeyCancelParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> Cancel(
        string id,
        PaykeyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/paykeys/{id}/unmasked</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.ListUnmasked(PaykeyListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedPaykeyResponse>> ListUnmasked(
        PaykeyListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(PaykeyListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedPaykeyResponse>> ListUnmasked(
        string id,
        PaykeyListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/paykeys/{id}/refresh_balance</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.RefreshBalance(PaykeyRefreshBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> RefreshBalance(
        PaykeyRefreshBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshBalance(PaykeyRefreshBalanceParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> RefreshBalance(
        string id,
        PaykeyRefreshBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/paykeys/{id}/refresh_review</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.RefreshReview(PaykeyRefreshReviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> RefreshReview(
        PaykeyRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RefreshReview(PaykeyRefreshReviewParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> RefreshReview(
        string id,
        PaykeyRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/paykeys/{id}/reveal</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.Reveal(PaykeyRevealParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RevealedPaykeyResponse>> Reveal(
        PaykeyRevealParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reveal(PaykeyRevealParams, CancellationToken)"/>
    Task<HttpResponse<RevealedPaykeyResponse>> Reveal(
        string id,
        PaykeyRevealParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/paykeys/{id}/unblock</c>, but is otherwise the
    /// same as <see cref="IPaykeyService.Unblock(PaykeyUnblockParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> Unblock(
        PaykeyUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unblock(PaykeyUnblockParams, CancellationToken)"/>
    Task<HttpResponse<PaykeyResponse>> Unblock(
        string id,
        PaykeyUnblockParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
