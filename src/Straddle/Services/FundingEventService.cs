using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Exceptions;
using Straddle.Models.FundingEvents;

namespace Straddle.Services;

/// <inheritdoc/>
public sealed class FundingEventService : IFundingEventService
{
    readonly Lazy<IFundingEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFundingEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStraddleClient _client;

    /// <inheritdoc/>
    public IFundingEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FundingEventService(this._client.WithOptions(modifier));
    }

    public FundingEventService(IStraddleClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new FundingEventServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<FundingEventResponse> Retrieve(
        FundingEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FundingEventResponse> Retrieve(
        string id,
        FundingEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FundingEventSummaryList> List(
        FundingEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FundingEventPaymentList> ListPayments(
        FundingEventListPaymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPayments(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FundingEventPaymentList> ListPayments(
        string id,
        FundingEventListPaymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPayments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FundingEventSimulation> Simulate(
        FundingEventSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Simulate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FundingEventServiceWithRawResponse : IFundingEventServiceWithRawResponse
{
    readonly IStraddleClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFundingEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FundingEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FundingEventServiceWithRawResponse(IStraddleClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FundingEventResponse>> Retrieve(
        FundingEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FundingEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fundingEventResponse = await response
                    .Deserialize<FundingEventResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fundingEventResponse.Validate();
                }
                return fundingEventResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FundingEventResponse>> Retrieve(
        string id,
        FundingEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FundingEventSummaryList>> List(
        FundingEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FundingEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fundingEventSummaryList = await response
                    .Deserialize<FundingEventSummaryList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fundingEventSummaryList.Validate();
                }
                return fundingEventSummaryList;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FundingEventPaymentList>> ListPayments(
        FundingEventListPaymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StraddleInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FundingEventListPaymentsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fundingEventPaymentList = await response
                    .Deserialize<FundingEventPaymentList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fundingEventPaymentList.Validate();
                }
                return fundingEventPaymentList;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FundingEventPaymentList>> ListPayments(
        string id,
        FundingEventListPaymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPayments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FundingEventSimulation>> Simulate(
        FundingEventSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FundingEventSimulateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fundingEventSimulation = await response
                    .Deserialize<FundingEventSimulation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fundingEventSimulation.Validate();
                }
                return fundingEventSimulation;
            }
        );
    }
}
