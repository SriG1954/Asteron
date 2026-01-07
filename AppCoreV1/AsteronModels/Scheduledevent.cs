using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Scheduledevent
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public string? Comments { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string Eventname { get; set; } = null!;

    public string? Paramname1 { get; set; }

    public string? Paramname2 { get; set; }

    public string? Paramtype1 { get; set; }

    public string? Paramtype2 { get; set; }

    public string? Paramvalue1 { get; set; }

    public string? Paramvalue2 { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? Retrycount { get; set; }

    public DateTime Scheduleddatetime { get; set; }

    public long Type { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
