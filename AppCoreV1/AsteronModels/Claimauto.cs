using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimauto
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Differentialpricingind { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long Subtype { get; set; }

    public string? Updatedfromcentretab { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
