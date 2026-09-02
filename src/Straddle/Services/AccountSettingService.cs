using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.AccountSettings;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class AccountSettingService : IAccountSettingService
{
    readonly Lazy<IAccountSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountSettingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IAccountSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountSettingService(this._client.WithOptions(modifier));
    }

    public AccountSettingService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountSettingServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountSettingsResponse> Retrieve(
        AccountSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountSettingsResponse> Retrieve(
        string accountID,
        AccountSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountSettingServiceWithRawResponse : IAccountSettingServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountSettingServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountSettingsResponse>> Retrieve(
        AccountSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new StraddleInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountSettingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountSettingsResponse = await response
                    .Deserialize<AccountSettingsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountSettingsResponse.Validate();
                }
                return accountSettingsResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountSettingsResponse>> Retrieve(
        string accountID,
        AccountSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }
}
