using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptEnquirycasereport
{
    public int Id { get; set; }

    public string? EnquiryNumber { get; set; } = null!;

    public string? EnquiryCaseStatus { get; set; } = null!;

    public string? GivenName { get; set; } = null!;

    public string? Surname { get; set; } = null!;

    public string? Sex { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PostCode { get; set; }

    public string? CaseManager { get; set; }

    public string? Team { get; set; }

    public string? CreationDate { get; set; }

    public string? IncurredDate { get; set; }

    public string? Source { get; set; }

    public string? ContactDate { get; set; }

    public string? Notifier { get; set; }

    public string? IfOther { get; set; }

    public string? NatureOfIllnessOrInjury { get; set; }

    public string? NatureOfIncident { get; set; }

    public string? Description { get; set; }

    public string? Product { get; set; }

    public string? ContractStatus { get; set; }

    public string? PolicyNumber { get; set; }

    public string? CommencementDate { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }
}
