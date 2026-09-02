using System.Text.Json;
using Straddle.Exceptions;
using Straddle.Models.Organizations;
using Straddle.Models.Paykeys;
using Straddle.Models.Webhooks;
using Accounts = Straddle.Models.Accounts;
using AccountSettings = Straddle.Models.AccountSettings;
using Bridge = Straddle.Models.Bridge;
using CapabilityRequests = Straddle.Models.CapabilityRequests;
using Charges = Straddle.Models.Charges;
using Customers = Straddle.Models.Customers;
using FundingEvents = Straddle.Models.FundingEvents;
using LinkedBankAccounts = Straddle.Models.LinkedBankAccounts;
using PaykeysReview = Straddle.Models.Paykeys.Review;
using Payments = Straddle.Models.Payments;
using Representatives = Straddle.Models.Representatives;
using Review = Straddle.Models.Customers.Review;

namespace Straddle.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Accounts::AccessLevel>(),
            new ApiEnumConverter<string, Accounts::AccountType>(),
            new ApiEnumConverter<string, Accounts::SortOrder>(),
            new ApiEnumConverter<string, Accounts::Status>(),
            new ApiEnumConverter<string, Accounts::Type>(),
            new ApiEnumConverter<string, Accounts::FinalStatus>(),
            new ApiEnumConverter<string, CapabilityRequests::Category>(),
            new ApiEnumConverter<string, CapabilityRequests::SortOrder>(),
            new ApiEnumConverter<string, CapabilityRequests::Status>(),
            new ApiEnumConverter<string, CapabilityRequests::Type>(),
            new ApiEnumConverter<string, LinkedBankAccounts::Purpose>(),
            new ApiEnumConverter<string, LinkedBankAccounts::Level>(),
            new ApiEnumConverter<string, LinkedBankAccounts::LinkedBankAccountListParamsPurpose>(),
            new ApiEnumConverter<string, LinkedBankAccounts::SortOrder>(),
            new ApiEnumConverter<string, LinkedBankAccounts::Status>(),
            new ApiEnumConverter<string, SortOrder>(),
            new ApiEnumConverter<string, Representatives::Level>(),
            new ApiEnumConverter<string, Representatives::SortOrder>(),
            new ApiEnumConverter<string, Customers::SortBy>(),
            new ApiEnumConverter<string, Review::Status>(),
            new ApiEnumConverter<string, SortBy>(),
            new ApiEnumConverter<string, PaykeysReview::Status>(),
            new ApiEnumConverter<string, FundingEvents::SortBy>(),
            new ApiEnumConverter<string, FundingEvents::DefaultSort>(),
            new ApiEnumConverter<string, FundingEvents::FundingEventListPaymentsParamsSortBy>(),
            new ApiEnumConverter<string, FundingEvents::FundingEventJobType>(),
            new ApiEnumConverter<string, Payments::DefaultSort>(),
            new ApiEnumConverter<string, Payments::SortBy>(),
            new ApiEnumConverter<string, Accounts::AccountAccessLevel>(),
            new ApiEnumConverter<string, Accounts::AccountStatus>(),
            new ApiEnumConverter<string, Accounts::AccountType2>(),
            new ApiEnumConverter<string, Accounts::CapabilityStatus>(),
            new ApiEnumConverter<string, Accounts::FundingTime>(),
            new ApiEnumConverter<string, AccountSettings::Internet>(),
            new ApiEnumConverter<string, AccountSettings::SignedAgreement>(),
            new ApiEnumConverter<string, AccountSettings::Businesses>(),
            new ApiEnumConverter<string, AccountSettings::Individuals>(),
            new ApiEnumConverter<string, Accounts::ResponseType>(),
            new ApiEnumConverter<string, AccountSettings::AccountPaymentTypeSettingsCharges>(),
            new ApiEnumConverter<string, AccountSettings::AccountPaymentTypeSettingsPayouts>(),
            new ApiEnumConverter<string, Accounts::AccountPayoutSettingsFundingTime>(),
            new ApiEnumConverter<string, Accounts::AccountResponseResponseType>(),
            new ApiEnumConverter<string, AccountSettings::ResponseType>(),
            new ApiEnumConverter<string, Accounts::Reason>(),
            new ApiEnumConverter<string, Accounts::Source>(),
            new ApiEnumConverter<string, Bridge::AccountType>(),
            new ApiEnumConverter<string, Charges::BalanceCheckMode>(),
            new ApiEnumConverter<string, CapabilityRequests::CapabilityRequestCategory>(),
            new ApiEnumConverter<string, CapabilityRequests::CapabilityRequestStatus>(),
            new ApiEnumConverter<string, CapabilityRequests::CapabilityRequestType>(),
            new ApiEnumConverter<string, CapabilityRequests::ResponseType>(),
            new ApiEnumConverter<string, Charges::ConsentType>(),
            new ApiEnumConverter<string, Review::CorrelationBucket>(),
            new ApiEnumConverter<string, Customers::CustomerStatus>(),
            new ApiEnumConverter<string, Customers::CustomerType>(),
            new ApiEnumConverter<string, FundingEvents::FundingEventPaymentReason>(),
            new ApiEnumConverter<string, FundingEvents::FundingEventTransferDirection>(),
            new ApiEnumConverter<string, FundingEvents::FundingEventType>(),
            new ApiEnumConverter<string, LinkedBankAccounts::LinkedBankAccountPurpose>(),
            new ApiEnumConverter<string, LinkedBankAccounts::LinkedBankAccountStatus>(),
            new ApiEnumConverter<string, LinkedBankAccounts::ResponseType>(),
            new ApiEnumConverter<
                string,
                LinkedBankAccounts::LinkedBankAccountResponseResponseType
            >(),
            new ApiEnumConverter<string, LinkedBankAccounts::Reason>(),
            new ApiEnumConverter<string, LinkedBankAccounts::Source>(),
            new ApiEnumConverter<string, ResponseType>(),
            new ApiEnumConverter<string, OrganizationResponseResponseType>(),
            new ApiEnumConverter<string, Bridge::PaykeyBalanceRefreshStatus>(),
            new ApiEnumConverter<string, Bridge::PaykeyProcessingMode>(),
            new ApiEnumConverter<string, Bridge::PaykeySource>(),
            new ApiEnumConverter<string, Bridge::PaykeyStatus>(),
            new ApiEnumConverter<string, PaykeysReview::PaykeyVerificationResult>(),
            new ApiEnumConverter<string, Charges::PaymentDocumentType>(),
            new ApiEnumConverter<string, Charges::PaymentRail>(),
            new ApiEnumConverter<string, Charges::PaymentRelationship>(),
            new ApiEnumConverter<string, Charges::PaymentStatus>(),
            new ApiEnumConverter<string, Bridge::PaymentStatusReason>(),
            new ApiEnumConverter<string, Bridge::PaymentStatusSource>(),
            new ApiEnumConverter<string, Charges::PaymentType>(),
            new ApiEnumConverter<string, Representatives::Status>(),
            new ApiEnumConverter<string, Representatives::ResponseType>(),
            new ApiEnumConverter<string, Representatives::RepresentativeResponseResponseType>(),
            new ApiEnumConverter<string, Representatives::Reason>(),
            new ApiEnumConverter<string, Representatives::Source>(),
            new ApiEnumConverter<string, Bridge::ResponseType>(),
            new ApiEnumConverter<string, Customers::SimulatedCustomerOutcome>(),
            new ApiEnumConverter<string, Bridge::SimulatedPaykeyOutcome>(),
            new ApiEnumConverter<string, Charges::SimulatedPaymentOutcome>(),
            new ApiEnumConverter<string, Accounts::AccountSortOrder>(),
            new ApiEnumConverter<string, Accounts::AgreementType>(),
            new ApiEnumConverter<string, FundingEvents::TransferDirection>(),
            new ApiEnumConverter<string, LinkedBankAccounts::UnmaskedLinkedBankAccountStatus>(),
            new ApiEnumConverter<
                string,
                LinkedBankAccounts::UnmaskedLinkedBankAccountResponseResponseType
            >(),
            new ApiEnumConverter<string, Representatives::UnmaskedRepresentativeStatus>(),
            new ApiEnumConverter<
                string,
                Representatives::UnmaskedRepresentativeResponseResponseType
            >(),
            new ApiEnumConverter<string, Review::VerificationDecision>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, CustomerCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, PaykeyEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, PaykeyCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, PaykeyCreatedV1WebhookEventDataStatusDetailsReason>(),
            new ApiEnumConverter<string, ConsentType>(),
            new ApiEnumConverter<string, ChargeCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, ChargeCreatedV1WebhookEventDataStatusDetailsReason>(),
            new ApiEnumConverter<string, StatusHistoryReason>(),
            new ApiEnumConverter<string, StatusHistoryStatus>(),
            new ApiEnumConverter<string, PaymentRail>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataConsentType>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataStatusDetailsReason>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataStatusHistoryReason>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataStatusHistoryStatus>(),
            new ApiEnumConverter<string, ChargeEventV1WebhookEventDataPaymentRail>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataConsentType>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataStatusDetailsReason>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataStatusHistoryReason>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataStatusHistoryStatus>(),
            new ApiEnumConverter<string, PayoutCreatedV1WebhookEventDataPaymentRail>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataConsentType>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataStatusDetailsReason>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataStatusHistoryReason>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataStatusHistoryStatus>(),
            new ApiEnumConverter<string, PayoutEventV1WebhookEventDataPaymentRail>(),
            new ApiEnumConverter<string, PlatformEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, StatusDetailReason>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, PlatformCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, PlatformCreatedV1WebhookEventDataStatusDetailReason>(),
            new ApiEnumConverter<string, PlatformCreatedV1WebhookEventDataStatusDetailSource>(),
            new ApiEnumConverter<string, Level>(),
            new ApiEnumConverter<string, MembershipLevel>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, UserEventV1WebhookEventDataRole>(),
            new ApiEnumConverter<string, UserEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, UserCreatedV1WebhookEventDataLevel>(),
            new ApiEnumConverter<string, UserCreatedV1WebhookEventDataMembershipLevel>(),
            new ApiEnumConverter<string, UserCreatedV1WebhookEventDataMembershipRole>(),
            new ApiEnumConverter<string, UserCreatedV1WebhookEventDataRole>(),
            new ApiEnumConverter<string, UserCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<
                string,
                FundingEventCreatedV1WebhookEventDataStatusHistoryReason
            >(),
            new ApiEnumConverter<
                string,
                FundingEventCreatedV1WebhookEventDataStatusHistoryStatus
            >(),
            new ApiEnumConverter<string, FundingEventCreatedV1WebhookEventDataStatus>(),
            new ApiEnumConverter<
                string,
                FundingEventCreatedV1WebhookEventDataStatusDetailsReason
            >(),
            new ApiEnumConverter<string, FundingEventEventV1WebhookEventDataStatusHistoryReason>(),
            new ApiEnumConverter<string, FundingEventEventV1WebhookEventDataStatusHistoryStatus>(),
            new ApiEnumConverter<string, FundingEventEventV1WebhookEventDataStatus>(),
            new ApiEnumConverter<string, FundingEventEventV1WebhookEventDataStatusDetailsReason>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StraddleInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
