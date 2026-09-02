using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.LinkedBankAccounts;

namespace Straddle.Services;

/// <summary>
/// Linked bank accounts connect external bank accounts to an account or platform
/// for charges, payouts, or billing.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILinkedBankAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILinkedBankAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILinkedBankAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a linked bank account for an account or platform, assigns its payment
    /// purposes, and returns the linked bank account.
    /// </summary>
    Task<LinkedBankAccountResponse> Create(
        LinkedBankAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the linked bank account with the specified ID. The response masks the account number.
    /// </summary>
    Task<LinkedBankAccountResponse> Retrieve(
        LinkedBankAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LinkedBankAccountRetrieveParams, CancellationToken)"/>
    Task<LinkedBankAccountResponse> Retrieve(
        string linkedBankAccountID,
        LinkedBankAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates bank account details and metadata, then returns the linked bank account.
    /// The linked bank account must have status `created`, or status `onboarding` with
    /// `status_detail.reason` set to `stuck`.
    /// </summary>
    Task<LinkedBankAccountResponse> Update(
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LinkedBankAccountUpdateParams, CancellationToken)"/>
    Task<LinkedBankAccountResponse> Update(
        string linkedBankAccountID,
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of linked bank accounts. Filter the list by account,
    /// scope, purpose, or status.
    /// </summary>
    Task<LinkedBankAccountList> List(
        LinkedBankAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a linked bank account and returns it with status `canceled`. The linked
    /// bank account must have status `created`.
    /// </summary>
    Task<LinkedBankAccountResponse> Cancel(
        LinkedBankAccountCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(LinkedBankAccountCancelParams, CancellationToken)"/>
    Task<LinkedBankAccountResponse> Cancel(
        string linkedBankAccountID,
        LinkedBankAccountCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the linked bank account with the specified ID without masking its account
    /// number. This endpoint is available only when Straddle enables data unmasking for
    /// the account.
    /// </summary>
    Task<UnmaskedLinkedBankAccountResponse> ListUnmasked(
        LinkedBankAccountListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(LinkedBankAccountListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedLinkedBankAccountResponse> ListUnmasked(
        string linkedBankAccountID,
        LinkedBankAccountListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILinkedBankAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILinkedBankAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILinkedBankAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/linked_bank_accounts</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.Create(LinkedBankAccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkedBankAccountResponse>> Create(
        LinkedBankAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/linked_bank_accounts/{linked_bank_account_id}</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.Retrieve(LinkedBankAccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkedBankAccountResponse>> Retrieve(
        LinkedBankAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LinkedBankAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LinkedBankAccountResponse>> Retrieve(
        string linkedBankAccountID,
        LinkedBankAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/linked_bank_accounts/{linked_bank_account_id}</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.Update(LinkedBankAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkedBankAccountResponse>> Update(
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LinkedBankAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LinkedBankAccountResponse>> Update(
        string linkedBankAccountID,
        LinkedBankAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/linked_bank_accounts</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.List(LinkedBankAccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkedBankAccountList>> List(
        LinkedBankAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/linked_bank_accounts/{linked_bank_account_id}/cancel</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.Cancel(LinkedBankAccountCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkedBankAccountResponse>> Cancel(
        LinkedBankAccountCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(LinkedBankAccountCancelParams, CancellationToken)"/>
    Task<HttpResponse<LinkedBankAccountResponse>> Cancel(
        string linkedBankAccountID,
        LinkedBankAccountCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/linked_bank_accounts/{linked_bank_account_id}/unmask</c>, but is otherwise the
    /// same as <see cref="ILinkedBankAccountService.ListUnmasked(LinkedBankAccountListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedLinkedBankAccountResponse>> ListUnmasked(
        LinkedBankAccountListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(LinkedBankAccountListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedLinkedBankAccountResponse>> ListUnmasked(
        string linkedBankAccountID,
        LinkedBankAccountListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
