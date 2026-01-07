using System;
using System.Collections.Generic;

namespace AppCoreV1.ABLEModels;

public partial class AbleEmail
{
    public int EmailId { get; set; }

    public string? SenderEmail { get; set; }

    public string? RecipientEmail { get; set; }

    public string? MailSubject { get; set; }

    public string? MailBody { get; set; }

    public DateTime? DateSent { get; set; }
}
