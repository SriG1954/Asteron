using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Credential
{
    public long Id { get; set; }

    public string Active { get; set; } = null!;

    public long? Beanversion { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long? Failedattempts { get; set; }

    public DateTime? Lockdate { get; set; }

    public string Obfuscatedinternal { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public string Username { get; set; } = null!;

    public string Usernamedenorm { get; set; } = null!;
}
