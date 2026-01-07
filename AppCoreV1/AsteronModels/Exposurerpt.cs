using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class Exposurerpt
{
    public long Id { get; set; }

    public long Availablereserves { get; set; }

    public long Availableresrvrprtng { get; set; }

    public long? Beanversion { get; set; }

    public long Claimid { get; set; }

    public DateTime Createtime { get; set; }

    public long? Createuserid { get; set; }

    public long Exposureid { get; set; }

    public long Futurepayments { get; set; }

    public long Futurepaymentsrprtng { get; set; }

    public long Openrecoveryreserves { get; set; }

    public long Openrecoveryresrprtng { get; set; }

    public long Openreserves { get; set; }

    public long Openreservesrprtng { get; set; }

    public string Publicid { get; set; } = null!;

    public long Remainingreserves { get; set; }

    public long Remainingresrvrprtng { get; set; }

    public long Retired { get; set; }

    public long Totalpayments { get; set; }

    public long Totalpaymentsrprtng { get; set; }

    public long Totalrecoveries { get; set; }

    public long Totalrecoveriesrprtng { get; set; }

    public DateTime Updatetime { get; set; }

    public long? Updateuserid { get; set; }
}
