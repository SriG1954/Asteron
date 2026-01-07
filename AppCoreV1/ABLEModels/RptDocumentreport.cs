using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptDocumentreport
{
    public int Id { get; set; }

    public string? CaseNumber { get; set; } = null!;

    public string? BenefitNumber { get; set; } = null!;

    public string? CaseType { get; set; } = null!;

    public string? DocumentType { get; set; } = null!;

    public decimal? DocumentId { get; set; }

    public string? DateCreatedInAble { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }
    public int? StaffInd { get; set; }
    public int ApplicationId { get; set; }
}
