using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCaseaction
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? BenefitNumber { get; set; }

    public string? CaseType { get; set; } = null!;

    public string? Status { get; set; } = null!;

    public string? Reason { get; set; }

    public string? ActionedBy { get; set; } = null!;

    public string? ActionDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public int? StaffInd { get; set; }
    public int ApplicationId { get; set; }
}
