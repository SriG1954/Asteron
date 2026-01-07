using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Incident
{
    public long Id { get; set; }

    public string? Ambulanceused { get; set; }

    public long? Beanversion { get; set; }

    public long? ClaimanttypeExt { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public long? Detailedinjurytype { get; set; }

    public long? Employmentdataid { get; set; }

    public long? FaultratingExt { get; set; }

    public long? FirstnoticeindicatorExt { get; set; }

    public long? Generalinjurytype { get; set; }

    public long? HowreportedExt { get; set; }

    public long? LosscauseExt { get; set; }

    public string? Lostwages { get; set; }

    public long? PrimarybodyfunctionExt { get; set; }

    public string Publicid { get; set; } = null!;

    public string? RehabilitationreferralindExt { get; set; }

    public long? ReportedbytypeExt { get; set; }

    public DateTime? ReporteddateExt { get; set; }

    public long? ReportonlyExt { get; set; }

    public long? ResultofinjuryExt { get; set; }

    public long Retired { get; set; }

    public long? ScClaimeventquestions { get; set; }

    public long? ScInjuryquestions { get; set; }

    public long? Severity { get; set; }

    public long? StatutorybenefitsExt { get; set; }

    public long? StatutorycareExtid { get; set; }

    public long Subtype { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
