using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyClassification
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string ClasificationType { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }
}
