using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PaymentPreference
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string Description { get; set; } = null!;

    public decimal? BulkPayee { get; set; }

    public string PaymentPeriod { get; set; } = null!;

    public string PaymentDay { get; set; } = null!;

    public string? NominatedPayee { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public decimal? UseForBilling { get; set; }

    public string? Identifier { get; set; }

    public string? CategoryOfService { get; set; }

    public string? PaymentMethod { get; set; }

    public string? NameToPrintOnCheque { get; set; }
}
