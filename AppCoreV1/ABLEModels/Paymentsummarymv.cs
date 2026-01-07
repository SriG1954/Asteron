using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Paymentsummarymv
{
    public int Id { get; set; }

    public string ClaimNumber { get; set; } = null!;

    public string BenefitNumber { get; set; } = null!;

    public double? EFormId { get; set; }

    public string? BenefitPayment { get; set; }

    public string? AcceptFrom { get; set; }

    public string? From { get; set; }

    public string? To { get; set; }

    public double? BenefitAmount { get; set; }

    public string? BenefitAmountInfo { get; set; }

    public double? StampDuty { get; set; }

    public string? StampDutyInfo { get; set; }

    public double? PremiumRefund { get; set; }

    public string? PremiumRefundInfo { get; set; }

    public double? SuperContributions { get; set; }

    public string? SuperContributionsInfo { get; set; }

    public double? NoClaimBonus { get; set; }

    public string? NoClaimBonusInfo { get; set; }

    public double? Offsets { get; set; }

    public string? OffsetsInfo { get; set; }

    public double? Others { get; set; }

    public string? OthersInfo { get; set; }

    public double? Tax { get; set; }

    public string? TaxInfo { get; set; }

    public string? CalculationDescription { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PartialBenefit { get; set; }

    public string? GroupPayee { get; set; }

    public string? CpiEbrClaimsEscalation { get; set; }

    public string? CpiEbrClaimsEscalDes { get; set; }

    public double? NumberOfPayments { get; set; }

    public string? AdminInitials { get; set; }

    public string? AdminDate { get; set; }

    public string? PaymentReference { get; set; }

    public string? AdminAuthorisedByInitials { get; set; }

    public string? AdminAuthorisedDate { get; set; }

    public string? PsoftRefForWaivPremiums { get; set; }

    public string? PsoftWvedPremiumAuthBy { get; set; }

    public string? PsoftPayAuthDate { get; set; }

    public string? PeopleSoftScoReference { get; set; }

    public string? PsoftPayAuthBy { get; set; }

    public string? PsoftPayAuthDate1 { get; set; }

    public string? ServiceRequestScoReference { get; set; }

    public string? OtherInformationEnd { get; set; }

    public double? Total { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? ClassOfBusiness { get; set; }

    public string? BenefitCode { get; set; }

    public string? ProductCode { get; set; }

    public string? BenefitType { get; set; }

    public DateTime? DateCreated { get; set; }
    public int? StaffInd { get; set; }
    public int ApplicationId { get; set; }
}
