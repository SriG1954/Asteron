using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class DocumentGroup
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string? DocumentGroup1 { get; set; }
}
