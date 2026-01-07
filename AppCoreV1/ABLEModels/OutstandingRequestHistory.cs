using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class OutstandingRequestHistory
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? OutstandingRqtC { get; set; }

    public decimal? OutstandingRqtI { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? CompletionNotes { get; set; }

    public string? ReasonForCompletion { get; set; }

    public string? SupressionNotes { get; set; }

    public string? ReasonForSuppression { get; set; }
}
