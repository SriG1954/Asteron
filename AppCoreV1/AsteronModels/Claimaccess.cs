using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimaccess
{
    public long Id { get; set; }

    public string? Anyone { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public long? Groupid { get; set; }

    public long Permission { get; set; }

    public string Publicid { get; set; } = null!;

    public long? Securityzoneid { get; set; }

    public long? Userid { get; set; }
}
