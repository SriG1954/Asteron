using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptClaimcasedecipha
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? PolicyNumber { get; set; } = null!;

    public string? CustomerFirstName { get; set; } = null!;

    public string? CustomerLastName { get; set; } = null!;

    public string? State { get; set; }

    public string? PostCode { get; set; }

    public string? ClaimsTeamDepartment { get; set; }
    public int? StaffInd { get; set; }
}
