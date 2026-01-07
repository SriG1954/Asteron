using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ActionHistory
{
    public decimal Id { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? ClaimNumber { get; set; }

    public string? BenefitNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public partial class ActionHistoryEx
{
    public string? Id { get; set; }

    public string? LastUpdated { get; set; }

    public string? ClaimNumber { get; set; }

    public string? BenefitNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
