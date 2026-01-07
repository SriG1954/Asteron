using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claim
{
    public long Id { get; set; }

    public long? Assignedbyuserid { get; set; }

    public long? Assignedgroupid { get; set; }

    public long? Assigneduserid { get; set; }

    public DateTime? Assignmentdate { get; set; }

    public long Assignmentstatus { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimantdenormid { get; set; }

    public string Claimnumber { get; set; } = null!;

    public long? Claimtier { get; set; }

    public DateTime? Closedate { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Currency { get; set; }

    public string? Description { get; set; }

    public string Donotdestroy { get; set; } = null!;

    public long Flagged { get; set; }

    public DateTime? Flaggeddate { get; set; }

    public string? Flaggedreason { get; set; }

    public string? Incidentreport { get; set; }

    public long? Insureddenormid { get; set; }

    public string? Insuredpremises { get; set; }

    public string? Isoenabled { get; set; }

    public long? Isostatus { get; set; }

    public long? Lobcode { get; set; }

    public long? Lockingcolumn { get; set; }

    public long? Losscause { get; set; }

    public DateTime? Lossdate { get; set; }

    public long? Losslocationid { get; set; }

    public long Losstype { get; set; }

    public long? Maincontacttype { get; set; }

    public long? Permissionrequired { get; set; }

    public long Policyid { get; set; }

    public string? Preexdisblty { get; set; }

    public long? Previousgroupid { get; set; }

    public long? Previoususerid { get; set; }

    public string Publicid { get; set; } = null!;

    public DateTime? Reopendate { get; set; }

    public long? Reopenedreason { get; set; }

    public long? Reportedbytype { get; set; }

    public DateTime? Reporteddate { get; set; }

    public long Retired { get; set; }

    public string? ScAlternateclaimnumber1 { get; set; }

    public long? ScClaimauto { get; set; }

    public long? ScClaimdecision { get; set; }

    public string? ScClaimdecisioncomments { get; set; }

    public long? ScClaimeventquestions { get; set; }

    public long? ScClaimproctype { get; set; }

    public long? ScClaimreconcilereport { get; set; }

    public long? ScClaimrejectreason { get; set; }

    public long? ScClosedoutcome { get; set; }

    public long? ScDependentsequencenumber { get; set; }

    public string? ScDuplicate { get; set; }

    public long? ScIdrstatus { get; set; }

    public string? ScIsaccidentclaim { get; set; }

    public string? ScLegacyclaimno { get; set; }

    public long? ScLosscause { get; set; }

    public long? ScPolicybrand { get; set; }

    public DateTime? ScSignificantinjurydate { get; set; }

    public long? ScWpreasoncode { get; set; }

    public long? Segment { get; set; }

    public long? Showmedicalfirstinfo { get; set; }

    public long? Siescalatesiu { get; set; }

    public long? Siscore { get; set; }

    public long? Siustatus { get; set; }

    public long State { get; set; }

    public long? Strategy { get; set; }

    public long? Supplementalworkloadweight { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }

    public long Workloadweight { get; set; }
}
