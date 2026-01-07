using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartySearch
{
    public decimal Id { get; set; }
    public decimal C { get; set; }
    public decimal I { get; set; }
    public string? CustomerNo { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public string? Dob { get; set; }

    public string? Dod { get; set; }

    public string? ClaimNumber { get; set; }

    public int Pid { get; set; }
    public int? StaffInd { get; set; }
    public int ApplicationId { get; set; }

}
