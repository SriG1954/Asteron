using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptClosedtaskreport
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? CaseStatus { get; set; } = null!;

    public string? ClaimantName { get; set; } = null!;

    public string? CaseType { get; set; }

    public string? CaseManager { get; set; }

    public string? ClaimTeam { get; set; }

    public string? TaskProcessStep { get; set; }

    public decimal? TaskId { get; set; }

    public decimal? TaskCode { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    public string? TaskStatus { get; set; }

    public string? TaskAssignedToUser { get; set; }

    public string? TaskAssignedToRole { get; set; }

    public string? TaskCreatedByUser { get; set; }

    public string? TaskCreatedDate { get; set; }

    public string? TaskCompletedByUser { get; set; }

    public string? TaskCompletedDate { get; set; }

    public decimal? BenchmarkDays { get; set; }

    public string? BenchmarkDate { get; set; }

    public string? ProductName { get; set; }

    public string? BenefitNumber { get; set; }

    public string? BenefitCode { get; set; }

    public string? BenefitDescription { get; set; }

    public string? TaskCreatedByTeam { get; set; }

    public string? TaskCompletedByTeam { get; set; }

    public string? OriginalTaskTargetDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? ClassOfBusiness { get; set; }

    public string? ProductCode { get; set; }

    public string? TargetBenefitType { get; set; }

    public string? TaskTeamQueue { get; set; }
    public int? StaffInd { get; set; }
}
