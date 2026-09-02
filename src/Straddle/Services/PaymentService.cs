using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Payments;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class PaymentService : IPaymentService
{
    readonly Lazy<IPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentService(this._client.WithOptions(modifier));
    }

    public PaymentService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PaymentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PaymentSummaryList> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PaymentServiceWithRawResponse : IPaymentServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaymentServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaymentSummaryList>> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PaymentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var paymentSummaryList = await response
                    .Deserialize<PaymentSummaryList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paymentSummaryList.Validate();
                }
                return paymentSummaryList;
            }
        );
    }
}
