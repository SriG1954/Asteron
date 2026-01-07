using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Authorityprofile
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Currency { get; set; }

    public string Custom { get; set; } = null!;

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? ScAdditionalslimit { get; set; }

    public long? ScAuthjoblimit { get; set; }

    public long? ScExgratialimit { get; set; }

    public long? ScRecoverywriteofflimit { get; set; }

    public long? ScRejectclaimlimit { get; set; }

    public long? ScTotallosslimit { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
