using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptClaimbenefitactuarialrec
{
    public int Id { get; set; }

    public string? MonthEffectiveDate { get; set; } = null!;

    public string? SourceSystem { get; set; } = null!;

    public string? ProductName { get; set; } = null!;

    public string? PolicyNumber { get; set; } = null!;

    public string? GroupPlanNumber { get; set; }

    public string? IndicativeClaimType { get; set; }

    public string? SourceBenefitCode { get; set; }

    public string? SourceBenefitDescription { get; set; }

    public string? CoverType { get; set; }

    public string? TargetBenefitCode { get; set; }

    public string? ClaimStatus { get; set; }

    public string? BenefitStatus { get; set; }

    public string? ClaimNumber { get; set; }

    public string? GivenName { get; set; }

    public string? Surname { get; set; }

    public string? Sex { get; set; }

    public string? DateOfBirth { get; set; }

    public string? DateOfDeath { get; set; }

    public string? Occupation { get; set; }

    public string? OccupationCategory { get; set; }

    public decimal? HoursWorkedPerWeek { get; set; }

    public decimal? PreDisabilityIncome { get; set; }

    public string? State { get; set; }

    public string? PostCode { get; set; }

    public string? CaseType { get; set; }

    public string? CurrentClaimOwner { get; set; }

    public string? ClaimTeam { get; set; }

    public string? RegistrationDate { get; set; }

    public string? FirstContactDate { get; set; }

    public string? IncurredDate { get; set; }

    public decimal? AgeAtIncurredDate { get; set; }

    public string? ClaimEventType { get; set; }

    public string? PrimaryCauseCode { get; set; }

    public string? PrimaryCauseDescription { get; set; }

    public string? PrimaryCauseDate { get; set; }

    public string? SecondaryCauseCode { get; set; }

    public string? SecondaryCauseDescription { get; set; }

    public string? SecondaryCauseDate { get; set; }

    public string? ExpectedReturnToWorkDate { get; set; }

    public string? CeasedWorkDate { get; set; }

    public string? ClaimFinalisedDate { get; set; }

    public string? ClaimFinalisedReason { get; set; }

    public string? ClaimReopenDate { get; set; }

    public string? ClaimReopenReason { get; set; }

    public string? ContractStartDate { get; set; }

    public string? ContractStatus { get; set; }

    public string? BenefitNumber { get; set; }

    public string? TargetBenefitDescription { get; set; }

    public string? RiskCommencedDate { get; set; }

    public string? RiskExpiryDate { get; set; }

    public string? WaitingPeriodAccident { get; set; }

    public string? WaitingPeriodSickness { get; set; }

    public string? BenefitPeriodAccident { get; set; }

    public string? BenefitPeriodSickness { get; set; }

    public decimal? InitialSumInsured { get; set; }

    public string? InitialSumInsuredFreq { get; set; }

    public decimal? TargetSumInsured { get; set; }

    public string? TargetSumInsuredFreq { get; set; }

    public string? CalculationStartType { get; set; }

    public string? CalculationEndType { get; set; }

    public string? Decision { get; set; }

    public string? Accepted { get; set; }

    public string? DecisionDate { get; set; }

    public string? DecisionReason { get; set; }

    public string? FinalisedDate { get; set; }

    public string? FinalisedReason { get; set; }

    public string? BenefitReopenDate { get; set; }

    public string? BenefitReopenReason { get; set; }

    public decimal? SuperContributionPercent { get; set; }

    public string? IndexationFlag { get; set; }

    public string? IndexationFrequency { get; set; }

    public string? AgreedValue { get; set; }

    public string? ChronicConditionOption { get; set; }

    public string? Day1AccidentOption { get; set; }

    public decimal? NumberOfReinsurers { get; set; }

    public decimal? TotalReinsurancePercent { get; set; }

    public string? AdviserSalesId { get; set; }

    public string? GroupPlanName { get; set; }

    public string? RiskCategory { get; set; }

    public string? OverrideRiskCategory { get; set; }

    public string? OverrideRiskCategoryReason { get; set; }

    public string? PrimaryOccupationStartDate { get; set; }

    public string? PrimaryOccupationEndDate { get; set; }

    public string? DateOfDiagnosis { get; set; }

    public string? ExternalMemberNumber { get; set; }

    public string? BenefitCreationDate { get; set; }

    public string? ClassOfBusiness { get; set; }

    public string? ContractEndDate { get; set; }

    public decimal? PartialEarningsIncome { get; set; }

    public string? BenefitStartDate { get; set; }

    public string? BenefitEndDate { get; set; }

    public decimal? MaximumIndexationRate { get; set; }

    public string? Source { get; set; }

    public string? IncidentOccurredOverseas { get; set; }

    public string? CountryOfIncident { get; set; }

    public string? BenefitType { get; set; }

    public string? ProductCode { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? PartyId { get; set; }

    public string? SourceBenefitType { get; set; }

    public string? SourceBenefitSelected { get; set; }

    public string? ConcurrentClaimIndicator { get; set; }

    public string? ConcurrentClaimNumbers { get; set; }

    public DateTime? DateReturnedToWork { get; set; }

    public string? ExpectedRtwFtRange { get; set; }

    public string? AdmitAdvancePayAndFinalise { get; set; }

    public string? NonDisclosure { get; set; }

    public string? CmpRequired { get; set; }

    public decimal? UrgentFinancialNeedsFlag { get; set; }

    public decimal? SpecialArrangementFlag { get; set; }

    public string? SpecialArrangementDuration { get; set; }

    public string? UnexpectedCircumstances { get; set; }
    public int? StaffInd { get; set; }
}
