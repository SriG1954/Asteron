using AppCoreV1.Interfaces;
using ClosedXML.Excel;

namespace AppCoreV1.Helper
{
    public class XLSAsteronHelper : IXLSAsteronHelper, IDisposable
    {
        private readonly IAsteronSearch _context;

        public XLSAsteronHelper(IAsteronSearch context)
        {
            _context = context;
        }

        public async Task<byte[]> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchClaim(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Claim");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Claim";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Assignedbyuserid";
                worksheet.Cell(currentRow, 3).Value = "Assignedgroupid";
                worksheet.Cell(currentRow, 4).Value = "Assigneduserid";
                worksheet.Cell(currentRow, 5).Value = "Assignmentdate";
                worksheet.Cell(currentRow, 6).Value = "Assignmentstatus";
                worksheet.Cell(currentRow, 7).Value = "Beanversion";
                worksheet.Cell(currentRow, 8).Value = "Claimantdenormid";
                worksheet.Cell(currentRow, 9).Value = "Claimnumber";
                worksheet.Cell(currentRow, 10).Value = "Claimtier";
                worksheet.Cell(currentRow, 11).Value = "Closedate";
                worksheet.Cell(currentRow, 12).Value = "Createtime";
                worksheet.Cell(currentRow, 13).Value = "Createuserid";
                worksheet.Cell(currentRow, 14).Value = "Currency";
                worksheet.Cell(currentRow, 15).Value = "Description";
                worksheet.Cell(currentRow, 16).Value = "Donotdestroy";
                worksheet.Cell(currentRow, 17).Value = "Flagged";
                worksheet.Cell(currentRow, 18).Value = "Flaggeddate";
                worksheet.Cell(currentRow, 19).Value = "Flaggedreason";
                worksheet.Cell(currentRow, 20).Value = "Incidentreport";
                worksheet.Cell(currentRow, 21).Value = "Insureddenormid";
                worksheet.Cell(currentRow, 22).Value = "Insuredpremises";
                worksheet.Cell(currentRow, 23).Value = "Isoenabled";
                worksheet.Cell(currentRow, 24).Value = "Isostatus";
                worksheet.Cell(currentRow, 25).Value = "Lobcode";
                worksheet.Cell(currentRow, 26).Value = "Lockingcolumn";
                worksheet.Cell(currentRow, 27).Value = "Losscause";
                worksheet.Cell(currentRow, 28).Value = "Lossdate";
                worksheet.Cell(currentRow, 29).Value = "Losslocationid";
                worksheet.Cell(currentRow, 30).Value = "Losstype";
                worksheet.Cell(currentRow, 31).Value = "Maincontacttype";
                worksheet.Cell(currentRow, 32).Value = "Permissionrequired";
                worksheet.Cell(currentRow, 33).Value = "Policyid";
                worksheet.Cell(currentRow, 34).Value = "Preexdisblty";
                worksheet.Cell(currentRow, 35).Value = "Previousgroupid";
                worksheet.Cell(currentRow, 36).Value = "Previoususerid";
                worksheet.Cell(currentRow, 37).Value = "Publicid";
                worksheet.Cell(currentRow, 38).Value = "Reopendate";
                worksheet.Cell(currentRow, 39).Value = "Reopenedreason";
                worksheet.Cell(currentRow, 40).Value = "Reportedbytype";
                worksheet.Cell(currentRow, 41).Value = "Reporteddate";
                worksheet.Cell(currentRow, 42).Value = "Retired";
                worksheet.Cell(currentRow, 43).Value = "ScAlternateclaimnumber1";
                worksheet.Cell(currentRow, 44).Value = "ScClaimauto";
                worksheet.Cell(currentRow, 45).Value = "ScClaimdecision";
                worksheet.Cell(currentRow, 46).Value = "ScClaimdecisioncomments";
                worksheet.Cell(currentRow, 47).Value = "ScClaimeventquestions";
                worksheet.Cell(currentRow, 48).Value = "ScClaimproctype";
                worksheet.Cell(currentRow, 49).Value = "ScClaimreconcilereport";
                worksheet.Cell(currentRow, 50).Value = "ScClaimrejectreason";
                worksheet.Cell(currentRow, 51).Value = "ScClosedoutcome";
                worksheet.Cell(currentRow, 52).Value = "ScDependentsequencenumber";
                worksheet.Cell(currentRow, 53).Value = "ScDuplicate";
                worksheet.Cell(currentRow, 54).Value = "ScIdrstatus";
                worksheet.Cell(currentRow, 55).Value = "ScIsaccidentclaim";
                worksheet.Cell(currentRow, 56).Value = "ScLegacyclaimno";
                worksheet.Cell(currentRow, 57).Value = "ScLosscause";
                worksheet.Cell(currentRow, 58).Value = "ScPolicybrand";
                worksheet.Cell(currentRow, 59).Value = "ScSignificantinjurydate";
                worksheet.Cell(currentRow, 60).Value = "ScWpreasoncode";
                worksheet.Cell(currentRow, 61).Value = "Segment";
                worksheet.Cell(currentRow, 62).Value = "Showmedicalfirstinfo";
                worksheet.Cell(currentRow, 63).Value = "Siescalatesiu";
                worksheet.Cell(currentRow, 64).Value = "Siscore";
                worksheet.Cell(currentRow, 65).Value = "Siustatus";
                worksheet.Cell(currentRow, 66).Value = "State";
                worksheet.Cell(currentRow, 67).Value = "Strategy";
                worksheet.Cell(currentRow, 68).Value = "Supplementalworkloadweight";
                worksheet.Cell(currentRow, 69).Value = "Updatetime";
                worksheet.Cell(currentRow, 70).Value = "Updateuserid";
                worksheet.Cell(currentRow, 71).Value = "Validationlevel";
                worksheet.Cell(currentRow, 72).Value = "Workloadweight";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Assignedbyuserid;
                    worksheet.Cell(currentRow, 3).Value = claim.Assignedgroupid;
                    worksheet.Cell(currentRow, 4).Value = claim.Assigneduserid;
                    worksheet.Cell(currentRow, 5).Value = claim.Assignmentdate;
                    worksheet.Cell(currentRow, 6).Value = claim.Assignmentstatus;
                    worksheet.Cell(currentRow, 7).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 8).Value = claim.Claimantdenormid;
                    worksheet.Cell(currentRow, 9).Value = claim.Claimnumber;
                    worksheet.Cell(currentRow, 10).Value = claim.Claimtier;
                    worksheet.Cell(currentRow, 11).Value = claim.Closedate;
                    worksheet.Cell(currentRow, 12).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 13).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 14).Value = claim.Currency;
                    worksheet.Cell(currentRow, 15).Value = claim.Description;
                    worksheet.Cell(currentRow, 16).Value = claim.Donotdestroy;
                    worksheet.Cell(currentRow, 17).Value = claim.Flagged;
                    worksheet.Cell(currentRow, 18).Value = claim.Flaggeddate;
                    worksheet.Cell(currentRow, 19).Value = claim.Flaggedreason;
                    worksheet.Cell(currentRow, 20).Value = claim.Incidentreport;
                    worksheet.Cell(currentRow, 21).Value = claim.Insureddenormid;
                    worksheet.Cell(currentRow, 22).Value = claim.Insuredpremises;
                    worksheet.Cell(currentRow, 23).Value = claim.Isoenabled;
                    worksheet.Cell(currentRow, 24).Value = claim.Isostatus;
                    worksheet.Cell(currentRow, 25).Value = claim.Lobcode;
                    worksheet.Cell(currentRow, 26).Value = claim.Lockingcolumn;
                    worksheet.Cell(currentRow, 27).Value = claim.Losscause;
                    worksheet.Cell(currentRow, 28).Value = claim.Lossdate;
                    worksheet.Cell(currentRow, 29).Value = claim.Losslocationid;
                    worksheet.Cell(currentRow, 30).Value = claim.Losstype;
                    worksheet.Cell(currentRow, 31).Value = claim.Maincontacttype;
                    worksheet.Cell(currentRow, 32).Value = claim.Permissionrequired;
                    worksheet.Cell(currentRow, 33).Value = claim.Policyid;
                    worksheet.Cell(currentRow, 34).Value = claim.Preexdisblty;
                    worksheet.Cell(currentRow, 35).Value = claim.Previousgroupid;
                    worksheet.Cell(currentRow, 36).Value = claim.Previoususerid;
                    worksheet.Cell(currentRow, 37).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 38).Value = claim.Reopendate;
                    worksheet.Cell(currentRow, 39).Value = claim.Reopenedreason;
                    worksheet.Cell(currentRow, 40).Value = claim.Reportedbytype;
                    worksheet.Cell(currentRow, 41).Value = claim.Reporteddate;
                    worksheet.Cell(currentRow, 42).Value = claim.Retired;
                    worksheet.Cell(currentRow, 43).Value = claim.ScAlternateclaimnumber1;
                    worksheet.Cell(currentRow, 44).Value = claim.ScClaimauto;
                    worksheet.Cell(currentRow, 45).Value = claim.ScClaimdecision;
                    worksheet.Cell(currentRow, 46).Value = claim.ScClaimdecisioncomments;
                    worksheet.Cell(currentRow, 47).Value = claim.ScClaimeventquestions;
                    worksheet.Cell(currentRow, 48).Value = claim.ScClaimproctype;
                    worksheet.Cell(currentRow, 49).Value = claim.ScClaimreconcilereport;
                    worksheet.Cell(currentRow, 50).Value = claim.ScClaimrejectreason;
                    worksheet.Cell(currentRow, 51).Value = claim.ScClosedoutcome;
                    worksheet.Cell(currentRow, 52).Value = claim.ScDependentsequencenumber;
                    worksheet.Cell(currentRow, 53).Value = claim.ScDuplicate;
                    worksheet.Cell(currentRow, 54).Value = claim.ScIdrstatus;
                    worksheet.Cell(currentRow, 55).Value = claim.ScIsaccidentclaim;
                    worksheet.Cell(currentRow, 56).Value = claim.ScLegacyclaimno;
                    worksheet.Cell(currentRow, 57).Value = claim.ScLosscause;
                    worksheet.Cell(currentRow, 58).Value = claim.ScPolicybrand;
                    worksheet.Cell(currentRow, 59).Value = claim.ScSignificantinjurydate;
                    worksheet.Cell(currentRow, 60).Value = claim.ScWpreasoncode;
                    worksheet.Cell(currentRow, 61).Value = claim.Segment;
                    worksheet.Cell(currentRow, 62).Value = claim.Showmedicalfirstinfo;
                    worksheet.Cell(currentRow, 63).Value = claim.Siescalatesiu;
                    worksheet.Cell(currentRow, 64).Value = claim.Siscore;
                    worksheet.Cell(currentRow, 65).Value = claim.Siustatus;
                    worksheet.Cell(currentRow, 66).Value = claim.State;
                    worksheet.Cell(currentRow, 67).Value = claim.Strategy;
                    worksheet.Cell(currentRow, 68).Value = claim.Supplementalworkloadweight;
                    worksheet.Cell(currentRow, 69).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 70).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 71).Value = claim.Validationlevel;
                    worksheet.Cell(currentRow, 72).Value = claim.Workloadweight;
                }

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetClaim(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetClaim(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Claim");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Claim";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignedbyuserid"; worksheet.Cell(currentRow, 2).Value = claim.Assignedbyuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignedgroupid"; worksheet.Cell(currentRow, 2).Value = claim.Assignedgroupid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assigneduserid"; worksheet.Cell(currentRow, 2).Value = claim.Assigneduserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignmentdate"; worksheet.Cell(currentRow, 2).Value = claim.Assignmentdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignmentstatus"; worksheet.Cell(currentRow, 2).Value = claim.Assignmentstatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimantdenormid"; worksheet.Cell(currentRow, 2).Value = claim.Claimantdenormid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimnumber"; worksheet.Cell(currentRow, 2).Value = claim.Claimnumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimtier"; worksheet.Cell(currentRow, 2).Value = claim.Claimtier;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Closedate"; worksheet.Cell(currentRow, 2).Value = claim.Closedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Currency"; worksheet.Cell(currentRow, 2).Value = claim.Currency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Donotdestroy"; worksheet.Cell(currentRow, 2).Value = claim.Donotdestroy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Flagged"; worksheet.Cell(currentRow, 2).Value = claim.Flagged;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Flaggeddate"; worksheet.Cell(currentRow, 2).Value = claim.Flaggeddate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Flaggedreason"; worksheet.Cell(currentRow, 2).Value = claim.Flaggedreason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Incidentreport"; worksheet.Cell(currentRow, 2).Value = claim.Incidentreport;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Insureddenormid"; worksheet.Cell(currentRow, 2).Value = claim.Insureddenormid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Insuredpremises"; worksheet.Cell(currentRow, 2).Value = claim.Insuredpremises;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Isoenabled"; worksheet.Cell(currentRow, 2).Value = claim.Isoenabled;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Isostatus"; worksheet.Cell(currentRow, 2).Value = claim.Isostatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lobcode"; worksheet.Cell(currentRow, 2).Value = claim.Lobcode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lockingcolumn"; worksheet.Cell(currentRow, 2).Value = claim.Lockingcolumn;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Losscause"; worksheet.Cell(currentRow, 2).Value = claim.Losscause;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lossdate"; worksheet.Cell(currentRow, 2).Value = claim.Lossdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Losslocationid"; worksheet.Cell(currentRow, 2).Value = claim.Losslocationid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Losstype"; worksheet.Cell(currentRow, 2).Value = claim.Losstype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Maincontacttype"; worksheet.Cell(currentRow, 2).Value = claim.Maincontacttype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Permissionrequired"; worksheet.Cell(currentRow, 2).Value = claim.Permissionrequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Policyid"; worksheet.Cell(currentRow, 2).Value = claim.Policyid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Preexdisblty"; worksheet.Cell(currentRow, 2).Value = claim.Preexdisblty;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previousgroupid"; worksheet.Cell(currentRow, 2).Value = claim.Previousgroupid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previoususerid"; worksheet.Cell(currentRow, 2).Value = claim.Previoususerid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reopendate"; worksheet.Cell(currentRow, 2).Value = claim.Reopendate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reopenedreason"; worksheet.Cell(currentRow, 2).Value = claim.Reopenedreason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reportedbytype"; worksheet.Cell(currentRow, 2).Value = claim.Reportedbytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reporteddate"; worksheet.Cell(currentRow, 2).Value = claim.Reporteddate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAlternateclaimnumber1"; worksheet.Cell(currentRow, 2).Value = claim.ScAlternateclaimnumber1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimauto"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimauto;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimdecision"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimdecision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimdecisioncomments"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimdecisioncomments;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimeventquestions"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimeventquestions;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimproctype"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimproctype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimreconcilereport"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimreconcilereport;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimrejectreason"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimrejectreason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClosedoutcome"; worksheet.Cell(currentRow, 2).Value = claim.ScClosedoutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDependentsequencenumber"; worksheet.Cell(currentRow, 2).Value = claim.ScDependentsequencenumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDuplicate"; worksheet.Cell(currentRow, 2).Value = claim.ScDuplicate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScIdrstatus"; worksheet.Cell(currentRow, 2).Value = claim.ScIdrstatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScIsaccidentclaim"; worksheet.Cell(currentRow, 2).Value = claim.ScIsaccidentclaim;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScLegacyclaimno"; worksheet.Cell(currentRow, 2).Value = claim.ScLegacyclaimno;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScLosscause"; worksheet.Cell(currentRow, 2).Value = claim.ScLosscause;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPolicybrand"; worksheet.Cell(currentRow, 2).Value = claim.ScPolicybrand;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScSignificantinjurydate"; worksheet.Cell(currentRow, 2).Value = claim.ScSignificantinjurydate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScWpreasoncode"; worksheet.Cell(currentRow, 2).Value = claim.ScWpreasoncode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Segment"; worksheet.Cell(currentRow, 2).Value = claim.Segment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Showmedicalfirstinfo"; worksheet.Cell(currentRow, 2).Value = claim.Showmedicalfirstinfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Siescalatesiu"; worksheet.Cell(currentRow, 2).Value = claim.Siescalatesiu;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Siscore"; worksheet.Cell(currentRow, 2).Value = claim.Siscore;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Siustatus"; worksheet.Cell(currentRow, 2).Value = claim.Siustatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Strategy"; worksheet.Cell(currentRow, 2).Value = claim.Strategy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Supplementalworkloadweight"; worksheet.Cell(currentRow, 2).Value = claim.Supplementalworkloadweight;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Validationlevel"; worksheet.Cell(currentRow, 2).Value = claim.Validationlevel;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Workloadweight"; worksheet.Cell(currentRow, 2).Value = claim.Workloadweight;

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
