using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Complaintcategory
{
    public long Id { get; set; }

    public long? Beanversion { get; set; }

    public string Categorydescription { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Isdisabled { get; set; }

    public string? Isinuse { get; set; }

    public long Policytype { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public string Subcategorydescription { get; set; } = null!;

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
