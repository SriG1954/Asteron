using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Empldatatoinjincident
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Foreignentityid { get; set; }

    public long Ownerid { get; set; }

    public string Publicid { get; set; } = null!;
}
