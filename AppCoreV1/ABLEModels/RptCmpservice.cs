using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCmpservice
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? CmpStatus { get; set; } = null!;

    public string? GoalName { get; set; } = null!;

    public string? GoalOutcome { get; set; }

    public string? GoalDescription { get; set; }

    public string? GoalCreationDate { get; set; }

    public string? GoalOutcomeDate { get; set; }

    public string? CmpGoalDate { get; set; }

    public string? PlanName { get; set; }

    public string? PlanNotes { get; set; }

    public string? PlanStatus { get; set; }

    public string? PlanCreationDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? GoalReason { get; set; }
    public int? StaffInd { get; set; }
}
