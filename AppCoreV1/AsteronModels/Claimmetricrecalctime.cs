using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimmetricrecalctime
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Lockingcolumn { get; set; }

    public long Metriclimitgeneration { get; set; }

    public DateTime? Nextrecalculationtime { get; set; }

    public string Publicid { get; set; } = null!;

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
