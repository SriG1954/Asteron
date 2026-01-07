using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Activitypattern
{
    public long Id { get; set; }

    public long Activityclass { get; set; }

    public string Automatedonly { get; set; } = null!;

    public long? Beanversion { get; set; }

    public long? Category { get; set; }

    public long? Claimlosstype { get; set; }

    public string Closedclaimavlble { get; set; } = null!;

    public string? Code { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public long? Escalationbuscaltag { get; set; }

    public long? Escalationdays { get; set; }

    public long? Escalationhours { get; set; }

    public long? Escalationincldays { get; set; }

    public long? Escalationstartpt { get; set; }

    public string? Escbuscallocpath { get; set; }

    public string Externallyowned { get; set; } = null!;

    public long? Importance { get; set; }

    public string Mandatory { get; set; } = null!;

    public long? Priority { get; set; }

    public string Publicid { get; set; } = null!;

    public string Recurring { get; set; } = null!;

    public long Retired { get; set; }

    public long? ScActautoassigntype { get; set; }

    public long? ScAutoassigntogroup { get; set; }

    public long? ScAutoassigntoqueue { get; set; }

    public string? ScCancompleteonworkplan { get; set; }

    public long? ScDefaultassigntype { get; set; }

    public string? ScIsreassignablewithclaim { get; set; }

    public string? ScIssubjecteditable { get; set; }

    public string? ScScanneddocumentactivity { get; set; }

    public string? Shortsubject { get; set; }

    public string? Subject { get; set; }

    public string? Targetbuscallocpath { get; set; }

    public long? Targetbuscaltag { get; set; }

    public long? Targetdays { get; set; }

    public long? Targethours { get; set; }

    public long? Targetincludedays { get; set; }

    public long? Targetstartpoint { get; set; }

    public long Type { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
