using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Charges;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class ChargeService : IChargeService
{
    readonly Lazy<IChargeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChargeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IChargeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChargeService(this._client.WithOptions(modifier));
    }

    public ChargeService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChargeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Create(
        ChargeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Retrieve(
        ChargeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Update(
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Update(
        string id,
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Cancel(
        ChargeCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Hold(
        ChargeHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Hold(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Hold(
        string id,
        ChargeHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hold(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UnmaskedChargeResponse> ListUnmasked(
        ChargeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUnmasked(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UnmaskedChargeResponse> ListUnmasked(
        string id,
        ChargeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PayoutResponse> Refund(
        ChargeRefundParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Refund(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PayoutResponse> Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Refund(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Release(
        ChargeReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Release(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Release(
        string id,
        ChargeReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> Resubmit(
        ChargeResubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Resubmit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> Resubmit(
        string id,
        ChargeResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Resubmit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChargeResponse> UploadAuthorizationProof(
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadAuthorizationProof(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChargeResponse> UploadAuthorizationProof(
        string id,
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadAuthorizationProof(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ChargeServiceWithRawResponse : IChargeServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChargeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChargeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChargeServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Create(
        ChargeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChargeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Retrieve(
        ChargeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Update(
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Update(
        string id,
        ChargeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Cancel(
        ChargeCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeCancelParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Hold(
        ChargeHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeHoldParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Hold(
        string id,
        ChargeHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hold(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnmaskedChargeResponse>> ListUnmasked(
        ChargeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeListUnmaskedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var unmaskedChargeResponse = await response
                    .Deserialize<UnmaskedChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    unmaskedChargeResponse.Validate();
                }
                return unmaskedChargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UnmaskedChargeResponse>> ListUnmasked(
        string id,
        ChargeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutResponse>> Refund(
        ChargeRefundParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeRefundParams> request = new()
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
    public Task<HttpResponse<PayoutResponse>> Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Refund(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Release(
        ChargeReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeReleaseParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Release(
        string id,
        ChargeReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> Resubmit(
        ChargeResubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeResubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> Resubmit(
        string id,
        ChargeResubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Resubmit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargeResponse>> UploadAuthorizationProof(
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChargeUploadAuthorizationProofParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chargeResponse = await response
                    .Deserialize<ChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chargeResponse.Validate();
                }
                return chargeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChargeResponse>> UploadAuthorizationProof(
        string id,
        ChargeUploadAuthorizationProofParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadAuthorizationProof(parameters with { ID = id }, cancellationToken);
    }
}
