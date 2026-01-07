using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptClaimexpense
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? Payee { get; set; } = null!;

    public string? PolicyNumber { get; set; } = null!;

    public string? InvoiceType { get; set; }

    public string? InvoiceNumber { get; set; }

    public decimal? AmountIncGst { get; set; }

    public decimal? Gst { get; set; }

    public string? PaymentMethod { get; set; }

    public string? VendorId { get; set; }

    public string? AdminInitials { get; set; }

    public string? PaymentCreationDate { get; set; }

    public string? PaymentReference { get; set; }

    public string? AuthorisedBy { get; set; }

    public string? AuthorisationDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? ClassOfBusiness { get; set; }

    public string? BenefitCode { get; set; }

    public string? ProductCode { get; set; }

    public string? TargetBenefitType { get; set; }

    public decimal? ClaimExpenseGuid { get; set; }
    public int? StaffInd { get; set; }
}
