using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class CaseParty
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? RoleC { get; set; }

    public decimal? RoleI { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? UseDefaultPaymentDetailsForParty { get; set; }
}


