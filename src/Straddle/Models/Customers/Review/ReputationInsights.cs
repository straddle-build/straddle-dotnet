using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Customers.Review;

[JsonConverter(typeof(JsonModelConverter<ReputationInsights, ReputationInsightsFromRaw>))]
public sealed record class ReputationInsights : JsonModel
{
    /// <summary>
    /// Number of active accounts associated with the identity.
    /// </summary>
    public int? AccountsActiveCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("accounts_active_count");
        }
        init { this._rawData.Set("accounts_active_count", value); }
    }

    /// <summary>
    /// Number of closed accounts associated with the identity.
    /// </summary>
    public int? AccountsClosedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("accounts_closed_count");
        }
        init { this._rawData.Set("accounts_closed_count", value); }
    }

    /// <summary>
    /// Dates when accounts associated with the identity were closed.
    /// </summary>
    public IReadOnlyList<string>? AccountsClosedDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("accounts_closed_dates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "accounts_closed_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of accounts associated with the identity.
    /// </summary>
    public int? AccountsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("accounts_count");
        }
        init { this._rawData.Set("accounts_count", value); }
    }

    /// <summary>
    /// Number of accounts associated with fraud.
    /// </summary>
    public int? AccountsFraudCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("accounts_fraud_count");
        }
        init { this._rawData.Set("accounts_fraud_count", value); }
    }

    /// <summary>
    /// Dates when accounts were labeled as fraudulent.
    /// </summary>
    public IReadOnlyList<string>? AccountsFraudLabeledDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "accounts_fraud_labeled_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "accounts_fraud_labeled_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total fraud loss associated with the accounts.
    /// </summary>
    public double? AccountsFraudLossTotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("accounts_fraud_loss_total_amount");
        }
        init { this._rawData.Set("accounts_fraud_loss_total_amount", value); }
    }

    /// <summary>
    /// Number of fraudulent ACH transactions.
    /// </summary>
    public int? AchFraudTransactionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("ach_fraud_transactions_count");
        }
        init { this._rawData.Set("ach_fraud_transactions_count", value); }
    }

    /// <summary>
    /// Dates when fraudulent ACH transactions occurred.
    /// </summary>
    public IReadOnlyList<string>? AchFraudTransactionsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "ach_fraud_transactions_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "ach_fraud_transactions_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total amount of fraudulent ACH transactions.
    /// </summary>
    public double? AchFraudTransactionsTotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ach_fraud_transactions_total_amount");
        }
        init { this._rawData.Set("ach_fraud_transactions_total_amount", value); }
    }

    /// <summary>
    /// Number of returned ACH transactions.
    /// </summary>
    public int? AchReturnedTransactionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("ach_returned_transactions_count");
        }
        init { this._rawData.Set("ach_returned_transactions_count", value); }
    }

    /// <summary>
    /// Dates when ACH transactions were returned.
    /// </summary>
    public IReadOnlyList<string>? AchReturnedTransactionsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "ach_returned_transactions_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "ach_returned_transactions_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total amount of returned ACH transactions.
    /// </summary>
    public double? AchReturnedTransactionsTotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "ach_returned_transactions_total_amount"
            );
        }
        init { this._rawData.Set("ach_returned_transactions_total_amount", value); }
    }

    /// <summary>
    /// Number of approved applications associated with the identity.
    /// </summary>
    public int? ApplicationsApprovedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("applications_approved_count");
        }
        init { this._rawData.Set("applications_approved_count", value); }
    }

    /// <summary>
    /// Number of applications associated with the identity.
    /// </summary>
    public int? ApplicationsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("applications_count");
        }
        init { this._rawData.Set("applications_count", value); }
    }

    /// <summary>
    /// Dates when applications associated with the identity were submitted.
    /// </summary>
    public IReadOnlyList<string>? ApplicationsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applications_dates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applications_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of declined applications associated with the identity.
    /// </summary>
    public int? ApplicationsDeclinedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("applications_declined_count");
        }
        init { this._rawData.Set("applications_declined_count", value); }
    }

    /// <summary>
    /// Number of applications associated with fraud.
    /// </summary>
    public int? ApplicationsFraudCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("applications_fraud_count");
        }
        init { this._rawData.Set("applications_fraud_count", value); }
    }

    /// <summary>
    /// Number of disputed card transactions.
    /// </summary>
    public int? CardDisputedTransactionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("card_disputed_transactions_count");
        }
        init { this._rawData.Set("card_disputed_transactions_count", value); }
    }

    /// <summary>
    /// Dates when card transactions were disputed.
    /// </summary>
    public IReadOnlyList<string>? CardDisputedTransactionsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "card_disputed_transactions_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "card_disputed_transactions_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total amount of disputed card transactions.
    /// </summary>
    public double? CardDisputedTransactionsTotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "card_disputed_transactions_total_amount"
            );
        }
        init { this._rawData.Set("card_disputed_transactions_total_amount", value); }
    }

    /// <summary>
    /// Number of fraudulent card transactions.
    /// </summary>
    public int? CardFraudTransactionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("card_fraud_transactions_count");
        }
        init { this._rawData.Set("card_fraud_transactions_count", value); }
    }

    /// <summary>
    /// Dates when fraudulent card transactions occurred.
    /// </summary>
    public IReadOnlyList<string>? CardFraudTransactionsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "card_fraud_transactions_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "card_fraud_transactions_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total amount of fraudulent card transactions.
    /// </summary>
    public double? CardFraudTransactionsTotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("card_fraud_transactions_total_amount");
        }
        init { this._rawData.Set("card_fraud_transactions_total_amount", value); }
    }

    /// <summary>
    /// Number of stopped card transactions.
    /// </summary>
    public int? CardStoppedTransactionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("card_stopped_transactions_count");
        }
        init { this._rawData.Set("card_stopped_transactions_count", value); }
    }

    /// <summary>
    /// Dates when card transactions were stopped.
    /// </summary>
    public IReadOnlyList<string>? CardStoppedTransactionsDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "card_stopped_transactions_dates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "card_stopped_transactions_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of active profiles associated with the identity.
    /// </summary>
    public int? UserActiveProfileCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_active_profile_count");
        }
        init { this._rawData.Set("user_active_profile_count", value); }
    }

    /// <summary>
    /// Number of addresses associated with the identity.
    /// </summary>
    public int? UserAddressCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_address_count");
        }
        init { this._rawData.Set("user_address_count", value); }
    }

    /// <summary>
    /// Number of closed profiles associated with the identity.
    /// </summary>
    public int? UserClosedProfileCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_closed_profile_count");
        }
        init { this._rawData.Set("user_closed_profile_count", value); }
    }

    /// <summary>
    /// Number of dates of birth associated with the identity.
    /// </summary>
    public int? UserDobCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_dob_count");
        }
        init { this._rawData.Set("user_dob_count", value); }
    }

    /// <summary>
    /// Number of email addresses associated with the identity.
    /// </summary>
    public int? UserEmailCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_email_count");
        }
        init { this._rawData.Set("user_email_count", value); }
    }

    /// <summary>
    /// Number of financial institutions associated with the identity.
    /// </summary>
    public int? UserInstitutionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_institution_count");
        }
        init { this._rawData.Set("user_institution_count", value); }
    }

    /// <summary>
    /// Number of mobile numbers associated with the identity.
    /// </summary>
    public int? UserMobileCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("user_mobile_count");
        }
        init { this._rawData.Set("user_mobile_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountsActiveCount;
        _ = this.AccountsClosedCount;
        _ = this.AccountsClosedDates;
        _ = this.AccountsCount;
        _ = this.AccountsFraudCount;
        _ = this.AccountsFraudLabeledDates;
        _ = this.AccountsFraudLossTotalAmount;
        _ = this.AchFraudTransactionsCount;
        _ = this.AchFraudTransactionsDates;
        _ = this.AchFraudTransactionsTotalAmount;
        _ = this.AchReturnedTransactionsCount;
        _ = this.AchReturnedTransactionsDates;
        _ = this.AchReturnedTransactionsTotalAmount;
        _ = this.ApplicationsApprovedCount;
        _ = this.ApplicationsCount;
        _ = this.ApplicationsDates;
        _ = this.ApplicationsDeclinedCount;
        _ = this.ApplicationsFraudCount;
        _ = this.CardDisputedTransactionsCount;
        _ = this.CardDisputedTransactionsDates;
        _ = this.CardDisputedTransactionsTotalAmount;
        _ = this.CardFraudTransactionsCount;
        _ = this.CardFraudTransactionsDates;
        _ = this.CardFraudTransactionsTotalAmount;
        _ = this.CardStoppedTransactionsCount;
        _ = this.CardStoppedTransactionsDates;
        _ = this.UserActiveProfileCount;
        _ = this.UserAddressCount;
        _ = this.UserClosedProfileCount;
        _ = this.UserDobCount;
        _ = this.UserEmailCount;
        _ = this.UserInstitutionCount;
        _ = this.UserMobileCount;
    }

    public ReputationInsights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationInsights(ReputationInsights reputationInsights)
        : base(reputationInsights) { }
#pragma warning restore CS8618

    public ReputationInsights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationInsights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReputationInsightsFromRaw.FromRawUnchecked"/>
    public static ReputationInsights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReputationInsightsFromRaw : IFromRawJson<ReputationInsights>
{
    /// <inheritdoc/>
    public ReputationInsights FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReputationInsights.FromRawUnchecked(rawData);
}
