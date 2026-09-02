using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.Accounts;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AccountResponse> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountResponse> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountResponse> Update(
        string accountID,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountList> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse> Onboard(
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Onboard(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountResponse> Onboard(
        string accountID,
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Onboard(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse> SimulateOnboarding(
        AccountSimulateOnboardingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SimulateOnboarding(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountResponse> SimulateOnboarding(
        string accountID,
        AccountSimulateOnboardingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SimulateOnboarding(
            parameters with
            {
                AccountID = accountID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountResponse>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountResponse = await response
                    .Deserialize<AccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountResponse.Validate();
                }
                return accountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountResponse>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new StraddleInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountResponse = await response
                    .Deserialize<AccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountResponse.Validate();
                }
                return accountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountResponse>> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountResponse>> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new StraddleInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountResponse = await response
                    .Deserialize<AccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountResponse.Validate();
                }
                return accountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountResponse>> Update(
        string accountID,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountList>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountList = await response
                    .Deserialize<AccountList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountList.Validate();
                }
                return accountList;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountResponse>> Onboard(
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new StraddleInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountOnboardParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountResponse = await response
                    .Deserialize<AccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountResponse.Validate();
                }
                return accountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountResponse>> Onboard(
        string accountID,
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Onboard(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountResponse>> SimulateOnboarding(
        AccountSimulateOnboardingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new StraddleInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountSimulateOnboardingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountResponse = await response
                    .Deserialize<AccountResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountResponse.Validate();
                }
                return accountResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountResponse>> SimulateOnboarding(
        string accountID,
        AccountSimulateOnboardingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SimulateOnboarding(
            parameters with
            {
                AccountID = accountID,
            },
            cancellationToken
        );
    }
}
