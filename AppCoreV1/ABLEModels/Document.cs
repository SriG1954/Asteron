using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class DocumentA
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public decimal? ContactC { get; set; }

    public decimal? ContactI { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public string? EnvelopId { get; set; }

    public string? Tag { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? DateCreated { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? LastUpdated { get; set; }

    public string? Description { get; set; }

    public decimal? KeyDocument { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public string? DocumentType { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Title { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public string? ClaimNumber { get; set; }
    public int? StaffInd { get; set; }
    public int ApplicationId { get; set; }

}
