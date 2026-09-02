using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Bridge;
using Straddle.Models.Paykeys.Review;

namespace Straddle.Services.Paykeys;

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
    public async Task<PaykeyReviewResponse> List(
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
    public Task<PaykeyReviewResponse> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> SetVerificationDecision(
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
    public Task<PaykeyResponse> SetVerificationDecision(
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
    public async Task<HttpResponse<PaykeyReviewResponse>> List(
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
                var paykeyReviewResponse = await response
                    .Deserialize<PaykeyReviewResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paykeyReviewResponse.Validate();
                }
                return paykeyReviewResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaykeyReviewResponse>> List(
        string id,
        ReviewListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> SetVerificationDecision(
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
                var paykeyResponse = await response
                    .Deserialize<PaykeyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paykeyResponse.Validate();
                }
                return paykeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaykeyResponse>> SetVerificationDecision(
        string id,
        ReviewSetVerificationDecisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetVerificationDecision(parameters with { ID = id }, cancellationToken);
    }
}
