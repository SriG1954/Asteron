using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptPhoneenquiry
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? ReasonForContact { get; set; } = null!;

    public string? DateOfContact { get; set; } = null!;

    public string? DirectionOfContact { get; set; }

    public string? ClaimantName { get; set; }

    public string? ContactName { get; set; }

    public string? MethodOfContact { get; set; }

    public string? ContactMadeIndicator { get; set; }

    public string? PhoneRecordingLink { get; set; }

    public decimal? DurationOfContact { get; set; }

    public string? UserName { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }

    public string? ContactDescription { get; set; }

    public string? Decision { get; set; }

    public string? DecisionDate { get; set; }

    public string? DecisionReason { get; set; }
    public int? StaffInd { get; set; }
}
