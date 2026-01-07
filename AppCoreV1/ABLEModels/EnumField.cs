using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class EnumField
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public string? InstanceName { get; set; }

    public decimal? Retired { get; set; }

    public string? DomainName { get; set; }

    public string? Description { get; set; }
}
