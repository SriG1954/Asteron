using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimOccupation
{
    public int Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string? ClaimNumber { get; set; }

    public string? Occupation { get; set; }

    public string? JobTitle { get; set; }

    public decimal? HoursWorkedPerWeek { get; set; }

    public decimal? GrossAmt { get; set; }

    public DateTime? DateOfHire { get; set; }

    public DateTime? DateJobEnded { get; set; }

    public string? OccupationCode { get; set; }

    public string? IncomeType { get; set; }

    public string? EmploymentStatus { get; set; }

    public string? SelfEmployed { get; set; }

    public decimal? DaysWorkedPerWeek { get; set; }

    public string? NatureOfWorkDuties { get; set; }

    public string? ReasonForCeasingPosition { get; set; }

    public string? BusinessStructure { get; set; }

    public decimal? Rank { get; set; }
    public int ApplicationId { get; set; }
}
