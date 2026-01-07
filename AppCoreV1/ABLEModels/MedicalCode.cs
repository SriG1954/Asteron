using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class MedicalCode
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ClaimC { get; set; }

    public decimal? ClaimI { get; set; }

    public string? MedicalCondition { get; set; }

    public DateTime? DateOfFirstTreatment { get; set; }

    public string? LifeExpectancy { get; set; }

    public string? Diagnosis { get; set; }

    public DateTime? DateOfDiagnosis { get; set; }

    public DateTime? DateOfFirstConsultation { get; set; }

    public string? CustomerDominantSide { get; set; }

    public string? ImpactOnActivityLevels { get; set; }

    public string? Description { get; set; }

    public string? Level { get; set; }

    public string? Type { get; set; }

    public string? Code { get; set; }

    public string? Severity { get; set; }

    public string? Status { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public decimal? PreExistingCondition { get; set; }

    public string? LevelIndicator { get; set; }

    public string? DurationClass { get; set; }

    public string? BodySide { get; set; }

    public string? BodyLocation { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public string? Comment { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? Source { get; set; }
    public string? ClaimNumber { get; set; }
    public int ApplicationId { get; set; }
}
