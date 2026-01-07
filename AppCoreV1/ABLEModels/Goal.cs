using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Goal
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClientGoalC { get; set; }

    public decimal? ClientGoalI { get; set; }

    public decimal? LifeAreaC { get; set; }

    public decimal? LifeAreaI { get; set; }

    public string? StrategyName { get; set; }

    public string? SummarySnapshot { get; set; }

    public string? CustomerStrategyStatus { get; set; }

    public DateTime? TargetDate { get; set; }
}

public partial class GoalEx
{
    public string? Id { get; set; }

    public string? C { get; set; }

    public string? I { get; set; }

    public string? ClientGoalC { get; set; }

    public string? ClientGoalI { get; set; }

    public string? LifeAreaC { get; set; }

    public string? LifeAreaI { get; set; }

    public string? StrategyName { get; set; }

    public string? SummarySnapshot { get; set; }

    public string? CustomerStrategyStatus { get; set; }

    public string? TargetDate { get; set; }
}

