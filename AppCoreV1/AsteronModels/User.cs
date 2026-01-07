using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class User
{
    public long Id { get; set; }

    public long? Authorityprofileid { get; set; }

    public long? Beanversion { get; set; }

    public long Contactid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Credentialid { get; set; }

    public long? Defaultcountry { get; set; }

    public long? Defaultphonecountry { get; set; }

    public string? Department { get; set; }

    public string Externaluser { get; set; } = null!;

    public string? Jobtitle { get; set; }

    public long? Language { get; set; }

    public long? Locale { get; set; }

    public string Obfuscatedinternal { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public long? Systemusertype { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public long? Usersettingsid { get; set; }

    public long Vacationstatus { get; set; }

    public long? Validationlevel { get; set; }
}
