using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Organizations;

namespace Straddle.Services;

/// <summary>
/// Organizations group related Straddle accounts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrganizationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an organization for your platform and returns it. Organizations group
    /// related accounts and users.
    /// </summary>
    Task<OrganizationResponse> Create(
        OrganizationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the organization with the specified ID.
    /// </summary>
    Task<OrganizationResponse> Retrieve(
        OrganizationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrganizationRetrieveParams, CancellationToken)"/>
    Task<OrganizationResponse> Retrieve(
        string organizationID,
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of organizations for your platform. Filter the list by
    /// name or external ID.
    /// </summary>
    Task<OrganizationList> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOrganizationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOrganizationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations</c>, but is otherwise the
    /// same as <see cref="IOrganizationService.Create(OrganizationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationResponse>> Create(
        OrganizationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/{organization_id}</c>, but is otherwise the
    /// same as <see cref="IOrganizationService.Retrieve(OrganizationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationResponse>> Retrieve(
        OrganizationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrganizationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OrganizationResponse>> Retrieve(
        string organizationID,
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations</c>, but is otherwise the
    /// same as <see cref="IOrganizationService.List(OrganizationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationList>> List(
        OrganizationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
