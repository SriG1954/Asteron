using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Claim
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public string? AccidentSickness { get; set; }

    public string? AdditionalInformation { get; set; }

    public decimal? FatalClaim { get; set; }

    public decimal? OccurredInAnotherCountry { get; set; }

    public decimal? ClaimantIsNotifier { get; set; }

    public DateTime? ClaimReceivedDate { get; set; }

    public DateTime? DateReturnedToWork { get; set; }

    public string? TraumaDefinition { get; set; }

    public string? InsuredClaimCorrespondence { get; set; }

    public DateTime? ExpectedRtwftdateIfKnown { get; set; }

    public string? TpdsubDefinition { get; set; }

    public string? Source { get; set; }

    public DateTime? IncurredDateOnLastUpdate { get; set; }

    public DateTime? GuidelinesDate { get; set; }

    public string? RecoveryDurationUnit { get; set; }

    public decimal? Min { get; set; }

    public decimal? Opt { get; set; }

    public decimal? Max { get; set; }

    public decimal? DisableAutoUpdates { get; set; }

    public DateTime? Min1 { get; set; }

    public DateTime? Opt1 { get; set; }

    public DateTime? Max1 { get; set; }
    public int ApplicationId { get; set; }

}
