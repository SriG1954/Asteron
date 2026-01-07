using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class Contact
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? DateTime { get; set; }

    public string? Reason { get; set; }

    public string? Method { get; set; }

    public string? Direction { get; set; }

    public string? ContactSuccessful { get; set; }

    public string? Description { get; set; }

    public decimal? MethodOfContact { get; set; }

    public string? CustomerRepresentative { get; set; }

    public string? PhoneRecordingLink { get; set; }

    public string? User { get; set; }

    public decimal? ContactDuration { get; set; }

    public string? PrivacyTag { get; set; }

    public string? DealtWithBy { get; set; }
    public string? ClaimNumber { get; set; }
    public int ApplicationId { get; set; }
}
