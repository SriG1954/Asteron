using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimPolicyExclusion
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimPolicyEntitlementC { get; set; }

    public decimal? ClaimPolicyEntitlementI { get; set; }
}
