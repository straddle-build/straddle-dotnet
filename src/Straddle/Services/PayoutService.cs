using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Charges;
using Straddle.Models.Payouts;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class PayoutService : IPayoutService
{
    readonly Lazy<IPayoutServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPayoutServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayoutService(this._client.WithOptions(modifier));
    }

    public PayoutService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PayoutServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Create(
        PayoutCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Retrieve(
        PayoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Update(
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Update(
        string id,
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Cancel(
        PayoutCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Hold(
        PayoutHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Hold(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Hold(
        string id,
        PayoutHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hold(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UnmaskedPayoutResponse> ListUnmasked(
        PayoutListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUnmasked(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UnmaskedPayoutResponse> ListUnmasked(
        string id,
        PayoutListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Release(
        PayoutReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Release(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Release(
        string id,
        PayoutReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Resubmit(
        PayoutResubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Resubmit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Resubmit(
        string id,
        PayoutResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Resubmit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> UploadAuthorizationProof(
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadAuthorizationProof(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> UploadAuthorizationProof(
        string id,
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadAuthorizationProof(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PayoutServiceWithRawResponse : IPayoutServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPayoutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayoutServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PayoutServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Create(
        PayoutCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PayoutCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Retrieve(
        PayoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Update(
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Update(
        string id,
        PayoutUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Cancel(
        PayoutCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutCancelParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Hold(
        PayoutHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutHoldParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Hold(
        string id,
        PayoutHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hold(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnmaskedPayoutResponse>> ListUnmasked(
        PayoutListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutListUnmaskedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var unmaskedPayoutResponse = await response
                    .Deserialize<UnmaskedPayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    unmaskedPayoutResponse.Validate();
                }
                return unmaskedPayoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UnmaskedPayoutResponse>> ListUnmasked(
        string id,
        PayoutListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Release(
        PayoutReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutReleaseParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Release(
        string id,
        PayoutReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Resubmit(
        PayoutResubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutResubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> Resubmit(
        string id,
        PayoutResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Resubmit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> UploadAuthorizationProof(
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PayoutUploadAuthorizationProofParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payoutResponse = await response
                    .Deserialize<PayoutResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payoutResponse.Validate();
                }
                return payoutResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PayoutResponse>> UploadAuthorizationProof(
        string id,
        PayoutUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadAuthorizationProof(parameters with { ID = id }, cancellationToken);
    }
}
