using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptTaskreportreinsurance
{
    public int Id { get; set; }

    public string? TaskCreatedByUser { get; set; } = null!;

    public string? TaskCreatedDate { get; set; } = null!;

    public string? TaskCompletedByUser { get; set; } = null!;

    public string? TaskCompletedDate { get; set; }

    public string? BenchmarkDays { get; set; }

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

    public string? ClaimNumber { get; set; }

    public string? CaseStatus { get; set; }

    public string? ClaimantName { get; set; }

    public string? CaseType { get; set; }

    public string? CaseManager { get; set; }

    public string? ClaimTeam { get; set; }

    public string? TaskProcessStep { get; set; }

    public string? TaskId { get; set; }

    public string? TaskCode { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    public string? TaskStatus { get; set; }

    public string? TaskAssignedToUser { get; set; }

    public string? TaskAssignedToRole { get; set; }
    public int? StaffInd { get; set; }
}
