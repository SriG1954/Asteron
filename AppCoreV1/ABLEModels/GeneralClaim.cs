using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.ABLEModels
{
    public partial class GeneralClaim
    {
        public string? CaseNumber { get; set; }
        public Case? mCase { get; set; } = null;
        public Claim? mClaim { get; set;} = null;
        public CaseParty? mCaseParty { get; set; } = null;
        public Party? mParty { get; set; } = null;
        public PartyAddress? mPartyAddress { get; set; } = null;
        public ContactDetail? mContactDetail { get; set; } = null;
        public DepartmentUser? mDepartmentUser { get; set; } = null;
        public DocumentA? mDocument { get; set; } = null;
        public Process? mProcess { get; set; } = null;

    }
}
