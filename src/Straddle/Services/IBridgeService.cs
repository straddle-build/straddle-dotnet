using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Bridge;

namespace Straddle.Services;

/// <summary>
/// Bridge connects customer bank accounts and creates paykeys from supported
/// provider tokens or bank account details.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBridgeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBridgeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBridgeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a paykey from a routing number, account number, and account type.
    /// </summary>
    Task<PaykeyResponse> CreateBankAccountPaykey(
        BridgeCreateBankAccountPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a paykey from a Plaid processor token.
    /// </summary>
    Task<PaykeyResponse> CreatePlaidPaykey(
        BridgeCreatePlaidPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a paykey from a Quiltt processor token.
    /// </summary>
    Task<RevealedPaykeyResponse> CreateQuilttPaykey(
        BridgeCreateQuilttPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a session token for the Bridge widget.
    /// </summary>
    Task<BridgeTokenResponse> CreateToken(
        BridgeCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBridgeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBridgeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBridgeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bridge/bank_account</c>, but is otherwise the
    /// same as <see cref="IBridgeService.CreateBankAccountPaykey(BridgeCreateBankAccountPaykeyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> CreateBankAccountPaykey(
        BridgeCreateBankAccountPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bridge/plaid</c>, but is otherwise the
    /// same as <see cref="IBridgeService.CreatePlaidPaykey(BridgeCreatePlaidPaykeyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaykeyResponse>> CreatePlaidPaykey(
        BridgeCreatePlaidPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bridge/quiltt</c>, but is otherwise the
    /// same as <see cref="IBridgeService.CreateQuilttPaykey(BridgeCreateQuilttPaykeyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RevealedPaykeyResponse>> CreateQuilttPaykey(
        BridgeCreateQuilttPaykeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bridge/initialize</c>, but is otherwise the
    /// same as <see cref="IBridgeService.CreateToken(BridgeCreateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BridgeTokenResponse>> CreateToken(
        BridgeCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}
