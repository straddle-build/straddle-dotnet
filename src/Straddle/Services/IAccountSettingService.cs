using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.AccountSettings;

namespace Straddle.Services;

/// <summary>
/// Account settings define payment limits, capabilities, statement details, and
/// policy controls for an account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns all effective settings for the account, including values inherited from
    /// its organization, platform, and system defaults.
    /// </summary>
    Task<AccountSettingsResponse> Retrieve(
        AccountSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountSettingRetrieveParams, CancellationToken)"/>
    Task<AccountSettingsResponse> Retrieve(
        string accountID,
        AccountSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountSettingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/account_settings/{account_id}</c>, but is otherwise the
    /// same as <see cref="IAccountSettingService.Retrieve(AccountSettingRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountSettingsResponse>> Retrieve(
        AccountSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountSettingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountSettingsResponse>> Retrieve(
        string accountID,
        AccountSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
