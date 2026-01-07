using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Document
{
    public long Id { get; set; }

    public string? Author { get; set; }

    public string? Authordenorm { get; set; }

    public long? Beanversion { get; set; }

    public long? Claimcontactid { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public DateTime? Datemodified { get; set; }

    public string? Description { get; set; }

    public string? Dms { get; set; }

    public string? Docuid { get; set; }

    public string? Documentidentifier { get; set; }

    public string? Documentidentifierdenorm { get; set; }

    public string? ExposetocustomerExt { get; set; }

    public long? Exposureid { get; set; }

    public string? Inbound { get; set; }

    public string? Mimetype { get; set; }

    public string? Name { get; set; }

    public string? Namedenorm { get; set; }

    public string? Obsolete { get; set; }

    public string Publicid { get; set; } = null!;

    public string? Recipient { get; set; }

    public long Retired { get; set; }

    public long? ScActivitystatus { get; set; }

    public long? ScArchiveonly { get; set; }

    public string? ScBatchid { get; set; }

    public long? ScDisclosurestatus { get; set; }

    public long? ScDocsource { get; set; }

    public DateTime? ScDocumentdate { get; set; }

    public long? ScDocumentsize { get; set; }

    public string? ScIsversion { get; set; }

    public long? Securitytype { get; set; }

    public long? Status { get; set; }

    public long? Type { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
