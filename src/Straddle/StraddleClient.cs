using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Services;

namespace Straddle;

/// <inheritdoc/>
public sealed class StraddleClient : IStraddleClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string Bearer
    {
        get { return this._options.Bearer; }
        init { this._options.Bearer = value; }
    }

    readonly Lazy<IStraddleClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStraddleClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IStraddleClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StraddleClient(modifier(this._options));
    }

    readonly Lazy<IAccountService> _accounts;
    public IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<ICapabilityRequestService> _capabilityRequests;
    public ICapabilityRequestService CapabilityRequests
    {
        get { return _capabilityRequests.Value; }
    }

    readonly Lazy<ILinkedBankAccountService> _linkedBankAccounts;
    public ILinkedBankAccountService LinkedBankAccounts
    {
        get { return _linkedBankAccounts.Value; }
    }

    readonly Lazy<IOrganizationService> _organizations;
    public IOrganizationService Organizations
    {
        get { return _organizations.Value; }
    }

    readonly Lazy<IRepresentativeService> _representatives;
    public IRepresentativeService Representatives
    {
        get { return _representatives.Value; }
    }

    readonly Lazy<IBridgeService> _bridge;
    public IBridgeService Bridge
    {
        get { return _bridge.Value; }
    }

    readonly Lazy<ICustomerService> _customers;
    public ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IPaykeyService> _paykeys;
    public IPaykeyService Paykeys
    {
        get { return _paykeys.Value; }
    }

    readonly Lazy<IChargeService> _charges;
    public IChargeService Charges
    {
        get { return _charges.Value; }
    }

    readonly Lazy<IFundingEventService> _fundingEvents;
    public IFundingEventService FundingEvents
    {
        get { return _fundingEvents.Value; }
    }

    readonly Lazy<IPaymentService> _payments;
    public IPaymentService Payments
    {
        get { return _payments.Value; }
    }

    readonly Lazy<IPayoutService> _payouts;
    public IPayoutService Payouts
    {
        get { return _payouts.Value; }
    }

    readonly Lazy<IAccountSettingService> _accountSettings;
    public IAccountSettingService AccountSettings
    {
        get { return _accountSettings.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public StraddleClient()
    {
        _options = new();

        _withRawResponse = new(() => new StraddleClientWithRawResponse(this._options));
        _accounts = new(() => new AccountService(this));
        _capabilityRequests = new(() => new CapabilityRequestService(this));
        _linkedBankAccounts = new(() => new LinkedBankAccountService(this));
        _organizations = new(() => new OrganizationService(this));
        _representatives = new(() => new RepresentativeService(this));
        _bridge = new(() => new BridgeService(this));
        _customers = new(() => new CustomerService(this));
        _paykeys = new(() => new PaykeyService(this));
        _charges = new(() => new ChargeService(this));
        _fundingEvents = new(() => new FundingEventService(this));
        _payments = new(() => new PaymentService(this));
        _payouts = new(() => new PayoutService(this));
        _accountSettings = new(() => new AccountSettingService(this));
        _webhooks = new(() => new WebhookService(this));
    }

    public StraddleClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class StraddleClientWithRawResponse : IStraddleClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string Bearer
    {
        get { return this._options.Bearer; }
        init { this._options.Bearer = value; }
    }

    /// <inheritdoc/>
    public IStraddleClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StraddleClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IAccountServiceWithRawResponse> _accounts;
    public IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<ICapabilityRequestServiceWithRawResponse> _capabilityRequests;
    public ICapabilityRequestServiceWithRawResponse CapabilityRequests
    {
        get { return _capabilityRequests.Value; }
    }

    readonly Lazy<ILinkedBankAccountServiceWithRawResponse> _linkedBankAccounts;
    public ILinkedBankAccountServiceWithRawResponse LinkedBankAccounts
    {
        get { return _linkedBankAccounts.Value; }
    }

    readonly Lazy<IOrganizationServiceWithRawResponse> _organizations;
    public IOrganizationServiceWithRawResponse Organizations
    {
        get { return _organizations.Value; }
    }

    readonly Lazy<IRepresentativeServiceWithRawResponse> _representatives;
    public IRepresentativeServiceWithRawResponse Representatives
    {
        get { return _representatives.Value; }
    }

    readonly Lazy<IBridgeServiceWithRawResponse> _bridge;
    public IBridgeServiceWithRawResponse Bridge
    {
        get { return _bridge.Value; }
    }

    readonly Lazy<ICustomerServiceWithRawResponse> _customers;
    public ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IPaykeyServiceWithRawResponse> _paykeys;
    public IPaykeyServiceWithRawResponse Paykeys
    {
        get { return _paykeys.Value; }
    }

    readonly Lazy<IChargeServiceWithRawResponse> _charges;
    public IChargeServiceWithRawResponse Charges
    {
        get { return _charges.Value; }
    }

    readonly Lazy<IFundingEventServiceWithRawResponse> _fundingEvents;
    public IFundingEventServiceWithRawResponse FundingEvents
    {
        get { return _fundingEvents.Value; }
    }

    readonly Lazy<IPaymentServiceWithRawResponse> _payments;
    public IPaymentServiceWithRawResponse Payments
    {
        get { return _payments.Value; }
    }

    readonly Lazy<IPayoutServiceWithRawResponse> _payouts;
    public IPayoutServiceWithRawResponse Payouts
    {
        get { return _payouts.Value; }
    }

    readonly Lazy<IAccountSettingServiceWithRawResponse> _accountSettings;
    public IAccountSettingServiceWithRawResponse AccountSettings
    {
        get { return _accountSettings.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw StraddleExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new StraddleIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await global::System
                .Threading.Tasks.Task.Delay(backoff, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-scalar-retry-count"))
        {
            requestMessage.Headers.Add("x-scalar-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = global::System.Threading.CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new StraddleIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > global::System.TimeSpan.Zero
            && apiBackoff < global::System.TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = global::System.Math.Min(
            0.5 * global::System.Math.Pow(2.0, retries - 1),
            8.0
        );
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return global::System.TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue =
            headerValues == null
                ? null
                : global::System.Linq.Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return global::System.TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue =
            headerValues == null
                ? null
                : global::System.Linq.Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return global::System.TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (global::System.DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - global::System.DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(
                global::System.Linq.Enumerable.FirstOrDefault(headerValues),
                out var shouldRetry
            )
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is StraddleIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public StraddleClientWithRawResponse()
    {
        _options = new();

        _accounts = new(() => new AccountServiceWithRawResponse(this));
        _capabilityRequests = new(() => new CapabilityRequestServiceWithRawResponse(this));
        _linkedBankAccounts = new(() => new LinkedBankAccountServiceWithRawResponse(this));
        _organizations = new(() => new OrganizationServiceWithRawResponse(this));
        _representatives = new(() => new RepresentativeServiceWithRawResponse(this));
        _bridge = new(() => new BridgeServiceWithRawResponse(this));
        _customers = new(() => new CustomerServiceWithRawResponse(this));
        _paykeys = new(() => new PaykeyServiceWithRawResponse(this));
        _charges = new(() => new ChargeServiceWithRawResponse(this));
        _fundingEvents = new(() => new FundingEventServiceWithRawResponse(this));
        _payments = new(() => new PaymentServiceWithRawResponse(this));
        _payouts = new(() => new PayoutServiceWithRawResponse(this));
        _accountSettings = new(() => new AccountSettingServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
    }

    public StraddleClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
