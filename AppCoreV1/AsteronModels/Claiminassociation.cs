using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claiminassociation
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimassociationid { get; set; }

    public long Claiminfoid { get; set; }

    public string Primaryclaim { get; set; } = null!;

    public string Publicid { get; set; } = null!;
}
