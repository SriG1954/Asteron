using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Coverage
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Currency { get; set; }

    public DateTime? Effectivedate { get; set; }

    public DateTime? Expirationdate { get; set; }

    public string? OccupationExt { get; set; }

    public long Policyid { get; set; }

    public long? PremiumstatusExt { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? Riskunitid { get; set; }

    public string? ScCoveragesourcekey { get; set; }

    public string? ScRawproduct { get; set; }

    public long? ScStatus { get; set; }

    public long Subtype { get; set; }

    public DateTime? TermenddateExt { get; set; }

    public DateTime? TermstartdateExt { get; set; }

    public long Type { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
