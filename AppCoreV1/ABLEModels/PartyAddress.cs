using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class PartyAddress
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? PartyC { get; set; }

    public decimal? PartyI { get; set; }

    public string? AddressType { get; set; } = null!;

    public string? EffectiveFrom { get; set; } = null!;

    public string? EffectiveTo { get; set; }

    public string? BuildingName1 { get; set; }

    public string? BuildingName2 { get; set; }

    public decimal? DisplayExtend { get; set; }

    public decimal? Dpid { get; set; }

    public string? FloorLevelNum { get; set; }

    public string? LotNumber { get; set; }

    public string? PostalNumber { get; set; }

    public string? PostalNumberP { get; set; }

    public string? PostalNumberS { get; set; }

    public string? PremiseNoSuff { get; set; }

    public decimal? PremiseNoTo { get; set; }

    public string? PremiseNoToSu { get; set; }

    public string? FloorLevelTyp { get; set; }

    public string? StreetSuffix { get; set; }

    public string? PostalType { get; set; }

    public decimal? Status { get; set; }

    public string? AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? Suburb { get; set; } = null!;

    public string? State { get; set; }

    public string? PostCode { get; set; } = null!;

    public string? CountryCode { get; set; }
    public string? ClaimNumber { get; set; }
    public string? PartyName { get; set; }
    public int ApplicationId { get; set; }
}
