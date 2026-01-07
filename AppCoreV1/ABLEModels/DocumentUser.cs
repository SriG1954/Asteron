using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class DocumentUser
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public string? UserName { get; set; }

    public string? UserId { get; set; }

    public decimal? UserEnabled { get; set; }

    public decimal? DepartmentDefaultC { get; set; }

    public decimal? DepartmentDefaultI { get; set; }
}
