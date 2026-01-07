using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Policy
{
    public long Id { get; set; }

    public string? Accountnumber { get; set; }

    public long? Beanversion { get; set; }

    public DateTime? Cancellationdate { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Currency { get; set; }

    public DateTime? Effectivedate { get; set; }

    public DateTime? Expirationdate { get; set; }

    public string? Foreigncoverage { get; set; }

    public DateTime? Origeffectivedate { get; set; }

    public string? Otherinsurance { get; set; }

    public string Policynumber { get; set; } = null!;

    public long Policytype { get; set; }

    public string? Producercode { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime? Retroactivedate { get; set; }

    public string? Returntoworkprgm { get; set; }

    public long? ScBrand { get; set; }

    public string? ScGstexempt { get; set; }

    public string? ScGstregistered { get; set; }

    public long? ScIntermedtype { get; set; }

    public string? ScStampdutyexempt { get; set; }

    public string? ScUnderwritingcompany { get; set; }

    public long? Status { get; set; }

    public long? Totalproperties { get; set; }

    public long? Totalvehicles { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Validationlevel { get; set; }

    public string Verified { get; set; } = null!;
}
