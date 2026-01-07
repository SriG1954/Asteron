using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyContact
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string? ContactMethod { get; set; } = null!;

    public string? ContactTime { get; set; }

    public string? Verificaton { get; set; } = null!;

    public string? IntCode { get; set; }

    public string? AreaCode { get; set; }

    public string? TelNo { get; set; } = null!;

    public string? ExtNo { get; set; }

    public decimal? IsExDir { get; set; }

    public string? Email { get; set; } = null!;
}
