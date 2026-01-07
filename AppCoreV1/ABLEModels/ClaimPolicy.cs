using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimPolicy
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public decimal? PolicyC { get; set; }

    public decimal? PolicyI { get; set; }

    public DateTime? LastRefreshDate { get; set; }

    public DateTime? Commencementd { get; set; }

    public DateTime? InternalEndDate { get; set; }
}
