using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class Benefit
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? OverrideClaimIncurredDate { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BenefitStartDate { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BenefitEndDate { get; set; }

    public DateTime? ProofOfLossDate { get; set; }

    public DateTime? ExpectedBenefitClosureDate { get; set; }

    public string? Source { get; set; }

    public DateTime? EffectiveDateOfCoverage { get; set; }

    public DateTime? BenefitExpiryDate { get; set; }

    public decimal? WaitingPeriod { get; set; }

    public string? WaitingPeriodBasis { get; set; }

    public decimal? FullyRetained { get; set; }

    public string? BenefitDecision { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BenefitDecisionDate { get; set; }

    public string? ReasonForBenefitDecision { get; set; }

    public string? BenefitSelected { get; set; }

    public decimal? AgreedValue { get; set; }

    public decimal? ChronicConditionOption { get; set; }

    public decimal? Day1AccidentOption { get; set; }

    public string? Iar { get; set; }

    public string? OccupationalCategory { get; set; }

    public string? PasriskOptionCode { get; set; }

    public string? PasriskOptionDesc { get; set; }

    public decimal? SuperContributionPct { get; set; }

    public string? GroupId { get; set; }

    public string? SubBenefitFlag { get; set; }

    public string? StartDateCalculationType { get; set; }

    public string? EndDateCalculationType { get; set; }

    public decimal? MaximumBenefitPeriod { get; set; }

    public decimal? MaximumBenefitPeriodAccident { get; set; }

    public decimal? MaximumBenefitPeriodHospital { get; set; }

    public string? MaximumBenefitPeriodBasis { get; set; }

    public string? MaximumBenefitPeriodAccidentBasis { get; set; }

    public string? MaximumBenefitPeriodHospitalBasis { get; set; }

    public decimal? SicknessWaitingPeriod { get; set; }

    public decimal? AccidentWaitingPeriod { get; set; }

    public decimal? HospitalWaitingPeriod { get; set; }

    public string? WaitingPeriodBasis1 { get; set; }

    public string? AccidentWaitingPeriodBasis { get; set; }

    public string? HospitalWaitingPeriodBasis { get; set; }

    public decimal? SumInsured { get; set; }

    public decimal? AgeroundingRule { get; set; }

    public decimal? RoundUnit { get; set; }

    public string? AgeroundingPrecision { get; set; }

    public string? RoundInstruction { get; set; }

    public decimal? MaximumAggregateAmount { get; set; }

    public decimal? MinimumAmount { get; set; }

    public decimal? MinimumPercentage { get; set; }

    public string? MinimumCalculationType { get; set; }

    public decimal? AutomaticAcceptanceLimit { get; set; }

    public decimal? DuesCreatedInArrears { get; set; }

    public decimal? MaximumAmount { get; set; }

    public decimal? MaximumPercentage { get; set; }

    public decimal? MaximumCalculationType { get; set; }

    public decimal? Underwritten { get; set; }

    public DateTime? ReinsurerLiabilityApprovedToDate { get; set; }

    public DateTime? ToEndOfBenefit { get; set; }

    public decimal? IndexationApplies { get; set; }

    public string? AdjustmentTypeName { get; set; }

    public decimal? EliminationPeriod { get; set; }

    public string? EliminationPeriodBasis { get; set; }

    public decimal? MinimumRate { get; set; }

    public decimal? IndexLeadTime { get; set; }

    public decimal? AdjustBenefit { get; set; }

    public decimal? MaximumRate { get; set; }

    public decimal? MaximumCumulativeRate { get; set; }

    public decimal? MaxNumberIndexations { get; set; }

    public decimal? MinThresholdApplies { get; set; }

    public decimal? MaxThresholdApplies { get; set; }

    public string? Type { get; set; }

    public DateTime? ChangeInClaimDefinitionDate { get; set; }

    public DateTime? WhenAnyAllDecisionMade { get; set; }

    public DateTime? DateBenefitsWithheld { get; set; }

    public decimal? WhoAuthorizedBenefitsWithheldC { get; set; }

    public decimal? WhoAuthorizedBenefitsWithheldI { get; set; }

    public decimal? LastUpdateUserNameC { get; set; }

    public decimal? LastUpdateUserNameI { get; set; }

    public DateTime? AnyAllReviewDate { get; set; }

    public string? ReasonBenefitsWithheld { get; set; }

    public decimal? OverrideChangeInDefinitionDate { get; set; }

    public string? AnyAllStatus { get; set; }
    public string? ClaimNumber { get; set; }

    public int? StaffInd { get; set; }

    public int ApplicationId { get; set; }

}
