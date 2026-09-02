# Straddle C# Reference

## Accounts

### Create

```csharp
Create(AccountCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/accounts`
- Summary: Create an account

### Retrieve

```csharp
Retrieve(AccountRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/accounts/{account_id}`
- Summary: Get an account

### Update

```csharp
Update(AccountUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/accounts/{account_id}`
- Summary: Update an account

### List

```csharp
List(AccountListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/accounts`
- Summary: List accounts

### Onboard

```csharp
Onboard(AccountOnboardParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/accounts/{account_id}/onboard`
- Summary: Onboard an account

### SimulateOnboarding

```csharp
SimulateOnboarding(AccountSimulateOnboardingParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/accounts/{account_id}/simulate`
- Summary: Simulate status transitions for a sandbox account

## CapabilityRequests

### Create

```csharp
Create(CapabilityRequestCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/accounts/{account_id}/capability_requests`
- Summary: Create capability requests

### List

```csharp
List(CapabilityRequestListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/accounts/{account_id}/capability_requests`
- Summary: List capability requests

## LinkedBankAccounts

### Create

```csharp
Create(LinkedBankAccountCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/linked_bank_accounts`
- Summary: Create a linked bank account

### Retrieve

```csharp
Retrieve(LinkedBankAccountRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/linked_bank_accounts/{linked_bank_account_id}`
- Summary: Get a linked bank account

### Update

```csharp
Update(LinkedBankAccountUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/linked_bank_accounts/{linked_bank_account_id}`
- Summary: Update a linked bank account

### List

```csharp
List(LinkedBankAccountListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/linked_bank_accounts`
- Summary: List linked bank accounts

### Cancel

```csharp
Cancel(LinkedBankAccountCancelParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PATCH /v1/linked_bank_accounts/{linked_bank_account_id}/cancel`
- Summary: Cancel a linked bank account

### ListUnmasked

```csharp
ListUnmasked(LinkedBankAccountListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/linked_bank_accounts/{linked_bank_account_id}/unmask`
- Summary: Get an unmasked linked bank account

## Organizations

### Create

```csharp
Create(OrganizationCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/organizations`
- Summary: Create an organization

### Retrieve

```csharp
Retrieve(OrganizationRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/organizations/{organization_id}`
- Summary: Get an organization

### List

```csharp
List(OrganizationListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/organizations`
- Summary: List organizations

## Representatives

### Create

```csharp
Create(RepresentativeCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/representatives`
- Summary: Create a representative

### Retrieve

```csharp
Retrieve(RepresentativeRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/representatives/{representative_id}`
- Summary: Get a representative

### Update

```csharp
Update(RepresentativeUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/representatives/{representative_id}`
- Summary: Update a representative

### List

```csharp
List(RepresentativeListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/representatives`
- Summary: List representatives

### ListUnmasked

```csharp
ListUnmasked(RepresentativeListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/representatives/{representative_id}/unmask`
- Summary: Get an unmasked representative

## Bridge

### CreateBankAccountPaykey

```csharp
CreateBankAccountPaykey(BridgeCreateBankAccountPaykeyParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/bridge/bank_account`
- Summary: Create a paykey from bank account details

### CreatePlaidPaykey

```csharp
CreatePlaidPaykey(BridgeCreatePlaidPaykeyParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/bridge/plaid`
- Summary: Create a paykey from a Plaid token

### CreateQuilttPaykey

```csharp
CreateQuilttPaykey(BridgeCreateQuilttPaykeyParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/bridge/quiltt`
- Summary: Create a paykey from a Quiltt token

### CreateToken

```csharp
CreateToken(BridgeCreateTokenParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/bridge/initialize`
- Summary: Create a Bridge widget session token

## Customers

### Create

```csharp
Create(CustomerCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/customers`
- Summary: Create a customer

### Retrieve

```csharp
Retrieve(CustomerRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/customers/{id}`
- Summary: Get a customer

### Update

```csharp
Update(CustomerUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/customers/{id}`
- Summary: Update a customer

### List

```csharp
List(CustomerListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/customers`
- Summary: List customers

### Delete

```csharp
Delete(CustomerDeleteParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `DELETE /v1/customers/{id}`
- Summary: Delete a customer

### ListUnmasked

```csharp
ListUnmasked(CustomerListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/customers/{id}/unmasked`
- Summary: Get an unmasked customer

### RefreshReview

```csharp
RefreshReview(CustomerRefreshReviewParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/customers/{id}/refresh_review`
- Summary: Refresh a customer review

## Customers.Review

### List

```csharp
List(ReviewListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/customers/{id}/review`
- Summary: Get a customer review

### SetVerificationDecision

```csharp
SetVerificationDecision(ReviewSetVerificationDecisionParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PATCH /v1/customers/{id}/review`
- Summary: Set a customer verification decision

## Paykeys

### Retrieve

```csharp
Retrieve(PaykeyRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/paykeys/{id}`
- Summary: Get a paykey

### List

```csharp
List(PaykeyListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/paykeys`
- Summary: List paykeys

### Cancel

```csharp
Cancel(PaykeyCancelParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/paykeys/{id}/cancel`
- Summary: Cancel a paykey

### ListUnmasked

```csharp
ListUnmasked(PaykeyListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/paykeys/{id}/unmasked`
- Summary: Get an unmasked paykey

### RefreshBalance

```csharp
RefreshBalance(PaykeyRefreshBalanceParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/paykeys/{id}/refresh_balance`
- Summary: Refresh a paykey balance

### RefreshReview

```csharp
RefreshReview(PaykeyRefreshReviewParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/paykeys/{id}/refresh_review`
- Summary: Refresh a paykey review

### Reveal

```csharp
Reveal(PaykeyRevealParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/paykeys/{id}/reveal`
- Summary: Reveal a paykey token

### Unblock

```csharp
Unblock(PaykeyUnblockParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PATCH /v1/paykeys/{id}/unblock`
- Summary: Unblock a paykey

## Paykeys.Review

### List

```csharp
List(ReviewListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/paykeys/{id}/review`
- Summary: Get a paykey review

### SetVerificationDecision

```csharp
SetVerificationDecision(ReviewSetVerificationDecisionParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PATCH /v1/paykeys/{id}/review`
- Summary: Set a paykey verification decision

## Charges

### Create

```csharp
Create(ChargeCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/charges`
- Summary: Create a charge

### Retrieve

```csharp
Retrieve(ChargeRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/charges/{id}`
- Summary: Get a charge

### Update

```csharp
Update(ChargeUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/charges/{id}`
- Summary: Update a charge

### Cancel

```csharp
Cancel(ChargeCancelParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/charges/{id}/cancel`
- Summary: Cancel a charge

### Hold

```csharp
Hold(ChargeHoldParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/charges/{id}/hold`
- Summary: Hold a charge

### ListUnmasked

```csharp
ListUnmasked(ChargeListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/charges/{id}/unmask`
- Summary: Get an unmasked charge

### Refund

```csharp
Refund(ChargeRefundParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/charges/{id}/refund`
- Summary: Refund a paid charge

### Release

```csharp
Release(ChargeReleaseParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/charges/{id}/release`
- Summary: Release a charge

### Resubmit

```csharp
Resubmit(ChargeResubmitParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/charges/{id}/resubmit`
- Summary: Resubmit a charge

### UploadAuthorizationProof

```csharp
UploadAuthorizationProof(ChargeUploadAuthorizationProofParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/charges/{id}/authorization`
- Summary: Upload a proof-of-authorization document for a charge

## FundingEvents

### Retrieve

```csharp
Retrieve(FundingEventRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/funding_events/{id}`
- Summary: Get a funding event

### List

```csharp
List(FundingEventListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/funding_events`
- Summary: List funding events

### ListPayments

```csharp
ListPayments(FundingEventListPaymentsParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/funding_event_payments/{id}`
- Summary: List funding event payments

### Simulate

```csharp
Simulate(FundingEventSimulateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/funding_events/simulate`
- Summary: Simulate a funding event

## Payments

### List

```csharp
List(PaymentListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/payments`
- Summary: List payments

## Payouts

### Create

```csharp
Create(PayoutCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/payouts`
- Summary: Create a payout

### Retrieve

```csharp
Retrieve(PayoutRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/payouts/{id}`
- Summary: Get a payout

### Update

```csharp
Update(PayoutUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/payouts/{id}`
- Summary: Update a payout

### Cancel

```csharp
Cancel(PayoutCancelParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/payouts/{id}/cancel`
- Summary: Cancel a payout

### Hold

```csharp
Hold(PayoutHoldParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/payouts/{id}/hold`
- Summary: Hold a payout

### ListUnmasked

```csharp
ListUnmasked(PayoutListUnmaskedParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/payouts/{id}/unmask`
- Summary: Get an unmasked payout

### Release

```csharp
Release(PayoutReleaseParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /v1/payouts/{id}/release`
- Summary: Release a payout

### Resubmit

```csharp
Resubmit(PayoutResubmitParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/payouts/{id}/resubmit`
- Summary: Resubmit a payout

### UploadAuthorizationProof

```csharp
UploadAuthorizationProof(PayoutUploadAuthorizationProofParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /v1/payouts/{id}/authorization`
- Summary: Upload a proof-of-authorization document for a payout

## AccountSettings

### Retrieve

```csharp
Retrieve(AccountSettingRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /v1/account_settings/{account_id}`
- Summary: Get account settings
