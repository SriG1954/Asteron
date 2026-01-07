using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptOverrideriskreport
{
    public int Id { get; set; }

    public string? OverrideProcessedBy { get; set; } = null!;

    public string? LumpsumIpIndicator { get; set; } = null!;

    public string? ClaimType { get; set; } = null!;

    public string? ClaimNumber { get; set; }

    public string? RiskCategory { get; set; }

    public string? RiskCategoryCreationDate { get; set; }

    public string? OverrideRiskCategory { get; set; }

    public string? OverrideRiskCategoryReason { get; set; }
    public int? StaffInd { get; set; }
}
