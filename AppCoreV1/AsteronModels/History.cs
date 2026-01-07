using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class History
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public long? Customtype { get; set; }

    public string? Description { get; set; }

    public DateTime? Eventtimestamp { get; set; }

    public long? Exposureid { get; set; }

    public long? Matterid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Subtype { get; set; }

    public long? Type { get; set; }

    public long? Userid { get; set; }
}
