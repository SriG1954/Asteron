using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class AbleIssue
{
    public int Id { get; set; }

    public string? ReportedBy { get; set; }

    public string? Description { get; set; }

    public string? DateReported { get; set; }

    public string? Status { get; set; }
}
