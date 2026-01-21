using AppCoreV1.ABLEModels;
using AppCoreV1.Interfaces;
using ClosedXML.Excel;

namespace AppCoreV1.Helper
{
    public class XLSAbleHelper : IXLSAbleHelper, IDisposable
    {
        private readonly IAbleSearch _context;

        public XLSAbleHelper(IAbleSearch context)
        {
            _context = context;
        }

        private string GetAppName(int appflg)
        {
            string appname = "Able";
            if (appflg == 2)
            {
                appname = "Orion";
            }
            return appname;
        }

        public async Task<byte[]> GetClaimbenefitmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchClaimbenefitmv(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Claimbenefitmv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Claimbenefitmv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "IndicativeClaimType";
                worksheet.Cell(currentRow, 4).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 5).Value = "StaffInd";
                worksheet.Cell(currentRow, 6).Value = "GivenName";
                worksheet.Cell(currentRow, 7).Value = "Surname";
                worksheet.Cell(currentRow, 8).Value = "Sex";
                worksheet.Cell(currentRow, 9).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 10).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 11).Value = "Occupation";
                worksheet.Cell(currentRow, 12).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 13).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 14).Value = "State";
                worksheet.Cell(currentRow, 15).Value = "PostCode";
                worksheet.Cell(currentRow, 16).Value = "CaseType";
                worksheet.Cell(currentRow, 17).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 18).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 19).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 20).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 21).Value = "IncurredDate";
                worksheet.Cell(currentRow, 22).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 23).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 24).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 25).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 26).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 27).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 28).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 29).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 30).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 31).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 32).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 34).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 35).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 36).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 37).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 38).Value = "ContractStatus";
                worksheet.Cell(currentRow, 39).Value = "ProductName";
                worksheet.Cell(currentRow, 40).Value = "BenefitType";
                worksheet.Cell(currentRow, 41).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 42).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 43).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 44).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 45).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 46).Value = "CoverType";
                worksheet.Cell(currentRow, 47).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 48).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 49).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 50).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 51).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 52).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 53).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 54).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 55).Value = "InitialSumInsuredFreq";
                worksheet.Cell(currentRow, 56).Value = "SumInsured";
                worksheet.Cell(currentRow, 57).Value = "BenefitPaymentFreq";
                worksheet.Cell(currentRow, 58).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 59).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 60).Value = "Decision";
                worksheet.Cell(currentRow, 61).Value = "Accepted";
                worksheet.Cell(currentRow, 62).Value = "DecisionDate";
                worksheet.Cell(currentRow, 63).Value = "DecisionReason";
                worksheet.Cell(currentRow, 64).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 65).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 66).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 67).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 68).Value = "FirstAcceptanceDate";
                worksheet.Cell(currentRow, 69).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 70).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 71).Value = "IndexationFrequency";
                worksheet.Cell(currentRow, 72).Value = "AgreedValue";
                worksheet.Cell(currentRow, 73).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 74).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 75).Value = "ReInsurerName";
                worksheet.Cell(currentRow, 76).Value = "ReinsuranceTreatyType";
                worksheet.Cell(currentRow, 77).Value = "ReinsurancePercent";
                worksheet.Cell(currentRow, 78).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 79).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 80).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 81).Value = "RiskCategory";
                worksheet.Cell(currentRow, 82).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 83).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 84).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 85).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 86).Value = "PrimaryOccSelfEmployedInd";
                worksheet.Cell(currentRow, 87).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 88).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 89).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 90).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 91).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 92).Value = "SumReInsured";
                worksheet.Cell(currentRow, 93).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 94).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 95).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 96).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 97).Value = "Source";
                worksheet.Cell(currentRow, 98).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 99).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 100).Value = "SourceSystem";
                worksheet.Cell(currentRow, 101).Value = "Entity";
                worksheet.Cell(currentRow, 102).Value = "OccupationCategory";
                worksheet.Cell(currentRow, 103).Value = "TpdDefinition";
                worksheet.Cell(currentRow, 104).Value = "TpdSubDefinition";
                worksheet.Cell(currentRow, 105).Value = "TraumaDefinition";
                worksheet.Cell(currentRow, 106).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 107).Value = "ProductCode";
                worksheet.Cell(currentRow, 108).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 109).Value = "PartyId";
                worksheet.Cell(currentRow, 110).Value = "Declined";
                worksheet.Cell(currentRow, 111).Value = "QualifyingPeriod";
                worksheet.Cell(currentRow, 112).Value = "ExpectedResolutionDate";
                worksheet.Cell(currentRow, 113).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 114).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 115).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 116).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 117).Value = "PaymentAuthorized";
                worksheet.Cell(currentRow, 118).Value = "ClaimAllocateNewDate";
                worksheet.Cell(currentRow, 119).Value = "ClaimAllowAutoAllocation";
                worksheet.Cell(currentRow, 120).Value = "AllocatedBy";
                worksheet.Cell(currentRow, 121).Value = "AssignedToDept";
                worksheet.Cell(currentRow, 122).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 123).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 124).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 125).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 126).Value = "CmpRequired";
                worksheet.Cell(currentRow, 127).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 128).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 129).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 130).Value = "UnexpectedCircumstances";
                worksheet.Cell(currentRow, 131).Value = "CoverageNumber";
                worksheet.Cell(currentRow, 132).Value = "Assessedunderlimitedcover";
                worksheet.Cell(currentRow, 133).Value = "ClaimReceivedDate";
                worksheet.Cell(currentRow, 134).Value = "CustomerContactFrequency";
                worksheet.Cell(currentRow, 135).Value = "UnexpectedCircumstancesApply";
                worksheet.Cell(currentRow, 136).Value = "IarCode";
                worksheet.Cell(currentRow, 137).Value = "IarDescription";
                worksheet.Cell(currentRow, 138).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.IndicativeClaimType;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 5).Value = claim.StaffInd;
                    worksheet.Cell(currentRow, 6).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 7).Value = claim.Surname;
                    worksheet.Cell(currentRow, 8).Value = claim.Sex;
                    worksheet.Cell(currentRow, 9).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 10).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 11).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 12).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 13).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 14).Value = claim.State;
                    worksheet.Cell(currentRow, 15).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 16).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 17).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 18).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 19).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 20).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 21).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 22).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 23).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 24).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 25).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 26).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 27).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 28).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 29).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 30).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 31).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 32).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 34).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 35).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 36).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 37).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 38).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 39).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 40).Value = claim.BenefitType;
                    worksheet.Cell(currentRow, 41).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 42).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 43).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 44).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 45).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 46).Value = claim.CoverType;
                    worksheet.Cell(currentRow, 47).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 48).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 49).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 50).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 51).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 52).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 53).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 54).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 55).Value = claim.InitialSumInsuredFreq;
                    worksheet.Cell(currentRow, 56).Value = claim.SumInsured;
                    worksheet.Cell(currentRow, 57).Value = claim.BenefitPaymentFreq;
                    worksheet.Cell(currentRow, 58).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 59).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 60).Value = claim.Decision;
                    worksheet.Cell(currentRow, 61).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 62).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 63).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 64).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 65).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 66).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 67).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 68).Value = claim.FirstAcceptanceDate;
                    worksheet.Cell(currentRow, 69).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 70).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 71).Value = claim.IndexationFrequency;
                    worksheet.Cell(currentRow, 72).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 73).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 74).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 75).Value = claim.ReInsurerName;
                    worksheet.Cell(currentRow, 76).Value = claim.ReinsuranceTreatyType;
                    worksheet.Cell(currentRow, 77).Value = claim.ReinsurancePercent;
                    worksheet.Cell(currentRow, 78).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 79).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 80).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 81).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 82).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 83).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 84).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 85).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 86).Value = claim.PrimaryOccSelfEmployedInd;
                    worksheet.Cell(currentRow, 87).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 88).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 89).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 90).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 91).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 92).Value = claim.SumReInsured;
                    worksheet.Cell(currentRow, 93).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 94).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 95).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 96).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 97).Value = claim.Source;
                    worksheet.Cell(currentRow, 98).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 99).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 100).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 101).Value = claim.Entity;
                    worksheet.Cell(currentRow, 102).Value = claim.OccupationCategory;
                    worksheet.Cell(currentRow, 103).Value = claim.TpdDefinition;
                    worksheet.Cell(currentRow, 104).Value = claim.TpdSubDefinition;
                    worksheet.Cell(currentRow, 105).Value = claim.TraumaDefinition;
                    worksheet.Cell(currentRow, 106).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 107).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 108).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 109).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 110).Value = claim.Declined;
                    worksheet.Cell(currentRow, 111).Value = claim.QualifyingPeriod;
                    worksheet.Cell(currentRow, 112).Value = claim.ExpectedResolutionDate;
                    worksheet.Cell(currentRow, 113).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 114).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 115).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 116).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 117).Value = claim.PaymentAuthorized;
                    worksheet.Cell(currentRow, 118).Value = claim.ClaimAllocateNewDate;
                    worksheet.Cell(currentRow, 119).Value = claim.ClaimAllowAutoAllocation;
                    worksheet.Cell(currentRow, 120).Value = claim.AllocatedBy;
                    worksheet.Cell(currentRow, 121).Value = claim.AssignedToDept;
                    worksheet.Cell(currentRow, 122).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 123).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 124).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 125).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 126).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 127).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 128).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 129).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 130).Value = claim.UnexpectedCircumstances;
                    worksheet.Cell(currentRow, 131).Value = claim.CoverageNumber;
                    worksheet.Cell(currentRow, 132).Value = claim.Assessedunderlimitedcover;
                    worksheet.Cell(currentRow, 133).Value = claim.ClaimReceivedDate;
                    worksheet.Cell(currentRow, 134).Value = claim.CustomerContactFrequency;
                    worksheet.Cell(currentRow, 135).Value = claim.UnexpectedCircumstancesApply;
                    worksheet.Cell(currentRow, 136).Value = claim.IarCode;
                    worksheet.Cell(currentRow, 137).Value = claim.IarDescription;
                    worksheet.Cell(currentRow, 138).Value = GetAppName(claim.ApplicationId);
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

        public async Task<byte[]> GetClaimbenefitmv(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetClaimbenefitmv(id, appflag);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Claimbenefitmv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " Claimbenefitmv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndicativeClaimType"; worksheet.Cell(currentRow, 2).Value = claim.IndicativeClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StaffInd"; worksheet.Cell(currentRow, 2).Value = claim.StaffInd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverType"; worksheet.Cell(currentRow, 2).Value = claim.CoverType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPaymentFreq"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPaymentFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstAcceptanceDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstAcceptanceDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFrequency"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReInsurerName"; worksheet.Cell(currentRow, 2).Value = claim.ReInsurerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsuranceTreatyType"; worksheet.Cell(currentRow, 2).Value = claim.ReinsuranceTreatyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.ReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccSelfEmployedInd"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccSelfEmployedInd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumReInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumReInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Entity"; worksheet.Cell(currentRow, 2).Value = claim.Entity;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationCategory"; worksheet.Cell(currentRow, 2).Value = claim.OccupationCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdSubDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdSubDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TraumaDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Declined"; worksheet.Cell(currentRow, 2).Value = claim.Declined;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "QualifyingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.QualifyingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedResolutionDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedResolutionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentAuthorized"; worksheet.Cell(currentRow, 2).Value = claim.PaymentAuthorized;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimAllocateNewDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimAllocateNewDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimAllowAutoAllocation"; worksheet.Cell(currentRow, 2).Value = claim.ClaimAllowAutoAllocation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AllocatedBy"; worksheet.Cell(currentRow, 2).Value = claim.AllocatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AssignedToDept"; worksheet.Cell(currentRow, 2).Value = claim.AssignedToDept;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverageNumber"; worksheet.Cell(currentRow, 2).Value = claim.CoverageNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assessedunderlimitedcover"; worksheet.Cell(currentRow, 2).Value = claim.Assessedunderlimitedcover;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReceivedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReceivedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerContactFrequency"; worksheet.Cell(currentRow, 2).Value = claim.CustomerContactFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstancesApply"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstancesApply;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IarCode"; worksheet.Cell(currentRow, 2).Value = claim.IarCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IarDescription"; worksheet.Cell(currentRow, 2).Value = claim.IarDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetPaymentsummarymvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchPaymentsummarymv(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Paymentsummarymv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Paymentsummarymv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 4).Value = "EFormId";
                worksheet.Cell(currentRow, 5).Value = "BenefitPayment";
                worksheet.Cell(currentRow, 6).Value = "AcceptFrom";
                worksheet.Cell(currentRow, 7).Value = "From";
                worksheet.Cell(currentRow, 8).Value = "To";
                worksheet.Cell(currentRow, 9).Value = "BenefitAmount";
                worksheet.Cell(currentRow, 10).Value = "BenefitAmountInfo";
                worksheet.Cell(currentRow, 11).Value = "StampDuty";
                worksheet.Cell(currentRow, 12).Value = "StampDutyInfo";
                worksheet.Cell(currentRow, 13).Value = "PremiumRefund";
                worksheet.Cell(currentRow, 14).Value = "PremiumRefundInfo";
                worksheet.Cell(currentRow, 15).Value = "SuperContributions";
                worksheet.Cell(currentRow, 16).Value = "SuperContributionsInfo";
                worksheet.Cell(currentRow, 17).Value = "NoClaimBonus";
                worksheet.Cell(currentRow, 18).Value = "NoClaimBonusInfo";
                worksheet.Cell(currentRow, 19).Value = "Offsets";
                worksheet.Cell(currentRow, 20).Value = "OffsetsInfo";
                worksheet.Cell(currentRow, 21).Value = "Others";
                worksheet.Cell(currentRow, 22).Value = "OthersInfo";
                worksheet.Cell(currentRow, 23).Value = "Tax";
                worksheet.Cell(currentRow, 24).Value = "TaxInfo";
                worksheet.Cell(currentRow, 25).Value = "CalculationDescription";
                worksheet.Cell(currentRow, 26).Value = "PaymentMethod";
                worksheet.Cell(currentRow, 27).Value = "PartialBenefit";
                worksheet.Cell(currentRow, 28).Value = "GroupPayee";
                worksheet.Cell(currentRow, 29).Value = "CpiEbrClaimsEscalation";
                worksheet.Cell(currentRow, 30).Value = "CpiEbrClaimsEscalDes";
                worksheet.Cell(currentRow, 31).Value = "NumberOfPayments";
                worksheet.Cell(currentRow, 32).Value = "AdminInitials";
                worksheet.Cell(currentRow, 33).Value = "AdminDate";
                worksheet.Cell(currentRow, 34).Value = "PaymentReference";
                worksheet.Cell(currentRow, 35).Value = "AdminAuthorisedByInitials";
                worksheet.Cell(currentRow, 36).Value = "AdminAuthorisedDate";
                worksheet.Cell(currentRow, 37).Value = "PsoftRefForWaivPremiums";
                worksheet.Cell(currentRow, 38).Value = "PsoftWvedPremiumAuthBy";
                worksheet.Cell(currentRow, 39).Value = "PsoftPayAuthDate";
                worksheet.Cell(currentRow, 40).Value = "PeopleSoftScoReference";
                worksheet.Cell(currentRow, 41).Value = "PsoftPayAuthBy";
                worksheet.Cell(currentRow, 42).Value = "PsoftPayAuthDate1";
                worksheet.Cell(currentRow, 43).Value = "ServiceRequestScoReference";
                worksheet.Cell(currentRow, 44).Value = "OtherInformationEnd";
                worksheet.Cell(currentRow, 45).Value = "Total";
                worksheet.Cell(currentRow, 46).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 47).Value = "ClaimType";
                worksheet.Cell(currentRow, 48).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 49).Value = "BenefitCode";
                worksheet.Cell(currentRow, 50).Value = "ProductCode";
                worksheet.Cell(currentRow, 51).Value = "BenefitType";
                worksheet.Cell(currentRow, 52).Value = "DateCreated";
                worksheet.Cell(currentRow, 53).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.EFormId;
                    worksheet.Cell(currentRow, 5).Value = claim.BenefitPayment;
                    worksheet.Cell(currentRow, 6).Value = claim.AcceptFrom;
                    worksheet.Cell(currentRow, 7).Value = claim.From;
                    worksheet.Cell(currentRow, 8).Value = claim.To;
                    worksheet.Cell(currentRow, 9).Value = claim.BenefitAmount;
                    worksheet.Cell(currentRow, 10).Value = claim.BenefitAmountInfo;
                    worksheet.Cell(currentRow, 11).Value = claim.StampDuty;
                    worksheet.Cell(currentRow, 12).Value = claim.StampDutyInfo;
                    worksheet.Cell(currentRow, 13).Value = claim.PremiumRefund;
                    worksheet.Cell(currentRow, 14).Value = claim.PremiumRefundInfo;
                    worksheet.Cell(currentRow, 15).Value = claim.SuperContributions;
                    worksheet.Cell(currentRow, 16).Value = claim.SuperContributionsInfo;
                    worksheet.Cell(currentRow, 17).Value = claim.NoClaimBonus;
                    worksheet.Cell(currentRow, 18).Value = claim.NoClaimBonusInfo;
                    worksheet.Cell(currentRow, 19).Value = claim.Offsets;
                    worksheet.Cell(currentRow, 20).Value = claim.OffsetsInfo;
                    worksheet.Cell(currentRow, 21).Value = claim.Others;
                    worksheet.Cell(currentRow, 22).Value = claim.OthersInfo;
                    worksheet.Cell(currentRow, 23).Value = claim.Tax;
                    worksheet.Cell(currentRow, 24).Value = claim.TaxInfo;
                    worksheet.Cell(currentRow, 25).Value = claim.CalculationDescription;
                    worksheet.Cell(currentRow, 26).Value = claim.PaymentMethod;
                    worksheet.Cell(currentRow, 27).Value = claim.PartialBenefit;
                    worksheet.Cell(currentRow, 28).Value = claim.GroupPayee;
                    worksheet.Cell(currentRow, 29).Value = claim.CpiEbrClaimsEscalation;
                    worksheet.Cell(currentRow, 30).Value = claim.CpiEbrClaimsEscalDes;
                    worksheet.Cell(currentRow, 31).Value = claim.NumberOfPayments;
                    worksheet.Cell(currentRow, 32).Value = claim.AdminInitials;
                    worksheet.Cell(currentRow, 33).Value = claim.AdminDate;
                    worksheet.Cell(currentRow, 34).Value = claim.PaymentReference;
                    worksheet.Cell(currentRow, 35).Value = claim.AdminAuthorisedByInitials;
                    worksheet.Cell(currentRow, 36).Value = claim.AdminAuthorisedDate;
                    worksheet.Cell(currentRow, 37).Value = claim.PsoftRefForWaivPremiums;
                    worksheet.Cell(currentRow, 38).Value = claim.PsoftWvedPremiumAuthBy;
                    worksheet.Cell(currentRow, 39).Value = claim.PsoftPayAuthDate;
                    worksheet.Cell(currentRow, 40).Value = claim.PeopleSoftScoReference;
                    worksheet.Cell(currentRow, 41).Value = claim.PsoftPayAuthBy;
                    worksheet.Cell(currentRow, 42).Value = claim.PsoftPayAuthDate1;
                    worksheet.Cell(currentRow, 43).Value = claim.ServiceRequestScoReference;
                    worksheet.Cell(currentRow, 44).Value = claim.OtherInformationEnd;
                    worksheet.Cell(currentRow, 45).Value = claim.Total;
                    worksheet.Cell(currentRow, 46).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 47).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 48).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 49).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 50).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 51).Value = claim.BenefitType;
                    worksheet.Cell(currentRow, 52).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 53).Value = GetAppName(appflag);
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

        public async Task<byte[]> GetPaymentsummarymv(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetPaymentsummarymv(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Paymentsummarymv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " Paymentsummarymv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EFormId"; worksheet.Cell(currentRow, 2).Value = claim.EFormId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPayment"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPayment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AcceptFrom"; worksheet.Cell(currentRow, 2).Value = claim.AcceptFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "From"; worksheet.Cell(currentRow, 2).Value = claim.From;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "To"; worksheet.Cell(currentRow, 2).Value = claim.To;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitAmount"; worksheet.Cell(currentRow, 2).Value = claim.BenefitAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitAmountInfo"; worksheet.Cell(currentRow, 2).Value = claim.BenefitAmountInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StampDuty"; worksheet.Cell(currentRow, 2).Value = claim.StampDuty;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StampDutyInfo"; worksheet.Cell(currentRow, 2).Value = claim.StampDutyInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiumRefund"; worksheet.Cell(currentRow, 2).Value = claim.PremiumRefund;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiumRefundInfo"; worksheet.Cell(currentRow, 2).Value = claim.PremiumRefundInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributions"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributions;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionsInfo"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionsInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NoClaimBonus"; worksheet.Cell(currentRow, 2).Value = claim.NoClaimBonus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NoClaimBonusInfo"; worksheet.Cell(currentRow, 2).Value = claim.NoClaimBonusInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Offsets"; worksheet.Cell(currentRow, 2).Value = claim.Offsets;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OffsetsInfo"; worksheet.Cell(currentRow, 2).Value = claim.OffsetsInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Others"; worksheet.Cell(currentRow, 2).Value = claim.Others;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OthersInfo"; worksheet.Cell(currentRow, 2).Value = claim.OthersInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Tax"; worksheet.Cell(currentRow, 2).Value = claim.Tax;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaxInfo"; worksheet.Cell(currentRow, 2).Value = claim.TaxInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationDescription"; worksheet.Cell(currentRow, 2).Value = claim.CalculationDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentMethod"; worksheet.Cell(currentRow, 2).Value = claim.PaymentMethod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialBenefit"; worksheet.Cell(currentRow, 2).Value = claim.PartialBenefit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPayee"; worksheet.Cell(currentRow, 2).Value = claim.GroupPayee;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CpiEbrClaimsEscalation"; worksheet.Cell(currentRow, 2).Value = claim.CpiEbrClaimsEscalation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CpiEbrClaimsEscalDes"; worksheet.Cell(currentRow, 2).Value = claim.CpiEbrClaimsEscalDes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NumberOfPayments"; worksheet.Cell(currentRow, 2).Value = claim.NumberOfPayments;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminInitials"; worksheet.Cell(currentRow, 2).Value = claim.AdminInitials;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminDate"; worksheet.Cell(currentRow, 2).Value = claim.AdminDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentReference"; worksheet.Cell(currentRow, 2).Value = claim.PaymentReference;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminAuthorisedByInitials"; worksheet.Cell(currentRow, 2).Value = claim.AdminAuthorisedByInitials;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminAuthorisedDate"; worksheet.Cell(currentRow, 2).Value = claim.AdminAuthorisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PsoftRefForWaivPremiums"; worksheet.Cell(currentRow, 2).Value = claim.PsoftRefForWaivPremiums;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PsoftWvedPremiumAuthBy"; worksheet.Cell(currentRow, 2).Value = claim.PsoftWvedPremiumAuthBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PsoftPayAuthDate"; worksheet.Cell(currentRow, 2).Value = claim.PsoftPayAuthDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PeopleSoftScoReference"; worksheet.Cell(currentRow, 2).Value = claim.PeopleSoftScoReference;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PsoftPayAuthBy"; worksheet.Cell(currentRow, 2).Value = claim.PsoftPayAuthBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PsoftPayAuthDate1"; worksheet.Cell(currentRow, 2).Value = claim.PsoftPayAuthDate1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceRequestScoReference"; worksheet.Cell(currentRow, 2).Value = claim.ServiceRequestScoReference;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OtherInformationEnd"; worksheet.Cell(currentRow, 2).Value = claim.OtherInformationEnd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Total"; worksheet.Cell(currentRow, 2).Value = claim.Total;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);


                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetTaskmvs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchTaskmv(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Taskmv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Taskmv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CaseStatus";
                worksheet.Cell(currentRow, 4).Value = "ClaimantName";
                worksheet.Cell(currentRow, 5).Value = "CaseType";
                worksheet.Cell(currentRow, 6).Value = "CaseManager";
                worksheet.Cell(currentRow, 7).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 8).Value = "TaskProcessStep";
                worksheet.Cell(currentRow, 9).Value = "TaskId";
                worksheet.Cell(currentRow, 10).Value = "TaskCode";
                worksheet.Cell(currentRow, 11).Value = "TaskName";
                worksheet.Cell(currentRow, 12).Value = "TaskDescription";
                worksheet.Cell(currentRow, 13).Value = "TaskStatus";
                worksheet.Cell(currentRow, 14).Value = "TaskAssignedToUser";
                worksheet.Cell(currentRow, 15).Value = "TaskAssignedToDepartment";
                worksheet.Cell(currentRow, 16).Value = "TaskAssignedToRole";
                worksheet.Cell(currentRow, 17).Value = "TaskCreatedByUser";
                worksheet.Cell(currentRow, 18).Value = "TaskCreatedDate";
                worksheet.Cell(currentRow, 19).Value = "TaskCompletedByUser";
                worksheet.Cell(currentRow, 20).Value = "TaskCompletedDate";
                worksheet.Cell(currentRow, 21).Value = "BenchmarkDays";
                worksheet.Cell(currentRow, 22).Value = "BenchmarkDate";
                worksheet.Cell(currentRow, 23).Value = "ProductName";
                worksheet.Cell(currentRow, 24).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 25).Value = "BenefitCode";
                worksheet.Cell(currentRow, 26).Value = "BenefitDescription";
                worksheet.Cell(currentRow, 27).Value = "TaskCreatedByTeam";
                worksheet.Cell(currentRow, 28).Value = "TaskCompletedByTeam";
                worksheet.Cell(currentRow, 29).Value = "OriginalTaskTargetDate";
                worksheet.Cell(currentRow, 30).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 31).Value = "ClaimType";
                worksheet.Cell(currentRow, 32).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 33).Value = "ProductCode";
                worksheet.Cell(currentRow, 34).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 35).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 36).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 37).Value = "TaskInDepartment";
                worksheet.Cell(currentRow, 38).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CaseStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 6).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 8).Value = claim.TaskProcessStep;
                    worksheet.Cell(currentRow, 9).Value = claim.TaskId;
                    worksheet.Cell(currentRow, 10).Value = claim.TaskCode;
                    worksheet.Cell(currentRow, 11).Value = claim.TaskName;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskDescription;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.TaskAssignedToUser;
                    worksheet.Cell(currentRow, 15).Value = claim.TaskAssignedToDepartment;
                    worksheet.Cell(currentRow, 16).Value = claim.TaskAssignedToRole;
                    worksheet.Cell(currentRow, 17).Value = claim.TaskCreatedByUser;
                    worksheet.Cell(currentRow, 18).Value = claim.TaskCreatedDate;
                    worksheet.Cell(currentRow, 19).Value = claim.TaskCompletedByUser;
                    worksheet.Cell(currentRow, 20).Value = claim.TaskCompletedDate;
                    worksheet.Cell(currentRow, 21).Value = claim.BenchmarkDays;
                    worksheet.Cell(currentRow, 22).Value = claim.BenchmarkDate;
                    worksheet.Cell(currentRow, 23).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 24).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 25).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 26).Value = claim.BenefitDescription;
                    worksheet.Cell(currentRow, 27).Value = claim.TaskCreatedByTeam;
                    worksheet.Cell(currentRow, 28).Value = claim.TaskCompletedByTeam;
                    worksheet.Cell(currentRow, 29).Value = claim.OriginalTaskTargetDate;
                    worksheet.Cell(currentRow, 30).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 31).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 32).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 33).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 34).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 35).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 36).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 37).Value = claim.TaskInDepartment;
                    worksheet.Cell(currentRow, 38).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetTaskmv(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetTaskmv(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Taskmv");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " Taskmv";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.CaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskProcessStep"; worksheet.Cell(currentRow, 2).Value = claim.TaskProcessStep;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskId"; worksheet.Cell(currentRow, 2).Value = claim.TaskId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCode"; worksheet.Cell(currentRow, 2).Value = claim.TaskCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskName"; worksheet.Cell(currentRow, 2).Value = claim.TaskName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskDescription"; worksheet.Cell(currentRow, 2).Value = claim.TaskDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskStatus"; worksheet.Cell(currentRow, 2).Value = claim.TaskStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToDepartment"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToDepartment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToRole"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToRole;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDays"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDays;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDate"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTaskTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTaskTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskInDepartment"; worksheet.Cell(currentRow, 2).Value = claim.TaskInDepartment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);


                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptAbleusers(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptAbleuser(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptAbleuser");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptAbleuser";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "ClaimUserId";
                worksheet.Cell(currentRow, 2).Value = "LanId";
                worksheet.Cell(currentRow, 3).Value = "FullName";
                worksheet.Cell(currentRow, 4).Value = "JobTitle";
                worksheet.Cell(currentRow, 5).Value = "Mail";
                worksheet.Cell(currentRow, 6).Value = "Mobile";
                worksheet.Cell(currentRow, 7).Value = "DepartmentNumber";
                worksheet.Cell(currentRow, 8).Value = "ManagerLanId";
                worksheet.Cell(currentRow, 9).Value = "ManagerName";
                worksheet.Cell(currentRow, 10).Value = "ManagerMobile";
                worksheet.Cell(currentRow, 11).Value = "LastLogonDate";
                worksheet.Cell(currentRow, 12).Value = "DefaultDepartment";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.ClaimUserId;
                    worksheet.Cell(currentRow, 2).Value = claim.LanId;
                    worksheet.Cell(currentRow, 3).Value = claim.FullName;
                    worksheet.Cell(currentRow, 4).Value = claim.JobTitle;
                    worksheet.Cell(currentRow, 5).Value = claim.Mail;
                    worksheet.Cell(currentRow, 6).Value = claim.Mobile;
                    worksheet.Cell(currentRow, 7).Value = claim.DepartmentNumber;
                    worksheet.Cell(currentRow, 8).Value = claim.ManagerLanId;
                    worksheet.Cell(currentRow, 9).Value = claim.ManagerName;
                    worksheet.Cell(currentRow, 10).Value = claim.ManagerMobile;
                    worksheet.Cell(currentRow, 11).Value = claim.LastLogonDate;
                    worksheet.Cell(currentRow, 12).Value = claim.DefaultDepartment;

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

        public async Task<byte[]> GetRptAbleuser(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptAbleuser(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptAbleuser");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptAbleuser";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimUserId"; worksheet.Cell(currentRow, 2).Value = claim.ClaimUserId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LanId"; worksheet.Cell(currentRow, 2).Value = claim.LanId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FullName"; worksheet.Cell(currentRow, 2).Value = claim.FullName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "JobTitle"; worksheet.Cell(currentRow, 2).Value = claim.JobTitle;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mail"; worksheet.Cell(currentRow, 2).Value = claim.Mail;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mobile"; worksheet.Cell(currentRow, 2).Value = claim.Mobile;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DepartmentNumber"; worksheet.Cell(currentRow, 2).Value = claim.DepartmentNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerLanId"; worksheet.Cell(currentRow, 2).Value = claim.ManagerLanId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerName"; worksheet.Cell(currentRow, 2).Value = claim.ManagerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerMobile"; worksheet.Cell(currentRow, 2).Value = claim.ManagerMobile;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastLogonDate"; worksheet.Cell(currentRow, 2).Value = claim.LastLogonDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DefaultDepartment"; worksheet.Cell(currentRow, 2).Value = claim.DefaultDepartment;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptAbleusersallroles(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptAbleusersallrole(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptAbleusersallrole");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptAbleusersallrole";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "ClaimUserId";
                worksheet.Cell(currentRow, 2).Value = "LanId";
                worksheet.Cell(currentRow, 3).Value = "FullName";
                worksheet.Cell(currentRow, 4).Value = "JobTitle";
                worksheet.Cell(currentRow, 5).Value = "Mail";
                worksheet.Cell(currentRow, 6).Value = "Mobile";
                worksheet.Cell(currentRow, 7).Value = "DepartmentNumber";
                worksheet.Cell(currentRow, 8).Value = "ManagerLanId";
                worksheet.Cell(currentRow, 9).Value = "ManagerName";
                worksheet.Cell(currentRow, 10).Value = "ManagerMobile";
                worksheet.Cell(currentRow, 11).Value = "LastLogonDate";
                worksheet.Cell(currentRow, 12).Value = "Role";
                worksheet.Cell(currentRow, 13).Value = "DefaultDepartment";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.ClaimUserId;
                    worksheet.Cell(currentRow, 2).Value = claim.LanId;
                    worksheet.Cell(currentRow, 3).Value = claim.FullName;
                    worksheet.Cell(currentRow, 4).Value = claim.JobTitle;
                    worksheet.Cell(currentRow, 5).Value = claim.Mail;
                    worksheet.Cell(currentRow, 6).Value = claim.Mobile;
                    worksheet.Cell(currentRow, 7).Value = claim.DepartmentNumber;
                    worksheet.Cell(currentRow, 8).Value = claim.ManagerLanId;
                    worksheet.Cell(currentRow, 9).Value = claim.ManagerName;
                    worksheet.Cell(currentRow, 10).Value = claim.ManagerMobile;
                    worksheet.Cell(currentRow, 11).Value = claim.LastLogonDate;
                    worksheet.Cell(currentRow, 12).Value = claim.Role;
                    worksheet.Cell(currentRow, 13).Value = claim.DefaultDepartment;
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

        public async Task<byte[]> GetRptAbleusersallrole(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptAbleusersallrole(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptAbleusersallrole");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptAbleusersallrole";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimUserId"; worksheet.Cell(currentRow, 2).Value = claim.ClaimUserId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LanId"; worksheet.Cell(currentRow, 2).Value = claim.LanId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FullName"; worksheet.Cell(currentRow, 2).Value = claim.FullName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "JobTitle"; worksheet.Cell(currentRow, 2).Value = claim.JobTitle;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mail"; worksheet.Cell(currentRow, 2).Value = claim.Mail;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Mobile"; worksheet.Cell(currentRow, 2).Value = claim.Mobile;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DepartmentNumber"; worksheet.Cell(currentRow, 2).Value = claim.DepartmentNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerLanId"; worksheet.Cell(currentRow, 2).Value = claim.ManagerLanId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerName"; worksheet.Cell(currentRow, 2).Value = claim.ManagerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ManagerMobile"; worksheet.Cell(currentRow, 2).Value = claim.ManagerMobile;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastLogonDate"; worksheet.Cell(currentRow, 2).Value = claim.LastLogonDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Role"; worksheet.Cell(currentRow, 2).Value = claim.Role;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DefaultDepartment"; worksheet.Cell(currentRow, 2).Value = claim.DefaultDepartment;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetRptActionsservices(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptActionsservice(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptActionsservice");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptActionsservice";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimCase";
                worksheet.Cell(currentRow, 3).Value = "ClaimCreationDate";
                worksheet.Cell(currentRow, 4).Value = "NotificationDate";
                worksheet.Cell(currentRow, 5).Value = "IncurredDate";
                worksheet.Cell(currentRow, 6).Value = "CaseManager";
                worksheet.Cell(currentRow, 7).Value = "TeamManager";
                worksheet.Cell(currentRow, 8).Value = "TriageSegment";
                worksheet.Cell(currentRow, 9).Value = "DepartmentOfCase";
                worksheet.Cell(currentRow, 10).Value = "CmpCustomerGoal";
                worksheet.Cell(currentRow, 11).Value = "CmpGoalDate";
                worksheet.Cell(currentRow, 12).Value = "ActionName";
                worksheet.Cell(currentRow, 13).Value = "ActionStartDate";
                worksheet.Cell(currentRow, 14).Value = "ActionOpenDuration";
                worksheet.Cell(currentRow, 15).Value = "ActionOutcome";
                worksheet.Cell(currentRow, 16).Value = "ActionOutcomeReason";
                worksheet.Cell(currentRow, 17).Value = "ActionOutcomeComments";
                worksheet.Cell(currentRow, 18).Value = "ActionOutcomeDate";
                worksheet.Cell(currentRow, 19).Value = "ServiceCreatorActionOwner";
                worksheet.Cell(currentRow, 20).Value = "ServiceProvider";
                worksheet.Cell(currentRow, 21).Value = "ServiceCode";
                worksheet.Cell(currentRow, 22).Value = "ServiceName";
                worksheet.Cell(currentRow, 23).Value = "UnitsOfferedNumberOfHours";
                worksheet.Cell(currentRow, 24).Value = "RatePerHour";
                worksheet.Cell(currentRow, 25).Value = "TotalCosts";
                worksheet.Cell(currentRow, 26).Value = "ServiceStartDate";
                worksheet.Cell(currentRow, 27).Value = "ServiceEndDate";
                worksheet.Cell(currentRow, 28).Value = "PrimaryDiagnosis";
                worksheet.Cell(currentRow, 29).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 30).Value = "Occupation";
                worksheet.Cell(currentRow, 31).Value = "DeathBenefitCase";
                worksheet.Cell(currentRow, 32).Value = "BexBenefitCase";
                worksheet.Cell(currentRow, 33).Value = "IpBenefitCase";
                worksheet.Cell(currentRow, 34).Value = "TpdBenefitCase";
                worksheet.Cell(currentRow, 35).Value = "TtdBenefitCase";
                worksheet.Cell(currentRow, 36).Value = "TraumaBenefitCase";
                worksheet.Cell(currentRow, 37).Value = "StandAloneWopBenefitCase";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimCase;
                    worksheet.Cell(currentRow, 3).Value = claim.ClaimCreationDate;
                    worksheet.Cell(currentRow, 4).Value = claim.NotificationDate;
                    worksheet.Cell(currentRow, 5).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 6).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 7).Value = claim.TeamManager;
                    worksheet.Cell(currentRow, 8).Value = claim.TriageSegment;
                    worksheet.Cell(currentRow, 9).Value = claim.DepartmentOfCase;
                    worksheet.Cell(currentRow, 10).Value = claim.CmpCustomerGoal;
                    worksheet.Cell(currentRow, 11).Value = claim.CmpGoalDate;
                    worksheet.Cell(currentRow, 12).Value = claim.ActionName;
                    worksheet.Cell(currentRow, 13).Value = claim.ActionStartDate;
                    worksheet.Cell(currentRow, 14).Value = claim.ActionOpenDuration;
                    worksheet.Cell(currentRow, 15).Value = claim.ActionOutcome;
                    worksheet.Cell(currentRow, 16).Value = claim.ActionOutcomeReason;
                    worksheet.Cell(currentRow, 17).Value = claim.ActionOutcomeComments;
                    worksheet.Cell(currentRow, 18).Value = claim.ActionOutcomeDate;
                    worksheet.Cell(currentRow, 19).Value = claim.ServiceCreatorActionOwner;
                    worksheet.Cell(currentRow, 20).Value = claim.ServiceProvider;
                    worksheet.Cell(currentRow, 21).Value = claim.ServiceCode;
                    worksheet.Cell(currentRow, 22).Value = claim.ServiceName;
                    worksheet.Cell(currentRow, 23).Value = claim.UnitsOfferedNumberOfHours;
                    worksheet.Cell(currentRow, 24).Value = claim.RatePerHour;
                    worksheet.Cell(currentRow, 25).Value = claim.TotalCosts;
                    worksheet.Cell(currentRow, 26).Value = claim.ServiceStartDate;
                    worksheet.Cell(currentRow, 27).Value = claim.ServiceEndDate;
                    worksheet.Cell(currentRow, 28).Value = claim.PrimaryDiagnosis;
                    worksheet.Cell(currentRow, 29).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 30).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 31).Value = claim.DeathBenefitCase;
                    worksheet.Cell(currentRow, 32).Value = claim.BexBenefitCase;
                    worksheet.Cell(currentRow, 33).Value = claim.IpBenefitCase;
                    worksheet.Cell(currentRow, 34).Value = claim.TpdBenefitCase;
                    worksheet.Cell(currentRow, 35).Value = claim.TtdBenefitCase;
                    worksheet.Cell(currentRow, 36).Value = claim.TraumaBenefitCase;
                    worksheet.Cell(currentRow, 37).Value = claim.StandAloneWopBenefitCase;
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

        public async Task<byte[]> GetRptActionsservice(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptActionsservice(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptActionsservice");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptActionsservice";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimCase"; worksheet.Cell(currentRow, 2).Value = claim.ClaimCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NotificationDate"; worksheet.Cell(currentRow, 2).Value = claim.NotificationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TeamManager"; worksheet.Cell(currentRow, 2).Value = claim.TeamManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TriageSegment"; worksheet.Cell(currentRow, 2).Value = claim.TriageSegment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DepartmentOfCase"; worksheet.Cell(currentRow, 2).Value = claim.DepartmentOfCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpCustomerGoal"; worksheet.Cell(currentRow, 2).Value = claim.CmpCustomerGoal;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionName"; worksheet.Cell(currentRow, 2).Value = claim.ActionName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ActionStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOpenDuration"; worksheet.Cell(currentRow, 2).Value = claim.ActionOpenDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcome"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcomeReason"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcomeReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcomeComments"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcomeComments;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCreatorActionOwner"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCreatorActionOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceProvider"; worksheet.Cell(currentRow, 2).Value = claim.ServiceProvider;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCode"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceName"; worksheet.Cell(currentRow, 2).Value = claim.ServiceName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnitsOfferedNumberOfHours"; worksheet.Cell(currentRow, 2).Value = claim.UnitsOfferedNumberOfHours;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RatePerHour"; worksheet.Cell(currentRow, 2).Value = claim.RatePerHour;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TotalCosts"; worksheet.Cell(currentRow, 2).Value = claim.TotalCosts;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DeathBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.DeathBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BexBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.BexBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IpBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.IpBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.TpdBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TtdBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.TtdBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.TraumaBenefitCase;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StandAloneWopBenefitCase"; worksheet.Cell(currentRow, 2).Value = claim.StandAloneWopBenefitCase;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCaseactions(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCaseaction(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCaseaction");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " RptCaseaction";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 4).Value = "CaseType";
                worksheet.Cell(currentRow, 5).Value = "Status";
                worksheet.Cell(currentRow, 6).Value = "Reason";
                worksheet.Cell(currentRow, 7).Value = "ActionedBy";
                worksheet.Cell(currentRow, 8).Value = "ActionDate";
                worksheet.Cell(currentRow, 9).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 10).Value = "ClaimType";
                worksheet.Cell(currentRow, 11).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 5).Value = claim.Status;
                    worksheet.Cell(currentRow, 6).Value = claim.Reason;
                    worksheet.Cell(currentRow, 7).Value = claim.ActionedBy;
                    worksheet.Cell(currentRow, 8).Value = claim.ActionDate;
                    worksheet.Cell(currentRow, 9).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 10).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 11).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetRptCaseaction(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCaseaction(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCaseaction");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " RptCaseaction";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reason"; worksheet.Cell(currentRow, 2).Value = claim.Reason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionedBy"; worksheet.Cell(currentRow, 2).Value = claim.ActionedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionDate"; worksheet.Cell(currentRow, 2).Value = claim.ActionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimbenefitactuarialrecs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimbenefitactuarialrec(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitactuarialrec");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimbenefitactuarialrec";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "MonthEffectiveDate";
                worksheet.Cell(currentRow, 3).Value = "SourceSystem";
                worksheet.Cell(currentRow, 4).Value = "ProductName";
                worksheet.Cell(currentRow, 5).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 6).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 7).Value = "IndicativeClaimType";
                worksheet.Cell(currentRow, 8).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 9).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 10).Value = "CoverType";
                worksheet.Cell(currentRow, 11).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 12).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 13).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 14).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 15).Value = "GivenName";
                worksheet.Cell(currentRow, 16).Value = "Surname";
                worksheet.Cell(currentRow, 17).Value = "Sex";
                worksheet.Cell(currentRow, 18).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 19).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 20).Value = "Occupation";
                worksheet.Cell(currentRow, 21).Value = "OccupationCategory";
                worksheet.Cell(currentRow, 22).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 23).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 24).Value = "State";
                worksheet.Cell(currentRow, 25).Value = "PostCode";
                worksheet.Cell(currentRow, 26).Value = "CaseType";
                worksheet.Cell(currentRow, 27).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 28).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 29).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 30).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 31).Value = "IncurredDate";
                worksheet.Cell(currentRow, 32).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 34).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 35).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 36).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 37).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 38).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 39).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 40).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 41).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 42).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 43).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 44).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 45).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 46).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 47).Value = "ContractStatus";
                worksheet.Cell(currentRow, 48).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 49).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 50).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 51).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 52).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 53).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 54).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 55).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 56).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 57).Value = "InitialSumInsuredFreq";
                worksheet.Cell(currentRow, 58).Value = "TargetSumInsured";
                worksheet.Cell(currentRow, 59).Value = "TargetSumInsuredFreq";
                worksheet.Cell(currentRow, 60).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 61).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 62).Value = "Decision";
                worksheet.Cell(currentRow, 63).Value = "Accepted";
                worksheet.Cell(currentRow, 64).Value = "DecisionDate";
                worksheet.Cell(currentRow, 65).Value = "DecisionReason";
                worksheet.Cell(currentRow, 66).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 67).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 68).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 69).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 70).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 71).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 72).Value = "IndexationFrequency";
                worksheet.Cell(currentRow, 73).Value = "AgreedValue";
                worksheet.Cell(currentRow, 74).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 75).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 76).Value = "NumberOfReinsurers";
                worksheet.Cell(currentRow, 77).Value = "TotalReinsurancePercent";
                worksheet.Cell(currentRow, 78).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 79).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 80).Value = "RiskCategory";
                worksheet.Cell(currentRow, 81).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 82).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 83).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 84).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 85).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 86).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 87).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 88).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 89).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 90).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 91).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 92).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 93).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 94).Value = "Source";
                worksheet.Cell(currentRow, 95).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 96).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 97).Value = "BenefitType";
                worksheet.Cell(currentRow, 98).Value = "ProductCode";
                worksheet.Cell(currentRow, 99).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 100).Value = "PartyId";
                worksheet.Cell(currentRow, 101).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 102).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 103).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 104).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 105).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 106).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 107).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 108).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 109).Value = "CmpRequired";
                worksheet.Cell(currentRow, 110).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 111).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 112).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 113).Value = "UnexpectedCircumstances";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.MonthEffectiveDate;
                    worksheet.Cell(currentRow, 3).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 4).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 5).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 6).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 7).Value = claim.IndicativeClaimType;
                    worksheet.Cell(currentRow, 8).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 9).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 10).Value = claim.CoverType;
                    worksheet.Cell(currentRow, 11).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 12).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 13).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 15).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 16).Value = claim.Surname;
                    worksheet.Cell(currentRow, 17).Value = claim.Sex;
                    worksheet.Cell(currentRow, 18).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 19).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 20).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 21).Value = claim.OccupationCategory;
                    worksheet.Cell(currentRow, 22).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 23).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 24).Value = claim.State;
                    worksheet.Cell(currentRow, 25).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 26).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 27).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 28).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 29).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 30).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 31).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 32).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 34).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 35).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 36).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 37).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 38).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 39).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 40).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 41).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 42).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 43).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 44).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 45).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 46).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 47).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 48).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 49).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 50).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 51).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 52).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 53).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 54).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 55).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 56).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 57).Value = claim.InitialSumInsuredFreq;
                    worksheet.Cell(currentRow, 58).Value = claim.TargetSumInsured;
                    worksheet.Cell(currentRow, 59).Value = claim.TargetSumInsuredFreq;
                    worksheet.Cell(currentRow, 60).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 61).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 62).Value = claim.Decision;
                    worksheet.Cell(currentRow, 63).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 64).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 65).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 66).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 67).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 68).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 69).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 70).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 71).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 72).Value = claim.IndexationFrequency;
                    worksheet.Cell(currentRow, 73).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 74).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 75).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 76).Value = claim.NumberOfReinsurers;
                    worksheet.Cell(currentRow, 77).Value = claim.TotalReinsurancePercent;
                    worksheet.Cell(currentRow, 78).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 79).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 80).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 81).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 82).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 83).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 84).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 85).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 86).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 87).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 88).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 89).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 90).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 91).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 92).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 93).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 94).Value = claim.Source;
                    worksheet.Cell(currentRow, 95).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 96).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 97).Value = claim.BenefitType;
                    worksheet.Cell(currentRow, 98).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 99).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 100).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 101).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 102).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 103).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 104).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 105).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 106).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 107).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 108).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 109).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 110).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 111).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 112).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 113).Value = claim.UnexpectedCircumstances;
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

        public async Task<byte[]> GetRptClaimbenefitactuarialrec(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimbenefitactuarialrec(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitactuarialrec");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimbenefitactuarialrec";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MonthEffectiveDate"; worksheet.Cell(currentRow, 2).Value = claim.MonthEffectiveDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndicativeClaimType"; worksheet.Cell(currentRow, 2).Value = claim.IndicativeClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverType"; worksheet.Cell(currentRow, 2).Value = claim.CoverType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationCategory"; worksheet.Cell(currentRow, 2).Value = claim.OccupationCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.TargetSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.TargetSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFrequency"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NumberOfReinsurers"; worksheet.Cell(currentRow, 2).Value = claim.NumberOfReinsurers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TotalReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.TotalReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimBenefitactuarialrecls(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimBenefitactuarialrecl(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimBenefitactuarialrecl");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimBenefitactuarialrecl";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "MonthEffectiveDate";
                worksheet.Cell(currentRow, 3).Value = "SourceSystem";
                worksheet.Cell(currentRow, 4).Value = "ProductName";
                worksheet.Cell(currentRow, 5).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 6).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 7).Value = "IndicativeClaimType";
                worksheet.Cell(currentRow, 8).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 9).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 10).Value = "CoverType";
                worksheet.Cell(currentRow, 11).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 12).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 13).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 14).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 15).Value = "GivenName";
                worksheet.Cell(currentRow, 16).Value = "Surname";
                worksheet.Cell(currentRow, 17).Value = "Sex";
                worksheet.Cell(currentRow, 18).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 19).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 20).Value = "Occupation";
                worksheet.Cell(currentRow, 21).Value = "OccupationCategory";
                worksheet.Cell(currentRow, 22).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 23).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 24).Value = "State";
                worksheet.Cell(currentRow, 25).Value = "PostCode";
                worksheet.Cell(currentRow, 26).Value = "CaseType";
                worksheet.Cell(currentRow, 27).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 28).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 29).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 30).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 31).Value = "IncurredDate";
                worksheet.Cell(currentRow, 32).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 34).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 35).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 36).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 37).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 38).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 39).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 40).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 41).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 42).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 43).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 44).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 45).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 46).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 47).Value = "ContractStatus";
                worksheet.Cell(currentRow, 48).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 49).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 50).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 51).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 52).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 53).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 54).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 55).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 56).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 57).Value = "TargetSumInsured";
                worksheet.Cell(currentRow, 58).Value = "TargetSumInsuredFreq";
                worksheet.Cell(currentRow, 59).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 60).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 61).Value = "Decision";
                worksheet.Cell(currentRow, 62).Value = "Accepted";
                worksheet.Cell(currentRow, 63).Value = "DecisionDate";
                worksheet.Cell(currentRow, 64).Value = "DecisionReason";
                worksheet.Cell(currentRow, 65).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 66).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 67).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 68).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 69).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 70).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 71).Value = "IndexationFrequency";
                worksheet.Cell(currentRow, 72).Value = "AgreedValue";
                worksheet.Cell(currentRow, 73).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 74).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 75).Value = "NumberOfReinsurers";
                worksheet.Cell(currentRow, 76).Value = "TotalReinsurancePercent";
                worksheet.Cell(currentRow, 77).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 78).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 79).Value = "RiskCategory";
                worksheet.Cell(currentRow, 80).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 81).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 82).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 83).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 84).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 85).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 86).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 87).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 88).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 89).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 90).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 91).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 92).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 93).Value = "Source";
                worksheet.Cell(currentRow, 94).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 95).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 96).Value = "BenefitType";
                worksheet.Cell(currentRow, 97).Value = "ProductCode";
                worksheet.Cell(currentRow, 98).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 99).Value = "PartyId";
                worksheet.Cell(currentRow, 100).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 101).Value = "QualifyingPeriod";
                worksheet.Cell(currentRow, 102).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 103).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 104).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 105).Value = "PaymentAuthorized";
                worksheet.Cell(currentRow, 106).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 107).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 108).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 109).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 110).Value = "CmpRequired";
                worksheet.Cell(currentRow, 111).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 112).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 113).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 114).Value = "UnexpectedCircumstances";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.MonthEffectiveDate;
                    worksheet.Cell(currentRow, 3).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 4).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 5).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 6).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 7).Value = claim.IndicativeClaimType;
                    worksheet.Cell(currentRow, 8).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 9).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 10).Value = claim.CoverType;
                    worksheet.Cell(currentRow, 11).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 12).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 13).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 15).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 16).Value = claim.Surname;
                    worksheet.Cell(currentRow, 17).Value = claim.Sex;
                    worksheet.Cell(currentRow, 18).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 19).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 20).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 21).Value = claim.OccupationCategory;
                    worksheet.Cell(currentRow, 22).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 23).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 24).Value = claim.State;
                    worksheet.Cell(currentRow, 25).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 26).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 27).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 28).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 29).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 30).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 31).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 32).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 34).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 35).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 36).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 37).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 38).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 39).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 40).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 41).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 42).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 43).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 44).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 45).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 46).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 47).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 48).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 49).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 50).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 51).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 52).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 53).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 54).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 55).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 56).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 57).Value = claim.TargetSumInsured;
                    worksheet.Cell(currentRow, 58).Value = claim.TargetSumInsuredFreq;
                    worksheet.Cell(currentRow, 59).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 60).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 61).Value = claim.Decision;
                    worksheet.Cell(currentRow, 62).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 63).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 64).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 65).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 66).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 67).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 68).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 69).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 70).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 71).Value = claim.IndexationFrequency;
                    worksheet.Cell(currentRow, 72).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 73).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 74).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 75).Value = claim.NumberOfReinsurers;
                    worksheet.Cell(currentRow, 76).Value = claim.TotalReinsurancePercent;
                    worksheet.Cell(currentRow, 77).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 78).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 79).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 80).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 81).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 82).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 83).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 84).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 85).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 86).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 87).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 88).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 89).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 90).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 91).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 92).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 93).Value = claim.Source;
                    worksheet.Cell(currentRow, 94).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 95).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 96).Value = claim.BenefitType;
                    worksheet.Cell(currentRow, 97).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 98).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 99).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 100).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 101).Value = claim.QualifyingPeriod;
                    worksheet.Cell(currentRow, 102).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 103).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 104).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 105).Value = claim.PaymentAuthorized;
                    worksheet.Cell(currentRow, 106).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 107).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 108).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 109).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 110).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 111).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 112).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 113).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 114).Value = claim.UnexpectedCircumstances;
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

        public async Task<byte[]> GetRptClaimBenefitactuarialrecl(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimBenefitactuarialrecl(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimBenefitactuarialrecl");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimBenefitactuarialrecl";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MonthEffectiveDate"; worksheet.Cell(currentRow, 2).Value = claim.MonthEffectiveDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndicativeClaimType"; worksheet.Cell(currentRow, 2).Value = claim.IndicativeClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverType"; worksheet.Cell(currentRow, 2).Value = claim.CoverType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationCategory"; worksheet.Cell(currentRow, 2).Value = claim.OccupationCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.TargetSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.TargetSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFrequency"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NumberOfReinsurers"; worksheet.Cell(currentRow, 2).Value = claim.NumberOfReinsurers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TotalReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.TotalReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "QualifyingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.QualifyingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentAuthorized"; worksheet.Cell(currentRow, 2).Value = claim.PaymentAuthorized;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimbenefitgroups(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimbenefitgroup(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitgroup");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimbenefitgroup";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 4).Value = "GivenName";
                worksheet.Cell(currentRow, 5).Value = "Surname";
                worksheet.Cell(currentRow, 6).Value = "Sex";
                worksheet.Cell(currentRow, 7).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 8).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 9).Value = "Occupation";
                worksheet.Cell(currentRow, 10).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 11).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 12).Value = "State";
                worksheet.Cell(currentRow, 13).Value = "PostCode";
                worksheet.Cell(currentRow, 14).Value = "CaseType";
                worksheet.Cell(currentRow, 15).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 16).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 17).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 18).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 19).Value = "IncurredDate";
                worksheet.Cell(currentRow, 20).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 21).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 22).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 23).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 24).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 25).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 26).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 27).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 28).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 29).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 30).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 31).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 32).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 34).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 35).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 36).Value = "ContractStatus";
                worksheet.Cell(currentRow, 37).Value = "ProductName";
                worksheet.Cell(currentRow, 38).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 39).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 40).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 41).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 42).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 43).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 44).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 45).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 46).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 47).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 48).Value = "SumInsured";
                worksheet.Cell(currentRow, 49).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 50).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 51).Value = "Decision";
                worksheet.Cell(currentRow, 52).Value = "Accepted";
                worksheet.Cell(currentRow, 53).Value = "DecisionDate";
                worksheet.Cell(currentRow, 54).Value = "DecisionReason";
                worksheet.Cell(currentRow, 55).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 56).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 57).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 58).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 59).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 60).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 61).Value = "AgreedValue";
                worksheet.Cell(currentRow, 62).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 63).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 64).Value = "ReInsurerName";
                worksheet.Cell(currentRow, 65).Value = "ReinsuranceTreatyType";
                worksheet.Cell(currentRow, 66).Value = "ReinsurancePercent";
                worksheet.Cell(currentRow, 67).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 68).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 69).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 70).Value = "RiskCategory";
                worksheet.Cell(currentRow, 71).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 72).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 73).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 74).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 75).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 76).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 77).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 78).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 79).Value = "InitialSumInsuredX12";
                worksheet.Cell(currentRow, 80).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 81).Value = "SumReInsured";
                worksheet.Cell(currentRow, 82).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 83).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 84).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 85).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 86).Value = "Source";
                worksheet.Cell(currentRow, 87).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 88).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 89).Value = "SourceSystem";
                worksheet.Cell(currentRow, 90).Value = "ClaimType";
                worksheet.Cell(currentRow, 91).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 92).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 93).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 94).Value = "InitialSumInsuredFreq";
                worksheet.Cell(currentRow, 95).Value = "PrimaryOccSelfEmployedInd";
                worksheet.Cell(currentRow, 96).Value = "TpdDefinition";
                worksheet.Cell(currentRow, 97).Value = "TpdSubDefinition";
                worksheet.Cell(currentRow, 98).Value = "TraumaDefinition";
                worksheet.Cell(currentRow, 99).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 100).Value = "ProductCode";
                worksheet.Cell(currentRow, 101).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 102).Value = "PartyId";
                worksheet.Cell(currentRow, 103).Value = "Declined";
                worksheet.Cell(currentRow, 104).Value = "QualifyingPeriod";
                worksheet.Cell(currentRow, 105).Value = "ExpectedResolutionDate";
                worksheet.Cell(currentRow, 106).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 107).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 108).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 109).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 110).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 111).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 112).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 113).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 114).Value = "CmpRequired";
                worksheet.Cell(currentRow, 115).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 116).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 117).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 118).Value = "UnexpectedCircumstances";
                worksheet.Cell(currentRow, 119).Value = "CoverageNumber";
                worksheet.Cell(currentRow, 120).Value = "AssessedUnderLimitedCover";
                worksheet.Cell(currentRow, 121).Value = "ClaimReceivedDate";
                worksheet.Cell(currentRow, 122).Value = "CustomerContactFrequency";
                worksheet.Cell(currentRow, 123).Value = "UnexpectedCircumstancesApply";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 5).Value = claim.Surname;
                    worksheet.Cell(currentRow, 6).Value = claim.Sex;
                    worksheet.Cell(currentRow, 7).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 8).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 9).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 10).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 11).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 12).Value = claim.State;
                    worksheet.Cell(currentRow, 13).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 14).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 15).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 16).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 17).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 18).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 19).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 20).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 21).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 22).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 23).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 24).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 25).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 26).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 27).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 28).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 29).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 31).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 32).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 34).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 35).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 36).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 37).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 38).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 39).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 40).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 41).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 42).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 43).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 44).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 45).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 46).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 47).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 48).Value = claim.SumInsured;
                    worksheet.Cell(currentRow, 49).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 50).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 51).Value = claim.Decision;
                    worksheet.Cell(currentRow, 52).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 53).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 54).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 55).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 56).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 57).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 58).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 59).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 60).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 61).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 62).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 63).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 64).Value = claim.ReInsurerName;
                    worksheet.Cell(currentRow, 65).Value = claim.ReinsuranceTreatyType;
                    worksheet.Cell(currentRow, 66).Value = claim.ReinsurancePercent;
                    worksheet.Cell(currentRow, 67).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 68).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 69).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 70).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 71).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 72).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 73).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 74).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 75).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 76).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 77).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 78).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 79).Value = claim.InitialSumInsuredX12;
                    worksheet.Cell(currentRow, 80).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 81).Value = claim.SumReInsured;
                    worksheet.Cell(currentRow, 82).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 83).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 84).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 85).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 86).Value = claim.Source;
                    worksheet.Cell(currentRow, 87).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 88).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 89).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 90).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 91).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 92).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 93).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 94).Value = claim.InitialSumInsuredFreq;
                    worksheet.Cell(currentRow, 95).Value = claim.PrimaryOccSelfEmployedInd;
                    worksheet.Cell(currentRow, 96).Value = claim.TpdDefinition;
                    worksheet.Cell(currentRow, 97).Value = claim.TpdSubDefinition;
                    worksheet.Cell(currentRow, 98).Value = claim.TraumaDefinition;
                    worksheet.Cell(currentRow, 99).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 100).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 101).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 102).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 103).Value = claim.Declined;
                    worksheet.Cell(currentRow, 104).Value = claim.QualifyingPeriod;
                    worksheet.Cell(currentRow, 105).Value = claim.ExpectedResolutionDate;
                    worksheet.Cell(currentRow, 106).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 107).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 108).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 109).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 110).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 111).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 112).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 113).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 114).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 115).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 116).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 117).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 118).Value = claim.UnexpectedCircumstances;
                    worksheet.Cell(currentRow, 119).Value = claim.CoverageNumber;
                    worksheet.Cell(currentRow, 120).Value = claim.AssessedUnderLimitedCover;
                    worksheet.Cell(currentRow, 121).Value = claim.ClaimReceivedDate;
                    worksheet.Cell(currentRow, 122).Value = claim.CustomerContactFrequency;
                    worksheet.Cell(currentRow, 123).Value = claim.UnexpectedCircumstancesApply;
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

        public async Task<byte[]> GetRptClaimbenefitgroup(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimbenefitgroup(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitgroup");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimbenefitgroup";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReInsurerName"; worksheet.Cell(currentRow, 2).Value = claim.ReInsurerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsuranceTreatyType"; worksheet.Cell(currentRow, 2).Value = claim.ReinsuranceTreatyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.ReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredX12"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredX12;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumReInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumReInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccSelfEmployedInd"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccSelfEmployedInd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdSubDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdSubDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TraumaDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Declined"; worksheet.Cell(currentRow, 2).Value = claim.Declined;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "QualifyingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.QualifyingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedResolutionDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedResolutionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverageNumber"; worksheet.Cell(currentRow, 2).Value = claim.CoverageNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AssessedUnderLimitedCover"; worksheet.Cell(currentRow, 2).Value = claim.AssessedUnderLimitedCover;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReceivedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReceivedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerContactFrequency"; worksheet.Cell(currentRow, 2).Value = claim.CustomerContactFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstancesApply"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstancesApply;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimbenefitreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimbenefitreinsurance(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitreinsurance");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimbenefitreinsurance";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 4).Value = "GivenName";
                worksheet.Cell(currentRow, 5).Value = "Surname";
                worksheet.Cell(currentRow, 6).Value = "Sex";
                worksheet.Cell(currentRow, 7).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 8).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 9).Value = "Occupation";
                worksheet.Cell(currentRow, 10).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 11).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 12).Value = "State";
                worksheet.Cell(currentRow, 13).Value = "PostCode";
                worksheet.Cell(currentRow, 14).Value = "CaseType";
                worksheet.Cell(currentRow, 15).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 16).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 17).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 18).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 19).Value = "IncurredDate";
                worksheet.Cell(currentRow, 20).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 21).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 22).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 23).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 24).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 25).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 26).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 27).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 28).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 29).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 30).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 31).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 32).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 34).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 35).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 36).Value = "ContractStatus";
                worksheet.Cell(currentRow, 37).Value = "ProductName";
                worksheet.Cell(currentRow, 38).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 39).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 40).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 41).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 42).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 43).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 44).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 45).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 46).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 47).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 48).Value = "SumInsured";
                worksheet.Cell(currentRow, 49).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 50).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 51).Value = "Decision";
                worksheet.Cell(currentRow, 52).Value = "Accepted";
                worksheet.Cell(currentRow, 53).Value = "DecisionDate";
                worksheet.Cell(currentRow, 54).Value = "DecisionReason";
                worksheet.Cell(currentRow, 55).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 56).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 57).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 58).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 59).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 60).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 61).Value = "AgreedValue";
                worksheet.Cell(currentRow, 62).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 63).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 64).Value = "ReInsurerName";
                worksheet.Cell(currentRow, 65).Value = "ReinsuranceTreatyType";
                worksheet.Cell(currentRow, 66).Value = "ReinsurancePercent";
                worksheet.Cell(currentRow, 67).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 68).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 69).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 70).Value = "RiskCategory";
                worksheet.Cell(currentRow, 71).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 72).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 73).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 74).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 75).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 76).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 77).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 78).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 79).Value = "InitialSumInsuredX12";
                worksheet.Cell(currentRow, 80).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 81).Value = "SumReInsured";
                worksheet.Cell(currentRow, 82).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 83).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 84).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 85).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 86).Value = "Source";
                worksheet.Cell(currentRow, 87).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 88).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 89).Value = "SourceSystem";
                worksheet.Cell(currentRow, 90).Value = "ClaimType";
                worksheet.Cell(currentRow, 91).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 92).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 93).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 94).Value = "InitialSumInsuredFreq";
                worksheet.Cell(currentRow, 95).Value = "PrimaryOccSelfEmployedInd";
                worksheet.Cell(currentRow, 96).Value = "TpdDefinition";
                worksheet.Cell(currentRow, 97).Value = "TpdSubDefinition";
                worksheet.Cell(currentRow, 98).Value = "TraumaDefinition";
                worksheet.Cell(currentRow, 99).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 100).Value = "ProductCode";
                worksheet.Cell(currentRow, 101).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 102).Value = "PartyId";
                worksheet.Cell(currentRow, 103).Value = "Declined";
                worksheet.Cell(currentRow, 104).Value = "QualifyingPeriod";
                worksheet.Cell(currentRow, 105).Value = "ExpectedResolutionDate";
                worksheet.Cell(currentRow, 106).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 107).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 108).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 109).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 110).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 111).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 112).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 113).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 114).Value = "CmpRequired";
                worksheet.Cell(currentRow, 115).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 116).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 117).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 118).Value = "UnexpectedCircumstances";
                worksheet.Cell(currentRow, 119).Value = "CoverageNumber";
                worksheet.Cell(currentRow, 120).Value = "AssessedUnderLimitedCover";
                worksheet.Cell(currentRow, 121).Value = "ClaimReceivedDate";
                worksheet.Cell(currentRow, 122).Value = "CustomerContactFrequency";
                worksheet.Cell(currentRow, 123).Value = "UnexpectedCircumstancesApply";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 5).Value = claim.Surname;
                    worksheet.Cell(currentRow, 6).Value = claim.Sex;
                    worksheet.Cell(currentRow, 7).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 8).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 9).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 10).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 11).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 12).Value = claim.State;
                    worksheet.Cell(currentRow, 13).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 14).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 15).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 16).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 17).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 18).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 19).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 20).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 21).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 22).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 23).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 24).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 25).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 26).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 27).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 28).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 29).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 31).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 32).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 34).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 35).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 36).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 37).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 38).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 39).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 40).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 41).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 42).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 43).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 44).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 45).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 46).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 47).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 48).Value = claim.SumInsured;
                    worksheet.Cell(currentRow, 49).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 50).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 51).Value = claim.Decision;
                    worksheet.Cell(currentRow, 52).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 53).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 54).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 55).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 56).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 57).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 58).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 59).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 60).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 61).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 62).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 63).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 64).Value = claim.ReInsurerName;
                    worksheet.Cell(currentRow, 65).Value = claim.ReinsuranceTreatyType;
                    worksheet.Cell(currentRow, 66).Value = claim.ReinsurancePercent;
                    worksheet.Cell(currentRow, 67).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 68).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 69).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 70).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 71).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 72).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 73).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 74).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 75).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 76).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 77).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 78).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 79).Value = claim.InitialSumInsuredX12;
                    worksheet.Cell(currentRow, 80).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 81).Value = claim.SumReInsured;
                    worksheet.Cell(currentRow, 82).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 83).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 84).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 85).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 86).Value = claim.Source;
                    worksheet.Cell(currentRow, 87).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 88).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 89).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 90).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 91).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 92).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 93).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 94).Value = claim.InitialSumInsuredFreq;
                    worksheet.Cell(currentRow, 95).Value = claim.PrimaryOccSelfEmployedInd;
                    worksheet.Cell(currentRow, 96).Value = claim.TpdDefinition;
                    worksheet.Cell(currentRow, 97).Value = claim.TpdSubDefinition;
                    worksheet.Cell(currentRow, 98).Value = claim.TraumaDefinition;
                    worksheet.Cell(currentRow, 99).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 100).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 101).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 102).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 103).Value = claim.Declined;
                    worksheet.Cell(currentRow, 104).Value = claim.QualifyingPeriod;
                    worksheet.Cell(currentRow, 105).Value = claim.ExpectedResolutionDate;
                    worksheet.Cell(currentRow, 106).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 107).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 108).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 109).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 110).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 111).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 112).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 113).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 114).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 115).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 116).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 117).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 118).Value = claim.UnexpectedCircumstances;
                    worksheet.Cell(currentRow, 119).Value = claim.CoverageNumber;
                    worksheet.Cell(currentRow, 120).Value = claim.AssessedUnderLimitedCover;
                    worksheet.Cell(currentRow, 121).Value = claim.ClaimReceivedDate;
                    worksheet.Cell(currentRow, 122).Value = claim.CustomerContactFrequency;
                    worksheet.Cell(currentRow, 123).Value = claim.UnexpectedCircumstancesApply;
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

        public async Task<byte[]> GetRptClaimbenefitreinsurance(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimbenefitreinsurance(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitreinsurance");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimbenefitreinsurance";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReInsurerName"; worksheet.Cell(currentRow, 2).Value = claim.ReInsurerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsuranceTreatyType"; worksheet.Cell(currentRow, 2).Value = claim.ReinsuranceTreatyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.ReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredX12"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredX12;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumReInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumReInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccSelfEmployedInd"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccSelfEmployedInd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdSubDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdSubDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TraumaDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Declined"; worksheet.Cell(currentRow, 2).Value = claim.Declined;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "QualifyingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.QualifyingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedResolutionDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedResolutionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverageNumber"; worksheet.Cell(currentRow, 2).Value = claim.CoverageNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AssessedUnderLimitedCover"; worksheet.Cell(currentRow, 2).Value = claim.AssessedUnderLimitedCover;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReceivedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReceivedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerContactFrequency"; worksheet.Cell(currentRow, 2).Value = claim.CustomerContactFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstancesApply"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstancesApply;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimbenefitws(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimbenefitw(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitw");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimbenefitw";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 4).Value = "GivenName";
                worksheet.Cell(currentRow, 5).Value = "Surname";
                worksheet.Cell(currentRow, 6).Value = "Sex";
                worksheet.Cell(currentRow, 7).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 8).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 9).Value = "Occupation";
                worksheet.Cell(currentRow, 10).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 11).Value = "PreDisabilityIncome";
                worksheet.Cell(currentRow, 12).Value = "State";
                worksheet.Cell(currentRow, 13).Value = "PostCode";
                worksheet.Cell(currentRow, 14).Value = "CaseType";
                worksheet.Cell(currentRow, 15).Value = "CurrentClaimOwner";
                worksheet.Cell(currentRow, 16).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 17).Value = "RegistrationDate";
                worksheet.Cell(currentRow, 18).Value = "FirstContactDate";
                worksheet.Cell(currentRow, 19).Value = "IncurredDate";
                worksheet.Cell(currentRow, 20).Value = "AgeAtIncurredDate";
                worksheet.Cell(currentRow, 21).Value = "ClaimEventType";
                worksheet.Cell(currentRow, 22).Value = "PrimaryCauseCode";
                worksheet.Cell(currentRow, 23).Value = "PrimaryCauseDescription";
                worksheet.Cell(currentRow, 24).Value = "PrimaryCauseDate";
                worksheet.Cell(currentRow, 25).Value = "SecondaryCauseCode";
                worksheet.Cell(currentRow, 26).Value = "SecondaryCauseDescription";
                worksheet.Cell(currentRow, 27).Value = "SecondaryCauseDate";
                worksheet.Cell(currentRow, 28).Value = "ExpectedReturnToWorkDate";
                worksheet.Cell(currentRow, 29).Value = "CeasedWorkDate";
                worksheet.Cell(currentRow, 30).Value = "ClaimFinalisedDate";
                worksheet.Cell(currentRow, 31).Value = "ClaimFinalisedReason";
                worksheet.Cell(currentRow, 32).Value = "ClaimReopenDate";
                worksheet.Cell(currentRow, 33).Value = "ClaimReopenReason";
                worksheet.Cell(currentRow, 34).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 35).Value = "ContractStartDate";
                worksheet.Cell(currentRow, 36).Value = "ContractStatus";
                worksheet.Cell(currentRow, 37).Value = "ProductName";
                worksheet.Cell(currentRow, 38).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 39).Value = "TargetBenefitCode";
                worksheet.Cell(currentRow, 40).Value = "TargetBenefitDescription";
                worksheet.Cell(currentRow, 41).Value = "BenefitStatus";
                worksheet.Cell(currentRow, 42).Value = "RiskCommencedDate";
                worksheet.Cell(currentRow, 43).Value = "RiskExpiryDate";
                worksheet.Cell(currentRow, 44).Value = "WaitingPeriodAccident";
                worksheet.Cell(currentRow, 45).Value = "WaitingPeriodSickness";
                worksheet.Cell(currentRow, 46).Value = "BenefitPeriodAccident";
                worksheet.Cell(currentRow, 47).Value = "BenefitPeriodSickness";
                worksheet.Cell(currentRow, 48).Value = "SumInsured";
                worksheet.Cell(currentRow, 49).Value = "CalculationStartType";
                worksheet.Cell(currentRow, 50).Value = "CalculationEndType";
                worksheet.Cell(currentRow, 51).Value = "Decision";
                worksheet.Cell(currentRow, 52).Value = "Accepted";
                worksheet.Cell(currentRow, 53).Value = "DecisionDate";
                worksheet.Cell(currentRow, 54).Value = "DecisionReason";
                worksheet.Cell(currentRow, 55).Value = "FinalisedDate";
                worksheet.Cell(currentRow, 56).Value = "FinalisedReason";
                worksheet.Cell(currentRow, 57).Value = "BenefitReopenDate";
                worksheet.Cell(currentRow, 58).Value = "BenefitReopenReason";
                worksheet.Cell(currentRow, 59).Value = "SuperContributionPercent";
                worksheet.Cell(currentRow, 60).Value = "IndexationFlag";
                worksheet.Cell(currentRow, 61).Value = "AgreedValue";
                worksheet.Cell(currentRow, 62).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 63).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 64).Value = "ReInsurerName";
                worksheet.Cell(currentRow, 65).Value = "ReinsuranceTreatyType";
                worksheet.Cell(currentRow, 66).Value = "ReinsurancePercent";
                worksheet.Cell(currentRow, 67).Value = "AdviserSalesId";
                worksheet.Cell(currentRow, 68).Value = "GroupPlanName";
                worksheet.Cell(currentRow, 69).Value = "GroupPlanNumber";
                worksheet.Cell(currentRow, 70).Value = "RiskCategory";
                worksheet.Cell(currentRow, 71).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 72).Value = "OverrideRiskCategoryReason";
                worksheet.Cell(currentRow, 73).Value = "PrimaryOccupationStartDate";
                worksheet.Cell(currentRow, 74).Value = "PrimaryOccupationEndDate";
                worksheet.Cell(currentRow, 75).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 76).Value = "ExternalMemberNumber";
                worksheet.Cell(currentRow, 77).Value = "BenefitCreationDate";
                worksheet.Cell(currentRow, 78).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 79).Value = "InitialSumInsuredX12";
                worksheet.Cell(currentRow, 80).Value = "ContractEndDate";
                worksheet.Cell(currentRow, 81).Value = "SumReInsured";
                worksheet.Cell(currentRow, 82).Value = "PartialEarningsIncome";
                worksheet.Cell(currentRow, 83).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 84).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 85).Value = "MaximumIndexationRate";
                worksheet.Cell(currentRow, 86).Value = "Source";
                worksheet.Cell(currentRow, 87).Value = "IncidentOccurredOverseas";
                worksheet.Cell(currentRow, 88).Value = "CountryOfIncident";
                worksheet.Cell(currentRow, 89).Value = "SourceSystem";
                worksheet.Cell(currentRow, 90).Value = "ClaimType";
                worksheet.Cell(currentRow, 91).Value = "SourceBenefitCode";
                worksheet.Cell(currentRow, 92).Value = "SourceBenefitDescription";
                worksheet.Cell(currentRow, 93).Value = "InitialSumInsured";
                worksheet.Cell(currentRow, 94).Value = "InitialSumInsuredFreq";
                worksheet.Cell(currentRow, 95).Value = "PrimaryOccSelfEmployedInd";
                worksheet.Cell(currentRow, 96).Value = "TpdDefinition";
                worksheet.Cell(currentRow, 97).Value = "TpdSubDefinition";
                worksheet.Cell(currentRow, 98).Value = "TraumaDefinition";
                worksheet.Cell(currentRow, 99).Value = "SourceBenefitType";
                worksheet.Cell(currentRow, 100).Value = "ProductCode";
                worksheet.Cell(currentRow, 101).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 102).Value = "PartyId";
                worksheet.Cell(currentRow, 103).Value = "Declined";
                worksheet.Cell(currentRow, 104).Value = "QualifyingPeriod";
                worksheet.Cell(currentRow, 105).Value = "ExpectedResolutionDate";
                worksheet.Cell(currentRow, 106).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 107).Value = "SourceBenefitSelected";
                worksheet.Cell(currentRow, 108).Value = "ConcurrentClaimIndicator";
                worksheet.Cell(currentRow, 109).Value = "ConcurrentClaimNumbers";
                worksheet.Cell(currentRow, 110).Value = "WorkStatusType";
                worksheet.Cell(currentRow, 111).Value = "StartDate";
                worksheet.Cell(currentRow, 112).Value = "PartialCapacity";
                worksheet.Cell(currentRow, 113).Value = "EndDate";
                worksheet.Cell(currentRow, 114).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 115).Value = "ExpectedRtwFtRange";
                worksheet.Cell(currentRow, 116).Value = "AdmitAdvancePayAndFinalise";
                worksheet.Cell(currentRow, 117).Value = "NonDisclosure";
                worksheet.Cell(currentRow, 118).Value = "CmpRequired";
                worksheet.Cell(currentRow, 119).Value = "UrgentFinancialNeedsFlag";
                worksheet.Cell(currentRow, 120).Value = "SpecialArrangementFlag";
                worksheet.Cell(currentRow, 121).Value = "SpecialArrangementDuration";
                worksheet.Cell(currentRow, 122).Value = "UnexpectedCircumstances";
                worksheet.Cell(currentRow, 123).Value = "CoverageNumber";
                worksheet.Cell(currentRow, 124).Value = "AssessedUnderLimitedCover";
                worksheet.Cell(currentRow, 125).Value = "ClaimReceivedDate";
                worksheet.Cell(currentRow, 126).Value = "CustomerContactFrequency";
                worksheet.Cell(currentRow, 127).Value = "UnexpectedCircumstancesApply";
                worksheet.Cell(currentRow, 128).Value = "IarCode";
                worksheet.Cell(currentRow, 129).Value = "IarDescription";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 5).Value = claim.Surname;
                    worksheet.Cell(currentRow, 6).Value = claim.Sex;
                    worksheet.Cell(currentRow, 7).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 8).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 9).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 10).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 11).Value = claim.PreDisabilityIncome;
                    worksheet.Cell(currentRow, 12).Value = claim.State;
                    worksheet.Cell(currentRow, 13).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 14).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 15).Value = claim.CurrentClaimOwner;
                    worksheet.Cell(currentRow, 16).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 17).Value = claim.RegistrationDate;
                    worksheet.Cell(currentRow, 18).Value = claim.FirstContactDate;
                    worksheet.Cell(currentRow, 19).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 20).Value = claim.AgeAtIncurredDate;
                    worksheet.Cell(currentRow, 21).Value = claim.ClaimEventType;
                    worksheet.Cell(currentRow, 22).Value = claim.PrimaryCauseCode;
                    worksheet.Cell(currentRow, 23).Value = claim.PrimaryCauseDescription;
                    worksheet.Cell(currentRow, 24).Value = claim.PrimaryCauseDate;
                    worksheet.Cell(currentRow, 25).Value = claim.SecondaryCauseCode;
                    worksheet.Cell(currentRow, 26).Value = claim.SecondaryCauseDescription;
                    worksheet.Cell(currentRow, 27).Value = claim.SecondaryCauseDate;
                    worksheet.Cell(currentRow, 28).Value = claim.ExpectedReturnToWorkDate;
                    worksheet.Cell(currentRow, 29).Value = claim.CeasedWorkDate;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimFinalisedDate;
                    worksheet.Cell(currentRow, 31).Value = claim.ClaimFinalisedReason;
                    worksheet.Cell(currentRow, 32).Value = claim.ClaimReopenDate;
                    worksheet.Cell(currentRow, 33).Value = claim.ClaimReopenReason;
                    worksheet.Cell(currentRow, 34).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 35).Value = claim.ContractStartDate;
                    worksheet.Cell(currentRow, 36).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 37).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 38).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 39).Value = claim.TargetBenefitCode;
                    worksheet.Cell(currentRow, 40).Value = claim.TargetBenefitDescription;
                    worksheet.Cell(currentRow, 41).Value = claim.BenefitStatus;
                    worksheet.Cell(currentRow, 42).Value = claim.RiskCommencedDate;
                    worksheet.Cell(currentRow, 43).Value = claim.RiskExpiryDate;
                    worksheet.Cell(currentRow, 44).Value = claim.WaitingPeriodAccident;
                    worksheet.Cell(currentRow, 45).Value = claim.WaitingPeriodSickness;
                    worksheet.Cell(currentRow, 46).Value = claim.BenefitPeriodAccident;
                    worksheet.Cell(currentRow, 47).Value = claim.BenefitPeriodSickness;
                    worksheet.Cell(currentRow, 48).Value = claim.SumInsured;
                    worksheet.Cell(currentRow, 49).Value = claim.CalculationStartType;
                    worksheet.Cell(currentRow, 50).Value = claim.CalculationEndType;
                    worksheet.Cell(currentRow, 51).Value = claim.Decision;
                    worksheet.Cell(currentRow, 52).Value = claim.Accepted;
                    worksheet.Cell(currentRow, 53).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 54).Value = claim.DecisionReason;
                    worksheet.Cell(currentRow, 55).Value = claim.FinalisedDate;
                    worksheet.Cell(currentRow, 56).Value = claim.FinalisedReason;
                    worksheet.Cell(currentRow, 57).Value = claim.BenefitReopenDate;
                    worksheet.Cell(currentRow, 58).Value = claim.BenefitReopenReason;
                    worksheet.Cell(currentRow, 59).Value = claim.SuperContributionPercent;
                    worksheet.Cell(currentRow, 60).Value = claim.IndexationFlag;
                    worksheet.Cell(currentRow, 61).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 62).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 63).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 64).Value = claim.ReInsurerName;
                    worksheet.Cell(currentRow, 65).Value = claim.ReinsuranceTreatyType;
                    worksheet.Cell(currentRow, 66).Value = claim.ReinsurancePercent;
                    worksheet.Cell(currentRow, 67).Value = claim.AdviserSalesId;
                    worksheet.Cell(currentRow, 68).Value = claim.GroupPlanName;
                    worksheet.Cell(currentRow, 69).Value = claim.GroupPlanNumber;
                    worksheet.Cell(currentRow, 70).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 71).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 72).Value = claim.OverrideRiskCategoryReason;
                    worksheet.Cell(currentRow, 73).Value = claim.PrimaryOccupationStartDate;
                    worksheet.Cell(currentRow, 74).Value = claim.PrimaryOccupationEndDate;
                    worksheet.Cell(currentRow, 75).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 76).Value = claim.ExternalMemberNumber;
                    worksheet.Cell(currentRow, 77).Value = claim.BenefitCreationDate;
                    worksheet.Cell(currentRow, 78).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 79).Value = claim.InitialSumInsuredX12;
                    worksheet.Cell(currentRow, 80).Value = claim.ContractEndDate;
                    worksheet.Cell(currentRow, 81).Value = claim.SumReInsured;
                    worksheet.Cell(currentRow, 82).Value = claim.PartialEarningsIncome;
                    worksheet.Cell(currentRow, 83).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 84).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 85).Value = claim.MaximumIndexationRate;
                    worksheet.Cell(currentRow, 86).Value = claim.Source;
                    worksheet.Cell(currentRow, 87).Value = claim.IncidentOccurredOverseas;
                    worksheet.Cell(currentRow, 88).Value = claim.CountryOfIncident;
                    worksheet.Cell(currentRow, 89).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 90).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 91).Value = claim.SourceBenefitCode;
                    worksheet.Cell(currentRow, 92).Value = claim.SourceBenefitDescription;
                    worksheet.Cell(currentRow, 93).Value = claim.InitialSumInsured;
                    worksheet.Cell(currentRow, 94).Value = claim.InitialSumInsuredFreq;
                    worksheet.Cell(currentRow, 95).Value = claim.PrimaryOccSelfEmployedInd;
                    worksheet.Cell(currentRow, 96).Value = claim.TpdDefinition;
                    worksheet.Cell(currentRow, 97).Value = claim.TpdSubDefinition;
                    worksheet.Cell(currentRow, 98).Value = claim.TraumaDefinition;
                    worksheet.Cell(currentRow, 99).Value = claim.SourceBenefitType;
                    worksheet.Cell(currentRow, 100).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 101).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 102).Value = claim.PartyId;
                    worksheet.Cell(currentRow, 103).Value = claim.Declined;
                    worksheet.Cell(currentRow, 104).Value = claim.QualifyingPeriod;
                    worksheet.Cell(currentRow, 105).Value = claim.ExpectedResolutionDate;
                    worksheet.Cell(currentRow, 106).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 107).Value = claim.SourceBenefitSelected;
                    worksheet.Cell(currentRow, 108).Value = claim.ConcurrentClaimIndicator;
                    worksheet.Cell(currentRow, 109).Value = claim.ConcurrentClaimNumbers;
                    worksheet.Cell(currentRow, 110).Value = claim.WorkStatusType;
                    worksheet.Cell(currentRow, 111).Value = claim.StartDate;
                    worksheet.Cell(currentRow, 112).Value = claim.PartialCapacity;
                    worksheet.Cell(currentRow, 113).Value = claim.EndDate;
                    worksheet.Cell(currentRow, 114).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 115).Value = claim.ExpectedRtwFtRange;
                    worksheet.Cell(currentRow, 116).Value = claim.AdmitAdvancePayAndFinalise;
                    worksheet.Cell(currentRow, 117).Value = claim.NonDisclosure;
                    worksheet.Cell(currentRow, 118).Value = claim.CmpRequired;
                    worksheet.Cell(currentRow, 119).Value = claim.UrgentFinancialNeedsFlag;
                    worksheet.Cell(currentRow, 120).Value = claim.SpecialArrangementFlag;
                    worksheet.Cell(currentRow, 121).Value = claim.SpecialArrangementDuration;
                    worksheet.Cell(currentRow, 122).Value = claim.UnexpectedCircumstances;
                    worksheet.Cell(currentRow, 123).Value = claim.CoverageNumber;
                    worksheet.Cell(currentRow, 124).Value = claim.AssessedUnderLimitedCover;
                    worksheet.Cell(currentRow, 125).Value = claim.ClaimReceivedDate;
                    worksheet.Cell(currentRow, 126).Value = claim.CustomerContactFrequency;
                    worksheet.Cell(currentRow, 127).Value = claim.UnexpectedCircumstancesApply;
                    worksheet.Cell(currentRow, 128).Value = claim.IarCode;
                    worksheet.Cell(currentRow, 129).Value = claim.IarDescription;
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

        public async Task<byte[]> GetRptClaimbenefitw(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimbenefitw(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimbenefitw");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimbenefitw";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreDisabilityIncome"; worksheet.Cell(currentRow, 2).Value = claim.PreDisabilityIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CurrentClaimOwner"; worksheet.Cell(currentRow, 2).Value = claim.CurrentClaimOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RegistrationDate"; worksheet.Cell(currentRow, 2).Value = claim.RegistrationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstContactDate"; worksheet.Cell(currentRow, 2).Value = claim.FirstContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeAtIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.AgeAtIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimEventType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimEventType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseCode"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDescription"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecondaryCauseDate"; worksheet.Cell(currentRow, 2).Value = claim.SecondaryCauseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedReturnToWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedReturnToWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CeasedWorkDate"; worksheet.Cell(currentRow, 2).Value = claim.CeasedWorkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimFinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimFinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCommencedDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCommencedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPeriodSickness"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPeriodSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationStartType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationStartType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CalculationEndType"; worksheet.Cell(currentRow, 2).Value = claim.CalculationEndType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Accepted"; worksheet.Cell(currentRow, 2).Value = claim.Accepted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedDate"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinalisedReason"; worksheet.Cell(currentRow, 2).Value = claim.FinalisedReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitReopenReason"; worksheet.Cell(currentRow, 2).Value = claim.BenefitReopenReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPercent"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationFlag"; worksheet.Cell(currentRow, 2).Value = claim.IndexationFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReInsurerName"; worksheet.Cell(currentRow, 2).Value = claim.ReInsurerName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsuranceTreatyType"; worksheet.Cell(currentRow, 2).Value = claim.ReinsuranceTreatyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsurancePercent"; worksheet.Cell(currentRow, 2).Value = claim.ReinsurancePercent;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdviserSalesId"; worksheet.Cell(currentRow, 2).Value = claim.AdviserSalesId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanName"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupPlanNumber"; worksheet.Cell(currentRow, 2).Value = claim.GroupPlanNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationStartDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccupationEndDate"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccupationEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExternalMemberNumber"; worksheet.Cell(currentRow, 2).Value = claim.ExternalMemberNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredX12"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredX12;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ContractEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumReInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumReInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialEarningsIncome"; worksheet.Cell(currentRow, 2).Value = claim.PartialEarningsIncome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumIndexationRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumIndexationRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncidentOccurredOverseas"; worksheet.Cell(currentRow, 2).Value = claim.IncidentOccurredOverseas;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsured"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InitialSumInsuredFreq"; worksheet.Cell(currentRow, 2).Value = claim.InitialSumInsuredFreq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrimaryOccSelfEmployedInd"; worksheet.Cell(currentRow, 2).Value = claim.PrimaryOccSelfEmployedInd;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdSubDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdSubDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TraumaDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyId"; worksheet.Cell(currentRow, 2).Value = claim.PartyId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Declined"; worksheet.Cell(currentRow, 2).Value = claim.Declined;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "QualifyingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.QualifyingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedResolutionDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedResolutionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceBenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.SourceBenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimNumbers"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimNumbers;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WorkStatusType"; worksheet.Cell(currentRow, 2).Value = claim.WorkStatusType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDate"; worksheet.Cell(currentRow, 2).Value = claim.StartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialCapacity"; worksheet.Cell(currentRow, 2).Value = claim.PartialCapacity;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EndDate"; worksheet.Cell(currentRow, 2).Value = claim.EndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwFtRange"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwFtRange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdmitAdvancePayAndFinalise"; worksheet.Cell(currentRow, 2).Value = claim.AdmitAdvancePayAndFinalise;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonDisclosure"; worksheet.Cell(currentRow, 2).Value = claim.NonDisclosure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpRequired"; worksheet.Cell(currentRow, 2).Value = claim.CmpRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeedsFlag"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeedsFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementFlag"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SpecialArrangementDuration"; worksheet.Cell(currentRow, 2).Value = claim.SpecialArrangementDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverageNumber"; worksheet.Cell(currentRow, 2).Value = claim.CoverageNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AssessedUnderLimitedCover"; worksheet.Cell(currentRow, 2).Value = claim.AssessedUnderLimitedCover;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReceivedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReceivedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerContactFrequency"; worksheet.Cell(currentRow, 2).Value = claim.CustomerContactFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstancesApply"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstancesApply;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IarCode"; worksheet.Cell(currentRow, 2).Value = claim.IarCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IarDescription"; worksheet.Cell(currentRow, 2).Value = claim.IarDescription;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimcasedeciphas(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimcasedecipha(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimcasedecipha");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimcasedecipha";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 4).Value = "CustomerFirstName";
                worksheet.Cell(currentRow, 5).Value = "CustomerLastName";
                worksheet.Cell(currentRow, 6).Value = "State";
                worksheet.Cell(currentRow, 7).Value = "PostCode";
                worksheet.Cell(currentRow, 8).Value = "ClaimsTeamDepartment";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.CustomerFirstName;
                    worksheet.Cell(currentRow, 5).Value = claim.CustomerLastName;
                    worksheet.Cell(currentRow, 6).Value = claim.State;
                    worksheet.Cell(currentRow, 7).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 8).Value = claim.ClaimsTeamDepartment;
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

        public async Task<byte[]> GetRptClaimcasedecipha(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimcasedecipha(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimcasedecipha");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimcasedecipha";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerFirstName"; worksheet.Cell(currentRow, 2).Value = claim.CustomerFirstName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerLastName"; worksheet.Cell(currentRow, 2).Value = claim.CustomerLastName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimsTeamDepartment"; worksheet.Cell(currentRow, 2).Value = claim.ClaimsTeamDepartment;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetRptClaimexpenses(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimexpense(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimexpense");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimexpense";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "Payee";
                worksheet.Cell(currentRow, 4).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 5).Value = "InvoiceType";
                worksheet.Cell(currentRow, 6).Value = "InvoiceNumber";
                worksheet.Cell(currentRow, 7).Value = "AmountIncGst";
                worksheet.Cell(currentRow, 8).Value = "Gst";
                worksheet.Cell(currentRow, 9).Value = "PaymentMethod";
                worksheet.Cell(currentRow, 10).Value = "VendorId";
                worksheet.Cell(currentRow, 11).Value = "AdminInitials";
                worksheet.Cell(currentRow, 12).Value = "PaymentCreationDate";
                worksheet.Cell(currentRow, 13).Value = "PaymentReference";
                worksheet.Cell(currentRow, 14).Value = "AuthorisedBy";
                worksheet.Cell(currentRow, 15).Value = "AuthorisationDate";
                worksheet.Cell(currentRow, 16).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 17).Value = "ClaimType";
                worksheet.Cell(currentRow, 18).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 19).Value = "BenefitCode";
                worksheet.Cell(currentRow, 20).Value = "ProductCode";
                worksheet.Cell(currentRow, 21).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 22).Value = "ClaimExpenseGuid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.Payee;
                    worksheet.Cell(currentRow, 4).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 5).Value = claim.InvoiceType;
                    worksheet.Cell(currentRow, 6).Value = claim.InvoiceNumber;
                    worksheet.Cell(currentRow, 7).Value = claim.AmountIncGst;
                    worksheet.Cell(currentRow, 8).Value = claim.Gst;
                    worksheet.Cell(currentRow, 9).Value = claim.PaymentMethod;
                    worksheet.Cell(currentRow, 10).Value = claim.VendorId;
                    worksheet.Cell(currentRow, 11).Value = claim.AdminInitials;
                    worksheet.Cell(currentRow, 12).Value = claim.PaymentCreationDate;
                    worksheet.Cell(currentRow, 13).Value = claim.PaymentReference;
                    worksheet.Cell(currentRow, 14).Value = claim.AuthorisedBy;
                    worksheet.Cell(currentRow, 15).Value = claim.AuthorisationDate;
                    worksheet.Cell(currentRow, 16).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 17).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 18).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 19).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 20).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 21).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 22).Value = claim.ClaimExpenseGuid;
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

        public async Task<byte[]> GetRptClaimexpense(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimexpense(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimexpense");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimexpense";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Payee"; worksheet.Cell(currentRow, 2).Value = claim.Payee;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InvoiceType"; worksheet.Cell(currentRow, 2).Value = claim.InvoiceType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InvoiceNumber"; worksheet.Cell(currentRow, 2).Value = claim.InvoiceNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AmountIncGst"; worksheet.Cell(currentRow, 2).Value = claim.AmountIncGst;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Gst"; worksheet.Cell(currentRow, 2).Value = claim.Gst;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentMethod"; worksheet.Cell(currentRow, 2).Value = claim.PaymentMethod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "VendorId"; worksheet.Cell(currentRow, 2).Value = claim.VendorId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminInitials"; worksheet.Cell(currentRow, 2).Value = claim.AdminInitials;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.PaymentCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentReference"; worksheet.Cell(currentRow, 2).Value = claim.PaymentReference;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AuthorisedBy"; worksheet.Cell(currentRow, 2).Value = claim.AuthorisedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AuthorisationDate"; worksheet.Cell(currentRow, 2).Value = claim.AuthorisationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimExpenseGuid"; worksheet.Cell(currentRow, 2).Value = claim.ClaimExpenseGuid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClaimparticipants(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClaimparticipant(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimparticipant");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClaimparticipant";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "FaxExtension";
                worksheet.Cell(currentRow, 3).Value = "Email";
                worksheet.Cell(currentRow, 4).Value = "TypeOfParticipant";
                worksheet.Cell(currentRow, 5).Value = "PersonOrganisation";
                worksheet.Cell(currentRow, 6).Value = "Name";
                worksheet.Cell(currentRow, 7).Value = "Hva";
                worksheet.Cell(currentRow, 8).Value = "AddressType";
                worksheet.Cell(currentRow, 9).Value = "Address";
                worksheet.Cell(currentRow, 10).Value = "Suburb";
                worksheet.Cell(currentRow, 11).Value = "State";
                worksheet.Cell(currentRow, 12).Value = "PostCode";
                worksheet.Cell(currentRow, 13).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 14).Value = "ParticipantEffectiveDate";
                worksheet.Cell(currentRow, 15).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 16).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 17).Value = "ClaimType";
                worksheet.Cell(currentRow, 18).Value = "ResidentialInternationalCode";
                worksheet.Cell(currentRow, 19).Value = "ResidentialAreaCode";
                worksheet.Cell(currentRow, 20).Value = "ResidentialPhone";
                worksheet.Cell(currentRow, 21).Value = "ResidentialExtension";
                worksheet.Cell(currentRow, 22).Value = "BusinessInternationalCode";
                worksheet.Cell(currentRow, 23).Value = "BusinessAreaCode";
                worksheet.Cell(currentRow, 24).Value = "BusinessPhone";
                worksheet.Cell(currentRow, 25).Value = "BusinessExtension";
                worksheet.Cell(currentRow, 26).Value = "MobileInternationalCode";
                worksheet.Cell(currentRow, 27).Value = "MobileAreaCode";
                worksheet.Cell(currentRow, 28).Value = "MobilePhone";
                worksheet.Cell(currentRow, 29).Value = "MobileExtension";
                worksheet.Cell(currentRow, 30).Value = "FaxInternationalCode";
                worksheet.Cell(currentRow, 31).Value = "FaxAreaCode";
                worksheet.Cell(currentRow, 32).Value = "FaxPhone";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.FaxExtension;
                    worksheet.Cell(currentRow, 3).Value = claim.Email;
                    worksheet.Cell(currentRow, 4).Value = claim.TypeOfParticipant;
                    worksheet.Cell(currentRow, 5).Value = claim.PersonOrganisation;
                    worksheet.Cell(currentRow, 6).Value = claim.Name;
                    worksheet.Cell(currentRow, 7).Value = claim.Hva;
                    worksheet.Cell(currentRow, 8).Value = claim.AddressType;
                    worksheet.Cell(currentRow, 9).Value = claim.Address;
                    worksheet.Cell(currentRow, 10).Value = claim.Suburb;
                    worksheet.Cell(currentRow, 11).Value = claim.State;
                    worksheet.Cell(currentRow, 12).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 13).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 14).Value = claim.ParticipantEffectiveDate;
                    worksheet.Cell(currentRow, 15).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 16).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 17).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 18).Value = claim.ResidentialInternationalCode;
                    worksheet.Cell(currentRow, 19).Value = claim.ResidentialAreaCode;
                    worksheet.Cell(currentRow, 20).Value = claim.ResidentialPhone;
                    worksheet.Cell(currentRow, 21).Value = claim.ResidentialExtension;
                    worksheet.Cell(currentRow, 22).Value = claim.BusinessInternationalCode;
                    worksheet.Cell(currentRow, 23).Value = claim.BusinessAreaCode;
                    worksheet.Cell(currentRow, 24).Value = claim.BusinessPhone;
                    worksheet.Cell(currentRow, 25).Value = claim.BusinessExtension;
                    worksheet.Cell(currentRow, 26).Value = claim.MobileInternationalCode;
                    worksheet.Cell(currentRow, 27).Value = claim.MobileAreaCode;
                    worksheet.Cell(currentRow, 28).Value = claim.MobilePhone;
                    worksheet.Cell(currentRow, 29).Value = claim.MobileExtension;
                    worksheet.Cell(currentRow, 30).Value = claim.FaxInternationalCode;
                    worksheet.Cell(currentRow, 31).Value = claim.FaxAreaCode;
                    worksheet.Cell(currentRow, 32).Value = claim.FaxPhone;
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

        public async Task<byte[]> GetRptClaimparticipant(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClaimparticipant(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClaimparticipant");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClaimparticipant";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FaxExtension"; worksheet.Cell(currentRow, 2).Value = claim.FaxExtension;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Email"; worksheet.Cell(currentRow, 2).Value = claim.Email;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TypeOfParticipant"; worksheet.Cell(currentRow, 2).Value = claim.TypeOfParticipant;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PersonOrganisation"; worksheet.Cell(currentRow, 2).Value = claim.PersonOrganisation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Hva"; worksheet.Cell(currentRow, 2).Value = claim.Hva;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AddressType"; worksheet.Cell(currentRow, 2).Value = claim.AddressType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Address"; worksheet.Cell(currentRow, 2).Value = claim.Address;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Suburb"; worksheet.Cell(currentRow, 2).Value = claim.Suburb;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ParticipantEffectiveDate"; worksheet.Cell(currentRow, 2).Value = claim.ParticipantEffectiveDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ResidentialInternationalCode"; worksheet.Cell(currentRow, 2).Value = claim.ResidentialInternationalCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ResidentialAreaCode"; worksheet.Cell(currentRow, 2).Value = claim.ResidentialAreaCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ResidentialPhone"; worksheet.Cell(currentRow, 2).Value = claim.ResidentialPhone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ResidentialExtension"; worksheet.Cell(currentRow, 2).Value = claim.ResidentialExtension;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessInternationalCode"; worksheet.Cell(currentRow, 2).Value = claim.BusinessInternationalCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessAreaCode"; worksheet.Cell(currentRow, 2).Value = claim.BusinessAreaCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessPhone"; worksheet.Cell(currentRow, 2).Value = claim.BusinessPhone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessExtension"; worksheet.Cell(currentRow, 2).Value = claim.BusinessExtension;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MobileInternationalCode"; worksheet.Cell(currentRow, 2).Value = claim.MobileInternationalCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MobileAreaCode"; worksheet.Cell(currentRow, 2).Value = claim.MobileAreaCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MobilePhone"; worksheet.Cell(currentRow, 2).Value = claim.MobilePhone;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MobileExtension"; worksheet.Cell(currentRow, 2).Value = claim.MobileExtension;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FaxInternationalCode"; worksheet.Cell(currentRow, 2).Value = claim.FaxInternationalCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FaxAreaCode"; worksheet.Cell(currentRow, 2).Value = claim.FaxAreaCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FaxPhone"; worksheet.Cell(currentRow, 2).Value = claim.FaxPhone;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptClosedtaskreports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptClosedtaskreport(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClosedtaskreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptClosedtaskreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CaseStatus";
                worksheet.Cell(currentRow, 4).Value = "ClaimantName";
                worksheet.Cell(currentRow, 5).Value = "CaseType";
                worksheet.Cell(currentRow, 6).Value = "CaseManager";
                worksheet.Cell(currentRow, 7).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 8).Value = "TaskProcessStep";
                worksheet.Cell(currentRow, 9).Value = "TaskId";
                worksheet.Cell(currentRow, 10).Value = "TaskCode";
                worksheet.Cell(currentRow, 11).Value = "TaskName";
                worksheet.Cell(currentRow, 12).Value = "TaskDescription";
                worksheet.Cell(currentRow, 13).Value = "TaskStatus";
                worksheet.Cell(currentRow, 14).Value = "TaskAssignedToUser";
                worksheet.Cell(currentRow, 15).Value = "TaskAssignedToRole";
                worksheet.Cell(currentRow, 16).Value = "TaskCreatedByUser";
                worksheet.Cell(currentRow, 17).Value = "TaskCreatedDate";
                worksheet.Cell(currentRow, 18).Value = "TaskCompletedByUser";
                worksheet.Cell(currentRow, 19).Value = "TaskCompletedDate";
                worksheet.Cell(currentRow, 20).Value = "BenchmarkDays";
                worksheet.Cell(currentRow, 21).Value = "BenchmarkDate";
                worksheet.Cell(currentRow, 22).Value = "ProductName";
                worksheet.Cell(currentRow, 23).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 24).Value = "BenefitCode";
                worksheet.Cell(currentRow, 25).Value = "BenefitDescription";
                worksheet.Cell(currentRow, 26).Value = "TaskCreatedByTeam";
                worksheet.Cell(currentRow, 27).Value = "TaskCompletedByTeam";
                worksheet.Cell(currentRow, 28).Value = "OriginalTaskTargetDate";
                worksheet.Cell(currentRow, 29).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 30).Value = "ClaimType";
                worksheet.Cell(currentRow, 31).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 32).Value = "ProductCode";
                worksheet.Cell(currentRow, 33).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 34).Value = "TaskTeamQueue";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CaseStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 6).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 8).Value = claim.TaskProcessStep;
                    worksheet.Cell(currentRow, 9).Value = claim.TaskId;
                    worksheet.Cell(currentRow, 10).Value = claim.TaskCode;
                    worksheet.Cell(currentRow, 11).Value = claim.TaskName;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskDescription;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.TaskAssignedToUser;
                    worksheet.Cell(currentRow, 15).Value = claim.TaskAssignedToRole;
                    worksheet.Cell(currentRow, 16).Value = claim.TaskCreatedByUser;
                    worksheet.Cell(currentRow, 17).Value = claim.TaskCreatedDate;
                    worksheet.Cell(currentRow, 18).Value = claim.TaskCompletedByUser;
                    worksheet.Cell(currentRow, 19).Value = claim.TaskCompletedDate;
                    worksheet.Cell(currentRow, 20).Value = claim.BenchmarkDays;
                    worksheet.Cell(currentRow, 21).Value = claim.BenchmarkDate;
                    worksheet.Cell(currentRow, 22).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 23).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 24).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 25).Value = claim.BenefitDescription;
                    worksheet.Cell(currentRow, 26).Value = claim.TaskCreatedByTeam;
                    worksheet.Cell(currentRow, 27).Value = claim.TaskCompletedByTeam;
                    worksheet.Cell(currentRow, 28).Value = claim.OriginalTaskTargetDate;
                    worksheet.Cell(currentRow, 29).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 31).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 32).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 33).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 34).Value = claim.TaskTeamQueue;
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

        public async Task<byte[]> GetRptClosedtaskreport(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptClosedtaskreport(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptClosedtaskreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptClosedtaskreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.CaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskProcessStep"; worksheet.Cell(currentRow, 2).Value = claim.TaskProcessStep;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskId"; worksheet.Cell(currentRow, 2).Value = claim.TaskId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCode"; worksheet.Cell(currentRow, 2).Value = claim.TaskCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskName"; worksheet.Cell(currentRow, 2).Value = claim.TaskName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskDescription"; worksheet.Cell(currentRow, 2).Value = claim.TaskDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskStatus"; worksheet.Cell(currentRow, 2).Value = claim.TaskStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToRole"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToRole;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDays"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDays;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDate"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTaskTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTaskTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskTeamQueue"; worksheet.Cell(currentRow, 2).Value = claim.TaskTeamQueue;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCmpactions(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCmpaction(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpaction");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptCmpaction";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CmpStatus";
                worksheet.Cell(currentRow, 4).Value = "GoalName";
                worksheet.Cell(currentRow, 5).Value = "GoalOutcome";
                worksheet.Cell(currentRow, 6).Value = "GoalDescription";
                worksheet.Cell(currentRow, 7).Value = "GoalCreationDate";
                worksheet.Cell(currentRow, 8).Value = "GoalOutcomeDate";
                worksheet.Cell(currentRow, 9).Value = "CmpGoalDate";
                worksheet.Cell(currentRow, 10).Value = "PlanName";
                worksheet.Cell(currentRow, 11).Value = "PlanNotes";
                worksheet.Cell(currentRow, 12).Value = "PlanStatus";
                worksheet.Cell(currentRow, 13).Value = "PlanCreationDate";
                worksheet.Cell(currentRow, 14).Value = "FactorName";
                worksheet.Cell(currentRow, 15).Value = "FactorDescription";
                worksheet.Cell(currentRow, 16).Value = "Factors";
                worksheet.Cell(currentRow, 17).Value = "FactorStatus";
                worksheet.Cell(currentRow, 18).Value = "StrategyName";
                worksheet.Cell(currentRow, 19).Value = "StrategyOutcome";
                worksheet.Cell(currentRow, 20).Value = "StrategyTargetDate";
                worksheet.Cell(currentRow, 21).Value = "StrategyCreationDate";
                worksheet.Cell(currentRow, 22).Value = "StrategyOutcomeDate";
                worksheet.Cell(currentRow, 23).Value = "ActionName";
                worksheet.Cell(currentRow, 24).Value = "ActionLastUpdated";
                worksheet.Cell(currentRow, 25).Value = "ActionStartDate";
                worksheet.Cell(currentRow, 26).Value = "ActionOwner";
                worksheet.Cell(currentRow, 27).Value = "ActionOwnerTeam";
                worksheet.Cell(currentRow, 28).Value = "ActionOutcome";
                worksheet.Cell(currentRow, 29).Value = "ActionOutcomeDate";
                worksheet.Cell(currentRow, 30).Value = "ActionOutcomeReason";
                worksheet.Cell(currentRow, 31).Value = "ActionOwnerType";
                worksheet.Cell(currentRow, 32).Value = "ServiceCode";
                worksheet.Cell(currentRow, 33).Value = "ServiceDescription";
                worksheet.Cell(currentRow, 34).Value = "ServiceCreator";
                worksheet.Cell(currentRow, 35).Value = "ServiceStartDate";
                worksheet.Cell(currentRow, 36).Value = "ServiceEndDate";
                worksheet.Cell(currentRow, 37).Value = "ServiceNotes";
                worksheet.Cell(currentRow, 38).Value = "CommenceDate";
                worksheet.Cell(currentRow, 39).Value = "ServicePractitioner";
                worksheet.Cell(currentRow, 40).Value = "DocumentUploadDate";
                worksheet.Cell(currentRow, 41).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 42).Value = "ClaimType";
                worksheet.Cell(currentRow, 43).Value = "GoalReason";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CmpStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GoalName;
                    worksheet.Cell(currentRow, 5).Value = claim.GoalOutcome;
                    worksheet.Cell(currentRow, 6).Value = claim.GoalDescription;
                    worksheet.Cell(currentRow, 7).Value = claim.GoalCreationDate;
                    worksheet.Cell(currentRow, 8).Value = claim.GoalOutcomeDate;
                    worksheet.Cell(currentRow, 9).Value = claim.CmpGoalDate;
                    worksheet.Cell(currentRow, 10).Value = claim.PlanName;
                    worksheet.Cell(currentRow, 11).Value = claim.PlanNotes;
                    worksheet.Cell(currentRow, 12).Value = claim.PlanStatus;
                    worksheet.Cell(currentRow, 13).Value = claim.PlanCreationDate;
                    worksheet.Cell(currentRow, 14).Value = claim.FactorName;
                    worksheet.Cell(currentRow, 15).Value = claim.FactorDescription;
                    worksheet.Cell(currentRow, 16).Value = claim.Factors;
                    worksheet.Cell(currentRow, 17).Value = claim.FactorStatus;
                    worksheet.Cell(currentRow, 18).Value = claim.StrategyName;
                    worksheet.Cell(currentRow, 19).Value = claim.StrategyOutcome;
                    worksheet.Cell(currentRow, 20).Value = claim.StrategyTargetDate;
                    worksheet.Cell(currentRow, 21).Value = claim.StrategyCreationDate;
                    worksheet.Cell(currentRow, 22).Value = claim.StrategyOutcomeDate;
                    worksheet.Cell(currentRow, 23).Value = claim.ActionName;
                    worksheet.Cell(currentRow, 24).Value = claim.ActionLastUpdated;
                    worksheet.Cell(currentRow, 25).Value = claim.ActionStartDate;
                    worksheet.Cell(currentRow, 26).Value = claim.ActionOwner;
                    worksheet.Cell(currentRow, 27).Value = claim.ActionOwnerTeam;
                    worksheet.Cell(currentRow, 28).Value = claim.ActionOutcome;
                    worksheet.Cell(currentRow, 29).Value = claim.ActionOutcomeDate;
                    worksheet.Cell(currentRow, 30).Value = claim.ActionOutcomeReason;
                    worksheet.Cell(currentRow, 31).Value = claim.ActionOwnerType;
                    worksheet.Cell(currentRow, 32).Value = claim.ServiceCode;
                    worksheet.Cell(currentRow, 33).Value = claim.ServiceDescription;
                    worksheet.Cell(currentRow, 34).Value = claim.ServiceCreator;
                    worksheet.Cell(currentRow, 35).Value = claim.ServiceStartDate;
                    worksheet.Cell(currentRow, 36).Value = claim.ServiceEndDate;
                    worksheet.Cell(currentRow, 37).Value = claim.ServiceNotes;
                    worksheet.Cell(currentRow, 38).Value = claim.CommenceDate;
                    worksheet.Cell(currentRow, 39).Value = claim.ServicePractitioner;
                    worksheet.Cell(currentRow, 40).Value = claim.DocumentUploadDate;
                    worksheet.Cell(currentRow, 41).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 42).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 43).Value = claim.GoalReason;
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

        public async Task<byte[]> GetRptCmpaction(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCmpaction(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpaction");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptCmpaction";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpStatus"; worksheet.Cell(currentRow, 2).Value = claim.CmpStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalName"; worksheet.Cell(currentRow, 2).Value = claim.GoalName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalOutcome"; worksheet.Cell(currentRow, 2).Value = claim.GoalOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalDescription"; worksheet.Cell(currentRow, 2).Value = claim.GoalDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.GoalCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalOutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.GoalOutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanName"; worksheet.Cell(currentRow, 2).Value = claim.PlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanNotes"; worksheet.Cell(currentRow, 2).Value = claim.PlanNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanStatus"; worksheet.Cell(currentRow, 2).Value = claim.PlanStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.PlanCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FactorName"; worksheet.Cell(currentRow, 2).Value = claim.FactorName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FactorDescription"; worksheet.Cell(currentRow, 2).Value = claim.FactorDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Factors"; worksheet.Cell(currentRow, 2).Value = claim.Factors;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FactorStatus"; worksheet.Cell(currentRow, 2).Value = claim.FactorStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyName"; worksheet.Cell(currentRow, 2).Value = claim.StrategyName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyOutcome"; worksheet.Cell(currentRow, 2).Value = claim.StrategyOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.StrategyTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.StrategyCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyOutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.StrategyOutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionName"; worksheet.Cell(currentRow, 2).Value = claim.ActionName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionLastUpdated"; worksheet.Cell(currentRow, 2).Value = claim.ActionLastUpdated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ActionStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOwner"; worksheet.Cell(currentRow, 2).Value = claim.ActionOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOwnerTeam"; worksheet.Cell(currentRow, 2).Value = claim.ActionOwnerTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcome"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcomeReason"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcomeReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOwnerType"; worksheet.Cell(currentRow, 2).Value = claim.ActionOwnerType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCode"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceDescription"; worksheet.Cell(currentRow, 2).Value = claim.ServiceDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCreator"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCreator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceNotes"; worksheet.Cell(currentRow, 2).Value = claim.ServiceNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CommenceDate"; worksheet.Cell(currentRow, 2).Value = claim.CommenceDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServicePractitioner"; worksheet.Cell(currentRow, 2).Value = claim.ServicePractitioner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentUploadDate"; worksheet.Cell(currentRow, 2).Value = claim.DocumentUploadDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalReason"; worksheet.Cell(currentRow, 2).Value = claim.GoalReason;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCmpgoaldatemovements(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCmpgoaldatemovement(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpgoaldatemovement");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptCmpgoaldatemovement";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CmpStatus";
                worksheet.Cell(currentRow, 4).Value = "PlanName";
                worksheet.Cell(currentRow, 5).Value = "PlanCreationDate";
                worksheet.Cell(currentRow, 6).Value = "CmpGoalDate";
                worksheet.Cell(currentRow, 7).Value = "CmpGoalCreationDate";
                worksheet.Cell(currentRow, 8).Value = "CmpGoalUpdatedDate";
                worksheet.Cell(currentRow, 9).Value = "CmpGoalUpdatedByUserName";
                worksheet.Cell(currentRow, 10).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 11).Value = "ClaimType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CmpStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.PlanName;
                    worksheet.Cell(currentRow, 5).Value = claim.PlanCreationDate;
                    worksheet.Cell(currentRow, 6).Value = claim.CmpGoalDate;
                    worksheet.Cell(currentRow, 7).Value = claim.CmpGoalCreationDate;
                    worksheet.Cell(currentRow, 8).Value = claim.CmpGoalUpdatedDate;
                    worksheet.Cell(currentRow, 9).Value = claim.CmpGoalUpdatedByUserName;
                    worksheet.Cell(currentRow, 10).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 11).Value = claim.ClaimType;
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

        public async Task<byte[]> GetRptCmpgoaldatemovement(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCmpgoaldatemovement(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpgoaldatemovement");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptCmpgoaldatemovement";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpStatus"; worksheet.Cell(currentRow, 2).Value = claim.CmpStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanName"; worksheet.Cell(currentRow, 2).Value = claim.PlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.PlanCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalUpdatedDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalUpdatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalUpdatedByUserName"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalUpdatedByUserName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCmpplanstatuss(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCmpplanstatus(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpplanstatus");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptCmpplanstatus";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CmpStatus";
                worksheet.Cell(currentRow, 4).Value = "CmpGoalDate";
                worksheet.Cell(currentRow, 5).Value = "PlanName";
                worksheet.Cell(currentRow, 6).Value = "PlanNotes";
                worksheet.Cell(currentRow, 7).Value = "PlanStatus";
                worksheet.Cell(currentRow, 8).Value = "PlanCreationDate";
                worksheet.Cell(currentRow, 9).Value = "ServiceCode";
                worksheet.Cell(currentRow, 10).Value = "ServiceDescription";
                worksheet.Cell(currentRow, 11).Value = "ServiceCreator";
                worksheet.Cell(currentRow, 12).Value = "ServiceStartDate";
                worksheet.Cell(currentRow, 13).Value = "ServiceEndDate";
                worksheet.Cell(currentRow, 14).Value = "PlanStatusDate";
                worksheet.Cell(currentRow, 15).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 16).Value = "ClaimType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CmpStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.CmpGoalDate;
                    worksheet.Cell(currentRow, 5).Value = claim.PlanName;
                    worksheet.Cell(currentRow, 6).Value = claim.PlanNotes;
                    worksheet.Cell(currentRow, 7).Value = claim.PlanStatus;
                    worksheet.Cell(currentRow, 8).Value = claim.PlanCreationDate;
                    worksheet.Cell(currentRow, 9).Value = claim.ServiceCode;
                    worksheet.Cell(currentRow, 10).Value = claim.ServiceDescription;
                    worksheet.Cell(currentRow, 11).Value = claim.ServiceCreator;
                    worksheet.Cell(currentRow, 12).Value = claim.ServiceStartDate;
                    worksheet.Cell(currentRow, 13).Value = claim.ServiceEndDate;
                    worksheet.Cell(currentRow, 14).Value = claim.PlanStatusDate;
                    worksheet.Cell(currentRow, 15).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 16).Value = claim.ClaimType;
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

        public async Task<byte[]> GetRptCmpplanstatus(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCmpplanstatus(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpplanstatus");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptCmpplanstatus";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpStatus"; worksheet.Cell(currentRow, 2).Value = claim.CmpStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanName"; worksheet.Cell(currentRow, 2).Value = claim.PlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanNotes"; worksheet.Cell(currentRow, 2).Value = claim.PlanNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanStatus"; worksheet.Cell(currentRow, 2).Value = claim.PlanStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.PlanCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCode"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceDescription"; worksheet.Cell(currentRow, 2).Value = claim.ServiceDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceCreator"; worksheet.Cell(currentRow, 2).Value = claim.ServiceCreator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceStartDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ServiceEndDate"; worksheet.Cell(currentRow, 2).Value = claim.ServiceEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanStatusDate"; worksheet.Cell(currentRow, 2).Value = claim.PlanStatusDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCmpservices(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCmpservice(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpservice");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptCmpservice";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CmpStatus";
                worksheet.Cell(currentRow, 4).Value = "GoalName";
                worksheet.Cell(currentRow, 5).Value = "GoalOutcome";
                worksheet.Cell(currentRow, 6).Value = "GoalDescription";
                worksheet.Cell(currentRow, 7).Value = "GoalCreationDate";
                worksheet.Cell(currentRow, 8).Value = "GoalOutcomeDate";
                worksheet.Cell(currentRow, 9).Value = "CmpGoalDate";
                worksheet.Cell(currentRow, 10).Value = "PlanName";
                worksheet.Cell(currentRow, 11).Value = "PlanNotes";
                worksheet.Cell(currentRow, 12).Value = "PlanStatus";
                worksheet.Cell(currentRow, 13).Value = "PlanCreationDate";
                worksheet.Cell(currentRow, 14).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 15).Value = "ClaimType";
                worksheet.Cell(currentRow, 16).Value = "GoalReason";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CmpStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GoalName;
                    worksheet.Cell(currentRow, 5).Value = claim.GoalOutcome;
                    worksheet.Cell(currentRow, 6).Value = claim.GoalDescription;
                    worksheet.Cell(currentRow, 7).Value = claim.GoalCreationDate;
                    worksheet.Cell(currentRow, 8).Value = claim.GoalOutcomeDate;
                    worksheet.Cell(currentRow, 9).Value = claim.CmpGoalDate;
                    worksheet.Cell(currentRow, 10).Value = claim.PlanName;
                    worksheet.Cell(currentRow, 11).Value = claim.PlanNotes;
                    worksheet.Cell(currentRow, 12).Value = claim.PlanStatus;
                    worksheet.Cell(currentRow, 13).Value = claim.PlanCreationDate;
                    worksheet.Cell(currentRow, 14).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 15).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 16).Value = claim.GoalReason;
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

        public async Task<byte[]> GetRptCmpservice(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCmpservice(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCmpservice");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptCmpservice";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpStatus"; worksheet.Cell(currentRow, 2).Value = claim.CmpStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalName"; worksheet.Cell(currentRow, 2).Value = claim.GoalName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalOutcome"; worksheet.Cell(currentRow, 2).Value = claim.GoalOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalDescription"; worksheet.Cell(currentRow, 2).Value = claim.GoalDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.GoalCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalOutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.GoalOutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CmpGoalDate"; worksheet.Cell(currentRow, 2).Value = claim.CmpGoalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanName"; worksheet.Cell(currentRow, 2).Value = claim.PlanName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanNotes"; worksheet.Cell(currentRow, 2).Value = claim.PlanNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanStatus"; worksheet.Cell(currentRow, 2).Value = claim.PlanStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlanCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.PlanCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalReason"; worksheet.Cell(currentRow, 2).Value = claim.GoalReason;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptCompliants(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptCompliant(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCompliant");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptCompliant";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNo";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "FirstName";
                worksheet.Cell(currentRow, 5).Value = "Gender";
                worksheet.Cell(currentRow, 6).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 7).Value = "PolicyNo1";
                worksheet.Cell(currentRow, 8).Value = "GroupRetail1";
                worksheet.Cell(currentRow, 9).Value = "BenefitType1";
                worksheet.Cell(currentRow, 10).Value = "BenefitStatus1";
                worksheet.Cell(currentRow, 11).Value = "PolicyNo2";
                worksheet.Cell(currentRow, 12).Value = "GroupRetail2";
                worksheet.Cell(currentRow, 13).Value = "BenefitType2";
                worksheet.Cell(currentRow, 14).Value = "BenefitStatus2";
                worksheet.Cell(currentRow, 15).Value = "PolicyNo3";
                worksheet.Cell(currentRow, 16).Value = "GroupRetail3";
                worksheet.Cell(currentRow, 17).Value = "BenefitType3";
                worksheet.Cell(currentRow, 18).Value = "BenefitStatus3";
                worksheet.Cell(currentRow, 19).Value = "PolicyNo4";
                worksheet.Cell(currentRow, 20).Value = "GroupRetail4";
                worksheet.Cell(currentRow, 21).Value = "BenefitType4";
                worksheet.Cell(currentRow, 22).Value = "BenefitStatus4";
                worksheet.Cell(currentRow, 23).Value = "ClaimStatus";
                worksheet.Cell(currentRow, 24).Value = "ComplaintIdNo";
                worksheet.Cell(currentRow, 25).Value = "ComplaintNotificationDate";
                worksheet.Cell(currentRow, 26).Value = "RaisedBy";
                worksheet.Cell(currentRow, 27).Value = "ComplaintTheme1";
                worksheet.Cell(currentRow, 28).Value = "ComplaintTheme2";
                worksheet.Cell(currentRow, 29).Value = "ComplaintTheme3";
                worksheet.Cell(currentRow, 30).Value = "ComplaintTheme4";
                worksheet.Cell(currentRow, 31).Value = "ComplaintTheme5";
                worksheet.Cell(currentRow, 32).Value = "ComplaintType";
                worksheet.Cell(currentRow, 33).Value = "Method1";
                worksheet.Cell(currentRow, 34).Value = "ComplaintSource1";
                worksheet.Cell(currentRow, 35).Value = "Method2";
                worksheet.Cell(currentRow, 36).Value = "ComplaintSource2";
                worksheet.Cell(currentRow, 37).Value = "Method3";
                worksheet.Cell(currentRow, 38).Value = "ComplaintSource3";
                worksheet.Cell(currentRow, 39).Value = "ComplaintStatus";
                worksheet.Cell(currentRow, 40).Value = "ComplaintOwner";
                worksheet.Cell(currentRow, 41).Value = "EscalationDate";
                worksheet.Cell(currentRow, 42).Value = "NoOfDaysComplaintOpen";
                worksheet.Cell(currentRow, 43).Value = "ClosureDate";
                worksheet.Cell(currentRow, 44).Value = "ClosureReason";
                worksheet.Cell(currentRow, 45).Value = "AcknowLetterSlaMetYN";
                worksheet.Cell(currentRow, 46).Value = "DaysToSendAcknowLetter";
                worksheet.Cell(currentRow, 47).Value = "LetterToTrusteeSlaMetYN";
                worksheet.Cell(currentRow, 48).Value = "DaysToSendTrusteeLetter";
                worksheet.Cell(currentRow, 49).Value = "NonSuperLetterSlaMetYN";
                worksheet.Cell(currentRow, 50).Value = "DaysToSendNonSuperLetter";
                worksheet.Cell(currentRow, 51).Value = "SuperLetterSlaMetYN";
                worksheet.Cell(currentRow, 52).Value = "DaysToSendSuperLetter";
                worksheet.Cell(currentRow, 53).Value = "TmOfComplaintRecordOwner";
                worksheet.Cell(currentRow, 54).Value = "TmOfClaimCaseOwner";
                worksheet.Cell(currentRow, 55).Value = "ComplaintRecordTeamName";
                worksheet.Cell(currentRow, 56).Value = "EscalationApprovedByTm";
                worksheet.Cell(currentRow, 57).Value = "EscalationDeclinedByTm";
                worksheet.Cell(currentRow, 58).Value = "EscalationToTm";
                worksheet.Cell(currentRow, 59).Value = "CatEscalationApproved";
                worksheet.Cell(currentRow, 60).Value = "CatEscalationDeclined";
                worksheet.Cell(currentRow, 61).Value = "EscalationToCat";
                worksheet.Cell(currentRow, 62).Value = "ClassOfBusiness";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNo;
                    worksheet.Cell(currentRow, 3).Value = claim.LastName;
                    worksheet.Cell(currentRow, 4).Value = claim.FirstName;
                    worksheet.Cell(currentRow, 5).Value = claim.Gender;
                    worksheet.Cell(currentRow, 6).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 7).Value = claim.PolicyNo1;
                    worksheet.Cell(currentRow, 8).Value = claim.GroupRetail1;
                    worksheet.Cell(currentRow, 9).Value = claim.BenefitType1;
                    worksheet.Cell(currentRow, 10).Value = claim.BenefitStatus1;
                    worksheet.Cell(currentRow, 11).Value = claim.PolicyNo2;
                    worksheet.Cell(currentRow, 12).Value = claim.GroupRetail2;
                    worksheet.Cell(currentRow, 13).Value = claim.BenefitType2;
                    worksheet.Cell(currentRow, 14).Value = claim.BenefitStatus2;
                    worksheet.Cell(currentRow, 15).Value = claim.PolicyNo3;
                    worksheet.Cell(currentRow, 16).Value = claim.GroupRetail3;
                    worksheet.Cell(currentRow, 17).Value = claim.BenefitType3;
                    worksheet.Cell(currentRow, 18).Value = claim.BenefitStatus3;
                    worksheet.Cell(currentRow, 19).Value = claim.PolicyNo4;
                    worksheet.Cell(currentRow, 20).Value = claim.GroupRetail4;
                    worksheet.Cell(currentRow, 21).Value = claim.BenefitType4;
                    worksheet.Cell(currentRow, 22).Value = claim.BenefitStatus4;
                    worksheet.Cell(currentRow, 23).Value = claim.ClaimStatus;
                    worksheet.Cell(currentRow, 24).Value = claim.ComplaintIdNo;
                    worksheet.Cell(currentRow, 25).Value = claim.ComplaintNotificationDate;
                    worksheet.Cell(currentRow, 26).Value = claim.RaisedBy;
                    worksheet.Cell(currentRow, 27).Value = claim.ComplaintTheme1;
                    worksheet.Cell(currentRow, 28).Value = claim.ComplaintTheme2;
                    worksheet.Cell(currentRow, 29).Value = claim.ComplaintTheme3;
                    worksheet.Cell(currentRow, 30).Value = claim.ComplaintTheme4;
                    worksheet.Cell(currentRow, 31).Value = claim.ComplaintTheme5;
                    worksheet.Cell(currentRow, 32).Value = claim.ComplaintType;
                    worksheet.Cell(currentRow, 33).Value = claim.Method1;
                    worksheet.Cell(currentRow, 34).Value = claim.ComplaintSource1;
                    worksheet.Cell(currentRow, 35).Value = claim.Method2;
                    worksheet.Cell(currentRow, 36).Value = claim.ComplaintSource2;
                    worksheet.Cell(currentRow, 37).Value = claim.Method3;
                    worksheet.Cell(currentRow, 38).Value = claim.ComplaintSource3;
                    worksheet.Cell(currentRow, 39).Value = claim.ComplaintStatus;
                    worksheet.Cell(currentRow, 40).Value = claim.ComplaintOwner;
                    worksheet.Cell(currentRow, 41).Value = claim.EscalationDate;
                    worksheet.Cell(currentRow, 42).Value = claim.NoOfDaysComplaintOpen;
                    worksheet.Cell(currentRow, 43).Value = claim.ClosureDate;
                    worksheet.Cell(currentRow, 44).Value = claim.ClosureReason;
                    worksheet.Cell(currentRow, 45).Value = claim.AcknowLetterSlaMetYN;
                    worksheet.Cell(currentRow, 46).Value = claim.DaysToSendAcknowLetter;
                    worksheet.Cell(currentRow, 47).Value = claim.LetterToTrusteeSlaMetYN;
                    worksheet.Cell(currentRow, 48).Value = claim.DaysToSendTrusteeLetter;
                    worksheet.Cell(currentRow, 49).Value = claim.NonSuperLetterSlaMetYN;
                    worksheet.Cell(currentRow, 50).Value = claim.DaysToSendNonSuperLetter;
                    worksheet.Cell(currentRow, 51).Value = claim.SuperLetterSlaMetYN;
                    worksheet.Cell(currentRow, 52).Value = claim.DaysToSendSuperLetter;
                    worksheet.Cell(currentRow, 53).Value = claim.TmOfComplaintRecordOwner;
                    worksheet.Cell(currentRow, 54).Value = claim.TmOfClaimCaseOwner;
                    worksheet.Cell(currentRow, 55).Value = claim.ComplaintRecordTeamName;
                    worksheet.Cell(currentRow, 56).Value = claim.EscalationApprovedByTm;
                    worksheet.Cell(currentRow, 57).Value = claim.EscalationDeclinedByTm;
                    worksheet.Cell(currentRow, 58).Value = claim.EscalationToTm;
                    worksheet.Cell(currentRow, 59).Value = claim.CatEscalationApproved;
                    worksheet.Cell(currentRow, 60).Value = claim.CatEscalationDeclined;
                    worksheet.Cell(currentRow, 61).Value = claim.EscalationToCat;
                    worksheet.Cell(currentRow, 62).Value = claim.ClassOfBusiness;
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

        public async Task<byte[]> GetRptCompliant(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptCompliant(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptCompliant");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptCompliant";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNo"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastName"; worksheet.Cell(currentRow, 2).Value = claim.LastName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FirstName"; worksheet.Cell(currentRow, 2).Value = claim.FirstName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Gender"; worksheet.Cell(currentRow, 2).Value = claim.Gender;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNo1"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNo1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupRetail1"; worksheet.Cell(currentRow, 2).Value = claim.GroupRetail1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType1"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus1"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNo2"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNo2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupRetail2"; worksheet.Cell(currentRow, 2).Value = claim.GroupRetail2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType2"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus2"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNo3"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNo3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupRetail3"; worksheet.Cell(currentRow, 2).Value = claim.GroupRetail3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType3"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus3"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNo4"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNo4;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupRetail4"; worksheet.Cell(currentRow, 2).Value = claim.GroupRetail4;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType4"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType4;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStatus4"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStatus4;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimStatus"; worksheet.Cell(currentRow, 2).Value = claim.ClaimStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintIdNo"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintIdNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintNotificationDate"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintNotificationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RaisedBy"; worksheet.Cell(currentRow, 2).Value = claim.RaisedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintTheme1"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintTheme1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintTheme2"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintTheme2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintTheme3"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintTheme3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintTheme4"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintTheme4;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintTheme5"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintTheme5;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintType"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Method1"; worksheet.Cell(currentRow, 2).Value = claim.Method1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintSource1"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintSource1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Method2"; worksheet.Cell(currentRow, 2).Value = claim.Method2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintSource2"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintSource2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Method3"; worksheet.Cell(currentRow, 2).Value = claim.Method3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintSource3"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintSource3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintStatus"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintOwner"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EscalationDate"; worksheet.Cell(currentRow, 2).Value = claim.EscalationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NoOfDaysComplaintOpen"; worksheet.Cell(currentRow, 2).Value = claim.NoOfDaysComplaintOpen;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClosureDate"; worksheet.Cell(currentRow, 2).Value = claim.ClosureDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClosureReason"; worksheet.Cell(currentRow, 2).Value = claim.ClosureReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AcknowLetterSlaMetYN"; worksheet.Cell(currentRow, 2).Value = claim.AcknowLetterSlaMetYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysToSendAcknowLetter"; worksheet.Cell(currentRow, 2).Value = claim.DaysToSendAcknowLetter;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LetterToTrusteeSlaMetYN"; worksheet.Cell(currentRow, 2).Value = claim.LetterToTrusteeSlaMetYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysToSendTrusteeLetter"; worksheet.Cell(currentRow, 2).Value = claim.DaysToSendTrusteeLetter;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NonSuperLetterSlaMetYN"; worksheet.Cell(currentRow, 2).Value = claim.NonSuperLetterSlaMetYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysToSendNonSuperLetter"; worksheet.Cell(currentRow, 2).Value = claim.DaysToSendNonSuperLetter;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperLetterSlaMetYN"; worksheet.Cell(currentRow, 2).Value = claim.SuperLetterSlaMetYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysToSendSuperLetter"; worksheet.Cell(currentRow, 2).Value = claim.DaysToSendSuperLetter;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TmOfComplaintRecordOwner"; worksheet.Cell(currentRow, 2).Value = claim.TmOfComplaintRecordOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TmOfClaimCaseOwner"; worksheet.Cell(currentRow, 2).Value = claim.TmOfClaimCaseOwner;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ComplaintRecordTeamName"; worksheet.Cell(currentRow, 2).Value = claim.ComplaintRecordTeamName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EscalationApprovedByTm"; worksheet.Cell(currentRow, 2).Value = claim.EscalationApprovedByTm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EscalationDeclinedByTm"; worksheet.Cell(currentRow, 2).Value = claim.EscalationDeclinedByTm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EscalationToTm"; worksheet.Cell(currentRow, 2).Value = claim.EscalationToTm;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CatEscalationApproved"; worksheet.Cell(currentRow, 2).Value = claim.CatEscalationApproved;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CatEscalationDeclined"; worksheet.Cell(currentRow, 2).Value = claim.CatEscalationDeclined;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EscalationToCat"; worksheet.Cell(currentRow, 2).Value = claim.EscalationToCat;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptDocumentreports(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchRptDocumentreport(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptDocumentreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " RptDocumentreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "CaseNumber";
                worksheet.Cell(currentRow, 3).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 4).Value = "CaseType";
                worksheet.Cell(currentRow, 5).Value = "DocumentType";
                worksheet.Cell(currentRow, 6).Value = "DocumentId";
                worksheet.Cell(currentRow, 7).Value = "DateCreatedInAble";
                worksheet.Cell(currentRow, 8).Value = "CreatedBy";
                worksheet.Cell(currentRow, 9).Value = "LastUpdatedBy";
                worksheet.Cell(currentRow, 10).Value = "Status";
                worksheet.Cell(currentRow, 11).Value = "Description";
                worksheet.Cell(currentRow, 12).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 13).Value = "ClaimType";
                worksheet.Cell(currentRow, 14).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.CaseNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 5).Value = claim.DocumentType;
                    worksheet.Cell(currentRow, 6).Value = claim.DocumentId;
                    worksheet.Cell(currentRow, 7).Value = claim.DateCreatedInAble;
                    worksheet.Cell(currentRow, 8).Value = claim.CreatedBy;
                    worksheet.Cell(currentRow, 9).Value = claim.LastUpdatedBy;
                    worksheet.Cell(currentRow, 10).Value = claim.Status;
                    worksheet.Cell(currentRow, 11).Value = claim.Description;
                    worksheet.Cell(currentRow, 12).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 13).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 14).Value = GetAppName(claim.ApplicationId);
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

        public async Task<byte[]> GetRptDocumentreport(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptDocumentreport(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptDocumentreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " RptDocumentreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseNumber"; worksheet.Cell(currentRow, 2).Value = claim.CaseNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentType"; worksheet.Cell(currentRow, 2).Value = claim.DocumentType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentId"; worksheet.Cell(currentRow, 2).Value = claim.DocumentId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreatedInAble"; worksheet.Cell(currentRow, 2).Value = claim.DateCreatedInAble;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreatedBy"; worksheet.Cell(currentRow, 2).Value = claim.CreatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdatedBy"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptEnquirycasereports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptEnquirycasereport(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptEnquirycasereport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptEnquirycasereport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "EnquiryNumber";
                worksheet.Cell(currentRow, 3).Value = "EnquiryCaseStatus";
                worksheet.Cell(currentRow, 4).Value = "GivenName";
                worksheet.Cell(currentRow, 5).Value = "Surname";
                worksheet.Cell(currentRow, 6).Value = "Sex";
                worksheet.Cell(currentRow, 7).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 8).Value = "PostCode";
                worksheet.Cell(currentRow, 9).Value = "CaseManager";
                worksheet.Cell(currentRow, 10).Value = "Team";
                worksheet.Cell(currentRow, 11).Value = "CreationDate";
                worksheet.Cell(currentRow, 12).Value = "IncurredDate";
                worksheet.Cell(currentRow, 13).Value = "Source";
                worksheet.Cell(currentRow, 14).Value = "ContactDate";
                worksheet.Cell(currentRow, 15).Value = "Notifier";
                worksheet.Cell(currentRow, 16).Value = "IfOther";
                worksheet.Cell(currentRow, 17).Value = "NatureOfIllnessOrInjury";
                worksheet.Cell(currentRow, 18).Value = "NatureOfIncident";
                worksheet.Cell(currentRow, 19).Value = "Description";
                worksheet.Cell(currentRow, 20).Value = "Product";
                worksheet.Cell(currentRow, 21).Value = "ContractStatus";
                worksheet.Cell(currentRow, 22).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 23).Value = "CommencementDate";
                worksheet.Cell(currentRow, 24).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 25).Value = "ClaimType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.EnquiryNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.EnquiryCaseStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.GivenName;
                    worksheet.Cell(currentRow, 5).Value = claim.Surname;
                    worksheet.Cell(currentRow, 6).Value = claim.Sex;
                    worksheet.Cell(currentRow, 7).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 8).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 9).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 10).Value = claim.Team;
                    worksheet.Cell(currentRow, 11).Value = claim.CreationDate;
                    worksheet.Cell(currentRow, 12).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 13).Value = claim.Source;
                    worksheet.Cell(currentRow, 14).Value = claim.ContactDate;
                    worksheet.Cell(currentRow, 15).Value = claim.Notifier;
                    worksheet.Cell(currentRow, 16).Value = claim.IfOther;
                    worksheet.Cell(currentRow, 17).Value = claim.NatureOfIllnessOrInjury;
                    worksheet.Cell(currentRow, 18).Value = claim.NatureOfIncident;
                    worksheet.Cell(currentRow, 19).Value = claim.Description;
                    worksheet.Cell(currentRow, 20).Value = claim.Product;
                    worksheet.Cell(currentRow, 21).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 22).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 23).Value = claim.CommencementDate;
                    worksheet.Cell(currentRow, 24).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 25).Value = claim.ClaimType;
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

        public async Task<byte[]> GetRptEnquirycasereport(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptEnquirycasereport(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptEnquirycasereport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptEnquirycasereport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EnquiryNumber"; worksheet.Cell(currentRow, 2).Value = claim.EnquiryNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EnquiryCaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.EnquiryCaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GivenName"; worksheet.Cell(currentRow, 2).Value = claim.GivenName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Surname"; worksheet.Cell(currentRow, 2).Value = claim.Surname;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Sex"; worksheet.Cell(currentRow, 2).Value = claim.Sex;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Team"; worksheet.Cell(currentRow, 2).Value = claim.Team;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreationDate"; worksheet.Cell(currentRow, 2).Value = claim.CreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactDate"; worksheet.Cell(currentRow, 2).Value = claim.ContactDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Notifier"; worksheet.Cell(currentRow, 2).Value = claim.Notifier;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IfOther"; worksheet.Cell(currentRow, 2).Value = claim.IfOther;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NatureOfIllnessOrInjury"; worksheet.Cell(currentRow, 2).Value = claim.NatureOfIllnessOrInjury;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NatureOfIncident"; worksheet.Cell(currentRow, 2).Value = claim.NatureOfIncident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Product"; worksheet.Cell(currentRow, 2).Value = claim.Product;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CommencementDate"; worksheet.Cell(currentRow, 2).Value = claim.CommencementDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptHcrcompletednotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptHcrcompletednote(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptHcrcompletednote");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptHcrcompletednote";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "NoteType";
                worksheet.Cell(currentRow, 4).Value = "DateCreated";
                worksheet.Cell(currentRow, 5).Value = "Status";
                worksheet.Cell(currentRow, 6).Value = "DateOfStatusChange";
                worksheet.Cell(currentRow, 7).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 8).Value = "ClaimType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.NoteType;
                    worksheet.Cell(currentRow, 4).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 5).Value = claim.Status;
                    worksheet.Cell(currentRow, 6).Value = claim.DateOfStatusChange;
                    worksheet.Cell(currentRow, 7).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 8).Value = claim.ClaimType;
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

        public async Task<byte[]> GetRptHcrcompletednote(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptHcrcompletednote(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptHcrcompletednote");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptHcrcompletednote";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NoteType"; worksheet.Cell(currentRow, 2).Value = claim.NoteType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfStatusChange"; worksheet.Cell(currentRow, 2).Value = claim.DateOfStatusChange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptOpentasks(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptOpentask(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptOpentask");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptOpentask";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CaseStatus";
                worksheet.Cell(currentRow, 4).Value = "ClaimantName";
                worksheet.Cell(currentRow, 5).Value = "CaseType";
                worksheet.Cell(currentRow, 6).Value = "CaseManager";
                worksheet.Cell(currentRow, 7).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 8).Value = "TaskProcessStep";
                worksheet.Cell(currentRow, 9).Value = "TaskId";
                worksheet.Cell(currentRow, 10).Value = "TaskCode";
                worksheet.Cell(currentRow, 11).Value = "TaskName";
                worksheet.Cell(currentRow, 12).Value = "TaskDescription";
                worksheet.Cell(currentRow, 13).Value = "TaskStatus";
                worksheet.Cell(currentRow, 14).Value = "TaskAssignedToUser";
                worksheet.Cell(currentRow, 15).Value = "TaskAssignedToRole";
                worksheet.Cell(currentRow, 16).Value = "TaskCreatedByUser";
                worksheet.Cell(currentRow, 17).Value = "TaskCreatedDate";
                worksheet.Cell(currentRow, 18).Value = "TaskCompletedByUser";
                worksheet.Cell(currentRow, 19).Value = "TaskCompletedDate";
                worksheet.Cell(currentRow, 20).Value = "BenchmarkDays";
                worksheet.Cell(currentRow, 21).Value = "BenchmarkDate";
                worksheet.Cell(currentRow, 22).Value = "ProductName";
                worksheet.Cell(currentRow, 23).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 24).Value = "BenefitCode";
                worksheet.Cell(currentRow, 25).Value = "BenefitDescription";
                worksheet.Cell(currentRow, 26).Value = "TaskCreatedByTeam";
                worksheet.Cell(currentRow, 27).Value = "TaskCompletedByTeam";
                worksheet.Cell(currentRow, 28).Value = "OriginalTaskTargetDate";
                worksheet.Cell(currentRow, 29).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 30).Value = "ClaimType";
                worksheet.Cell(currentRow, 31).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 32).Value = "ProductCode";
                worksheet.Cell(currentRow, 33).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 34).Value = "TaskTeamQueue";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CaseStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 6).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 8).Value = claim.TaskProcessStep;
                    worksheet.Cell(currentRow, 9).Value = claim.TaskId;
                    worksheet.Cell(currentRow, 10).Value = claim.TaskCode;
                    worksheet.Cell(currentRow, 11).Value = claim.TaskName;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskDescription;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.TaskAssignedToUser;
                    worksheet.Cell(currentRow, 15).Value = claim.TaskAssignedToRole;
                    worksheet.Cell(currentRow, 16).Value = claim.TaskCreatedByUser;
                    worksheet.Cell(currentRow, 17).Value = claim.TaskCreatedDate;
                    worksheet.Cell(currentRow, 18).Value = claim.TaskCompletedByUser;
                    worksheet.Cell(currentRow, 19).Value = claim.TaskCompletedDate;
                    worksheet.Cell(currentRow, 20).Value = claim.BenchmarkDays;
                    worksheet.Cell(currentRow, 21).Value = claim.BenchmarkDate;
                    worksheet.Cell(currentRow, 22).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 23).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 24).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 25).Value = claim.BenefitDescription;
                    worksheet.Cell(currentRow, 26).Value = claim.TaskCreatedByTeam;
                    worksheet.Cell(currentRow, 27).Value = claim.TaskCompletedByTeam;
                    worksheet.Cell(currentRow, 28).Value = claim.OriginalTaskTargetDate;
                    worksheet.Cell(currentRow, 29).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 31).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 32).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 33).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 34).Value = claim.TaskTeamQueue;
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

        public async Task<byte[]> GetRptOpentask(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptOpentask(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptOpentask");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptOpentask";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.CaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskProcessStep"; worksheet.Cell(currentRow, 2).Value = claim.TaskProcessStep;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskId"; worksheet.Cell(currentRow, 2).Value = claim.TaskId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCode"; worksheet.Cell(currentRow, 2).Value = claim.TaskCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskName"; worksheet.Cell(currentRow, 2).Value = claim.TaskName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskDescription"; worksheet.Cell(currentRow, 2).Value = claim.TaskDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskStatus"; worksheet.Cell(currentRow, 2).Value = claim.TaskStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToRole"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToRole;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDays"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDays;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDate"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTaskTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTaskTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskTeamQueue"; worksheet.Cell(currentRow, 2).Value = claim.TaskTeamQueue;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptOverrideriskreports(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptOverrideriskreport(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptOverrideriskreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptOverrideriskreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "OverrideProcessedBy";
                worksheet.Cell(currentRow, 3).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 4).Value = "ClaimType";
                worksheet.Cell(currentRow, 5).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 6).Value = "RiskCategory";
                worksheet.Cell(currentRow, 7).Value = "RiskCategoryCreationDate";
                worksheet.Cell(currentRow, 8).Value = "OverrideRiskCategory";
                worksheet.Cell(currentRow, 9).Value = "OverrideRiskCategoryReason";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.OverrideProcessedBy;
                    worksheet.Cell(currentRow, 3).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 5).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 6).Value = claim.RiskCategory;
                    worksheet.Cell(currentRow, 7).Value = claim.RiskCategoryCreationDate;
                    worksheet.Cell(currentRow, 8).Value = claim.OverrideRiskCategory;
                    worksheet.Cell(currentRow, 9).Value = claim.OverrideRiskCategoryReason;
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

        public async Task<byte[]> GetRptOverrideriskreport(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptOverrideriskreport(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptOverrideriskreport");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptOverrideriskreport";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideProcessedBy"; worksheet.Cell(currentRow, 2).Value = claim.OverrideProcessedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RiskCategoryCreationDate"; worksheet.Cell(currentRow, 2).Value = claim.RiskCategoryCreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategory"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideRiskCategoryReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideRiskCategoryReason;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetRptPaymentsummaryls(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptPaymentsummaryl(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptPaymentsummaryl");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptPaymentsummaryl";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 4).Value = "EFormId";
                worksheet.Cell(currentRow, 5).Value = "LastUpdateDate";
                worksheet.Cell(currentRow, 6).Value = "PolicyType";
                worksheet.Cell(currentRow, 7).Value = "ConcurrentClaimYN";
                worksheet.Cell(currentRow, 8).Value = "ClaimType";
                worksheet.Cell(currentRow, 9).Value = "GroupOrRetail";
                worksheet.Cell(currentRow, 10).Value = "PaymentType";
                worksheet.Cell(currentRow, 11).Value = "BenefitAmtCalc";
                worksheet.Cell(currentRow, 12).Value = "DateCeasedWork";
                worksheet.Cell(currentRow, 13).Value = "IncurredDate";
                worksheet.Cell(currentRow, 14).Value = "AcceptFrom";
                worksheet.Cell(currentRow, 15).Value = "BenefitPayable";
                worksheet.Cell(currentRow, 16).Value = "InvestmentAmount";
                worksheet.Cell(currentRow, 17).Value = "Bonus";
                worksheet.Cell(currentRow, 18).Value = "OtherTaxable";
                worksheet.Cell(currentRow, 19).Value = "TotalGrossAmount";
                worksheet.Cell(currentRow, 20).Value = "OtherNonTaxable";
                worksheet.Cell(currentRow, 21).Value = "TaxValue";
                worksheet.Cell(currentRow, 22).Value = "TotalNetAmount";
                worksheet.Cell(currentRow, 23).Value = "PartialWdrwlTferReq";
                worksheet.Cell(currentRow, 24).Value = "PartialWdrawalTferAmt";
                worksheet.Cell(currentRow, 25).Value = "TaxDollar";
                worksheet.Cell(currentRow, 26).Value = "CaldNetAmount";
                worksheet.Cell(currentRow, 27).Value = "PaymentAddtnlInfo";
                worksheet.Cell(currentRow, 28).Value = "PaymentMethod";
                worksheet.Cell(currentRow, 29).Value = "ForGroupPayee";
                worksheet.Cell(currentRow, 30).Value = "AdminReqdWdrawal";
                worksheet.Cell(currentRow, 31).Value = "PolicyDelinkedYN";
                worksheet.Cell(currentRow, 32).Value = "DelinkedPolicyDetails";
                worksheet.Cell(currentRow, 33).Value = "AdminDeletePolicyYN";
                worksheet.Cell(currentRow, 34).Value = "AdminDeleteProcDate";
                worksheet.Cell(currentRow, 35).Value = "PremRefundReqdYN";
                worksheet.Cell(currentRow, 36).Value = "RemaingCoverYN";
                worksheet.Cell(currentRow, 37).Value = "BuyBackOption";
                worksheet.Cell(currentRow, 38).Value = "BuyBackOptionEffDate";
                worksheet.Cell(currentRow, 39).Value = "TrmaReinstmntApplYN";
                worksheet.Cell(currentRow, 40).Value = "FinancialPlanningBftYN";
                worksheet.Cell(currentRow, 41).Value = "FinancialPlanningBftAmt";
                worksheet.Cell(currentRow, 42).Value = "OtherPaymentInfo";
                worksheet.Cell(currentRow, 43).Value = "ProcessDate";
                worksheet.Cell(currentRow, 44).Value = "AuthoriseDate";
                worksheet.Cell(currentRow, 45).Value = "OtherAdminInfo";
                worksheet.Cell(currentRow, 46).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 47).Value = "ClaimTypeIpLs";
                worksheet.Cell(currentRow, 48).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 49).Value = "BenefitCode";
                worksheet.Cell(currentRow, 50).Value = "ProductCode";
                worksheet.Cell(currentRow, 51).Value = "BenefitType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.EFormId;
                    worksheet.Cell(currentRow, 5).Value = claim.LastUpdateDate;
                    worksheet.Cell(currentRow, 6).Value = claim.PolicyType;
                    worksheet.Cell(currentRow, 7).Value = claim.ConcurrentClaimYN;
                    worksheet.Cell(currentRow, 8).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 9).Value = claim.GroupOrRetail;
                    worksheet.Cell(currentRow, 10).Value = claim.PaymentType;
                    worksheet.Cell(currentRow, 11).Value = claim.BenefitAmtCalc;
                    worksheet.Cell(currentRow, 12).Value = claim.DateCeasedWork;
                    worksheet.Cell(currentRow, 13).Value = claim.IncurredDate;
                    worksheet.Cell(currentRow, 14).Value = claim.AcceptFrom;
                    worksheet.Cell(currentRow, 15).Value = claim.BenefitPayable;
                    worksheet.Cell(currentRow, 16).Value = claim.InvestmentAmount;
                    worksheet.Cell(currentRow, 17).Value = claim.Bonus;
                    worksheet.Cell(currentRow, 18).Value = claim.OtherTaxable;
                    worksheet.Cell(currentRow, 19).Value = claim.TotalGrossAmount;
                    worksheet.Cell(currentRow, 20).Value = claim.OtherNonTaxable;
                    worksheet.Cell(currentRow, 21).Value = claim.TaxValue;
                    worksheet.Cell(currentRow, 22).Value = claim.TotalNetAmount;
                    worksheet.Cell(currentRow, 23).Value = claim.PartialWdrwlTferReq;
                    worksheet.Cell(currentRow, 24).Value = claim.PartialWdrawalTferAmt;
                    worksheet.Cell(currentRow, 25).Value = claim.TaxDollar;
                    worksheet.Cell(currentRow, 26).Value = claim.CaldNetAmount;
                    worksheet.Cell(currentRow, 27).Value = claim.PaymentAddtnlInfo;
                    worksheet.Cell(currentRow, 28).Value = claim.PaymentMethod;
                    worksheet.Cell(currentRow, 29).Value = claim.ForGroupPayee;
                    worksheet.Cell(currentRow, 30).Value = claim.AdminReqdWdrawal;
                    worksheet.Cell(currentRow, 31).Value = claim.PolicyDelinkedYN;
                    worksheet.Cell(currentRow, 32).Value = claim.DelinkedPolicyDetails;
                    worksheet.Cell(currentRow, 33).Value = claim.AdminDeletePolicyYN;
                    worksheet.Cell(currentRow, 34).Value = claim.AdminDeleteProcDate;
                    worksheet.Cell(currentRow, 35).Value = claim.PremRefundReqdYN;
                    worksheet.Cell(currentRow, 36).Value = claim.RemaingCoverYN;
                    worksheet.Cell(currentRow, 37).Value = claim.BuyBackOption;
                    worksheet.Cell(currentRow, 38).Value = claim.BuyBackOptionEffDate;
                    worksheet.Cell(currentRow, 39).Value = claim.TrmaReinstmntApplYN;
                    worksheet.Cell(currentRow, 40).Value = claim.FinancialPlanningBftYN;
                    worksheet.Cell(currentRow, 41).Value = claim.FinancialPlanningBftAmt;
                    worksheet.Cell(currentRow, 42).Value = claim.OtherPaymentInfo;
                    worksheet.Cell(currentRow, 43).Value = claim.ProcessDate;
                    worksheet.Cell(currentRow, 44).Value = claim.AuthoriseDate;
                    worksheet.Cell(currentRow, 45).Value = claim.OtherAdminInfo;
                    worksheet.Cell(currentRow, 46).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 47).Value = claim.ClaimTypeIpLs;
                    worksheet.Cell(currentRow, 48).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 49).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 50).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 51).Value = claim.BenefitType;
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

        public async Task<byte[]> GetRptPaymentsummaryl(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptPaymentsummaryl(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptPaymentsummaryl");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptPaymentsummaryl";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EFormId"; worksheet.Cell(currentRow, 2).Value = claim.EFormId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdateDate"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdateDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyType"; worksheet.Cell(currentRow, 2).Value = claim.PolicyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ConcurrentClaimYN"; worksheet.Cell(currentRow, 2).Value = claim.ConcurrentClaimYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupOrRetail"; worksheet.Cell(currentRow, 2).Value = claim.GroupOrRetail;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentType"; worksheet.Cell(currentRow, 2).Value = claim.PaymentType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitAmtCalc"; worksheet.Cell(currentRow, 2).Value = claim.BenefitAmtCalc;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCeasedWork"; worksheet.Cell(currentRow, 2).Value = claim.DateCeasedWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AcceptFrom"; worksheet.Cell(currentRow, 2).Value = claim.AcceptFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitPayable"; worksheet.Cell(currentRow, 2).Value = claim.BenefitPayable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InvestmentAmount"; worksheet.Cell(currentRow, 2).Value = claim.InvestmentAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Bonus"; worksheet.Cell(currentRow, 2).Value = claim.Bonus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OtherTaxable"; worksheet.Cell(currentRow, 2).Value = claim.OtherTaxable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TotalGrossAmount"; worksheet.Cell(currentRow, 2).Value = claim.TotalGrossAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OtherNonTaxable"; worksheet.Cell(currentRow, 2).Value = claim.OtherNonTaxable;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaxValue"; worksheet.Cell(currentRow, 2).Value = claim.TaxValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TotalNetAmount"; worksheet.Cell(currentRow, 2).Value = claim.TotalNetAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialWdrwlTferReq"; worksheet.Cell(currentRow, 2).Value = claim.PartialWdrwlTferReq;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartialWdrawalTferAmt"; worksheet.Cell(currentRow, 2).Value = claim.PartialWdrawalTferAmt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaxDollar"; worksheet.Cell(currentRow, 2).Value = claim.TaxDollar;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaldNetAmount"; worksheet.Cell(currentRow, 2).Value = claim.CaldNetAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentAddtnlInfo"; worksheet.Cell(currentRow, 2).Value = claim.PaymentAddtnlInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PaymentMethod"; worksheet.Cell(currentRow, 2).Value = claim.PaymentMethod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ForGroupPayee"; worksheet.Cell(currentRow, 2).Value = claim.ForGroupPayee;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminReqdWdrawal"; worksheet.Cell(currentRow, 2).Value = claim.AdminReqdWdrawal;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyDelinkedYN"; worksheet.Cell(currentRow, 2).Value = claim.PolicyDelinkedYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DelinkedPolicyDetails"; worksheet.Cell(currentRow, 2).Value = claim.DelinkedPolicyDetails;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminDeletePolicyYN"; worksheet.Cell(currentRow, 2).Value = claim.AdminDeletePolicyYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdminDeleteProcDate"; worksheet.Cell(currentRow, 2).Value = claim.AdminDeleteProcDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremRefundReqdYN"; worksheet.Cell(currentRow, 2).Value = claim.PremRefundReqdYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RemaingCoverYN"; worksheet.Cell(currentRow, 2).Value = claim.RemaingCoverYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BuyBackOption"; worksheet.Cell(currentRow, 2).Value = claim.BuyBackOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BuyBackOptionEffDate"; worksheet.Cell(currentRow, 2).Value = claim.BuyBackOptionEffDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TrmaReinstmntApplYN"; worksheet.Cell(currentRow, 2).Value = claim.TrmaReinstmntApplYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinancialPlanningBftYN"; worksheet.Cell(currentRow, 2).Value = claim.FinancialPlanningBftYN;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FinancialPlanningBftAmt"; worksheet.Cell(currentRow, 2).Value = claim.FinancialPlanningBftAmt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OtherPaymentInfo"; worksheet.Cell(currentRow, 2).Value = claim.OtherPaymentInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProcessDate"; worksheet.Cell(currentRow, 2).Value = claim.ProcessDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AuthoriseDate"; worksheet.Cell(currentRow, 2).Value = claim.AuthoriseDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OtherAdminInfo"; worksheet.Cell(currentRow, 2).Value = claim.OtherAdminInfo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTypeIpLs"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTypeIpLs;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitType"; worksheet.Cell(currentRow, 2).Value = claim.BenefitType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptPhoneenquirys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptPhoneenquiry(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptPhoneenquiry");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptPhoneenquiry";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "ReasonForContact";
                worksheet.Cell(currentRow, 4).Value = "DateOfContact";
                worksheet.Cell(currentRow, 5).Value = "DirectionOfContact";
                worksheet.Cell(currentRow, 6).Value = "ClaimantName";
                worksheet.Cell(currentRow, 7).Value = "ContactName";
                worksheet.Cell(currentRow, 8).Value = "MethodOfContact";
                worksheet.Cell(currentRow, 9).Value = "ContactMadeIndicator";
                worksheet.Cell(currentRow, 10).Value = "PhoneRecordingLink";
                worksheet.Cell(currentRow, 11).Value = "DurationOfContact";
                worksheet.Cell(currentRow, 12).Value = "UserName";
                worksheet.Cell(currentRow, 13).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 14).Value = "ClaimType";
                worksheet.Cell(currentRow, 15).Value = "ContactDescription";
                worksheet.Cell(currentRow, 16).Value = "Decision";
                worksheet.Cell(currentRow, 17).Value = "DecisionDate";
                worksheet.Cell(currentRow, 18).Value = "DecisionReason";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.ReasonForContact;
                    worksheet.Cell(currentRow, 4).Value = claim.DateOfContact;
                    worksheet.Cell(currentRow, 5).Value = claim.DirectionOfContact;
                    worksheet.Cell(currentRow, 6).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 7).Value = claim.ContactName;
                    worksheet.Cell(currentRow, 8).Value = claim.MethodOfContact;
                    worksheet.Cell(currentRow, 9).Value = claim.ContactMadeIndicator;
                    worksheet.Cell(currentRow, 10).Value = claim.PhoneRecordingLink;
                    worksheet.Cell(currentRow, 11).Value = claim.DurationOfContact;
                    worksheet.Cell(currentRow, 12).Value = claim.UserName;
                    worksheet.Cell(currentRow, 13).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 14).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 15).Value = claim.ContactDescription;
                    worksheet.Cell(currentRow, 16).Value = claim.Decision;
                    worksheet.Cell(currentRow, 17).Value = claim.DecisionDate;
                    worksheet.Cell(currentRow, 18).Value = claim.DecisionReason;
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

        public async Task<byte[]> GetRptPhoneenquiry(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptPhoneenquiry(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptPhoneenquiry");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptPhoneenquiry";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonForContact"; worksheet.Cell(currentRow, 2).Value = claim.ReasonForContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfContact"; worksheet.Cell(currentRow, 2).Value = claim.DateOfContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DirectionOfContact"; worksheet.Cell(currentRow, 2).Value = claim.DirectionOfContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactName"; worksheet.Cell(currentRow, 2).Value = claim.ContactName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MethodOfContact"; worksheet.Cell(currentRow, 2).Value = claim.MethodOfContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactMadeIndicator"; worksheet.Cell(currentRow, 2).Value = claim.ContactMadeIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PhoneRecordingLink"; worksheet.Cell(currentRow, 2).Value = claim.PhoneRecordingLink;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DurationOfContact"; worksheet.Cell(currentRow, 2).Value = claim.DurationOfContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserName"; worksheet.Cell(currentRow, 2).Value = claim.UserName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactDescription"; worksheet.Cell(currentRow, 2).Value = claim.ContactDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Decision"; worksheet.Cell(currentRow, 2).Value = claim.Decision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.DecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DecisionReason"; worksheet.Cell(currentRow, 2).Value = claim.DecisionReason;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptRecoveryrehabnotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptRecoveryrehabnote(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptRecoveryrehabnote");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptRecoveryrehabnote";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "NoteType";
                worksheet.Cell(currentRow, 4).Value = "DateCreated";
                worksheet.Cell(currentRow, 5).Value = "Status";
                worksheet.Cell(currentRow, 6).Value = "DateOfStatusChange";
                worksheet.Cell(currentRow, 7).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 8).Value = "ClaimType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.NoteType;
                    worksheet.Cell(currentRow, 4).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 5).Value = claim.Status;
                    worksheet.Cell(currentRow, 6).Value = claim.DateOfStatusChange;
                    worksheet.Cell(currentRow, 7).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 8).Value = claim.ClaimType;
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

        public async Task<byte[]> GetRptRecoveryrehabnote(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptRecoveryrehabnote(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptRecoveryrehabnote");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptRecoveryrehabnote";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NoteType"; worksheet.Cell(currentRow, 2).Value = claim.NoteType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfStatusChange"; worksheet.Cell(currentRow, 2).Value = claim.DateOfStatusChange;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptTaskreportgroups(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptTaskreportgroup(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptTaskreportgroup");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptTaskreportgroup";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 3).Value = "CaseStatus";
                worksheet.Cell(currentRow, 4).Value = "ClaimantName";
                worksheet.Cell(currentRow, 5).Value = "CaseType";
                worksheet.Cell(currentRow, 6).Value = "CaseManager";
                worksheet.Cell(currentRow, 7).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 8).Value = "TaskProcessStep";
                worksheet.Cell(currentRow, 9).Value = "TaskId";
                worksheet.Cell(currentRow, 10).Value = "TaskCode";
                worksheet.Cell(currentRow, 11).Value = "TaskName";
                worksheet.Cell(currentRow, 12).Value = "TaskDescription";
                worksheet.Cell(currentRow, 13).Value = "TaskStatus";
                worksheet.Cell(currentRow, 14).Value = "TaskAssignedToUser";
                worksheet.Cell(currentRow, 15).Value = "TaskAssignedToRole";
                worksheet.Cell(currentRow, 16).Value = "TaskCreatedByUser";
                worksheet.Cell(currentRow, 17).Value = "TaskCreatedDate";
                worksheet.Cell(currentRow, 18).Value = "TaskCompletedByUser";
                worksheet.Cell(currentRow, 19).Value = "TaskCompletedDate";
                worksheet.Cell(currentRow, 20).Value = "BenchmarkDays";
                worksheet.Cell(currentRow, 21).Value = "BenchmarkDate";
                worksheet.Cell(currentRow, 22).Value = "ProductName";
                worksheet.Cell(currentRow, 23).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 24).Value = "BenefitCode";
                worksheet.Cell(currentRow, 25).Value = "BenefitDescription";
                worksheet.Cell(currentRow, 26).Value = "TaskCreatedByTeam";
                worksheet.Cell(currentRow, 27).Value = "TaskCompletedByTeam";
                worksheet.Cell(currentRow, 28).Value = "OriginalTaskTargetDate";
                worksheet.Cell(currentRow, 29).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 30).Value = "ClaimType";
                worksheet.Cell(currentRow, 31).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 32).Value = "ProductCode";
                worksheet.Cell(currentRow, 33).Value = "TargetBenefitType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 3).Value = claim.CaseStatus;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 6).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 8).Value = claim.TaskProcessStep;
                    worksheet.Cell(currentRow, 9).Value = claim.TaskId;
                    worksheet.Cell(currentRow, 10).Value = claim.TaskCode;
                    worksheet.Cell(currentRow, 11).Value = claim.TaskName;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskDescription;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.TaskAssignedToUser;
                    worksheet.Cell(currentRow, 15).Value = claim.TaskAssignedToRole;
                    worksheet.Cell(currentRow, 16).Value = claim.TaskCreatedByUser;
                    worksheet.Cell(currentRow, 17).Value = claim.TaskCreatedDate;
                    worksheet.Cell(currentRow, 18).Value = claim.TaskCompletedByUser;
                    worksheet.Cell(currentRow, 19).Value = claim.TaskCompletedDate;
                    worksheet.Cell(currentRow, 20).Value = claim.BenchmarkDays;
                    worksheet.Cell(currentRow, 21).Value = claim.BenchmarkDate;
                    worksheet.Cell(currentRow, 22).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 23).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 24).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 25).Value = claim.BenefitDescription;
                    worksheet.Cell(currentRow, 26).Value = claim.TaskCreatedByTeam;
                    worksheet.Cell(currentRow, 27).Value = claim.TaskCompletedByTeam;
                    worksheet.Cell(currentRow, 28).Value = claim.OriginalTaskTargetDate;
                    worksheet.Cell(currentRow, 29).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 30).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 31).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 32).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 33).Value = claim.TargetBenefitType;
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

        public async Task<byte[]> GetRptTaskreportgroup(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptTaskreportgroup(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptTaskreportgroup");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptTaskreportgroup";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.CaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskProcessStep"; worksheet.Cell(currentRow, 2).Value = claim.TaskProcessStep;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskId"; worksheet.Cell(currentRow, 2).Value = claim.TaskId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCode"; worksheet.Cell(currentRow, 2).Value = claim.TaskCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskName"; worksheet.Cell(currentRow, 2).Value = claim.TaskName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskDescription"; worksheet.Cell(currentRow, 2).Value = claim.TaskDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskStatus"; worksheet.Cell(currentRow, 2).Value = claim.TaskStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToRole"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToRole;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDays"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDays;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDate"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTaskTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTaskTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetRptTaskreportreinsurances(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchRptTaskreportreinsurance(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptTaskreportreinsurance");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able RptTaskreportreinsurance";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "TaskCreatedByUser";
                worksheet.Cell(currentRow, 3).Value = "TaskCreatedDate";
                worksheet.Cell(currentRow, 4).Value = "TaskCompletedByUser";
                worksheet.Cell(currentRow, 5).Value = "TaskCompletedDate";
                worksheet.Cell(currentRow, 6).Value = "BenchmarkDays";
                worksheet.Cell(currentRow, 7).Value = "BenchmarkDate";
                worksheet.Cell(currentRow, 8).Value = "ProductName";
                worksheet.Cell(currentRow, 9).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 10).Value = "BenefitCode";
                worksheet.Cell(currentRow, 11).Value = "BenefitDescription";
                worksheet.Cell(currentRow, 12).Value = "TaskCreatedByTeam";
                worksheet.Cell(currentRow, 13).Value = "TaskCompletedByTeam";
                worksheet.Cell(currentRow, 14).Value = "OriginalTaskTargetDate";
                worksheet.Cell(currentRow, 15).Value = "LumpsumIpIndicator";
                worksheet.Cell(currentRow, 16).Value = "ClaimType";
                worksheet.Cell(currentRow, 17).Value = "ClassOfBusiness";
                worksheet.Cell(currentRow, 18).Value = "ProductCode";
                worksheet.Cell(currentRow, 19).Value = "TargetBenefitType";
                worksheet.Cell(currentRow, 20).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 21).Value = "CaseStatus";
                worksheet.Cell(currentRow, 22).Value = "ClaimantName";
                worksheet.Cell(currentRow, 23).Value = "CaseType";
                worksheet.Cell(currentRow, 24).Value = "CaseManager";
                worksheet.Cell(currentRow, 25).Value = "ClaimTeam";
                worksheet.Cell(currentRow, 26).Value = "TaskProcessStep";
                worksheet.Cell(currentRow, 27).Value = "TaskId";
                worksheet.Cell(currentRow, 28).Value = "TaskCode";
                worksheet.Cell(currentRow, 29).Value = "TaskName";
                worksheet.Cell(currentRow, 30).Value = "TaskDescription";
                worksheet.Cell(currentRow, 31).Value = "TaskStatus";
                worksheet.Cell(currentRow, 32).Value = "TaskAssignedToUser";
                worksheet.Cell(currentRow, 33).Value = "TaskAssignedToRole";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                    worksheet.Cell(currentRow, 3).Value = claim.TaskCreatedDate;
                    worksheet.Cell(currentRow, 4).Value = claim.TaskCompletedByUser;
                    worksheet.Cell(currentRow, 5).Value = claim.TaskCompletedDate;
                    worksheet.Cell(currentRow, 6).Value = claim.BenchmarkDays;
                    worksheet.Cell(currentRow, 7).Value = claim.BenchmarkDate;
                    worksheet.Cell(currentRow, 8).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 9).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 10).Value = claim.BenefitCode;
                    worksheet.Cell(currentRow, 11).Value = claim.BenefitDescription;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskCreatedByTeam;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskCompletedByTeam;
                    worksheet.Cell(currentRow, 14).Value = claim.OriginalTaskTargetDate;
                    worksheet.Cell(currentRow, 15).Value = claim.LumpsumIpIndicator;
                    worksheet.Cell(currentRow, 16).Value = claim.ClaimType;
                    worksheet.Cell(currentRow, 17).Value = claim.ClassOfBusiness;
                    worksheet.Cell(currentRow, 18).Value = claim.ProductCode;
                    worksheet.Cell(currentRow, 19).Value = claim.TargetBenefitType;
                    worksheet.Cell(currentRow, 20).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 21).Value = claim.CaseStatus;
                    worksheet.Cell(currentRow, 22).Value = claim.ClaimantName;
                    worksheet.Cell(currentRow, 23).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 24).Value = claim.CaseManager;
                    worksheet.Cell(currentRow, 25).Value = claim.ClaimTeam;
                    worksheet.Cell(currentRow, 26).Value = claim.TaskProcessStep;
                    worksheet.Cell(currentRow, 27).Value = claim.TaskId;
                    worksheet.Cell(currentRow, 28).Value = claim.TaskCode;
                    worksheet.Cell(currentRow, 29).Value = claim.TaskName;
                    worksheet.Cell(currentRow, 30).Value = claim.TaskDescription;
                    worksheet.Cell(currentRow, 31).Value = claim.TaskStatus;
                    worksheet.Cell(currentRow, 32).Value = claim.TaskAssignedToUser;
                    worksheet.Cell(currentRow, 33).Value = claim.TaskAssignedToRole;
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

        public async Task<byte[]> GetRptTaskreportreinsurance(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetRptTaskreportreinsurance(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("RptTaskreportreinsurance");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: RptTaskreportreinsurance";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedDate"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDays"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDays;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenchmarkDate"; worksheet.Cell(currentRow, 2).Value = claim.BenchmarkDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitCode"; worksheet.Cell(currentRow, 2).Value = claim.BenefitCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCreatedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCreatedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCompletedByTeam"; worksheet.Cell(currentRow, 2).Value = claim.TaskCompletedByTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTaskTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTaskTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LumpsumIpIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LumpsumIpIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimType"; worksheet.Cell(currentRow, 2).Value = claim.ClaimType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClassOfBusiness"; worksheet.Cell(currentRow, 2).Value = claim.ClassOfBusiness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductCode"; worksheet.Cell(currentRow, 2).Value = claim.ProductCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetBenefitType"; worksheet.Cell(currentRow, 2).Value = claim.TargetBenefitType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseStatus"; worksheet.Cell(currentRow, 2).Value = claim.CaseStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantName"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseManager"; worksheet.Cell(currentRow, 2).Value = claim.CaseManager;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimTeam"; worksheet.Cell(currentRow, 2).Value = claim.ClaimTeam;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskProcessStep"; worksheet.Cell(currentRow, 2).Value = claim.TaskProcessStep;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskId"; worksheet.Cell(currentRow, 2).Value = claim.TaskId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskCode"; worksheet.Cell(currentRow, 2).Value = claim.TaskCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskName"; worksheet.Cell(currentRow, 2).Value = claim.TaskName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskDescription"; worksheet.Cell(currentRow, 2).Value = claim.TaskDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskStatus"; worksheet.Cell(currentRow, 2).Value = claim.TaskStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToUser"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToUser;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskAssignedToRole"; worksheet.Cell(currentRow, 2).Value = claim.TaskAssignedToRole;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetPartys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchParty(column, search, pageIndex, pageSize);
            //var items = await _context.SearchPartySearch(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Party");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able Party";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CustomerNo";
                worksheet.Cell(currentRow, 5).Value = "Name";
                worksheet.Cell(currentRow, 6).Value = "Title";
                worksheet.Cell(currentRow, 7).Value = "PreferredName";
                worksheet.Cell(currentRow, 8).Value = "PreviousName";
                worksheet.Cell(currentRow, 9).Value = "Verified";
                worksheet.Cell(currentRow, 10).Value = "DateOfBirth";
                worksheet.Cell(currentRow, 11).Value = "DateOfDeath";
                worksheet.Cell(currentRow, 12).Value = "Gender";
                worksheet.Cell(currentRow, 13).Value = "MaritalStatus";
                worksheet.Cell(currentRow, 14).Value = "PartyType";
                worksheet.Cell(currentRow, 15).Value = "Deceased";
                worksheet.Cell(currentRow, 16).Value = "NotificationsIssued";
                worksheet.Cell(currentRow, 17).Value = "Occupation";
                worksheet.Cell(currentRow, 18).Value = "Tenure";
                worksheet.Cell(currentRow, 19).Value = "HazardousPursuit";
                worksheet.Cell(currentRow, 20).Value = "Nationality";
                worksheet.Cell(currentRow, 21).Value = "CountryOfBirth";
                worksheet.Cell(currentRow, 22).Value = "CulturalConsiderations";
                worksheet.Cell(currentRow, 23).Value = "HighValueAdvisor";
                worksheet.Cell(currentRow, 24).Value = "SecuredClient";
                worksheet.Cell(currentRow, 25).Value = "GroupClient";
                worksheet.Cell(currentRow, 26).Value = "StaffMember";
                worksheet.Cell(currentRow, 27).Value = "Password";
                worksheet.Cell(currentRow, 28).Value = "CorrespondenceTranslationRequired";
                worksheet.Cell(currentRow, 29).Value = "InterpreterRequired";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CustomerNo;
                    worksheet.Cell(currentRow, 5).Value = claim.Name;
                    worksheet.Cell(currentRow, 6).Value = claim.Title;
                    worksheet.Cell(currentRow, 7).Value = claim.PreferredName;
                    worksheet.Cell(currentRow, 8).Value = claim.PreviousName;
                    worksheet.Cell(currentRow, 9).Value = claim.Verified;
                    worksheet.Cell(currentRow, 10).Value = claim.DateOfBirth;
                    worksheet.Cell(currentRow, 11).Value = claim.DateOfDeath;
                    worksheet.Cell(currentRow, 12).Value = claim.Gender;
                    worksheet.Cell(currentRow, 13).Value = claim.MaritalStatus;
                    worksheet.Cell(currentRow, 14).Value = claim.PartyType;
                    worksheet.Cell(currentRow, 15).Value = claim.Deceased;
                    worksheet.Cell(currentRow, 16).Value = claim.NotificationsIssued;
                    worksheet.Cell(currentRow, 17).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 18).Value = claim.Tenure;
                    worksheet.Cell(currentRow, 19).Value = claim.HazardousPursuit;
                    worksheet.Cell(currentRow, 20).Value = claim.Nationality;
                    worksheet.Cell(currentRow, 21).Value = claim.CountryOfBirth;
                    worksheet.Cell(currentRow, 22).Value = claim.CulturalConsiderations;
                    worksheet.Cell(currentRow, 23).Value = claim.HighValueAdvisor;
                    worksheet.Cell(currentRow, 24).Value = claim.SecuredClient;
                    worksheet.Cell(currentRow, 25).Value = claim.GroupClient;
                    worksheet.Cell(currentRow, 26).Value = claim.StaffMember;
                    worksheet.Cell(currentRow, 27).Value = claim.Password;
                    worksheet.Cell(currentRow, 28).Value = claim.CorrespondenceTranslationRequired;
                    worksheet.Cell(currentRow, 29).Value = claim.InterpreterRequired;
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

        public async Task<byte[]> GetParty(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetParty(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Party");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Party";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerNo"; worksheet.Cell(currentRow, 2).Value = claim.CustomerNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Title"; worksheet.Cell(currentRow, 2).Value = claim.Title;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreferredName"; worksheet.Cell(currentRow, 2).Value = claim.PreferredName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreviousName"; worksheet.Cell(currentRow, 2).Value = claim.PreviousName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Verified"; worksheet.Cell(currentRow, 2).Value = claim.Verified;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.DateOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDeath"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDeath;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Gender"; worksheet.Cell(currentRow, 2).Value = claim.Gender;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaritalStatus"; worksheet.Cell(currentRow, 2).Value = claim.MaritalStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyType"; worksheet.Cell(currentRow, 2).Value = claim.PartyType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Deceased"; worksheet.Cell(currentRow, 2).Value = claim.Deceased;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NotificationsIssued"; worksheet.Cell(currentRow, 2).Value = claim.NotificationsIssued;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Tenure"; worksheet.Cell(currentRow, 2).Value = claim.Tenure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HazardousPursuit"; worksheet.Cell(currentRow, 2).Value = claim.HazardousPursuit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Nationality"; worksheet.Cell(currentRow, 2).Value = claim.Nationality;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryOfBirth"; worksheet.Cell(currentRow, 2).Value = claim.CountryOfBirth;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CulturalConsiderations"; worksheet.Cell(currentRow, 2).Value = claim.CulturalConsiderations;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HighValueAdvisor"; worksheet.Cell(currentRow, 2).Value = claim.HighValueAdvisor;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SecuredClient"; worksheet.Cell(currentRow, 2).Value = claim.SecuredClient;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupClient"; worksheet.Cell(currentRow, 2).Value = claim.GroupClient;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StaffMember"; worksheet.Cell(currentRow, 2).Value = claim.StaffMember;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Password"; worksheet.Cell(currentRow, 2).Value = claim.Password;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CorrespondenceTranslationRequired"; worksheet.Cell(currentRow, 2).Value = claim.CorrespondenceTranslationRequired;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InterpreterRequired"; worksheet.Cell(currentRow, 2).Value = claim.InterpreterRequired;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetPartyAddresss(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchPartyAddress(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartyAddress");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " PartyAddress";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PartyC";
                worksheet.Cell(currentRow, 5).Value = "PartyI";
                worksheet.Cell(currentRow, 6).Value = "AddressType";
                worksheet.Cell(currentRow, 7).Value = "EffectiveFrom";
                worksheet.Cell(currentRow, 8).Value = "EffectiveTo";
                worksheet.Cell(currentRow, 9).Value = "BuildingName1";
                worksheet.Cell(currentRow, 10).Value = "BuildingName2";
                worksheet.Cell(currentRow, 11).Value = "DisplayExtend";
                worksheet.Cell(currentRow, 12).Value = "Dpid";
                worksheet.Cell(currentRow, 13).Value = "FloorLevelNum";
                worksheet.Cell(currentRow, 14).Value = "LotNumber";
                worksheet.Cell(currentRow, 15).Value = "PostalNumber";
                worksheet.Cell(currentRow, 16).Value = "PostalNumberP";
                worksheet.Cell(currentRow, 17).Value = "PostalNumberS";
                worksheet.Cell(currentRow, 18).Value = "PremiseNoSuff";
                worksheet.Cell(currentRow, 19).Value = "PremiseNoTo";
                worksheet.Cell(currentRow, 20).Value = "PremiseNoToSu";
                worksheet.Cell(currentRow, 21).Value = "FloorLevelTyp";
                worksheet.Cell(currentRow, 22).Value = "StreetSuffix";
                worksheet.Cell(currentRow, 23).Value = "PostalType";
                worksheet.Cell(currentRow, 24).Value = "Status";
                worksheet.Cell(currentRow, 25).Value = "AddressLine1";
                worksheet.Cell(currentRow, 26).Value = "AddressLine2";
                worksheet.Cell(currentRow, 27).Value = "AddressLine3";
                worksheet.Cell(currentRow, 28).Value = "Suburb";
                worksheet.Cell(currentRow, 29).Value = "State";
                worksheet.Cell(currentRow, 30).Value = "PostCode";
                worksheet.Cell(currentRow, 31).Value = "CountryCode";
                worksheet.Cell(currentRow, 32).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 33).Value = "PartyName";
                worksheet.Cell(currentRow, 34).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 5).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 6).Value = claim.AddressType;
                    worksheet.Cell(currentRow, 7).Value = claim.EffectiveFrom;
                    worksheet.Cell(currentRow, 8).Value = claim.EffectiveTo;
                    worksheet.Cell(currentRow, 9).Value = claim.BuildingName1;
                    worksheet.Cell(currentRow, 10).Value = claim.BuildingName2;
                    worksheet.Cell(currentRow, 11).Value = claim.DisplayExtend;
                    worksheet.Cell(currentRow, 12).Value = claim.Dpid;
                    worksheet.Cell(currentRow, 13).Value = claim.FloorLevelNum;
                    worksheet.Cell(currentRow, 14).Value = claim.LotNumber;
                    worksheet.Cell(currentRow, 15).Value = claim.PostalNumber;
                    worksheet.Cell(currentRow, 16).Value = claim.PostalNumberP;
                    worksheet.Cell(currentRow, 17).Value = claim.PostalNumberS;
                    worksheet.Cell(currentRow, 18).Value = claim.PremiseNoSuff;
                    worksheet.Cell(currentRow, 19).Value = claim.PremiseNoTo;
                    worksheet.Cell(currentRow, 20).Value = claim.PremiseNoToSu;
                    worksheet.Cell(currentRow, 21).Value = claim.FloorLevelTyp;
                    worksheet.Cell(currentRow, 22).Value = claim.StreetSuffix;
                    worksheet.Cell(currentRow, 23).Value = claim.PostalType;
                    worksheet.Cell(currentRow, 24).Value = claim.Status;
                    worksheet.Cell(currentRow, 25).Value = claim.AddressLine1;
                    worksheet.Cell(currentRow, 26).Value = claim.AddressLine2;
                    worksheet.Cell(currentRow, 27).Value = claim.AddressLine3;
                    worksheet.Cell(currentRow, 28).Value = claim.Suburb;
                    worksheet.Cell(currentRow, 29).Value = claim.State;
                    worksheet.Cell(currentRow, 30).Value = claim.PostCode;
                    worksheet.Cell(currentRow, 31).Value = claim.CountryCode;
                    worksheet.Cell(currentRow, 32).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 33).Value = claim.PartyName;
                    worksheet.Cell(currentRow, 34).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetPartyAddress(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetPartyAddress(id, appflag);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartyAddress");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " PartyAddress";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AddressType"; worksheet.Cell(currentRow, 2).Value = claim.AddressType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveFrom"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveTo"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveTo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BuildingName1"; worksheet.Cell(currentRow, 2).Value = claim.BuildingName1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BuildingName2"; worksheet.Cell(currentRow, 2).Value = claim.BuildingName2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DisplayExtend"; worksheet.Cell(currentRow, 2).Value = claim.DisplayExtend;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Dpid"; worksheet.Cell(currentRow, 2).Value = claim.Dpid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FloorLevelNum"; worksheet.Cell(currentRow, 2).Value = claim.FloorLevelNum;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LotNumber"; worksheet.Cell(currentRow, 2).Value = claim.LotNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostalNumber"; worksheet.Cell(currentRow, 2).Value = claim.PostalNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostalNumberP"; worksheet.Cell(currentRow, 2).Value = claim.PostalNumberP;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostalNumberS"; worksheet.Cell(currentRow, 2).Value = claim.PostalNumberS;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiseNoSuff"; worksheet.Cell(currentRow, 2).Value = claim.PremiseNoSuff;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiseNoTo"; worksheet.Cell(currentRow, 2).Value = claim.PremiseNoTo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PremiseNoToSu"; worksheet.Cell(currentRow, 2).Value = claim.PremiseNoToSu;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FloorLevelTyp"; worksheet.Cell(currentRow, 2).Value = claim.FloorLevelTyp;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StreetSuffix"; worksheet.Cell(currentRow, 2).Value = claim.StreetSuffix;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostalType"; worksheet.Cell(currentRow, 2).Value = claim.PostalType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AddressLine1"; worksheet.Cell(currentRow, 2).Value = claim.AddressLine1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AddressLine2"; worksheet.Cell(currentRow, 2).Value = claim.AddressLine2;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AddressLine3"; worksheet.Cell(currentRow, 2).Value = claim.AddressLine3;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Suburb"; worksheet.Cell(currentRow, 2).Value = claim.Suburb;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "State"; worksheet.Cell(currentRow, 2).Value = claim.State;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PostCode"; worksheet.Cell(currentRow, 2).Value = claim.PostCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CountryCode"; worksheet.Cell(currentRow, 2).Value = claim.CountryCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyName"; worksheet.Cell(currentRow, 2).Value = claim.PartyName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }


        public async Task<byte[]> GetPartyContacts(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchPartyContact(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartyContact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able PartyContact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PartyC";
                worksheet.Cell(currentRow, 5).Value = "PartyI";
                worksheet.Cell(currentRow, 6).Value = "ContactMethod";
                worksheet.Cell(currentRow, 7).Value = "ContactTime";
                worksheet.Cell(currentRow, 8).Value = "Verificaton";
                worksheet.Cell(currentRow, 9).Value = "IntCode";
                worksheet.Cell(currentRow, 10).Value = "AreaCode";
                worksheet.Cell(currentRow, 11).Value = "TelNo";
                worksheet.Cell(currentRow, 12).Value = "ExtNo";
                worksheet.Cell(currentRow, 13).Value = "IsExDir";
                worksheet.Cell(currentRow, 14).Value = "Email";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 5).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 6).Value = claim.ContactMethod;
                    worksheet.Cell(currentRow, 7).Value = claim.ContactTime;
                    worksheet.Cell(currentRow, 8).Value = claim.Verificaton;
                    worksheet.Cell(currentRow, 9).Value = claim.IntCode;
                    worksheet.Cell(currentRow, 10).Value = claim.AreaCode;
                    worksheet.Cell(currentRow, 11).Value = claim.TelNo;
                    worksheet.Cell(currentRow, 12).Value = claim.ExtNo;
                    worksheet.Cell(currentRow, 13).Value = claim.IsExDir;
                    worksheet.Cell(currentRow, 14).Value = claim.Email;
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

        public async Task<byte[]> GetPartyContact(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetPartyContact(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartyContact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: PartyContact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactMethod"; worksheet.Cell(currentRow, 2).Value = claim.ContactMethod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactTime"; worksheet.Cell(currentRow, 2).Value = claim.ContactTime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Verificaton"; worksheet.Cell(currentRow, 2).Value = claim.Verificaton;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IntCode"; worksheet.Cell(currentRow, 2).Value = claim.IntCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AreaCode"; worksheet.Cell(currentRow, 2).Value = claim.AreaCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TelNo"; worksheet.Cell(currentRow, 2).Value = claim.TelNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExtNo"; worksheet.Cell(currentRow, 2).Value = claim.ExtNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IsExDir"; worksheet.Cell(currentRow, 2).Value = claim.IsExDir;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Email"; worksheet.Cell(currentRow, 2).Value = claim.Email;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetCases(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchCase(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Case");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able Case";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "IncuredDate";
                worksheet.Cell(currentRow, 7).Value = "Context";
                worksheet.Cell(currentRow, 8).Value = "TriageSegment";
                worksheet.Cell(currentRow, 9).Value = "CaseNumber";
                worksheet.Cell(currentRow, 10).Value = "UnexpectedCircumstances";
                worksheet.Cell(currentRow, 11).Value = "CustomerContactFrequency";
                worksheet.Cell(currentRow, 12).Value = "OpportunityToInfluenceExhausted";
                worksheet.Cell(currentRow, 13).Value = "Description";
                worksheet.Cell(currentRow, 14).Value = "OverrideTriageSegmentReason";
                worksheet.Cell(currentRow, 15).Value = "CreationDate";
                worksheet.Cell(currentRow, 16).Value = "UrgentFinancialNeed";
                worksheet.Cell(currentRow, 17).Value = "CaseType";
                worksheet.Cell(currentRow, 18).Value = "CaseOwnerComment";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.IncuredDate;
                    worksheet.Cell(currentRow, 7).Value = claim.Context;
                    worksheet.Cell(currentRow, 8).Value = claim.TriageSegment;
                    worksheet.Cell(currentRow, 9).Value = claim.CaseNumber;
                    worksheet.Cell(currentRow, 10).Value = claim.UnexpectedCircumstances;
                    worksheet.Cell(currentRow, 11).Value = claim.CustomerContactFrequency;
                    worksheet.Cell(currentRow, 12).Value = claim.OpportunityToInfluenceExhausted;
                    worksheet.Cell(currentRow, 13).Value = claim.Description;
                    worksheet.Cell(currentRow, 14).Value = claim.OverrideTriageSegmentReason;
                    worksheet.Cell(currentRow, 15).Value = claim.CreationDate;
                    worksheet.Cell(currentRow, 16).Value = claim.UrgentFinancialNeed;
                    worksheet.Cell(currentRow, 17).Value = claim.CaseType;
                    worksheet.Cell(currentRow, 18).Value = claim.CaseOwnerComment;
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

        public async Task<byte[]> GetCase(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetCase(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Case");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Case";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncuredDate"; worksheet.Cell(currentRow, 2).Value = claim.IncuredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Context"; worksheet.Cell(currentRow, 2).Value = claim.Context;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TriageSegment"; worksheet.Cell(currentRow, 2).Value = claim.TriageSegment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseNumber"; worksheet.Cell(currentRow, 2).Value = claim.CaseNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UnexpectedCircumstances"; worksheet.Cell(currentRow, 2).Value = claim.UnexpectedCircumstances;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerContactFrequency"; worksheet.Cell(currentRow, 2).Value = claim.CustomerContactFrequency;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OpportunityToInfluenceExhausted"; worksheet.Cell(currentRow, 2).Value = claim.OpportunityToInfluenceExhausted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideTriageSegmentReason"; worksheet.Cell(currentRow, 2).Value = claim.OverrideTriageSegmentReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreationDate"; worksheet.Cell(currentRow, 2).Value = claim.CreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UrgentFinancialNeed"; worksheet.Cell(currentRow, 2).Value = claim.UrgentFinancialNeed;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseType"; worksheet.Cell(currentRow, 2).Value = claim.CaseType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseOwnerComment"; worksheet.Cell(currentRow, 2).Value = claim.CaseOwnerComment;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchClaim(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Claim");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able Claim";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "AccidentSickness";
                worksheet.Cell(currentRow, 7).Value = "AdditionalInformation";
                worksheet.Cell(currentRow, 8).Value = "FatalClaim";
                worksheet.Cell(currentRow, 9).Value = "OccurredInAnotherCountry";
                worksheet.Cell(currentRow, 10).Value = "ClaimantIsNotifier";
                worksheet.Cell(currentRow, 11).Value = "ClaimReceivedDate";
                worksheet.Cell(currentRow, 12).Value = "DateReturnedToWork";
                worksheet.Cell(currentRow, 13).Value = "TraumaDefinition";
                worksheet.Cell(currentRow, 14).Value = "InsuredClaimCorrespondence";
                worksheet.Cell(currentRow, 15).Value = "ExpectedRtwftdateIfKnown";
                worksheet.Cell(currentRow, 16).Value = "TpdsubDefinition";
                worksheet.Cell(currentRow, 17).Value = "Source";
                worksheet.Cell(currentRow, 18).Value = "IncurredDateOnLastUpdate";
                worksheet.Cell(currentRow, 19).Value = "GuidelinesDate";
                worksheet.Cell(currentRow, 20).Value = "RecoveryDurationUnit";
                worksheet.Cell(currentRow, 21).Value = "Min";
                worksheet.Cell(currentRow, 22).Value = "Opt";
                worksheet.Cell(currentRow, 23).Value = "Max";
                worksheet.Cell(currentRow, 24).Value = "DisableAutoUpdates";
                worksheet.Cell(currentRow, 25).Value = "Min1";
                worksheet.Cell(currentRow, 26).Value = "Opt1";
                worksheet.Cell(currentRow, 27).Value = "Max1";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.AccidentSickness;
                    worksheet.Cell(currentRow, 7).Value = claim.AdditionalInformation;
                    worksheet.Cell(currentRow, 8).Value = claim.FatalClaim;
                    worksheet.Cell(currentRow, 9).Value = claim.OccurredInAnotherCountry;
                    worksheet.Cell(currentRow, 10).Value = claim.ClaimantIsNotifier;
                    worksheet.Cell(currentRow, 11).Value = claim.ClaimReceivedDate;
                    worksheet.Cell(currentRow, 12).Value = claim.DateReturnedToWork;
                    worksheet.Cell(currentRow, 13).Value = claim.TraumaDefinition;
                    worksheet.Cell(currentRow, 14).Value = claim.InsuredClaimCorrespondence;
                    worksheet.Cell(currentRow, 15).Value = claim.ExpectedRtwftdateIfKnown;
                    worksheet.Cell(currentRow, 16).Value = claim.TpdsubDefinition;
                    worksheet.Cell(currentRow, 17).Value = claim.Source;
                    worksheet.Cell(currentRow, 18).Value = claim.IncurredDateOnLastUpdate;
                    worksheet.Cell(currentRow, 19).Value = claim.GuidelinesDate;
                    worksheet.Cell(currentRow, 20).Value = claim.RecoveryDurationUnit;
                    worksheet.Cell(currentRow, 21).Value = claim.Min;
                    worksheet.Cell(currentRow, 22).Value = claim.Opt;
                    worksheet.Cell(currentRow, 23).Value = claim.Max;
                    worksheet.Cell(currentRow, 24).Value = claim.DisableAutoUpdates;
                    worksheet.Cell(currentRow, 25).Value = claim.Min1;
                    worksheet.Cell(currentRow, 26).Value = claim.Opt1;
                    worksheet.Cell(currentRow, 27).Value = claim.Max1;
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
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AccidentSickness"; worksheet.Cell(currentRow, 2).Value = claim.AccidentSickness;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdditionalInformation"; worksheet.Cell(currentRow, 2).Value = claim.AdditionalInformation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FatalClaim"; worksheet.Cell(currentRow, 2).Value = claim.FatalClaim;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccurredInAnotherCountry"; worksheet.Cell(currentRow, 2).Value = claim.OccurredInAnotherCountry;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimantIsNotifier"; worksheet.Cell(currentRow, 2).Value = claim.ClaimantIsNotifier;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimReceivedDate"; worksheet.Cell(currentRow, 2).Value = claim.ClaimReceivedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReturnedToWork"; worksheet.Cell(currentRow, 2).Value = claim.DateReturnedToWork;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TraumaDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TraumaDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "InsuredClaimCorrespondence"; worksheet.Cell(currentRow, 2).Value = claim.InsuredClaimCorrespondence;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedRtwftdateIfKnown"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedRtwftdateIfKnown;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TpdsubDefinition"; worksheet.Cell(currentRow, 2).Value = claim.TpdsubDefinition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncurredDateOnLastUpdate"; worksheet.Cell(currentRow, 2).Value = claim.IncurredDateOnLastUpdate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GuidelinesDate"; worksheet.Cell(currentRow, 2).Value = claim.GuidelinesDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RecoveryDurationUnit"; worksheet.Cell(currentRow, 2).Value = claim.RecoveryDurationUnit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Min"; worksheet.Cell(currentRow, 2).Value = claim.Min;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Opt"; worksheet.Cell(currentRow, 2).Value = claim.Opt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Max"; worksheet.Cell(currentRow, 2).Value = claim.Max;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DisableAutoUpdates"; worksheet.Cell(currentRow, 2).Value = claim.DisableAutoUpdates;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Min1"; worksheet.Cell(currentRow, 2).Value = claim.Min1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Opt1"; worksheet.Cell(currentRow, 2).Value = claim.Opt1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Max1"; worksheet.Cell(currentRow, 2).Value = claim.Max1;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchPolicy(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Policy");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Policy";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 5).Value = "Product";
                worksheet.Cell(currentRow, 6).Value = "ProductName";
                worksheet.Cell(currentRow, 7).Value = "ContractStatus";
                worksheet.Cell(currentRow, 8).Value = "ContractStatusName";
                worksheet.Cell(currentRow, 9).Value = "SourceSystem";
                worksheet.Cell(currentRow, 10).Value = "SourceSystemName";
                worksheet.Cell(currentRow, 11).Value = "StartDate";
                worksheet.Cell(currentRow, 12).Value = "TerminationDate";
                worksheet.Cell(currentRow, 13).Value = "EffectiveDate";
                worksheet.Cell(currentRow, 14).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 5).Value = claim.Product;
                    worksheet.Cell(currentRow, 6).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 7).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 8).Value = claim.ContractStatusName;
                    worksheet.Cell(currentRow, 9).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 10).Value = claim.SourceSystemName;
                    worksheet.Cell(currentRow, 11).Value = claim.StartDate;
                    worksheet.Cell(currentRow, 12).Value = claim.TerminationDate;
                    worksheet.Cell(currentRow, 13).Value = claim.EffectiveDate;
                    worksheet.Cell(currentRow, 14).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetPolicy(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetPolicy(id, appflag);
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
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Product"; worksheet.Cell(currentRow, 2).Value = claim.Product;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatusName"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatusName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystemName"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystemName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDate"; worksheet.Cell(currentRow, 2).Value = claim.StartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TerminationDate"; worksheet.Cell(currentRow, 2).Value = claim.TerminationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveDate"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveDate;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetBenefits(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchBenefit(column, search, pageIndex, pageSize, 0, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Benefit");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Benefit";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "OverrideClaimIncurredDate";
                worksheet.Cell(currentRow, 7).Value = "BenefitStartDate";
                worksheet.Cell(currentRow, 8).Value = "BenefitEndDate";
                worksheet.Cell(currentRow, 9).Value = "ProofOfLossDate";
                worksheet.Cell(currentRow, 10).Value = "ExpectedBenefitClosureDate";
                worksheet.Cell(currentRow, 11).Value = "Source";
                worksheet.Cell(currentRow, 12).Value = "EffectiveDateOfCoverage";
                worksheet.Cell(currentRow, 13).Value = "BenefitExpiryDate";
                worksheet.Cell(currentRow, 14).Value = "WaitingPeriod";
                worksheet.Cell(currentRow, 15).Value = "WaitingPeriodBasis";
                worksheet.Cell(currentRow, 16).Value = "FullyRetained";
                worksheet.Cell(currentRow, 17).Value = "BenefitDecision";
                worksheet.Cell(currentRow, 18).Value = "BenefitDecisionDate";
                worksheet.Cell(currentRow, 19).Value = "ReasonForBenefitDecision";
                worksheet.Cell(currentRow, 20).Value = "BenefitSelected";
                worksheet.Cell(currentRow, 21).Value = "AgreedValue";
                worksheet.Cell(currentRow, 22).Value = "ChronicConditionOption";
                worksheet.Cell(currentRow, 23).Value = "Day1AccidentOption";
                worksheet.Cell(currentRow, 24).Value = "Iar";
                worksheet.Cell(currentRow, 25).Value = "OccupationalCategory";
                worksheet.Cell(currentRow, 26).Value = "PasriskOptionCode";
                worksheet.Cell(currentRow, 27).Value = "PasriskOptionDesc";
                worksheet.Cell(currentRow, 28).Value = "SuperContributionPct";
                worksheet.Cell(currentRow, 29).Value = "GroupId";
                worksheet.Cell(currentRow, 30).Value = "SubBenefitFlag";
                worksheet.Cell(currentRow, 31).Value = "StartDateCalculationType";
                worksheet.Cell(currentRow, 32).Value = "EndDateCalculationType";
                worksheet.Cell(currentRow, 33).Value = "MaximumBenefitPeriod";
                worksheet.Cell(currentRow, 34).Value = "MaximumBenefitPeriodAccident";
                worksheet.Cell(currentRow, 35).Value = "MaximumBenefitPeriodHospital";
                worksheet.Cell(currentRow, 36).Value = "MaximumBenefitPeriodBasis";
                worksheet.Cell(currentRow, 37).Value = "MaximumBenefitPeriodAccidentBasis";
                worksheet.Cell(currentRow, 38).Value = "MaximumBenefitPeriodHospitalBasis";
                worksheet.Cell(currentRow, 39).Value = "SicknessWaitingPeriod";
                worksheet.Cell(currentRow, 40).Value = "AccidentWaitingPeriod";
                worksheet.Cell(currentRow, 41).Value = "HospitalWaitingPeriod";
                worksheet.Cell(currentRow, 42).Value = "WaitingPeriodBasis1";
                worksheet.Cell(currentRow, 43).Value = "AccidentWaitingPeriodBasis";
                worksheet.Cell(currentRow, 44).Value = "HospitalWaitingPeriodBasis";
                worksheet.Cell(currentRow, 45).Value = "SumInsured";
                worksheet.Cell(currentRow, 46).Value = "AgeroundingRule";
                worksheet.Cell(currentRow, 47).Value = "RoundUnit";
                worksheet.Cell(currentRow, 48).Value = "AgeroundingPrecision";
                worksheet.Cell(currentRow, 49).Value = "RoundInstruction";
                worksheet.Cell(currentRow, 50).Value = "MaximumAggregateAmount";
                worksheet.Cell(currentRow, 51).Value = "MinimumAmount";
                worksheet.Cell(currentRow, 52).Value = "MinimumPercentage";
                worksheet.Cell(currentRow, 53).Value = "MinimumCalculationType";
                worksheet.Cell(currentRow, 54).Value = "AutomaticAcceptanceLimit";
                worksheet.Cell(currentRow, 55).Value = "DuesCreatedInArrears";
                worksheet.Cell(currentRow, 56).Value = "MaximumAmount";
                worksheet.Cell(currentRow, 57).Value = "MaximumPercentage";
                worksheet.Cell(currentRow, 58).Value = "MaximumCalculationType";
                worksheet.Cell(currentRow, 59).Value = "Underwritten";
                worksheet.Cell(currentRow, 60).Value = "ReinsurerLiabilityApprovedToDate";
                worksheet.Cell(currentRow, 61).Value = "ToEndOfBenefit";
                worksheet.Cell(currentRow, 62).Value = "IndexationApplies";
                worksheet.Cell(currentRow, 63).Value = "AdjustmentTypeName";
                worksheet.Cell(currentRow, 64).Value = "EliminationPeriod";
                worksheet.Cell(currentRow, 65).Value = "EliminationPeriodBasis";
                worksheet.Cell(currentRow, 66).Value = "MinimumRate";
                worksheet.Cell(currentRow, 67).Value = "IndexLeadTime";
                worksheet.Cell(currentRow, 68).Value = "AdjustBenefit";
                worksheet.Cell(currentRow, 69).Value = "MaximumRate";
                worksheet.Cell(currentRow, 70).Value = "MaximumCumulativeRate";
                worksheet.Cell(currentRow, 71).Value = "MaxNumberIndexations";
                worksheet.Cell(currentRow, 72).Value = "MinThresholdApplies";
                worksheet.Cell(currentRow, 73).Value = "MaxThresholdApplies";
                worksheet.Cell(currentRow, 74).Value = "Type";
                worksheet.Cell(currentRow, 75).Value = "ChangeInClaimDefinitionDate";
                worksheet.Cell(currentRow, 76).Value = "WhenAnyAllDecisionMade";
                worksheet.Cell(currentRow, 77).Value = "DateBenefitsWithheld";
                worksheet.Cell(currentRow, 78).Value = "WhoAuthorizedBenefitsWithheldC";
                worksheet.Cell(currentRow, 79).Value = "WhoAuthorizedBenefitsWithheldI";
                worksheet.Cell(currentRow, 80).Value = "LastUpdateUserNameC";
                worksheet.Cell(currentRow, 81).Value = "LastUpdateUserNameI";
                worksheet.Cell(currentRow, 82).Value = "AnyAllReviewDate";
                worksheet.Cell(currentRow, 83).Value = "ReasonBenefitsWithheld";
                worksheet.Cell(currentRow, 84).Value = "OverrideChangeInDefinitionDate";
                worksheet.Cell(currentRow, 85).Value = "AnyAllStatus";
                worksheet.Cell(currentRow, 86).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.OverrideClaimIncurredDate;
                    worksheet.Cell(currentRow, 7).Value = claim.BenefitStartDate;
                    worksheet.Cell(currentRow, 8).Value = claim.BenefitEndDate;
                    worksheet.Cell(currentRow, 9).Value = claim.ProofOfLossDate;
                    worksheet.Cell(currentRow, 10).Value = claim.ExpectedBenefitClosureDate;
                    worksheet.Cell(currentRow, 11).Value = claim.Source;
                    worksheet.Cell(currentRow, 12).Value = claim.EffectiveDateOfCoverage;
                    worksheet.Cell(currentRow, 13).Value = claim.BenefitExpiryDate;
                    worksheet.Cell(currentRow, 14).Value = claim.WaitingPeriod;
                    worksheet.Cell(currentRow, 15).Value = claim.WaitingPeriodBasis;
                    worksheet.Cell(currentRow, 16).Value = claim.FullyRetained;
                    worksheet.Cell(currentRow, 17).Value = claim.BenefitDecision;
                    worksheet.Cell(currentRow, 18).Value = claim.BenefitDecisionDate;
                    worksheet.Cell(currentRow, 19).Value = claim.ReasonForBenefitDecision;
                    worksheet.Cell(currentRow, 20).Value = claim.BenefitSelected;
                    worksheet.Cell(currentRow, 21).Value = claim.AgreedValue;
                    worksheet.Cell(currentRow, 22).Value = claim.ChronicConditionOption;
                    worksheet.Cell(currentRow, 23).Value = claim.Day1AccidentOption;
                    worksheet.Cell(currentRow, 24).Value = claim.Iar;
                    worksheet.Cell(currentRow, 25).Value = claim.OccupationalCategory;
                    worksheet.Cell(currentRow, 26).Value = claim.PasriskOptionCode;
                    worksheet.Cell(currentRow, 27).Value = claim.PasriskOptionDesc;
                    worksheet.Cell(currentRow, 28).Value = claim.SuperContributionPct;
                    worksheet.Cell(currentRow, 29).Value = claim.GroupId;
                    worksheet.Cell(currentRow, 30).Value = claim.SubBenefitFlag;
                    worksheet.Cell(currentRow, 31).Value = claim.StartDateCalculationType;
                    worksheet.Cell(currentRow, 32).Value = claim.EndDateCalculationType;
                    worksheet.Cell(currentRow, 33).Value = claim.MaximumBenefitPeriod;
                    worksheet.Cell(currentRow, 34).Value = claim.MaximumBenefitPeriodAccident;
                    worksheet.Cell(currentRow, 35).Value = claim.MaximumBenefitPeriodHospital;
                    worksheet.Cell(currentRow, 36).Value = claim.MaximumBenefitPeriodBasis;
                    worksheet.Cell(currentRow, 37).Value = claim.MaximumBenefitPeriodAccidentBasis;
                    worksheet.Cell(currentRow, 38).Value = claim.MaximumBenefitPeriodHospitalBasis;
                    worksheet.Cell(currentRow, 39).Value = claim.SicknessWaitingPeriod;
                    worksheet.Cell(currentRow, 40).Value = claim.AccidentWaitingPeriod;
                    worksheet.Cell(currentRow, 41).Value = claim.HospitalWaitingPeriod;
                    worksheet.Cell(currentRow, 42).Value = claim.WaitingPeriodBasis1;
                    worksheet.Cell(currentRow, 43).Value = claim.AccidentWaitingPeriodBasis;
                    worksheet.Cell(currentRow, 44).Value = claim.HospitalWaitingPeriodBasis;
                    worksheet.Cell(currentRow, 45).Value = claim.SumInsured;
                    worksheet.Cell(currentRow, 46).Value = claim.AgeroundingRule;
                    worksheet.Cell(currentRow, 47).Value = claim.RoundUnit;
                    worksheet.Cell(currentRow, 48).Value = claim.AgeroundingPrecision;
                    worksheet.Cell(currentRow, 49).Value = claim.RoundInstruction;
                    worksheet.Cell(currentRow, 50).Value = claim.MaximumAggregateAmount;
                    worksheet.Cell(currentRow, 51).Value = claim.MinimumAmount;
                    worksheet.Cell(currentRow, 52).Value = claim.MinimumPercentage;
                    worksheet.Cell(currentRow, 53).Value = claim.MinimumCalculationType;
                    worksheet.Cell(currentRow, 54).Value = claim.AutomaticAcceptanceLimit;
                    worksheet.Cell(currentRow, 55).Value = claim.DuesCreatedInArrears;
                    worksheet.Cell(currentRow, 56).Value = claim.MaximumAmount;
                    worksheet.Cell(currentRow, 57).Value = claim.MaximumPercentage;
                    worksheet.Cell(currentRow, 58).Value = claim.MaximumCalculationType;
                    worksheet.Cell(currentRow, 59).Value = claim.Underwritten;
                    worksheet.Cell(currentRow, 60).Value = claim.ReinsurerLiabilityApprovedToDate;
                    worksheet.Cell(currentRow, 61).Value = claim.ToEndOfBenefit;
                    worksheet.Cell(currentRow, 62).Value = claim.IndexationApplies;
                    worksheet.Cell(currentRow, 63).Value = claim.AdjustmentTypeName;
                    worksheet.Cell(currentRow, 64).Value = claim.EliminationPeriod;
                    worksheet.Cell(currentRow, 65).Value = claim.EliminationPeriodBasis;
                    worksheet.Cell(currentRow, 66).Value = claim.MinimumRate;
                    worksheet.Cell(currentRow, 67).Value = claim.IndexLeadTime;
                    worksheet.Cell(currentRow, 68).Value = claim.AdjustBenefit;
                    worksheet.Cell(currentRow, 69).Value = claim.MaximumRate;
                    worksheet.Cell(currentRow, 70).Value = claim.MaximumCumulativeRate;
                    worksheet.Cell(currentRow, 71).Value = claim.MaxNumberIndexations;
                    worksheet.Cell(currentRow, 72).Value = claim.MinThresholdApplies;
                    worksheet.Cell(currentRow, 73).Value = claim.MaxThresholdApplies;
                    worksheet.Cell(currentRow, 74).Value = claim.Type;
                    worksheet.Cell(currentRow, 75).Value = claim.ChangeInClaimDefinitionDate;
                    worksheet.Cell(currentRow, 76).Value = claim.WhenAnyAllDecisionMade;
                    worksheet.Cell(currentRow, 77).Value = claim.DateBenefitsWithheld;
                    worksheet.Cell(currentRow, 78).Value = claim.WhoAuthorizedBenefitsWithheldC;
                    worksheet.Cell(currentRow, 79).Value = claim.WhoAuthorizedBenefitsWithheldI;
                    worksheet.Cell(currentRow, 80).Value = claim.LastUpdateUserNameC;
                    worksheet.Cell(currentRow, 81).Value = claim.LastUpdateUserNameI;
                    worksheet.Cell(currentRow, 82).Value = claim.AnyAllReviewDate;
                    worksheet.Cell(currentRow, 83).Value = claim.ReasonBenefitsWithheld;
                    worksheet.Cell(currentRow, 84).Value = claim.OverrideChangeInDefinitionDate;
                    worksheet.Cell(currentRow, 85).Value = claim.AnyAllStatus;
                    worksheet.Cell(currentRow, 86).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetBenefit(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetBenefit(id, appflag);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Benefit");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " Benefit";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideClaimIncurredDate"; worksheet.Cell(currentRow, 2).Value = claim.OverrideClaimIncurredDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitStartDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitStartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEndDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProofOfLossDate"; worksheet.Cell(currentRow, 2).Value = claim.ProofOfLossDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ExpectedBenefitClosureDate"; worksheet.Cell(currentRow, 2).Value = claim.ExpectedBenefitClosureDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveDateOfCoverage"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveDateOfCoverage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitExpiryDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitExpiryDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodBasis"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FullyRetained"; worksheet.Cell(currentRow, 2).Value = claim.FullyRetained;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDecision"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDecision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitDecisionDate"; worksheet.Cell(currentRow, 2).Value = claim.BenefitDecisionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonForBenefitDecision"; worksheet.Cell(currentRow, 2).Value = claim.ReasonForBenefitDecision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.BenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgreedValue"; worksheet.Cell(currentRow, 2).Value = claim.AgreedValue;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChronicConditionOption"; worksheet.Cell(currentRow, 2).Value = claim.ChronicConditionOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Day1AccidentOption"; worksheet.Cell(currentRow, 2).Value = claim.Day1AccidentOption;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Iar"; worksheet.Cell(currentRow, 2).Value = claim.Iar;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationalCategory"; worksheet.Cell(currentRow, 2).Value = claim.OccupationalCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PasriskOptionCode"; worksheet.Cell(currentRow, 2).Value = claim.PasriskOptionCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PasriskOptionDesc"; worksheet.Cell(currentRow, 2).Value = claim.PasriskOptionDesc;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuperContributionPct"; worksheet.Cell(currentRow, 2).Value = claim.SuperContributionPct;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GroupId"; worksheet.Cell(currentRow, 2).Value = claim.GroupId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SubBenefitFlag"; worksheet.Cell(currentRow, 2).Value = claim.SubBenefitFlag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDateCalculationType"; worksheet.Cell(currentRow, 2).Value = claim.StartDateCalculationType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EndDateCalculationType"; worksheet.Cell(currentRow, 2).Value = claim.EndDateCalculationType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriod"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriodAccident"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriodAccident;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriodHospital"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriodHospital;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriodBasis"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriodBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriodAccidentBasis"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriodAccidentBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumBenefitPeriodHospitalBasis"; worksheet.Cell(currentRow, 2).Value = claim.MaximumBenefitPeriodHospitalBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SicknessWaitingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.SicknessWaitingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AccidentWaitingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.AccidentWaitingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HospitalWaitingPeriod"; worksheet.Cell(currentRow, 2).Value = claim.HospitalWaitingPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WaitingPeriodBasis1"; worksheet.Cell(currentRow, 2).Value = claim.WaitingPeriodBasis1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AccidentWaitingPeriodBasis"; worksheet.Cell(currentRow, 2).Value = claim.AccidentWaitingPeriodBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HospitalWaitingPeriodBasis"; worksheet.Cell(currentRow, 2).Value = claim.HospitalWaitingPeriodBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SumInsured"; worksheet.Cell(currentRow, 2).Value = claim.SumInsured;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeroundingRule"; worksheet.Cell(currentRow, 2).Value = claim.AgeroundingRule;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RoundUnit"; worksheet.Cell(currentRow, 2).Value = claim.RoundUnit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AgeroundingPrecision"; worksheet.Cell(currentRow, 2).Value = claim.AgeroundingPrecision;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RoundInstruction"; worksheet.Cell(currentRow, 2).Value = claim.RoundInstruction;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumAggregateAmount"; worksheet.Cell(currentRow, 2).Value = claim.MaximumAggregateAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MinimumAmount"; worksheet.Cell(currentRow, 2).Value = claim.MinimumAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MinimumPercentage"; worksheet.Cell(currentRow, 2).Value = claim.MinimumPercentage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MinimumCalculationType"; worksheet.Cell(currentRow, 2).Value = claim.MinimumCalculationType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AutomaticAcceptanceLimit"; worksheet.Cell(currentRow, 2).Value = claim.AutomaticAcceptanceLimit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DuesCreatedInArrears"; worksheet.Cell(currentRow, 2).Value = claim.DuesCreatedInArrears;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumAmount"; worksheet.Cell(currentRow, 2).Value = claim.MaximumAmount;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumPercentage"; worksheet.Cell(currentRow, 2).Value = claim.MaximumPercentage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumCalculationType"; worksheet.Cell(currentRow, 2).Value = claim.MaximumCalculationType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Underwritten"; worksheet.Cell(currentRow, 2).Value = claim.Underwritten;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReinsurerLiabilityApprovedToDate"; worksheet.Cell(currentRow, 2).Value = claim.ReinsurerLiabilityApprovedToDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ToEndOfBenefit"; worksheet.Cell(currentRow, 2).Value = claim.ToEndOfBenefit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexationApplies"; worksheet.Cell(currentRow, 2).Value = claim.IndexationApplies;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdjustmentTypeName"; worksheet.Cell(currentRow, 2).Value = claim.AdjustmentTypeName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EliminationPeriod"; worksheet.Cell(currentRow, 2).Value = claim.EliminationPeriod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EliminationPeriodBasis"; worksheet.Cell(currentRow, 2).Value = claim.EliminationPeriodBasis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MinimumRate"; worksheet.Cell(currentRow, 2).Value = claim.MinimumRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IndexLeadTime"; worksheet.Cell(currentRow, 2).Value = claim.IndexLeadTime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AdjustBenefit"; worksheet.Cell(currentRow, 2).Value = claim.AdjustBenefit;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaximumCumulativeRate"; worksheet.Cell(currentRow, 2).Value = claim.MaximumCumulativeRate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaxNumberIndexations"; worksheet.Cell(currentRow, 2).Value = claim.MaxNumberIndexations;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MinThresholdApplies"; worksheet.Cell(currentRow, 2).Value = claim.MinThresholdApplies;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MaxThresholdApplies"; worksheet.Cell(currentRow, 2).Value = claim.MaxThresholdApplies;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ChangeInClaimDefinitionDate"; worksheet.Cell(currentRow, 2).Value = claim.ChangeInClaimDefinitionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WhenAnyAllDecisionMade"; worksheet.Cell(currentRow, 2).Value = claim.WhenAnyAllDecisionMade;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateBenefitsWithheld"; worksheet.Cell(currentRow, 2).Value = claim.DateBenefitsWithheld;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WhoAuthorizedBenefitsWithheldC"; worksheet.Cell(currentRow, 2).Value = claim.WhoAuthorizedBenefitsWithheldC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "WhoAuthorizedBenefitsWithheldI"; worksheet.Cell(currentRow, 2).Value = claim.WhoAuthorizedBenefitsWithheldI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdateUserNameC"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdateUserNameC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdateUserNameI"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdateUserNameI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AnyAllReviewDate"; worksheet.Cell(currentRow, 2).Value = claim.AnyAllReviewDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonBenefitsWithheld"; worksheet.Cell(currentRow, 2).Value = claim.ReasonBenefitsWithheld;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OverrideChangeInDefinitionDate"; worksheet.Cell(currentRow, 2).Value = claim.OverrideChangeInDefinitionDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AnyAllStatus"; worksheet.Cell(currentRow, 2).Value = claim.AnyAllStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetNote1s(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchNote1(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Note2");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Note";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PartyC";
                worksheet.Cell(currentRow, 5).Value = "PartyI";
                worksheet.Cell(currentRow, 6).Value = "ContactC";
                worksheet.Cell(currentRow, 7).Value = "ContactI";
                worksheet.Cell(currentRow, 8).Value = "CaseC";
                worksheet.Cell(currentRow, 9).Value = "CaseI";
                worksheet.Cell(currentRow, 10).Value = "PackedData";
                worksheet.Cell(currentRow, 11).Value = "EnvelopId";
                worksheet.Cell(currentRow, 12).Value = "Tag";
                worksheet.Cell(currentRow, 13).Value = "DateCreated";
                worksheet.Cell(currentRow, 14).Value = "LastUpdated";
                worksheet.Cell(currentRow, 15).Value = "Description";
                worksheet.Cell(currentRow, 16).Value = "KeyDocument";
                worksheet.Cell(currentRow, 17).Value = "EffectiveFrom";
                worksheet.Cell(currentRow, 18).Value = "EffectiveTo";
                worksheet.Cell(currentRow, 19).Value = "DocumentType";
                worksheet.Cell(currentRow, 20).Value = "CreatedBy";
                worksheet.Cell(currentRow, 21).Value = "UpdatedBy";
                worksheet.Cell(currentRow, 22).Value = "UpdatedBy";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 5).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 6).Value = claim.ContactC;
                    worksheet.Cell(currentRow, 7).Value = claim.ContactI;
                    worksheet.Cell(currentRow, 8).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 9).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 10).Value = claim.PackedData;
                    worksheet.Cell(currentRow, 11).Value = claim.EnvelopId;
                    worksheet.Cell(currentRow, 12).Value = claim.Tag;
                    worksheet.Cell(currentRow, 13).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 14).Value = claim.LastUpdated;
                    worksheet.Cell(currentRow, 15).Value = claim.Description;
                    worksheet.Cell(currentRow, 16).Value = claim.KeyDocument;
                    worksheet.Cell(currentRow, 17).Value = claim.EffectiveFrom;
                    worksheet.Cell(currentRow, 18).Value = claim.EffectiveTo;
                    worksheet.Cell(currentRow, 19).Value = claim.DocumentType;
                    worksheet.Cell(currentRow, 20).Value = claim.CreatedBy;
                    worksheet.Cell(currentRow, 21).Value = claim.UpdatedBy;
                    worksheet.Cell(currentRow, 22).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetNote1(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetNote1(id, appflag);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Note2");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + "  Note";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactC"; worksheet.Cell(currentRow, 2).Value = claim.ContactC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactI"; worksheet.Cell(currentRow, 2).Value = claim.ContactI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PackedData"; worksheet.Cell(currentRow, 2).Value = claim.PackedData;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EnvelopId"; worksheet.Cell(currentRow, 2).Value = claim.EnvelopId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Tag"; worksheet.Cell(currentRow, 2).Value = claim.Tag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdated"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "KeyDocument"; worksheet.Cell(currentRow, 2).Value = claim.KeyDocument;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveFrom"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveTo"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveTo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentType"; worksheet.Cell(currentRow, 2).Value = claim.DocumentType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreatedBy"; worksheet.Cell(currentRow, 2).Value = claim.CreatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UpdatedBy"; worksheet.Cell(currentRow, 2).Value = claim.UpdatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetMedicalCodes(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchMedicalCode(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("MedicalCode");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " MedicalCode";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "ClaimC";
                worksheet.Cell(currentRow, 5).Value = "ClaimI";
                worksheet.Cell(currentRow, 6).Value = "MedicalCondition";
                worksheet.Cell(currentRow, 7).Value = "DateOfFirstTreatment";
                worksheet.Cell(currentRow, 8).Value = "LifeExpectancy";
                worksheet.Cell(currentRow, 9).Value = "Diagnosis";
                worksheet.Cell(currentRow, 10).Value = "DateOfDiagnosis";
                worksheet.Cell(currentRow, 11).Value = "DateOfFirstConsultation";
                worksheet.Cell(currentRow, 12).Value = "CustomerDominantSide";
                worksheet.Cell(currentRow, 13).Value = "ImpactOnActivityLevels";
                worksheet.Cell(currentRow, 14).Value = "Description";
                worksheet.Cell(currentRow, 15).Value = "Level";
                worksheet.Cell(currentRow, 16).Value = "Type";
                worksheet.Cell(currentRow, 17).Value = "Code";
                worksheet.Cell(currentRow, 18).Value = "Severity";
                worksheet.Cell(currentRow, 19).Value = "Status";
                worksheet.Cell(currentRow, 20).Value = "EffectiveFrom";
                worksheet.Cell(currentRow, 21).Value = "PreExistingCondition";
                worksheet.Cell(currentRow, 22).Value = "LevelIndicator";
                worksheet.Cell(currentRow, 23).Value = "DurationClass";
                worksheet.Cell(currentRow, 24).Value = "BodySide";
                worksheet.Cell(currentRow, 25).Value = "BodyLocation";
                worksheet.Cell(currentRow, 26).Value = "EffectiveTo";
                worksheet.Cell(currentRow, 27).Value = "Comment";
                worksheet.Cell(currentRow, 28).Value = "RequestDate";
                worksheet.Cell(currentRow, 29).Value = "ApprovalDate";
                worksheet.Cell(currentRow, 30).Value = "Source";
                worksheet.Cell(currentRow, 31).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 32).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimC;
                    worksheet.Cell(currentRow, 5).Value = claim.ClaimI;
                    worksheet.Cell(currentRow, 6).Value = claim.MedicalCondition;
                    worksheet.Cell(currentRow, 7).Value = claim.DateOfFirstTreatment;
                    worksheet.Cell(currentRow, 8).Value = claim.LifeExpectancy;
                    worksheet.Cell(currentRow, 9).Value = claim.Diagnosis;
                    worksheet.Cell(currentRow, 10).Value = claim.DateOfDiagnosis;
                    worksheet.Cell(currentRow, 11).Value = claim.DateOfFirstConsultation;
                    worksheet.Cell(currentRow, 12).Value = claim.CustomerDominantSide;
                    worksheet.Cell(currentRow, 13).Value = claim.ImpactOnActivityLevels;
                    worksheet.Cell(currentRow, 14).Value = claim.Description;
                    worksheet.Cell(currentRow, 15).Value = claim.Level;
                    worksheet.Cell(currentRow, 16).Value = claim.Type;
                    worksheet.Cell(currentRow, 17).Value = claim.Code;
                    worksheet.Cell(currentRow, 18).Value = claim.Severity;
                    worksheet.Cell(currentRow, 19).Value = claim.Status;
                    worksheet.Cell(currentRow, 20).Value = claim.EffectiveFrom;
                    worksheet.Cell(currentRow, 21).Value = claim.PreExistingCondition;
                    worksheet.Cell(currentRow, 22).Value = claim.LevelIndicator;
                    worksheet.Cell(currentRow, 23).Value = claim.DurationClass;
                    worksheet.Cell(currentRow, 24).Value = claim.BodySide;
                    worksheet.Cell(currentRow, 25).Value = claim.BodyLocation;
                    worksheet.Cell(currentRow, 26).Value = claim.EffectiveTo;
                    worksheet.Cell(currentRow, 27).Value = claim.Comment;
                    worksheet.Cell(currentRow, 28).Value = claim.RequestDate;
                    worksheet.Cell(currentRow, 29).Value = claim.ApprovalDate;
                    worksheet.Cell(currentRow, 30).Value = claim.Source;
                    worksheet.Cell(currentRow, 31).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 32).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetMedicalCode(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetMedicalCode(id, appflag);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("MedicalCode");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name:" + GetAppName(claim.ApplicationId) + " MedicalCode";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MedicalCondition"; worksheet.Cell(currentRow, 2).Value = claim.MedicalCondition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfFirstTreatment"; worksheet.Cell(currentRow, 2).Value = claim.DateOfFirstTreatment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LifeExpectancy"; worksheet.Cell(currentRow, 2).Value = claim.LifeExpectancy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Diagnosis"; worksheet.Cell(currentRow, 2).Value = claim.Diagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfDiagnosis"; worksheet.Cell(currentRow, 2).Value = claim.DateOfDiagnosis;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfFirstConsultation"; worksheet.Cell(currentRow, 2).Value = claim.DateOfFirstConsultation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerDominantSide"; worksheet.Cell(currentRow, 2).Value = claim.CustomerDominantSide;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ImpactOnActivityLevels"; worksheet.Cell(currentRow, 2).Value = claim.ImpactOnActivityLevels;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Level"; worksheet.Cell(currentRow, 2).Value = claim.Level;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Code"; worksheet.Cell(currentRow, 2).Value = claim.Code;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Severity"; worksheet.Cell(currentRow, 2).Value = claim.Severity;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveFrom"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PreExistingCondition"; worksheet.Cell(currentRow, 2).Value = claim.PreExistingCondition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LevelIndicator"; worksheet.Cell(currentRow, 2).Value = claim.LevelIndicator;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DurationClass"; worksheet.Cell(currentRow, 2).Value = claim.DurationClass;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BodySide"; worksheet.Cell(currentRow, 2).Value = claim.BodySide;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BodyLocation"; worksheet.Cell(currentRow, 2).Value = claim.BodyLocation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveTo"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveTo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Comment"; worksheet.Cell(currentRow, 2).Value = claim.Comment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RequestDate"; worksheet.Cell(currentRow, 2).Value = claim.RequestDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ApprovalDate"; worksheet.Cell(currentRow, 2).Value = claim.ApprovalDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Source"; worksheet.Cell(currentRow, 2).Value = claim.Source;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetCoverageSearchs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchCoverageSearch(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CoverageSearch");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able CoverageSearch";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PolicyNumber";
                worksheet.Cell(currentRow, 5).Value = "Product";
                worksheet.Cell(currentRow, 6).Value = "ProductName";
                worksheet.Cell(currentRow, 7).Value = "ContractStatus";
                worksheet.Cell(currentRow, 8).Value = "ContractStatusName";
                worksheet.Cell(currentRow, 9).Value = "SourceSystem";
                worksheet.Cell(currentRow, 10).Value = "SourceSystemName";
                worksheet.Cell(currentRow, 11).Value = "StartDate";
                worksheet.Cell(currentRow, 12).Value = "TerminationDate";
                worksheet.Cell(currentRow, 13).Value = "EffectiveDate";
                worksheet.Cell(currentRow, 14).Value = "ClaimPolicyC";
                worksheet.Cell(currentRow, 15).Value = "ClaimPolicyI";
                worksheet.Cell(currentRow, 16).Value = "Coverage";
                worksheet.Cell(currentRow, 17).Value = "CoverageCode";
                worksheet.Cell(currentRow, 18).Value = "Status";
                worksheet.Cell(currentRow, 19).Value = "EffectiveDate1";
                worksheet.Cell(currentRow, 20).Value = "ClaimPolicyCoverageC";
                worksheet.Cell(currentRow, 21).Value = "ClaimPolicyCoverageI";
                worksheet.Cell(currentRow, 22).Value = "Type";
                worksheet.Cell(currentRow, 23).Value = "BenefitEntitlementDescription";
                worksheet.Cell(currentRow, 24).Value = "BenefitSelected";
                worksheet.Cell(currentRow, 25).Value = "PasriskOptionCode";
                worksheet.Cell(currentRow, 26).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 27).Value = "Pid";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PolicyNumber;
                    worksheet.Cell(currentRow, 5).Value = claim.Product;
                    worksheet.Cell(currentRow, 6).Value = claim.ProductName;
                    worksheet.Cell(currentRow, 7).Value = claim.ContractStatus;
                    worksheet.Cell(currentRow, 8).Value = claim.ContractStatusName;
                    worksheet.Cell(currentRow, 9).Value = claim.SourceSystem;
                    worksheet.Cell(currentRow, 10).Value = claim.SourceSystemName;
                    worksheet.Cell(currentRow, 11).Value = claim.StartDate;
                    worksheet.Cell(currentRow, 12).Value = claim.TerminationDate;
                    worksheet.Cell(currentRow, 13).Value = claim.EffectiveDate;
                    worksheet.Cell(currentRow, 14).Value = claim.ClaimPolicyC;
                    worksheet.Cell(currentRow, 15).Value = claim.ClaimPolicyI;
                    worksheet.Cell(currentRow, 16).Value = claim.Coverage;
                    worksheet.Cell(currentRow, 17).Value = claim.CoverageCode;
                    worksheet.Cell(currentRow, 18).Value = claim.Status;
                    worksheet.Cell(currentRow, 19).Value = claim.EffectiveDate1;
                    worksheet.Cell(currentRow, 20).Value = claim.ClaimPolicyCoverageC;
                    worksheet.Cell(currentRow, 21).Value = claim.ClaimPolicyCoverageI;
                    worksheet.Cell(currentRow, 22).Value = claim.Type;
                    worksheet.Cell(currentRow, 23).Value = claim.BenefitEntitlementDescription;
                    worksheet.Cell(currentRow, 24).Value = claim.BenefitSelected;
                    worksheet.Cell(currentRow, 25).Value = claim.PasriskOptionCode;
                    worksheet.Cell(currentRow, 26).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 27).Value = claim.Pid;
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

        public async Task<byte[]> GetCoverageSearch(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetCoverageSearch(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CoverageSearch");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: CoverageSearch";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PolicyNumber"; worksheet.Cell(currentRow, 2).Value = claim.PolicyNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Product"; worksheet.Cell(currentRow, 2).Value = claim.Product;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProductName"; worksheet.Cell(currentRow, 2).Value = claim.ProductName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatus"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContractStatusName"; worksheet.Cell(currentRow, 2).Value = claim.ContractStatusName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystem"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystem;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SourceSystemName"; worksheet.Cell(currentRow, 2).Value = claim.SourceSystemName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDate"; worksheet.Cell(currentRow, 2).Value = claim.StartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TerminationDate"; worksheet.Cell(currentRow, 2).Value = claim.TerminationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveDate"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimPolicyC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimPolicyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimPolicyI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimPolicyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Coverage"; worksheet.Cell(currentRow, 2).Value = claim.Coverage;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CoverageCode"; worksheet.Cell(currentRow, 2).Value = claim.CoverageCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveDate1"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveDate1;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimPolicyCoverageC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimPolicyCoverageC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimPolicyCoverageI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimPolicyCoverageI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitEntitlementDescription"; worksheet.Cell(currentRow, 2).Value = claim.BenefitEntitlementDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitSelected"; worksheet.Cell(currentRow, 2).Value = claim.BenefitSelected;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PasriskOptionCode"; worksheet.Cell(currentRow, 2).Value = claim.PasriskOptionCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Pid"; worksheet.Cell(currentRow, 2).Value = claim.Pid;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetPartySearchs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchPartySearch(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartySearch");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " PartySearch";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "CustomerNo";
                worksheet.Cell(currentRow, 3).Value = "Title";
                worksheet.Cell(currentRow, 4).Value = "Name";
                worksheet.Cell(currentRow, 5).Value = "Dob";
                worksheet.Cell(currentRow, 6).Value = "Dod";
                worksheet.Cell(currentRow, 7).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 8).Value = "Pid";
                worksheet.Cell(currentRow, 9).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.CustomerNo;
                    worksheet.Cell(currentRow, 3).Value = claim.Title;
                    worksheet.Cell(currentRow, 4).Value = claim.Name;
                    worksheet.Cell(currentRow, 5).Value = claim.Dob;
                    worksheet.Cell(currentRow, 6).Value = claim.Dod;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 8).Value = claim.Pid;
                    worksheet.Cell(currentRow, 9).Value = GetAppName(claim.ApplicationId);
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

        public async Task<byte[]> GetPartySearch(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetPartySearch(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartySearch");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " PartySearch";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerNo"; worksheet.Cell(currentRow, 2).Value = claim.CustomerNo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Title"; worksheet.Cell(currentRow, 2).Value = claim.Title;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Dob"; worksheet.Cell(currentRow, 2).Value = claim.Dob;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Dod"; worksheet.Cell(currentRow, 2).Value = claim.Dod;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Pid"; worksheet.Cell(currentRow, 2).Value = claim.Pid;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchDocument(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Document");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Document";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PartyC";
                worksheet.Cell(currentRow, 5).Value = "PartyI";
                worksheet.Cell(currentRow, 6).Value = "ContactC";
                worksheet.Cell(currentRow, 7).Value = "ContactI";
                worksheet.Cell(currentRow, 8).Value = "CaseC";
                worksheet.Cell(currentRow, 9).Value = "CaseI";
                worksheet.Cell(currentRow, 10).Value = "EnvelopId";
                worksheet.Cell(currentRow, 11).Value = "Tag";
                worksheet.Cell(currentRow, 12).Value = "DateCreated";
                worksheet.Cell(currentRow, 13).Value = "LastUpdated";
                worksheet.Cell(currentRow, 14).Value = "Description";
                worksheet.Cell(currentRow, 15).Value = "KeyDocument";
                worksheet.Cell(currentRow, 16).Value = "EffectiveFrom";
                worksheet.Cell(currentRow, 17).Value = "EffectiveTo";
                worksheet.Cell(currentRow, 18).Value = "DocumentType";
                worksheet.Cell(currentRow, 19).Value = "CreatedBy";
                worksheet.Cell(currentRow, 20).Value = "UpdatedBy";
                worksheet.Cell(currentRow, 21).Value = "Title";
                worksheet.Cell(currentRow, 22).Value = "FileName";
                worksheet.Cell(currentRow, 23).Value = "FileType";
                worksheet.Cell(currentRow, 24).Value = "ClaimNumber";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 5).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 6).Value = claim.ContactC;
                    worksheet.Cell(currentRow, 7).Value = claim.ContactI;
                    worksheet.Cell(currentRow, 8).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 9).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 10).Value = claim.EnvelopId;
                    worksheet.Cell(currentRow, 11).Value = claim.Tag;
                    worksheet.Cell(currentRow, 12).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 13).Value = claim.LastUpdated;
                    worksheet.Cell(currentRow, 14).Value = claim.Description;
                    worksheet.Cell(currentRow, 15).Value = claim.KeyDocument;
                    worksheet.Cell(currentRow, 16).Value = claim.EffectiveFrom;
                    worksheet.Cell(currentRow, 17).Value = claim.EffectiveTo;
                    worksheet.Cell(currentRow, 18).Value = claim.DocumentType;
                    worksheet.Cell(currentRow, 19).Value = claim.CreatedBy;
                    worksheet.Cell(currentRow, 20).Value = claim.UpdatedBy;
                    worksheet.Cell(currentRow, 21).Value = claim.Title;
                    worksheet.Cell(currentRow, 22).Value = claim.FileName;
                    worksheet.Cell(currentRow, 23).Value = claim.FileType;
                    worksheet.Cell(currentRow, 24).Value = claim.ClaimNumber;
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

        public async Task<byte[]> GetDocument(string id, int appflag = 1)
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
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactC"; worksheet.Cell(currentRow, 2).Value = claim.ContactC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactI"; worksheet.Cell(currentRow, 2).Value = claim.ContactI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EnvelopId"; worksheet.Cell(currentRow, 2).Value = claim.EnvelopId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Tag"; worksheet.Cell(currentRow, 2).Value = claim.Tag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdated"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "KeyDocument"; worksheet.Cell(currentRow, 2).Value = claim.KeyDocument;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveFrom"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveFrom;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EffectiveTo"; worksheet.Cell(currentRow, 2).Value = claim.EffectiveTo;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentType"; worksheet.Cell(currentRow, 2).Value = claim.DocumentType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreatedBy"; worksheet.Cell(currentRow, 2).Value = claim.CreatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UpdatedBy"; worksheet.Cell(currentRow, 2).Value = claim.UpdatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Title"; worksheet.Cell(currentRow, 2).Value = claim.Title;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FileName"; worksheet.Cell(currentRow, 2).Value = claim.FileName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FileType"; worksheet.Cell(currentRow, 2).Value = claim.FileType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;

                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetCaseValidations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchCaseValidation(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CaseValidation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able CaseValidation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "Category";
                worksheet.Cell(currentRow, 7).Value = "Message";
                worksheet.Cell(currentRow, 8).Value = "UserC";
                worksheet.Cell(currentRow, 9).Value = "UserI";
                worksheet.Cell(currentRow, 10).Value = "LastUpdatedDate";
                worksheet.Cell(currentRow, 11).Value = "LastUpdatedBy";
                worksheet.Cell(currentRow, 12).Value = "ReasonForSuppression";
                worksheet.Cell(currentRow, 13).Value = "Description";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.Category;
                    worksheet.Cell(currentRow, 7).Value = claim.Message;
                    worksheet.Cell(currentRow, 8).Value = claim.UserC;
                    worksheet.Cell(currentRow, 9).Value = claim.UserI;
                    worksheet.Cell(currentRow, 10).Value = claim.LastUpdatedDate;
                    worksheet.Cell(currentRow, 11).Value = claim.LastUpdatedBy;
                    worksheet.Cell(currentRow, 12).Value = claim.ReasonForSuppression;
                    worksheet.Cell(currentRow, 13).Value = claim.Description;
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

        public async Task<byte[]> GetCaseValidation(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetCaseValidation(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CaseValidation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: CaseValidation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Category"; worksheet.Cell(currentRow, 2).Value = claim.Category;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Message"; worksheet.Cell(currentRow, 2).Value = claim.Message;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserC"; worksheet.Cell(currentRow, 2).Value = claim.UserC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserI"; worksheet.Cell(currentRow, 2).Value = claim.UserI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdatedDate"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdatedDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdatedBy"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonForSuppression"; worksheet.Cell(currentRow, 2).Value = claim.ReasonForSuppression;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetOutstandingRequests(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchOutstandingRequest(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("OutstandingRequest");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able OutstandingRequest";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "PartySourceC";
                worksheet.Cell(currentRow, 5).Value = "PartySourceI";
                worksheet.Cell(currentRow, 6).Value = "PartySubjectC";
                worksheet.Cell(currentRow, 7).Value = "PartySubjectI";
                worksheet.Cell(currentRow, 8).Value = "CaseC";
                worksheet.Cell(currentRow, 9).Value = "CaseI";
                worksheet.Cell(currentRow, 10).Value = "ProcessC";
                worksheet.Cell(currentRow, 11).Value = "ProcessI";
                worksheet.Cell(currentRow, 12).Value = "TaskC";
                worksheet.Cell(currentRow, 13).Value = "TaskI";
                worksheet.Cell(currentRow, 14).Value = "DocumentC";
                worksheet.Cell(currentRow, 15).Value = "DocumentI";
                worksheet.Cell(currentRow, 16).Value = "Type";
                worksheet.Cell(currentRow, 17).Value = "DateCreated";
                worksheet.Cell(currentRow, 18).Value = "CreatedBy";
                worksheet.Cell(currentRow, 19).Value = "LastFollowedUpBy";
                worksheet.Cell(currentRow, 20).Value = "NextFollowUpDate";
                worksheet.Cell(currentRow, 21).Value = "Description";
                worksheet.Cell(currentRow, 22).Value = "Category";
                worksheet.Cell(currentRow, 23).Value = "CreationDate";
                worksheet.Cell(currentRow, 24).Value = "Status";
                worksheet.Cell(currentRow, 25).Value = "DateRequested";
                worksheet.Cell(currentRow, 26).Value = "RequestedBy";
                worksheet.Cell(currentRow, 27).Value = "DateLastFollowedUp";
                worksheet.Cell(currentRow, 28).Value = "NotProceedingWithDate";
                worksheet.Cell(currentRow, 29).Value = "DateCompleted";
                worksheet.Cell(currentRow, 30).Value = "CompletionReason";
                worksheet.Cell(currentRow, 31).Value = "CompletionNotes";
                worksheet.Cell(currentRow, 32).Value = "DateSuppressed";
                worksheet.Cell(currentRow, 33).Value = "SuppressionReason";
                worksheet.Cell(currentRow, 34).Value = "SuppressionNotes";
                worksheet.Cell(currentRow, 35).Value = "SuppressedBy";
                worksheet.Cell(currentRow, 36).Value = "UserCreated";
                worksheet.Cell(currentRow, 37).Value = "UserLastUpdated";
                worksheet.Cell(currentRow, 38).Value = "UpdatedBy";
                worksheet.Cell(currentRow, 39).Value = "SelectedCategory";
                worksheet.Cell(currentRow, 40).Value = "SelectedType";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.PartySourceC;
                    worksheet.Cell(currentRow, 5).Value = claim.PartySourceI;
                    worksheet.Cell(currentRow, 6).Value = claim.PartySubjectC;
                    worksheet.Cell(currentRow, 7).Value = claim.PartySubjectI;
                    worksheet.Cell(currentRow, 8).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 9).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 10).Value = claim.ProcessC;
                    worksheet.Cell(currentRow, 11).Value = claim.ProcessI;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskC;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskI;
                    worksheet.Cell(currentRow, 14).Value = claim.DocumentC;
                    worksheet.Cell(currentRow, 15).Value = claim.DocumentI;
                    worksheet.Cell(currentRow, 16).Value = claim.Type;
                    worksheet.Cell(currentRow, 17).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 18).Value = claim.CreatedBy;
                    worksheet.Cell(currentRow, 19).Value = claim.LastFollowedUpBy;
                    worksheet.Cell(currentRow, 20).Value = claim.NextFollowUpDate;
                    worksheet.Cell(currentRow, 21).Value = claim.Description;
                    worksheet.Cell(currentRow, 22).Value = claim.Category;
                    worksheet.Cell(currentRow, 23).Value = claim.CreationDate;
                    worksheet.Cell(currentRow, 24).Value = claim.Status;
                    worksheet.Cell(currentRow, 25).Value = claim.DateRequested;
                    worksheet.Cell(currentRow, 26).Value = claim.RequestedBy;
                    worksheet.Cell(currentRow, 27).Value = claim.DateLastFollowedUp;
                    worksheet.Cell(currentRow, 28).Value = claim.NotProceedingWithDate;
                    worksheet.Cell(currentRow, 29).Value = claim.DateCompleted;
                    worksheet.Cell(currentRow, 30).Value = claim.CompletionReason;
                    worksheet.Cell(currentRow, 31).Value = claim.CompletionNotes;
                    worksheet.Cell(currentRow, 32).Value = claim.DateSuppressed;
                    worksheet.Cell(currentRow, 33).Value = claim.SuppressionReason;
                    worksheet.Cell(currentRow, 34).Value = claim.SuppressionNotes;
                    worksheet.Cell(currentRow, 35).Value = claim.SuppressedBy;
                    worksheet.Cell(currentRow, 36).Value = claim.UserCreated;
                    worksheet.Cell(currentRow, 37).Value = claim.UserLastUpdated;
                    worksheet.Cell(currentRow, 38).Value = claim.UpdatedBy;
                    worksheet.Cell(currentRow, 39).Value = claim.SelectedCategory;
                    worksheet.Cell(currentRow, 40).Value = claim.SelectedType;
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

        public async Task<byte[]> GetOutstandingRequest(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetOutstandingRequest(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("OutstandingRequest");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: OutstandingRequest";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartySourceC"; worksheet.Cell(currentRow, 2).Value = claim.PartySourceC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartySourceI"; worksheet.Cell(currentRow, 2).Value = claim.PartySourceI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartySubjectC"; worksheet.Cell(currentRow, 2).Value = claim.PartySubjectC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartySubjectI"; worksheet.Cell(currentRow, 2).Value = claim.PartySubjectI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProcessC"; worksheet.Cell(currentRow, 2).Value = claim.ProcessC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProcessI"; worksheet.Cell(currentRow, 2).Value = claim.ProcessI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskC"; worksheet.Cell(currentRow, 2).Value = claim.TaskC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskI"; worksheet.Cell(currentRow, 2).Value = claim.TaskI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentC"; worksheet.Cell(currentRow, 2).Value = claim.DocumentC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentI"; worksheet.Cell(currentRow, 2).Value = claim.DocumentI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Type"; worksheet.Cell(currentRow, 2).Value = claim.Type;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreatedBy"; worksheet.Cell(currentRow, 2).Value = claim.CreatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastFollowedUpBy"; worksheet.Cell(currentRow, 2).Value = claim.LastFollowedUpBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NextFollowUpDate"; worksheet.Cell(currentRow, 2).Value = claim.NextFollowUpDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Category"; worksheet.Cell(currentRow, 2).Value = claim.Category;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreationDate"; worksheet.Cell(currentRow, 2).Value = claim.CreationDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateRequested"; worksheet.Cell(currentRow, 2).Value = claim.DateRequested;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RequestedBy"; worksheet.Cell(currentRow, 2).Value = claim.RequestedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateLastFollowedUp"; worksheet.Cell(currentRow, 2).Value = claim.DateLastFollowedUp;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NotProceedingWithDate"; worksheet.Cell(currentRow, 2).Value = claim.NotProceedingWithDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCompleted"; worksheet.Cell(currentRow, 2).Value = claim.DateCompleted;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CompletionReason"; worksheet.Cell(currentRow, 2).Value = claim.CompletionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CompletionNotes"; worksheet.Cell(currentRow, 2).Value = claim.CompletionNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateSuppressed"; worksheet.Cell(currentRow, 2).Value = claim.DateSuppressed;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuppressionReason"; worksheet.Cell(currentRow, 2).Value = claim.SuppressionReason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuppressionNotes"; worksheet.Cell(currentRow, 2).Value = claim.SuppressionNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SuppressedBy"; worksheet.Cell(currentRow, 2).Value = claim.SuppressedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserCreated"; worksheet.Cell(currentRow, 2).Value = claim.UserCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserLastUpdated"; worksheet.Cell(currentRow, 2).Value = claim.UserLastUpdated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UpdatedBy"; worksheet.Cell(currentRow, 2).Value = claim.UpdatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SelectedCategory"; worksheet.Cell(currentRow, 2).Value = claim.SelectedCategory;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SelectedType"; worksheet.Cell(currentRow, 2).Value = claim.SelectedType;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetTaskAs(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchTaskA(column, search, pageIndex, pageSize, appflag);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("TaskA");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " TaskA";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "DocumentC";
                worksheet.Cell(currentRow, 5).Value = "DocumentI";
                worksheet.Cell(currentRow, 6).Value = "PartyC";
                worksheet.Cell(currentRow, 7).Value = "PartyI";
                worksheet.Cell(currentRow, 8).Value = "PlicyC";
                worksheet.Cell(currentRow, 9).Value = "PlicyI";
                worksheet.Cell(currentRow, 10).Value = "ProcessC";
                worksheet.Cell(currentRow, 11).Value = "ProcessI";
                worksheet.Cell(currentRow, 12).Value = "TaskC";
                worksheet.Cell(currentRow, 13).Value = "TaskI";
                worksheet.Cell(currentRow, 14).Value = "TaskType";
                worksheet.Cell(currentRow, 15).Value = "Status";
                worksheet.Cell(currentRow, 16).Value = "Target";
                worksheet.Cell(currentRow, 17).Value = "Description";
                worksheet.Cell(currentRow, 18).Value = "OriginalTargetDate";
                worksheet.Cell(currentRow, 19).Value = "Priority";
                worksheet.Cell(currentRow, 20).Value = "Subject";
                worksheet.Cell(currentRow, 21).Value = "Assignee";
                worksheet.Cell(currentRow, 22).Value = "OnHoldUntil";
                worksheet.Cell(currentRow, 23).Value = "CreatedBy";
                worksheet.Cell(currentRow, 24).Value = "DefaultDepartment";
                worksheet.Cell(currentRow, 25).Value = "CreationDate";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.DocumentC;
                    worksheet.Cell(currentRow, 5).Value = claim.DocumentI;
                    worksheet.Cell(currentRow, 6).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 7).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 8).Value = claim.PlicyC;
                    worksheet.Cell(currentRow, 9).Value = claim.PlicyI;
                    worksheet.Cell(currentRow, 10).Value = claim.ProcessC;
                    worksheet.Cell(currentRow, 11).Value = claim.ProcessI;
                    worksheet.Cell(currentRow, 12).Value = claim.TaskC;
                    worksheet.Cell(currentRow, 13).Value = claim.TaskI;
                    worksheet.Cell(currentRow, 14).Value = claim.TaskType;
                    worksheet.Cell(currentRow, 15).Value = claim.Status;
                    worksheet.Cell(currentRow, 16).Value = claim.Target;
                    worksheet.Cell(currentRow, 17).Value = claim.Description;
                    worksheet.Cell(currentRow, 18).Value = claim.OriginalTargetDate;
                    worksheet.Cell(currentRow, 19).Value = claim.Priority;
                    worksheet.Cell(currentRow, 20).Value = claim.Subject;
                    worksheet.Cell(currentRow, 21).Value = claim.Assignee;
                    worksheet.Cell(currentRow, 22).Value = claim.OnHoldUntil;
                    worksheet.Cell(currentRow, 23).Value = claim.CreatedBy;
                    worksheet.Cell(currentRow, 24).Value = claim.DefaultDepartment;
                    worksheet.Cell(currentRow, 25).Value = claim.CreationDate;
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

        public async Task<byte[]> GetTaskA(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetTaskA(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("TaskA");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: TaskA";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentC"; worksheet.Cell(currentRow, 2).Value = claim.DocumentC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DocumentI"; worksheet.Cell(currentRow, 2).Value = claim.DocumentI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlicyC"; worksheet.Cell(currentRow, 2).Value = claim.PlicyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PlicyI"; worksheet.Cell(currentRow, 2).Value = claim.PlicyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProcessC"; worksheet.Cell(currentRow, 2).Value = claim.ProcessC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ProcessI"; worksheet.Cell(currentRow, 2).Value = claim.ProcessI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskC"; worksheet.Cell(currentRow, 2).Value = claim.TaskC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskI"; worksheet.Cell(currentRow, 2).Value = claim.TaskI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TaskType"; worksheet.Cell(currentRow, 2).Value = claim.TaskType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Target"; worksheet.Cell(currentRow, 2).Value = claim.Target;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OriginalTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.OriginalTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Priority"; worksheet.Cell(currentRow, 2).Value = claim.Priority;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Subject"; worksheet.Cell(currentRow, 2).Value = claim.Subject;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Assignee"; worksheet.Cell(currentRow, 2).Value = claim.Assignee;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OnHoldUntil"; worksheet.Cell(currentRow, 2).Value = claim.OnHoldUntil;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreatedBy"; worksheet.Cell(currentRow, 2).Value = claim.CreatedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DefaultDepartment"; worksheet.Cell(currentRow, 2).Value = claim.DefaultDepartment;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreationDate"; worksheet.Cell(currentRow, 2).Value = claim.CreationDate;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            byte[] data = null!;
            var items = await _context.SearchContact(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Contact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(appflag) + " Contact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "DateTime";
                worksheet.Cell(currentRow, 7).Value = "Reason";
                worksheet.Cell(currentRow, 8).Value = "Method";
                worksheet.Cell(currentRow, 9).Value = "Direction";
                worksheet.Cell(currentRow, 10).Value = "ContactSuccessful";
                worksheet.Cell(currentRow, 11).Value = "Description";
                worksheet.Cell(currentRow, 12).Value = "MethodOfContact";
                worksheet.Cell(currentRow, 13).Value = "CustomerRepresentative";
                worksheet.Cell(currentRow, 14).Value = "PhoneRecordingLink";
                worksheet.Cell(currentRow, 15).Value = "User";
                worksheet.Cell(currentRow, 16).Value = "ContactDuration";
                worksheet.Cell(currentRow, 17).Value = "PrivacyTag";
                worksheet.Cell(currentRow, 18).Value = "DealtWithBy";
                worksheet.Cell(currentRow, 19).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 20).Value = "Application";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.DateTime;
                    worksheet.Cell(currentRow, 7).Value = claim.Reason;
                    worksheet.Cell(currentRow, 8).Value = claim.Method;
                    worksheet.Cell(currentRow, 9).Value = claim.Direction;
                    worksheet.Cell(currentRow, 10).Value = claim.ContactSuccessful;
                    worksheet.Cell(currentRow, 11).Value = claim.Description;
                    worksheet.Cell(currentRow, 12).Value = claim.MethodOfContact;
                    worksheet.Cell(currentRow, 13).Value = claim.CustomerRepresentative;
                    worksheet.Cell(currentRow, 14).Value = claim.PhoneRecordingLink;
                    worksheet.Cell(currentRow, 15).Value = claim.User;
                    worksheet.Cell(currentRow, 16).Value = claim.ContactDuration;
                    worksheet.Cell(currentRow, 17).Value = claim.PrivacyTag;
                    worksheet.Cell(currentRow, 18).Value = claim.DealtWithBy;
                    worksheet.Cell(currentRow, 19).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 20).Value = GetAppName(claim.ApplicationId);

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

        public async Task<byte[]> GetContact(string id, int appflag = 1)
        {
            byte[] data = null!;
            var claim = await _context.GetContact(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Contact");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: " + GetAppName(claim.ApplicationId) + " Contact";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateTime"; worksheet.Cell(currentRow, 2).Value = claim.DateTime;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Reason"; worksheet.Cell(currentRow, 2).Value = claim.Reason;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Method"; worksheet.Cell(currentRow, 2).Value = claim.Method;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Direction"; worksheet.Cell(currentRow, 2).Value = claim.Direction;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactSuccessful"; worksheet.Cell(currentRow, 2).Value = claim.ContactSuccessful;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "MethodOfContact"; worksheet.Cell(currentRow, 2).Value = claim.MethodOfContact;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerRepresentative"; worksheet.Cell(currentRow, 2).Value = claim.CustomerRepresentative;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PhoneRecordingLink"; worksheet.Cell(currentRow, 2).Value = claim.PhoneRecordingLink;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "User"; worksheet.Cell(currentRow, 2).Value = claim.User;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ContactDuration"; worksheet.Cell(currentRow, 2).Value = claim.ContactDuration;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PrivacyTag"; worksheet.Cell(currentRow, 2).Value = claim.PrivacyTag;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DealtWithBy"; worksheet.Cell(currentRow, 2).Value = claim.DealtWithBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Application"; worksheet.Cell(currentRow, 2).Value = GetAppName(claim.ApplicationId);


                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetOccupations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchOccupation(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Occupation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able Occupation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "ClaimC";
                worksheet.Cell(currentRow, 5).Value = "ClaimI";
                worksheet.Cell(currentRow, 6).Value = "PartyC";
                worksheet.Cell(currentRow, 7).Value = "PartyI";
                worksheet.Cell(currentRow, 8).Value = "DateOfHire";
                worksheet.Cell(currentRow, 9).Value = "JobTitle";
                worksheet.Cell(currentRow, 10).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 11).Value = "DateJobEnded";
                worksheet.Cell(currentRow, 12).Value = "OccupationCode";
                worksheet.Cell(currentRow, 13).Value = "SelfEmployed";
                worksheet.Cell(currentRow, 14).Value = "EmploymentStatus";
                worksheet.Cell(currentRow, 15).Value = "DaysWorkedPerWeek";
                worksheet.Cell(currentRow, 16).Value = "NatureOfWorkDuties";
                worksheet.Cell(currentRow, 17).Value = "ReasonForCeasingPosition";
                worksheet.Cell(currentRow, 18).Value = "BusinessStructure";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimC;
                    worksheet.Cell(currentRow, 5).Value = claim.ClaimI;
                    worksheet.Cell(currentRow, 6).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 7).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 8).Value = claim.DateOfHire;
                    worksheet.Cell(currentRow, 9).Value = claim.JobTitle;
                    worksheet.Cell(currentRow, 10).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 11).Value = claim.DateJobEnded;
                    worksheet.Cell(currentRow, 12).Value = claim.OccupationCode;
                    worksheet.Cell(currentRow, 13).Value = claim.SelfEmployed;
                    worksheet.Cell(currentRow, 14).Value = claim.EmploymentStatus;
                    worksheet.Cell(currentRow, 15).Value = claim.DaysWorkedPerWeek;
                    worksheet.Cell(currentRow, 16).Value = claim.NatureOfWorkDuties;
                    worksheet.Cell(currentRow, 17).Value = claim.ReasonForCeasingPosition;
                    worksheet.Cell(currentRow, 18).Value = claim.BusinessStructure;
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

        public async Task<byte[]> GetOccupation(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetOccupation(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Occupation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Occupation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfHire"; worksheet.Cell(currentRow, 2).Value = claim.DateOfHire;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "JobTitle"; worksheet.Cell(currentRow, 2).Value = claim.JobTitle;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateJobEnded"; worksheet.Cell(currentRow, 2).Value = claim.DateJobEnded;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationCode"; worksheet.Cell(currentRow, 2).Value = claim.OccupationCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SelfEmployed"; worksheet.Cell(currentRow, 2).Value = claim.SelfEmployed;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EmploymentStatus"; worksheet.Cell(currentRow, 2).Value = claim.EmploymentStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.DaysWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NatureOfWorkDuties"; worksheet.Cell(currentRow, 2).Value = claim.NatureOfWorkDuties;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonForCeasingPosition"; worksheet.Cell(currentRow, 2).Value = claim.ReasonForCeasingPosition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessStructure"; worksheet.Cell(currentRow, 2).Value = claim.BusinessStructure;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetClaimOccupations(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchClaimOccupation(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClaimOccupation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able ClaimOccupation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "ClaimC";
                worksheet.Cell(currentRow, 7).Value = "ClaimI";
                worksheet.Cell(currentRow, 8).Value = "PartyC";
                worksheet.Cell(currentRow, 9).Value = "PartyI";
                worksheet.Cell(currentRow, 10).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 11).Value = "Occupation";
                worksheet.Cell(currentRow, 12).Value = "JobTitle";
                worksheet.Cell(currentRow, 13).Value = "HoursWorkedPerWeek";
                worksheet.Cell(currentRow, 14).Value = "GrossAmt";
                worksheet.Cell(currentRow, 15).Value = "DateOfHire";
                worksheet.Cell(currentRow, 16).Value = "DateJobEnded";
                worksheet.Cell(currentRow, 17).Value = "OccupationCode";
                worksheet.Cell(currentRow, 18).Value = "IncomeType";
                worksheet.Cell(currentRow, 19).Value = "EmploymentStatus";
                worksheet.Cell(currentRow, 20).Value = "SelfEmployed";
                worksheet.Cell(currentRow, 21).Value = "DaysWorkedPerWeek";
                worksheet.Cell(currentRow, 22).Value = "NatureOfWorkDuties";
                worksheet.Cell(currentRow, 23).Value = "ReasonForCeasingPosition";
                worksheet.Cell(currentRow, 24).Value = "BusinessStructure";
                worksheet.Cell(currentRow, 25).Value = "Rank";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.ClaimC;
                    worksheet.Cell(currentRow, 7).Value = claim.ClaimI;
                    worksheet.Cell(currentRow, 8).Value = claim.PartyC;
                    worksheet.Cell(currentRow, 9).Value = claim.PartyI;
                    worksheet.Cell(currentRow, 10).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 11).Value = claim.Occupation;
                    worksheet.Cell(currentRow, 12).Value = claim.JobTitle;
                    worksheet.Cell(currentRow, 13).Value = claim.HoursWorkedPerWeek;
                    worksheet.Cell(currentRow, 14).Value = claim.GrossAmt;
                    worksheet.Cell(currentRow, 15).Value = claim.DateOfHire;
                    worksheet.Cell(currentRow, 16).Value = claim.DateJobEnded;
                    worksheet.Cell(currentRow, 17).Value = claim.OccupationCode;
                    worksheet.Cell(currentRow, 18).Value = claim.IncomeType;
                    worksheet.Cell(currentRow, 19).Value = claim.EmploymentStatus;
                    worksheet.Cell(currentRow, 20).Value = claim.SelfEmployed;
                    worksheet.Cell(currentRow, 21).Value = claim.DaysWorkedPerWeek;
                    worksheet.Cell(currentRow, 22).Value = claim.NatureOfWorkDuties;
                    worksheet.Cell(currentRow, 23).Value = claim.ReasonForCeasingPosition;
                    worksheet.Cell(currentRow, 24).Value = claim.BusinessStructure;
                    worksheet.Cell(currentRow, 25).Value = claim.Rank;
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

        public async Task<byte[]> GetClaimOccupation(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetClaimOccupation(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClaimOccupation");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: ClaimOccupation";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyC"; worksheet.Cell(currentRow, 2).Value = claim.PartyC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyI"; worksheet.Cell(currentRow, 2).Value = claim.PartyI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Occupation"; worksheet.Cell(currentRow, 2).Value = claim.Occupation;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "JobTitle"; worksheet.Cell(currentRow, 2).Value = claim.JobTitle;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "HoursWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.HoursWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GrossAmt"; worksheet.Cell(currentRow, 2).Value = claim.GrossAmt;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateOfHire"; worksheet.Cell(currentRow, 2).Value = claim.DateOfHire;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateJobEnded"; worksheet.Cell(currentRow, 2).Value = claim.DateJobEnded;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OccupationCode"; worksheet.Cell(currentRow, 2).Value = claim.OccupationCode;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IncomeType"; worksheet.Cell(currentRow, 2).Value = claim.IncomeType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EmploymentStatus"; worksheet.Cell(currentRow, 2).Value = claim.EmploymentStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SelfEmployed"; worksheet.Cell(currentRow, 2).Value = claim.SelfEmployed;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DaysWorkedPerWeek"; worksheet.Cell(currentRow, 2).Value = claim.DaysWorkedPerWeek;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "NatureOfWorkDuties"; worksheet.Cell(currentRow, 2).Value = claim.NatureOfWorkDuties;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReasonForCeasingPosition"; worksheet.Cell(currentRow, 2).Value = claim.ReasonForCeasingPosition;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BusinessStructure"; worksheet.Cell(currentRow, 2).Value = claim.BusinessStructure;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Rank"; worksheet.Cell(currentRow, 2).Value = claim.Rank;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetClaimPeriods(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchClaimPeriod(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClaimPeriod");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able ClaimPeriod";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "ClaimC";
                worksheet.Cell(currentRow, 5).Value = "ClaimI";
                worksheet.Cell(currentRow, 6).Value = "PartyCFacility";
                worksheet.Cell(currentRow, 7).Value = "PartyIFacility";
                worksheet.Cell(currentRow, 8).Value = "StartDate";
                worksheet.Cell(currentRow, 9).Value = "EndDate";
                worksheet.Cell(currentRow, 10).Value = "Description";
                worksheet.Cell(currentRow, 11).Value = "ClaimNumber";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.ClaimC;
                    worksheet.Cell(currentRow, 5).Value = claim.ClaimI;
                    worksheet.Cell(currentRow, 6).Value = claim.PartyCFacility;
                    worksheet.Cell(currentRow, 7).Value = claim.PartyIFacility;
                    worksheet.Cell(currentRow, 8).Value = claim.StartDate;
                    worksheet.Cell(currentRow, 9).Value = claim.EndDate;
                    worksheet.Cell(currentRow, 10).Value = claim.Description;
                    worksheet.Cell(currentRow, 11).Value = claim.ClaimNumber;
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

        public async Task<byte[]> GetClaimPeriod(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetClaimPeriod(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClaimPeriod");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: ClaimPeriod";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimC"; worksheet.Cell(currentRow, 2).Value = claim.ClaimC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimI"; worksheet.Cell(currentRow, 2).Value = claim.ClaimI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyCFacility"; worksheet.Cell(currentRow, 2).Value = claim.PartyCFacility;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyIFacility"; worksheet.Cell(currentRow, 2).Value = claim.PartyIFacility;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDate"; worksheet.Cell(currentRow, 2).Value = claim.StartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EndDate"; worksheet.Cell(currentRow, 2).Value = claim.EndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetClientGoals(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchClientGoal(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClientGoal");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able ClientGoal";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "CustomerGoalName";
                worksheet.Cell(currentRow, 7).Value = "GoalDescription";
                worksheet.Cell(currentRow, 8).Value = "GoalTargetDate";
                worksheet.Cell(currentRow, 9).Value = "Status";
                worksheet.Cell(currentRow, 10).Value = "OutcomeDate";
                worksheet.Cell(currentRow, 11).Value = "OutcomeNotes";
                worksheet.Cell(currentRow, 12).Value = "GoalDateRationale";
                worksheet.Cell(currentRow, 13).Value = "AchievementTimeframe";
                worksheet.Cell(currentRow, 14).Value = "CreateDate";
                worksheet.Cell(currentRow, 15).Value = "GoalReason";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.CustomerGoalName;
                    worksheet.Cell(currentRow, 7).Value = claim.GoalDescription;
                    worksheet.Cell(currentRow, 8).Value = claim.GoalTargetDate;
                    worksheet.Cell(currentRow, 9).Value = claim.Status;
                    worksheet.Cell(currentRow, 10).Value = claim.OutcomeDate;
                    worksheet.Cell(currentRow, 11).Value = claim.OutcomeNotes;
                    worksheet.Cell(currentRow, 12).Value = claim.GoalDateRationale;
                    worksheet.Cell(currentRow, 13).Value = claim.AchievementTimeframe;
                    worksheet.Cell(currentRow, 14).Value = claim.CreateDate;
                    worksheet.Cell(currentRow, 15).Value = claim.GoalReason;
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

        public async Task<byte[]> GetClientGoal(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetClientGoal(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ClientGoal");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: ClientGoal";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerGoalName"; worksheet.Cell(currentRow, 2).Value = claim.CustomerGoalName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalDescription"; worksheet.Cell(currentRow, 2).Value = claim.GoalDescription;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalTargetDate"; worksheet.Cell(currentRow, 2).Value = claim.GoalTargetDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OutcomeDate"; worksheet.Cell(currentRow, 2).Value = claim.OutcomeDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OutcomeNotes"; worksheet.Cell(currentRow, 2).Value = claim.OutcomeNotes;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalDateRationale"; worksheet.Cell(currentRow, 2).Value = claim.GoalDateRationale;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "AchievementTimeframe"; worksheet.Cell(currentRow, 2).Value = claim.AchievementTimeframe;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CreateDate"; worksheet.Cell(currentRow, 2).Value = claim.CreateDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalReason"; worksheet.Cell(currentRow, 2).Value = claim.GoalReason;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetGoals(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchGoal(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Goal");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able Goal";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "ClientGoalC";
                worksheet.Cell(currentRow, 5).Value = "ClientGoalI";
                worksheet.Cell(currentRow, 6).Value = "LifeAreaC";
                worksheet.Cell(currentRow, 7).Value = "LifeAreaI";
                worksheet.Cell(currentRow, 8).Value = "StrategyName";
                worksheet.Cell(currentRow, 9).Value = "SummarySnapshot";
                worksheet.Cell(currentRow, 10).Value = "CustomerStrategyStatus";
                worksheet.Cell(currentRow, 11).Value = "TargetDate";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.ClientGoalC;
                    worksheet.Cell(currentRow, 5).Value = claim.ClientGoalI;
                    worksheet.Cell(currentRow, 6).Value = claim.LifeAreaC;
                    worksheet.Cell(currentRow, 7).Value = claim.LifeAreaI;
                    worksheet.Cell(currentRow, 8).Value = claim.StrategyName;
                    worksheet.Cell(currentRow, 9).Value = claim.SummarySnapshot;
                    worksheet.Cell(currentRow, 10).Value = claim.CustomerStrategyStatus;
                    worksheet.Cell(currentRow, 11).Value = claim.TargetDate;
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

        public async Task<byte[]> GetGoal(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetGoal(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Goal");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Goal";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClientGoalC"; worksheet.Cell(currentRow, 2).Value = claim.ClientGoalC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClientGoalI"; worksheet.Cell(currentRow, 2).Value = claim.ClientGoalI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LifeAreaC"; worksheet.Cell(currentRow, 2).Value = claim.LifeAreaC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LifeAreaI"; worksheet.Cell(currentRow, 2).Value = claim.LifeAreaI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StrategyName"; worksheet.Cell(currentRow, 2).Value = claim.StrategyName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "SummarySnapshot"; worksheet.Cell(currentRow, 2).Value = claim.SummarySnapshot;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CustomerStrategyStatus"; worksheet.Cell(currentRow, 2).Value = claim.CustomerStrategyStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "TargetDate"; worksheet.Cell(currentRow, 2).Value = claim.TargetDate;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetActionAs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchActionA(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ActionA");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able ActionA";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "GoalC";
                worksheet.Cell(currentRow, 5).Value = "GoalI";
                worksheet.Cell(currentRow, 6).Value = "PartyCResponsibilityOfServiceProvider";
                worksheet.Cell(currentRow, 7).Value = "PartyIResponsibilityOfServiceProvider";
                worksheet.Cell(currentRow, 8).Value = "PartyCResponsibilityOfClient";
                worksheet.Cell(currentRow, 9).Value = "PartyIResponsibilityOfClient";
                worksheet.Cell(currentRow, 10).Value = "UserCResponsibilityOfStaffMember";
                worksheet.Cell(currentRow, 11).Value = "UserIResponsibilityOfStaffMember";
                worksheet.Cell(currentRow, 12).Value = "Rationale";
                worksheet.Cell(currentRow, 13).Value = "ActionOutcome";
                worksheet.Cell(currentRow, 14).Value = "OutcomeComments";
                worksheet.Cell(currentRow, 15).Value = "ActionName";
                worksheet.Cell(currentRow, 16).Value = "StartDate";
                worksheet.Cell(currentRow, 17).Value = "EndDate";
                worksheet.Cell(currentRow, 18).Value = "ReviewDate";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.GoalC;
                    worksheet.Cell(currentRow, 5).Value = claim.GoalI;
                    worksheet.Cell(currentRow, 6).Value = claim.PartyCResponsibilityOfServiceProvider;
                    worksheet.Cell(currentRow, 7).Value = claim.PartyIResponsibilityOfServiceProvider;
                    worksheet.Cell(currentRow, 8).Value = claim.PartyCResponsibilityOfClient;
                    worksheet.Cell(currentRow, 9).Value = claim.PartyIResponsibilityOfClient;
                    worksheet.Cell(currentRow, 10).Value = claim.UserCResponsibilityOfStaffMember;
                    worksheet.Cell(currentRow, 11).Value = claim.UserIResponsibilityOfStaffMember;
                    worksheet.Cell(currentRow, 12).Value = claim.Rationale;
                    worksheet.Cell(currentRow, 13).Value = claim.ActionOutcome;
                    worksheet.Cell(currentRow, 14).Value = claim.OutcomeComments;
                    worksheet.Cell(currentRow, 15).Value = claim.ActionName;
                    worksheet.Cell(currentRow, 16).Value = claim.StartDate;
                    worksheet.Cell(currentRow, 17).Value = claim.EndDate;
                    worksheet.Cell(currentRow, 18).Value = claim.ReviewDate;
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

        public async Task<byte[]> GetActionA(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetActionA(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ActionA");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: ActionA";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalC"; worksheet.Cell(currentRow, 2).Value = claim.GoalC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "GoalI"; worksheet.Cell(currentRow, 2).Value = claim.GoalI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyCResponsibilityOfServiceProvider"; worksheet.Cell(currentRow, 2).Value = claim.PartyCResponsibilityOfServiceProvider;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyIResponsibilityOfServiceProvider"; worksheet.Cell(currentRow, 2).Value = claim.PartyIResponsibilityOfServiceProvider;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyCResponsibilityOfClient"; worksheet.Cell(currentRow, 2).Value = claim.PartyCResponsibilityOfClient;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "PartyIResponsibilityOfClient"; worksheet.Cell(currentRow, 2).Value = claim.PartyIResponsibilityOfClient;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserCResponsibilityOfStaffMember"; worksheet.Cell(currentRow, 2).Value = claim.UserCResponsibilityOfStaffMember;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserIResponsibilityOfStaffMember"; worksheet.Cell(currentRow, 2).Value = claim.UserIResponsibilityOfStaffMember;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Rationale"; worksheet.Cell(currentRow, 2).Value = claim.Rationale;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionOutcome"; worksheet.Cell(currentRow, 2).Value = claim.ActionOutcome;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "OutcomeComments"; worksheet.Cell(currentRow, 2).Value = claim.OutcomeComments;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ActionName"; worksheet.Cell(currentRow, 2).Value = claim.ActionName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "StartDate"; worksheet.Cell(currentRow, 2).Value = claim.StartDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "EndDate"; worksheet.Cell(currentRow, 2).Value = claim.EndDate;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReviewDate"; worksheet.Cell(currentRow, 2).Value = claim.ReviewDate;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }
        public async Task<byte[]> GetLifeAreas(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchLifeArea(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("LifeArea");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able LifeArea";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "C";
                worksheet.Cell(currentRow, 3).Value = "I";
                worksheet.Cell(currentRow, 4).Value = "CaseC";
                worksheet.Cell(currentRow, 5).Value = "CaseI";
                worksheet.Cell(currentRow, 6).Value = "Factors";
                worksheet.Cell(currentRow, 7).Value = "FactorStatus";
                worksheet.Cell(currentRow, 8).Value = "Notes";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.C;
                    worksheet.Cell(currentRow, 3).Value = claim.I;
                    worksheet.Cell(currentRow, 4).Value = claim.CaseC;
                    worksheet.Cell(currentRow, 5).Value = claim.CaseI;
                    worksheet.Cell(currentRow, 6).Value = claim.Factors;
                    worksheet.Cell(currentRow, 7).Value = claim.FactorStatus;
                    worksheet.Cell(currentRow, 8).Value = claim.Notes;
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

        public async Task<byte[]> GetLifeArea(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetLifeArea(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("LifeArea");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: LifeArea";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "C"; worksheet.Cell(currentRow, 2).Value = claim.C;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "I"; worksheet.Cell(currentRow, 2).Value = claim.I;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseC"; worksheet.Cell(currentRow, 2).Value = claim.CaseC;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "CaseI"; worksheet.Cell(currentRow, 2).Value = claim.CaseI;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Factors"; worksheet.Cell(currentRow, 2).Value = claim.Factors;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "FactorStatus"; worksheet.Cell(currentRow, 2).Value = claim.FactorStatus;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Notes"; worksheet.Cell(currentRow, 2).Value = claim.Notes;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetActionHistorys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchActionHistory(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ActionHistory");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able ActionHistory";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "LastUpdated";
                worksheet.Cell(currentRow, 3).Value = "ClaimNumber";
                worksheet.Cell(currentRow, 4).Value = "BenefitNumber";
                worksheet.Cell(currentRow, 5).Value = "Name";
                worksheet.Cell(currentRow, 6).Value = "Description";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.LastUpdated;
                    worksheet.Cell(currentRow, 3).Value = claim.ClaimNumber;
                    worksheet.Cell(currentRow, 4).Value = claim.BenefitNumber;
                    worksheet.Cell(currentRow, 5).Value = claim.Name;
                    worksheet.Cell(currentRow, 6).Value = claim.Description;
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

        public async Task<byte[]> GetActionHistory(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetActionHistory(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ActionHistory");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: ActionHistory";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LastUpdated"; worksheet.Cell(currentRow, 2).Value = claim.LastUpdated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ClaimNumber"; worksheet.Cell(currentRow, 2).Value = claim.ClaimNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "BenefitNumber"; worksheet.Cell(currentRow, 2).Value = claim.BenefitNumber;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Name"; worksheet.Cell(currentRow, 2).Value = claim.Name;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetAbleIssues(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchAbleIssue(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("AbleIssue");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able AbleIssue";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ReportedBy";
                worksheet.Cell(currentRow, 3).Value = "Description";
                worksheet.Cell(currentRow, 4).Value = "DateReported";
                worksheet.Cell(currentRow, 5).Value = "Status";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.ReportedBy;
                    worksheet.Cell(currentRow, 3).Value = claim.Description;
                    worksheet.Cell(currentRow, 4).Value = claim.DateReported;
                    worksheet.Cell(currentRow, 5).Value = claim.Status;
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

        public async Task<byte[]> GetAbleIssue(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetAbleIssue(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("AbleIssue");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: AbleIssue";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "ReportedBy"; worksheet.Cell(currentRow, 2).Value = claim.ReportedBy;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Description"; worksheet.Cell(currentRow, 2).Value = claim.Description;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateReported"; worksheet.Cell(currentRow, 2).Value = claim.DateReported;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Status"; worksheet.Cell(currentRow, 2).Value = claim.Status;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetSiteLogs(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchSiteLog(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("SiteLog");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able SiteLog";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "UserId";
                worksheet.Cell(currentRow, 3).Value = "Message";
                worksheet.Cell(currentRow, 4).Value = "LogType";
                worksheet.Cell(currentRow, 5).Value = "DateCreated";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.Id;
                    worksheet.Cell(currentRow, 2).Value = claim.UserId;
                    worksheet.Cell(currentRow, 3).Value = claim.Message;
                    worksheet.Cell(currentRow, 4).Value = claim.LogType;
                    worksheet.Cell(currentRow, 5).Value = claim.DateCreated;
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

        public async Task<byte[]> GetSiteLog(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetSiteLog(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("SiteLog");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: SiteLog";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "Id"; worksheet.Cell(currentRow, 2).Value = claim.Id;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserId"; worksheet.Cell(currentRow, 2).Value = claim.UserId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "Message"; worksheet.Cell(currentRow, 2).Value = claim.Message;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "LogType"; worksheet.Cell(currentRow, 2).Value = claim.LogType;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;



                //worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    data = stream.ToArray();
                }
            }

            return data;
        }

        public async Task<byte[]> GetAbleSiteUsers(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            var items = await _context.SearchAbleSiteUser(column, search, pageIndex, pageSize);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("AbleSiteUser");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: Able AbleSiteUser";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Number of Rows: " + items.Count.ToString();
                worksheet.Cell(4, 1).Value = "Created By: User";
                worksheet.Cell(5, 1).Value = "";


                worksheet.Cell(currentRow, 1).Value = "UserId";
                worksheet.Cell(currentRow, 2).Value = "UserName";
                worksheet.Cell(currentRow, 3).Value = "RoleName";
                worksheet.Cell(currentRow, 4).Value = "DateCreated";
                worksheet.Cell(currentRow, 5).Value = "IsActive";

                foreach (var claim in items)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = claim.UserId;
                    worksheet.Cell(currentRow, 2).Value = claim.UserName;
                    worksheet.Cell(currentRow, 3).Value = claim.RoleName;
                    worksheet.Cell(currentRow, 4).Value = claim.DateCreated;
                    worksheet.Cell(currentRow, 5).Value = claim.IsActive.ToString();
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

        public async Task<byte[]> GetAbleSiteUser(string id)
        {
            byte[] data = null!;
            var claim = await _context.GetAbleSiteUser(id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("AbleSiteUser");
                var currentRow = 6;
                worksheet.Cell(1, 1).Value = "Report Name: AbleSiteUser";
                worksheet.Cell(2, 1).Value = "Report Date: " + DateTime.Now.ToString();
                worksheet.Cell(3, 1).Value = "Created By: User";
                worksheet.Cell(4, 1).Value = "";

                worksheet.Cell(currentRow, 1).Value = "Parameter";
                worksheet.Cell(currentRow, 2).Value = "Value";


                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserId"; worksheet.Cell(currentRow, 2).Value = claim.UserId;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "UserName"; worksheet.Cell(currentRow, 2).Value = claim.UserName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "RoleName"; worksheet.Cell(currentRow, 2).Value = claim.RoleName;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "DateCreated"; worksheet.Cell(currentRow, 2).Value = claim.DateCreated;
                currentRow++; worksheet.Cell(currentRow, 1).Value = "IsActive"; worksheet.Cell(currentRow, 2).Value = claim.IsActive.ToString();



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
