using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.Representatives;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        RepresentativeCreatedV1WebhookEvent,
        RepresentativeCreatedV1WebhookEventFromRaw
    >)
)]
public sealed record class RepresentativeCreatedV1WebhookEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the account associated with this event.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required Representative Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Representative>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// Type of this event.
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.Data.Validate();
        _ = this.EventID;
        _ = this.EventType;
    }

    public RepresentativeCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeCreatedV1WebhookEvent(
        RepresentativeCreatedV1WebhookEvent representativeCreatedV1WebhookEvent
    )
        : base(representativeCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public RepresentativeCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static RepresentativeCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeCreatedV1WebhookEventFromRaw : IFromRawJson<RepresentativeCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public RepresentativeCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentativeCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}
