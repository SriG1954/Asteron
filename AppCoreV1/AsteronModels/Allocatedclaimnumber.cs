using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Allocatedclaimnumber
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public string Claimnumber { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Publicid { get; set; } = null!;

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
