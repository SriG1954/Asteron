using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Address
{
    public long Id { get; set; }

    public string? Addressline1 { get; set; }

    public string? Addressline2 { get; set; }

    public string? Addressline3 { get; set; }

    public long? Addresstype { get; set; }

    public string Batchgeocode { get; set; } = null!;

    public long? Beanversion { get; set; }

    public string? City { get; set; }

    public string? Citydenorm { get; set; }

    public long? Country { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public string? Description { get; set; }

    public long? Geocodestatus { get; set; }

    public string? Postalcode { get; set; }

    public string? Postalcodedenorm { get; set; }

    public string Publicid { get; set; } = null!;

    public long Retired { get; set; }

    public string? ScAddressformat { get; set; }

    public string? ScPermanentchange { get; set; }

    public long? State { get; set; }

    public long Subtype { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }

    public DateTime? Validuntil { get; set; }
}
