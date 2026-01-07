using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimcontactrole
{
    public long Id { get; set; }

    public string Active { get; set; } = null!;

    public long? Beanversion { get; set; }

    public long Claimcontactid { get; set; }

    public string? Comments { get; set; }

    public long? Coveredpartytype { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Exposureid { get; set; }

    public long? Incidentid { get; set; }

    public long? Matterid { get; set; }

    public long? Partynumber { get; set; }

    public long? Policyid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long Role { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
