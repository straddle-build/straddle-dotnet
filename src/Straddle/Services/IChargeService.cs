using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Charges;

namespace Straddle.Services;

/// <summary>
/// Charges debit a customer's bank account through a paykey.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IChargeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChargeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a charge against a customer's paykey. Straddle submits the charge for
    /// processing on `payment_date` unless the charge is on hold.
    /// </summary>
    Task<ChargeResponse> Create(
        ChargeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a charge by its unique identifier.
    /// </summary>
    Task<ChargeResponse> Retrieve(
        ChargeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChargeRetrieveParams, CancellationToken)"/>
    Task<ChargeResponse> Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the description, amount, `payment_date`, or metadata. The charge must have
    /// a status of `created` or `on_hold`.
    /// </summary>
    Task<ChargeResponse> Update(
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ChargeUpdateParams, CancellationToken)"/>
    Task<ChargeResponse> Update(
        string id,
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a charge. The charge must have a status of `created`, `scheduled`, or `on_hold`.
    /// </summary>
    Task<ChargeResponse> Cancel(
        ChargeCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ChargeCancelParams, CancellationToken)"/>
    Task<ChargeResponse> Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Places a charge on hold to prevent submission for processing. The charge must have
    /// a status of `created` or `scheduled`.
    /// </summary>
    Task<ChargeResponse> Hold(
        ChargeHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hold(ChargeHoldParams, CancellationToken)"/>
    Task<ChargeResponse> Hold(
        string id,
        ChargeHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a charge with its sensitive fields unmasked.
    /// </summary>
    Task<UnmaskedChargeResponse> ListUnmasked(
        ChargeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(ChargeListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedChargeResponse> ListUnmasked(
        string id,
        ChargeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a payout to return funds from a paid charge to the customer's bank
    /// account. The payout is linked to the charge through `related_payments`. A charge
    /// can be refunded once, either fully or partially.
    /// </summary>
    Task<PayoutResponse> Refund(
        ChargeRefundParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Refund(ChargeRefundParams, CancellationToken)"/>
    Task<PayoutResponse> Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Releases a charge from `on_hold` and returns it to `created` for submission on `payment_date`.
    /// </summary>
    Task<ChargeResponse> Release(
        ChargeReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(ChargeReleaseParams, CancellationToken)"/>
    Task<ChargeResponse> Release(
        string id,
        ChargeReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new charge from a failed, reversed, or cancelled charge. The request can
    /// override `description`, `external_id`, and `payment_date`. Other payment details
    /// come from the original charge.
    /// </summary>
    Task<ChargeResponse> Resubmit(
        ChargeResubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resubmit(ChargeResubmitParams, CancellationToken)"/>
    Task<ChargeResponse> Resubmit(
        string id,
        ChargeResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a proof-of-authorization document for a charge. A later upload adds
    /// another document and does not replace an existing one.
    /// </summary>
    Task<ChargeResponse> UploadAuthorizationProof(
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadAuthorizationProof(ChargeUploadAuthorizationProofParams, CancellationToken)"/>
    Task<ChargeResponse> UploadAuthorizationProof(
        string id,
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChargeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChargeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/charges</c>, but is otherwise the
    /// same as <see cref="IChargeService.Create(ChargeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Create(
        ChargeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/charges/{id}</c>, but is otherwise the
    /// same as <see cref="IChargeService.Retrieve(ChargeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Retrieve(
        ChargeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChargeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/charges/{id}</c>, but is otherwise the
    /// same as <see cref="IChargeService.Update(ChargeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Update(
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ChargeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Update(
        string id,
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/charges/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="IChargeService.Cancel(ChargeCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Cancel(
        ChargeCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ChargeCancelParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/charges/{id}/hold</c>, but is otherwise the
    /// same as <see cref="IChargeService.Hold(ChargeHoldParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Hold(
        ChargeHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hold(ChargeHoldParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Hold(
        string id,
        ChargeHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/charges/{id}/unmask</c>, but is otherwise the
    /// same as <see cref="IChargeService.ListUnmasked(ChargeListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedChargeResponse>> ListUnmasked(
        ChargeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(ChargeListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedChargeResponse>> ListUnmasked(
        string id,
        ChargeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/charges/{id}/refund</c>, but is otherwise the
    /// same as <see cref="IChargeService.Refund(ChargeRefundParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayoutResponse>> Refund(
        ChargeRefundParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Refund(ChargeRefundParams, CancellationToken)"/>
    Task<HttpResponse<PayoutResponse>> Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/charges/{id}/release</c>, but is otherwise the
    /// same as <see cref="IChargeService.Release(ChargeReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Release(
        ChargeReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(ChargeReleaseParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Release(
        string id,
        ChargeReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/charges/{id}/resubmit</c>, but is otherwise the
    /// same as <see cref="IChargeService.Resubmit(ChargeResubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> Resubmit(
        ChargeResubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resubmit(ChargeResubmitParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> Resubmit(
        string id,
        ChargeResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/charges/{id}/authorization</c>, but is otherwise the
    /// same as <see cref="IChargeService.UploadAuthorizationProof(ChargeUploadAuthorizationProofParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChargeResponse>> UploadAuthorizationProof(
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadAuthorizationProof(ChargeUploadAuthorizationProofParams, CancellationToken)"/>
    Task<HttpResponse<ChargeResponse>> UploadAuthorizationProof(
        string id,
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    );
}
