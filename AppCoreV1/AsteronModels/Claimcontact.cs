using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Claimcontact
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public string? Claimantflag { get; set; }

    public long Claimid { get; set; }

    public long Contactid { get; set; }

    public string? Contactnamedenorm { get; set; }

    public string? Contactprohibited { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Personfirstnamedenorm { get; set; }

    public string? Personlastnamedenorm { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
