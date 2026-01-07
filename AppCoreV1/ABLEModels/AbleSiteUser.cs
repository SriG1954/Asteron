using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class AbleSiteUser
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }
    public string? RoleName { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsActive { get; set; }
}

public partial class AbleSiteUserA
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }
    public string? RoleName { get; set; }

    public string? DateCreated { get; set; }

    public string? IsActive { get; set; }
}