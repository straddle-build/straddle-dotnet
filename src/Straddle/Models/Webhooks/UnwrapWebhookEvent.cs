using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;
using Straddle.Exceptions;

namespace Straddle.Models.Webhooks;

[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string AccountID
    {
        get
        {
            return Match(
                accountCreatedV1: (x) => x.AccountID,
                accountEventV1: (x) => x.AccountID,
                representativeEventV1: (x) => x.AccountID,
                representativeCreatedV1: (x) => x.AccountID,
                linkedBankAccountEventV1: (x) => x.AccountID,
                linkedBankAccountCreatedV1: (x) => x.AccountID,
                capabilityRequestEventV1: (x) => x.AccountID,
                capabilityRequestCreatedV1: (x) => x.AccountID,
                customerEventV1: (x) => x.AccountID,
                customerCreatedV1: (x) => x.AccountID,
                paykeyEventV1: (x) => x.AccountID,
                paykeyCreatedV1: (x) => x.AccountID,
                chargeCreatedV1: (x) => x.AccountID,
                chargeEventV1: (x) => x.AccountID,
                payoutCreatedV1: (x) => x.AccountID,
                payoutEventV1: (x) => x.AccountID,
                platformEventV1: (x) => x.AccountID,
                platformCreatedV1: (x) => x.AccountID,
                userEventV1: (x) => x.AccountID,
                userCreatedV1: (x) => x.AccountID,
                fundingEventCreatedV1: (x) => x.AccountID,
                fundingEventEventV1: (x) => x.AccountID
            );
        }
    }

    public string EventID
    {
        get
        {
            return Match(
                accountCreatedV1: (x) => x.EventID,
                accountEventV1: (x) => x.EventID,
                representativeEventV1: (x) => x.EventID,
                representativeCreatedV1: (x) => x.EventID,
                linkedBankAccountEventV1: (x) => x.EventID,
                linkedBankAccountCreatedV1: (x) => x.EventID,
                capabilityRequestEventV1: (x) => x.EventID,
                capabilityRequestCreatedV1: (x) => x.EventID,
                customerEventV1: (x) => x.EventID,
                customerCreatedV1: (x) => x.EventID,
                paykeyEventV1: (x) => x.EventID,
                paykeyCreatedV1: (x) => x.EventID,
                chargeCreatedV1: (x) => x.EventID,
                chargeEventV1: (x) => x.EventID,
                payoutCreatedV1: (x) => x.EventID,
                payoutEventV1: (x) => x.EventID,
                platformEventV1: (x) => x.EventID,
                platformCreatedV1: (x) => x.EventID,
                userEventV1: (x) => x.EventID,
                userCreatedV1: (x) => x.EventID,
                fundingEventCreatedV1: (x) => x.EventID,
                fundingEventEventV1: (x) => x.EventID
            );
        }
    }

    public string EventType
    {
        get
        {
            return Match(
                accountCreatedV1: (x) => x.EventType,
                accountEventV1: (x) => x.EventType,
                representativeEventV1: (x) => x.EventType,
                representativeCreatedV1: (x) => x.EventType,
                linkedBankAccountEventV1: (x) => x.EventType,
                linkedBankAccountCreatedV1: (x) => x.EventType,
                capabilityRequestEventV1: (x) => x.EventType,
                capabilityRequestCreatedV1: (x) => x.EventType,
                customerEventV1: (x) => x.EventType,
                customerCreatedV1: (x) => x.EventType,
                paykeyEventV1: (x) => x.EventType,
                paykeyCreatedV1: (x) => x.EventType,
                chargeCreatedV1: (x) => x.EventType,
                chargeEventV1: (x) => x.EventType,
                payoutCreatedV1: (x) => x.EventType,
                payoutEventV1: (x) => x.EventType,
                platformEventV1: (x) => x.EventType,
                platformCreatedV1: (x) => x.EventType,
                userEventV1: (x) => x.EventType,
                userCreatedV1: (x) => x.EventType,
                fundingEventCreatedV1: (x) => x.EventType,
                fundingEventEventV1: (x) => x.EventType
            );
        }
    }

    public UnwrapWebhookEvent(AccountCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(AccountEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(RepresentativeEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        RepresentativeCreatedV1WebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        LinkedBankAccountEventV1WebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        LinkedBankAccountCreatedV1WebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        CapabilityRequestEventV1WebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        CapabilityRequestCreatedV1WebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CustomerEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CustomerCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaykeyEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaykeyCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(ChargeCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(ChargeEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PayoutCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PayoutEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PlatformEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PlatformCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UserEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UserCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(FundingEventCreatedV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(FundingEventEventV1WebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccountCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccountCreatedV1(out var value)) {
    ///     // `value` is of type `AccountCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccountCreatedV1([NotNullWhen(true)] out AccountCreatedV1WebhookEvent? value)
    {
        value = this.Value as AccountCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccountEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccountEventV1(out var value)) {
    ///     // `value` is of type `AccountEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccountEventV1([NotNullWhen(true)] out AccountEventV1WebhookEvent? value)
    {
        value = this.Value as AccountEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RepresentativeEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRepresentativeEventV1(out var value)) {
    ///     // `value` is of type `RepresentativeEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRepresentativeEventV1(
        [NotNullWhen(true)] out RepresentativeEventV1WebhookEvent? value
    )
    {
        value = this.Value as RepresentativeEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RepresentativeCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRepresentativeCreatedV1(out var value)) {
    ///     // `value` is of type `RepresentativeCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRepresentativeCreatedV1(
        [NotNullWhen(true)] out RepresentativeCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as RepresentativeCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LinkedBankAccountEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLinkedBankAccountEventV1(out var value)) {
    ///     // `value` is of type `LinkedBankAccountEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLinkedBankAccountEventV1(
        [NotNullWhen(true)] out LinkedBankAccountEventV1WebhookEvent? value
    )
    {
        value = this.Value as LinkedBankAccountEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LinkedBankAccountCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLinkedBankAccountCreatedV1(out var value)) {
    ///     // `value` is of type `LinkedBankAccountCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLinkedBankAccountCreatedV1(
        [NotNullWhen(true)] out LinkedBankAccountCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as LinkedBankAccountCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CapabilityRequestEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCapabilityRequestEventV1(out var value)) {
    ///     // `value` is of type `CapabilityRequestEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCapabilityRequestEventV1(
        [NotNullWhen(true)] out CapabilityRequestEventV1WebhookEvent? value
    )
    {
        value = this.Value as CapabilityRequestEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CapabilityRequestCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCapabilityRequestCreatedV1(out var value)) {
    ///     // `value` is of type `CapabilityRequestCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCapabilityRequestCreatedV1(
        [NotNullWhen(true)] out CapabilityRequestCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as CapabilityRequestCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomerEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustomerEventV1(out var value)) {
    ///     // `value` is of type `CustomerEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustomerEventV1([NotNullWhen(true)] out CustomerEventV1WebhookEvent? value)
    {
        value = this.Value as CustomerEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomerCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustomerCreatedV1(out var value)) {
    ///     // `value` is of type `CustomerCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustomerCreatedV1(
        [NotNullWhen(true)] out CustomerCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as CustomerCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaykeyEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaykeyEventV1(out var value)) {
    ///     // `value` is of type `PaykeyEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaykeyEventV1([NotNullWhen(true)] out PaykeyEventV1WebhookEvent? value)
    {
        value = this.Value as PaykeyEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaykeyCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaykeyCreatedV1(out var value)) {
    ///     // `value` is of type `PaykeyCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaykeyCreatedV1([NotNullWhen(true)] out PaykeyCreatedV1WebhookEvent? value)
    {
        value = this.Value as PaykeyCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChargeCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChargeCreatedV1(out var value)) {
    ///     // `value` is of type `ChargeCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChargeCreatedV1([NotNullWhen(true)] out ChargeCreatedV1WebhookEvent? value)
    {
        value = this.Value as ChargeCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChargeEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChargeEventV1(out var value)) {
    ///     // `value` is of type `ChargeEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChargeEventV1([NotNullWhen(true)] out ChargeEventV1WebhookEvent? value)
    {
        value = this.Value as ChargeEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PayoutCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayoutCreatedV1(out var value)) {
    ///     // `value` is of type `PayoutCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayoutCreatedV1([NotNullWhen(true)] out PayoutCreatedV1WebhookEvent? value)
    {
        value = this.Value as PayoutCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PayoutEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPayoutEventV1(out var value)) {
    ///     // `value` is of type `PayoutEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPayoutEventV1([NotNullWhen(true)] out PayoutEventV1WebhookEvent? value)
    {
        value = this.Value as PayoutEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PlatformEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlatformEventV1(out var value)) {
    ///     // `value` is of type `PlatformEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlatformEventV1([NotNullWhen(true)] out PlatformEventV1WebhookEvent? value)
    {
        value = this.Value as PlatformEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PlatformCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlatformCreatedV1(out var value)) {
    ///     // `value` is of type `PlatformCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlatformCreatedV1(
        [NotNullWhen(true)] out PlatformCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as PlatformCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserEventV1(out var value)) {
    ///     // `value` is of type `UserEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserEventV1([NotNullWhen(true)] out UserEventV1WebhookEvent? value)
    {
        value = this.Value as UserEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserCreatedV1(out var value)) {
    ///     // `value` is of type `UserCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserCreatedV1([NotNullWhen(true)] out UserCreatedV1WebhookEvent? value)
    {
        value = this.Value as UserCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FundingEventCreatedV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFundingEventCreatedV1(out var value)) {
    ///     // `value` is of type `FundingEventCreatedV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFundingEventCreatedV1(
        [NotNullWhen(true)] out FundingEventCreatedV1WebhookEvent? value
    )
    {
        value = this.Value as FundingEventCreatedV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FundingEventEventV1WebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFundingEventEventV1(out var value)) {
    ///     // `value` is of type `FundingEventEventV1WebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFundingEventEventV1(
        [NotNullWhen(true)] out FundingEventEventV1WebhookEvent? value
    )
    {
        value = this.Value as FundingEventEventV1WebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AccountCreatedV1WebhookEvent value) =&gt; {...},
    ///     (AccountEventV1WebhookEvent value) =&gt; {...},
    ///     (RepresentativeEventV1WebhookEvent value) =&gt; {...},
    ///     (RepresentativeCreatedV1WebhookEvent value) =&gt; {...},
    ///     (LinkedBankAccountEventV1WebhookEvent value) =&gt; {...},
    ///     (LinkedBankAccountCreatedV1WebhookEvent value) =&gt; {...},
    ///     (CapabilityRequestEventV1WebhookEvent value) =&gt; {...},
    ///     (CapabilityRequestCreatedV1WebhookEvent value) =&gt; {...},
    ///     (CustomerEventV1WebhookEvent value) =&gt; {...},
    ///     (CustomerCreatedV1WebhookEvent value) =&gt; {...},
    ///     (PaykeyEventV1WebhookEvent value) =&gt; {...},
    ///     (PaykeyCreatedV1WebhookEvent value) =&gt; {...},
    ///     (ChargeCreatedV1WebhookEvent value) =&gt; {...},
    ///     (ChargeEventV1WebhookEvent value) =&gt; {...},
    ///     (PayoutCreatedV1WebhookEvent value) =&gt; {...},
    ///     (PayoutEventV1WebhookEvent value) =&gt; {...},
    ///     (PlatformEventV1WebhookEvent value) =&gt; {...},
    ///     (PlatformCreatedV1WebhookEvent value) =&gt; {...},
    ///     (UserEventV1WebhookEvent value) =&gt; {...},
    ///     (UserCreatedV1WebhookEvent value) =&gt; {...},
    ///     (FundingEventCreatedV1WebhookEvent value) =&gt; {...},
    ///     (FundingEventEventV1WebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<AccountCreatedV1WebhookEvent> accountCreatedV1,
        Action<AccountEventV1WebhookEvent> accountEventV1,
        Action<RepresentativeEventV1WebhookEvent> representativeEventV1,
        Action<RepresentativeCreatedV1WebhookEvent> representativeCreatedV1,
        Action<LinkedBankAccountEventV1WebhookEvent> linkedBankAccountEventV1,
        Action<LinkedBankAccountCreatedV1WebhookEvent> linkedBankAccountCreatedV1,
        Action<CapabilityRequestEventV1WebhookEvent> capabilityRequestEventV1,
        Action<CapabilityRequestCreatedV1WebhookEvent> capabilityRequestCreatedV1,
        Action<CustomerEventV1WebhookEvent> customerEventV1,
        Action<CustomerCreatedV1WebhookEvent> customerCreatedV1,
        Action<PaykeyEventV1WebhookEvent> paykeyEventV1,
        Action<PaykeyCreatedV1WebhookEvent> paykeyCreatedV1,
        Action<ChargeCreatedV1WebhookEvent> chargeCreatedV1,
        Action<ChargeEventV1WebhookEvent> chargeEventV1,
        Action<PayoutCreatedV1WebhookEvent> payoutCreatedV1,
        Action<PayoutEventV1WebhookEvent> payoutEventV1,
        Action<PlatformEventV1WebhookEvent> platformEventV1,
        Action<PlatformCreatedV1WebhookEvent> platformCreatedV1,
        Action<UserEventV1WebhookEvent> userEventV1,
        Action<UserCreatedV1WebhookEvent> userCreatedV1,
        Action<FundingEventCreatedV1WebhookEvent> fundingEventCreatedV1,
        Action<FundingEventEventV1WebhookEvent> fundingEventEventV1
    )
    {
        switch (this.Value)
        {
            case AccountCreatedV1WebhookEvent value:
                accountCreatedV1(value);
                break;
            case AccountEventV1WebhookEvent value:
                accountEventV1(value);
                break;
            case RepresentativeEventV1WebhookEvent value:
                representativeEventV1(value);
                break;
            case RepresentativeCreatedV1WebhookEvent value:
                representativeCreatedV1(value);
                break;
            case LinkedBankAccountEventV1WebhookEvent value:
                linkedBankAccountEventV1(value);
                break;
            case LinkedBankAccountCreatedV1WebhookEvent value:
                linkedBankAccountCreatedV1(value);
                break;
            case CapabilityRequestEventV1WebhookEvent value:
                capabilityRequestEventV1(value);
                break;
            case CapabilityRequestCreatedV1WebhookEvent value:
                capabilityRequestCreatedV1(value);
                break;
            case CustomerEventV1WebhookEvent value:
                customerEventV1(value);
                break;
            case CustomerCreatedV1WebhookEvent value:
                customerCreatedV1(value);
                break;
            case PaykeyEventV1WebhookEvent value:
                paykeyEventV1(value);
                break;
            case PaykeyCreatedV1WebhookEvent value:
                paykeyCreatedV1(value);
                break;
            case ChargeCreatedV1WebhookEvent value:
                chargeCreatedV1(value);
                break;
            case ChargeEventV1WebhookEvent value:
                chargeEventV1(value);
                break;
            case PayoutCreatedV1WebhookEvent value:
                payoutCreatedV1(value);
                break;
            case PayoutEventV1WebhookEvent value:
                payoutEventV1(value);
                break;
            case PlatformEventV1WebhookEvent value:
                platformEventV1(value);
                break;
            case PlatformCreatedV1WebhookEvent value:
                platformCreatedV1(value);
                break;
            case UserEventV1WebhookEvent value:
                userEventV1(value);
                break;
            case UserCreatedV1WebhookEvent value:
                userCreatedV1(value);
                break;
            case FundingEventCreatedV1WebhookEvent value:
                fundingEventCreatedV1(value);
                break;
            case FundingEventEventV1WebhookEvent value:
                fundingEventEventV1(value);
                break;
            default:
                throw new StraddleInvalidDataException(
                    "Data did not match any variant of UnwrapWebhookEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AccountCreatedV1WebhookEvent value) =&gt; {...},
    ///     (AccountEventV1WebhookEvent value) =&gt; {...},
    ///     (RepresentativeEventV1WebhookEvent value) =&gt; {...},
    ///     (RepresentativeCreatedV1WebhookEvent value) =&gt; {...},
    ///     (LinkedBankAccountEventV1WebhookEvent value) =&gt; {...},
    ///     (LinkedBankAccountCreatedV1WebhookEvent value) =&gt; {...},
    ///     (CapabilityRequestEventV1WebhookEvent value) =&gt; {...},
    ///     (CapabilityRequestCreatedV1WebhookEvent value) =&gt; {...},
    ///     (CustomerEventV1WebhookEvent value) =&gt; {...},
    ///     (CustomerCreatedV1WebhookEvent value) =&gt; {...},
    ///     (PaykeyEventV1WebhookEvent value) =&gt; {...},
    ///     (PaykeyCreatedV1WebhookEvent value) =&gt; {...},
    ///     (ChargeCreatedV1WebhookEvent value) =&gt; {...},
    ///     (ChargeEventV1WebhookEvent value) =&gt; {...},
    ///     (PayoutCreatedV1WebhookEvent value) =&gt; {...},
    ///     (PayoutEventV1WebhookEvent value) =&gt; {...},
    ///     (PlatformEventV1WebhookEvent value) =&gt; {...},
    ///     (PlatformCreatedV1WebhookEvent value) =&gt; {...},
    ///     (UserEventV1WebhookEvent value) =&gt; {...},
    ///     (UserCreatedV1WebhookEvent value) =&gt; {...},
    ///     (FundingEventCreatedV1WebhookEvent value) =&gt; {...},
    ///     (FundingEventEventV1WebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<AccountCreatedV1WebhookEvent, T> accountCreatedV1,
        Func<AccountEventV1WebhookEvent, T> accountEventV1,
        Func<RepresentativeEventV1WebhookEvent, T> representativeEventV1,
        Func<RepresentativeCreatedV1WebhookEvent, T> representativeCreatedV1,
        Func<LinkedBankAccountEventV1WebhookEvent, T> linkedBankAccountEventV1,
        Func<LinkedBankAccountCreatedV1WebhookEvent, T> linkedBankAccountCreatedV1,
        Func<CapabilityRequestEventV1WebhookEvent, T> capabilityRequestEventV1,
        Func<CapabilityRequestCreatedV1WebhookEvent, T> capabilityRequestCreatedV1,
        Func<CustomerEventV1WebhookEvent, T> customerEventV1,
        Func<CustomerCreatedV1WebhookEvent, T> customerCreatedV1,
        Func<PaykeyEventV1WebhookEvent, T> paykeyEventV1,
        Func<PaykeyCreatedV1WebhookEvent, T> paykeyCreatedV1,
        Func<ChargeCreatedV1WebhookEvent, T> chargeCreatedV1,
        Func<ChargeEventV1WebhookEvent, T> chargeEventV1,
        Func<PayoutCreatedV1WebhookEvent, T> payoutCreatedV1,
        Func<PayoutEventV1WebhookEvent, T> payoutEventV1,
        Func<PlatformEventV1WebhookEvent, T> platformEventV1,
        Func<PlatformCreatedV1WebhookEvent, T> platformCreatedV1,
        Func<UserEventV1WebhookEvent, T> userEventV1,
        Func<UserCreatedV1WebhookEvent, T> userCreatedV1,
        Func<FundingEventCreatedV1WebhookEvent, T> fundingEventCreatedV1,
        Func<FundingEventEventV1WebhookEvent, T> fundingEventEventV1
    )
    {
        return this.Value switch
        {
            AccountCreatedV1WebhookEvent value => accountCreatedV1(value),
            AccountEventV1WebhookEvent value => accountEventV1(value),
            RepresentativeEventV1WebhookEvent value => representativeEventV1(value),
            RepresentativeCreatedV1WebhookEvent value => representativeCreatedV1(value),
            LinkedBankAccountEventV1WebhookEvent value => linkedBankAccountEventV1(value),
            LinkedBankAccountCreatedV1WebhookEvent value => linkedBankAccountCreatedV1(value),
            CapabilityRequestEventV1WebhookEvent value => capabilityRequestEventV1(value),
            CapabilityRequestCreatedV1WebhookEvent value => capabilityRequestCreatedV1(value),
            CustomerEventV1WebhookEvent value => customerEventV1(value),
            CustomerCreatedV1WebhookEvent value => customerCreatedV1(value),
            PaykeyEventV1WebhookEvent value => paykeyEventV1(value),
            PaykeyCreatedV1WebhookEvent value => paykeyCreatedV1(value),
            ChargeCreatedV1WebhookEvent value => chargeCreatedV1(value),
            ChargeEventV1WebhookEvent value => chargeEventV1(value),
            PayoutCreatedV1WebhookEvent value => payoutCreatedV1(value),
            PayoutEventV1WebhookEvent value => payoutEventV1(value),
            PlatformEventV1WebhookEvent value => platformEventV1(value),
            PlatformCreatedV1WebhookEvent value => platformCreatedV1(value),
            UserEventV1WebhookEvent value => userEventV1(value),
            UserCreatedV1WebhookEvent value => userCreatedV1(value),
            FundingEventCreatedV1WebhookEvent value => fundingEventCreatedV1(value),
            FundingEventEventV1WebhookEvent value => fundingEventEventV1(value),
            _ => throw new StraddleInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnwrapWebhookEvent(AccountCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(AccountEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(RepresentativeEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(RepresentativeCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(
        LinkedBankAccountEventV1WebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(
        LinkedBankAccountCreatedV1WebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(
        CapabilityRequestEventV1WebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(
        CapabilityRequestCreatedV1WebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(CustomerEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CustomerCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaykeyEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaykeyCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(ChargeCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(ChargeEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PayoutCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PayoutEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PlatformEventV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PlatformCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(UserEventV1WebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(UserCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(FundingEventCreatedV1WebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(FundingEventEventV1WebhookEvent value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StraddleInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            );
        }
        this.Switch(
            (accountCreatedV1) => accountCreatedV1.Validate(),
            (accountEventV1) => accountEventV1.Validate(),
            (representativeEventV1) => representativeEventV1.Validate(),
            (representativeCreatedV1) => representativeCreatedV1.Validate(),
            (linkedBankAccountEventV1) => linkedBankAccountEventV1.Validate(),
            (linkedBankAccountCreatedV1) => linkedBankAccountCreatedV1.Validate(),
            (capabilityRequestEventV1) => capabilityRequestEventV1.Validate(),
            (capabilityRequestCreatedV1) => capabilityRequestCreatedV1.Validate(),
            (customerEventV1) => customerEventV1.Validate(),
            (customerCreatedV1) => customerCreatedV1.Validate(),
            (paykeyEventV1) => paykeyEventV1.Validate(),
            (paykeyCreatedV1) => paykeyCreatedV1.Validate(),
            (chargeCreatedV1) => chargeCreatedV1.Validate(),
            (chargeEventV1) => chargeEventV1.Validate(),
            (payoutCreatedV1) => payoutCreatedV1.Validate(),
            (payoutEventV1) => payoutEventV1.Validate(),
            (platformEventV1) => platformEventV1.Validate(),
            (platformCreatedV1) => platformCreatedV1.Validate(),
            (userEventV1) => userEventV1.Validate(),
            (userCreatedV1) => userCreatedV1.Validate(),
            (fundingEventCreatedV1) => fundingEventCreatedV1.Validate(),
            (fundingEventEventV1) => fundingEventEventV1.Validate()
        );
    }

    public virtual bool Equals(UnwrapWebhookEvent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AccountCreatedV1WebhookEvent _ => 0,
            AccountEventV1WebhookEvent _ => 1,
            RepresentativeEventV1WebhookEvent _ => 2,
            RepresentativeCreatedV1WebhookEvent _ => 3,
            LinkedBankAccountEventV1WebhookEvent _ => 4,
            LinkedBankAccountCreatedV1WebhookEvent _ => 5,
            CapabilityRequestEventV1WebhookEvent _ => 6,
            CapabilityRequestCreatedV1WebhookEvent _ => 7,
            CustomerEventV1WebhookEvent _ => 8,
            CustomerCreatedV1WebhookEvent _ => 9,
            PaykeyEventV1WebhookEvent _ => 10,
            PaykeyCreatedV1WebhookEvent _ => 11,
            ChargeCreatedV1WebhookEvent _ => 12,
            ChargeEventV1WebhookEvent _ => 13,
            PayoutCreatedV1WebhookEvent _ => 14,
            PayoutEventV1WebhookEvent _ => 15,
            PlatformEventV1WebhookEvent _ => 16,
            PlatformCreatedV1WebhookEvent _ => 17,
            UserEventV1WebhookEvent _ => 18,
            UserCreatedV1WebhookEvent _ => 19,
            FundingEventCreatedV1WebhookEvent _ => 20,
            FundingEventEventV1WebhookEvent _ => 21,
            _ => -1,
        };
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AccountCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AccountEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RepresentativeEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RepresentativeCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LinkedBankAccountEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LinkedBankAccountCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CapabilityRequestEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CapabilityRequestCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CustomerEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CustomerCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaykeyEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaykeyCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChargeCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChargeEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PayoutCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PayoutEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PlatformEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PlatformCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UserEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UserCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FundingEventCreatedV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FundingEventEventV1WebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is StraddleInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
