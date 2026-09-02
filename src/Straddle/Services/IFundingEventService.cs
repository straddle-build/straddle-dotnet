using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.FundingEvents;

namespace Straddle.Services;

/// <summary>
/// Funding events group charge and payout activity into transfers between Straddle
/// and your linked bank account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFundingEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFundingEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFundingEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a funding event by its unique identifier, including its current status,
    /// status history, and linked bank account details when available.
    /// </summary>
    Task<FundingEventResponse> Retrieve(
        FundingEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FundingEventRetrieveParams, CancellationToken)"/>
    Task<FundingEventResponse> Retrieve(
        string id,
        FundingEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of funding events that match the specified filters.
    /// </summary>
    Task<FundingEventSummaryList> List(
        FundingEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of payments included in the funding event.
    /// </summary>
    Task<FundingEventPaymentList> ListPayments(
        FundingEventListPaymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPayments(FundingEventListPaymentsParams, CancellationToken)"/>
    Task<FundingEventPaymentList> ListPayments(
        string id,
        FundingEventListPaymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a funding event for unfunded charge or payout activity in the sandbox and
    /// returns its ID. This endpoint is unavailable in production.
    /// </summary>
    Task<FundingEventSimulation> Simulate(
        FundingEventSimulateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFundingEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFundingEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFundingEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/funding_events/{id}</c>, but is otherwise the
    /// same as <see cref="IFundingEventService.Retrieve(FundingEventRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FundingEventResponse>> Retrieve(
        FundingEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FundingEventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FundingEventResponse>> Retrieve(
        string id,
        FundingEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/funding_events</c>, but is otherwise the
    /// same as <see cref="IFundingEventService.List(FundingEventListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FundingEventSummaryList>> List(
        FundingEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/funding_event_payments/{id}</c>, but is otherwise the
    /// same as <see cref="IFundingEventService.ListPayments(FundingEventListPaymentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FundingEventPaymentList>> ListPayments(
        FundingEventListPaymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPayments(FundingEventListPaymentsParams, CancellationToken)"/>
    Task<HttpResponse<FundingEventPaymentList>> ListPayments(
        string id,
        FundingEventListPaymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/funding_events/simulate</c>, but is otherwise the
    /// same as <see cref="IFundingEventService.Simulate(FundingEventSimulateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FundingEventSimulation>> Simulate(
        FundingEventSimulateParams parameters,
        CancellationToken cancellationToken = default
    );
}
