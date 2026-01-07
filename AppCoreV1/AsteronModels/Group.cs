using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Group
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Grouptype { get; set; }

    public long? Loadfactor { get; set; }

    public string Name { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? ScGroupstrategy { get; set; }

    public long Securityzoneid { get; set; }

    public long? Supervisorid { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }

    public string Worldvisible { get; set; } = null!;
}
