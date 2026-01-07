using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Note
{
    public long Id { get; set; }

    public long? Activityid { get; set; }

    public long? Authorid { get; set; }

    public DateTime? Authoringdate { get; set; }

    public long? Beanversion { get; set; }

    public string? Body { get; set; }

    public long? Claimcontactid { get; set; }

    public long Claimid { get; set; }

    public string Confidential { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? ExpcustomernoteExt { get; set; }

    public long? Exposureid { get; set; }

    public string? ExptocustselfserviceExt { get; set; }

    public long? Language { get; set; }

    public long? Matterid { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public string? ScIsmanualnote { get; set; }

    public long? Securitytype { get; set; }

    public string? Subject { get; set; }

    public long? Topic { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public string? ClaimnumberRefOnly { get; set; }
}
