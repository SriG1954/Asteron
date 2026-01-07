using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Policylocation
{
    public long Id { get; set; }

    public long? Addressid { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Locationnumber { get; set; }

    public long? Policyid { get; set; }

    public string Primarylocation { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
