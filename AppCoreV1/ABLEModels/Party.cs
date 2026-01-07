using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Party
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public string? CustomerNo { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? PreferredName { get; set; }

    public string? PreviousName { get; set; }

    public decimal? Verified { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfDeath { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public string? PartyType { get; set; }

    public decimal? Deceased { get; set; }

    public decimal? NotificationsIssued { get; set; }

    public string? Occupation { get; set; }

    public DateTime? Tenure { get; set; }

    public string? HazardousPursuit { get; set; }

    public string? Nationality { get; set; }

    public string? CountryOfBirth { get; set; }

    public string? CulturalConsiderations { get; set; }

    public decimal? HighValueAdvisor { get; set; }

    public decimal? SecuredClient { get; set; }

    public decimal? GroupClient { get; set; }

    public decimal? StaffMember { get; set; }

    public string? Password { get; set; }

    public decimal? CorrespondenceTranslationRequired { get; set; }

    public decimal? InterpreterRequired { get; set; }

    public string? DOB { get; set; }
    public string? DOD { get; set; }
}

