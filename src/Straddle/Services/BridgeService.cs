using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class BridgeService : IBridgeService
{
    readonly Lazy<IBridgeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBridgeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IBridgeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BridgeService(this._client.WithOptions(modifier));
    }

    public BridgeService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BridgeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> CreateBankAccountPaykey(
        BridgeCreateBankAccountPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateBankAccountPaykey(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PaykeyResponse> CreatePlaidPaykey(
        BridgeCreatePlaidPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreatePlaidPaykey(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RevealedPaykeyResponse> CreateQuilttPaykey(
        BridgeCreateQuilttPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateQuilttPaykey(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BridgeTokenResponse> CreateToken(
        BridgeCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BridgeServiceWithRawResponse : IBridgeServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBridgeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BridgeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BridgeServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaykeyResponse>> CreateBankAccountPaykey(
        BridgeCreateBankAccountPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BridgeCreateBankAccountPaykeyParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public async Task<HttpResponse<PaykeyResponse>> CreatePlaidPaykey(
        BridgeCreatePlaidPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BridgeCreatePlaidPaykeyParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public async Task<HttpResponse<RevealedPaykeyResponse>> CreateQuilttPaykey(
        BridgeCreateQuilttPaykeyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BridgeCreateQuilttPaykeyParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public async Task<HttpResponse<BridgeTokenResponse>> CreateToken(
        BridgeCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BridgeCreateTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bridgeTokenResponse = await response
                    .Deserialize<BridgeTokenResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bridgeTokenResponse.Validate();
                }
                return bridgeTokenResponse;
            }
        );
    }
}
