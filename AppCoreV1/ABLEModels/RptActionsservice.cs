using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptActionsservice
{
    public int Id { get; set; }

    public string? ClaimCase { get; set; } = null!;

    public string? ClaimCreationDate { get; set; } = null!;

    public string? NotificationDate { get; set; } = null!;

    public string? IncurredDate { get; set; } = null!;

    public string? CaseManager { get; set; } = null!;

    public string? TeamManager { get; set; }

    public string? TriageSegment { get; set; }

    public string? DepartmentOfCase { get; set; }

    public string? CmpCustomerGoal { get; set; }

    public string? CmpGoalDate { get; set; }

    public string? ActionName { get; set; }

    public string? ActionStartDate { get; set; }

    public int? ActionOpenDuration { get; set; }

    public string? ActionOutcome { get; set; }

    public string? ActionOutcomeReason { get; set; }

    public string? ActionOutcomeComments { get; set; }

    public string? ActionOutcomeDate { get; set; }

    public string? ServiceCreatorActionOwner { get; set; }

    public string? ServiceProvider { get; set; }

    public string? ServiceCode { get; set; }

    public string? ServiceName { get; set; }

    public decimal? UnitsOfferedNumberOfHours { get; set; }

    public decimal? RatePerHour { get; set; }

    public decimal? TotalCosts { get; set; }

    public string? ServiceStartDate { get; set; }

    public string? ServiceEndDate { get; set; }

    public string? PrimaryDiagnosis { get; set; }

    public string? PrimaryCauseDescription { get; set; }

    public string? Occupation { get; set; }

    public string? DeathBenefitCase { get; set; }

    public string? BexBenefitCase { get; set; }

    public string? IpBenefitCase { get; set; }

    public string? TpdBenefitCase { get; set; }

    public string? TtdBenefitCase { get; set; }

    public string? TraumaBenefitCase { get; set; }

    public string? StandAloneWopBenefitCase { get; set; }
    public int? StaffInd { get; set; }

}
