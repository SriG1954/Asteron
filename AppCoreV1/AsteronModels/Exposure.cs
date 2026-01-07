using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Exposure
{
    public long Id { get; set; }

    public long? Assignedbyuserid { get; set; }

    public long? Assignedgroupid { get; set; }

    public long? Assigneduserid { get; set; }

    public DateTime? Assignmentdate { get; set; }

    public long Assignmentstatus { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimantdenormid { get; set; }

    public long? Claimanttype { get; set; }

    public long Claimid { get; set; }

    public long Claimorder { get; set; }

    public DateTime? Closedate { get; set; }

    public long? Closedoutcome { get; set; }

    public string? Contactpermitted { get; set; }

    public long? Coverageid { get; set; }

    public long? Coveragesubtype { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? DecisioncommentsExt { get; set; }

    public long? DecisionExt { get; set; }

    public string? ExposurereferencenumberExt { get; set; }

    public long? Exposuretier { get; set; }

    public long Exposuretype { get; set; }

    public long? Incidentid { get; set; }

    public long? Isostatus { get; set; }

    public long? Jurisdictionstate { get; set; }

    public long? LitigationstatusExt { get; set; }

    public string? MaterialdamageExt { get; set; }

    public long? Metriclimitgeneration { get; set; }

    public long? Previousgroupid { get; set; }

    public long? Previoususerid { get; set; }

    public long Primarycoverage { get; set; }

    public string Publicid { get; set; } = null!;

    public long? ReasonwithoutprejudiceExt { get; set; }

    public DateTime? Reopendate { get; set; }

    public long? Reopenedreason { get; set; }

    public long Retired { get; set; }

    public string Rigroupsetexternally { get; set; } = null!;

    public long? Segment { get; set; }

    public DateTime? Settledate { get; set; }

    public long State { get; set; }

    public long? Strategy { get; set; }

    public long Supplementalworkloadweight { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }

    public string? Wcpreexdisblty { get; set; }

    public long Workloadweight { get; set; }
}
