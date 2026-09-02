using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Charges;
using Straddle.Models.Payouts;

namespace Straddle.Services;

/// <summary>
/// Payouts send money to a customer's bank account through a paykey.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPayoutService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPayoutServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a payout to a customer's bank account. Straddle submits the payout for
    /// processing on `payment_date` unless the payout is on hold.
    /// </summary>
    Task<PayoutResponse> Create(
        PayoutCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a payout by its unique identifier.
    /// </summary>
    Task<PayoutResponse> Retrieve(
        PayoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PayoutRetrieveParams, CancellationToken)"/>
    Task<PayoutResponse> Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the description, amount, `payment_date`, or metadata. The payout must have
    /// a status of `created` or `on_hold`.
    /// </summary>
    Task<PayoutResponse> Update(
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PayoutUpdateParams, CancellationToken)"/>
    Task<PayoutResponse> Update(
        string id,
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a payout. The payout must have a status of `created`, `scheduled`, or `on_hold`.
    /// </summary>
    Task<PayoutResponse> Cancel(
        PayoutCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PayoutCancelParams, CancellationToken)"/>
    Task<PayoutResponse> Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Places a payout on hold to prevent submission for processing. The payout must have
    /// a status of `created` or `scheduled`.
    /// </summary>
    Task<PayoutResponse> Hold(
        PayoutHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hold(PayoutHoldParams, CancellationToken)"/>
    Task<PayoutResponse> Hold(
        string id,
        PayoutHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a payout with its sensitive fields unmasked.
    /// </summary>
    Task<UnmaskedPayoutResponse> ListUnmasked(
        PayoutListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(PayoutListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedPayoutResponse> ListUnmasked(
        string id,
        PayoutListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Releases a payout from `on_hold` and returns it to `created` for submission on `payment_date`.
    /// </summary>
    Task<PayoutResponse> Release(
        PayoutReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PayoutReleaseParams, CancellationToken)"/>
    Task<PayoutResponse> Release(
        string id,
        PayoutReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new payout from a failed, reversed, or cancelled payout. The request can
    /// override `description`, `external_id`, and `payment_date`. Other payment details
    /// come from the original payout.
    /// </summary>
    Task<PayoutResponse> Resubmit(
        PayoutResubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resubmit(PayoutResubmitParams, CancellationToken)"/>
    Task<PayoutResponse> Resubmit(
        string id,
        PayoutResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a proof-of-authorization document for a payout. A later upload adds
    /// another document and does not replace an existing one.
    /// </summary>
    Task<PayoutResponse> UploadAuthorizationProof(
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadAuthorizationProof(PayoutUploadAuthorizationProofParams, CancellationToken)"/>
    Task<PayoutResponse> UploadAuthorizationProof(
        string id,
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPayoutService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPayoutServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayoutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/payouts</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Create(PayoutCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Create(
        PayoutCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/payouts/{id}</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Retrieve(PayoutRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Retrieve(
        PayoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PayoutRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/payouts/{id}</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Update(PayoutUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Update(
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PayoutUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Update(
        string id,
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/payouts/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Cancel(PayoutCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Cancel(
        PayoutCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PayoutCancelParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/payouts/{id}/hold</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Hold(PayoutHoldParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Hold(
        PayoutHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hold(PayoutHoldParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Hold(
        string id,
        PayoutHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/payouts/{id}/unmask</c>, but is otherwise the
    /// same as <see cref="IPayoutService.ListUnmasked(PayoutListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedPayoutResponse>> ListUnmasked(
        PayoutListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(PayoutListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedPayoutResponse>> ListUnmasked(
        string id,
        PayoutListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/payouts/{id}/release</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Release(PayoutReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Release(
        PayoutReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PayoutReleaseParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Release(
        string id,
        PayoutReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/payouts/{id}/resubmit</c>, but is otherwise the
    /// same as <see cref="IPayoutService.Resubmit(PayoutResubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Resubmit(
        PayoutResubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resubmit(PayoutResubmitParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Resubmit(
        string id,
        PayoutResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/payouts/{id}/authorization</c>, but is otherwise the
    /// same as <see cref="IPayoutService.UploadAuthorizationProof(PayoutUploadAuthorizationProofParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> UploadAuthorizationProof(
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadAuthorizationProof(PayoutUploadAuthorizationProofParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> UploadAuthorizationProof(
        string id,
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );
}
