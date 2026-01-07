using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Occupation
{
    public int Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public DateTime? DateOfHire { get; set; }

    public string? JobTitle { get; set; }

    public decimal? HoursWorkedPerWeek { get; set; }

    public DateTime? DateJobEnded { get; set; }

    public string? OccupationCode { get; set; }

    public decimal? SelfEmployed { get; set; }

    public string? EmploymentStatus { get; set; }

    public decimal? DaysWorkedPerWeek { get; set; }

    public string? NatureOfWorkDuties { get; set; }

    public string? ReasonForCeasingPosition { get; set; }

    public string? BusinessStructure { get; set; }
}
