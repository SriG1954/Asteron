using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Evaluation
{
    public long Id { get; set; }

    public long? Amount { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Exposureid { get; set; }

    public string? IsvupliftapplicableExt { get; set; }

    public string? Name { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public string? ScCollectexcessind { get; set; }

    public string? ScSettlingtpinsurance { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
