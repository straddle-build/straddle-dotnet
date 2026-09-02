using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.LinkedBankAccounts;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class LinkedBankAccountService : ILinkedBankAccountService
{
    readonly Lazy<ILinkedBankAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILinkedBankAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public ILinkedBankAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LinkedBankAccountService(this._client.WithOptions(modifier));
    }

    public LinkedBankAccountService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new LinkedBankAccountServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<LinkedBankAccountResponse> Create(
        LinkedBankAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LinkedBankAccountResponse> Retrieve(
        LinkedBankAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LinkedBankAccountResponse> Retrieve(
        string linkedBankAccountID,
        LinkedBankAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LinkedBankAccountResponse> Update(
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LinkedBankAccountResponse> Update(
        string linkedBankAccountID,
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LinkedBankAccountList> List(
        LinkedBankAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LinkedBankAccountResponse> Cancel(
        LinkedBankAccountCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LinkedBankAccountResponse> Cancel(
        string linkedBankAccountID,
        LinkedBankAccountCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<UnmaskedLinkedBankAccountResponse> ListUnmasked(
        LinkedBankAccountListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUnmasked(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UnmaskedLinkedBankAccountResponse> ListUnmasked(
        string linkedBankAccountID,
        LinkedBankAccountListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class LinkedBankAccountServiceWithRawResponse
    : ILinkedBankAccountServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILinkedBankAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LinkedBankAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LinkedBankAccountServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkedBankAccountResponse>> Create(
        LinkedBankAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LinkedBankAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkedBankAccountResponse = await response
                    .Deserialize<LinkedBankAccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkedBankAccountResponse.Validate();
                }
                return linkedBankAccountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkedBankAccountResponse>> Retrieve(
        LinkedBankAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LinkedBankAccountID == null)
        {
            throw new StraddleInvalidDataException(
                "'parameters.LinkedBankAccountID' cannot be null"
            );
        }

        HttpRequest<LinkedBankAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkedBankAccountResponse = await response
                    .Deserialize<LinkedBankAccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkedBankAccountResponse.Validate();
                }
                return linkedBankAccountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LinkedBankAccountResponse>> Retrieve(
        string linkedBankAccountID,
        LinkedBankAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkedBankAccountResponse>> Update(
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LinkedBankAccountID == null)
        {
            throw new StraddleInvalidDataException(
                "'parameters.LinkedBankAccountID' cannot be null"
            );
        }

        HttpRequest<LinkedBankAccountUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkedBankAccountResponse = await response
                    .Deserialize<LinkedBankAccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkedBankAccountResponse.Validate();
                }
                return linkedBankAccountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LinkedBankAccountResponse>> Update(
        string linkedBankAccountID,
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkedBankAccountList>> List(
        LinkedBankAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LinkedBankAccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkedBankAccountList = await response
                    .Deserialize<LinkedBankAccountList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkedBankAccountList.Validate();
                }
                return linkedBankAccountList;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkedBankAccountResponse>> Cancel(
        LinkedBankAccountCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LinkedBankAccountID == null)
        {
            throw new StraddleInvalidDataException(
                "'parameters.LinkedBankAccountID' cannot be null"
            );
        }

        HttpRequest<LinkedBankAccountCancelParams> request = new()
        {
            Method = StraddleClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkedBankAccountResponse = await response
                    .Deserialize<LinkedBankAccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkedBankAccountResponse.Validate();
                }
                return linkedBankAccountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LinkedBankAccountResponse>> Cancel(
        string linkedBankAccountID,
        LinkedBankAccountCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnmaskedLinkedBankAccountResponse>> ListUnmasked(
        LinkedBankAccountListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LinkedBankAccountID == null)
        {
            throw new StraddleInvalidDataException(
                "'parameters.LinkedBankAccountID' cannot be null"
            );
        }

        HttpRequest<LinkedBankAccountListUnmaskedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var unmaskedLinkedBankAccountResponse = await response
                    .Deserialize<UnmaskedLinkedBankAccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    unmaskedLinkedBankAccountResponse.Validate();
                }
                return unmaskedLinkedBankAccountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UnmaskedLinkedBankAccountResponse>> ListUnmasked(
        string linkedBankAccountID,
        LinkedBankAccountListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUnmasked(
            parameters with
            {
                LinkedBankAccountID = linkedBankAccountID,
            },
            cancellationToken
        );
    }
}
