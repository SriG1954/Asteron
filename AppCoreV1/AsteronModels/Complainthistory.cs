using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Complainthistory
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public long? ComplaintcategoryExtid { get; set; }

    public long Complaintid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public DateTime? Extendedresolutiondate { get; set; }

    public string Publicid { get; set; } = null!;

    public DateTime? Receiveddate { get; set; }

    public DateTime? Resolutiondate { get; set; }

    public string? Resolutiondescription { get; set; }

    public long Retired { get; set; }

    public long? Status { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Userid { get; set; }
}
