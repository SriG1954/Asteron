using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Earning
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? OccupationC { get; set; }

    public decimal? OccupationI { get; set; }

    public string? Type { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public decimal? ActualGross { get; set; }

    public decimal? SalaryAmountBasis { get; set; }

    public string? AdditionalNotes { get; set; }

    public decimal? BiWeekly { get; set; }

    public decimal? SemiMonthly { get; set; }

    public decimal? Monthly { get; set; }

    public decimal? Yearly { get; set; }

    public decimal? Yearly1 { get; set; }

    public decimal? StandardHours { get; set; }

    public decimal? OverrideWeeklyEarnings { get; set; }

    public decimal? OvertimeHours { get; set; }

    public decimal? OvertimeHourlyRate { get; set; }

    public decimal? StandardEarnings { get; set; }

    public decimal? VacationStatutoryTime { get; set; }

    public decimal? VacationStatutoryEarnings { get; set; }

    public decimal? ShiftHours { get; set; }

    public decimal? ShiftDifferential { get; set; }

    public decimal? ShiftPay { get; set; }

    public decimal? ShiftEarnings { get; set; }
}
