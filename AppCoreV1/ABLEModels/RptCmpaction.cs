using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCmpaction
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

    public string? FactorName { get; set; }

    public string? FactorDescription { get; set; }

    public string? Factors { get; set; }

    public string? FactorStatus { get; set; }

    public string? StrategyName { get; set; }

    public string? StrategyOutcome { get; set; }

    public string? StrategyTargetDate { get; set; }

    public string? StrategyCreationDate { get; set; }

    public string? StrategyOutcomeDate { get; set; }

    public string? ActionName { get; set; }

    public DateTime? ActionLastUpdated { get; set; }

    public string? ActionStartDate { get; set; }

    public string? ActionOwner { get; set; }

    public string? ActionOwnerTeam { get; set; }

    public string? ActionOutcome { get; set; }

    public string? ActionOutcomeDate { get; set; }

    public string? ActionOutcomeReason { get; set; }

    public string? ActionOwnerType { get; set; }

    public string? ServiceCode { get; set; }

    public string? ServiceDescription { get; set; }

    public string? ServiceCreator { get; set; }

    public string? ServiceStartDate { get; set; }

    public string? ServiceEndDate { get; set; }

    public string? ServiceNotes { get; set; }

    public string? CommenceDate { get; set; }

    public string? ServicePractitioner { get; set; }

    public string? DocumentUploadDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? GoalReason { get; set; }
    public int? StaffInd { get; set; }
}
