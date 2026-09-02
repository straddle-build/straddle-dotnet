using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Organizations;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class OrganizationService : IOrganizationService
{
    readonly Lazy<IOrganizationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrganizationService(this._client.WithOptions(modifier));
    }

    public OrganizationService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new OrganizationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<OrganizationResponse> Create(
        OrganizationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OrganizationResponse> Retrieve(
        OrganizationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OrganizationResponse> Retrieve(
        string organizationID,
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OrganizationID = organizationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<OrganizationList> List(
        OrganizationListParams? parameters = null,
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
public sealed class OrganizationServiceWithRawResponse : IOrganizationServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OrganizationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OrganizationServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationResponse>> Create(
        OrganizationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OrganizationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizationResponse = await response
                    .Deserialize<OrganizationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizationResponse.Validate();
                }
                return organizationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationResponse>> Retrieve(
        OrganizationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrganizationID == null)
        {
            throw new StraddleInvalidDataException("'parameters.OrganizationID' cannot be null");
        }

        HttpRequest<OrganizationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizationResponse = await response
                    .Deserialize<OrganizationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizationResponse.Validate();
                }
                return organizationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OrganizationResponse>> Retrieve(
        string organizationID,
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OrganizationID = organizationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationList>> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OrganizationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizationList = await response
                    .Deserialize<OrganizationList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizationList.Validate();
                }
                return organizationList;
            }
        );
    }
}
