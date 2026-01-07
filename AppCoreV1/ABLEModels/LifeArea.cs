using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class LifeArea
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? CaseC { get; set; }

    public decimal? CaseI { get; set; }

    public string? Factors { get; set; }

    public string? FactorStatus { get; set; }

    public string? Notes { get; set; }
}

public partial class LifeAreaEx
{
    public string? Id { get; set; }

    public string? C { get; set; }

    public string? I { get; set; }

    public string? CaseC { get; set; }

    public string? CaseI { get; set; }

    public string? Factors { get; set; }

    public string? FactorStatus { get; set; }

    public string? Notes { get; set; }
}
