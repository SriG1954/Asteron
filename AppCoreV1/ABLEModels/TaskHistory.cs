using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class TaskHistory
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? TaskC { get; set; }

    public decimal? TaskI { get; set; }

    public string? ActionedBy { get; set; }

    public DateTime? ActionedDate { get; set; }
}
