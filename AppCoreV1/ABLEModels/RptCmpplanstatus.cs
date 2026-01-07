using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCmpplanstatus
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? CmpStatus { get; set; } = null!;

    public string? CmpGoalDate { get; set; } = null!;

    public string? PlanName { get; set; }

    public string? PlanNotes { get; set; }

    public string? PlanStatus { get; set; }

    public string? PlanCreationDate { get; set; }

    public string? ServiceCode { get; set; }

    public string? ServiceDescription { get; set; }

    public string? ServiceCreator { get; set; }

    public string? ServiceStartDate { get; set; }

    public string? ServiceEndDate { get; set; }

    public string? PlanStatusDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }
    public int? StaffInd { get; set; }

}
