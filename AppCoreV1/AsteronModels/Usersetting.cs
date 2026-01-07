using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Usersetting
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Lastnclaims { get; set; }

    public long? Numopenclaims { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? Startuppage { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
