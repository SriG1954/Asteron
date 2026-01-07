using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class OutstandingRequestDocument
{
    public decimal Id { get; set; }

    public decimal? CFrom { get; set; }

    public decimal? IFrom { get; set; }

    public decimal? CTo { get; set; }

    public decimal? ITo { get; set; }

    public decimal? OutstandingRqtC { get; set; }

    public decimal? OutstandingRqtI { get; set; }

    public decimal? DocumentC { get; set; }

    public decimal? DocumentI { get; set; }
}
