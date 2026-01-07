using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class BenefitExclusion
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? BenefitC { get; set; }

    public decimal? BenefitI { get; set; }

    public string? Type { get; set; }

    public string? DurationUnit { get; set; }

    public string? Duration { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Status { get; set; }

    public string? LastStatusChanged { get; set; }

    public string? Description { get; set; }

    public decimal? StatusUpdatedByC { get; set; }

    public decimal? StatusUpdatedByI { get; set; }
}
