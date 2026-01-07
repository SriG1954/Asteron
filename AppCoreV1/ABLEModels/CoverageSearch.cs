using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class CoverageSearch
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

    public decimal? ClaimPolicyC { get; set; }

    public decimal? ClaimPolicyI { get; set; }

    public string? Coverage { get; set; }

    public string? CoverageCode { get; set; }

    public string? Status { get; set; }

    public DateTime? EffectiveDate1 { get; set; }

    public decimal? ClaimPolicyCoverageC { get; set; }

    public decimal? ClaimPolicyCoverageI { get; set; }

    public string? Type { get; set; }

    public string? BenefitEntitlementDescription { get; set; }

    public string? BenefitSelected { get; set; }

    public string? PasriskOptionCode { get; set; }

    public string? ClaimNumber { get; set; }

    public int Pid { get; set; }
    public int ApplicationId { get; set; }
}
