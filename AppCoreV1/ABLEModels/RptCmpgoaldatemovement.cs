using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCmpgoaldatemovement
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? CmpStatus { get; set; } = null!;

    public string? PlanName { get; set; } = null!;

    public string? PlanCreationDate { get; set; }

    public string? CmpGoalDate { get; set; }

    public string? CmpGoalCreationDate { get; set; }

    public string? CmpGoalUpdatedDate { get; set; }

    public string? CmpGoalUpdatedByUserName { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }
    public int? StaffInd { get; set; }
}
