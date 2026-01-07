using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyConsent
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string ConsentType { get; set; } = null!;

    public string ConsentStatus { get; set; } = null!;

    public DateTime? EffectiveDate { get; set; }
}
