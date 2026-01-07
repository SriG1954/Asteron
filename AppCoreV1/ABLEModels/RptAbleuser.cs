using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptAbleuser
{
    public decimal? ClaimUserId { get; set; }

    public string? LanId { get; set; } = null!;

    public string? FullName { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string? Mail { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? DepartmentNumber { get; set; }

    public string? ManagerLanId { get; set; }

    public string? ManagerName { get; set; }

    public string? ManagerMobile { get; set; }

    public string? LastLogonDate { get; set; }

    public string? DefaultDepartment { get; set; }
}
