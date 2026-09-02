using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.CapabilityRequests;

namespace Straddle.Services;

/// <summary>
/// Capability requests change the payment, customer, and consent types available to an account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICapabilityRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICapabilityRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICapabilityRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates one or more capability requests for an account and returns the resulting requests.
    /// </summary>
    Task<CapabilityRequestList> Create(
        CapabilityRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CapabilityRequestCreateParams, CancellationToken)"/>
    Task<CapabilityRequestList> Create(
        string accountID,
        CapabilityRequestCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of capability requests for an account. Filter the list by
    /// capability type, category, or status.
    /// </summary>
    Task<CapabilityRequestList> List(
        CapabilityRequestListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CapabilityRequestListParams, CancellationToken)"/>
    Task<CapabilityRequestList> List(
        string accountID,
        CapabilityRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICapabilityRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICapabilityRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICapabilityRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts/{account_id}/capability_requests</c>, but is otherwise the
    /// same as <see cref="ICapabilityRequestService.Create(CapabilityRequestCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CapabilityRequestList>> Create(
        CapabilityRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CapabilityRequestCreateParams, CancellationToken)"/>
    Task<HttpResponse<CapabilityRequestList>> Create(
        string accountID,
        CapabilityRequestCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{account_id}/capability_requests</c>, but is otherwise the
    /// same as <see cref="ICapabilityRequestService.List(CapabilityRequestListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CapabilityRequestList>> List(
        CapabilityRequestListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CapabilityRequestListParams, CancellationToken)"/>
    Task<HttpResponse<CapabilityRequestList>> List(
        string accountID,
        CapabilityRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
