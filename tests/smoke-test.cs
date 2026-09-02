using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 0618 // A smoke run exercises deprecated operations deliberately.

// Smoke test: calls every generated operation once to confirm the SDK can
// reach each endpoint. The generator runs this against a mock server and
// reads the JSON report written to SCALAR_SMOKE_REPORT.
internal static class SmokeProgram
{
    // `Label` says which of an operation's two calls this is — "required params" or "all
    // params". It is empty when the operation contributed a single case.
    private sealed record SmokeCase(
        string Operation,
        string Method,
        string Path,
        string Label,
        Func<global::Straddle.StraddleClient, CancellationToken, Task> Run
    );

    private static readonly IReadOnlyList<SmokeCase> Cases = new SmokeCase[]
    {
        new SmokeCase(
            "create",
            "POST",
            "/v1/accounts",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Create(
                        new global::Straddle.Models.Accounts.AccountCreateParams
                        {
                            AccessLevel = global::Straddle.Models.Accounts.AccessLevel.Standard,
                            AccountType = global::Straddle.Models.Accounts.AccountType.Business,
                            BusinessProfile =
                                new global::Straddle.Models.Accounts.AccountBusinessProfile
                                {
                                    Name = "smoke",
                                    Website = "smoke",
                                },
                            OrganizationID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/accounts",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Create(
                        new global::Straddle.Models.Accounts.AccountCreateParams
                        {
                            AccessLevel = global::Straddle.Models.Accounts.AccessLevel.Standard,
                            AccountType = global::Straddle.Models.Accounts.AccountType.Business,
                            BusinessProfile =
                                new global::Straddle.Models.Accounts.AccountBusinessProfile
                                {
                                    Name = "smoke",
                                    Website = "smoke",
                                },
                            OrganizationID = "smoke",
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/accounts/{account_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Retrieve(
                        new global::Straddle.Models.Accounts.AccountRetrieveParams
                        {
                            AccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/accounts/{account_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Retrieve(
                        new global::Straddle.Models.Accounts.AccountRetrieveParams
                        {
                            AccountID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/accounts/{account_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Update(
                        new global::Straddle.Models.Accounts.AccountUpdateParams
                        {
                            AccountID = "smoke",
                            BusinessProfile =
                                new global::Straddle.Models.Accounts.AccountBusinessProfile
                                {
                                    Name = "smoke",
                                    Website = "smoke",
                                },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/accounts/{account_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Update(
                        new global::Straddle.Models.Accounts.AccountUpdateParams
                        {
                            AccountID = "smoke",
                            BusinessProfile =
                                new global::Straddle.Models.Accounts.AccountBusinessProfile
                                {
                                    Name = "smoke",
                                    Website = "smoke",
                                },
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/accounts",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.List(
                        new global::Straddle.Models.Accounts.AccountListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/accounts",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.List(
                        new global::Straddle.Models.Accounts.AccountListParams
                        {
                            CorrelationID = "smoke",
                            ExternalID = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SearchText = "smoke",
                            SortBy = "smoke",
                            SortOrder = global::Straddle.Models.Accounts.SortOrder.Asc,
                            Status = global::Straddle.Models.Accounts.Status.Created,
                            Type = global::Straddle.Models.Accounts.Type.Business,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "onboard",
            "POST",
            "/v1/accounts/{account_id}/onboard",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Onboard(
                        new global::Straddle.Models.Accounts.AccountOnboardParams
                        {
                            AccountID = "smoke",
                            TermsOfService = new global::Straddle.Models.Accounts.TermsOfService
                            {
                                AcceptedDate = System.DateTimeOffset.UnixEpoch,
                                AgreementType = global::Straddle
                                    .Models
                                    .Accounts
                                    .AgreementType
                                    .Embedded,
                                AgreementUrl = null,
                            },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "onboard",
            "POST",
            "/v1/accounts/{account_id}/onboard",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.Onboard(
                        new global::Straddle.Models.Accounts.AccountOnboardParams
                        {
                            AccountID = "smoke",
                            TermsOfService = new global::Straddle.Models.Accounts.TermsOfService
                            {
                                AcceptedDate = System.DateTimeOffset.UnixEpoch,
                                AgreementType = global::Straddle
                                    .Models
                                    .Accounts
                                    .AgreementType
                                    .Embedded,
                                AgreementUrl = null,
                            },
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "simulateOnboarding",
            "POST",
            "/v1/accounts/{account_id}/simulate",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.SimulateOnboarding(
                        new global::Straddle.Models.Accounts.AccountSimulateOnboardingParams
                        {
                            AccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "simulateOnboarding",
            "POST",
            "/v1/accounts/{account_id}/simulate",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Accounts.SimulateOnboarding(
                        new global::Straddle.Models.Accounts.AccountSimulateOnboardingParams
                        {
                            AccountID = "smoke",
                            CorrelationID = "smoke",
                            FinalStatus = global::Straddle.Models.Accounts.FinalStatus.Onboarding,
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/accounts/{account_id}/capability_requests",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .CapabilityRequests.Create(
                        new global::Straddle.Models.CapabilityRequests.CapabilityRequestCreateParams
                        {
                            AccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/accounts/{account_id}/capability_requests",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .CapabilityRequests.Create(
                        new global::Straddle.Models.CapabilityRequests.CapabilityRequestCreateParams
                        {
                            AccountID = "smoke",
                            Businesses = new global::Straddle.Models.CapabilityRequests.Businesses
                            {
                                Enable = true,
                            },
                            Charges =
                                new global::Straddle.Models.CapabilityRequests.CapabilityRequestCreateParamsCharges
                                {
                                    DailyAmount = 1,
                                    Enable = true,
                                    MaxAmount = 1,
                                    MonthlyAmount = 1,
                                    MonthlyCount = 1,
                                },
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Individuals = new global::Straddle.Models.CapabilityRequests.Individuals
                            {
                                Enable = true,
                            },
                            Internet = new global::Straddle.Models.CapabilityRequests.Internet
                            {
                                Enable = true,
                            },
                            Payouts =
                                new global::Straddle.Models.CapabilityRequests.CapabilityRequestCreateParamsPayouts
                                {
                                    DailyAmount = 1,
                                    Enable = true,
                                    MaxAmount = 1,
                                    MonthlyAmount = 1,
                                    MonthlyCount = 1,
                                },
                            RequestID = "smoke",
                            SignedAgreement =
                                new global::Straddle.Models.CapabilityRequests.SignedAgreement
                                {
                                    Enable = true,
                                },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/accounts/{account_id}/capability_requests",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .CapabilityRequests.List(
                        new global::Straddle.Models.CapabilityRequests.CapabilityRequestListParams
                        {
                            AccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/accounts/{account_id}/capability_requests",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .CapabilityRequests.List(
                        new global::Straddle.Models.CapabilityRequests.CapabilityRequestListParams
                        {
                            AccountID = "smoke",
                            Category = global::Straddle
                                .Models
                                .CapabilityRequests
                                .Category
                                .PaymentType,
                            CorrelationID = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SortBy = "smoke",
                            SortOrder = global::Straddle.Models.CapabilityRequests.SortOrder.Asc,
                            Status = global::Straddle.Models.CapabilityRequests.Status.Active,
                            Type = global::Straddle.Models.CapabilityRequests.Type.Charges,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/linked_bank_accounts",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Create(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountCreateParams
                        {
                            BankAccount = new global::Straddle.Models.LinkedBankAccounts.BankAccount
                            {
                                AccountHolder = "smoke",
                                AccountNumber = "smoke",
                                RoutingNumber = "smoke",
                            },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/linked_bank_accounts",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Create(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountCreateParams
                        {
                            BankAccount = new global::Straddle.Models.LinkedBankAccounts.BankAccount
                            {
                                AccountHolder = "smoke",
                                AccountNumber = "smoke",
                                RoutingNumber = "smoke",
                            },
                            AccountID = null,
                            CorrelationID = "smoke",
                            Description = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            PlatformID = null,
                            Purposes = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/linked_bank_accounts/{linked_bank_account_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Retrieve(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountRetrieveParams
                        {
                            LinkedBankAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/linked_bank_accounts/{linked_bank_account_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Retrieve(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountRetrieveParams
                        {
                            LinkedBankAccountID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/linked_bank_accounts/{linked_bank_account_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Update(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountUpdateParams
                        {
                            BankAccount =
                                new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountUpdateParamsBankAccount
                                {
                                    AccountHolder = "smoke",
                                    AccountNumber = "smoke",
                                    RoutingNumber = "smoke",
                                },
                            LinkedBankAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/linked_bank_accounts/{linked_bank_account_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Update(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountUpdateParams
                        {
                            BankAccount =
                                new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountUpdateParamsBankAccount
                                {
                                    AccountHolder = "smoke",
                                    AccountNumber = "smoke",
                                    RoutingNumber = "smoke",
                                },
                            LinkedBankAccountID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/linked_bank_accounts",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.List(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/linked_bank_accounts",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.List(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountListParams
                        {
                            AccountID = "smoke",
                            CorrelationID = "smoke",
                            Level = global::Straddle.Models.LinkedBankAccounts.Level.Account,
                            PageNumber = 1,
                            PageSize = 1,
                            Purpose = global::Straddle
                                .Models
                                .LinkedBankAccounts
                                .LinkedBankAccountListParamsPurpose
                                .Charges,
                            RequestID = "smoke",
                            SortBy = "smoke",
                            SortOrder = global::Straddle.Models.LinkedBankAccounts.SortOrder.Asc,
                            Status = global::Straddle.Models.LinkedBankAccounts.Status.Created,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PATCH",
            "/v1/linked_bank_accounts/{linked_bank_account_id}/cancel",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Cancel(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountCancelParams
                        {
                            LinkedBankAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PATCH",
            "/v1/linked_bank_accounts/{linked_bank_account_id}/cancel",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.Cancel(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountCancelParams
                        {
                            LinkedBankAccountID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/linked_bank_accounts/{linked_bank_account_id}/unmask",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.ListUnmasked(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountListUnmaskedParams
                        {
                            LinkedBankAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/linked_bank_accounts/{linked_bank_account_id}/unmask",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .LinkedBankAccounts.ListUnmasked(
                        new global::Straddle.Models.LinkedBankAccounts.LinkedBankAccountListUnmaskedParams
                        {
                            LinkedBankAccountID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/organizations",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.Create(
                        new global::Straddle.Models.Organizations.OrganizationCreateParams
                        {
                            Name = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/organizations",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.Create(
                        new global::Straddle.Models.Organizations.OrganizationCreateParams
                        {
                            Name = "smoke",
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/organizations/{organization_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.Retrieve(
                        new global::Straddle.Models.Organizations.OrganizationRetrieveParams
                        {
                            OrganizationID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/organizations/{organization_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.Retrieve(
                        new global::Straddle.Models.Organizations.OrganizationRetrieveParams
                        {
                            OrganizationID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/organizations",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.List(
                        new global::Straddle.Models.Organizations.OrganizationListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/organizations",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Organizations.List(
                        new global::Straddle.Models.Organizations.OrganizationListParams
                        {
                            CorrelationID = "smoke",
                            ExternalID = "smoke",
                            Name = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SortBy = "smoke",
                            SortOrder = global::Straddle.Models.Organizations.SortOrder.Asc,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/representatives",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Create(
                        new global::Straddle.Models.Representatives.RepresentativeCreateParams
                        {
                            AccountID = "smoke",
                            Dob = "1980-01-01",
                            Email = "ron.swanson@pawnee.com",
                            FirstName = "smoke",
                            LastName = "smoke",
                            MobileNumber = "+12128675309",
                            Relationship =
                                new global::Straddle.Models.Representatives.RepresentativeRelationship
                                {
                                    Control = true,
                                    Owner = true,
                                    Primary = true,
                                },
                            SsnLast4 = "1234",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/representatives",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Create(
                        new global::Straddle.Models.Representatives.RepresentativeCreateParams
                        {
                            AccountID = "smoke",
                            Dob = "1980-01-01",
                            Email = "ron.swanson@pawnee.com",
                            FirstName = "smoke",
                            LastName = "smoke",
                            MobileNumber = "+12128675309",
                            Relationship =
                                new global::Straddle.Models.Representatives.RepresentativeRelationship
                                {
                                    Control = true,
                                    Owner = true,
                                    Primary = true,
                                },
                            SsnLast4 = "1234",
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/representatives/{representative_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Retrieve(
                        new global::Straddle.Models.Representatives.RepresentativeRetrieveParams
                        {
                            RepresentativeID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/representatives/{representative_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Retrieve(
                        new global::Straddle.Models.Representatives.RepresentativeRetrieveParams
                        {
                            RepresentativeID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/representatives/{representative_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Update(
                        new global::Straddle.Models.Representatives.RepresentativeUpdateParams
                        {
                            Dob = "1980-01-01",
                            Email = "ron.swanson@pawnee.com",
                            FirstName = "Ron",
                            LastName = "Swanson",
                            MobileNumber = "+12128675309",
                            Relationship =
                                new global::Straddle.Models.Representatives.RepresentativeRelationship
                                {
                                    Control = true,
                                    Owner = true,
                                    Primary = true,
                                },
                            RepresentativeID = "smoke",
                            SsnLast4 = "1234",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/representatives/{representative_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.Update(
                        new global::Straddle.Models.Representatives.RepresentativeUpdateParams
                        {
                            Dob = "1980-01-01",
                            Email = "ron.swanson@pawnee.com",
                            FirstName = "Ron",
                            LastName = "Swanson",
                            MobileNumber = "+12128675309",
                            Relationship =
                                new global::Straddle.Models.Representatives.RepresentativeRelationship
                                {
                                    Control = true,
                                    Owner = true,
                                    Primary = true,
                                },
                            RepresentativeID = "smoke",
                            SsnLast4 = "1234",
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/representatives",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.List(
                        new global::Straddle.Models.Representatives.RepresentativeListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/representatives",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.List(
                        new global::Straddle.Models.Representatives.RepresentativeListParams
                        {
                            AccountID = "smoke",
                            CorrelationID = "smoke",
                            Level = global::Straddle.Models.Representatives.Level.Account,
                            OrganizationID = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            PlatformID = "smoke",
                            RequestID = "smoke",
                            SortBy = "smoke",
                            SortOrder = global::Straddle.Models.Representatives.SortOrder.Asc,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/representatives/{representative_id}/unmask",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.ListUnmasked(
                        new global::Straddle.Models.Representatives.RepresentativeListUnmaskedParams
                        {
                            RepresentativeID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/representatives/{representative_id}/unmask",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Representatives.ListUnmasked(
                        new global::Straddle.Models.Representatives.RepresentativeListUnmaskedParams
                        {
                            RepresentativeID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createBankAccountPaykey",
            "POST",
            "/v1/bridge/bank_account",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateBankAccountPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreateBankAccountPaykeyParams
                        {
                            AccountNumber = "smoke",
                            AccountType = global::Straddle.Models.Bridge.AccountType.Checking,
                            CustomerID = "smoke",
                            RoutingNumber = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createBankAccountPaykey",
            "POST",
            "/v1/bridge/bank_account",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateBankAccountPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreateBankAccountPaykeyParams
                        {
                            AccountNumber = "smoke",
                            AccountType = global::Straddle.Models.Bridge.AccountType.Checking,
                            CustomerID = "smoke",
                            RoutingNumber = "smoke",
                            Config = new global::Straddle.Models.Bridge.PaykeyConfiguration(),
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createPlaidPaykey",
            "POST",
            "/v1/bridge/plaid",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreatePlaidPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreatePlaidPaykeyParams
                        {
                            CustomerID = "smoke",
                            PlaidToken = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createPlaidPaykey",
            "POST",
            "/v1/bridge/plaid",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreatePlaidPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreatePlaidPaykeyParams
                        {
                            CustomerID = "smoke",
                            PlaidToken = "smoke",
                            Config = new global::Straddle.Models.Bridge.PaykeyConfiguration(),
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createQuilttPaykey",
            "POST",
            "/v1/bridge/quiltt",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateQuilttPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreateQuilttPaykeyParams
                        {
                            CustomerID = "smoke",
                            QuilttToken = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createQuilttPaykey",
            "POST",
            "/v1/bridge/quiltt",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateQuilttPaykey(
                        new global::Straddle.Models.Bridge.BridgeCreateQuilttPaykeyParams
                        {
                            CustomerID = "smoke",
                            QuilttToken = "smoke",
                            Config = new global::Straddle.Models.Bridge.PaykeyConfiguration(),
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createToken",
            "POST",
            "/v1/bridge/initialize",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateToken(
                        new global::Straddle.Models.Bridge.BridgeCreateTokenParams
                        {
                            CustomerID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createToken",
            "POST",
            "/v1/bridge/initialize",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Bridge.CreateToken(
                        new global::Straddle.Models.Bridge.BridgeCreateTokenParams
                        {
                            CustomerID = "smoke",
                            Config = new global::Straddle.Models.Bridge.PaykeyConfiguration(),
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/customers",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Create(
                        new global::Straddle.Models.Customers.CustomerCreateParams
                        {
                            Device = new global::Straddle.Models.Customers.CustomerDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            Email = "ron.swanson@pawnee.com",
                            Name = "Ron Swanson",
                            Phone = "+12128675309",
                            Type = global::Straddle.Models.Customers.CustomerType.Individual,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/customers",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Create(
                        new global::Straddle.Models.Customers.CustomerCreateParams
                        {
                            Device = new global::Straddle.Models.Customers.CustomerDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            Email = "ron.swanson@pawnee.com",
                            Name = "Ron Swanson",
                            Phone = "+12128675309",
                            Type = global::Straddle.Models.Customers.CustomerType.Individual,
                            Address = null,
                            ComplianceProfile = null,
                            Config = new global::Straddle.Models.Customers.CustomerConfiguration(),
                            CorrelationID = "smoke",
                            ExternalID = "customer_123",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/customers/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Retrieve(
                        new global::Straddle.Models.Customers.CustomerRetrieveParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/customers/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Retrieve(
                        new global::Straddle.Models.Customers.CustomerRetrieveParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/customers/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Update(
                        new global::Straddle.Models.Customers.CustomerUpdateParams
                        {
                            ID = "smoke",
                            Device = new global::Straddle.Models.Customers.CustomerDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            Email = "smoke",
                            Name = "smoke",
                            Phone = "smoke",
                            Status = global::Straddle.Models.Customers.CustomerStatus.Verified,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/customers/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Update(
                        new global::Straddle.Models.Customers.CustomerUpdateParams
                        {
                            ID = "smoke",
                            Device = new global::Straddle.Models.Customers.CustomerDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            Email = "smoke",
                            Name = "smoke",
                            Phone = "smoke",
                            Status = global::Straddle.Models.Customers.CustomerStatus.Verified,
                            Address = null,
                            ComplianceProfile = null,
                            CorrelationID = "smoke",
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/customers",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.List(
                        new global::Straddle.Models.Customers.CustomerListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/customers",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.List(
                        new global::Straddle.Models.Customers.CustomerListParams
                        {
                            CorrelationID = "smoke",
                            CreatedFrom = System.DateTimeOffset.UnixEpoch,
                            CreatedTo = System.DateTimeOffset.UnixEpoch,
                            Email = "smoke",
                            ExternalID = "smoke",
                            Name = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SearchText = "smoke",
                            SortBy = global::Straddle.Models.Customers.SortBy.Name,
                            SortOrder = global::Straddle.Models.Accounts.AccountSortOrder.Asc,
                            Status =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Customers.CustomerStatus
                                >>(),
                            StraddleAccountID = "smoke",
                            Types =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Customers.CustomerType
                                >>(),
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "delete",
            "DELETE",
            "/v1/customers/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Delete(
                        new global::Straddle.Models.Customers.CustomerDeleteParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "delete",
            "DELETE",
            "/v1/customers/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Delete(
                        new global::Straddle.Models.Customers.CustomerDeleteParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/customers/{id}/unmasked",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.ListUnmasked(
                        new global::Straddle.Models.Customers.CustomerListUnmaskedParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/customers/{id}/unmasked",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.ListUnmasked(
                        new global::Straddle.Models.Customers.CustomerListUnmaskedParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshReview",
            "PUT",
            "/v1/customers/{id}/refresh_review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.RefreshReview(
                        new global::Straddle.Models.Customers.CustomerRefreshReviewParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshReview",
            "PUT",
            "/v1/customers/{id}/refresh_review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.RefreshReview(
                        new global::Straddle.Models.Customers.CustomerRefreshReviewParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/customers/{id}/review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Review.List(
                        new global::Straddle.Models.Customers.Review.ReviewListParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/customers/{id}/review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Review.List(
                        new global::Straddle.Models.Customers.Review.ReviewListParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "setVerificationDecision",
            "PATCH",
            "/v1/customers/{id}/review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Review.SetVerificationDecision(
                        new global::Straddle.Models.Customers.Review.ReviewSetVerificationDecisionParams
                        {
                            ID = "smoke",
                            Status = global::Straddle.Models.Customers.Review.Status.Verified,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "setVerificationDecision",
            "PATCH",
            "/v1/customers/{id}/review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Customers.Review.SetVerificationDecision(
                        new global::Straddle.Models.Customers.Review.ReviewSetVerificationDecisionParams
                        {
                            ID = "smoke",
                            Status = global::Straddle.Models.Customers.Review.Status.Verified,
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/paykeys/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Retrieve(
                        new global::Straddle.Models.Paykeys.PaykeyRetrieveParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/paykeys/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Retrieve(
                        new global::Straddle.Models.Paykeys.PaykeyRetrieveParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/paykeys",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.List(
                        new global::Straddle.Models.Paykeys.PaykeyListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/paykeys",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.List(
                        new global::Straddle.Models.Paykeys.PaykeyListParams
                        {
                            CorrelationID = "smoke",
                            CreatedFrom = System.DateTimeOffset.UnixEpoch,
                            CreatedTo = System.DateTimeOffset.UnixEpoch,
                            CustomerID = "smoke",
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SearchText = "smoke",
                            SortBy = global::Straddle.Models.Paykeys.SortBy.InstitutionName,
                            SortOrder = global::Straddle.Models.Accounts.AccountSortOrder.Asc,
                            Source =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Bridge.PaykeySource
                                >>(),
                            Status =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Bridge.PaykeyStatus
                                >>(),
                            StraddleAccountID = "smoke",
                            UnblockEligible = true,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/paykeys/{id}/cancel",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Cancel(
                        new global::Straddle.Models.Paykeys.PaykeyCancelParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/paykeys/{id}/cancel",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Cancel(
                        new global::Straddle.Models.Paykeys.PaykeyCancelParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/paykeys/{id}/unmasked",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.ListUnmasked(
                        new global::Straddle.Models.Paykeys.PaykeyListUnmaskedParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/paykeys/{id}/unmasked",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.ListUnmasked(
                        new global::Straddle.Models.Paykeys.PaykeyListUnmaskedParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshBalance",
            "PUT",
            "/v1/paykeys/{id}/refresh_balance",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.RefreshBalance(
                        new global::Straddle.Models.Paykeys.PaykeyRefreshBalanceParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshBalance",
            "PUT",
            "/v1/paykeys/{id}/refresh_balance",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.RefreshBalance(
                        new global::Straddle.Models.Paykeys.PaykeyRefreshBalanceParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshReview",
            "PUT",
            "/v1/paykeys/{id}/refresh_review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.RefreshReview(
                        new global::Straddle.Models.Paykeys.PaykeyRefreshReviewParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refreshReview",
            "PUT",
            "/v1/paykeys/{id}/refresh_review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.RefreshReview(
                        new global::Straddle.Models.Paykeys.PaykeyRefreshReviewParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "reveal",
            "GET",
            "/v1/paykeys/{id}/reveal",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Reveal(
                        new global::Straddle.Models.Paykeys.PaykeyRevealParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "reveal",
            "GET",
            "/v1/paykeys/{id}/reveal",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Reveal(
                        new global::Straddle.Models.Paykeys.PaykeyRevealParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "unblock",
            "PATCH",
            "/v1/paykeys/{id}/unblock",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Unblock(
                        new global::Straddle.Models.Paykeys.PaykeyUnblockParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "unblock",
            "PATCH",
            "/v1/paykeys/{id}/unblock",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Unblock(
                        new global::Straddle.Models.Paykeys.PaykeyUnblockParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Message = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/paykeys/{id}/review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Review.List(
                        new global::Straddle.Models.Paykeys.Review.ReviewListParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/paykeys/{id}/review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Review.List(
                        new global::Straddle.Models.Paykeys.Review.ReviewListParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "setVerificationDecision",
            "PATCH",
            "/v1/paykeys/{id}/review",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Review.SetVerificationDecision(
                        new global::Straddle.Models.Paykeys.Review.ReviewSetVerificationDecisionParams
                        {
                            ID = "smoke",
                            Status = global::Straddle.Models.Paykeys.Review.Status.Active,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "setVerificationDecision",
            "PATCH",
            "/v1/paykeys/{id}/review",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Paykeys.Review.SetVerificationDecision(
                        new global::Straddle.Models.Paykeys.Review.ReviewSetVerificationDecisionParams
                        {
                            ID = "smoke",
                            Status = global::Straddle.Models.Paykeys.Review.Status.Active,
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/charges",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Create(
                        new global::Straddle.Models.Charges.ChargeCreateParams
                        {
                            Amount = 10000,
                            Config = new global::Straddle.Models.Charges.ChargeConfiguration
                            {
                                BalanceCheck = global::Straddle
                                    .Models
                                    .Charges
                                    .BalanceCheckMode
                                    .Enabled,
                            },
                            ConsentType = global::Straddle.Models.Charges.ConsentType.Internet,
                            Currency = "USD",
                            Description = "Monthly subscription fee",
                            Device = new global::Straddle.Models.Charges.PaymentDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            ExternalID = "smoke",
                            Paykey = "smoke",
                            PaymentDate = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/charges",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Create(
                        new global::Straddle.Models.Charges.ChargeCreateParams
                        {
                            Amount = 10000,
                            Config = new global::Straddle.Models.Charges.ChargeConfiguration
                            {
                                BalanceCheck = global::Straddle
                                    .Models
                                    .Charges
                                    .BalanceCheckMode
                                    .Enabled,
                            },
                            ConsentType = global::Straddle.Models.Charges.ConsentType.Internet,
                            Currency = "USD",
                            Description = "Monthly subscription fee",
                            Device = new global::Straddle.Models.Charges.PaymentDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            ExternalID = "smoke",
                            Paykey = "smoke",
                            PaymentDate = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/charges/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Retrieve(
                        new global::Straddle.Models.Charges.ChargeRetrieveParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/charges/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Retrieve(
                        new global::Straddle.Models.Charges.ChargeRetrieveParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/charges/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Update(
                        new global::Straddle.Models.Charges.ChargeUpdateParams
                        {
                            ID = "smoke",
                            Amount = 10000,
                            Description = "Monthly subscription fee",
                            PaymentDate = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/charges/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Update(
                        new global::Straddle.Models.Charges.ChargeUpdateParams
                        {
                            ID = "smoke",
                            Amount = 10000,
                            Description = "Monthly subscription fee",
                            PaymentDate = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/charges/{id}/cancel",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Cancel(
                        new global::Straddle.Models.Charges.ChargeCancelParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/charges/{id}/cancel",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Cancel(
                        new global::Straddle.Models.Charges.ChargeCancelParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "hold",
            "PUT",
            "/v1/charges/{id}/hold",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Hold(
                        new global::Straddle.Models.Charges.ChargeHoldParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "hold",
            "PUT",
            "/v1/charges/{id}/hold",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Hold(
                        new global::Straddle.Models.Charges.ChargeHoldParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/charges/{id}/unmask",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.ListUnmasked(
                        new global::Straddle.Models.Charges.ChargeListUnmaskedParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/charges/{id}/unmask",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.ListUnmasked(
                        new global::Straddle.Models.Charges.ChargeListUnmaskedParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refund",
            "POST",
            "/v1/charges/{id}/refund",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Refund(
                        new global::Straddle.Models.Charges.ChargeRefundParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "refund",
            "POST",
            "/v1/charges/{id}/refund",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Refund(
                        new global::Straddle.Models.Charges.ChargeRefundParams
                        {
                            ID = "smoke",
                            Amount = 5000,
                            CorrelationID = "smoke",
                            Description = null,
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            PaymentDate = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "release",
            "PUT",
            "/v1/charges/{id}/release",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Release(
                        new global::Straddle.Models.Charges.ChargeReleaseParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "release",
            "PUT",
            "/v1/charges/{id}/release",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Release(
                        new global::Straddle.Models.Charges.ChargeReleaseParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "resubmit",
            "POST",
            "/v1/charges/{id}/resubmit",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Resubmit(
                        new global::Straddle.Models.Charges.ChargeResubmitParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "resubmit",
            "POST",
            "/v1/charges/{id}/resubmit",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.Resubmit(
                        new global::Straddle.Models.Charges.ChargeResubmitParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            Description = null,
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            PaymentDate = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadAuthorizationProof",
            "POST",
            "/v1/charges/{id}/authorization",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.UploadAuthorizationProof(
                        new global::Straddle.Models.Charges.ChargeUploadAuthorizationProofParams
                        {
                            ID = "smoke",
                            File = new System.IO.MemoryStream(
                                System.Text.Encoding.UTF8.GetBytes("smoke")
                            ),
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadAuthorizationProof",
            "POST",
            "/v1/charges/{id}/authorization",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Charges.UploadAuthorizationProof(
                        new global::Straddle.Models.Charges.ChargeUploadAuthorizationProofParams
                        {
                            ID = "smoke",
                            File = new System.IO.MemoryStream(
                                System.Text.Encoding.UTF8.GetBytes("smoke")
                            ),
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/funding_events/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.Retrieve(
                        new global::Straddle.Models.FundingEvents.FundingEventRetrieveParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/funding_events/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.Retrieve(
                        new global::Straddle.Models.FundingEvents.FundingEventRetrieveParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/funding_events",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.List(
                        new global::Straddle.Models.FundingEvents.FundingEventListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/funding_events",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.List(
                        new global::Straddle.Models.FundingEvents.FundingEventListParams
                        {
                            CorrelationID = "smoke",
                            CreatedFrom = null,
                            CreatedTo = null,
                            Direction = global::Straddle
                                .Models
                                .FundingEvents
                                .TransferDirection
                                .Deposit,
                            EventType = global::Straddle
                                .Models
                                .FundingEvents
                                .FundingEventType
                                .ChargeDeposit,
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SearchText = null,
                            SortBy = global::Straddle.Models.FundingEvents.SortBy.TransferDate,
                            SortOrder = global::Straddle.Models.Accounts.AccountSortOrder.Asc,
                            Status = null,
                            StatusReason = null,
                            StatusSource = null,
                            StraddleAccountID = "smoke",
                            TraceID = null,
                            TraceNumber = null,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listPayments",
            "GET",
            "/v1/funding_event_payments/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.ListPayments(
                        new global::Straddle.Models.FundingEvents.FundingEventListPaymentsParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listPayments",
            "GET",
            "/v1/funding_event_payments/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.ListPayments(
                        new global::Straddle.Models.FundingEvents.FundingEventListPaymentsParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            DefaultPageSize = 1,
                            DefaultSort = global::Straddle
                                .Models
                                .FundingEvents
                                .DefaultSort
                                .CreatedAt,
                            DefaultSortOrder = global::Straddle
                                .Models
                                .Accounts
                                .AccountSortOrder
                                .Asc,
                            IncludeMetadata = true,
                            PageNumber = 1,
                            PageSize = 1,
                            RequestID = "smoke",
                            SortBy = global::Straddle
                                .Models
                                .FundingEvents
                                .FundingEventListPaymentsParamsSortBy
                                .CreatedAt,
                            SortOrder = global::Straddle.Models.Accounts.AccountSortOrder.Asc,
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "simulate",
            "POST",
            "/v1/funding_events/simulate",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.Simulate(
                        new global::Straddle.Models.FundingEvents.FundingEventSimulateParams
                        {
                            FundingEventJobType = global::Straddle
                                .Models
                                .FundingEvents
                                .FundingEventJobType
                                .Charges,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "simulate",
            "POST",
            "/v1/funding_events/simulate",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .FundingEvents.Simulate(
                        new global::Straddle.Models.FundingEvents.FundingEventSimulateParams
                        {
                            FundingEventJobType = global::Straddle
                                .Models
                                .FundingEvents
                                .FundingEventJobType
                                .Charges,
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            SandboxOutcome = global::Straddle
                                .Models
                                .Charges
                                .SimulatedPaymentOutcome
                                .Standard,
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/payments",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payments.List(
                        new global::Straddle.Models.Payments.PaymentListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/v1/payments",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payments.List(
                        new global::Straddle.Models.Payments.PaymentListParams
                        {
                            CorrelationID = "smoke",
                            CustomerID = "smoke",
                            DefaultPageSize = 1,
                            DefaultSort = global::Straddle.Models.Payments.DefaultSort.CreatedAt,
                            DefaultSortOrder = global::Straddle
                                .Models
                                .Accounts
                                .AccountSortOrder
                                .Asc,
                            ExternalID = "smoke",
                            FundingID = "smoke",
                            HasRefund = true,
                            HasResubmit = true,
                            IncludeMetadata = true,
                            IsRefund = true,
                            IsResubmit = true,
                            MaxAmount = 1,
                            MaxCreatedAt = System.DateTimeOffset.UnixEpoch,
                            MaxEffectiveAt = System.DateTimeOffset.UnixEpoch,
                            MaxPaymentDate = "smoke",
                            MaxUpdatedAt = System.DateTimeOffset.UnixEpoch,
                            MinAmount = 1,
                            MinCreatedAt = System.DateTimeOffset.UnixEpoch,
                            MinEffectiveAt = System.DateTimeOffset.UnixEpoch,
                            MinPaymentDate = "smoke",
                            MinUpdatedAt = System.DateTimeOffset.UnixEpoch,
                            PageNumber = 1,
                            PageSize = 1,
                            Paykey = "smoke",
                            PaykeyID = "smoke",
                            PaymentID = "smoke",
                            PaymentStatus =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Charges.PaymentStatus
                                >>(),
                            PaymentType =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Charges.PaymentType
                                >>(),
                            RequestID = "smoke",
                            SearchText = "smoke",
                            SortBy = global::Straddle.Models.Payments.SortBy.CreatedAt,
                            SortOrder = global::Straddle.Models.Accounts.AccountSortOrder.Asc,
                            StatusReason =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Bridge.PaymentStatusReason
                                >>(),
                            StatusSource =
                                new System.Collections.Generic.List<global::Straddle.Core.ApiEnum<
                                    string,
                                    global::Straddle.Models.Bridge.PaymentStatusSource
                                >>(),
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/payouts",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Create(
                        new global::Straddle.Models.Payouts.PayoutCreateParams
                        {
                            Amount = 10000,
                            Currency = "USD",
                            Description = "Vendor invoice payment",
                            Device = new global::Straddle.Models.Charges.PaymentDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            ExternalID = "smoke",
                            Paykey = "smoke",
                            PaymentDate = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/v1/payouts",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Create(
                        new global::Straddle.Models.Payouts.PayoutCreateParams
                        {
                            Amount = 10000,
                            Currency = "USD",
                            Description = "Vendor invoice payment",
                            Device = new global::Straddle.Models.Charges.PaymentDevice
                            {
                                IPAddress = "192.168.1.1",
                            },
                            ExternalID = "smoke",
                            Paykey = "smoke",
                            PaymentDate = "smoke",
                            Config = new global::Straddle.Models.Charges.PayoutConfiguration(),
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/payouts/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Retrieve(
                        new global::Straddle.Models.Payouts.PayoutRetrieveParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/payouts/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Retrieve(
                        new global::Straddle.Models.Payouts.PayoutRetrieveParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/payouts/{id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Update(
                        new global::Straddle.Models.Payouts.PayoutUpdateParams
                        {
                            ID = "smoke",
                            Amount = 10000,
                            Description = null,
                            PaymentDate = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/v1/payouts/{id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Update(
                        new global::Straddle.Models.Payouts.PayoutUpdateParams
                        {
                            ID = "smoke",
                            Amount = 10000,
                            Description = null,
                            PaymentDate = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Metadata = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/payouts/{id}/cancel",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Cancel(
                        new global::Straddle.Models.Payouts.PayoutCancelParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "cancel",
            "PUT",
            "/v1/payouts/{id}/cancel",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Cancel(
                        new global::Straddle.Models.Payouts.PayoutCancelParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "hold",
            "PUT",
            "/v1/payouts/{id}/hold",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Hold(
                        new global::Straddle.Models.Payouts.PayoutHoldParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "hold",
            "PUT",
            "/v1/payouts/{id}/hold",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Hold(
                        new global::Straddle.Models.Payouts.PayoutHoldParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/payouts/{id}/unmask",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.ListUnmasked(
                        new global::Straddle.Models.Payouts.PayoutListUnmaskedParams
                        {
                            ID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listUnmasked",
            "GET",
            "/v1/payouts/{id}/unmask",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.ListUnmasked(
                        new global::Straddle.Models.Payouts.PayoutListUnmaskedParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "release",
            "PUT",
            "/v1/payouts/{id}/release",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Release(
                        new global::Straddle.Models.Payouts.PayoutReleaseParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "release",
            "PUT",
            "/v1/payouts/{id}/release",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Release(
                        new global::Straddle.Models.Payouts.PayoutReleaseParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            Reason = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "resubmit",
            "POST",
            "/v1/payouts/{id}/resubmit",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Resubmit(
                        new global::Straddle.Models.Payouts.PayoutResubmitParams { ID = "smoke" },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "resubmit",
            "POST",
            "/v1/payouts/{id}/resubmit",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.Resubmit(
                        new global::Straddle.Models.Payouts.PayoutResubmitParams
                        {
                            ID = "smoke",
                            CorrelationID = "smoke",
                            Description = null,
                            ExternalID = null,
                            IdempotencyKey = "smoke",
                            PaymentDate = null,
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadAuthorizationProof",
            "POST",
            "/v1/payouts/{id}/authorization",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.UploadAuthorizationProof(
                        new global::Straddle.Models.Payouts.PayoutUploadAuthorizationProofParams
                        {
                            ID = "smoke",
                            File = new System.IO.MemoryStream(
                                System.Text.Encoding.UTF8.GetBytes("smoke")
                            ),
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadAuthorizationProof",
            "POST",
            "/v1/payouts/{id}/authorization",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Payouts.UploadAuthorizationProof(
                        new global::Straddle.Models.Payouts.PayoutUploadAuthorizationProofParams
                        {
                            ID = "smoke",
                            File = new System.IO.MemoryStream(
                                System.Text.Encoding.UTF8.GetBytes("smoke")
                            ),
                            CorrelationID = "smoke",
                            IdempotencyKey = "smoke",
                            RequestID = "smoke",
                            StraddleAccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/account_settings/{account_id}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .AccountSettings.Retrieve(
                        new global::Straddle.Models.AccountSettings.AccountSettingRetrieveParams
                        {
                            AccountID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/v1/account_settings/{account_id}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .AccountSettings.Retrieve(
                        new global::Straddle.Models.AccountSettings.AccountSettingRetrieveParams
                        {
                            AccountID = "smoke",
                            CorrelationID = "smoke",
                            RequestID = "smoke",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
    };

    public static async Task<int> Main()
    {
        var client = new global::Straddle.StraddleClient { MaxRetries = 0 };
        var selected = SelectCases(Environment.GetEnvironmentVariable("SCALAR_SMOKE_FILTER"));
        var results = new List<Dictionary<string, object?>>();

        foreach (var smokeCase in selected)
        {
            var stopwatch = Stopwatch.StartNew();
            var status = "passed";
            string? error = null;
            using var caseCts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            try
            {
                await smokeCase.Run(client, caseCts.Token).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                status = "failed";
                error = exception.Message;
            }
            stopwatch.Stop();
            var entry = new Dictionary<string, object?>
            {
                ["operation"] = smokeCase.Operation,
                ["method"] = smokeCase.Method,
                ["path"] = smokeCase.Path,
                ["status"] = status,
                ["durationMs"] = stopwatch.ElapsedMilliseconds,
            };
            // Reported only when the operation contributed both of its calls, so a single-case
            // operation reports exactly as it did before there were two.
            if (smokeCase.Label.Length > 0)
                entry["label"] = smokeCase.Label;
            if (error is not null)
                entry["error"] = error;
            results.Add(entry);
        }

        var failed = results.Count(result => (string?)result["status"] == "failed");
        var report = new Dictionary<string, object?>
        {
            ["total"] = results.Count,
            ["failed"] = failed,
            ["results"] = results,
        };

        var reportPath = Environment.GetEnvironmentVariable("SCALAR_SMOKE_REPORT");
        if (!string.IsNullOrEmpty(reportPath))
        {
            File.WriteAllText(reportPath, JsonSerializer.Serialize(report));
        }
        else
        {
            foreach (var result in results)
            {
                var suffix = result.TryGetValue("label", out var label) ? $" [{label}]" : "";
                if ((string?)result["status"] == "passed")
                {
                    Console.WriteLine(
                        $"PASS {result["operation"]}{suffix} ({result["method"]} {result["path"]}) {result["durationMs"]}ms"
                    );
                }
                else
                {
                    Console.Error.WriteLine(
                        $"FAIL {result["operation"]}{suffix} ({result["method"]} {result["path"]})\n{result["error"]}"
                    );
                }
            }
            if (results.Count == 0)
            {
                Console.Error.WriteLine(
                    "No code samples ran (empty SDK or a SCALAR_SMOKE_FILTER that matched nothing)."
                );
            }
            else
            {
                Console.WriteLine($"\n{results.Count - failed}/{results.Count} samples passed");
            }
        }

        return failed > 0 || results.Count == 0 ? 1 : 0;
    }

    private static IReadOnlyList<SmokeCase> SelectCases(string? filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return Cases;
        var needles = filter
            .Split(',')
            .Select(needle => needle.Trim())
            .Where(needle => needle.Length > 0)
            .ToArray();
        if (needles.Length == 0)
            return Cases;
        return Cases
            .Where(smokeCase =>
                needles.Any(needle =>
                    smokeCase.Operation.Contains(needle) || smokeCase.Path.Contains(needle)
                )
            )
            .ToList();
    }
}
