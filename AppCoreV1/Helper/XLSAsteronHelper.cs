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

        public async Task<byte[]> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchPolicy(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Policy");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Policy";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Accountnumber";
                worksheet.Cell(currentRow, 3).Value = "Beanversion";
                worksheet.Cell(currentRow, 4).Value = "Cancellationdate";
                worksheet.Cell(currentRow, 5).Value = "Createtime";
                worksheet.Cell(currentRow, 6).Value = "Createuserid";
                worksheet.Cell(currentRow, 7).Value = "Currency";
                worksheet.Cell(currentRow, 8).Value = "Effectivedate";
                worksheet.Cell(currentRow, 9).Value = "Expirationdate";
                worksheet.Cell(currentRow, 10).Value = "Foreigncoverage";
                worksheet.Cell(currentRow, 11).Value = "Origeffectivedate";
                worksheet.Cell(currentRow, 12).Value = "Otherinsurance";
                worksheet.Cell(currentRow, 13).Value = "Policynumber";
                worksheet.Cell(currentRow, 14).Value = "Policytype";
                worksheet.Cell(currentRow, 15).Value = "Producercode";
                worksheet.Cell(currentRow, 16).Value = "Publicid";
                worksheet.Cell(currentRow, 17).Value = "Retired";
                worksheet.Cell(currentRow, 18).Value = "Retroactivedate";
                worksheet.Cell(currentRow, 19).Value = "Returntoworkprgm";
                worksheet.Cell(currentRow, 20).Value = "ScBrand";
                worksheet.Cell(currentRow, 21).Value = "ScGstexempt";
                worksheet.Cell(currentRow, 22).Value = "ScGstregistered";
                worksheet.Cell(currentRow, 23).Value = "ScIntermedtype";
                worksheet.Cell(currentRow, 24).Value = "ScStampdutyexempt";
                worksheet.Cell(currentRow, 25).Value = "ScUnderwritingcompany";
                worksheet.Cell(currentRow, 26).Value = "Status";
                worksheet.Cell(currentRow, 27).Value = "Totalproperties";
                worksheet.Cell(currentRow, 28).Value = "Totalvehicles";
                worksheet.Cell(currentRow, 29).Value = "Updatetime";
                worksheet.Cell(currentRow, 30).Value = "Updateuserid";
                worksheet.Cell(currentRow, 31).Value = "Validationlevel";
                worksheet.Cell(currentRow, 32).Value = "Verified";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Accountnumber;
                    worksheet.Cell(currentRow, 3).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 4).Value = claim.Cancellationdate;
                    worksheet.Cell(currentRow, 5).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 6).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 7).Value = claim.Currency;
                    worksheet.Cell(currentRow, 8).Value = claim.Effectivedate;
                    worksheet.Cell(currentRow, 9).Value = claim.Expirationdate;
                    worksheet.Cell(currentRow, 10).Value = claim.Foreigncoverage;
                    worksheet.Cell(currentRow, 11).Value = claim.Origeffectivedate;
                    worksheet.Cell(currentRow, 12).Value = claim.Otherinsurance;
                    worksheet.Cell(currentRow, 13).Value = claim.Policynumber;
                    worksheet.Cell(currentRow, 14).Value = claim.Policytype;
                    worksheet.Cell(currentRow, 15).Value = claim.Producercode;
                    worksheet.Cell(currentRow, 16).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 17).Value = claim.Retired;
                    worksheet.Cell(currentRow, 18).Value = claim.Retroactivedate;
                    worksheet.Cell(currentRow, 19).Value = claim.Returntoworkprgm;
                    worksheet.Cell(currentRow, 20).Value = claim.ScBrand;
                    worksheet.Cell(currentRow, 21).Value = claim.ScGstexempt;
                    worksheet.Cell(currentRow, 22).Value = claim.ScGstregistered;
                    worksheet.Cell(currentRow, 23).Value = claim.ScIntermedtype;
                    worksheet.Cell(currentRow, 24).Value = claim.ScStampdutyexempt;
                    worksheet.Cell(currentRow, 25).Value = claim.ScUnderwritingcompany;
                    worksheet.Cell(currentRow, 26).Value = claim.Status;
                    worksheet.Cell(currentRow, 27).Value = claim.Totalproperties;
                    worksheet.Cell(currentRow, 28).Value = claim.Totalvehicles;
                    worksheet.Cell(currentRow, 29).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 30).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 31).Value = claim.Validationlevel;
                    worksheet.Cell(currentRow, 32).Value = claim.Verified;
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

        public async Task<byte[]> GetPolicy(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetPolicy(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Policy");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Policy";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accountnumber"; worksheet.Cell(currentRow, 2).Value = claim.Accountnumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Cancellationdate"; worksheet.Cell(currentRow, 2).Value = claim.Cancellationdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Currency"; worksheet.Cell(currentRow, 2).Value = claim.Currency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Effectivedate"; worksheet.Cell(currentRow, 2).Value = claim.Effectivedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Expirationdate"; worksheet.Cell(currentRow, 2).Value = claim.Expirationdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Foreigncoverage"; worksheet.Cell(currentRow, 2).Value = claim.Foreigncoverage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Origeffectivedate"; worksheet.Cell(currentRow, 2).Value = claim.Origeffectivedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Otherinsurance"; worksheet.Cell(currentRow, 2).Value = claim.Otherinsurance;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Policynumber"; worksheet.Cell(currentRow, 2).Value = claim.Policynumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Policytype"; worksheet.Cell(currentRow, 2).Value = claim.Policytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Producercode"; worksheet.Cell(currentRow, 2).Value = claim.Producercode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retroactivedate"; worksheet.Cell(currentRow, 2).Value = claim.Retroactivedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Returntoworkprgm"; worksheet.Cell(currentRow, 2).Value = claim.Returntoworkprgm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBrand"; worksheet.Cell(currentRow, 2).Value = claim.ScBrand;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScGstexempt"; worksheet.Cell(currentRow, 2).Value = claim.ScGstexempt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScGstregistered"; worksheet.Cell(currentRow, 2).Value = claim.ScGstregistered;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScIntermedtype"; worksheet.Cell(currentRow, 2).Value = claim.ScIntermedtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScStampdutyexempt"; worksheet.Cell(currentRow, 2).Value = claim.ScStampdutyexempt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScUnderwritingcompany"; worksheet.Cell(currentRow, 2).Value = claim.ScUnderwritingcompany;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Totalproperties"; worksheet.Cell(currentRow, 2).Value = claim.Totalproperties;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Totalvehicles"; worksheet.Cell(currentRow, 2).Value = claim.Totalvehicles;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Validationlevel"; worksheet.Cell(currentRow, 2).Value = claim.Validationlevel;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Verified"; worksheet.Cell(currentRow, 2).Value = claim.Verified;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetNotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchNote(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Note");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Note";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Activityid";
                worksheet.Cell(currentRow, 3).Value = "Authorid";
                worksheet.Cell(currentRow, 4).Value = "Authoringdate";
                worksheet.Cell(currentRow, 5).Value = "Beanversion";
                worksheet.Cell(currentRow, 6).Value = "Body";
                worksheet.Cell(currentRow, 7).Value = "Claimcontactid";
                worksheet.Cell(currentRow, 8).Value = "Claimid";
                worksheet.Cell(currentRow, 9).Value = "Confidential";
                worksheet.Cell(currentRow, 10).Value = "Createtime";
                worksheet.Cell(currentRow, 11).Value = "Createuserid";
                worksheet.Cell(currentRow, 12).Value = "ExpcustomernoteExt";
                worksheet.Cell(currentRow, 13).Value = "Exposureid";
                worksheet.Cell(currentRow, 14).Value = "ExptocustselfserviceExt";
                worksheet.Cell(currentRow, 15).Value = "Language";
                worksheet.Cell(currentRow, 16).Value = "Matterid";
                worksheet.Cell(currentRow, 17).Value = "Publicid";
                worksheet.Cell(currentRow, 18).Value = "Retired";
                worksheet.Cell(currentRow, 19).Value = "ScIsmanualnote";
                worksheet.Cell(currentRow, 20).Value = "Securitytype";
                worksheet.Cell(currentRow, 21).Value = "Subject";
                worksheet.Cell(currentRow, 22).Value = "Topic";
                worksheet.Cell(currentRow, 23).Value = "Updatetime";
                worksheet.Cell(currentRow, 24).Value = "Updateuserid";
                worksheet.Cell(currentRow, 25).Value = "ClaimnumberRefOnly";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Activityid;
                    worksheet.Cell(currentRow, 3).Value = claim.Authorid;
                    worksheet.Cell(currentRow, 4).Value = claim.Authoringdate;
                    worksheet.Cell(currentRow, 5).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 6).Value = claim.Body;
                    worksheet.Cell(currentRow, 7).Value = claim.Claimcontactid;
                    worksheet.Cell(currentRow, 8).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 9).Value = claim.Confidential;
                    worksheet.Cell(currentRow, 10).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 11).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 12).Value = claim.ExpcustomernoteExt;
                    worksheet.Cell(currentRow, 13).Value = claim.Exposureid;
                    worksheet.Cell(currentRow, 14).Value = claim.ExptocustselfserviceExt;
                    worksheet.Cell(currentRow, 15).Value = claim.Language;
                    worksheet.Cell(currentRow, 16).Value = claim.Matterid;
                    worksheet.Cell(currentRow, 17).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 18).Value = claim.Retired;
                    worksheet.Cell(currentRow, 19).Value = claim.ScIsmanualnote;
                    worksheet.Cell(currentRow, 20).Value = claim.Securitytype;
                    worksheet.Cell(currentRow, 21).Value = claim.Subject;
                    worksheet.Cell(currentRow, 22).Value = claim.Topic;
                    worksheet.Cell(currentRow, 23).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 24).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 25).Value = claim.ClaimnumberRefOnly;
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

        public async Task<byte[]> GetNote(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetNote(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Note");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Note";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Activityid"; worksheet.Cell(currentRow, 2).Value = claim.Activityid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Authorid"; worksheet.Cell(currentRow, 2).Value = claim.Authorid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Authoringdate"; worksheet.Cell(currentRow, 2).Value = claim.Authoringdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Body"; worksheet.Cell(currentRow, 2).Value = claim.Body;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimcontactid"; worksheet.Cell(currentRow, 2).Value = claim.Claimcontactid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Confidential"; worksheet.Cell(currentRow, 2).Value = claim.Confidential;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpcustomernoteExt"; worksheet.Cell(currentRow, 2).Value = claim.ExpcustomernoteExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Exposureid"; worksheet.Cell(currentRow, 2).Value = claim.Exposureid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExptocustselfserviceExt"; worksheet.Cell(currentRow, 2).Value = claim.ExptocustselfserviceExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Language"; worksheet.Cell(currentRow, 2).Value = claim.Language;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Matterid"; worksheet.Cell(currentRow, 2).Value = claim.Matterid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScIsmanualnote"; worksheet.Cell(currentRow, 2).Value = claim.ScIsmanualnote;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Securitytype"; worksheet.Cell(currentRow, 2).Value = claim.Securitytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subject"; worksheet.Cell(currentRow, 2).Value = claim.Subject;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Topic"; worksheet.Cell(currentRow, 2).Value = claim.Topic;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimnumberRefOnly"; worksheet.Cell(currentRow, 2).Value = claim.ClaimnumberRefOnly;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchDocument(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Document");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Document";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Author";
                worksheet.Cell(currentRow, 3).Value = "Authordenorm";
                worksheet.Cell(currentRow, 4).Value = "Beanversion";
                worksheet.Cell(currentRow, 5).Value = "Claimcontactid";
                worksheet.Cell(currentRow, 6).Value = "Claimid";
                worksheet.Cell(currentRow, 7).Value = "Createtime";
                worksheet.Cell(currentRow, 8).Value = "Createuserid";
                worksheet.Cell(currentRow, 9).Value = "Datemodified";
                worksheet.Cell(currentRow, 10).Value = "Description";
                worksheet.Cell(currentRow, 11).Value = "Dms";
                worksheet.Cell(currentRow, 12).Value = "Docuid";
                worksheet.Cell(currentRow, 13).Value = "Documentidentifier";
                worksheet.Cell(currentRow, 14).Value = "Documentidentifierdenorm";
                worksheet.Cell(currentRow, 15).Value = "ExposetocustomerExt";
                worksheet.Cell(currentRow, 16).Value = "Exposureid";
                worksheet.Cell(currentRow, 17).Value = "Inbound";
                worksheet.Cell(currentRow, 18).Value = "Mimetype";
                worksheet.Cell(currentRow, 19).Value = "Name";
                worksheet.Cell(currentRow, 20).Value = "Namedenorm";
                worksheet.Cell(currentRow, 21).Value = "Obsolete";
                worksheet.Cell(currentRow, 22).Value = "Publicid";
                worksheet.Cell(currentRow, 23).Value = "Recipient";
                worksheet.Cell(currentRow, 24).Value = "Retired";
                worksheet.Cell(currentRow, 25).Value = "ScActivitystatus";
                worksheet.Cell(currentRow, 26).Value = "ScArchiveonly";
                worksheet.Cell(currentRow, 27).Value = "ScBatchid";
                worksheet.Cell(currentRow, 28).Value = "ScDisclosurestatus";
                worksheet.Cell(currentRow, 29).Value = "ScDocsource";
                worksheet.Cell(currentRow, 30).Value = "ScDocumentdate";
                worksheet.Cell(currentRow, 31).Value = "ScDocumentsize";
                worksheet.Cell(currentRow, 32).Value = "ScIsversion";
                worksheet.Cell(currentRow, 33).Value = "Securitytype";
                worksheet.Cell(currentRow, 34).Value = "Status";
                worksheet.Cell(currentRow, 35).Value = "Type";
                worksheet.Cell(currentRow, 36).Value = "Updatetime";
                worksheet.Cell(currentRow, 37).Value = "Updateuserid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Author;
                    worksheet.Cell(currentRow, 3).Value = claim.Authordenorm;
                    worksheet.Cell(currentRow, 4).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 5).Value = claim.Claimcontactid;
                    worksheet.Cell(currentRow, 6).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 7).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 8).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 9).Value = claim.Datemodified;
                    worksheet.Cell(currentRow, 10).Value = claim.Description;
                    worksheet.Cell(currentRow, 11).Value = claim.Dms;
                    worksheet.Cell(currentRow, 12).Value = claim.Docuid;
                    worksheet.Cell(currentRow, 13).Value = claim.Documentidentifier;
                    worksheet.Cell(currentRow, 14).Value = claim.Documentidentifierdenorm;
                    worksheet.Cell(currentRow, 15).Value = claim.ExposetocustomerExt;
                    worksheet.Cell(currentRow, 16).Value = claim.Exposureid;
                    worksheet.Cell(currentRow, 17).Value = claim.Inbound;
                    worksheet.Cell(currentRow, 18).Value = claim.Mimetype;
                    worksheet.Cell(currentRow, 19).Value = claim.Name;
                    worksheet.Cell(currentRow, 20).Value = claim.Namedenorm;
                    worksheet.Cell(currentRow, 21).Value = claim.Obsolete;
                    worksheet.Cell(currentRow, 22).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 23).Value = claim.Recipient;
                    worksheet.Cell(currentRow, 24).Value = claim.Retired;
                    worksheet.Cell(currentRow, 25).Value = claim.ScActivitystatus;
                    worksheet.Cell(currentRow, 26).Value = claim.ScArchiveonly;
                    worksheet.Cell(currentRow, 27).Value = claim.ScBatchid;
                    worksheet.Cell(currentRow, 28).Value = claim.ScDisclosurestatus;
                    worksheet.Cell(currentRow, 29).Value = claim.ScDocsource;
                    worksheet.Cell(currentRow, 30).Value = claim.ScDocumentdate;
                    worksheet.Cell(currentRow, 31).Value = claim.ScDocumentsize;
                    worksheet.Cell(currentRow, 32).Value = claim.ScIsversion;
                    worksheet.Cell(currentRow, 33).Value = claim.Securitytype;
                    worksheet.Cell(currentRow, 34).Value = claim.Status;
                    worksheet.Cell(currentRow, 35).Value = claim.Type;
                    worksheet.Cell(currentRow, 36).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 37).Value = claim.Updateuserid;
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

        public async Task<byte[]> GetDocument(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetDocument(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Document");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Document";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Author"; worksheet.Cell(currentRow, 2).Value = claim.Author;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Authordenorm"; worksheet.Cell(currentRow, 2).Value = claim.Authordenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimcontactid"; worksheet.Cell(currentRow, 2).Value = claim.Claimcontactid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Datemodified"; worksheet.Cell(currentRow, 2).Value = claim.Datemodified;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Dms"; worksheet.Cell(currentRow, 2).Value = claim.Dms;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Docuid"; worksheet.Cell(currentRow, 2).Value = claim.Docuid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Documentidentifier"; worksheet.Cell(currentRow, 2).Value = claim.Documentidentifier;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Documentidentifierdenorm"; worksheet.Cell(currentRow, 2).Value = claim.Documentidentifierdenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExposetocustomerExt"; worksheet.Cell(currentRow, 2).Value = claim.ExposetocustomerExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Exposureid"; worksheet.Cell(currentRow, 2).Value = claim.Exposureid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Inbound"; worksheet.Cell(currentRow, 2).Value = claim.Inbound;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mimetype"; worksheet.Cell(currentRow, 2).Value = claim.Mimetype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Namedenorm"; worksheet.Cell(currentRow, 2).Value = claim.Namedenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Obsolete"; worksheet.Cell(currentRow, 2).Value = claim.Obsolete;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Recipient"; worksheet.Cell(currentRow, 2).Value = claim.Recipient;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScActivitystatus"; worksheet.Cell(currentRow, 2).Value = claim.ScActivitystatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScArchiveonly"; worksheet.Cell(currentRow, 2).Value = claim.ScArchiveonly;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBatchid"; worksheet.Cell(currentRow, 2).Value = claim.ScBatchid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDisclosurestatus"; worksheet.Cell(currentRow, 2).Value = claim.ScDisclosurestatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDocsource"; worksheet.Cell(currentRow, 2).Value = claim.ScDocsource;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDocumentdate"; worksheet.Cell(currentRow, 2).Value = claim.ScDocumentdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDocumentsize"; worksheet.Cell(currentRow, 2).Value = claim.ScDocumentsize;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScIsversion"; worksheet.Cell(currentRow, 2).Value = claim.ScIsversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Securitytype"; worksheet.Cell(currentRow, 2).Value = claim.Securitytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetActivitys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchActivity(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Activity");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Activity";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Activityclass";
                worksheet.Cell(currentRow, 3).Value = "Activitypatternid";
                worksheet.Cell(currentRow, 4).Value = "Assignedbyuserid";
                worksheet.Cell(currentRow, 5).Value = "Assignedgroupid";
                worksheet.Cell(currentRow, 6).Value = "Assignedqueueid";
                worksheet.Cell(currentRow, 7).Value = "Assigneduserid";
                worksheet.Cell(currentRow, 8).Value = "Assignmentdate";
                worksheet.Cell(currentRow, 9).Value = "Assignmentstatus";
                worksheet.Cell(currentRow, 10).Value = "Autogenerated";
                worksheet.Cell(currentRow, 11).Value = "Beanversion";
                worksheet.Cell(currentRow, 12).Value = "Claimcontactid";
                worksheet.Cell(currentRow, 13).Value = "Claimid";
                worksheet.Cell(currentRow, 14).Value = "Closedate";
                worksheet.Cell(currentRow, 15).Value = "Closeuserid";
                worksheet.Cell(currentRow, 16).Value = "ComplaintExtid";
                worksheet.Cell(currentRow, 17).Value = "Createtime";
                worksheet.Cell(currentRow, 18).Value = "Createuserid";
                worksheet.Cell(currentRow, 19).Value = "Description";
                worksheet.Cell(currentRow, 20).Value = "Escalated";
                worksheet.Cell(currentRow, 21).Value = "Escalationdate";
                worksheet.Cell(currentRow, 22).Value = "Exposureid";
                worksheet.Cell(currentRow, 23).Value = "Externallyowned";
                worksheet.Cell(currentRow, 24).Value = "Externalownerccid";
                worksheet.Cell(currentRow, 25).Value = "Generatedsource";
                worksheet.Cell(currentRow, 26).Value = "Importance";
                worksheet.Cell(currentRow, 27).Value = "InitialescalationdateExt";
                worksheet.Cell(currentRow, 28).Value = "InitialtargetdateExt";
                worksheet.Cell(currentRow, 29).Value = "Lastvieweddate";
                worksheet.Cell(currentRow, 30).Value = "Mandatory";
                worksheet.Cell(currentRow, 31).Value = "Previousgroupid";
                worksheet.Cell(currentRow, 32).Value = "Previousqueueid";
                worksheet.Cell(currentRow, 33).Value = "Previoususerid";
                worksheet.Cell(currentRow, 34).Value = "Priority";
                worksheet.Cell(currentRow, 35).Value = "Publicid";
                worksheet.Cell(currentRow, 36).Value = "Recurring";
                worksheet.Cell(currentRow, 37).Value = "Retired";
                worksheet.Cell(currentRow, 38).Value = "ScRejectreason";
                worksheet.Cell(currentRow, 39).Value = "Status";
                worksheet.Cell(currentRow, 40).Value = "Subject";
                worksheet.Cell(currentRow, 41).Value = "Subtype";
                worksheet.Cell(currentRow, 42).Value = "Targetdate";
                worksheet.Cell(currentRow, 43).Value = "Type";
                worksheet.Cell(currentRow, 44).Value = "Updatetime";
                worksheet.Cell(currentRow, 45).Value = "Updateuserid";
                worksheet.Cell(currentRow, 46).Value = "Validationlevel";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Activityclass;
                    worksheet.Cell(currentRow, 3).Value = claim.Activitypatternid;
                    worksheet.Cell(currentRow, 4).Value = claim.Assignedbyuserid;
                    worksheet.Cell(currentRow, 5).Value = claim.Assignedgroupid;
                    worksheet.Cell(currentRow, 6).Value = claim.Assignedqueueid;
                    worksheet.Cell(currentRow, 7).Value = claim.Assigneduserid;
                    worksheet.Cell(currentRow, 8).Value = claim.Assignmentdate;
                    worksheet.Cell(currentRow, 9).Value = claim.Assignmentstatus;
                    worksheet.Cell(currentRow, 10).Value = claim.Autogenerated;
                    worksheet.Cell(currentRow, 11).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 12).Value = claim.Claimcontactid;
                    worksheet.Cell(currentRow, 13).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 14).Value = claim.Closedate;
                    worksheet.Cell(currentRow, 15).Value = claim.Closeuserid;
                    worksheet.Cell(currentRow, 16).Value = claim.ComplaintExtid;
                    worksheet.Cell(currentRow, 17).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 18).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 19).Value = claim.Description;
                    worksheet.Cell(currentRow, 20).Value = claim.Escalated;
                    worksheet.Cell(currentRow, 21).Value = claim.Escalationdate;
                    worksheet.Cell(currentRow, 22).Value = claim.Exposureid;
                    worksheet.Cell(currentRow, 23).Value = claim.Externallyowned;
                    worksheet.Cell(currentRow, 24).Value = claim.Externalownerccid;
                    worksheet.Cell(currentRow, 25).Value = claim.Generatedsource;
                    worksheet.Cell(currentRow, 26).Value = claim.Importance;
                    worksheet.Cell(currentRow, 27).Value = claim.InitialescalationdateExt;
                    worksheet.Cell(currentRow, 28).Value = claim.InitialtargetdateExt;
                    worksheet.Cell(currentRow, 29).Value = claim.Lastvieweddate;
                    worksheet.Cell(currentRow, 30).Value = claim.Mandatory;
                    worksheet.Cell(currentRow, 31).Value = claim.Previousgroupid;
                    worksheet.Cell(currentRow, 32).Value = claim.Previousqueueid;
                    worksheet.Cell(currentRow, 33).Value = claim.Previoususerid;
                    worksheet.Cell(currentRow, 34).Value = claim.Priority;
                    worksheet.Cell(currentRow, 35).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 36).Value = claim.Recurring;
                    worksheet.Cell(currentRow, 37).Value = claim.Retired;
                    worksheet.Cell(currentRow, 38).Value = claim.ScRejectreason;
                    worksheet.Cell(currentRow, 39).Value = claim.Status;
                    worksheet.Cell(currentRow, 40).Value = claim.Subject;
                    worksheet.Cell(currentRow, 41).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 42).Value = claim.Targetdate;
                    worksheet.Cell(currentRow, 43).Value = claim.Type;
                    worksheet.Cell(currentRow, 44).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 45).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 46).Value = claim.Validationlevel;
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

        public async Task<byte[]> GetActivity(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetActivity(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Activity");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Activity";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Activityclass"; worksheet.Cell(currentRow, 2).Value = claim.Activityclass;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Activitypatternid"; worksheet.Cell(currentRow, 2).Value = claim.Activitypatternid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignedbyuserid"; worksheet.Cell(currentRow, 2).Value = claim.Assignedbyuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignedgroupid"; worksheet.Cell(currentRow, 2).Value = claim.Assignedgroupid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignedqueueid"; worksheet.Cell(currentRow, 2).Value = claim.Assignedqueueid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assigneduserid"; worksheet.Cell(currentRow, 2).Value = claim.Assigneduserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignmentdate"; worksheet.Cell(currentRow, 2).Value = claim.Assignmentdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignmentstatus"; worksheet.Cell(currentRow, 2).Value = claim.Assignmentstatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Autogenerated"; worksheet.Cell(currentRow, 2).Value = claim.Autogenerated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimcontactid"; worksheet.Cell(currentRow, 2).Value = claim.Claimcontactid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Closedate"; worksheet.Cell(currentRow, 2).Value = claim.Closedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Closeuserid"; worksheet.Cell(currentRow, 2).Value = claim.Closeuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintExtid"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintExtid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Escalated"; worksheet.Cell(currentRow, 2).Value = claim.Escalated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Escalationdate"; worksheet.Cell(currentRow, 2).Value = claim.Escalationdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Exposureid"; worksheet.Cell(currentRow, 2).Value = claim.Exposureid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Externallyowned"; worksheet.Cell(currentRow, 2).Value = claim.Externallyowned;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Externalownerccid"; worksheet.Cell(currentRow, 2).Value = claim.Externalownerccid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Generatedsource"; worksheet.Cell(currentRow, 2).Value = claim.Generatedsource;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Importance"; worksheet.Cell(currentRow, 2).Value = claim.Importance;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialescalationdateExt"; worksheet.Cell(currentRow, 2).Value = claim.InitialescalationdateExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialtargetdateExt"; worksheet.Cell(currentRow, 2).Value = claim.InitialtargetdateExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lastvieweddate"; worksheet.Cell(currentRow, 2).Value = claim.Lastvieweddate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mandatory"; worksheet.Cell(currentRow, 2).Value = claim.Mandatory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previousgroupid"; worksheet.Cell(currentRow, 2).Value = claim.Previousgroupid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previousqueueid"; worksheet.Cell(currentRow, 2).Value = claim.Previousqueueid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previoususerid"; worksheet.Cell(currentRow, 2).Value = claim.Previoususerid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Priority"; worksheet.Cell(currentRow, 2).Value = claim.Priority;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Recurring"; worksheet.Cell(currentRow, 2).Value = claim.Recurring;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScRejectreason"; worksheet.Cell(currentRow, 2).Value = claim.ScRejectreason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subject"; worksheet.Cell(currentRow, 2).Value = claim.Subject;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Targetdate"; worksheet.Cell(currentRow, 2).Value = claim.Targetdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Validationlevel"; worksheet.Cell(currentRow, 2).Value = claim.Validationlevel;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetHistorys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchHistory(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("History");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub History";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Beanversion";
                worksheet.Cell(currentRow, 3).Value = "Claimid";
                worksheet.Cell(currentRow, 4).Value = "Customtype";
                worksheet.Cell(currentRow, 5).Value = "Description";
                worksheet.Cell(currentRow, 6).Value = "Eventtimestamp";
                worksheet.Cell(currentRow, 7).Value = "Exposureid";
                worksheet.Cell(currentRow, 8).Value = "Matterid";
                worksheet.Cell(currentRow, 9).Value = "Publicid";
                worksheet.Cell(currentRow, 10).Value = "Subtype";
                worksheet.Cell(currentRow, 11).Value = "Type";
                worksheet.Cell(currentRow, 12).Value = "Userid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 3).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 4).Value = claim.Customtype;
                    worksheet.Cell(currentRow, 5).Value = claim.Description;
                    worksheet.Cell(currentRow, 6).Value = claim.Eventtimestamp;
                    worksheet.Cell(currentRow, 7).Value = claim.Exposureid;
                    worksheet.Cell(currentRow, 8).Value = claim.Matterid;
                    worksheet.Cell(currentRow, 9).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 10).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 11).Value = claim.Type;
                    worksheet.Cell(currentRow, 12).Value = claim.Userid;
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

        public async Task<byte[]> GetHistory(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetHistory(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("History");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: History";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Customtype"; worksheet.Cell(currentRow, 2).Value = claim.Customtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Eventtimestamp"; worksheet.Cell(currentRow, 2).Value = claim.Eventtimestamp;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Exposureid"; worksheet.Cell(currentRow, 2).Value = claim.Exposureid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Matterid"; worksheet.Cell(currentRow, 2).Value = claim.Matterid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Userid"; worksheet.Cell(currentRow, 2).Value = claim.Userid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchContact(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Contact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Contact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Addressbookuid";
                worksheet.Cell(currentRow, 3).Value = "Afterhours";
                worksheet.Cell(currentRow, 4).Value = "Attorneylicense";
                worksheet.Cell(currentRow, 5).Value = "AutopaymentallowedExt";
                worksheet.Cell(currentRow, 6).Value = "Autosync";
                worksheet.Cell(currentRow, 7).Value = "Beanversion";
                worksheet.Cell(currentRow, 8).Value = "Canmanageprojects";
                worksheet.Cell(currentRow, 9).Value = "Cellphone";
                worksheet.Cell(currentRow, 10).Value = "Claimantidtype";
                worksheet.Cell(currentRow, 11).Value = "CommentsExt";
                worksheet.Cell(currentRow, 12).Value = "Createtime";
                worksheet.Cell(currentRow, 13).Value = "Createuserid";
                worksheet.Cell(currentRow, 14).Value = "Dateofbirth";
                worksheet.Cell(currentRow, 15).Value = "DayperiodExt";
                worksheet.Cell(currentRow, 16).Value = "Donotdestroy";
                worksheet.Cell(currentRow, 17).Value = "Emailaddress1";
                worksheet.Cell(currentRow, 18).Value = "Emailaddress2";
                worksheet.Cell(currentRow, 19).Value = "Employeenumber";
                worksheet.Cell(currentRow, 20).Value = "Faxphone";
                worksheet.Cell(currentRow, 21).Value = "Firstname";
                worksheet.Cell(currentRow, 22).Value = "Firstnamedenorm";
                worksheet.Cell(currentRow, 23).Value = "Formername";
                worksheet.Cell(currentRow, 24).Value = "Gender";
                worksheet.Cell(currentRow, 25).Value = "Homephone";
                worksheet.Cell(currentRow, 26).Value = "IssensitiveExt";
                worksheet.Cell(currentRow, 27).Value = "Lastname";
                worksheet.Cell(currentRow, 28).Value = "Lastnamedenorm";
                worksheet.Cell(currentRow, 29).Value = "Loadrelatedcontacts";
                worksheet.Cell(currentRow, 30).Value = "LocationrepairtypeExt";
                worksheet.Cell(currentRow, 31).Value = "Makesafe";
                worksheet.Cell(currentRow, 32).Value = "Middlename";
                worksheet.Cell(currentRow, 33).Value = "Name";
                worksheet.Cell(currentRow, 34).Value = "Namedenorm";
                worksheet.Cell(currentRow, 35).Value = "Obfuscatedinternal";
                worksheet.Cell(currentRow, 36).Value = "Pendinglinkmessage";
                worksheet.Cell(currentRow, 37).Value = "Postaladdress";
                worksheet.Cell(currentRow, 38).Value = "Preferred";
                worksheet.Cell(currentRow, 39).Value = "Prefix";
                worksheet.Cell(currentRow, 40).Value = "Primaryaddressid";
                worksheet.Cell(currentRow, 41).Value = "Primaryphone";
                worksheet.Cell(currentRow, 42).Value = "Publicid";
                worksheet.Cell(currentRow, 43).Value = "RepairerrelationshipExt";
                worksheet.Cell(currentRow, 44).Value = "Retired";
                worksheet.Cell(currentRow, 45).Value = "ScAcceptsawpclaims";
                worksheet.Cell(currentRow, 46).Value = "ScAcceptsdriveable";
                worksheet.Cell(currentRow, 47).Value = "ScAcceptsnondriveable";
                worksheet.Cell(currentRow, 48).Value = "ScAcceptssms";
                worksheet.Cell(currentRow, 49).Value = "ScAcceptstpafclaims";
                worksheet.Cell(currentRow, 50).Value = "ScAcceptstpvehicles";
                worksheet.Cell(currentRow, 51).Value = "ScAcceptsume";
                worksheet.Cell(currentRow, 52).Value = "ScAccidentsequencekey";
                worksheet.Cell(currentRow, 53).Value = "ScAccountname";
                worksheet.Cell(currentRow, 54).Value = "ScAccountnumber";
                worksheet.Cell(currentRow, 55).Value = "ScActivecontact";
                worksheet.Cell(currentRow, 56).Value = "ScActivepnetaccount";
                worksheet.Cell(currentRow, 57).Value = "ScAuthparty";
                worksheet.Cell(currentRow, 58).Value = "ScB2bEnabled";
                worksheet.Cell(currentRow, 59).Value = "ScBankname";
                worksheet.Cell(currentRow, 60).Value = "ScBsb";
                worksheet.Cell(currentRow, 61).Value = "ScBulkpayments";
                worksheet.Cell(currentRow, 62).Value = "ScBusinesstype";
                worksheet.Cell(currentRow, 63).Value = "ScCellphone";
                worksheet.Cell(currentRow, 64).Value = "ScCentralbillservice";
                worksheet.Cell(currentRow, 65).Value = "ScConsolvendor";
                worksheet.Cell(currentRow, 66).Value = "ScContactpaymentaccountseq";
                worksheet.Cell(currentRow, 67).Value = "ScCorrespondencedelivery";
                worksheet.Cell(currentRow, 68).Value = "ScDeceased";
                worksheet.Cell(currentRow, 69).Value = "ScFormerfirstname";
                worksheet.Cell(currentRow, 70).Value = "ScFormermiddlename";
                worksheet.Cell(currentRow, 71).Value = "ScGstregistered";
                worksheet.Cell(currentRow, 72).Value = "ScHospitalname";
                worksheet.Cell(currentRow, 73).Value = "ScInterpreterreqd";
                worksheet.Cell(currentRow, 74).Value = "ScLanguage";
                worksheet.Cell(currentRow, 75).Value = "ScLanguagepref";
                worksheet.Cell(currentRow, 76).Value = "ScLocationtype";
                worksheet.Cell(currentRow, 77).Value = "ScNodependantadults";
                worksheet.Cell(currentRow, 78).Value = "ScNodependantchildren";
                worksheet.Cell(currentRow, 79).Value = "ScOpenfriday";
                worksheet.Cell(currentRow, 80).Value = "ScOpenmonday";
                worksheet.Cell(currentRow, 81).Value = "ScOpensaturday";
                worksheet.Cell(currentRow, 82).Value = "ScOpensunday";
                worksheet.Cell(currentRow, 83).Value = "ScOpenthursday";
                worksheet.Cell(currentRow, 84).Value = "ScOpentuesday";
                worksheet.Cell(currentRow, 85).Value = "ScOpenwednesday";
                worksheet.Cell(currentRow, 86).Value = "ScOtherphone";
                worksheet.Cell(currentRow, 87).Value = "ScOtherphonedesc";
                worksheet.Cell(currentRow, 88).Value = "ScPayable";
                worksheet.Cell(currentRow, 89).Value = "ScPaymentmethod";
                worksheet.Cell(currentRow, 90).Value = "ScPaymentname";
                worksheet.Cell(currentRow, 91).Value = "ScPaymentserviceackdate";
                worksheet.Cell(currentRow, 92).Value = "ScPaymentservicecorrid";
                worksheet.Cell(currentRow, 93).Value = "ScPaymentservicevendorid";
                worksheet.Cell(currentRow, 94).Value = "ScPaymentterms";
                worksheet.Cell(currentRow, 95).Value = "ScPaystartdate";
                worksheet.Cell(currentRow, 96).Value = "ScPolicytype";
                worksheet.Cell(currentRow, 97).Value = "ScPortfoliocode";
                worksheet.Cell(currentRow, 98).Value = "ScProcesstypeexists";
                worksheet.Cell(currentRow, 99).Value = "ScRecommended";
                worksheet.Cell(currentRow, 100).Value = "ScRemittancedelivery";
                worksheet.Cell(currentRow, 101).Value = "ScRemittancenotificationemail";
                worksheet.Cell(currentRow, 102).Value = "ScSamenotificationemail";
                worksheet.Cell(currentRow, 103).Value = "ScSamenotificationsms";
                worksheet.Cell(currentRow, 104).Value = "ScServiceablepostcodenational";
                worksheet.Cell(currentRow, 105).Value = "ScStaffnumber";
                worksheet.Cell(currentRow, 106).Value = "ScSuspended";
                worksheet.Cell(currentRow, 107).Value = "ScTradingname";
                worksheet.Cell(currentRow, 108).Value = "ScVendorengagementtype";
                worksheet.Cell(currentRow, 109).Value = "ScVendortype";
                worksheet.Cell(currentRow, 110).Value = "Subtype";
                worksheet.Cell(currentRow, 111).Value = "Suffix";
                worksheet.Cell(currentRow, 112).Value = "Taxid";
                worksheet.Cell(currentRow, 113).Value = "Taxstatus";
                worksheet.Cell(currentRow, 114).Value = "Updatetime";
                worksheet.Cell(currentRow, 115).Value = "Updateuserid";
                worksheet.Cell(currentRow, 116).Value = "Validationlevel";
                worksheet.Cell(currentRow, 117).Value = "Vendortype";
                worksheet.Cell(currentRow, 118).Value = "W9received";
                worksheet.Cell(currentRow, 119).Value = "WatchlistproviderExt";
                worksheet.Cell(currentRow, 120).Value = "Workphone";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Addressbookuid;
                    worksheet.Cell(currentRow, 3).Value = claim.Afterhours;
                    worksheet.Cell(currentRow, 4).Value = claim.Attorneylicense;
                    worksheet.Cell(currentRow, 5).Value = claim.AutopaymentallowedExt;
                    worksheet.Cell(currentRow, 6).Value = claim.Autosync;
                    worksheet.Cell(currentRow, 7).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 8).Value = claim.Canmanageprojects;
                    worksheet.Cell(currentRow, 9).Value = claim.Cellphone;
                    worksheet.Cell(currentRow, 10).Value = claim.Claimantidtype;
                    worksheet.Cell(currentRow, 11).Value = claim.CommentsExt;
                    worksheet.Cell(currentRow, 12).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 13).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 14).Value = claim.Dateofbirth;
                    worksheet.Cell(currentRow, 15).Value = claim.DayperiodExt;
                    worksheet.Cell(currentRow, 16).Value = claim.Donotdestroy;
                    worksheet.Cell(currentRow, 17).Value = claim.Emailaddress1;
                    worksheet.Cell(currentRow, 18).Value = claim.Emailaddress2;
                    worksheet.Cell(currentRow, 19).Value = claim.Employeenumber;
                    worksheet.Cell(currentRow, 20).Value = claim.Faxphone;
                    worksheet.Cell(currentRow, 21).Value = claim.Firstname;
                    worksheet.Cell(currentRow, 22).Value = claim.Firstnamedenorm;
                    worksheet.Cell(currentRow, 23).Value = claim.Formername;
                    worksheet.Cell(currentRow, 24).Value = claim.Gender;
                    worksheet.Cell(currentRow, 25).Value = claim.Homephone;
                    worksheet.Cell(currentRow, 26).Value = claim.IssensitiveExt;
                    worksheet.Cell(currentRow, 27).Value = claim.Lastname;
                    worksheet.Cell(currentRow, 28).Value = claim.Lastnamedenorm;
                    worksheet.Cell(currentRow, 29).Value = claim.Loadrelatedcontacts;
                    worksheet.Cell(currentRow, 30).Value = claim.LocationrepairtypeExt;
                    worksheet.Cell(currentRow, 31).Value = claim.Makesafe;
                    worksheet.Cell(currentRow, 32).Value = claim.Middlename;
                    worksheet.Cell(currentRow, 33).Value = claim.Name;
                    worksheet.Cell(currentRow, 34).Value = claim.Namedenorm;
                    worksheet.Cell(currentRow, 35).Value = claim.Obfuscatedinternal;
                    worksheet.Cell(currentRow, 36).Value = claim.Pendinglinkmessage;
                    worksheet.Cell(currentRow, 37).Value = claim.Postaladdress;
                    worksheet.Cell(currentRow, 38).Value = claim.Preferred;
                    worksheet.Cell(currentRow, 39).Value = claim.Prefix;
                    worksheet.Cell(currentRow, 40).Value = claim.Primaryaddressid;
                    worksheet.Cell(currentRow, 41).Value = claim.Primaryphone;
                    worksheet.Cell(currentRow, 42).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 43).Value = claim.RepairerrelationshipExt;
                    worksheet.Cell(currentRow, 44).Value = claim.Retired;
                    worksheet.Cell(currentRow, 45).Value = claim.ScAcceptsawpclaims;
                    worksheet.Cell(currentRow, 46).Value = claim.ScAcceptsdriveable;
                    worksheet.Cell(currentRow, 47).Value = claim.ScAcceptsnondriveable;
                    worksheet.Cell(currentRow, 48).Value = claim.ScAcceptssms;
                    worksheet.Cell(currentRow, 49).Value = claim.ScAcceptstpafclaims;
                    worksheet.Cell(currentRow, 50).Value = claim.ScAcceptstpvehicles;
                    worksheet.Cell(currentRow, 51).Value = claim.ScAcceptsume;
                    worksheet.Cell(currentRow, 52).Value = claim.ScAccidentsequencekey;
                    worksheet.Cell(currentRow, 53).Value = claim.ScAccountname;
                    worksheet.Cell(currentRow, 54).Value = claim.ScAccountnumber;
                    worksheet.Cell(currentRow, 55).Value = claim.ScActivecontact;
                    worksheet.Cell(currentRow, 56).Value = claim.ScActivepnetaccount;
                    worksheet.Cell(currentRow, 57).Value = claim.ScAuthparty;
                    worksheet.Cell(currentRow, 58).Value = claim.ScB2bEnabled;
                    worksheet.Cell(currentRow, 59).Value = claim.ScBankname;
                    worksheet.Cell(currentRow, 60).Value = claim.ScBsb;
                    worksheet.Cell(currentRow, 61).Value = claim.ScBulkpayments;
                    worksheet.Cell(currentRow, 62).Value = claim.ScBusinesstype;
                    worksheet.Cell(currentRow, 63).Value = claim.ScCellphone;
                    worksheet.Cell(currentRow, 64).Value = claim.ScCentralbillservice;
                    worksheet.Cell(currentRow, 65).Value = claim.ScConsolvendor;
                    worksheet.Cell(currentRow, 66).Value = claim.ScContactpaymentaccountseq;
                    worksheet.Cell(currentRow, 67).Value = claim.ScCorrespondencedelivery;
                    worksheet.Cell(currentRow, 68).Value = claim.ScDeceased;
                    worksheet.Cell(currentRow, 69).Value = claim.ScFormerfirstname;
                    worksheet.Cell(currentRow, 70).Value = claim.ScFormermiddlename;
                    worksheet.Cell(currentRow, 71).Value = claim.ScGstregistered;
                    worksheet.Cell(currentRow, 72).Value = claim.ScHospitalname;
                    worksheet.Cell(currentRow, 73).Value = claim.ScInterpreterreqd;
                    worksheet.Cell(currentRow, 74).Value = claim.ScLanguage;
                    worksheet.Cell(currentRow, 75).Value = claim.ScLanguagepref;
                    worksheet.Cell(currentRow, 76).Value = claim.ScLocationtype;
                    worksheet.Cell(currentRow, 77).Value = claim.ScNodependantadults;
                    worksheet.Cell(currentRow, 78).Value = claim.ScNodependantchildren;
                    worksheet.Cell(currentRow, 79).Value = claim.ScOpenfriday;
                    worksheet.Cell(currentRow, 80).Value = claim.ScOpenmonday;
                    worksheet.Cell(currentRow, 81).Value = claim.ScOpensaturday;
                    worksheet.Cell(currentRow, 82).Value = claim.ScOpensunday;
                    worksheet.Cell(currentRow, 83).Value = claim.ScOpenthursday;
                    worksheet.Cell(currentRow, 84).Value = claim.ScOpentuesday;
                    worksheet.Cell(currentRow, 85).Value = claim.ScOpenwednesday;
                    worksheet.Cell(currentRow, 86).Value = claim.ScOtherphone;
                    worksheet.Cell(currentRow, 87).Value = claim.ScOtherphonedesc;
                    worksheet.Cell(currentRow, 88).Value = claim.ScPayable;
                    worksheet.Cell(currentRow, 89).Value = claim.ScPaymentmethod;
                    worksheet.Cell(currentRow, 90).Value = claim.ScPaymentname;
                    worksheet.Cell(currentRow, 91).Value = claim.ScPaymentserviceackdate;
                    worksheet.Cell(currentRow, 92).Value = claim.ScPaymentservicecorrid;
                    worksheet.Cell(currentRow, 93).Value = claim.ScPaymentservicevendorid;
                    worksheet.Cell(currentRow, 94).Value = claim.ScPaymentterms;
                    worksheet.Cell(currentRow, 95).Value = claim.ScPaystartdate;
                    worksheet.Cell(currentRow, 96).Value = claim.ScPolicytype;
                    worksheet.Cell(currentRow, 97).Value = claim.ScPortfoliocode;
                    worksheet.Cell(currentRow, 98).Value = claim.ScProcesstypeexists;
                    worksheet.Cell(currentRow, 99).Value = claim.ScRecommended;
                    worksheet.Cell(currentRow, 100).Value = claim.ScRemittancedelivery;
                    worksheet.Cell(currentRow, 101).Value = claim.ScRemittancenotificationemail;
                    worksheet.Cell(currentRow, 102).Value = claim.ScSamenotificationemail;
                    worksheet.Cell(currentRow, 103).Value = claim.ScSamenotificationsms;
                    worksheet.Cell(currentRow, 104).Value = claim.ScServiceablepostcodenational;
                    worksheet.Cell(currentRow, 105).Value = claim.ScStaffnumber;
                    worksheet.Cell(currentRow, 106).Value = claim.ScSuspended;
                    worksheet.Cell(currentRow, 107).Value = claim.ScTradingname;
                    worksheet.Cell(currentRow, 108).Value = claim.ScVendorengagementtype;
                    worksheet.Cell(currentRow, 109).Value = claim.ScVendortype;
                    worksheet.Cell(currentRow, 110).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 111).Value = claim.Suffix;
                    worksheet.Cell(currentRow, 112).Value = claim.Taxid;
                    worksheet.Cell(currentRow, 113).Value = claim.Taxstatus;
                    worksheet.Cell(currentRow, 114).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 115).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 116).Value = claim.Validationlevel;
                    worksheet.Cell(currentRow, 117).Value = claim.Vendortype;
                    worksheet.Cell(currentRow, 118).Value = claim.W9received;
                    worksheet.Cell(currentRow, 119).Value = claim.WatchlistproviderExt;
                    worksheet.Cell(currentRow, 120).Value = claim.Workphone;
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

        public async Task<byte[]> GetContact(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetContact(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Contact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Contact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Addressbookuid"; worksheet.Cell(currentRow, 2).Value = claim.Addressbookuid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Afterhours"; worksheet.Cell(currentRow, 2).Value = claim.Afterhours;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Attorneylicense"; worksheet.Cell(currentRow, 2).Value = claim.Attorneylicense;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AutopaymentallowedExt"; worksheet.Cell(currentRow, 2).Value = claim.AutopaymentallowedExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Autosync"; worksheet.Cell(currentRow, 2).Value = claim.Autosync;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Canmanageprojects"; worksheet.Cell(currentRow, 2).Value = claim.Canmanageprojects;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Cellphone"; worksheet.Cell(currentRow, 2).Value = claim.Cellphone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimantidtype"; worksheet.Cell(currentRow, 2).Value = claim.Claimantidtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CommentsExt"; worksheet.Cell(currentRow, 2).Value = claim.CommentsExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Dateofbirth"; worksheet.Cell(currentRow, 2).Value = claim.Dateofbirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DayperiodExt"; worksheet.Cell(currentRow, 2).Value = claim.DayperiodExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Donotdestroy"; worksheet.Cell(currentRow, 2).Value = claim.Donotdestroy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Emailaddress1"; worksheet.Cell(currentRow, 2).Value = claim.Emailaddress1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Emailaddress2"; worksheet.Cell(currentRow, 2).Value = claim.Emailaddress2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Employeenumber"; worksheet.Cell(currentRow, 2).Value = claim.Employeenumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Faxphone"; worksheet.Cell(currentRow, 2).Value = claim.Faxphone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Firstname"; worksheet.Cell(currentRow, 2).Value = claim.Firstname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Firstnamedenorm"; worksheet.Cell(currentRow, 2).Value = claim.Firstnamedenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Formername"; worksheet.Cell(currentRow, 2).Value = claim.Formername;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Gender"; worksheet.Cell(currentRow, 2).Value = claim.Gender;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Homephone"; worksheet.Cell(currentRow, 2).Value = claim.Homephone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IssensitiveExt"; worksheet.Cell(currentRow, 2).Value = claim.IssensitiveExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lastname"; worksheet.Cell(currentRow, 2).Value = claim.Lastname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lastnamedenorm"; worksheet.Cell(currentRow, 2).Value = claim.Lastnamedenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Loadrelatedcontacts"; worksheet.Cell(currentRow, 2).Value = claim.Loadrelatedcontacts;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LocationrepairtypeExt"; worksheet.Cell(currentRow, 2).Value = claim.LocationrepairtypeExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Makesafe"; worksheet.Cell(currentRow, 2).Value = claim.Makesafe;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Middlename"; worksheet.Cell(currentRow, 2).Value = claim.Middlename;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Namedenorm"; worksheet.Cell(currentRow, 2).Value = claim.Namedenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Obfuscatedinternal"; worksheet.Cell(currentRow, 2).Value = claim.Obfuscatedinternal;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Pendinglinkmessage"; worksheet.Cell(currentRow, 2).Value = claim.Pendinglinkmessage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Postaladdress"; worksheet.Cell(currentRow, 2).Value = claim.Postaladdress;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Preferred"; worksheet.Cell(currentRow, 2).Value = claim.Preferred;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Prefix"; worksheet.Cell(currentRow, 2).Value = claim.Prefix;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Primaryaddressid"; worksheet.Cell(currentRow, 2).Value = claim.Primaryaddressid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Primaryphone"; worksheet.Cell(currentRow, 2).Value = claim.Primaryphone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RepairerrelationshipExt"; worksheet.Cell(currentRow, 2).Value = claim.RepairerrelationshipExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptsawpclaims"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptsawpclaims;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptsdriveable"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptsdriveable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptsnondriveable"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptsnondriveable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptssms"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptssms;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptstpafclaims"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptstpafclaims;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptstpvehicles"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptstpvehicles;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAcceptsume"; worksheet.Cell(currentRow, 2).Value = claim.ScAcceptsume;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAccidentsequencekey"; worksheet.Cell(currentRow, 2).Value = claim.ScAccidentsequencekey;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAccountname"; worksheet.Cell(currentRow, 2).Value = claim.ScAccountname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAccountnumber"; worksheet.Cell(currentRow, 2).Value = claim.ScAccountnumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScActivecontact"; worksheet.Cell(currentRow, 2).Value = claim.ScActivecontact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScActivepnetaccount"; worksheet.Cell(currentRow, 2).Value = claim.ScActivepnetaccount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAuthparty"; worksheet.Cell(currentRow, 2).Value = claim.ScAuthparty;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScB2bEnabled"; worksheet.Cell(currentRow, 2).Value = claim.ScB2bEnabled;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBankname"; worksheet.Cell(currentRow, 2).Value = claim.ScBankname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBsb"; worksheet.Cell(currentRow, 2).Value = claim.ScBsb;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBulkpayments"; worksheet.Cell(currentRow, 2).Value = claim.ScBulkpayments;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScBusinesstype"; worksheet.Cell(currentRow, 2).Value = claim.ScBusinesstype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScCellphone"; worksheet.Cell(currentRow, 2).Value = claim.ScCellphone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScCentralbillservice"; worksheet.Cell(currentRow, 2).Value = claim.ScCentralbillservice;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScConsolvendor"; worksheet.Cell(currentRow, 2).Value = claim.ScConsolvendor;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScContactpaymentaccountseq"; worksheet.Cell(currentRow, 2).Value = claim.ScContactpaymentaccountseq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScCorrespondencedelivery"; worksheet.Cell(currentRow, 2).Value = claim.ScCorrespondencedelivery;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScDeceased"; worksheet.Cell(currentRow, 2).Value = claim.ScDeceased;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScFormerfirstname"; worksheet.Cell(currentRow, 2).Value = claim.ScFormerfirstname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScFormermiddlename"; worksheet.Cell(currentRow, 2).Value = claim.ScFormermiddlename;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScGstregistered"; worksheet.Cell(currentRow, 2).Value = claim.ScGstregistered;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScHospitalname"; worksheet.Cell(currentRow, 2).Value = claim.ScHospitalname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScInterpreterreqd"; worksheet.Cell(currentRow, 2).Value = claim.ScInterpreterreqd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScLanguage"; worksheet.Cell(currentRow, 2).Value = claim.ScLanguage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScLanguagepref"; worksheet.Cell(currentRow, 2).Value = claim.ScLanguagepref;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScLocationtype"; worksheet.Cell(currentRow, 2).Value = claim.ScLocationtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScNodependantadults"; worksheet.Cell(currentRow, 2).Value = claim.ScNodependantadults;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScNodependantchildren"; worksheet.Cell(currentRow, 2).Value = claim.ScNodependantchildren;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpenfriday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpenfriday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpenmonday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpenmonday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpensaturday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpensaturday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpensunday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpensunday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpenthursday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpenthursday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpentuesday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpentuesday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOpenwednesday"; worksheet.Cell(currentRow, 2).Value = claim.ScOpenwednesday;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOtherphone"; worksheet.Cell(currentRow, 2).Value = claim.ScOtherphone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScOtherphonedesc"; worksheet.Cell(currentRow, 2).Value = claim.ScOtherphonedesc;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPayable"; worksheet.Cell(currentRow, 2).Value = claim.ScPayable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentmethod"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentmethod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentname"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentserviceackdate"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentserviceackdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentservicecorrid"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentservicecorrid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentservicevendorid"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentservicevendorid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaymentterms"; worksheet.Cell(currentRow, 2).Value = claim.ScPaymentterms;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPaystartdate"; worksheet.Cell(currentRow, 2).Value = claim.ScPaystartdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPolicytype"; worksheet.Cell(currentRow, 2).Value = claim.ScPolicytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPortfoliocode"; worksheet.Cell(currentRow, 2).Value = claim.ScPortfoliocode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScProcesstypeexists"; worksheet.Cell(currentRow, 2).Value = claim.ScProcesstypeexists;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScRecommended"; worksheet.Cell(currentRow, 2).Value = claim.ScRecommended;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScRemittancedelivery"; worksheet.Cell(currentRow, 2).Value = claim.ScRemittancedelivery;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScRemittancenotificationemail"; worksheet.Cell(currentRow, 2).Value = claim.ScRemittancenotificationemail;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScSamenotificationemail"; worksheet.Cell(currentRow, 2).Value = claim.ScSamenotificationemail;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScSamenotificationsms"; worksheet.Cell(currentRow, 2).Value = claim.ScSamenotificationsms;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScServiceablepostcodenational"; worksheet.Cell(currentRow, 2).Value = claim.ScServiceablepostcodenational;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScStaffnumber"; worksheet.Cell(currentRow, 2).Value = claim.ScStaffnumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScSuspended"; worksheet.Cell(currentRow, 2).Value = claim.ScSuspended;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScTradingname"; worksheet.Cell(currentRow, 2).Value = claim.ScTradingname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScVendorengagementtype"; worksheet.Cell(currentRow, 2).Value = claim.ScVendorengagementtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScVendortype"; worksheet.Cell(currentRow, 2).Value = claim.ScVendortype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Suffix"; worksheet.Cell(currentRow, 2).Value = claim.Suffix;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Taxid"; worksheet.Cell(currentRow, 2).Value = claim.Taxid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Taxstatus"; worksheet.Cell(currentRow, 2).Value = claim.Taxstatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Validationlevel"; worksheet.Cell(currentRow, 2).Value = claim.Validationlevel;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Vendortype"; worksheet.Cell(currentRow, 2).Value = claim.Vendortype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "W9received"; worksheet.Cell(currentRow, 2).Value = claim.W9received;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WatchlistproviderExt"; worksheet.Cell(currentRow, 2).Value = claim.WatchlistproviderExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Workphone"; worksheet.Cell(currentRow, 2).Value = claim.Workphone;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetAddresss(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchAddress(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Address");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Address";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Addressline1";
                worksheet.Cell(currentRow, 3).Value = "Addressline2";
                worksheet.Cell(currentRow, 4).Value = "Addressline3";
                worksheet.Cell(currentRow, 5).Value = "Addresstype";
                worksheet.Cell(currentRow, 6).Value = "Batchgeocode";
                worksheet.Cell(currentRow, 7).Value = "Beanversion";
                worksheet.Cell(currentRow, 8).Value = "City";
                worksheet.Cell(currentRow, 9).Value = "Citydenorm";
                worksheet.Cell(currentRow, 10).Value = "Country";
                worksheet.Cell(currentRow, 11).Value = "Createtime";
                worksheet.Cell(currentRow, 12).Value = "Createuserid";
                worksheet.Cell(currentRow, 13).Value = "Description";
                worksheet.Cell(currentRow, 14).Value = "Geocodestatus";
                worksheet.Cell(currentRow, 15).Value = "Postalcode";
                worksheet.Cell(currentRow, 16).Value = "Postalcodedenorm";
                worksheet.Cell(currentRow, 17).Value = "Publicid";
                worksheet.Cell(currentRow, 18).Value = "Retired";
                worksheet.Cell(currentRow, 19).Value = "ScAddressformat";
                worksheet.Cell(currentRow, 20).Value = "ScPermanentchange";
                worksheet.Cell(currentRow, 21).Value = "State";
                worksheet.Cell(currentRow, 22).Value = "Subtype";
                worksheet.Cell(currentRow, 23).Value = "Updatetime";
                worksheet.Cell(currentRow, 24).Value = "Updateuserid";
                worksheet.Cell(currentRow, 25).Value = "Validuntil";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Addressline1;
                    worksheet.Cell(currentRow, 3).Value = claim.Addressline2;
                    worksheet.Cell(currentRow, 4).Value = claim.Addressline3;
                    worksheet.Cell(currentRow, 5).Value = claim.Addresstype;
                    worksheet.Cell(currentRow, 6).Value = claim.Batchgeocode;
                    worksheet.Cell(currentRow, 7).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 8).Value = claim.City;
                    worksheet.Cell(currentRow, 9).Value = claim.Citydenorm;
                    worksheet.Cell(currentRow, 10).Value = claim.Country;
                    worksheet.Cell(currentRow, 11).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 12).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 13).Value = claim.Description;
                    worksheet.Cell(currentRow, 14).Value = claim.Geocodestatus;
                    worksheet.Cell(currentRow, 15).Value = claim.Postalcode;
                    worksheet.Cell(currentRow, 16).Value = claim.Postalcodedenorm;
                    worksheet.Cell(currentRow, 17).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 18).Value = claim.Retired;
                    worksheet.Cell(currentRow, 19).Value = claim.ScAddressformat;
                    worksheet.Cell(currentRow, 20).Value = claim.ScPermanentchange;
                    worksheet.Cell(currentRow, 21).Value = claim.State;
                    worksheet.Cell(currentRow, 22).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 23).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 24).Value = claim.Updateuserid;
                    worksheet.Cell(currentRow, 25).Value = claim.Validuntil;
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

        public async Task<byte[]> GetAddress(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetAddress(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Address");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Address";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Addressline1"; worksheet.Cell(currentRow, 2).Value = claim.Addressline1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Addressline2"; worksheet.Cell(currentRow, 2).Value = claim.Addressline2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Addressline3"; worksheet.Cell(currentRow, 2).Value = claim.Addressline3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Addresstype"; worksheet.Cell(currentRow, 2).Value = claim.Addresstype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Batchgeocode"; worksheet.Cell(currentRow, 2).Value = claim.Batchgeocode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "City"; worksheet.Cell(currentRow, 2).Value = claim.City;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Citydenorm"; worksheet.Cell(currentRow, 2).Value = claim.Citydenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Country"; worksheet.Cell(currentRow, 2).Value = claim.Country;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Geocodestatus"; worksheet.Cell(currentRow, 2).Value = claim.Geocodestatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Postalcode"; worksheet.Cell(currentRow, 2).Value = claim.Postalcode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Postalcodedenorm"; worksheet.Cell(currentRow, 2).Value = claim.Postalcodedenorm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScAddressformat"; worksheet.Cell(currentRow, 2).Value = claim.ScAddressformat;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScPermanentchange"; worksheet.Cell(currentRow, 2).Value = claim.ScPermanentchange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Validuntil"; worksheet.Cell(currentRow, 2).Value = claim.Validuntil;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetCoverages(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchCoverage(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Coverage");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Coverage";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Beanversion";
                worksheet.Cell(currentRow, 3).Value = "Createtime";
                worksheet.Cell(currentRow, 4).Value = "Createuserid";
                worksheet.Cell(currentRow, 5).Value = "Currency";
                worksheet.Cell(currentRow, 6).Value = "Effectivedate";
                worksheet.Cell(currentRow, 7).Value = "Expirationdate";
                worksheet.Cell(currentRow, 8).Value = "OccupationExt";
                worksheet.Cell(currentRow, 9).Value = "Policyid";
                worksheet.Cell(currentRow, 10).Value = "PremiumstatusExt";
                worksheet.Cell(currentRow, 11).Value = "Publicid";
                worksheet.Cell(currentRow, 12).Value = "Retired";
                worksheet.Cell(currentRow, 13).Value = "Riskunitid";
                worksheet.Cell(currentRow, 14).Value = "ScCoveragesourcekey";
                worksheet.Cell(currentRow, 15).Value = "ScRawproduct";
                worksheet.Cell(currentRow, 16).Value = "ScStatus";
                worksheet.Cell(currentRow, 17).Value = "Subtype";
                worksheet.Cell(currentRow, 18).Value = "TermenddateExt";
                worksheet.Cell(currentRow, 19).Value = "TermstartdateExt";
                worksheet.Cell(currentRow, 20).Value = "Type";
                worksheet.Cell(currentRow, 21).Value = "Updatetime";
                worksheet.Cell(currentRow, 22).Value = "Updateuserid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 3).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 4).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 5).Value = claim.Currency;
                    worksheet.Cell(currentRow, 6).Value = claim.Effectivedate;
                    worksheet.Cell(currentRow, 7).Value = claim.Expirationdate;
                    worksheet.Cell(currentRow, 8).Value = claim.OccupationExt;
                    worksheet.Cell(currentRow, 9).Value = claim.Policyid;
                    worksheet.Cell(currentRow, 10).Value = claim.PremiumstatusExt;
                    worksheet.Cell(currentRow, 11).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 12).Value = claim.Retired;
                    worksheet.Cell(currentRow, 13).Value = claim.Riskunitid;
                    worksheet.Cell(currentRow, 14).Value = claim.ScCoveragesourcekey;
                    worksheet.Cell(currentRow, 15).Value = claim.ScRawproduct;
                    worksheet.Cell(currentRow, 16).Value = claim.ScStatus;
                    worksheet.Cell(currentRow, 17).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 18).Value = claim.TermenddateExt;
                    worksheet.Cell(currentRow, 19).Value = claim.TermstartdateExt;
                    worksheet.Cell(currentRow, 20).Value = claim.Type;
                    worksheet.Cell(currentRow, 21).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 22).Value = claim.Updateuserid;
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

        public async Task<byte[]> GetCoverage(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetCoverage(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Coverage");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Coverage";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Currency"; worksheet.Cell(currentRow, 2).Value = claim.Currency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Effectivedate"; worksheet.Cell(currentRow, 2).Value = claim.Effectivedate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Expirationdate"; worksheet.Cell(currentRow, 2).Value = claim.Expirationdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationExt"; worksheet.Cell(currentRow, 2).Value = claim.OccupationExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Policyid"; worksheet.Cell(currentRow, 2).Value = claim.Policyid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiumstatusExt"; worksheet.Cell(currentRow, 2).Value = claim.PremiumstatusExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Riskunitid"; worksheet.Cell(currentRow, 2).Value = claim.Riskunitid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScCoveragesourcekey"; worksheet.Cell(currentRow, 2).Value = claim.ScCoveragesourcekey;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScRawproduct"; worksheet.Cell(currentRow, 2).Value = claim.ScRawproduct;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScStatus"; worksheet.Cell(currentRow, 2).Value = claim.ScStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TermenddateExt"; worksheet.Cell(currentRow, 2).Value = claim.TermenddateExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TermstartdateExt"; worksheet.Cell(currentRow, 2).Value = claim.TermstartdateExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetIncidents(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchIncident(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Incident");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Incident";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Ambulanceused";
                worksheet.Cell(currentRow, 3).Value = "Beanversion";
                worksheet.Cell(currentRow, 4).Value = "ClaimanttypeExt";
                worksheet.Cell(currentRow, 5).Value = "Claimid";
                worksheet.Cell(currentRow, 6).Value = "Createtime";
                worksheet.Cell(currentRow, 7).Value = "Createuserid";
                worksheet.Cell(currentRow, 8).Value = "Description";
                worksheet.Cell(currentRow, 9).Value = "Detailedinjurytype";
                worksheet.Cell(currentRow, 10).Value = "Employmentdataid";
                worksheet.Cell(currentRow, 11).Value = "FaultratingExt";
                worksheet.Cell(currentRow, 12).Value = "FirstnoticeindicatorExt";
                worksheet.Cell(currentRow, 13).Value = "Generalinjurytype";
                worksheet.Cell(currentRow, 14).Value = "HowreportedExt";
                worksheet.Cell(currentRow, 15).Value = "LosscauseExt";
                worksheet.Cell(currentRow, 16).Value = "Lostwages";
                worksheet.Cell(currentRow, 17).Value = "PrimarybodyfunctionExt";
                worksheet.Cell(currentRow, 18).Value = "Publicid";
                worksheet.Cell(currentRow, 19).Value = "RehabilitationreferralindExt";
                worksheet.Cell(currentRow, 20).Value = "ReportedbytypeExt";
                worksheet.Cell(currentRow, 21).Value = "ReporteddateExt";
                worksheet.Cell(currentRow, 22).Value = "ReportonlyExt";
                worksheet.Cell(currentRow, 23).Value = "ResultofinjuryExt";
                worksheet.Cell(currentRow, 24).Value = "Retired";
                worksheet.Cell(currentRow, 25).Value = "ScClaimeventquestions";
                worksheet.Cell(currentRow, 26).Value = "ScInjuryquestions";
                worksheet.Cell(currentRow, 27).Value = "Severity";
                worksheet.Cell(currentRow, 28).Value = "StatutorybenefitsExt";
                worksheet.Cell(currentRow, 29).Value = "StatutorycareExtid";
                worksheet.Cell(currentRow, 30).Value = "Subtype";
                worksheet.Cell(currentRow, 31).Value = "Updatetime";
                worksheet.Cell(currentRow, 32).Value = "Updateuserid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.Ambulanceused;
                    worksheet.Cell(currentRow, 3).Value = claim.Beanversion;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimanttypeExt;
                    worksheet.Cell(currentRow, 5).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 6).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 7).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 8).Value = claim.Description;
                    worksheet.Cell(currentRow, 9).Value = claim.Detailedinjurytype;
                    worksheet.Cell(currentRow, 10).Value = claim.Employmentdataid;
                    worksheet.Cell(currentRow, 11).Value = claim.FaultratingExt;
                    worksheet.Cell(currentRow, 12).Value = claim.FirstnoticeindicatorExt;
                    worksheet.Cell(currentRow, 13).Value = claim.Generalinjurytype;
                    worksheet.Cell(currentRow, 14).Value = claim.HowreportedExt;
                    worksheet.Cell(currentRow, 15).Value = claim.LosscauseExt;
                    worksheet.Cell(currentRow, 16).Value = claim.Lostwages;
                    worksheet.Cell(currentRow, 17).Value = claim.PrimarybodyfunctionExt;
                    worksheet.Cell(currentRow, 18).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 19).Value = claim.RehabilitationreferralindExt;
                    worksheet.Cell(currentRow, 20).Value = claim.ReportedbytypeExt;
                    worksheet.Cell(currentRow, 21).Value = claim.ReporteddateExt;
                    worksheet.Cell(currentRow, 22).Value = claim.ReportonlyExt;
                    worksheet.Cell(currentRow, 23).Value = claim.ResultofinjuryExt;
                    worksheet.Cell(currentRow, 24).Value = claim.Retired;
                    worksheet.Cell(currentRow, 25).Value = claim.ScClaimeventquestions;
                    worksheet.Cell(currentRow, 26).Value = claim.ScInjuryquestions;
                    worksheet.Cell(currentRow, 27).Value = claim.Severity;
                    worksheet.Cell(currentRow, 28).Value = claim.StatutorybenefitsExt;
                    worksheet.Cell(currentRow, 29).Value = claim.StatutorycareExtid;
                    worksheet.Cell(currentRow, 30).Value = claim.Subtype;
                    worksheet.Cell(currentRow, 31).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 32).Value = claim.Updateuserid;
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

        public async Task<byte[]> GetIncident(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetIncident(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Incident");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Incident";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Ambulanceused"; worksheet.Cell(currentRow, 2).Value = claim.Ambulanceused;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Beanversion"; worksheet.Cell(currentRow, 2).Value = claim.Beanversion;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimanttypeExt"; worksheet.Cell(currentRow, 2).Value = claim.ClaimanttypeExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Detailedinjurytype"; worksheet.Cell(currentRow, 2).Value = claim.Detailedinjurytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Employmentdataid"; worksheet.Cell(currentRow, 2).Value = claim.Employmentdataid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FaultratingExt"; worksheet.Cell(currentRow, 2).Value = claim.FaultratingExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstnoticeindicatorExt"; worksheet.Cell(currentRow, 2).Value = claim.FirstnoticeindicatorExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Generalinjurytype"; worksheet.Cell(currentRow, 2).Value = claim.Generalinjurytype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HowreportedExt"; worksheet.Cell(currentRow, 2).Value = claim.HowreportedExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LosscauseExt"; worksheet.Cell(currentRow, 2).Value = claim.LosscauseExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Lostwages"; worksheet.Cell(currentRow, 2).Value = claim.Lostwages;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimarybodyfunctionExt"; worksheet.Cell(currentRow, 2).Value = claim.PrimarybodyfunctionExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RehabilitationreferralindExt"; worksheet.Cell(currentRow, 2).Value = claim.RehabilitationreferralindExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReportedbytypeExt"; worksheet.Cell(currentRow, 2).Value = claim.ReportedbytypeExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReporteddateExt"; worksheet.Cell(currentRow, 2).Value = claim.ReporteddateExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReportonlyExt"; worksheet.Cell(currentRow, 2).Value = claim.ReportonlyExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ResultofinjuryExt"; worksheet.Cell(currentRow, 2).Value = claim.ResultofinjuryExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScClaimeventquestions"; worksheet.Cell(currentRow, 2).Value = claim.ScClaimeventquestions;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ScInjuryquestions"; worksheet.Cell(currentRow, 2).Value = claim.ScInjuryquestions;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Severity"; worksheet.Cell(currentRow, 2).Value = claim.Severity;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StatutorybenefitsExt"; worksheet.Cell(currentRow, 2).Value = claim.StatutorybenefitsExt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StatutorycareExtid"; worksheet.Cell(currentRow, 2).Value = claim.StatutorycareExtid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subtype"; worksheet.Cell(currentRow, 2).Value = claim.Subtype;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetComplaints(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchComplaint(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Complaint");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Helphub Complaint";
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
                worksheet.Cell(currentRow, 8).Value = "Claimid";
                worksheet.Cell(currentRow, 9).Value = "Complainantexpectationdesc";
                worksheet.Cell(currentRow, 10).Value = "ComplaintcategoryExtid";
                worksheet.Cell(currentRow, 11).Value = "Complaintnumber";
                worksheet.Cell(currentRow, 12).Value = "Contactid";
                worksheet.Cell(currentRow, 13).Value = "Createtime";
                worksheet.Cell(currentRow, 14).Value = "Createuserid";
                worksheet.Cell(currentRow, 15).Value = "Description";
                worksheet.Cell(currentRow, 16).Value = "Extendedresolutiondate";
                worksheet.Cell(currentRow, 17).Value = "Howreported";
                worksheet.Cell(currentRow, 18).Value = "Incidentdate";
                worksheet.Cell(currentRow, 19).Value = "Iscostforactualamount";
                worksheet.Cell(currentRow, 20).Value = "Mediadescription";
                worksheet.Cell(currentRow, 21).Value = "Mediainvolvedflag";
                worksheet.Cell(currentRow, 22).Value = "Previousgroupid";
                worksheet.Cell(currentRow, 23).Value = "Previoususerid";
                worksheet.Cell(currentRow, 24).Value = "Publicid";
                worksheet.Cell(currentRow, 25).Value = "Receiveddate";
                worksheet.Cell(currentRow, 26).Value = "Resolutiondate";
                worksheet.Cell(currentRow, 27).Value = "Resolutiondescription";
                worksheet.Cell(currentRow, 28).Value = "Retired";
                worksheet.Cell(currentRow, 29).Value = "Status";
                worksheet.Cell(currentRow, 30).Value = "Updatetime";
                worksheet.Cell(currentRow, 31).Value = "Updateuserid";

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
                    worksheet.Cell(currentRow, 8).Value = claim.Claimid;
                    worksheet.Cell(currentRow, 9).Value = claim.Complainantexpectationdesc;
                    worksheet.Cell(currentRow, 10).Value = claim.ComplaintcategoryExtid;
                    worksheet.Cell(currentRow, 11).Value = claim.Complaintnumber;
                    worksheet.Cell(currentRow, 12).Value = claim.Contactid;
                    worksheet.Cell(currentRow, 13).Value = claim.Createtime;
                    worksheet.Cell(currentRow, 14).Value = claim.Createuserid;
                    worksheet.Cell(currentRow, 15).Value = claim.Description;
                    worksheet.Cell(currentRow, 16).Value = claim.Extendedresolutiondate;
                    worksheet.Cell(currentRow, 17).Value = claim.Howreported;
                    worksheet.Cell(currentRow, 18).Value = claim.Incidentdate;
                    worksheet.Cell(currentRow, 19).Value = claim.Iscostforactualamount;
                    worksheet.Cell(currentRow, 20).Value = claim.Mediadescription;
                    worksheet.Cell(currentRow, 21).Value = claim.Mediainvolvedflag;
                    worksheet.Cell(currentRow, 22).Value = claim.Previousgroupid;
                    worksheet.Cell(currentRow, 23).Value = claim.Previoususerid;
                    worksheet.Cell(currentRow, 24).Value = claim.Publicid;
                    worksheet.Cell(currentRow, 25).Value = claim.Receiveddate;
                    worksheet.Cell(currentRow, 26).Value = claim.Resolutiondate;
                    worksheet.Cell(currentRow, 27).Value = claim.Resolutiondescription;
                    worksheet.Cell(currentRow, 28).Value = claim.Retired;
                    worksheet.Cell(currentRow, 29).Value = claim.Status;
                    worksheet.Cell(currentRow, 30).Value = claim.Updatetime;
                    worksheet.Cell(currentRow, 31).Value = claim.Updateuserid;
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

        public async Task<byte[]> GetComplaint(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetComplaint(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Complaint");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Complaint";
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
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Claimid"; worksheet.Cell(currentRow, 2).Value = claim.Claimid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Complainantexpectationdesc"; worksheet.Cell(currentRow, 2).Value = claim.Complainantexpectationdesc;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintcategoryExtid"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintcategoryExtid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Complaintnumber"; worksheet.Cell(currentRow, 2).Value = claim.Complaintnumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Contactid"; worksheet.Cell(currentRow, 2).Value = claim.Contactid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createtime"; worksheet.Cell(currentRow, 2).Value = claim.Createtime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Createuserid"; worksheet.Cell(currentRow, 2).Value = claim.Createuserid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Extendedresolutiondate"; worksheet.Cell(currentRow, 2).Value = claim.Extendedresolutiondate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Howreported"; worksheet.Cell(currentRow, 2).Value = claim.Howreported;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Incidentdate"; worksheet.Cell(currentRow, 2).Value = claim.Incidentdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Iscostforactualamount"; worksheet.Cell(currentRow, 2).Value = claim.Iscostforactualamount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mediadescription"; worksheet.Cell(currentRow, 2).Value = claim.Mediadescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mediainvolvedflag"; worksheet.Cell(currentRow, 2).Value = claim.Mediainvolvedflag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previousgroupid"; worksheet.Cell(currentRow, 2).Value = claim.Previousgroupid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Previoususerid"; worksheet.Cell(currentRow, 2).Value = claim.Previoususerid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Publicid"; worksheet.Cell(currentRow, 2).Value = claim.Publicid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Receiveddate"; worksheet.Cell(currentRow, 2).Value = claim.Receiveddate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Resolutiondate"; worksheet.Cell(currentRow, 2).Value = claim.Resolutiondate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Resolutiondescription"; worksheet.Cell(currentRow, 2).Value = claim.Resolutiondescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Retired"; worksheet.Cell(currentRow, 2).Value = claim.Retired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updatetime"; worksheet.Cell(currentRow, 2).Value = claim.Updatetime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Updateuserid"; worksheet.Cell(currentRow, 2).Value = claim.Updateuserid;



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
