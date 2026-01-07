using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimexception
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Exchecktime { get; set; }

    public string Publicid { get; set; } = null!;
}
