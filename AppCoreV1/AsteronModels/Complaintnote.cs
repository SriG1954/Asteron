using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Complaintnote
{
    public long Id { get; set; }

    public string? Adviceinstructions { get; set; }

    public long? Beanversion { get; set; }

    public long Complaintid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Isrepeatcall { get; set; } = null!;

    public string? Nextaction { get; set; }

    public long Noteid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
