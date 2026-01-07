using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimPolicyCoverage
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimPolicyC { get; set; }

    public decimal? ClaimPolicyI { get; set; }

    public string? Coverage { get; set; }

    public string? CoverageCode { get; set; }

    public string? Status { get; set; }

    public DateTime? EffectiveDate { get; set; }
}
