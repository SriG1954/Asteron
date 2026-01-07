using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class RptRecoveryrehabnote
{
    public int Id { get; set; }

    public string? ClaimNumber { get; set; } = null!;

    public string? NoteType { get; set; } = null!;

    public string? DateCreated { get; set; } = null!;

    public string? Status { get; set; }

    public string? DateOfStatusChange { get; set; }

    public string? LumpsumIpIndicator { get; set; }

    public string? ClaimType { get; set; }
    public int? StaffInd { get; set; }
}
