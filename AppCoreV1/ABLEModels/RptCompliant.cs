using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptCompliant
{
    public int Id { get; set; }

    public string? ClaimNo { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? FirstName { get; set; } = null!;

    public string? Gender { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PolicyNo1 { get; set; }

    public string? GroupRetail1 { get; set; }

    public string? BenefitType1 { get; set; }

    public string? BenefitStatus1 { get; set; }

    public string? PolicyNo2 { get; set; }

    public string? GroupRetail2 { get; set; }

    public string? BenefitType2 { get; set; }

    public string? BenefitStatus2 { get; set; }

    public string? PolicyNo3 { get; set; }

    public string? GroupRetail3 { get; set; }

    public string? BenefitType3 { get; set; }

    public string? BenefitStatus3 { get; set; }

    public string? PolicyNo4 { get; set; }

    public string? GroupRetail4 { get; set; }

    public string? BenefitType4 { get; set; }

    public string? BenefitStatus4 { get; set; }

    public string? ClaimStatus { get; set; }

    public string? ComplaintIdNo { get; set; }

    public string? ComplaintNotificationDate { get; set; }

    public string? RaisedBy { get; set; }

    public string? ComplaintTheme1 { get; set; }

    public string? ComplaintTheme2 { get; set; }

    public string? ComplaintTheme3 { get; set; }

    public string? ComplaintTheme4 { get; set; }

    public string? ComplaintTheme5 { get; set; }

    public string? ComplaintType { get; set; }

    public string? Method1 { get; set; }

    public string? ComplaintSource1 { get; set; }

    public string? Method2 { get; set; }

    public string? ComplaintSource2 { get; set; }

    public string? Method3 { get; set; }

    public string? ComplaintSource3 { get; set; }

    public string? ComplaintStatus { get; set; }

    public string? ComplaintOwner { get; set; }

    public string? EscalationDate { get; set; }

    public decimal? NoOfDaysComplaintOpen { get; set; }

    public string? ClosureDate { get; set; }

    public string? ClosureReason { get; set; }

    public string? AcknowLetterSlaMetYN { get; set; }

    public int? DaysToSendAcknowLetter { get; set; }

    public string? LetterToTrusteeSlaMetYN { get; set; }

    public int? DaysToSendTrusteeLetter { get; set; }

    public string? NonSuperLetterSlaMetYN { get; set; }

    public int? DaysToSendNonSuperLetter { get; set; }

    public string? SuperLetterSlaMetYN { get; set; }

    public int? DaysToSendSuperLetter { get; set; }

    public string? TmOfComplaintRecordOwner { get; set; }

    public string? TmOfClaimCaseOwner { get; set; }

    public string? ComplaintRecordTeamName { get; set; }

    public string? EscalationApprovedByTm { get; set; }

    public string? EscalationDeclinedByTm { get; set; }

    public string? EscalationToTm { get; set; }

    public string? CatEscalationApproved { get; set; }

    public string? CatEscalationDeclined { get; set; }

    public string? EscalationToCat { get; set; }

    public string? ClassOfBusiness { get; set; }
    public int? StaffInd { get; set; }
}
