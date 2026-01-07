using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ClaimPeriod
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public decimal? PartyCFacility { get; set; }

    public decimal? PartyIFacility { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public string? ClaimNumber { get; set; }
}
