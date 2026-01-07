using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClientGoal
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public string? CustomerGoalName { get; set; }

    public string? GoalDescription { get; set; }

    public DateTime? GoalTargetDate { get; set; }

    public string? Status { get; set; }

    public DateTime? OutcomeDate { get; set; }

    public string? OutcomeNotes { get; set; }

    public string? GoalDateRationale { get; set; }

    public string? AchievementTimeframe { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? GoalReason { get; set; }
}

public partial class ClientGoalEx
{
    public string? Id { get; set; }

    public string? C { get; set; }

    public string? I { get; set; }

    public string? CaseC { get; set; }

    public string? CaseI { get; set; }

    public string? CustomerGoalName { get; set; }

    public string? GoalDescription { get; set; }

    public string? GoalTargetDate { get; set; }

    public string? Status { get; set; }

    public string? OutcomeDate { get; set; }

    public string? OutcomeNotes { get; set; }

    public string? GoalDateRationale { get; set; }

    public string? AchievementTimeframe { get; set; }

    public string? CreateDate { get; set; }

    public string? GoalReason { get; set; }
}
