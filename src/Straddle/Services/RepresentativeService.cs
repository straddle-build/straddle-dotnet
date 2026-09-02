using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Representatives;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class RepresentativeService : IRepresentativeService
{
    readonly Lazy<IRepresentativeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRepresentativeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IRepresentativeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RepresentativeService(this._client.WithOptions(modifier));
    }

    public RepresentativeService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RepresentativeServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RepresentativeResponse> Create(
        RepresentativeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RepresentativeResponse> Retrieve(
        RepresentativeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RepresentativeResponse> Retrieve(
        string representativeID,
        RepresentativeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RepresentativeResponse> Update(
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RepresentativeResponse> Update(
        string representativeID,
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RepresentativeList> List(
        RepresentativeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UnmaskedRepresentativeResponse> ListUnmasked(
        RepresentativeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUnmasked(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UnmaskedRepresentativeResponse> ListUnmasked(
        string representativeID,
        RepresentativeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RepresentativeServiceWithRawResponse : IRepresentativeServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRepresentativeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RepresentativeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RepresentativeServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RepresentativeResponse>> Create(
        RepresentativeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RepresentativeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var representativeResponse = await response
                    .Deserialize<RepresentativeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    representativeResponse.Validate();
                }
                return representativeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RepresentativeResponse>> Retrieve(
        RepresentativeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RepresentativeID == null)
        {
            throw new StraddleInvalidDataException("'parameters.RepresentativeID' cannot be null");
        }

        HttpRequest<RepresentativeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var representativeResponse = await response
                    .Deserialize<RepresentativeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    representativeResponse.Validate();
                }
                return representativeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RepresentativeResponse>> Retrieve(
        string representativeID,
        RepresentativeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RepresentativeResponse>> Update(
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RepresentativeID == null)
        {
            throw new StraddleInvalidDataException("'parameters.RepresentativeID' cannot be null");
        }

        HttpRequest<RepresentativeUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var representativeResponse = await response
                    .Deserialize<RepresentativeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    representativeResponse.Validate();
                }
                return representativeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RepresentativeResponse>> Update(
        string representativeID,
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RepresentativeList>> List(
        RepresentativeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RepresentativeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var representativeList = await response
                    .Deserialize<RepresentativeList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    representativeList.Validate();
                }
                return representativeList;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnmaskedRepresentativeResponse>> ListUnmasked(
        RepresentativeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RepresentativeID == null)
        {
            throw new StraddleInvalidDataException("'parameters.RepresentativeID' cannot be null");
        }

        HttpRequest<RepresentativeListUnmaskedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var unmaskedRepresentativeResponse = await response
                    .Deserialize<UnmaskedRepresentativeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    unmaskedRepresentativeResponse.Validate();
                }
                return unmaskedRepresentativeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UnmaskedRepresentativeResponse>> ListUnmasked(
        string representativeID,
        RepresentativeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(
            parameters with
            {
                RepresentativeID = representativeID,
            },
            cancellationToken
        );
    }
}
