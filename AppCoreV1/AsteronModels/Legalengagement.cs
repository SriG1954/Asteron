using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Legalengagement
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Externalreference { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long? Requeststatus { get; set; }

    public long Retired { get; set; }

    public long? Status { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
