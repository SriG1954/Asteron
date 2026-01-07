using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Actassignhistory
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? ScActivity { get; set; }

    public long ScAssignedgroup { get; set; }

    public long? ScAssignedqueue { get; set; }

    public long? ScAssigneduser { get; set; }

    public DateTime? ScReassignmentenddate { get; set; }

    public string ScUserorqueue { get; set; } = null!;

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
