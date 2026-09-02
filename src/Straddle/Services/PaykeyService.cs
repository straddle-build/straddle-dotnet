using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Bridge;
using Straddle.Models.Paykeys;
using Straddle.Services.Paykeys;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class PaykeyService : IPaykeyService
{
    readonly Lazy<IPaykeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaykeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IPaykeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaykeyService(this._client.WithOptions(modifier));
    }

    public PaykeyService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PaykeyServiceWithRawResponse(client.WithRawResponse));
        _review = new(() => new ReviewService(client));
    }

    readonly Lazy<IReviewService> _review;
    public IReviewService Review
    {
        get { return _review.Value; }
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> Retrieve(
        PaykeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaykeyResponse> Retrieve(
        string id,
        PaykeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaykeySummaryList> List(
        PaykeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> Cancel(
        PaykeyCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaykeyResponse> Cancel(
        string id,
        PaykeyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UnmaskedPaykeyResponse> ListUnmasked(
        PaykeyListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUnmasked(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UnmaskedPaykeyResponse> ListUnmasked(
        string id,
        PaykeyListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> RefreshBalance(
        PaykeyRefreshBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RefreshBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaykeyResponse> RefreshBalance(
        string id,
        PaykeyRefreshBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshBalance(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> RefreshReview(
        PaykeyRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RefreshReview(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaykeyResponse> RefreshReview(
        string id,
        PaykeyRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshReview(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RevealedPaykeyResponse> Reveal(
        PaykeyRevealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reveal(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RevealedPaykeyResponse> Reveal(
        string id,
        PaykeyRevealParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reveal(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> Unblock(
        PaykeyUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unblock(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaykeyResponse> Unblock(
        string id,
        PaykeyUnblockParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unblock(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PaykeyServiceWithRawResponse : IPaykeyServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaykeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaykeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaykeyServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;

        _review = new(() => new ReviewServiceWithRawResponse(client));
    }

    readonly Lazy<IReviewServiceWithRawResponse> _review;
    public IReviewServiceWithRawResponse Review
    {
        get { return _review.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> Retrieve(
        PaykeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<PaykeyResponse>> Retrieve(
        string id,
        PaykeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeySummaryList>> List(
        PaykeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PaykeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var paykeySummaryList = await response
                    .Deserialize<PaykeySummaryList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paykeySummaryList.Validate();
                }
                return paykeySummaryList;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> Cancel(
        PaykeyCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyCancelParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<PaykeyResponse>> Cancel(
        string id,
        PaykeyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnmaskedPaykeyResponse>> ListUnmasked(
        PaykeyListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyListUnmaskedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var unmaskedPaykeyResponse = await response
                    .Deserialize<UnmaskedPaykeyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    unmaskedPaykeyResponse.Validate();
                }
                return unmaskedPaykeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UnmaskedPaykeyResponse>> ListUnmasked(
        string id,
        PaykeyListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> RefreshBalance(
        PaykeyRefreshBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyRefreshBalanceParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<PaykeyResponse>> RefreshBalance(
        string id,
        PaykeyRefreshBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshBalance(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> RefreshReview(
        PaykeyRefreshReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyRefreshReviewParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<PaykeyResponse>> RefreshReview(
        string id,
        PaykeyRefreshReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshReview(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RevealedPaykeyResponse>> Reveal(
        PaykeyRevealParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyRevealParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var revealedPaykeyResponse = await response
                    .Deserialize<RevealedPaykeyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    revealedPaykeyResponse.Validate();
                }
                return revealedPaykeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RevealedPaykeyResponse>> Reveal(
        string id,
        PaykeyRevealParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reveal(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> Unblock(
        PaykeyUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaykeyUnblockParams> request = new()
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
    public Task<HttpResponse<PaykeyResponse>> Unblock(
        string id,
        PaykeyUnblockParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unblock(parameters with { ID = id }, cancellationToken);
    }
}
