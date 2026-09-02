using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Accounts;

namespace Straddle.Services;

/// <summary>
/// Accounts represent businesses that use Straddle through a platform.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a business account in the specified organization and returns the account.
    /// </summary>
    Task<AccountResponse> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the account with the specified ID.
    /// </summary>
    Task<AccountResponse> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<AccountResponse> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an account's business profile, metadata, and external ID, then returns the account.
    /// </summary>
    Task<AccountResponse> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<AccountResponse> Update(
        string accountID,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of accounts for your platform. Filter the list by status,
    /// type, external ID, or text search.
    /// </summary>
    Task<AccountList> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts onboarding and records the account's acceptance of Straddle's Terms of
    /// Service. The account must have at least one representative and one linked bank
    /// account. This operation also moves all associated representatives and linked bank
    /// accounts to `onboarding`.
    /// </summary>
    Task<AccountResponse> Onboard(
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Onboard(AccountOnboardParams, CancellationToken)"/>
    Task<AccountResponse> Onboard(
        string accountID,
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates an account status transition to `onboarding` or `active` in the sandbox
    /// and returns the account.
    /// </summary>
    Task<AccountResponse> SimulateOnboarding(
        AccountSimulateOnboardingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SimulateOnboarding(AccountSimulateOnboardingParams, CancellationToken)"/>
    Task<AccountResponse> SimulateOnboarding(
        string accountID,
        AccountSimulateOnboardingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountResponse>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{account_id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountResponse>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountResponse>> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/accounts/{account_id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Update(AccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountResponse>> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AccountResponse>> Update(
        string accountID,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountList>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts/{account_id}/onboard</c>, but is otherwise the
    /// same as <see cref="IAccountService.Onboard(AccountOnboardParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountResponse>> Onboard(
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Onboard(AccountOnboardParams, CancellationToken)"/>
    Task<HttpResponse<AccountResponse>> Onboard(
        string accountID,
        AccountOnboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts/{account_id}/simulate</c>, but is otherwise the
    /// same as <see cref="IAccountService.SimulateOnboarding(AccountSimulateOnboardingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountResponse>> SimulateOnboarding(
        AccountSimulateOnboardingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SimulateOnboarding(AccountSimulateOnboardingParams, CancellationToken)"/>
    Task<HttpResponse<AccountResponse>> SimulateOnboarding(
        string accountID,
        AccountSimulateOnboardingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
