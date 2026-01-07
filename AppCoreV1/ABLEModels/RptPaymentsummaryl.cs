using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptPaymentsummaryl
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? BenefitNumber { get; set; } = null!;

    public decimal? EFormId { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? PolicyType { get; set; }

    public decimal? ConcurrentClaimYN { get; set; }

    public string? ClaimType { get; set; }

    public string? GroupOrRetail { get; set; }

    public string? PaymentType { get; set; }

    public string? BenefitAmtCalc { get; set; }

    public DateTime? DateCeasedWork { get; set; }

    public DateTime? IncurredDate { get; set; }

    public DateTime? AcceptFrom { get; set; }

    public decimal? BenefitPayable { get; set; }

    public decimal? InvestmentAmount { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? OtherTaxable { get; set; }

    public decimal? TotalGrossAmount { get; set; }

    public decimal? OtherNonTaxable { get; set; }

    public decimal? TaxValue { get; set; }

    public decimal? TotalNetAmount { get; set; }

    public decimal? PartialWdrwlTferReq { get; set; }

    public decimal? PartialWdrawalTferAmt { get; set; }

    public decimal? TaxDollar { get; set; }

    public decimal? CaldNetAmount { get; set; }

    public string? PaymentAddtnlInfo { get; set; }

    public string? PaymentMethod { get; set; }

    public string? ForGroupPayee { get; set; }

    public string? AdminReqdWdrawal { get; set; }

    public string? PolicyDelinkedYN { get; set; }

    public string? DelinkedPolicyDetails { get; set; }

    public string? AdminDeletePolicyYN { get; set; }

    public DateTime? AdminDeleteProcDate { get; set; }

    public string? PremRefundReqdYN { get; set; }

    public string? RemaingCoverYN { get; set; }

    public string? BuyBackOption { get; set; }

    public DateTime? BuyBackOptionEffDate { get; set; }

    public string? TrmaReinstmntApplYN { get; set; }

    public string? FinancialPlanningBftYN { get; set; }

    public decimal? FinancialPlanningBftAmt { get; set; }

    public string? OtherPaymentInfo { get; set; }

    public DateTime? ProcessDate { get; set; }

    public DateTime? AuthoriseDate { get; set; }

    public string? OtherAdminInfo { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimTypeIpLs { get; set; }

    public string? ClassOfBusiness { get; set; }

    public string? BenefitCode { get; set; }

    public string? ProductCode { get; set; }

    public string? BenefitType { get; set; }
    public int? StaffInd { get; set; }
}
