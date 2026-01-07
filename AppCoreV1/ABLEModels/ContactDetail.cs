using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class ContactDetail
{
    public decimal Id { get; set; }

    public decimal? C { get; set; }

    public decimal? I { get; set; }

    public decimal? ContactMediumPartyC { get; set; }

    public decimal? ContactMediumPartyI { get; set; }

    public decimal? PartyAddressPartyC { get; set; }

    public decimal? PartyAddressPartyI { get; set; }

    public decimal? Status { get; set; }

    public string? Email { get; set; }

    public string? SendEmailTo { get; set; }

    public string? ContactMethod { get; set; }

    public string? ContactTime { get; set; }

    public string? Verificaton { get; set; }

    public string? IntCode { get; set; }

    public string? AreaCode { get; set; }

    public string? TelNo { get; set; }

    public string? ExtnNo { get; set; }

    public decimal? IsExDir { get; set; }
}
