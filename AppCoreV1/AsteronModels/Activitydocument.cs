using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Activitydocument
{
    public long Id { get; set; }

    public long Activityid { get; set; }

    public long? Beanversion { get; set; }

    public long Documentid { get; set; }

    public string Publicid { get; set; } = null!;
}
