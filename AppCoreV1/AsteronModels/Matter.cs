using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Matter
{
    public long Id { get; set; }

    public long? Assignedbyuserid { get; set; }

    public long? Assignedgroupid { get; set; }

    public long? Assigneduserid { get; set; }

    public DateTime? Assignmentdate { get; set; }

    public long Assignmentstatus { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime? Closedate { get; set; }

    public long? Courttype { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Legalspecialty { get; set; }

    public long? Mattertype { get; set; }

    public string Name { get; set; } = null!;

    public long? Previousgroupid { get; set; }

    public long? Previoususerid { get; set; }

    public long? Primarycause { get; set; }

    public string Publicid { get; set; } = null!;

    public long? Reopenedreason { get; set; }

    public long? Resolution { get; set; }

    public long Retired { get; set; }

    public string? Subrorelated { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }
}
