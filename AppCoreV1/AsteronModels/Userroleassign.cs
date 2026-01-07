using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Userroleassign
{
    public long Id { get; set; }

    public string Active { get; set; } = null!;

    public long? Assignedgroupid { get; set; }

    public long? Assigneduserid { get; set; }

    public long Assignmentstatus { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long Role { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
