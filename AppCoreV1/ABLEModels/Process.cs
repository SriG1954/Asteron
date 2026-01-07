using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Process
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? DocumentC { get; set; }

    public decimal? DocumentI { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public decimal? PlicyC { get; set; }

    public decimal? PlicyI { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? ProcessC { get; set; }

    public decimal? ProcessI { get; set; }

    public decimal? TaskC { get; set; }

    public decimal? TaskI { get; set; }

    public string? Status { get; set; }

    public string? CaseManager { get; set; }

    public string? InDepartment { get; set; }

    public string? Role { get; set; }

    public DateTime? TargetDate { get; set; }

    public string? WorkType { get; set; }

    public string? Description { get; set; }

    public string? AssignedTo { get; set; }

    public string? CreatedBy { get; set; }
}
