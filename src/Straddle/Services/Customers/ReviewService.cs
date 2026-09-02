using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Customers;
using Straddle.Models.Customers.Review;

namespace Straddle.Services.Customers;

/// <inheritdoc/>
public sealed class ReviewService : IReviewService
{
    readonly Lazy<IReviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewService(this._client.WithOptions(modifier));
    }

    public ReviewService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReviewServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CustomerReviewResponse> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerReviewResponse> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetVerificationDecision(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetVerificationDecision(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReviewServiceWithRawResponse : IReviewServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReviewServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerReviewResponse>> List(
        ReviewListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ReviewListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerReviewResponse = await response
                    .Deserialize<CustomerReviewResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerReviewResponse.Validate();
                }
                return customerReviewResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerReviewResponse>> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> SetVerificationDecision(
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ReviewSetVerificationDecisionParams> request = new()
        {
            Method = StraddleClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerResponse = await response
                    .Deserialize<CustomerResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerResponse.Validate();
                }
                return customerResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerResponse>> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetVerificationDecision(parameters with { ID = id }, cancellationToken);
    }
}
