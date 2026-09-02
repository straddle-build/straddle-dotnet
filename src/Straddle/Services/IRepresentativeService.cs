using System;
using System.Threading;
using System.Threading.Tasks;
using Straddle.Core;
using Straddle.Models.Representatives;

namespace Straddle.Services;

/// <summary>
/// Representatives are people associated with a business account for ownership,
/// control, or authorization purposes.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRepresentativeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRepresentativeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRepresentativeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a representative for an account and returns the representative.
    /// Relationship fields identify primary representatives, control persons, and owners.
    /// </summary>
    Task<RepresentativeResponse> Create(
        RepresentativeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the representative with the specified ID.
    /// </summary>
    Task<RepresentativeResponse> Retrieve(
        RepresentativeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RepresentativeRetrieveParams, CancellationToken)"/>
    Task<RepresentativeResponse> Retrieve(
        string representativeID,
        RepresentativeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a representative's personal, contact, relationship, external ID, and
    /// metadata fields, then returns the representative.
    /// </summary>
    Task<RepresentativeResponse> Update(
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RepresentativeUpdateParams, CancellationToken)"/>
    Task<RepresentativeResponse> Update(
        string representativeID,
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of representatives. Filter the list by account,
    /// organization, platform, or scope.
    /// </summary>
    Task<RepresentativeList> List(
        RepresentativeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the representative with the specified ID without masking sensitive fields.
    /// This endpoint requires an administrator role.
    /// </summary>
    Task<UnmaskedRepresentativeResponse> ListUnmasked(
        RepresentativeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(RepresentativeListUnmaskedParams, CancellationToken)"/>
    Task<UnmaskedRepresentativeResponse> ListUnmasked(
        string representativeID,
        RepresentativeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRepresentativeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRepresentativeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRepresentativeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/representatives</c>, but is otherwise the
    /// same as <see cref="IRepresentativeService.Create(RepresentativeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RepresentativeResponse>> Create(
        RepresentativeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/representatives/{representative_id}</c>, but is otherwise the
    /// same as <see cref="IRepresentativeService.Retrieve(RepresentativeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RepresentativeResponse>> Retrieve(
        RepresentativeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RepresentativeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RepresentativeResponse>> Retrieve(
        string representativeID,
        RepresentativeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/representatives/{representative_id}</c>, but is otherwise the
    /// same as <see cref="IRepresentativeService.Update(RepresentativeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RepresentativeResponse>> Update(
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RepresentativeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RepresentativeResponse>> Update(
        string representativeID,
        RepresentativeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/representatives</c>, but is otherwise the
    /// same as <see cref="IRepresentativeService.List(RepresentativeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RepresentativeList>> List(
        RepresentativeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/representatives/{representative_id}/unmask</c>, but is otherwise the
    /// same as <see cref="IRepresentativeService.ListUnmasked(RepresentativeListUnmaskedParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UnmaskedRepresentativeResponse>> ListUnmasked(
        RepresentativeListUnmaskedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUnmasked(RepresentativeListUnmaskedParams, CancellationToken)"/>
    Task<HttpResponse<UnmaskedRepresentativeResponse>> ListUnmasked(
        string representativeID,
        RepresentativeListUnmaskedParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
