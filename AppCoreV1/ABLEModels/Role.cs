using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class Role
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public string? Role1 { get; set; }

    public string? Department { get; set; }

    public decimal? IsEnabled { get; set; }
}
