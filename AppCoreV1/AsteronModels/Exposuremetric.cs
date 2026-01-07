using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Exposuremetric
{
    public long Id { get; set; }

    public string? Activityskipped { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Exposureid { get; set; }

    public long? Integervalue { get; set; }

    public string? Isopen { get; set; }

    public long? Percentvalue { get; set; }

    public string Publicid { get; set; } = null!;

    public string? Skipped { get; set; }

    public DateTime? Starttime { get; set; }

    public long Subtype { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
