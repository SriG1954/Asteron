using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Policy
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public string? PolicyNumber { get; set; }

    public decimal? Product { get; set; }

    public string? ProductName { get; set; }

    public decimal? ContractStatus { get; set; }

    public string? ContractStatusName { get; set; }

    public decimal? SourceSystem { get; set; }

    public string? SourceSystemName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public DateTime? EffectiveDate { get; set; }
    public int ApplicationId { get; set; }
}
