using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class BenefitReInsurance
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? BenefitC { get; set; }

    public decimal? BenefitI { get; set; }

    public string? ReinsurerName { get; set; }

    public string? ReinsuranceCode { get; set; }

    public DateTime? TreatyEffectiveFrom { get; set; }

    public decimal? ExcessPoolAmount { get; set; }

    public decimal? ReinsuredFromReinsuredAmount { get; set; }

    public decimal? RetentionSurplusLimit { get; set; }

    public decimal? MandatoryReferralLimit { get; set; }

    public DateTime? ReinsurerNotificationDate { get; set; }

    public DateTime? TreatyEffectiveTo { get; set; }

    public decimal? ExcessLossFlag { get; set; }

    public decimal? PoolPercentage { get; set; }

    public decimal? QuotaSharePercentage { get; set; }
}
