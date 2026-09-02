using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Payments;

namespace Straddle.Services;

/// <summary>
/// Payments provide a combined view of charges and payouts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a paged list of charges and payouts that match the filters.
    /// </summary>
    Task<PaymentSummaryList> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/payments</c>, but is otherwise the
    /// same as <see cref="IPaymentService.List(PaymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaymentSummaryList>> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
