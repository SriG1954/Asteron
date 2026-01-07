using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Complaintparty
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public string? Comments { get; set; }

    public long Complaintid { get; set; }

    public long? Contactid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Preferedcontactmethod { get; set; }

    public long? Preferedcontacttime { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
