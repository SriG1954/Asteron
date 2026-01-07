using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Specialneed
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimfkid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? ScSpecialneed { get; set; }

    public string? ScSpecialneedcomment { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
