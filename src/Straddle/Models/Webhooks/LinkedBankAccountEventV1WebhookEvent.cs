using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Models.LinkedBankAccounts;

namespace Straddle.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        LinkedBankAccountEventV1WebhookEvent,
        LinkedBankAccountEventV1WebhookEventFromRaw
    >)
)]
public sealed record class LinkedBankAccountEventV1WebhookEvent : JsonModel
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

    public required LinkedBankAccount Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LinkedBankAccount>("data");
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

    public LinkedBankAccountEventV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountEventV1WebhookEvent(
        LinkedBankAccountEventV1WebhookEvent linkedBankAccountEventV1WebhookEvent
    )
        : base(linkedBankAccountEventV1WebhookEvent) { }
#pragma warning restore CS8618

    public LinkedBankAccountEventV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountEventV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountEventV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccountEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountEventV1WebhookEventFromRaw
    : IFromRawJson<LinkedBankAccountEventV1WebhookEvent>
{
    /// <inheritdoc/>
    public LinkedBankAccountEventV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedBankAccountEventV1WebhookEvent.FromRawUnchecked(rawData);
}
