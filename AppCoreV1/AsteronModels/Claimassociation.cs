using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimassociation
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimassoctype { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public string? Title { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
