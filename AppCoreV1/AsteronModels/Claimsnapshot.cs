using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimsnapshot
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public string? Claimdata { get; set; }

    public long Claimid { get; set; }

    public string? Compressed { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Encryptionversion { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime? Snapshotdate { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
