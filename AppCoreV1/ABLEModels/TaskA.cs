using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class TaskA
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? DocumentC { get; set; }

    public decimal? DocumentI { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public decimal? PlicyC { get; set; }

    public decimal? PlicyI { get; set; }

    public decimal? ProcessC { get; set; }

    public decimal? ProcessI { get; set; }

    public decimal? TaskC { get; set; }

    public decimal? TaskI { get; set; }

    public string? TaskType { get; set; }

    public string? Status { get; set; }

    public DateTime? Target { get; set; }

    public string? Description { get; set; }

    public DateTime? OriginalTargetDate { get; set; }

    public string? Priority { get; set; }

    public string? Subject { get; set; }

    public string? Assignee { get; set; }

    public DateTime? OnHoldUntil { get; set; }

    public string? CreatedBy { get; set; }

    public string? DefaultDepartment { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? ClaimNumber { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? UpdatedBy { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? CreationDate1 { get; set; }

    public DateTime? TargetDate { get; set; }
    public int ApplicationId { get; set; }
}
