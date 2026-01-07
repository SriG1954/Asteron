using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class OutstandingRequest
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartySourceC { get; set; }

    public decimal? PartySourceI { get; set; }

    public decimal? PartySubjectC { get; set; }

    public decimal? PartySubjectI { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? ProcessC { get; set; }

    public decimal? ProcessI { get; set; }

    public decimal? TaskC { get; set; }

    public decimal? TaskI { get; set; }

    public decimal? DocumentC { get; set; }

    public decimal? DocumentI { get; set; }

    public string? Type { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastFollowedUpBy { get; set; }

    public DateTime? NextFollowUpDate { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Status { get; set; }

    public DateTime? DateRequested { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? DateLastFollowedUp { get; set; }

    public DateTime? NotProceedingWithDate { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? CompletionReason { get; set; }

    public string? CompletionNotes { get; set; }

    public DateTime? DateSuppressed { get; set; }

    public string? SuppressionReason { get; set; }

    public string? SuppressionNotes { get; set; }

    public string? SuppressedBy { get; set; }

    public string? UserCreated { get; set; }

    public string? UserLastUpdated { get; set; }

    public string? UpdatedBy { get; set; }

    public string? SelectedCategory { get; set; }

    public string? SelectedType { get; set; }
    public string? ClaimNumber { get; set; }
    public int ApplicationId { get; set; }
}
