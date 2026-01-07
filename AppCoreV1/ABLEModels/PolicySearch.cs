using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class PolicySearch
{
    public decimal Id { get; set; }

    public string? ClaimNumber { get; set; }

    public string? PolicyNumber { get; set; }

    public string? ProductName { get; set; }

    public string? ContractStatusName { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? StartDate { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? EffectiveDate { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? TerminationDate { get; set; }

    public int Pid { get; set; }
    public int? StaffInd { get; set; } = null!;
    public int ApplicationId { get; set; }

}
