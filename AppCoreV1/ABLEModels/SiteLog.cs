using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class SiteLog
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? Message { get; set; }

    public string? LogType { get; set; }

    public string? DateCreated { get; set; }
}

public partial class SiteLogA
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? Message { get; set; }

    public string? LogType { get; set; }

    public string? DateCreated { get; set; }
}