using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Straddle.Core;

namespace Straddle.Models.Charges;

[JsonConverter(
    typeof(JsonModelConverter<PaymentAuthorizationProof, PaymentAuthorizationProofFromRaw>)
)]
public sealed record class PaymentAuthorizationProof : JsonModel
{
    /// <summary>
    /// Unique identifier for this document.
    /// </summary>
    public required string DocumentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("document_id");
        }
        init { this._rawData.Set("document_id", value); }
    }

    /// <summary>
    /// The file name of this document as uploaded.
    /// </summary>
    public required string DocumentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("document_name");
        }
        init { this._rawData.Set("document_name", value); }
    }

    /// <summary>
    /// The size of this document in bytes.
    /// </summary>
    public required long DocumentSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("document_size");
        }
        init { this._rawData.Set("document_size", value); }
    }

    public required ApiEnum<string, PaymentDocumentType> DocumentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentDocumentType>>(
                "document_type"
            );
        }
        init { this._rawData.Set("document_type", value); }
    }

    /// <summary>
    /// The UTC timestamp when this document was uploaded.
    /// </summary>
    public required DateTimeOffset UploadedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("uploaded_at");
        }
        init { this._rawData.Set("uploaded_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentID;
        _ = this.DocumentName;
        _ = this.DocumentSize;
        this.DocumentType.Validate();
        _ = this.UploadedAt;
    }

    public PaymentAuthorizationProof() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentAuthorizationProof(PaymentAuthorizationProof paymentAuthorizationProof)
        : base(paymentAuthorizationProof) { }
#pragma warning restore CS8618

    public PaymentAuthorizationProof(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentAuthorizationProof(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentAuthorizationProofFromRaw.FromRawUnchecked"/>
    public static PaymentAuthorizationProof FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentAuthorizationProofFromRaw : IFromRawJson<PaymentAuthorizationProof>
{
    /// <inheritdoc/>
    public PaymentAuthorizationProof FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentAuthorizationProof.FromRawUnchecked(rawData);
}
