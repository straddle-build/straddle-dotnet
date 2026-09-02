using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Services;

namespace Straddle;

/// <summary>
/// A client for interacting with the Straddle REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStraddleClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Send the API key as a bearer token in the `Authorization` header.
    /// </summary>
    string Bearer { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStraddleClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStraddleClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountService Accounts { get; }

    ICapabilityRequestService CapabilityRequests { get; }

    ILinkedBankAccountService LinkedBankAccounts { get; }

    IOrganizationService Organizations { get; }

    IRepresentativeService Representatives { get; }

    IBridgeService Bridge { get; }

    ICustomerService Customers { get; }

    IPaykeyService Paykeys { get; }

    IChargeService Charges { get; }

    IFundingEventService FundingEvents { get; }

    IPaymentService Payments { get; }

    IPayoutService Payouts { get; }

    IAccountSettingService AccountSettings { get; }

    IWebhookService Webhooks { get; }
}

/// <summary>
/// A view of <see cref="IStraddleClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IStraddleClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Send the API key as a bearer token in the `Authorization` header.
    /// </summary>
    string Bearer { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStraddleClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountServiceWithRawResponse Accounts { get; }

    ICapabilityRequestServiceWithRawResponse CapabilityRequests { get; }

    ILinkedBankAccountServiceWithRawResponse LinkedBankAccounts { get; }

    IOrganizationServiceWithRawResponse Organizations { get; }

    IRepresentativeServiceWithRawResponse Representatives { get; }

    IBridgeServiceWithRawResponse Bridge { get; }

    ICustomerServiceWithRawResponse Customers { get; }

    IPaykeyServiceWithRawResponse Paykeys { get; }

    IChargeServiceWithRawResponse Charges { get; }

    IFundingEventServiceWithRawResponse FundingEvents { get; }

    IPaymentServiceWithRawResponse Payments { get; }

    IPayoutServiceWithRawResponse Payouts { get; }

    IAccountSettingServiceWithRawResponse AccountSettings { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
    /// Sends a request to the Straddle REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
