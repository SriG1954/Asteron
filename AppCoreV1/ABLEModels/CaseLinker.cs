using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class CaseLinker
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseForwardC { get; set; }

    public decimal? CaseForwardI { get; set; }

    public decimal? CaseBackwardC { get; set; }

    public decimal? CaseBackwardI { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? LastUpdatedBy { get; set; }
}
