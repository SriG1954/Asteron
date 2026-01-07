using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class CaseValidation
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public string? Category { get; set; }

    public string? Message { get; set; }

    public decimal? UserC { get; set; }

    public decimal? UserI { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public decimal? ReasonForSuppression { get; set; }

    public string? Description { get; set; }
    public string? ClaimNumber { get; set; }
    public int ApplicationId { get; set; }
}
