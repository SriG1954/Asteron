using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Riskunit
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Policyid { get; set; }

    public long? Policylocationid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long Runumber { get; set; }

    public long Subtype { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
