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
        RepresentativeEventV1WebhookEvent,
        RepresentativeEventV1WebhookEventFromRaw
    >)
)]
public sealed record class RepresentativeEventV1WebhookEvent : JsonModel
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

    public RepresentativeEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RepresentativeEventV1WebhookEvent(
        RepresentativeEventV1WebhookEvent representativeEventV1WebhookEvent
    )
        : base(representativeEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public RepresentativeEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RepresentativeEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentativeEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static RepresentativeEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentativeEventV1WebhookEventFromRaw : IFromRawJson<RepresentativeEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public RepresentativeEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RepresentativeEventV1WebhookEvent.FromRawUnchecked(rawData);
}
