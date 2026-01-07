using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyPolicyRole
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public decimal? PolicyC { get; set; }

    public decimal? PolicyI { get; set; }

    public string Role { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal? Erole { get; set; }

    public decimal? Estatus { get; set; }

    public DateTime? CommenceDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public decimal? OrderNo { get; set; }
}
