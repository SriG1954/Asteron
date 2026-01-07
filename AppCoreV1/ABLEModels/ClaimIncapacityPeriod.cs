using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimIncapacityPeriod
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public decimal? PartC { get; set; }

    public decimal? PartI { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Notes { get; set; }

    public string? PartialCapacity { get; set; }

    public string? ClaimNumber { get; set; }
    public int ApplicationId { get; set; }
}
