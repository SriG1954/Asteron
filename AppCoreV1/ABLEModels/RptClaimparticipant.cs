using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptClaimparticipant
{
    public int Id { get; set; }

    public string? FaxExtension { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? TypeOfParticipant { get; set; }

    public string? PersonOrganisation { get; set; }

    public string? Name { get; set; } = null!;

    public string? Hva { get; set; } = null!;

    public string? AddressType { get; set; }

    public string? Address { get; set; }

    public string? Suburb { get; set; }

    public string? State { get; set; }

    public string? PostCode { get; set; }

    public string? ClaimNumber { get; set; }

    public string? ParticipantEffectiveDate { get; set; }

    public string? ClaimStatus { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? ResidentialInternationalCode { get; set; }

    public string? ResidentialAreaCode { get; set; }

    public string? ResidentialPhone { get; set; }

    public string? ResidentialExtension { get; set; }

    public string? BusinessInternationalCode { get; set; }

    public string? BusinessAreaCode { get; set; }

    public string? BusinessPhone { get; set; }

    public string? BusinessExtension { get; set; }

    public string? MobileInternationalCode { get; set; }

    public string? MobileAreaCode { get; set; }

    public string? MobilePhone { get; set; }

    public string? MobileExtension { get; set; }

    public string? FaxInternationalCode { get; set; }

    public string? FaxAreaCode { get; set; }

    public string? FaxPhone { get; set; }
    public int? StaffInd { get; set; }
}
