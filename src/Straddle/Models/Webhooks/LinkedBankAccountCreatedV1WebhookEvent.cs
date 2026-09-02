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
        LinkedBankAccountCreatedV1WebhookEvent,
        LinkedBankAccountCreatedV1WebhookEventFromRaw
    >)
)]
public sealed record class LinkedBankAccountCreatedV1WebhookEvent : JsonModel
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

    public LinkedBankAccountCreatedV1WebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedBankAccountCreatedV1WebhookEvent(
        LinkedBankAccountCreatedV1WebhookEvent linkedBankAccountCreatedV1WebhookEvent
    )
        : base(linkedBankAccountCreatedV1WebhookEvent) { }
#pragma warning restore CS8618

    public LinkedBankAccountCreatedV1WebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedBankAccountCreatedV1WebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedBankAccountCreatedV1WebhookEventFromRaw.FromRawUnchecked"/>
    public static LinkedBankAccountCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedBankAccountCreatedV1WebhookEventFromRaw
    : IFromRawJson<LinkedBankAccountCreatedV1WebhookEvent>
{
    /// <inheritdoc/>
    public LinkedBankAccountCreatedV1WebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedBankAccountCreatedV1WebhookEvent.FromRawUnchecked(rawData);
}
