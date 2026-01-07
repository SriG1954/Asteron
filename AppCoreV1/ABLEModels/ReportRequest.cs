using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCoreV1.ABLEModels;

public partial class ReportRequest
{
    public int Id { get; set; }

    //[Required][Display(Name = "User LANID")] 
    public string? UserId { get; set; }

    //[Required][Display(Name = "ABLE Report Name")] 
    public string? ReportName { get; set; }

    //[Required][Display(Name = "RLA Mail Address")] 
    public string? Email { get; set; }

    public DateTime? DateRequested { get; set; }

    public string? Status { get; set; }

    public DateTime? DateCompleted { get; set; }

}
