using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Complaint
{
    public long Id { get; set; }

    public long? Assignedbyuserid { get; set; }

    public long? Assignedgroupid { get; set; }

    public long? Assigneduserid { get; set; }

    public DateTime? Assignmentdate { get; set; }

    public long Assignmentstatus { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimid { get; set; }

    public string? Complainantexpectationdesc { get; set; }

    public long? ComplaintcategoryExtid { get; set; }

    public string Complaintnumber { get; set; } = null!;

    public long? Contactid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public DateTime? Extendedresolutiondate { get; set; }

    public long? Howreported { get; set; }

    public DateTime? Incidentdate { get; set; }

    public string? Iscostforactualamount { get; set; }

    public string? Mediadescription { get; set; }

    public string? Mediainvolvedflag { get; set; }

    public long? Previousgroupid { get; set; }

    public long? Previoususerid { get; set; }

    public string Publicid { get; set; } = null!;

    public DateTime? Receiveddate { get; set; }

    public DateTime? Resolutiondate { get; set; }

    public string? Resolutiondescription { get; set; }

    public long Retired { get; set; }

    public long? Status { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
