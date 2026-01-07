using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimPolicyEntitlement
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimPolicyCoverageC { get; set; }

    public decimal? ClaimPolicyCoverageI { get; set; }

    public string? Type { get; set; }

    public string? BenefitEntitlementDescription { get; set; }

    public string? BenefitSelected { get; set; }

    public string? PasriskOptionCode { get; set; }
}
