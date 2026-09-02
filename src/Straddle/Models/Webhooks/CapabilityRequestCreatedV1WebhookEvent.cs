using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.CapabilityRequests;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        CapabilityRequestCreatedV1WebhookEvent,
        CapabilityRequestCreatedV1WebhookEventFromRaw
    >)
)]
public sealed record class CapabilityRequestCreatedV1WebhookEvent : JsonModel
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

    public required CapabilityRequest Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilityRequest>("data");
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

    public CapabilityRequestCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilityRequestCreatedV1WebhookEvent(
        CapabilityRequestCreatedV1WebhookEvent capabilityRequestCreatedV1WebhookEvent
    )
        : base(capabilityRequestCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public CapabilityRequestCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilityRequestCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilityRequestCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static CapabilityRequestCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilityRequestCreatedV1WebhookEventFromRaw
    : IFromRawJson<CapabilityRequestCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public CapabilityRequestCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CapabilityRequestCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}
