using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Incidentcontact
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long? Contact { get; set; }

    public long? ContactroleExt { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Incidentid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
