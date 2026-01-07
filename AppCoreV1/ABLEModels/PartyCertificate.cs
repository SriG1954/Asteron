using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyCertificate
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string? CertificationIssued { get; set; }

    public string CertificationGroup { get; set; } = null!;

    public string CertificationType { get; set; } = null!;

    public string? CertificationStatus { get; set; }

    public string? DocumentIdentifier { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }
}
