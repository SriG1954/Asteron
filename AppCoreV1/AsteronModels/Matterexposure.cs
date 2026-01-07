using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Matterexposure
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Exposureid { get; set; }

    public long Matterid { get; set; }

    public string Publicid { get; set; } = null!;
}
