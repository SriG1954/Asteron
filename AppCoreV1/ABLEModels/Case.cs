using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Case
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public DateTime? IncuredDate { get; set; }

    public string? Context { get; set; }

    public string? TriageSegment { get; set; }

    public string? CaseNumber { get; set; }

    public string? UnexpectedCircumstances { get; set; }

    public decimal? CustomerContactFrequency { get; set; }

    public decimal? OpportunityToInfluenceExhausted { get; set; }

    public string? Description { get; set; }

    public string? OverrideTriageSegmentReason { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UrgentFinancialNeed { get; set; }

    public string? CaseType { get; set; }

    public string? CaseOwnerComment { get; set; }
    public int ApplicationId { get; set; }
}

public partial class CaseAction
{
    public string? Status { get; set; }

    public string? Reason { get; set; }

    public string? ActionedBy { get; set; }

    public string? ActionDate { get; set; }

    public string? ClaimNumber { get; set; }

}
