using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ProcessHistory
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ProcessC { get; set; }

    public decimal? ProcessI { get; set; }

    public string? Reason { get; set; }

    public DateTime? ActionDate { get; set; }
}
