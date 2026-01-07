using AppCoreV1.ABLEModels;
using AppCoreV1.Data;
using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Web;

namespace AppCoreV1.Repositories
{
    public class AbleSearch : IAbleSearch
    {
        private readonly AbleDBContext _context;
        private readonly ILogger<AbleSearch> _logger;

        public AbleSearch(AbleDBContext context, ILogger<AbleSearch> logger)
        {
            _context = context;
            _logger = logger;
        }

        public AbleDBContext GetAbleContext()
        {
            return _context;
        }

        public async Task<bool> AddSiteLog(SiteLog sitelog)
        {
            _context.Add(sitelog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddSiteLog(string message, string type)
        {
            SiteLog sitelog = new SiteLog
            {
                Id = 0,
                UserId = "System",
                Message = message,
                LogType = type,
                DateCreated = DateTime.Now.ToString(),
            };

            _context.Add(sitelog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedList<AbleSiteUser>> SearchAbleSiteUser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<AbleSiteUser> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.SiteUsers
                            orderby c.UserId ascending
                            select new AbleSiteUser
                            {
                                UserId = c.UserId,
                                UserName = c.UserName,
                                RoleName = c.RoleName,
                                DateCreated = c.DateCreated,
                                IsActive = c.IsActive
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "UserId":
                            query = query.Where(c => c.UserId!.Contains(search));
                            break;
                        case "UserName":
                            query = query.Where(c => c.UserName!.Contains(search));
                            break;
                        case "RoleName":
                            query = query.Where(c => c.RoleName!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated!.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<AbleSiteUser>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<AbleSiteUser> GetAbleSiteUser(string id)
        {
            AbleSiteUser item = null!;
            try
            {
                id = id.Replace("WLIFE", "WLIFE\\");
                var c = await _context.SiteUsers.FirstOrDefaultAsync(m => m.UserId == id);
                if (c != null)
                {
                    item = new AbleSiteUser
                    {
                        UserId = c.UserId,
                        UserName = c.UserName,
                        RoleName = c.RoleName,
                        DateCreated = c.DateCreated,
                        IsActive = c.IsActive,
                    };
                }
                else
                {
                    item = new AbleSiteUser();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new AbleSiteUser();
            }

            return item;
        }

        public async Task<PaginatedList<SiteLog>> SearchSiteLog(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<SiteLog> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.SiteLogs
                            orderby c.Id descending
                            select new SiteLog
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                Message = c.Message,
                                LogType = c.LogType,
                                DateCreated = c.DateCreated,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "UserId":
                            query = query.Where(c => c.UserId!.Contains(search));
                            break;
                        case "Message":
                            query = query.Where(c => c.Message!.Contains(search));
                            break;
                        case "LogType":
                            query = query.Where(c => c.LogType!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated!.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<SiteLog>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<SiteLog> GetSiteLog(string id)
        {
            SiteLog item = null!;
            try
            {
                var c = await _context.SiteLogs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new SiteLog
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        Message = c.Message,
                        LogType = c.LogType,
                        DateCreated = c.DateCreated,
                    };
                }
                else
                {
                    item = new SiteLog();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new SiteLog();
            }

            return item;
        }

        public async Task<AbleSiteUser> GetSiteUser(string id)
        {
            AbleSiteUser item = null!;
            try
            {
                var c = await _context.SiteUsers.FirstOrDefaultAsync(m => m.UserId == id);
                if (c != null)
                {
                    item = new AbleSiteUser
                    {
                        UserId = c.UserId,
                        UserName = c.UserName,
                        RoleName = c.RoleName,
                        DateCreated = c.DateCreated,
                        IsActive = c.IsActive,
                    };
                }
                else
                {
                    item = new AbleSiteUser();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new AbleSiteUser();
            }

            return item;
        }


        public async Task<PaginatedList<ReportRequest>> SearchReportRequest(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ReportRequest> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ReportRequests
                            orderby c.DateRequested descending
                            select new ReportRequest
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                ReportName = c.ReportName,
                                Email = c.Email,
                                DateRequested = c.DateRequested,
                                Status = c.Status,
                                DateCompleted = c.DateCompleted,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Status":
                            query = query.Where(c => c.Status!.Contains(search));
                            break;
                        case "UserId":
                            query = query.Where(c => c.UserId!.Contains(search));
                            break;
                        case "ReportName":
                            query = query.Where(c => c.ReportName!.Contains(search));
                            break;
                        case "Email":
                            query = query.Where(c => c.Email!.Contains(search));
                            break;
                        case "DateRequested":
                            query = query.Where(c => c.DateRequested.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<ReportRequest>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ReportRequest> GetReportRequest(string id)
        {
            ReportRequest item = null!;
            try
            {
                var c = await _context.ReportRequests.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ReportRequest
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        ReportName = c.ReportName,
                        Email = c.Email,
                        DateRequested = c.DateRequested,
                        Status = c.Status,
                    };
                }
                else
                {
                    item = new ReportRequest();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ReportRequest();
            }

            return item;
        }
        public async Task<PaginatedList<ReportRequest>> SearchNewRequest(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ReportRequest> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ReportRequests
                            where c.Status == "New"
                            orderby c.DateRequested descending
                            select new ReportRequest
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                ReportName = c.ReportName,
                                Email = c.Email,
                                DateRequested = c.DateRequested,
                                Status = c.Status,
                                DateCompleted = c.DateCompleted,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Status":
                            query = query.Where(c => c.Status!.Contains(search));
                            break;
                        case "UserId":
                            query = query.Where(c => c.UserId!.Contains(search));
                            break;
                        case "ReportName":
                            query = query.Where(c => c.ReportName!.Contains(search));
                            break;
                        case "Email":
                            query = query.Where(c => c.Email!.Contains(search));
                            break;
                        case "DateRequested":
                            query = query.Where(c => c.DateRequested.ToString()!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<ReportRequest>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ReportRequest> UpdateReportRequest(int id, int status)
        {
            ReportRequest item = null!;
            try
            {
                var updateitem = await _context.ReportRequests.FirstOrDefaultAsync(m => m.Id == id);
                
                if (updateitem != null)
                {
                    if(status == 1)
                    {
                        updateitem.Status = "InProgress";
                    }
                    else if (status == 2)
                    {
                        updateitem.Status = "Completed";
                        updateitem.DateCompleted = DateTime.Now;
                    }

                    _context.ReportRequests.Update(updateitem);
                    await _context.SaveChangesAsync();
                }
  

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return item;
        }

        public async Task<bool> CreatePageAndClassesV1()
        {
            await System.Threading.Tasks.Task.FromResult(true);
            return true;
        }

        public List<string> GetModelSearchColumnsV1(string modelname)
        {
            List<string> columns = new List<string>();
            //TblModelMapping item = null!;
            //try
            //{
            //    var c = await _context.TblModelMappings.FirstOrDefaultAsync(m => m.ModelName == modelname);
            //    if (c != null)
            //    {
            //        item = new TblModelMapping
            //        {
            //            ModelName = c.ModelName,
            //            Column1 = c.Column1,
            //            Column2 = c.Column2,
            //            Column3 = c.Column3,
            //            Column4 = c.Column4,
            //        };

            //        columns.Add(c.Column1);
            //        columns.Add(c.Column2);
            //        columns.Add(c.Column3);
            //        columns.Add(c.Column4);
            //    }
            //    else
            //    {
            //        item = new TblModelMapping();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.ToString());
            //}

            return columns;
        }

        public async Task<PaginatedList<Claimbenefitmv>> SearchClaimbenefitmv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Claimbenefitmv> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimbenefitmvs
                            orderby c.Id ascending
                            //where c.StaffInd == claimflag
                            select new Claimbenefitmv
                            {
                                Id = c.Id,
                                BenefitNumber = c.BenefitNumber,
                                PolicyNumber = c.PolicyNumber,
                                ClaimNumber = c.ClaimNumber,
                                Surname = c.Surname,
                                GivenName = c.GivenName,
                                DateOfBirth = c.DateOfBirth,
                                ClaimStatus = c.ClaimStatus,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Claimbenefitmv>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaginatedList<Claimbenefitmv>> SearchClaimbenefitmvD(string column, string search, string column1, string search1, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Claimbenefitmv> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claimbenefitmvs
                            orderby c.Id descending
                            //where c.StaffInd == claimflag
                            select new Claimbenefitmv
                            {
                                Id = c.Id,
                                BenefitNumber = c.BenefitNumber,
                                PolicyNumber = c.PolicyNumber,
                                ClaimNumber = c.ClaimNumber,
                                Surname = c.Surname,
                                GivenName = c.GivenName,
                                DateOfBirth = c.DateOfBirth,
                                ClaimStatus = c.ClaimStatus,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;

                    }
                }

                if (!string.IsNullOrEmpty(search1))
                {
                    switch (column1)
                    {
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search1));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search1));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search1));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search1));
                            break;
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search1));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search1));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                // filter by application
                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Claimbenefitmv>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claimbenefitmv> GetClaimbenefitmv(string id, int appflag = 1)
        {
            Claimbenefitmv item = null!;
            try
            {
                var c = await _context.Claimbenefitmvs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Claimbenefitmv
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        IndicativeClaimType = c.IndicativeClaimType,
                        ClaimStatus = c.ClaimStatus,
                        StaffInd = c.StaffInd,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        PolicyNumber = c.PolicyNumber,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        ProductName = c.ProductName,
                        BenefitType = c.BenefitType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitCode = c.TargetBenefitCode,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        CoverType = c.CoverType,
                        BenefitStatus = c.BenefitStatus,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        SumInsured = c.SumInsured,
                        BenefitPaymentFreq = c.BenefitPaymentFreq,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        FirstAcceptanceDate = c.FirstAcceptanceDate,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        IndexationFrequency = c.IndexationFrequency,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        ReInsurerName = c.ReInsurerName,
                        ReinsuranceTreatyType = c.ReinsuranceTreatyType,
                        ReinsurancePercent = c.ReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        PrimaryOccSelfEmployedInd = c.PrimaryOccSelfEmployedInd,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ContractEndDate = c.ContractEndDate,
                        SumReInsured = c.SumReInsured,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        SourceSystem = c.SourceSystem,
                        Entity = c.Entity,
                        OccupationCategory = c.OccupationCategory,
                        TpdDefinition = c.TpdDefinition,
                        TpdSubDefinition = c.TpdSubDefinition,
                        TraumaDefinition = c.TraumaDefinition,
                        SourceBenefitType = c.SourceBenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        Declined = c.Declined,
                        QualifyingPeriod = c.QualifyingPeriod,
                        ExpectedResolutionDate = c.ExpectedResolutionDate,
                        TargetBenefitType = c.TargetBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        PaymentAuthorized = c.PaymentAuthorized,
                        ClaimAllocateNewDate = c.ClaimAllocateNewDate,
                        ClaimAllowAutoAllocation = c.ClaimAllowAutoAllocation,
                        AllocatedBy = c.AllocatedBy,
                        AssignedToDept = c.AssignedToDept,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CoverageNumber = c.CoverageNumber,
                        Assessedunderlimitedcover = c.Assessedunderlimitedcover,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        UnexpectedCircumstancesApply = c.UnexpectedCircumstancesApply,
                        IarCode = c.IarCode,
                        IarDescription = c.IarDescription,
                        ApplicationId = c.ApplicationId,
                    };
                }
                else
                {
                    item = new Claimbenefitmv();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimbenefitmv();
            }

            return item;
        }

        public async Task<Claimbenefitmv> GetClaimbenefitmvByClaimNo(string id)
        {
            Claimbenefitmv item = null!;
            try
            {
                //var c = await _context.Claimbenefitmvs.FirstOrDefaultAsync(m => m.ClaimNumber == id);
                var c = await _context.Claimbenefitmvs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));

                if (c != null)
                {
                    item = new Claimbenefitmv
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        IndicativeClaimType = c.IndicativeClaimType,
                        ClaimStatus = c.ClaimStatus,
                        StaffInd = c.StaffInd,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        PolicyNumber = c.PolicyNumber,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        ProductName = c.ProductName,
                        BenefitType = c.BenefitType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitCode = c.TargetBenefitCode,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        CoverType = c.CoverType,
                        BenefitStatus = c.BenefitStatus,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        SumInsured = c.SumInsured,
                        BenefitPaymentFreq = c.BenefitPaymentFreq,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        FirstAcceptanceDate = c.FirstAcceptanceDate,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        IndexationFrequency = c.IndexationFrequency,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        ReInsurerName = c.ReInsurerName,
                        ReinsuranceTreatyType = c.ReinsuranceTreatyType,
                        ReinsurancePercent = c.ReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        PrimaryOccSelfEmployedInd = c.PrimaryOccSelfEmployedInd,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ContractEndDate = c.ContractEndDate,
                        SumReInsured = c.SumReInsured,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        SourceSystem = c.SourceSystem,
                        Entity = c.Entity,
                        OccupationCategory = c.OccupationCategory,
                        TpdDefinition = c.TpdDefinition,
                        TpdSubDefinition = c.TpdSubDefinition,
                        TraumaDefinition = c.TraumaDefinition,
                        SourceBenefitType = c.SourceBenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        Declined = c.Declined,
                        QualifyingPeriod = c.QualifyingPeriod,
                        ExpectedResolutionDate = c.ExpectedResolutionDate,
                        TargetBenefitType = c.TargetBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        PaymentAuthorized = c.PaymentAuthorized,
                        ClaimAllocateNewDate = c.ClaimAllocateNewDate,
                        ClaimAllowAutoAllocation = c.ClaimAllowAutoAllocation,
                        AllocatedBy = c.AllocatedBy,
                        AssignedToDept = c.AssignedToDept,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CoverageNumber = c.CoverageNumber,
                        Assessedunderlimitedcover = c.Assessedunderlimitedcover,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        UnexpectedCircumstancesApply = c.UnexpectedCircumstancesApply,
                        IarCode = c.IarCode,
                        IarDescription = c.IarDescription,
                    };
                }
                else
                {
                    item = new Claimbenefitmv();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claimbenefitmv();
            }

            return item;
        }

        public async Task<PaginatedList<Paymentsummarymv>> SearchPaymentsummarymv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Paymentsummarymv> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Paymentsummarymvs
                            orderby c.DateCreated descending
                            //where c.StaffInd == claimflag
                            select new Paymentsummarymv
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                DateCreated = c.DateCreated ?? null,
                                BenefitNumber = c.BenefitNumber ?? string.Empty,
                                BenefitPayment = c.BenefitPayment ?? string.Empty,
                                BenefitType = c.BenefitType ?? string.Empty,
                                BenefitAmount = c.BenefitAmount ?? null,
                                From = c.From ?? string.Empty,
                                To = c.To ?? string.Empty,
                                Tax = c.Tax ?? null,
                                Total = c.Total ?? null,
                                PaymentMethod = c.PaymentMethod ?? string.Empty,
                                PaymentReference = c.PaymentReference ?? string.Empty,
                                OtherInformationEnd = c.OtherInformationEnd ?? string.Empty,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated!.ToString()!.Contains(search));
                            break;
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search));
                            break;
                        case "BenefitType":
                            query = query.Where(c => c.BenefitType!.Contains(search));
                            break;
                        case "PaymentMethod":
                            query = query.Where(c => c.PaymentMethod!.Contains(search));
                            break;
                        case "PaymentReference":
                            query = query.Where(c => c.PaymentReference!.Contains(search));
                            break;
                        case "BenefitAmount":
                            query = query.Where(c => c.BenefitAmount.ToString()!.Contains(search));
                            break;
                        case "From":
                            query = query.Where(c => c.From!.Contains(search));
                            break;
                        case "To":
                            query = query.Where(c => c.To!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Paymentsummarymv>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Paymentsummarymv> GetPaymentsummarymv(string id)
        {
            Paymentsummarymv item = null!;
            try
            {
                var c = await _context.Paymentsummarymvs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Paymentsummarymv
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        BenefitNumber = c.BenefitNumber,
                        EFormId = c.EFormId,
                        BenefitPayment = c.BenefitPayment,
                        AcceptFrom = c.AcceptFrom,
                        From = c.From,
                        To = c.To,
                        BenefitAmount = c.BenefitAmount,
                        BenefitAmountInfo = c.BenefitAmountInfo,
                        StampDuty = c.StampDuty,
                        StampDutyInfo = c.StampDutyInfo,
                        PremiumRefund = c.PremiumRefund,
                        PremiumRefundInfo = c.PremiumRefundInfo,
                        SuperContributions = c.SuperContributions,
                        SuperContributionsInfo = c.SuperContributionsInfo,
                        NoClaimBonus = c.NoClaimBonus,
                        NoClaimBonusInfo = c.NoClaimBonusInfo,
                        Offsets = c.Offsets,
                        OffsetsInfo = c.OffsetsInfo,
                        Others = c.Others,
                        OthersInfo = c.OthersInfo,
                        Tax = c.Tax,
                        TaxInfo = c.TaxInfo,
                        CalculationDescription = c.CalculationDescription,
                        PaymentMethod = c.PaymentMethod,
                        PartialBenefit = c.PartialBenefit,
                        GroupPayee = c.GroupPayee,
                        CpiEbrClaimsEscalation = c.CpiEbrClaimsEscalation,
                        CpiEbrClaimsEscalDes = c.CpiEbrClaimsEscalDes,
                        NumberOfPayments = c.NumberOfPayments,
                        AdminInitials = c.AdminInitials,
                        AdminDate = c.AdminDate,
                        PaymentReference = c.PaymentReference,
                        AdminAuthorisedByInitials = c.AdminAuthorisedByInitials,
                        AdminAuthorisedDate = c.AdminAuthorisedDate,
                        PsoftRefForWaivPremiums = c.PsoftRefForWaivPremiums,
                        PsoftWvedPremiumAuthBy = c.PsoftWvedPremiumAuthBy,
                        PsoftPayAuthDate = c.PsoftPayAuthDate,
                        PeopleSoftScoReference = c.PeopleSoftScoReference,
                        PsoftPayAuthBy = c.PsoftPayAuthBy,
                        PsoftPayAuthDate1 = c.PsoftPayAuthDate1,
                        ServiceRequestScoReference = c.ServiceRequestScoReference,
                        OtherInformationEnd = c.OtherInformationEnd,
                        Total = c.Total,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        BenefitCode = c.BenefitCode,
                        ProductCode = c.ProductCode,
                        BenefitType = c.BenefitType,
                        DateCreated = c.DateCreated,
                    };
                }
                else
                {
                    item = new Paymentsummarymv();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Paymentsummarymv();
            }

            return item;
        }

        public async Task<PaginatedList<Taskmv>> SearchTaskmv(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Taskmv> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Taskmvs
                            orderby c.TaskCreatedDate descending
                            select new Taskmv
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CaseType = c.CaseType,
                                ClaimantName = c.ClaimantName,
                                CaseStatus = c.CaseStatus,
                                TaskName = c.TaskName,
                                TaskDescription = c.TaskDescription,
                                StaffInd = c.StaffInd,
                                TaskCreatedDate = c.TaskCreatedDate,
                                ApplicationId = c.ApplicationId,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimType":
                            query = query.Where(c => c.ClaimType!.Contains(search));
                            break;
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "CaseStatus":
                            query = query.Where(c => c.CaseStatus!.Contains(search));
                            break;
                        case "TaskName":
                            query = query.Where(c => c.TaskName!.Contains(search));
                            break;
                        case "TaskDescription":
                            query = query.Where(c => c.TaskDescription!.Contains(search));
                            break;
                        case "TaskCreatedDate":
                            query = query.Where(c => c.TaskCreatedDate!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Taskmv>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Taskmv> GetTaskmv(string id)
        {
            Taskmv item = null!;
            try
            {
                var c = await _context.Taskmvs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Taskmv
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CaseStatus = c.CaseStatus,
                        ClaimantName = c.ClaimantName,
                        CaseType = c.CaseType,
                        CaseManager = c.CaseManager,
                        ClaimTeam = c.ClaimTeam,
                        TaskProcessStep = c.TaskProcessStep,
                        TaskId = c.TaskId,
                        TaskCode = c.TaskCode,
                        TaskName = c.TaskName,
                        TaskDescription = c.TaskDescription,
                        TaskStatus = c.TaskStatus,
                        TaskAssignedToUser = c.TaskAssignedToUser,
                        TaskAssignedToDepartment = c.TaskAssignedToDepartment,
                        TaskAssignedToRole = c.TaskAssignedToRole,
                        TaskCreatedByUser = c.TaskCreatedByUser,
                        TaskCreatedDate = c.TaskCreatedDate,
                        TaskCompletedByUser = c.TaskCompletedByUser,
                        TaskCompletedDate = c.TaskCompletedDate,
                        BenchmarkDays = c.BenchmarkDays,
                        BenchmarkDate = c.BenchmarkDate,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        BenefitCode = c.BenefitCode,
                        BenefitDescription = c.BenefitDescription,
                        TaskCreatedByTeam = c.TaskCreatedByTeam,
                        TaskCompletedByTeam = c.TaskCompletedByTeam,
                        OriginalTaskTargetDate = c.OriginalTaskTargetDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        TaskInDepartment = c.TaskInDepartment,
                    };
                }
                else
                {
                    item = new Taskmv();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Taskmv();
            }

            return item;
        }

        public async Task<PaginatedList<RptAbleuser>> SearchRptAbleuser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<RptAbleuser> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptAbleusers
                            orderby c.ClaimUserId ascending
                            select new RptAbleuser
                            {
                                ClaimUserId = c.ClaimUserId,
                                LanId = c.LanId,
                                FullName = c.FullName,
                                JobTitle = c.JobTitle,
                                Mail = c.Mail,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "LanId":
                            query = query.Where(c => c.LanId!.Contains(search));
                            break;
                        case "FullName":
                            query = query.Where(c => c.FullName!.Contains(search));
                            break;
                        case "JobTitle":
                            query = query.Where(c => c.JobTitle!.Contains(search));
                            break;
                        case "Mail":
                            query = query.Where(c => c.Mail!.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<RptAbleuser>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptAbleuser> GetRptAbleuser(string id)
        {
            RptAbleuser item = null!;
            try
            {
                var c = await _context.RptAbleusers.FirstOrDefaultAsync(m => m.ClaimUserId == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptAbleuser
                    {
                        ClaimUserId = c.ClaimUserId,
                        LanId = c.LanId,
                        FullName = c.FullName,
                        JobTitle = c.JobTitle,
                        Mail = c.Mail,
                        Mobile = c.Mobile,
                        DepartmentNumber = c.DepartmentNumber,
                        ManagerLanId = c.ManagerLanId,
                        ManagerName = c.ManagerName,
                        ManagerMobile = c.ManagerMobile,
                        LastLogonDate = c.LastLogonDate,
                        DefaultDepartment = c.DefaultDepartment,
                    };
                }
                else
                {
                    item = new RptAbleuser();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptAbleuser();
            }

            return item;
        }

        public async Task<PaginatedList<RptAbleusersallrole>> SearchRptAbleusersallrole(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<RptAbleusersallrole> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptAbleusersallroles
                            orderby c.ClaimUserId ascending
                            select new RptAbleusersallrole
                            {
                                ClaimUserId = c.ClaimUserId,
                                LanId = c.LanId,
                                FullName = c.FullName,
                                JobTitle = c.JobTitle,
                                Role = c.Role,
                                Mail = c.Mail,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "LanId":
                            query = query.Where(c => c.LanId!.Contains(search));
                            break;
                        case "FullName":
                            query = query.Where(c => c.FullName!.Contains(search));
                            break;
                        case "JobTitle":
                            query = query.Where(c => c.JobTitle!.Contains(search));
                            break;
                        case "Role":
                            query = query.Where(c => c.Role!.Contains(search));
                            break;
                        case "Mail":
                            query = query.Where(c => c.Mail!.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<RptAbleusersallrole>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptAbleusersallrole> GetRptAbleusersallrole(string id)
        {
            RptAbleusersallrole item = null!;
            try
            {
                var c = await _context.RptAbleusersallroles.FirstOrDefaultAsync(m => m.ClaimUserId == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptAbleusersallrole
                    {
                        ClaimUserId = c.ClaimUserId,
                        LanId = c.LanId,
                        FullName = c.FullName,
                        JobTitle = c.JobTitle,
                        Mail = c.Mail,
                        Mobile = c.Mobile,
                        DepartmentNumber = c.DepartmentNumber,
                        ManagerLanId = c.ManagerLanId,
                        ManagerName = c.ManagerName,
                        ManagerMobile = c.ManagerMobile,
                        LastLogonDate = c.LastLogonDate,
                        Role = c.Role,
                        DefaultDepartment = c.DefaultDepartment,
                    };
                }
                else
                {
                    item = new RptAbleusersallrole();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptAbleusersallrole();
            }

            return item;
        }


        public async Task<PaginatedList<RptActionsservice>> SearchRptActionsservice(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptActionsservice> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptActionsservices
                            orderby c.Id ascending
                            select new RptActionsservice
                            {
                                Id = c.Id,
                                ClaimCase = c.ClaimCase,
                                ActionName = c.ActionName,
                                ActionStartDate = c.ActionStartDate,
                                CaseManager = c.CaseManager,
                                ActionOutcome = c.ActionOutcome,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimCase":
                            query = query.Where(c => c.ClaimCase!.Contains(search));
                            break;
                        case "ActionName":
                            query = query.Where(c => c.ActionName!.Contains(search));
                            break;
                        case "ActionStartDate":
                            query = query.Where(c => c.ActionStartDate!.Contains(search));
                            break;
                        case "ActionOutcome":
                            query = query.Where(c => c.ActionOutcome!.Contains(search));
                            break;
                        case "CaseManager":
                            query = query.Where(c => c.CaseManager!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptActionsservice>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptActionsservice> GetRptActionsservice(string id)
        {
            RptActionsservice item = null!;
            try
            {
                var c = await _context.RptActionsservices.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptActionsservice
                    {
                        Id = c.Id,
                        ClaimCase = c.ClaimCase,
                        ClaimCreationDate = c.ClaimCreationDate,
                        NotificationDate = c.NotificationDate,
                        IncurredDate = c.IncurredDate,
                        CaseManager = c.CaseManager,
                        TeamManager = c.TeamManager,
                        TriageSegment = c.TriageSegment,
                        DepartmentOfCase = c.DepartmentOfCase,
                        CmpCustomerGoal = c.CmpCustomerGoal,
                        CmpGoalDate = c.CmpGoalDate,
                        ActionName = c.ActionName,
                        ActionStartDate = c.ActionStartDate,
                        ActionOpenDuration = c.ActionOpenDuration,
                        ActionOutcome = c.ActionOutcome,
                        ActionOutcomeReason = c.ActionOutcomeReason,
                        ActionOutcomeComments = c.ActionOutcomeComments,
                        ActionOutcomeDate = c.ActionOutcomeDate,
                        ServiceCreatorActionOwner = c.ServiceCreatorActionOwner,
                        ServiceProvider = c.ServiceProvider,
                        ServiceCode = c.ServiceCode,
                        ServiceName = c.ServiceName,
                        UnitsOfferedNumberOfHours = c.UnitsOfferedNumberOfHours,
                        RatePerHour = c.RatePerHour,
                        TotalCosts = c.TotalCosts,
                        ServiceStartDate = c.ServiceStartDate,
                        ServiceEndDate = c.ServiceEndDate,
                        PrimaryDiagnosis = c.PrimaryDiagnosis,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        Occupation = c.Occupation,
                        DeathBenefitCase = c.DeathBenefitCase,
                        BexBenefitCase = c.BexBenefitCase,
                        IpBenefitCase = c.IpBenefitCase,
                        TpdBenefitCase = c.TpdBenefitCase,
                        TtdBenefitCase = c.TtdBenefitCase,
                        TraumaBenefitCase = c.TraumaBenefitCase,
                        StandAloneWopBenefitCase = c.StandAloneWopBenefitCase,
                    };
                }
                else
                {
                    item = new RptActionsservice();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptActionsservice();
            }

            return item;
        }

        public async Task<PaginatedList<RptCaseaction>> SearchRptCaseaction(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<RptCaseaction> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCaseactions
                            orderby c.ActionDate descending
                            select new RptCaseaction
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CaseType = c.CaseType,
                                Status = c.Status,
                                ActionedBy = c.ActionedBy,
                                ActionDate = c.ActionDate,
                                ClaimType = c.ClaimType,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CaseType":
                            query = query.Where(c => c.CaseType!.Contains(search));
                            break;
                        case "Status":
                            query = query.Where(c => c.Status!.Contains(search));
                            break;
                        case "ActionedBy":
                            query = query.Where(c => c.ActionedBy!.Contains(search));
                            break;
                        case "ActionDate":
                            query = query.Where(c => c.ActionDate!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<RptCaseaction>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCaseaction> GetRptCaseaction(string id)
        {
            RptCaseaction item = null!;
            try
            {
                var c = await _context.RptCaseactions.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCaseaction
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        BenefitNumber = c.BenefitNumber,
                        CaseType = c.CaseType,
                        Status = c.Status,
                        Reason = c.Reason,
                        ActionedBy = c.ActionedBy,
                        ActionDate = c.ActionDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptCaseaction();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCaseaction();
            }

            return item;
        }

        public async Task<RptCaseaction> GetRptCaseactionByClaimNo(string id)
        {
            RptCaseaction item = null!;
            try
            {
                var c = await _context.RptCaseactions.FirstOrDefaultAsync(m => m.ClaimNumber == id);
                if (c != null)
                {
                    item = new RptCaseaction
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        BenefitNumber = c.BenefitNumber,
                        CaseType = c.CaseType,
                        Status = c.Status,
                        Reason = c.Reason,
                        ActionedBy = c.ActionedBy,
                        ActionDate = c.ActionDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptCaseaction();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCaseaction();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimbenefitactuarialrec>> SearchRptClaimbenefitactuarialrec(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimbenefitactuarialrec> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimbenefitactuarialrecs
                            orderby c.Id ascending
                            select new RptClaimbenefitactuarialrec
                            {
                                Id = c.Id,
                                MonthEffectiveDate = c.MonthEffectiveDate,
                                SourceSystem = c.SourceSystem,
                                ProductName = c.ProductName,
                                ClaimNumber = c.ClaimNumber,
                                PolicyNumber = c.PolicyNumber,
                                IndicativeClaimType = c.IndicativeClaimType,
                                SourceBenefitDescription = c.SourceBenefitDescription,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ProductName":
                            query = query.Where(c => c.ProductName!.Contains(search));
                            break;
                        case "MonthEffectiveDate":
                            query = query.Where(c => c.MonthEffectiveDate!.Contains(search));
                            break;
                        case "SourceSystem":
                            query = query.Where(c => c.SourceSystem!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimbenefitactuarialrec>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimbenefitactuarialrec> GetRptClaimbenefitactuarialrec(string id)
        {
            RptClaimbenefitactuarialrec item = null!;
            try
            {
                var c = await _context.RptClaimbenefitactuarialrecs.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimbenefitactuarialrec
                    {
                        Id = c.Id,
                        MonthEffectiveDate = c.MonthEffectiveDate,
                        SourceSystem = c.SourceSystem,
                        ProductName = c.ProductName,
                        PolicyNumber = c.PolicyNumber,
                        GroupPlanNumber = c.GroupPlanNumber,
                        IndicativeClaimType = c.IndicativeClaimType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        CoverType = c.CoverType,
                        TargetBenefitCode = c.TargetBenefitCode,
                        ClaimStatus = c.ClaimStatus,
                        BenefitStatus = c.BenefitStatus,
                        ClaimNumber = c.ClaimNumber,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        OccupationCategory = c.OccupationCategory,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        TargetSumInsured = c.TargetSumInsured,
                        TargetSumInsuredFreq = c.TargetSumInsuredFreq,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        IndexationFrequency = c.IndexationFrequency,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        NumberOfReinsurers = c.NumberOfReinsurers,
                        TotalReinsurancePercent = c.TotalReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ContractEndDate = c.ContractEndDate,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        BenefitType = c.BenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        SourceBenefitType = c.SourceBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                    };
                }
                else
                {
                    item = new RptClaimbenefitactuarialrec();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimbenefitactuarialrec();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimBenefitactuarialrecl>> SearchRptClaimBenefitactuarialrecl(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimBenefitactuarialrecl> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimBenefitactuarialrecls
                            orderby c.Id ascending
                            select new RptClaimBenefitactuarialrecl
                            {
                                Id = c.Id,
                                MonthEffectiveDate = c.MonthEffectiveDate,
                                SourceSystem = c.SourceSystem,
                                ProductName = c.ProductName,
                                PolicyNumber = c.PolicyNumber,
                                IndicativeClaimType = c.IndicativeClaimType,
                                SourceBenefitDescription = c.SourceBenefitDescription,
                                ClaimNumber = c.ClaimNumber,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ProductName":
                            query = query.Where(c => c.ProductName!.Contains(search));
                            break;
                        case "MonthEffectiveDate":
                            query = query.Where(c => c.MonthEffectiveDate!.Contains(search));
                            break;
                        case "SourceSystem":
                            query = query.Where(c => c.SourceSystem!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimBenefitactuarialrecl>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimBenefitactuarialrecl> GetRptClaimBenefitactuarialrecl(string id)
        {
            RptClaimBenefitactuarialrecl item = null!;
            try
            {
                var c = await _context.RptClaimBenefitactuarialrecls.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimBenefitactuarialrecl
                    {
                        Id = c.Id,
                        MonthEffectiveDate = c.MonthEffectiveDate,
                        SourceSystem = c.SourceSystem,
                        ProductName = c.ProductName,
                        PolicyNumber = c.PolicyNumber,
                        GroupPlanNumber = c.GroupPlanNumber,
                        IndicativeClaimType = c.IndicativeClaimType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        CoverType = c.CoverType,
                        TargetBenefitCode = c.TargetBenefitCode,
                        ClaimStatus = c.ClaimStatus,
                        BenefitStatus = c.BenefitStatus,
                        ClaimNumber = c.ClaimNumber,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        OccupationCategory = c.OccupationCategory,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        InitialSumInsured = c.InitialSumInsured,
                        TargetSumInsured = c.TargetSumInsured,
                        TargetSumInsuredFreq = c.TargetSumInsuredFreq,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        IndexationFrequency = c.IndexationFrequency,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        NumberOfReinsurers = c.NumberOfReinsurers,
                        TotalReinsurancePercent = c.TotalReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ContractEndDate = c.ContractEndDate,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        BenefitType = c.BenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        SourceBenefitType = c.SourceBenefitType,
                        QualifyingPeriod = c.QualifyingPeriod,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        PaymentAuthorized = c.PaymentAuthorized,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                    };
                }
                else
                {
                    item = new RptClaimBenefitactuarialrecl();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimBenefitactuarialrecl();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimbenefitgroup>> SearchRptClaimbenefitgroup(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimbenefitgroup> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimbenefitgroups
                            orderby c.Id ascending
                            select new RptClaimbenefitgroup
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimStatus = c.ClaimStatus,
                                GivenName = c.GivenName,
                                Surname = c.Surname,
                                DateOfBirth = c.DateOfBirth,
                                DateOfDeath = c.DateOfDeath,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimStatus":
                            query = query.Where(c => c.ClaimStatus!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimbenefitgroup>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimbenefitgroup> GetRptClaimbenefitgroup(string id)
        {
            RptClaimbenefitgroup item = null!;
            try
            {
                var c = await _context.RptClaimbenefitgroups.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimbenefitgroup
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        ClaimStatus = c.ClaimStatus,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        PolicyNumber = c.PolicyNumber,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitCode = c.TargetBenefitCode,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        BenefitStatus = c.BenefitStatus,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        SumInsured = c.SumInsured,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        ReInsurerName = c.ReInsurerName,
                        ReinsuranceTreatyType = c.ReinsuranceTreatyType,
                        ReinsurancePercent = c.ReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        InitialSumInsuredX12 = c.InitialSumInsuredX12,
                        ContractEndDate = c.ContractEndDate,
                        SumReInsured = c.SumReInsured,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        SourceSystem = c.SourceSystem,
                        ClaimType = c.ClaimType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        PrimaryOccSelfEmployedInd = c.PrimaryOccSelfEmployedInd,
                        TpdDefinition = c.TpdDefinition,
                        TpdSubDefinition = c.TpdSubDefinition,
                        TraumaDefinition = c.TraumaDefinition,
                        SourceBenefitType = c.SourceBenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        Declined = c.Declined,
                        QualifyingPeriod = c.QualifyingPeriod,
                        ExpectedResolutionDate = c.ExpectedResolutionDate,
                        TargetBenefitType = c.TargetBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CoverageNumber = c.CoverageNumber,
                        AssessedUnderLimitedCover = c.AssessedUnderLimitedCover,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        UnexpectedCircumstancesApply = c.UnexpectedCircumstancesApply,
                    };
                }
                else
                {
                    item = new RptClaimbenefitgroup();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimbenefitgroup();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimbenefitreinsurance>> SearchRptClaimbenefitreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimbenefitreinsurance> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimbenefitreinsurances
                            orderby c.Id ascending
                            select new RptClaimbenefitreinsurance
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimStatus = c.ClaimStatus,
                                GivenName = c.GivenName,
                                Surname = c.Surname,
                                DateOfBirth = c.DateOfBirth,
                                StaffInd = c.StaffInd,
                                
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimStatus":
                            query = query.Where(c => c.ClaimStatus!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimbenefitreinsurance>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimbenefitreinsurance> GetRptClaimbenefitreinsurance(string id)
        {
            RptClaimbenefitreinsurance item = null!;
            try
            {
                var c = await _context.RptClaimbenefitreinsurances.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimbenefitreinsurance
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        ClaimStatus = c.ClaimStatus,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        PolicyNumber = c.PolicyNumber,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitCode = c.TargetBenefitCode,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        BenefitStatus = c.BenefitStatus,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        SumInsured = c.SumInsured,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        ReInsurerName = c.ReInsurerName,
                        ReinsuranceTreatyType = c.ReinsuranceTreatyType,
                        ReinsurancePercent = c.ReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        InitialSumInsuredX12 = c.InitialSumInsuredX12,
                        ContractEndDate = c.ContractEndDate,
                        SumReInsured = c.SumReInsured,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        SourceSystem = c.SourceSystem,
                        ClaimType = c.ClaimType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        PrimaryOccSelfEmployedInd = c.PrimaryOccSelfEmployedInd,
                        TpdDefinition = c.TpdDefinition,
                        TpdSubDefinition = c.TpdSubDefinition,
                        TraumaDefinition = c.TraumaDefinition,
                        SourceBenefitType = c.SourceBenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        Declined = c.Declined,
                        QualifyingPeriod = c.QualifyingPeriod,
                        ExpectedResolutionDate = c.ExpectedResolutionDate,
                        TargetBenefitType = c.TargetBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CoverageNumber = c.CoverageNumber,
                        AssessedUnderLimitedCover = c.AssessedUnderLimitedCover,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        UnexpectedCircumstancesApply = c.UnexpectedCircumstancesApply,
                    };
                }
                else
                {
                    item = new RptClaimbenefitreinsurance();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimbenefitreinsurance();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimbenefitw>> SearchRptClaimbenefitw(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimbenefitw> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimbenefitws
                            orderby c.Id ascending
                            select new RptClaimbenefitw
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimStatus = c.ClaimStatus,
                                GivenName = c.GivenName,
                                Surname = c.Surname,
                                DateOfBirth = c.DateOfBirth,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimStatus":
                            query = query.Where(c => c.ClaimStatus!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimbenefitw>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }


            return list;
        }

        public async Task<RptClaimbenefitw> GetRptClaimbenefitw(string id)
        {
            RptClaimbenefitw item = null!;
            try
            {
                var c = await _context.RptClaimbenefitws.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimbenefitw
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        ClaimStatus = c.ClaimStatus,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Occupation = c.Occupation,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        PreDisabilityIncome = c.PreDisabilityIncome,
                        State = c.State,
                        PostCode = c.PostCode,
                        CaseType = c.CaseType,
                        CurrentClaimOwner = c.CurrentClaimOwner,
                        ClaimTeam = c.ClaimTeam,
                        RegistrationDate = c.RegistrationDate,
                        FirstContactDate = c.FirstContactDate,
                        IncurredDate = c.IncurredDate,
                        AgeAtIncurredDate = c.AgeAtIncurredDate,
                        ClaimEventType = c.ClaimEventType,
                        PrimaryCauseCode = c.PrimaryCauseCode,
                        PrimaryCauseDescription = c.PrimaryCauseDescription,
                        PrimaryCauseDate = c.PrimaryCauseDate,
                        SecondaryCauseCode = c.SecondaryCauseCode,
                        SecondaryCauseDescription = c.SecondaryCauseDescription,
                        SecondaryCauseDate = c.SecondaryCauseDate,
                        ExpectedReturnToWorkDate = c.ExpectedReturnToWorkDate,
                        CeasedWorkDate = c.CeasedWorkDate,
                        ClaimFinalisedDate = c.ClaimFinalisedDate,
                        ClaimFinalisedReason = c.ClaimFinalisedReason,
                        ClaimReopenDate = c.ClaimReopenDate,
                        ClaimReopenReason = c.ClaimReopenReason,
                        PolicyNumber = c.PolicyNumber,
                        ContractStartDate = c.ContractStartDate,
                        ContractStatus = c.ContractStatus,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        TargetBenefitCode = c.TargetBenefitCode,
                        TargetBenefitDescription = c.TargetBenefitDescription,
                        BenefitStatus = c.BenefitStatus,
                        RiskCommencedDate = c.RiskCommencedDate,
                        RiskExpiryDate = c.RiskExpiryDate,
                        WaitingPeriodAccident = c.WaitingPeriodAccident,
                        WaitingPeriodSickness = c.WaitingPeriodSickness,
                        BenefitPeriodAccident = c.BenefitPeriodAccident,
                        BenefitPeriodSickness = c.BenefitPeriodSickness,
                        SumInsured = c.SumInsured,
                        CalculationStartType = c.CalculationStartType,
                        CalculationEndType = c.CalculationEndType,
                        Decision = c.Decision,
                        Accepted = c.Accepted,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                        FinalisedDate = c.FinalisedDate,
                        FinalisedReason = c.FinalisedReason,
                        BenefitReopenDate = c.BenefitReopenDate,
                        BenefitReopenReason = c.BenefitReopenReason,
                        SuperContributionPercent = c.SuperContributionPercent,
                        IndexationFlag = c.IndexationFlag,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        ReInsurerName = c.ReInsurerName,
                        ReinsuranceTreatyType = c.ReinsuranceTreatyType,
                        ReinsurancePercent = c.ReinsurancePercent,
                        AdviserSalesId = c.AdviserSalesId,
                        GroupPlanName = c.GroupPlanName,
                        GroupPlanNumber = c.GroupPlanNumber,
                        RiskCategory = c.RiskCategory,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                        PrimaryOccupationStartDate = c.PrimaryOccupationStartDate,
                        PrimaryOccupationEndDate = c.PrimaryOccupationEndDate,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        ExternalMemberNumber = c.ExternalMemberNumber,
                        BenefitCreationDate = c.BenefitCreationDate,
                        ClassOfBusiness = c.ClassOfBusiness,
                        InitialSumInsuredX12 = c.InitialSumInsuredX12,
                        ContractEndDate = c.ContractEndDate,
                        SumReInsured = c.SumReInsured,
                        PartialEarningsIncome = c.PartialEarningsIncome,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        MaximumIndexationRate = c.MaximumIndexationRate,
                        Source = c.Source,
                        IncidentOccurredOverseas = c.IncidentOccurredOverseas,
                        CountryOfIncident = c.CountryOfIncident,
                        SourceSystem = c.SourceSystem,
                        ClaimType = c.ClaimType,
                        SourceBenefitCode = c.SourceBenefitCode,
                        SourceBenefitDescription = c.SourceBenefitDescription,
                        InitialSumInsured = c.InitialSumInsured,
                        InitialSumInsuredFreq = c.InitialSumInsuredFreq,
                        PrimaryOccSelfEmployedInd = c.PrimaryOccSelfEmployedInd,
                        TpdDefinition = c.TpdDefinition,
                        TpdSubDefinition = c.TpdSubDefinition,
                        TraumaDefinition = c.TraumaDefinition,
                        SourceBenefitType = c.SourceBenefitType,
                        ProductCode = c.ProductCode,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        PartyId = c.PartyId,
                        Declined = c.Declined,
                        QualifyingPeriod = c.QualifyingPeriod,
                        ExpectedResolutionDate = c.ExpectedResolutionDate,
                        TargetBenefitType = c.TargetBenefitType,
                        SourceBenefitSelected = c.SourceBenefitSelected,
                        ConcurrentClaimIndicator = c.ConcurrentClaimIndicator,
                        ConcurrentClaimNumbers = c.ConcurrentClaimNumbers,
                        WorkStatusType = c.WorkStatusType,
                        StartDate = c.StartDate,
                        PartialCapacity = c.PartialCapacity,
                        EndDate = c.EndDate,
                        DateReturnedToWork = c.DateReturnedToWork,
                        ExpectedRtwFtRange = c.ExpectedRtwFtRange,
                        AdmitAdvancePayAndFinalise = c.AdmitAdvancePayAndFinalise,
                        NonDisclosure = c.NonDisclosure,
                        CmpRequired = c.CmpRequired,
                        UrgentFinancialNeedsFlag = c.UrgentFinancialNeedsFlag,
                        SpecialArrangementFlag = c.SpecialArrangementFlag,
                        SpecialArrangementDuration = c.SpecialArrangementDuration,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CoverageNumber = c.CoverageNumber,
                        AssessedUnderLimitedCover = c.AssessedUnderLimitedCover,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        UnexpectedCircumstancesApply = c.UnexpectedCircumstancesApply,
                        IarCode = c.IarCode,
                        IarDescription = c.IarDescription,
                    };
                }
                else
                {
                    item = new RptClaimbenefitw();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimbenefitw();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimcasedecipha>> SearchRptClaimcasedecipha(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimcasedecipha> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimcasedeciphas
                            orderby c.Id ascending
                            select new RptClaimcasedecipha
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                PolicyNumber = c.PolicyNumber,
                                CustomerFirstName = c.CustomerFirstName,
                                CustomerLastName = c.CustomerLastName,
                                State = c.State,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {

                        case "CustomerFirstName":
                            query = query.Where(c => c.CustomerFirstName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "CustomerLastName":
                            query = query.Where(c => c.CustomerLastName!.Contains(search));
                            break;
                        case "State":
                            query = query.Where(c => c.State!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimcasedecipha>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimcasedecipha> GetRptClaimcasedecipha(string id)
        {
            RptClaimcasedecipha item = null!;
            try
            {
                var c = await _context.RptClaimcasedeciphas.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimcasedecipha
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        PolicyNumber = c.PolicyNumber,
                        CustomerFirstName = c.CustomerFirstName,
                        CustomerLastName = c.CustomerLastName,
                        State = c.State,
                        PostCode = c.PostCode,
                        ClaimsTeamDepartment = c.ClaimsTeamDepartment,
                    };
                }
                else
                {
                    item = new RptClaimcasedecipha();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimcasedecipha();
            }

            return item;
        }


        public async Task<PaginatedList<RptClaimexpense>> SearchRptClaimexpense(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimexpense> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimexpenses
                            orderby c.Id ascending
                            select new RptClaimexpense
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                Payee = c.Payee,
                                PolicyNumber = c.PolicyNumber,
                                InvoiceNumber = c.InvoiceNumber,
                                AmountIncGst = c.AmountIncGst,
                                StaffInd = c.StaffInd
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Payee":
                            query = query.Where(c => c.Payee!.Contains(search));
                            break;
                        case "InvoiceNumber":
                            query = query.Where(c => c.InvoiceNumber!.Contains(search));
                            break;
                        case "AmountIncGst":
                            query = query.Where(c => c.AmountIncGst.ToString()!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClaimexpense>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimexpense> GetRptClaimexpense(string id)
        {
            RptClaimexpense item = null!;
            try
            {
                var c = await _context.RptClaimexpenses.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimexpense
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        Payee = c.Payee,
                        PolicyNumber = c.PolicyNumber,
                        InvoiceType = c.InvoiceType,
                        InvoiceNumber = c.InvoiceNumber,
                        AmountIncGst = c.AmountIncGst,
                        Gst = c.Gst,
                        PaymentMethod = c.PaymentMethod,
                        VendorId = c.VendorId,
                        AdminInitials = c.AdminInitials,
                        PaymentCreationDate = c.PaymentCreationDate,
                        PaymentReference = c.PaymentReference,
                        AuthorisedBy = c.AuthorisedBy,
                        AuthorisationDate = c.AuthorisationDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        BenefitCode = c.BenefitCode,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                        ClaimExpenseGuid = c.ClaimExpenseGuid,
                    };
                }
                else
                {
                    item = new RptClaimexpense();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimexpense();
            }

            return item;
        }

        public async Task<PaginatedList<RptClaimparticipant>> SearchRptClaimparticipant(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClaimparticipant> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClaimparticipants
                            orderby c.Id ascending
                            select new RptClaimparticipant
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                Email = c.Email,
                                Name = c.Name,
                                Hva = c.Hva,
                                Address = c.Address,
                                Suburb = c.Suburb,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Name":
                            query = query.Where(c => c.Name!.Contains(search));
                            break;
                        case "Email":
                            query = query.Where(c => c.Email!.Contains(search));
                            break;
                        case "Hva":
                            query = query.Where(c => c.Hva!.Contains(search));
                            break;
                        case "Address":
                            query = query.Where(c => c.Address!.Contains(search));
                            break;
                        case "Suburb":
                            query = query.Where(c => c.Suburb!.Contains(search));
                            break;
                    }
                }

                //if (claimflag == 0)
                //{
                //    query = query.Where(c => c.StaffInd == 0);
                //}

                list = await PaginatedList<RptClaimparticipant>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClaimparticipant> GetRptClaimparticipant(string id)
        {
            RptClaimparticipant item = null!;
            try
            {
                var c = await _context.RptClaimparticipants.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClaimparticipant
                    {
                        Id = c.Id,
                        FaxExtension = c.FaxExtension,
                        Email = c.Email,
                        TypeOfParticipant = c.TypeOfParticipant,
                        PersonOrganisation = c.PersonOrganisation,
                        Name = c.Name,
                        Hva = c.Hva,
                        AddressType = c.AddressType,
                        Address = c.Address,
                        Suburb = c.Suburb,
                        State = c.State,
                        PostCode = c.PostCode,
                        ClaimNumber = c.ClaimNumber,
                        ParticipantEffectiveDate = c.ParticipantEffectiveDate,
                        ClaimStatus = c.ClaimStatus,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ResidentialInternationalCode = c.ResidentialInternationalCode,
                        ResidentialAreaCode = c.ResidentialAreaCode,
                        ResidentialPhone = c.ResidentialPhone,
                        ResidentialExtension = c.ResidentialExtension,
                        BusinessInternationalCode = c.BusinessInternationalCode,
                        BusinessAreaCode = c.BusinessAreaCode,
                        BusinessPhone = c.BusinessPhone,
                        BusinessExtension = c.BusinessExtension,
                        MobileInternationalCode = c.MobileInternationalCode,
                        MobileAreaCode = c.MobileAreaCode,
                        MobilePhone = c.MobilePhone,
                        MobileExtension = c.MobileExtension,
                        FaxInternationalCode = c.FaxInternationalCode,
                        FaxAreaCode = c.FaxAreaCode,
                        FaxPhone = c.FaxPhone,
                    };
                }
                else
                {
                    item = new RptClaimparticipant();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClaimparticipant();
            }

            return item;
        }

        public async Task<PaginatedList<RptClosedtaskreport>> SearchRptClosedtaskreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptClosedtaskreport> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptClosedtaskreports
                            orderby c.Id ascending
                            select new RptClosedtaskreport
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimantName = c.ClaimantName,
                                CaseStatus = c.CaseStatus,
                                TaskName = c.TaskName,
                                TaskStatus = c.TaskDescription,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CaseStatus":
                            query = query.Where(c => c.CaseStatus!.Contains(search));
                            break;
                        case "TaskName":
                            query = query.Where(c => c.TaskName!.Contains(search));
                            break;
                        case "TaskDescription":
                            query = query.Where(c => c.TaskDescription!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptClosedtaskreport>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptClosedtaskreport> GetRptClosedtaskreport(string id)
        {
            RptClosedtaskreport item = null!;
            try
            {
                var c = await _context.RptClosedtaskreports.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptClosedtaskreport
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CaseStatus = c.CaseStatus,
                        ClaimantName = c.ClaimantName,
                        CaseType = c.CaseType,
                        CaseManager = c.CaseManager,
                        ClaimTeam = c.ClaimTeam,
                        TaskProcessStep = c.TaskProcessStep,
                        TaskId = c.TaskId,
                        TaskCode = c.TaskCode,
                        TaskName = c.TaskName,
                        TaskDescription = c.TaskDescription,
                        TaskStatus = c.TaskStatus,
                        TaskAssignedToUser = c.TaskAssignedToUser,
                        TaskAssignedToRole = c.TaskAssignedToRole,
                        TaskCreatedByUser = c.TaskCreatedByUser,
                        TaskCreatedDate = c.TaskCreatedDate,
                        TaskCompletedByUser = c.TaskCompletedByUser,
                        TaskCompletedDate = c.TaskCompletedDate,
                        BenchmarkDays = c.BenchmarkDays,
                        BenchmarkDate = c.BenchmarkDate,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        BenefitCode = c.BenefitCode,
                        BenefitDescription = c.BenefitDescription,
                        TaskCreatedByTeam = c.TaskCreatedByTeam,
                        TaskCompletedByTeam = c.TaskCompletedByTeam,
                        OriginalTaskTargetDate = c.OriginalTaskTargetDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                        TaskTeamQueue = c.TaskTeamQueue,
                    };
                }
                else
                {
                    item = new RptClosedtaskreport();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptClosedtaskreport();
            }

            return item;
        }

        public async Task<PaginatedList<RptCmpaction>> SearchRptCmpaction(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptCmpaction> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCmpactions
                            orderby c.Id ascending
                            select new RptCmpaction
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CmpStatus = c.CmpStatus,
                                GoalName = c.GoalName,
                                GoalDescription = c.GoalDescription,
                                GoalOutcome = c.GoalOutcome,
                                StaffInd = c.StaffInd,
                                
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CmpStatus":
                            query = query.Where(c => c.CmpStatus!.Contains(search));
                            break;
                        case "GoalName":
                            query = query.Where(c => c.GoalName!.Contains(search));
                            break;
                        case "GoalDescription":
                            query = query.Where(c => c.GoalDescription!.Contains(search));
                            break;
                        case "GoalOutcome":
                            query = query.Where(c => c.GoalOutcome!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptCmpaction>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCmpaction> GetRptCmpaction(string id)
        {
            RptCmpaction item = null!;
            try
            {
                var c = await _context.RptCmpactions.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCmpaction
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CmpStatus = c.CmpStatus,
                        GoalName = c.GoalName,
                        GoalOutcome = c.GoalOutcome,
                        GoalDescription = c.GoalDescription,
                        GoalCreationDate = c.GoalCreationDate,
                        GoalOutcomeDate = c.GoalOutcomeDate,
                        CmpGoalDate = c.CmpGoalDate,
                        PlanName = c.PlanName,
                        PlanNotes = c.PlanNotes,
                        PlanStatus = c.PlanStatus,
                        PlanCreationDate = c.PlanCreationDate,
                        FactorName = c.FactorName,
                        FactorDescription = c.FactorDescription,
                        Factors = c.Factors,
                        FactorStatus = c.FactorStatus,
                        StrategyName = c.StrategyName,
                        StrategyOutcome = c.StrategyOutcome,
                        StrategyTargetDate = c.StrategyTargetDate,
                        StrategyCreationDate = c.StrategyCreationDate,
                        StrategyOutcomeDate = c.StrategyOutcomeDate,
                        ActionName = c.ActionName,
                        ActionLastUpdated = c.ActionLastUpdated,
                        ActionStartDate = c.ActionStartDate,
                        ActionOwner = c.ActionOwner,
                        ActionOwnerTeam = c.ActionOwnerTeam,
                        ActionOutcome = c.ActionOutcome,
                        ActionOutcomeDate = c.ActionOutcomeDate,
                        ActionOutcomeReason = c.ActionOutcomeReason,
                        ActionOwnerType = c.ActionOwnerType,
                        ServiceCode = c.ServiceCode,
                        ServiceDescription = c.ServiceDescription,
                        ServiceCreator = c.ServiceCreator,
                        ServiceStartDate = c.ServiceStartDate,
                        ServiceEndDate = c.ServiceEndDate,
                        ServiceNotes = c.ServiceNotes,
                        CommenceDate = c.CommenceDate,
                        ServicePractitioner = c.ServicePractitioner,
                        DocumentUploadDate = c.DocumentUploadDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        GoalReason = c.GoalReason,
                    };
                }
                else
                {
                    item = new RptCmpaction();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCmpaction();
            }

            return item;
        }

        public async Task<PaginatedList<RptCmpgoaldatemovement>> SearchRptCmpgoaldatemovement(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptCmpgoaldatemovement> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCmpgoaldatemovements
                            orderby c.Id ascending
                            select new RptCmpgoaldatemovement
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CmpStatus = c.CmpStatus,
                                PlanName = c.PlanName,
                                CmpGoalDate = c.CmpGoalDate,
                                CmpGoalUpdatedDate = c.CmpGoalUpdatedDate,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "PlanName":
                            query = query.Where(c => c.PlanName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CmpStatus":
                            query = query.Where(c => c.CmpStatus!.Contains(search));
                            break;
                        case "CmpGoalDate":
                            query = query.Where(c => c.CmpGoalDate!.Contains(search));
                            break;
                        case "CmpGoalUpdatedDate":
                            query = query.Where(c => c.CmpGoalUpdatedDate!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptCmpgoaldatemovement>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCmpgoaldatemovement> GetRptCmpgoaldatemovement(string id)
        {
            RptCmpgoaldatemovement item = null!;
            try
            {
                var c = await _context.RptCmpgoaldatemovements.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCmpgoaldatemovement
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CmpStatus = c.CmpStatus,
                        PlanName = c.PlanName,
                        PlanCreationDate = c.PlanCreationDate,
                        CmpGoalDate = c.CmpGoalDate,
                        CmpGoalCreationDate = c.CmpGoalCreationDate,
                        CmpGoalUpdatedDate = c.CmpGoalUpdatedDate,
                        CmpGoalUpdatedByUserName = c.CmpGoalUpdatedByUserName,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptCmpgoaldatemovement();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCmpgoaldatemovement();
            }

            return item;
        }

        public async Task<PaginatedList<RptCmpplanstatus>> SearchRptCmpplanstatus(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptCmpplanstatus> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCmpplanstatuses
                            orderby c.Id ascending
                            select new RptCmpplanstatus
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CmpStatus = c.CmpStatus,
                                CmpGoalDate = c.CmpGoalDate,
                                PlanName = c.PlanName,
                                PlanStatus = c.PlanStatus,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "CmpGoalDate":
                            query = query.Where(c => c.CmpGoalDate!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CmpStatus":
                            query = query.Where(c => c.CmpStatus!.Contains(search));
                            break;
                        case "PlanName":
                            query = query.Where(c => c.PlanName!.Contains(search));
                            break;
                        case "PlanStatus":
                            query = query.Where(c => c.PlanStatus!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptCmpplanstatus>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCmpplanstatus> GetRptCmpplanstatus(string id)
        {
            RptCmpplanstatus item = null!;
            try
            {
                var c = await _context.RptCmpplanstatuses.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCmpplanstatus
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CmpStatus = c.CmpStatus,
                        CmpGoalDate = c.CmpGoalDate,
                        PlanName = c.PlanName,
                        PlanNotes = c.PlanNotes,
                        PlanStatus = c.PlanStatus,
                        PlanCreationDate = c.PlanCreationDate,
                        ServiceCode = c.ServiceCode,
                        ServiceDescription = c.ServiceDescription,
                        ServiceCreator = c.ServiceCreator,
                        ServiceStartDate = c.ServiceStartDate,
                        ServiceEndDate = c.ServiceEndDate,
                        PlanStatusDate = c.PlanStatusDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptCmpplanstatus();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCmpplanstatus();
            }

            return item;
        }

        public async Task<PaginatedList<RptCmpservice>> SearchRptCmpservice(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<RptCmpservice> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCmpservices
                            orderby c.Id ascending
                            select new RptCmpservice
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CmpStatus = c.CmpStatus,
                                GoalName = c.GoalName,
                                CmpGoalDate = c.CmpGoalDate,
                                GoalOutcome = c.GoalOutcome,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "GoalName":
                            query = query.Where(c => c.GoalName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CmpStatus":
                            query = query.Where(c => c.CmpStatus!.Contains(search));
                            break;
                        case "CmpGoalDate":
                            query = query.Where(c => c.CmpGoalDate!.Contains(search));
                            break;
                        case "GoalOutcome":
                            query = query.Where(c => c.GoalOutcome!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptCmpservice>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCmpservice> GetRptCmpservice(string id)
        {
            RptCmpservice item = null!;
            try
            {
                var c = await _context.RptCmpservices.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCmpservice
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CmpStatus = c.CmpStatus,
                        GoalName = c.GoalName,
                        GoalOutcome = c.GoalOutcome,
                        GoalDescription = c.GoalDescription,
                        GoalCreationDate = c.GoalCreationDate,
                        GoalOutcomeDate = c.GoalOutcomeDate,
                        CmpGoalDate = c.CmpGoalDate,
                        PlanName = c.PlanName,
                        PlanNotes = c.PlanNotes,
                        PlanStatus = c.PlanStatus,
                        PlanCreationDate = c.PlanCreationDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        GoalReason = c.GoalReason,
                    };
                }
                else
                {
                    item = new RptCmpservice();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCmpservice();
            }

            return item;
        }

        public async Task<PaginatedList<RptCompliant>> SearchRptCompliant(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptCompliant> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptCompliants
                            orderby c.Id ascending
                            select new RptCompliant
                            {
                                Id = c.Id,
                                ClaimNo = c.ClaimNo,
                                LastName = c.LastName,
                                FirstName = c.FirstName,
                                DateOfBirth = c.DateOfBirth,
                                PolicyNo1 = c.PolicyNo1,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "FirstName":
                            query = query.Where(c => c.FirstName!.Contains(search));
                            break;
                        case "ClaimNo":
                            query = query.Where(c => c.ClaimNo!.Contains(search));
                            break;
                        case "LastName":
                            query = query.Where(c => c.LastName!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;
                        case "PolicyNo1":
                            query = query.Where(c => c.PolicyNo1!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }


                list = await PaginatedList<RptCompliant>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptCompliant> GetRptCompliant(string id)
        {
            RptCompliant item = null!;
            try
            {
                var c = await _context.RptCompliants.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptCompliant
                    {
                        Id = c.Id,
                        ClaimNo = c.ClaimNo,
                        LastName = c.LastName,
                        FirstName = c.FirstName,
                        Gender = c.Gender,
                        DateOfBirth = c.DateOfBirth,
                        PolicyNo1 = c.PolicyNo1,
                        GroupRetail1 = c.GroupRetail1,
                        BenefitType1 = c.BenefitType1,
                        BenefitStatus1 = c.BenefitStatus1,
                        PolicyNo2 = c.PolicyNo2,
                        GroupRetail2 = c.GroupRetail2,
                        BenefitType2 = c.BenefitType2,
                        BenefitStatus2 = c.BenefitStatus2,
                        PolicyNo3 = c.PolicyNo3,
                        GroupRetail3 = c.GroupRetail3,
                        BenefitType3 = c.BenefitType3,
                        BenefitStatus3 = c.BenefitStatus3,
                        PolicyNo4 = c.PolicyNo4,
                        GroupRetail4 = c.GroupRetail4,
                        BenefitType4 = c.BenefitType4,
                        BenefitStatus4 = c.BenefitStatus4,
                        ClaimStatus = c.ClaimStatus,
                        ComplaintIdNo = c.ComplaintIdNo,
                        ComplaintNotificationDate = c.ComplaintNotificationDate,
                        RaisedBy = c.RaisedBy,
                        ComplaintTheme1 = c.ComplaintTheme1,
                        ComplaintTheme2 = c.ComplaintTheme2,
                        ComplaintTheme3 = c.ComplaintTheme3,
                        ComplaintTheme4 = c.ComplaintTheme4,
                        ComplaintTheme5 = c.ComplaintTheme5,
                        ComplaintType = c.ComplaintType,
                        Method1 = c.Method1,
                        ComplaintSource1 = c.ComplaintSource1,
                        Method2 = c.Method2,
                        ComplaintSource2 = c.ComplaintSource2,
                        Method3 = c.Method3,
                        ComplaintSource3 = c.ComplaintSource3,
                        ComplaintStatus = c.ComplaintStatus,
                        ComplaintOwner = c.ComplaintOwner,
                        EscalationDate = c.EscalationDate,
                        NoOfDaysComplaintOpen = c.NoOfDaysComplaintOpen,
                        ClosureDate = c.ClosureDate,
                        ClosureReason = c.ClosureReason,
                        AcknowLetterSlaMetYN = c.AcknowLetterSlaMetYN,
                        DaysToSendAcknowLetter = c.DaysToSendAcknowLetter,
                        LetterToTrusteeSlaMetYN = c.LetterToTrusteeSlaMetYN,
                        DaysToSendTrusteeLetter = c.DaysToSendTrusteeLetter,
                        NonSuperLetterSlaMetYN = c.NonSuperLetterSlaMetYN,
                        DaysToSendNonSuperLetter = c.DaysToSendNonSuperLetter,
                        SuperLetterSlaMetYN = c.SuperLetterSlaMetYN,
                        DaysToSendSuperLetter = c.DaysToSendSuperLetter,
                        TmOfComplaintRecordOwner = c.TmOfComplaintRecordOwner,
                        TmOfClaimCaseOwner = c.TmOfClaimCaseOwner,
                        ComplaintRecordTeamName = c.ComplaintRecordTeamName,
                        EscalationApprovedByTm = c.EscalationApprovedByTm,
                        EscalationDeclinedByTm = c.EscalationDeclinedByTm,
                        EscalationToTm = c.EscalationToTm,
                        CatEscalationApproved = c.CatEscalationApproved,
                        CatEscalationDeclined = c.CatEscalationDeclined,
                        EscalationToCat = c.EscalationToCat,
                        ClassOfBusiness = c.ClassOfBusiness,
                    };
                }
                else
                {
                    item = new RptCompliant();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptCompliant();
            }

            return item;
        }

        public async Task<PaginatedList<RptDocumentreport>> SearchRptDocumentreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<RptDocumentreport> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptDocumentreports
                            orderby c.DateCreatedInAble descending
                            select new RptDocumentreport
                            {
                                Id = c.Id,
                                CaseNumber = c.CaseNumber,
                                BenefitNumber = c.BenefitNumber,
                                CaseType = c.CaseType,
                                DocumentType = c.DocumentType,
                                Description = c.Description,
                                Status = c.Status,
                                DateCreatedInAble = c.DateCreatedInAble,
                                CreatedBy = c.CreatedBy,
                                LastUpdatedBy = c.LastUpdatedBy,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "CaseType":
                            query = query.Where(c => c.CaseType!.Contains(search));
                            break;
                        case "CaseNumber":
                            query = query.Where(c => c.CaseNumber!.Contains(search));
                            break;
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "DateCreatedInAble":
                            query = query.Where(c => c.DateCreatedInAble!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<RptDocumentreport>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptDocumentreport> GetRptDocumentreport(string id)
        {
            RptDocumentreport item = null!;
            try
            {
                var c = await _context.RptDocumentreports.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptDocumentreport
                    {
                        Id = c.Id,
                        CaseNumber = c.CaseNumber,
                        BenefitNumber = c.BenefitNumber,
                        CaseType = c.CaseType,
                        DocumentType = c.DocumentType,
                        DocumentId = c.DocumentId,
                        DateCreatedInAble = c.DateCreatedInAble,
                        CreatedBy = c.CreatedBy,
                        LastUpdatedBy = c.LastUpdatedBy,
                        Status = c.Status,
                        Description = c.Description,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptDocumentreport();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptDocumentreport();
            }

            return item;
        }

        public async Task<PaginatedList<RptEnquirycasereport>> SearchRptEnquirycasereport(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<RptEnquirycasereport> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptEnquirycasereports
                            orderby c.Id ascending
                            select new RptEnquirycasereport
                            {
                                Id = c.Id,
                                EnquiryNumber = c.EnquiryNumber,
                                EnquiryCaseStatus = c.EnquiryCaseStatus,
                                GivenName = c.GivenName,
                                Surname = c.Surname,
                                DateOfBirth = c.DateOfBirth,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "GivenName":
                            query = query.Where(c => c.GivenName!.Contains(search));
                            break;
                        case "EnquiryNumber":
                            query = query.Where(c => c.EnquiryNumber!.Contains(search));
                            break;
                        case "EnquiryCaseStatus":
                            query = query.Where(c => c.EnquiryCaseStatus!.Contains(search));
                            break;
                        case "Surname":
                            query = query.Where(c => c.Surname!.Contains(search));
                            break;
                        case "DateOfBirth":
                            query = query.Where(c => c.DateOfBirth!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<RptEnquirycasereport>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptEnquirycasereport> GetRptEnquirycasereport(string id)
        {
            RptEnquirycasereport item = null!;
            try
            {
                var c = await _context.RptEnquirycasereports.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptEnquirycasereport
                    {
                        Id = c.Id,
                        EnquiryNumber = c.EnquiryNumber,
                        EnquiryCaseStatus = c.EnquiryCaseStatus,
                        GivenName = c.GivenName,
                        Surname = c.Surname,
                        Sex = c.Sex,
                        DateOfBirth = c.DateOfBirth,
                        PostCode = c.PostCode,
                        CaseManager = c.CaseManager,
                        Team = c.Team,
                        CreationDate = c.CreationDate,
                        IncurredDate = c.IncurredDate,
                        Source = c.Source,
                        ContactDate = c.ContactDate,
                        Notifier = c.Notifier,
                        IfOther = c.IfOther,
                        NatureOfIllnessOrInjury = c.NatureOfIllnessOrInjury,
                        NatureOfIncident = c.NatureOfIncident,
                        Description = c.Description,
                        Product = c.Product,
                        ContractStatus = c.ContractStatus,
                        PolicyNumber = c.PolicyNumber,
                        CommencementDate = c.CommencementDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptEnquirycasereport();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptEnquirycasereport();
            }

            return item;
        }

        public async Task<PaginatedList<RptHcrcompletednote>> SearchRptHcrcompletednote(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptHcrcompletednote> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptHcrcompletednotes
                            orderby c.Id ascending
                            select new RptHcrcompletednote
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimType = c.ClaimType,
                                NoteType = c.NoteType,
                                DateCreated = c.DateCreated,
                                Status = c.Status,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "NoteType":
                            query = query.Where(c => c.NoteType!.Contains(search));
                            break;
                        case "ClaimType":
                            query = query.Where(c => c.ClaimType!.Contains(search));
                            break;
                        case "Status":
                            query = query.Where(c => c.Status!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptHcrcompletednote>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptHcrcompletednote> GetRptHcrcompletednote(string id)
        {
            RptHcrcompletednote item = null!;
            try
            {
                var c = await _context.RptHcrcompletednotes.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptHcrcompletednote
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        NoteType = c.NoteType,
                        DateCreated = c.DateCreated,
                        Status = c.Status,
                        DateOfStatusChange = c.DateOfStatusChange,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptHcrcompletednote();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptHcrcompletednote();
            }

            return item;
        }

        public async Task<PaginatedList<RptOpentask>> SearchRptOpentask(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptOpentask> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptOpentasks
                            orderby c.Id ascending
                            select new RptOpentask
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CaseStatus = c.CaseStatus,
                                ClaimantName = c.ClaimantName,
                                TaskName = c.TaskName,
                                TaskDescription = c.TaskDescription,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CaseStatus":
                            query = query.Where(c => c.CaseStatus!.Contains(search));
                            break;
                        case "TaskName":
                            query = query.Where(c => c.TaskName!.Contains(search));
                            break;
                        case "TaskDescription":
                            query = query.Where(c => c.TaskDescription!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptOpentask>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptOpentask> GetRptOpentask(string id)
        {
            RptOpentask item = null!;
            try
            {
                var c = await _context.RptOpentasks.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptOpentask
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CaseStatus = c.CaseStatus,
                        ClaimantName = c.ClaimantName,
                        CaseType = c.CaseType,
                        CaseManager = c.CaseManager,
                        ClaimTeam = c.ClaimTeam,
                        TaskProcessStep = c.TaskProcessStep,
                        TaskId = c.TaskId,
                        TaskCode = c.TaskCode,
                        TaskName = c.TaskName,
                        TaskDescription = c.TaskDescription,
                        TaskStatus = c.TaskStatus,
                        TaskAssignedToUser = c.TaskAssignedToUser,
                        TaskAssignedToRole = c.TaskAssignedToRole,
                        TaskCreatedByUser = c.TaskCreatedByUser,
                        TaskCreatedDate = c.TaskCreatedDate,
                        TaskCompletedByUser = c.TaskCompletedByUser,
                        TaskCompletedDate = c.TaskCompletedDate,
                        BenchmarkDays = c.BenchmarkDays,
                        BenchmarkDate = c.BenchmarkDate,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        BenefitCode = c.BenefitCode,
                        BenefitDescription = c.BenefitDescription,
                        TaskCreatedByTeam = c.TaskCreatedByTeam,
                        TaskCompletedByTeam = c.TaskCompletedByTeam,
                        OriginalTaskTargetDate = c.OriginalTaskTargetDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                        TaskTeamQueue = c.TaskTeamQueue,
                    };
                }
                else
                {
                    item = new RptOpentask();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptOpentask();
            }

            return item;
        }

        public async Task<PaginatedList<RptOverrideriskreport>> SearchRptOverrideriskreport(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptOverrideriskreport> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptOverrideriskreports
                            orderby c.Id ascending
                            select new RptOverrideriskreport
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimType = c.ClaimType,
                                OverrideProcessedBy = c.OverrideProcessedBy,
                                LumpsumIpIndicator = c.LumpsumIpIndicator,
                                RiskCategory = c.RiskCategory,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimType":
                            query = query.Where(c => c.ClaimType!.Contains(search));
                            break;
                        case "OverrideProcessedBy":
                            query = query.Where(c => c.OverrideProcessedBy!.Contains(search));
                            break;
                        case "LumpsumIpIndicator":
                            query = query.Where(c => c.LumpsumIpIndicator!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "RiskCategory":
                            query = query.Where(c => c.RiskCategory!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptOverrideriskreport>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptOverrideriskreport> GetRptOverrideriskreport(string id)
        {
            RptOverrideriskreport item = null!;
            try
            {
                var c = await _context.RptOverrideriskreports.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptOverrideriskreport
                    {
                        Id = c.Id,
                        OverrideProcessedBy = c.OverrideProcessedBy,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClaimNumber = c.ClaimNumber,
                        RiskCategory = c.RiskCategory,
                        RiskCategoryCreationDate = c.RiskCategoryCreationDate,
                        OverrideRiskCategory = c.OverrideRiskCategory,
                        OverrideRiskCategoryReason = c.OverrideRiskCategoryReason,
                    };
                }
                else
                {
                    item = new RptOverrideriskreport();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptOverrideriskreport();
            }

            return item;
        }


        public async Task<PaginatedList<RptPaymentsummaryl>> SearchRptPaymentsummaryl(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptPaymentsummaryl> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptPaymentsummaryls
                            orderby c.Id ascending
                            select new RptPaymentsummaryl
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimType = c.ClaimType,
                                BenefitPayable = c.BenefitPayable,
                                InvestmentAmount = c.InvestmentAmount,
                                Bonus = c.Bonus,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {

                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimType":
                            query = query.Where(c => c.ClaimType!.Contains(search));
                            break;
                        case "BenefitPayable":
                            query = query.Where(c => c.BenefitPayable.ToString()!.Contains(search));
                            break;
                        case "InvestmentAmount":
                            query = query.Where(c => c.InvestmentAmount.ToString()!.Contains(search));
                            break;
                        case "Bonus":
                            query = query.Where(c => c.Bonus.ToString()!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptPaymentsummaryl>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptPaymentsummaryl> GetRptPaymentsummaryl(string id)
        {
            RptPaymentsummaryl item = null!;
            try
            {
                var c = await _context.RptPaymentsummaryls.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptPaymentsummaryl
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        BenefitNumber = c.BenefitNumber,
                        EFormId = c.EFormId,
                        LastUpdateDate = c.LastUpdateDate,
                        PolicyType = c.PolicyType,
                        ConcurrentClaimYN = c.ConcurrentClaimYN,
                        ClaimType = c.ClaimType,
                        GroupOrRetail = c.GroupOrRetail,
                        PaymentType = c.PaymentType,
                        BenefitAmtCalc = c.BenefitAmtCalc,
                        DateCeasedWork = c.DateCeasedWork,
                        IncurredDate = c.IncurredDate,
                        AcceptFrom = c.AcceptFrom,
                        BenefitPayable = c.BenefitPayable,
                        InvestmentAmount = c.InvestmentAmount,
                        Bonus = c.Bonus,
                        OtherTaxable = c.OtherTaxable,
                        TotalGrossAmount = c.TotalGrossAmount,
                        OtherNonTaxable = c.OtherNonTaxable,
                        TaxValue = c.TaxValue,
                        TotalNetAmount = c.TotalNetAmount,
                        PartialWdrwlTferReq = c.PartialWdrwlTferReq,
                        PartialWdrawalTferAmt = c.PartialWdrawalTferAmt,
                        TaxDollar = c.TaxDollar,
                        CaldNetAmount = c.CaldNetAmount,
                        PaymentAddtnlInfo = c.PaymentAddtnlInfo,
                        PaymentMethod = c.PaymentMethod,
                        ForGroupPayee = c.ForGroupPayee,
                        AdminReqdWdrawal = c.AdminReqdWdrawal,
                        PolicyDelinkedYN = c.PolicyDelinkedYN,
                        DelinkedPolicyDetails = c.DelinkedPolicyDetails,
                        AdminDeletePolicyYN = c.AdminDeletePolicyYN,
                        AdminDeleteProcDate = c.AdminDeleteProcDate,
                        PremRefundReqdYN = c.PremRefundReqdYN,
                        RemaingCoverYN = c.RemaingCoverYN,
                        BuyBackOption = c.BuyBackOption,
                        BuyBackOptionEffDate = c.BuyBackOptionEffDate,
                        TrmaReinstmntApplYN = c.TrmaReinstmntApplYN,
                        FinancialPlanningBftYN = c.FinancialPlanningBftYN,
                        FinancialPlanningBftAmt = c.FinancialPlanningBftAmt,
                        OtherPaymentInfo = c.OtherPaymentInfo,
                        ProcessDate = c.ProcessDate,
                        AuthoriseDate = c.AuthoriseDate,
                        OtherAdminInfo = c.OtherAdminInfo,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimTypeIpLs = c.ClaimTypeIpLs,
                        ClassOfBusiness = c.ClassOfBusiness,
                        BenefitCode = c.BenefitCode,
                        ProductCode = c.ProductCode,
                        BenefitType = c.BenefitType,
                    };
                }
                else
                {
                    item = new RptPaymentsummaryl();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptPaymentsummaryl();
            }

            return item;
        }

        public async Task<PaginatedList<RptPhoneenquiry>> SearchRptPhoneenquiry(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptPhoneenquiry> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptPhoneenquiries
                            orderby c.Id ascending
                            select new RptPhoneenquiry
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimantName = c.ClaimantName,
                                ContactName = c.ContactName,
                                ReasonForContact = c.ReasonForContact,
                                Decision = c.Decision,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "ContactName":
                            query = query.Where(c => c.ContactName!.Contains(search));
                            break;
                        case "ReasonForContact":
                            query = query.Where(c => c.ReasonForContact!.Contains(search));
                            break;
                        case "Decision":
                            query = query.Where(c => c.Decision!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptPhoneenquiry>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptPhoneenquiry> GetRptPhoneenquiry(string id)
        {
            RptPhoneenquiry item = null!;
            try
            {
                var c = await _context.RptPhoneenquiries.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptPhoneenquiry
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        ReasonForContact = c.ReasonForContact,
                        DateOfContact = c.DateOfContact,
                        DirectionOfContact = c.DirectionOfContact,
                        ClaimantName = c.ClaimantName,
                        ContactName = c.ContactName,
                        MethodOfContact = c.MethodOfContact,
                        ContactMadeIndicator = c.ContactMadeIndicator,
                        PhoneRecordingLink = c.PhoneRecordingLink,
                        DurationOfContact = c.DurationOfContact,
                        UserName = c.UserName,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ContactDescription = c.ContactDescription,
                        Decision = c.Decision,
                        DecisionDate = c.DecisionDate,
                        DecisionReason = c.DecisionReason,
                    };
                }
                else
                {
                    item = new RptPhoneenquiry();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptPhoneenquiry();
            }

            return item;
        }

        public async Task<PaginatedList<RptRecoveryrehabnote>> SearchRptRecoveryrehabnote(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptRecoveryrehabnote> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptRecoveryrehabnotes
                            orderby c.Id ascending
                            select new RptRecoveryrehabnote
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                ClaimType = c.ClaimType,
                                NoteType = c.NoteType,
                                DateCreated = c.DateCreated,
                                Status = c.Status,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "ClaimType":
                            query = query.Where(c => c.ClaimType!.Contains(search));
                            break;
                        case "NoteType":
                            query = query.Where(c => c.NoteType!.Contains(search));
                            break;
                        case "Status":
                            query = query.Where(c => c.Status!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptRecoveryrehabnote>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptRecoveryrehabnote> GetRptRecoveryrehabnote(string id)
        {
            RptRecoveryrehabnote item = null!;
            try
            {
                var c = await _context.RptRecoveryrehabnotes.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptRecoveryrehabnote
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        NoteType = c.NoteType,
                        DateCreated = c.DateCreated,
                        Status = c.Status,
                        DateOfStatusChange = c.DateOfStatusChange,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                    };
                }
                else
                {
                    item = new RptRecoveryrehabnote();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptRecoveryrehabnote();
            }

            return item;
        }

        public async Task<PaginatedList<RptTaskreportgroup>> SearchRptTaskreportgroup(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptTaskreportgroup> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptTaskreportgroups
                            orderby c.Id ascending
                            select new RptTaskreportgroup
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CaseStatus = c.CaseStatus,
                                ClaimantName = c.ClaimantName,
                                TaskName = c.TaskName,
                                TaskDescription = c.TaskDescription,
                                StaffInd = c.StaffInd,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CaseStatus":
                            query = query.Where(c => c.CaseStatus!.Contains(search));
                            break;
                        case "TaskName":
                            query = query.Where(c => c.TaskName!.Contains(search));
                            break;
                        case "TaskDescription":
                            query = query.Where(c => c.TaskDescription!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptTaskreportgroup>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptTaskreportgroup> GetRptTaskreportgroup(string id)
        {
            RptTaskreportgroup item = null!;
            try
            {
                var c = await _context.RptTaskreportgroups.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptTaskreportgroup
                    {
                        Id = c.Id,
                        ClaimNumber = c.ClaimNumber,
                        CaseStatus = c.CaseStatus,
                        ClaimantName = c.ClaimantName,
                        CaseType = c.CaseType,
                        CaseManager = c.CaseManager,
                        ClaimTeam = c.ClaimTeam,
                        TaskProcessStep = c.TaskProcessStep,
                        TaskId = c.TaskId,
                        TaskCode = c.TaskCode,
                        TaskName = c.TaskName,
                        TaskDescription = c.TaskDescription,
                        TaskStatus = c.TaskStatus,
                        TaskAssignedToUser = c.TaskAssignedToUser,
                        TaskAssignedToRole = c.TaskAssignedToRole,
                        TaskCreatedByUser = c.TaskCreatedByUser,
                        TaskCreatedDate = c.TaskCreatedDate,
                        TaskCompletedByUser = c.TaskCompletedByUser,
                        TaskCompletedDate = c.TaskCompletedDate,
                        BenchmarkDays = c.BenchmarkDays,
                        BenchmarkDate = c.BenchmarkDate,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        BenefitCode = c.BenefitCode,
                        BenefitDescription = c.BenefitDescription,
                        TaskCreatedByTeam = c.TaskCreatedByTeam,
                        TaskCompletedByTeam = c.TaskCompletedByTeam,
                        OriginalTaskTargetDate = c.OriginalTaskTargetDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                    };
                }
                else
                {
                    item = new RptTaskreportgroup();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptTaskreportgroup();
            }

            return item;
        }

        public async Task<PaginatedList<RptTaskreportreinsurance>> SearchRptTaskreportreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0)
        {
            PaginatedList<RptTaskreportreinsurance> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.RptTaskreportreinsurances
                            orderby c.Id ascending
                            select new RptTaskreportreinsurance
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                CaseStatus = c.CaseStatus,
                                ClaimantName = c.ClaimantName,
                                ProductName = c.ProductName,
                                TaskName = c.TaskName,
                                StaffInd = c.StaffInd,
                                
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CaseStatus":
                            query = query.Where(c => c.CaseStatus!.Contains(search));
                            break;
                        case "ClaimantName":
                            query = query.Where(c => c.ClaimantName!.Contains(search));
                            break;
                        case "ProductName":
                            query = query.Where(c => c.ProductName!.Contains(search));
                            break;
                        case "TaskName":
                            query = query.Where(c => c.TaskName!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                list = await PaginatedList<RptTaskreportreinsurance>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<RptTaskreportreinsurance> GetRptTaskreportreinsurance(string id)
        {
            RptTaskreportreinsurance item = null!;
            try
            {
                var c = await _context.RptTaskreportreinsurances.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new RptTaskreportreinsurance
                    {
                        Id = c.Id,
                        TaskCreatedByUser = c.TaskCreatedByUser,
                        TaskCreatedDate = c.TaskCreatedDate,
                        TaskCompletedByUser = c.TaskCompletedByUser,
                        TaskCompletedDate = c.TaskCompletedDate,
                        BenchmarkDays = c.BenchmarkDays,
                        BenchmarkDate = c.BenchmarkDate,
                        ProductName = c.ProductName,
                        BenefitNumber = c.BenefitNumber,
                        BenefitCode = c.BenefitCode,
                        BenefitDescription = c.BenefitDescription,
                        TaskCreatedByTeam = c.TaskCreatedByTeam,
                        TaskCompletedByTeam = c.TaskCompletedByTeam,
                        OriginalTaskTargetDate = c.OriginalTaskTargetDate,
                        LumpsumIpIndicator = c.LumpsumIpIndicator,
                        ClaimType = c.ClaimType,
                        ClassOfBusiness = c.ClassOfBusiness,
                        ProductCode = c.ProductCode,
                        TargetBenefitType = c.TargetBenefitType,
                        ClaimNumber = c.ClaimNumber,
                        CaseStatus = c.CaseStatus,
                        ClaimantName = c.ClaimantName,
                        CaseType = c.CaseType,
                        CaseManager = c.CaseManager,
                        ClaimTeam = c.ClaimTeam,
                        TaskProcessStep = c.TaskProcessStep,
                        TaskId = c.TaskId,
                        TaskCode = c.TaskCode,
                        TaskName = c.TaskName,
                        TaskDescription = c.TaskDescription,
                        TaskStatus = c.TaskStatus,
                        TaskAssignedToUser = c.TaskAssignedToUser,
                        TaskAssignedToRole = c.TaskAssignedToRole,
                    };
                }
                else
                {
                    item = new RptTaskreportreinsurance();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new RptTaskreportreinsurance();
            }

            return item;
        }


        public async Task<PaginatedList<Party>> SearchParty(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Party> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Parties
                            orderby c.Id ascending
                            select new Party
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CustomerNo = c.CustomerNo,
                                Title = c.Title,
                                Name =  c.Name,
                                Gender = c.Gender,
                                DOB = c.DOB,
                                DOD = c.DOD,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "CustomerNo":
                            query = query.Where(c => c.CustomerNo!.Contains(search));
                            break;
                        case "Name":
                            query = query.Where(c => c.Name!.Contains(search));
                            break;
                        case "DOB":
                            query = query.Where(c => c.DOB!.Contains(search));
                            break;
                        case "DOD":
                            query = query.Where(c => c.DOD!.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<Party>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Party> GetParty(string id)
        {
            Party item = null!;
            try
            {
                var p = await _context.PartySearches.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                var c = await _context.Parties.FirstOrDefaultAsync(m => m.C == p!.C && m.I == p!.I);
                if (c != null)
                {
                    item = new Party
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CustomerNo = c.CustomerNo,
                        Name = c.Name,
                        Title = c.Title,
                        PreferredName = c.PreferredName,
                        PreviousName = c.PreviousName,
                        Verified = c.Verified,
                        DateOfBirth = c.DateOfBirth,
                        DateOfDeath = c.DateOfDeath,
                        Gender = c.Gender,
                        MaritalStatus = c.MaritalStatus,
                        PartyType = c.PartyType,
                        Deceased = c.Deceased,
                        NotificationsIssued = c.NotificationsIssued,
                        Occupation = c.Occupation,
                        Tenure = c.Tenure,
                        HazardousPursuit = c.HazardousPursuit,
                        Nationality = c.Nationality,
                        CountryOfBirth = c.CountryOfBirth,
                        CulturalConsiderations = c.CulturalConsiderations,
                        HighValueAdvisor = c.HighValueAdvisor,
                        SecuredClient = c.SecuredClient,
                        GroupClient = c.GroupClient,
                        StaffMember = c.StaffMember,
                        Password = c.Password,
                        CorrespondenceTranslationRequired = c.CorrespondenceTranslationRequired,
                        InterpreterRequired = c.InterpreterRequired,
                        
                    };
                }
                else
                {
                    item = new Party();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Party();
            }

            return item;
        }

        public async Task<PaginatedList<PartySearch>> SearchPartySearch(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<PartySearch> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartySearches
                            orderby c.Id ascending
                            //where c.StaffInd == claimflag
                            select new PartySearch
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimNumber = c.ClaimNumber,
                                CustomerNo = c.CustomerNo,
                                Title = c.Title,
                                Name = c.Name,
                                Dob = c.Dob,
                                Dod = c.Dod,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "CustomerNo":
                            query = query.Where(c => c.CustomerNo!.Contains(search));
                            break;
                        case "Name":
                            query = query.Where(c => c.Name!.Contains(search));
                            break;
                        case "Dob":
                            query = query.Where(c => c.Dob!.Contains(search));
                            break;
                        case "Dod":
                            query = query.Where(c => c.Dod!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<PartySearch>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartySearch> GetPartySearch(string id)
        {
            PartySearch item = null!;
            try
            {
                var c = await _context.PartySearches.FirstOrDefaultAsync(m => m.ClaimNumber == id);
                if (c != null)
                {
                    item = new PartySearch
                    {
                        Id = c.Id,
                        CustomerNo = c.CustomerNo,
                        Title = c.Title,
                        Name = c.Name,
                        Dob = c.Dob,
                        Dod = c.Dod,
                        ClaimNumber = c.ClaimNumber,
                        Pid = c.Pid,
                    };
                }
                else
                {
                    item = new PartySearch();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartySearch();
            }

            return item;
        }


        public async Task<PaginatedList<PartyAddress>> SearchPartyAddress(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<PartyAddress> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyAddresses
                            orderby c.Id ascending
                            select new PartyAddress
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                ClaimNumber = c.ClaimNumber,
                                PartyName = c.PartyName,
                                AddressType = c.AddressType,
                                EffectiveFrom = c.EffectiveFrom,
                                AddressLine1 = c.AddressLine1,
                                Suburb = c.Suburb,
                                PostCode = c.PostCode,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "PartyName":
                            query = query.Where(c => c.PartyName!.Contains(search));
                            break;
                        case "AddressType":
                            query = query.Where(c => c.AddressType!.Contains(search));
                            break;
                        case "EffectiveFrom":
                            query = query.Where(c => c.EffectiveFrom!.Contains(search));
                            break;
                        case "AddressLine1":
                            query = query.Where(c => c.AddressLine1!.Contains(search));
                            break;
                        case "Suburb":
                            query = query.Where(c => c.Suburb!.Contains(search));
                            break;
                        case "PostCode":
                            query = query.Where(c => c.PostCode!.Contains(search));
                            break;
                        case "PartyI":
                            query = query.Where(c => c.PartyI!.ToString()! == search);
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<PartyAddress>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyAddress> GetPartyAddress(string id, int appflag = 1)
        {
            PartyAddress item = null!;
            try
            {
                var c = await _context.PartyAddresses.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyAddress
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        AddressType = c.AddressType,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        BuildingName1 = c.BuildingName1,
                        BuildingName2 = c.BuildingName2,
                        DisplayExtend = c.DisplayExtend,
                        Dpid = c.Dpid,
                        FloorLevelNum = c.FloorLevelNum,
                        LotNumber = c.LotNumber,
                        PostalNumber = c.PostalNumber,
                        PostalNumberP = c.PostalNumberP,
                        PostalNumberS = c.PostalNumberS,
                        PremiseNoSuff = c.PremiseNoSuff,
                        PremiseNoTo = c.PremiseNoTo,
                        PremiseNoToSu = c.PremiseNoToSu,
                        FloorLevelTyp = c.FloorLevelTyp,
                        StreetSuffix = c.StreetSuffix,
                        PostalType = c.PostalType,
                        Status = c.Status,
                        AddressLine1 = c.AddressLine1,
                        AddressLine2 = c.AddressLine2,
                        AddressLine3 = c.AddressLine3,
                        Suburb = c.Suburb,
                        State = c.State,
                        PostCode = c.PostCode,
                        CountryCode = c.CountryCode,
                    };
                }
                else
                {
                    item = new PartyAddress();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyAddress();
            }

            return item;
        }

        public async Task<PartyAddress> GetPartyAddressById(string pc, string pi)
        {
            PartyAddress item = null!;
            try
            {
                var c = await _context.PartyAddresses.FirstOrDefaultAsync(m => m.PartyC == Convert.ToDecimal(pc) && m.PartyI == Convert.ToDecimal(pi));
                if (c != null)
                {
                    item = new PartyAddress
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        AddressType = c.AddressType,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        BuildingName1 = c.BuildingName1,
                        BuildingName2 = c.BuildingName2,
                        DisplayExtend = c.DisplayExtend,
                        Dpid = c.Dpid,
                        FloorLevelNum = c.FloorLevelNum,
                        LotNumber = c.LotNumber,
                        PostalNumber = c.PostalNumber,
                        PostalNumberP = c.PostalNumberP,
                        PostalNumberS = c.PostalNumberS,
                        PremiseNoSuff = c.PremiseNoSuff,
                        PremiseNoTo = c.PremiseNoTo,
                        PremiseNoToSu = c.PremiseNoToSu,
                        FloorLevelTyp = c.FloorLevelTyp,
                        StreetSuffix = c.StreetSuffix,
                        PostalType = c.PostalType,
                        Status = c.Status,
                        AddressLine1 = c.AddressLine1,
                        AddressLine2 = c.AddressLine2,
                        AddressLine3 = c.AddressLine3,
                        Suburb = c.Suburb,
                        State = c.State,
                        PostCode = c.PostCode,
                        CountryCode = c.CountryCode,
                    };
                }
                else
                {
                    item = new PartyAddress();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyAddress();
            }

            return item;
        }

        public async Task<PaginatedList<PartyCertificate>> SearchPartyCertificate(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PartyCertificate> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyCertificates
                            orderby c.Id ascending
                            select new PartyCertificate
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CertificationGroup = c.CertificationGroup,
                                CertificationType = c.CertificationType,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "CertificationGroup":
                            query = query.Where(c => c.CertificationGroup.Contains(search));
                            break;
                        case "CertificationType":
                            query = query.Where(c => c.CertificationType.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<PartyCertificate>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyCertificate> GetPartyCertificate(string id)
        {
            PartyCertificate item = null!;
            try
            {
                var c = await _context.PartyCertificates.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyCertificate
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        CertificationIssued = c.CertificationIssued,
                        CertificationGroup = c.CertificationGroup,
                        CertificationType = c.CertificationType,
                        CertificationStatus = c.CertificationStatus,
                        DocumentIdentifier = c.DocumentIdentifier,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                    };
                }
                else
                {
                    item = new PartyCertificate();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyCertificate();
            }

            return item;
        }

        public async Task<PaginatedList<PartyClassification>> SearchPartyClassification(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PartyClassification> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyClassifications
                            orderby c.Id ascending
                            select new PartyClassification
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClasificationType = c.ClasificationType,
                                Speciality = c.Speciality,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClasificationType":
                            query = query.Where(c => c.ClasificationType.Contains(search));
                            break;
                        case "Speciality":
                            query = query.Where(c => c.Speciality.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<PartyClassification>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyClassification> GetPartyClassification(string id)
        {
            PartyClassification item = null!;
            try
            {
                var c = await _context.PartyClassifications.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyClassification
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ClasificationType = c.ClasificationType,
                        Speciality = c.Speciality,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                    };
                }
                else
                {
                    item = new PartyClassification();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyClassification();
            }

            return item;
        }

        public async Task<PaginatedList<PartyConsent>> SearchPartyConsent(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PartyConsent> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyConsents
                            orderby c.Id ascending
                            select new PartyConsent
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ConsentType = c.ConsentType,
                                ConsentStatus = c.ConsentStatus,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ConsentType":
                            query = query.Where(c => c.ConsentType.Contains(search));
                            break;
                        case "ConsentStatus":
                            query = query.Where(c => c.ConsentStatus.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<PartyConsent>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyConsent> GetPartyConsent(string id)
        {
            PartyConsent item = null!;
            try
            {
                var c = await _context.PartyConsents.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyConsent
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ConsentType = c.ConsentType,
                        ConsentStatus = c.ConsentStatus,
                        EffectiveDate = c.EffectiveDate,
                    };
                }
                else
                {
                    item = new PartyConsent();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyConsent();
            }

            return item;
        }

        public async Task<PaginatedList<PartyContact>> SearchPartyContact(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PartyContact> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyContacts
                            orderby c.Id ascending
                            select new PartyContact
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ContactMethod = c.ContactMethod,
                                Verificaton = c.Verificaton,
                                ContactTime = c.ContactTime,
                                TelNo = c.TelNo,
                                Email = c.Email,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ContactMethod":
                            query = query.Where(c => c.ContactMethod!.Contains(search));
                            break;
                        case "TelNo":
                            query = query.Where(c => c.TelNo!.Contains(search));
                            break;
                        case "Email":
                            query = query.Where(c => c.Email!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<PartyContact>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyContact> GetPartyContact(string id)
        {
            PartyContact item = null!;
            try
            {
                var c = await _context.PartyContacts.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyContact
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ContactMethod = c.ContactMethod,
                        ContactTime = c.ContactTime,
                        Verificaton = c.Verificaton,
                        IntCode = c.IntCode,
                        AreaCode = c.AreaCode,
                        TelNo = c.TelNo,
                        ExtNo = c.ExtNo,
                        IsExDir = c.IsExDir,
                        Email = c.Email,
                    };
                }
                else
                {
                    item = new PartyContact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyContact();
            }

            return item;
        }

        public async Task<PartyContact> GetPartyContactById(string pc, string pi)
        {
            PartyContact item = null!;
            try
            {
                var c = await _context.PartyContacts.FirstOrDefaultAsync(m => m.PartyC == Convert.ToDecimal(pc) && m.PartyI == Convert.ToDecimal(pi));
                if (c != null)
                {
                    item = new PartyContact
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ContactMethod = c.ContactMethod,
                        ContactTime = c.ContactTime,
                        Verificaton = c.Verificaton,
                        IntCode = c.IntCode,
                        AreaCode = c.AreaCode,
                        TelNo = c.TelNo,
                        ExtNo = c.ExtNo,
                        IsExDir = c.IsExDir,
                        Email = c.Email,
                    };
                }
                else
                {
                    item = new PartyContact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyContact();
            }

            return item;
        }

        public async Task<PaginatedList<PartyPolicyRole>> SearchPartyPolicyRole(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PartyPolicyRole> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PartyPolicyRoles
                            orderby c.Id ascending
                            select new PartyPolicyRole
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                Role = c.Role,
                                Status = c.Status,
                                CommenceDate = c.CommenceDate,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Role":
                            query = query.Where(c => c.Role.Contains(search));
                            break;
                        case "Status":
                            query = query.Where(c => c.Status.Contains(search));
                            break;
                    }
                }

                list = await PaginatedList<PartyPolicyRole>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PartyPolicyRole> GetPartyPolicyRole(string id)
        {
            PartyPolicyRole item = null!;
            try
            {
                var c = await _context.PartyPolicyRoles.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PartyPolicyRole
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        PolicyC = c.PolicyC,
                        PolicyI = c.PolicyI,
                        Role = c.Role,
                        Status = c.Status,
                        Erole = c.Erole,
                        Estatus = c.Estatus,
                        CommenceDate = c.CommenceDate,
                        TerminationDate = c.TerminationDate,
                        OrderNo = c.OrderNo,
                    };
                }
                else
                {
                    item = new PartyPolicyRole();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PartyPolicyRole();
            }

            return item;
        }

        public async Task<PaginatedList<PaymentPreference>> SearchPaymentPreference(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<PaymentPreference> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PaymentPreferences
                            orderby c.Id ascending
                            select new PaymentPreference
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                Description = c.Description,
                                PaymentPeriod = c.PaymentPeriod,
                                PaymentDay = c.PaymentDay,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "Description":
                            query = query.Where(c => c.Description.Contains(search));
                            break;
                        case "PaymentPeriod":
                            query = query.Where(c => c.PaymentPeriod.Contains(search));
                            break;
                        case "PaymentDay":
                            query = query.Where(c => c.PaymentDay.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<PaymentPreference>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaymentPreference> GetPaymentPreference(string id)
        {
            PaymentPreference item = null!;
            try
            {
                var c = await _context.PaymentPreferences.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new PaymentPreference
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        Description = c.Description,
                        BulkPayee = c.BulkPayee,
                        PaymentPeriod = c.PaymentPeriod,
                        PaymentDay = c.PaymentDay,
                        NominatedPayee = c.NominatedPayee,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        UseForBilling = c.UseForBilling,
                        Identifier = c.Identifier,
                        CategoryOfService = c.CategoryOfService,
                        PaymentMethod = c.PaymentMethod,
                        NameToPrintOnCheque = c.NameToPrintOnCheque,
                    };
                }
                else
                {
                    item = new PaymentPreference();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new PaymentPreference();
            }

            return item;
        }


        public async Task<PaginatedList<Case>> SearchCase(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Case> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Cases
                            orderby c.Id ascending
                            select new Case
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                IncuredDate = c.IncuredDate,
                                Context = c.Context,
                                TriageSegment = c.TriageSegment,
                                CaseNumber = c.CaseNumber,
                                UnexpectedCircumstances = c.UnexpectedCircumstances,
                                CustomerContactFrequency = c.CustomerContactFrequency,
                                OpportunityToInfluenceExhausted = c.OpportunityToInfluenceExhausted,
                                Description = c.Description,
                                OverrideTriageSegmentReason = c.OverrideTriageSegmentReason,
                                CreationDate = c.CreationDate,
                                UrgentFinancialNeed = c.UrgentFinancialNeed,
                                CaseType = c.CaseType,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "CaseNumber":
                            query = query.Where(c => c.CaseNumber!.Contains(search));
                            break;
                        case "CaseType":
                            query = query.Where(c => c.CaseType!.Contains(search));
                            break;
                        case "CreationDate":
                            query = query.Where(c => c.CreationDate.ToString()!.Contains(search));
                            break;
                        case "TriageSegment":
                            query = query.Where(c => c.TriageSegment!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;

                    }
                }

                list = await PaginatedList<Case>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Case> GetCase(string id)
        {
            Case item = null!;
            try
            {
                var c = await _context.Cases.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Case
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        IncuredDate = c.IncuredDate,
                        Context = c.Context,
                        TriageSegment = c.TriageSegment,
                        CaseNumber = c.CaseNumber,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        OpportunityToInfluenceExhausted = c.OpportunityToInfluenceExhausted,
                        Description = c.Description,
                        OverrideTriageSegmentReason = c.OverrideTriageSegmentReason,
                        CreationDate = c.CreationDate,
                        UrgentFinancialNeed = c.UrgentFinancialNeed,
                        CaseType = c.CaseType,
                        CaseOwnerComment = c.CaseOwnerComment,
                    };
                }
                else
                {
                    item = new Case();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Case();
            }

            return item;
        }

        public async Task<Case> GetCaseByClaimNo(string id, int appflag = 1)
        {
            Case item = null!;
            try
            {
                var c = await _context.Cases.FirstOrDefaultAsync(m => m.CaseNumber == id && m.ApplicationId == appflag);
                if (c != null)
                {
                    item = new Case
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        IncuredDate = c.IncuredDate,
                        Context = c.Context,
                        TriageSegment = c.TriageSegment,
                        CaseNumber = c.CaseNumber,
                        UnexpectedCircumstances = c.UnexpectedCircumstances,
                        CustomerContactFrequency = c.CustomerContactFrequency,
                        OpportunityToInfluenceExhausted = c.OpportunityToInfluenceExhausted,
                        Description = c.Description,
                        OverrideTriageSegmentReason = c.OverrideTriageSegmentReason,
                        CreationDate = c.CreationDate,
                        UrgentFinancialNeed = c.UrgentFinancialNeed,
                        CaseType = c.CaseType,
                        CaseOwnerComment = c.CaseOwnerComment,
                        ApplicationId = c.ApplicationId
                    };
                }
                else
                {
                    item = new Case();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Case();
            }

            if (item == null)
            {
                item = new Case();
            }

            return item;
        }

        public async Task<PaginatedList<Case>> GetChildCases(string id, int appflag = 1)
        {
            Case _case = await GetCaseByClaimNo(id, appflag);
            PaginatedList<Case> list = null!;

            try
            {
                var query = from c in _context.Cases
                            where c.CaseC == _case.C && c.CaseI == _case.I && c.ApplicationId == appflag
                            orderby c.Id ascending
                            select new Case
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                IncuredDate = c.IncuredDate,
                                Context = c.Context,
                                TriageSegment = c.TriageSegment,
                                CaseNumber = c.CaseNumber,
                                UnexpectedCircumstances = c.UnexpectedCircumstances,
                                CustomerContactFrequency = c.CustomerContactFrequency,
                                OpportunityToInfluenceExhausted = c.OpportunityToInfluenceExhausted,
                                Description = c.Description,
                                OverrideTriageSegmentReason = c.OverrideTriageSegmentReason,
                                CreationDate = c.CreationDate,
                                UrgentFinancialNeed = c.UrgentFinancialNeed,
                                CaseType = c.CaseType,
                                ApplicationId = c.ApplicationId,
                            };

                list = await PaginatedList<Case>.CreateAsync(query, 1, 500);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return list;
        }

        public async Task<List<Case>> GetLinkedCases(string id, int appflag = 1)
        {
            List<Case> items = new List<Case>();
            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                if (con.State != System.Data.ConnectionState.Open) 
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetLinkedCases";
                cmd.Parameters.AddWithValue("@pClaimNumber", id);
                cmd.Parameters.AddWithValue("@pApplicationId", appflag);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Case _case = new Case
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                IncuredDate = Convert.ToDateTime(reader["IncuredDate"].ToString()),
                                Context = reader["Context"].ToString(),
                                TriageSegment = reader["TriageSegment"].ToString(),
                                CaseNumber = reader["CaseNumber"].ToString(),
                                Description = reader["Description"].ToString(),
                                OverrideTriageSegmentReason = reader["OverrideTriageSegmentReason"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["CreationDate"].ToString()),
                                UrgentFinancialNeed = reader["UrgentFinancialNeed"].ToString(),
                                CaseType = reader["CaseType"].ToString(),
                            };
                            items.Add(_case);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return items;
        }

        public async Task<PaginatedList<CaseLinker>> SearchCaseLinker(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<CaseLinker> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.CaseLinkers
                            orderby c.Id ascending
                            select new CaseLinker
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseForwardC = c.CaseForwardC,
                                CaseForwardI = c.CaseForwardI,
                                CaseBackwardC = c.CaseBackwardC,
                                CaseBackwardI = c.CaseBackwardI,
                                LastUpdated = c.LastUpdated,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "CaseForwardC":
                    //        query = query.Where(c => c.CaseForwardC!.Contains(search));
                    //        break;
                    //    case "CaseForwardI":
                    //        query = query.Where(c => c.CaseForwardI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<CaseLinker>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<CaseLinker> GetCaseLinker(string id)
        {
            CaseLinker item = null!;
            try
            {
                var c = await _context.CaseLinkers.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new CaseLinker
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseForwardC = c.CaseForwardC,
                        CaseForwardI = c.CaseForwardI,
                        CaseBackwardC = c.CaseBackwardC,
                        CaseBackwardI = c.CaseBackwardI,
                        LastUpdated = c.LastUpdated,
                        LastUpdatedBy = c.LastUpdatedBy,
                    };
                }
                else
                {
                    item = new CaseLinker();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new CaseLinker();
            }

            return item;
        }


        public async Task<PaginatedList<CaseParty>> SearchCaseParty(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<CaseParty> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.CaseParties
                            orderby c.Id ascending
                            select new CaseParty
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                RoleC = c.RoleC,
                                RoleI = c.RoleI,
                                RoleName = c.RoleName,
                                Description = c.Description,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "PartyC":
                    //        query = query.Where(c => c.PartyC!.Contains(search));
                    //        break;
                    //    case "PartyI":
                    //        query = query.Where(c => c.PartyI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<CaseParty>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<CaseParty> GetCaseParty(string id)
        {
            CaseParty item = null!;
            try
            {
                var c = await _context.CaseParties.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new CaseParty
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        RoleC = c.RoleC,
                        RoleI = c.RoleI,
                        RoleName = c.RoleName,
                        Description = c.Description,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        UseDefaultPaymentDetailsForParty = c.UseDefaultPaymentDetailsForParty,
                    };
                }
                else
                {
                    item = new CaseParty();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new CaseParty();
            }

            return item;
        }


        public async Task<PaginatedList<CaseValidation>> SearchCaseValidation(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<CaseValidation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.CaseValidations
                            orderby c.Id
                            select new CaseValidation
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                Category = c.Category,
                                Message = c.Message,
                                UserC = c.UserC,
                                UserI = c.UserI,
                                LastUpdatedDate = c.LastUpdatedDate,
                                LastUpdatedBy = c.LastUpdatedBy,
                                ReasonForSuppression = c.ReasonForSuppression,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Category":
                            query = query.Where(c => c.Category!.Contains(search));
                            break;
                        case "Message":
                            query = query.Where(c => c.Message!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<CaseValidation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<CaseValidation> GetCaseValidation(string id)
        {
            CaseValidation item = null!;
            try
            {
                var c = await _context.CaseValidations.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new CaseValidation
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        Category = c.Category,
                        Message = c.Message,
                        UserC = c.UserC,
                        UserI = c.UserI,
                        LastUpdatedDate = c.LastUpdatedDate,
                        LastUpdatedBy = c.LastUpdatedBy,
                        ReasonForSuppression = c.ReasonForSuppression,
                        Description = c.Description,
                    };
                }
                else
                {
                    item = new CaseValidation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new CaseValidation();
            }

            return item;
        }


        public async Task<PaginatedList<Claim>> SearchClaim(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Claim> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Claims
                            orderby c.Id ascending
                            select new Claim
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                AccidentSickness = c.AccidentSickness,
                                AdditionalInformation = c.AdditionalInformation,
                                FatalClaim = c.FatalClaim,
                                OccurredInAnotherCountry = c.OccurredInAnotherCountry,
                                ClaimantIsNotifier = c.ClaimantIsNotifier,
                                ClaimReceivedDate = c.ClaimReceivedDate,
                                DateReturnedToWork = c.DateReturnedToWork,
                                TraumaDefinition = c.TraumaDefinition,
                                InsuredClaimCorrespondence = c.InsuredClaimCorrespondence,
                                ExpectedRtwftdateIfKnown = c.ExpectedRtwftdateIfKnown,
                                TpdsubDefinition = c.TpdsubDefinition,
                                Source = c.Source,
                                IncurredDateOnLastUpdate = c.IncurredDateOnLastUpdate,
                                GuidelinesDate = c.GuidelinesDate,
                                RecoveryDurationUnit = c.RecoveryDurationUnit,
                                Min = c.Min,
                                Opt = c.Opt,
                                Max = c.Max,
                                DisableAutoUpdates = c.DisableAutoUpdates,
                                Min1 = c.Min1,
                                Opt1 = c.Opt1,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "AccidentSickness":
                            query = query.Where(c => c.AccidentSickness!.Contains(search));
                            break;
                        case "AdditionalInformation":
                            query = query.Where(c => c.AdditionalInformation!.Contains(search));
                            break;
                        case "ClaimReceivedDate":
                            query = query.Where(c => c.ClaimReceivedDate.ToString()!.Contains(search));
                            break;
                        case "ExpectedRtwftdateIfKnown":
                            query = query.Where(c => c.ExpectedRtwftdateIfKnown.ToString()!.Contains(search));
                            break;
                        case "TpdsubDefinition":
                            query = query.Where(c => c.TpdsubDefinition!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<Claim>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Claim> GetClaim(string id)
        {
            Claim item = null!;
            try
            {
                var c = await _context.Claims.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Claim
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        AccidentSickness = c.AccidentSickness,
                        AdditionalInformation = c.AdditionalInformation,
                        FatalClaim = c.FatalClaim,
                        OccurredInAnotherCountry = c.OccurredInAnotherCountry,
                        ClaimantIsNotifier = c.ClaimantIsNotifier,
                        ClaimReceivedDate = c.ClaimReceivedDate,
                        DateReturnedToWork = c.DateReturnedToWork,
                        TraumaDefinition = c.TraumaDefinition,
                        InsuredClaimCorrespondence = c.InsuredClaimCorrespondence,
                        ExpectedRtwftdateIfKnown = c.ExpectedRtwftdateIfKnown,
                        TpdsubDefinition = c.TpdsubDefinition,
                        Source = c.Source,
                        IncurredDateOnLastUpdate = c.IncurredDateOnLastUpdate,
                        GuidelinesDate = c.GuidelinesDate,
                        RecoveryDurationUnit = c.RecoveryDurationUnit,
                        Min = c.Min,
                        Opt = c.Opt,
                        Max = c.Max,
                        DisableAutoUpdates = c.DisableAutoUpdates,
                        Min1 = c.Min1,
                        Opt1 = c.Opt1,
                        Max1 = c.Max1,
                    };
                }
                else
                {
                    item = new Claim();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claim();
            }

            return item;
        }

        public async Task<Claim> GetClaimByClaimNumber(string id, int appflag = 1)
        {
            Claim item = null!;
            try
            {
                var query = from a in _context.Cases
                            join c in _context.Claims on new { a.CaseC, a.CaseI } equals new { c.CaseC, c.CaseI }
                            where a.CaseNumber!.Contains(id) && a.ApplicationId == appflag
                            select new Claim
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                AccidentSickness = c.AccidentSickness,
                                AdditionalInformation = c.AdditionalInformation,
                                FatalClaim = c.FatalClaim,
                                OccurredInAnotherCountry = c.OccurredInAnotherCountry,
                                ClaimantIsNotifier = c.ClaimantIsNotifier,
                                ClaimReceivedDate = c.ClaimReceivedDate,
                                DateReturnedToWork = c.DateReturnedToWork,
                                TraumaDefinition = c.TraumaDefinition,
                                InsuredClaimCorrespondence = c.InsuredClaimCorrespondence,
                                ExpectedRtwftdateIfKnown = c.ExpectedRtwftdateIfKnown,
                                TpdsubDefinition = c.TpdsubDefinition,
                                Source = c.Source,
                                IncurredDateOnLastUpdate = c.IncurredDateOnLastUpdate,
                                GuidelinesDate = c.GuidelinesDate,
                                RecoveryDurationUnit = c.RecoveryDurationUnit,
                                Min = c.Min,
                                Opt = c.Opt,
                                Max = c.Max,
                                DisableAutoUpdates = c.DisableAutoUpdates,
                                Min1 = c.Min1,
                                Opt1 = c.Opt1,
                                Max1 = c.Max1,
                                ApplicationId = c.ApplicationId,
                            };
                var mitem = await query!.FirstOrDefaultAsync();
                item = mitem!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claim();
            }

            if (item == null)
            {
                item = new Claim();
            }

            return item;
        }

        public async Task<Claim> GetClaimByClaimNumberV1(string id)
        {
            Claim item = null!;
            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetClaimByClaimNumber";
                cmd.Parameters.AddWithValue("@pClaimNumber", id);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item = new Claim
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                CaseC = Convert.ToInt32(reader["Case_C"].ToString()),
                                CaseI = Convert.ToInt32(reader["Case_I"].ToString()),
                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claim();
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return item;
        }

        public async Task<Claim> GetClaimByClaimNumberV2(string id)
        {
            Claim item = null!;
            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetClaimByClaimNumber";
                cmd.Parameters.AddWithValue("@pClaimNumber", id);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item = new Claim
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                CaseC = Convert.ToInt32(reader["Case_C"].ToString()),
                                CaseI = Convert.ToInt32(reader["Case_I"].ToString()),
                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Claim();
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return item;
        }

        public async Task<PaginatedList<ClaimIncapacityPeriod>> SearchClaimIncapacityPeriod(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<ClaimIncapacityPeriod> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimIncapacityPeriods
                            orderby c.Id ascending
                            select new ClaimIncapacityPeriod
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                PartC = c.PartC,
                                PartI = c.PartI,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Notes = c.Notes,
                                PartialCapacity = c.PartialCapacity,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;

                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<ClaimIncapacityPeriod>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimIncapacityPeriod> GetClaimIncapacityPeriod(string id)
        {
            ClaimIncapacityPeriod item = null!;
            try
            {
                var c = await _context.ClaimIncapacityPeriods.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimIncapacityPeriod
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        PartC = c.PartC,
                        PartI = c.PartI,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        Notes = c.Notes,
                        PartialCapacity = c.PartialCapacity,
                    };
                }
                else
                {
                    item = new ClaimIncapacityPeriod();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimIncapacityPeriod();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPolicy>> SearchClaimPolicy(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPolicy> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPolicies
                            orderby c.Id ascending
                            select new ClaimPolicy
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                PolicyC = c.PolicyC,
                                PolicyI = c.PolicyI,
                                LastRefreshDate = c.LastRefreshDate,
                                Commencementd = c.Commencementd,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimC":
                    //        query = query.Where(c => c.ClaimC!.Contains(search));
                    //        break;
                    //    case "ClaimI":
                    //        query = query.Where(c => c.ClaimI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClaimPolicy>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPolicy> GetClaimPolicy(string id)
        {
            ClaimPolicy item = null!;
            try
            {
                var c = await _context.ClaimPolicies.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPolicy
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        PolicyC = c.PolicyC,
                        PolicyI = c.PolicyI,
                        LastRefreshDate = c.LastRefreshDate,
                        Commencementd = c.Commencementd,
                        InternalEndDate = c.InternalEndDate,
                    };
                }
                else
                {
                    item = new ClaimPolicy();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPolicy();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPolicyCoverage>> SearchClaimPolicyCoverage(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPolicyCoverage> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPolicyCoverages
                            orderby c.Id ascending
                            select new ClaimPolicyCoverage
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimPolicyC = c.ClaimPolicyC,
                                ClaimPolicyI = c.ClaimPolicyI,
                                Coverage = c.Coverage,
                                CoverageCode = c.CoverageCode,
                                Status = c.Status,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyC":
                    //        query = query.Where(c => c.ClaimPolicyC!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyI":
                    //        query = query.Where(c => c.ClaimPolicyI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClaimPolicyCoverage>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPolicyCoverage> GetClaimPolicyCoverage(string id)
        {
            ClaimPolicyCoverage item = null!;
            try
            {
                var c = await _context.ClaimPolicyCoverages.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPolicyCoverage
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimPolicyC = c.ClaimPolicyC,
                        ClaimPolicyI = c.ClaimPolicyI,
                        Coverage = c.Coverage,
                        CoverageCode = c.CoverageCode,
                        Status = c.Status,
                        EffectiveDate = c.EffectiveDate,
                    };
                }
                else
                {
                    item = new ClaimPolicyCoverage();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPolicyCoverage();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPolicyEntitlement>> SearchClaimPolicyEntitlement(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPolicyEntitlement> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPolicyEntitlements
                            orderby c.Id ascending
                            select new ClaimPolicyEntitlement
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimPolicyCoverageC = c.ClaimPolicyCoverageC,
                                ClaimPolicyCoverageI = c.ClaimPolicyCoverageI,
                                Type = c.Type,
                                BenefitEntitlementDescription = c.BenefitEntitlementDescription,
                                BenefitSelected = c.BenefitSelected,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyCoverageC":
                    //        query = query.Where(c => c.ClaimPolicyCoverageC!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyCoverageI":
                    //        query = query.Where(c => c.ClaimPolicyCoverageI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClaimPolicyEntitlement>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPolicyEntitlement> GetClaimPolicyEntitlement(string id)
        {
            ClaimPolicyEntitlement item = null!;
            try
            {
                var c = await _context.ClaimPolicyEntitlements.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPolicyEntitlement
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimPolicyCoverageC = c.ClaimPolicyCoverageC,
                        ClaimPolicyCoverageI = c.ClaimPolicyCoverageI,
                        Type = c.Type,
                        BenefitEntitlementDescription = c.BenefitEntitlementDescription,
                        BenefitSelected = c.BenefitSelected,
                        PasriskOptionCode = c.PasriskOptionCode,
                    };
                }
                else
                {
                    item = new ClaimPolicyEntitlement();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPolicyEntitlement();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPolicyExclusion>> SearchClaimPolicyExclusion(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPolicyExclusion> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPolicyExclusions
                            orderby c.Id ascending
                            select new ClaimPolicyExclusion
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimPolicyEntitlementC = c.ClaimPolicyEntitlementC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyEntitlementC":
                    //        query = query.Where(c => c.ClaimPolicyEntitlementC!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClaimPolicyExclusion>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPolicyExclusion> GetClaimPolicyExclusion(string id)
        {
            ClaimPolicyExclusion item = null!;
            try
            {
                var c = await _context.ClaimPolicyExclusions.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPolicyExclusion
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimPolicyEntitlementC = c.ClaimPolicyEntitlementC,
                        ClaimPolicyEntitlementI = c.ClaimPolicyEntitlementI,
                    };
                }
                else
                {
                    item = new ClaimPolicyExclusion();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPolicyExclusion();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPolicyReinsurance>> SearchClaimPolicyReinsurance(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPolicyReinsurance> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPolicyReinsurances
                            orderby c.Id ascending
                            select new ClaimPolicyReinsurance
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimPolicyEntitlementC = c.ClaimPolicyEntitlementC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimPolicyEntitlementC":
                    //        query = query.Where(c => c.ClaimPolicyEntitlementC!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClaimPolicyReinsurance>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPolicyReinsurance> GetClaimPolicyReinsurance(string id)
        {
            ClaimPolicyReinsurance item = null!;
            try
            {
                var c = await _context.ClaimPolicyReinsurances.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPolicyReinsurance
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimPolicyEntitlementC = c.ClaimPolicyEntitlementC,
                        ClaimPolicyEntitlementI = c.ClaimPolicyEntitlementI,
                    };
                }
                else
                {
                    item = new ClaimPolicyReinsurance();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPolicyReinsurance();
            }

            return item;
        }

        public async Task<PaginatedList<Note1>> SearchNote1(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<Note1> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {

                var query = from c in _context.Note1s
                            //where c.ClaimNumber!.Contains(search)
                            orderby c.DateCreated descending
                            select new Note1
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                ContactC = c.ContactC,
                                ContactI = c.ContactI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                PackedData = c.PackedData,
                                EnvelopId = c.EnvelopId,
                                Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                LastUpdated = c.LastUpdated,
                                Description = c.Description,
                                KeyDocument = c.KeyDocument,
                                EffectiveFrom = c.EffectiveFrom,
                                EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                UpdatedBy = c.UpdatedBy,
                                Status = c.Status,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "CreatedBy":
                            query = query.Where(c => c.CreatedBy!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(c => c.ClaimNumber!.Contains(search));
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Note1>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaginatedList<CaseNotes>> SearchNotes(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<CaseNotes> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Note1s
                            orderby c.Id ascending
                            select new CaseNotes
                            {
                                Id = c.Id,
                                //C = c.C,
                                //I = c.I,
                                //PartyC = c.PartyC,
                                //PartyI = c.PartyI,
                                //ContactC = c.ContactC,
                                //ContactI = c.ContactI,
                                //CaseC = c.CaseC,
                                //CaseI = c.CaseI,
                                //PackedData = c.PackedData,
                                //EnvelopId = c.EnvelopId,
                                //Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                //LastUpdated = c.LastUpdated,
                                //Description = c.Description,
                                //KeyDocument = c.KeyDocument,
                                //EffectiveFrom = c.EffectiveFrom,
                                //EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                //UpdatedBy = c.UpdatedBy,
                                Status = c.Status,
                                ClaimNumber = c.ClaimNumber,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "CreatedBy":
                            query = query.Where(c => c.CreatedBy!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<CaseNotes>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Note1> GetNote1(string id, int appflag = 1)
        {
            Note1 item = null!;
            try
            {
                var c = await _context.Note1s.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Note1
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ContactC = c.ContactC,
                        ContactI = c.ContactI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        PackedData = c.PackedData,
                        //PackedData = XElement.Parse(c.PackedData!).Value,
                        EnvelopId = c.EnvelopId,
                        Tag = c.Tag,
                        DateCreated = c.DateCreated,
                        LastUpdated = c.LastUpdated,
                        Description = c.Description,
                        KeyDocument = c.KeyDocument,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        DocumentType = c.DocumentType,
                        CreatedBy = c.CreatedBy,
                        UpdatedBy = c.UpdatedBy,
                        Status = c.Status,
                        ClaimNumber = c.ClaimNumber,
                        ApplicationId = c.ApplicationId,
                    };
                }
                else
                {
                    item = new Note1();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Note1();
            }

            return item;
        }

        public async Task<PaginatedList<Note1>> SearchNotesPS(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Note1> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Note1s
                            where c.DocumentType!.Contains("payment")
                            orderby c.DateCreated descending
                            select new Note1
                            {
                                Id = c.Id,
                                //C = c.C,
                                //I = c.I,
                                //PartyC = c.PartyC,
                                //PartyI = c.PartyI,
                                //ContactC = c.ContactC,
                                //ContactI = c.ContactI,
                                //CaseC = c.CaseC,
                                //CaseI = c.CaseI,
                                PackedData = c.PackedData,
                                //EnvelopId = c.EnvelopId,
                                //Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                //LastUpdated = c.LastUpdated,
                                //Description = c.Description,
                                //KeyDocument = c.KeyDocument,
                                //EffectiveFrom = c.EffectiveFrom,
                                //EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                //UpdatedBy = c.UpdatedBy,
                                Status = c.Status,
                                ClaimNumber = c.ClaimNumber,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "CreatedBy":
                            query = query.Where(c => c.CreatedBy!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Note1>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaginatedList<ContactDetail>> SearchContactDetail(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ContactDetail> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ContactDetails
                            orderby c.Id ascending
                            select new ContactDetail
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ContactMediumPartyC = c.ContactMediumPartyC,
                                ContactMediumPartyI = c.ContactMediumPartyI,
                                PartyAddressPartyC = c.PartyAddressPartyC,
                                PartyAddressPartyI = c.PartyAddressPartyI,
                                Status = c.Status,
                                Email = c.Email,
                                SendEmailTo = c.SendEmailTo,
                                ContactMethod = c.ContactMethod,
                                ContactTime = c.ContactTime,
                                Verificaton = c.Verificaton,
                                IntCode = c.IntCode,
                                AreaCode = c.AreaCode,
                                TelNo = c.TelNo,
                                ExtnNo = c.ExtnNo,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ContactMediumPartyC":
                    //        query = query.Where(c => c.ContactMediumPartyC!.Contains(search));
                    //        break;
                    //    case "ContactMediumPartyI":
                    //        query = query.Where(c => c.ContactMediumPartyI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ContactDetail>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ContactDetail> GetContactDetail(string id)
        {
            ContactDetail item = null!;
            try
            {
                var c = await _context.ContactDetails.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ContactDetail
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ContactMediumPartyC = c.ContactMediumPartyC,
                        ContactMediumPartyI = c.ContactMediumPartyI,
                        PartyAddressPartyC = c.PartyAddressPartyC,
                        PartyAddressPartyI = c.PartyAddressPartyI,
                        Status = c.Status,
                        Email = c.Email,
                        SendEmailTo = c.SendEmailTo,
                        ContactMethod = c.ContactMethod,
                        ContactTime = c.ContactTime,
                        Verificaton = c.Verificaton,
                        IntCode = c.IntCode,
                        AreaCode = c.AreaCode,
                        TelNo = c.TelNo,
                        ExtnNo = c.ExtnNo,
                        IsExDir = c.IsExDir,
                    };
                }
                else
                {
                    item = new ContactDetail();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ContactDetail();
            }

            return item;
        }


        public async Task<PaginatedList<DepartmentUser>> SearchDepartmentUser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<DepartmentUser> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.DepartmentUsers
                            orderby c.Id ascending
                            select new DepartmentUser
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                DepartmentUserC = c.DepartmentUserC,
                                DepartmentUserI = c.DepartmentUserI,
                                Name = c.Name,
                                UserId = c.UserId,
                                UserEnabled = c.UserEnabled,
                                DepartmentDefaultC = c.DepartmentDefaultC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "DepartmentUserC":
                    //        query = query.Where(c => c.DepartmentUserC!.Contains(search));
                    //        break;
                    //    case "DepartmentUserI":
                    //        query = query.Where(c => c.DepartmentUserI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<DepartmentUser>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<DepartmentUser> GetDepartmentUser(string id)
        {
            DepartmentUser item = null!;
            try
            {
                var c = await _context.DepartmentUsers.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new DepartmentUser
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        DepartmentUserC = c.DepartmentUserC,
                        DepartmentUserI = c.DepartmentUserI,
                        Name = c.Name,
                        UserId = c.UserId,
                        UserEnabled = c.UserEnabled,
                        DepartmentDefaultC = c.DepartmentDefaultC,
                        DepartmentDefaultI = c.DepartmentDefaultI,
                    };
                }
                else
                {
                    item = new DepartmentUser();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new DepartmentUser();
            }

            return item;
        }


        public async Task<PaginatedList<Benefit>> SearchBenefit(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<Benefit> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Benefits
                            orderby c.Id ascending
                            //where c.StaffInd == claimflag
                            select new Benefit
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                
                                ClaimNumber = c.ClaimNumber ?? string.Empty,
                                //OverrideClaimIncurredDate = c.OverrideClaimIncurredDate,
                                BenefitStartDate = c.BenefitStartDate,
                                //BenefitEndDate = c.BenefitEndDate,
                                //ProofOfLossDate = c.ProofOfLossDate,
                                //ExpectedBenefitClosureDate = c.ExpectedBenefitClosureDate,
                                //Source = c.Source,
                                //EffectiveDateOfCoverage = c.EffectiveDateOfCoverage,
                                //BenefitExpiryDate = c.BenefitExpiryDate,
                                //WaitingPeriod = c.WaitingPeriod,
                                //WaitingPeriodBasis = c.WaitingPeriodBasis,
                                //FullyRetained = c.FullyRetained,
                                //BenefitDecision = c.BenefitDecision,
                                //BenefitDecisionDate = c.BenefitDecisionDate,
                                //ReasonForBenefitDecision = c.ReasonForBenefitDecision,
                                //BenefitSelected = c.BenefitSelected,
                                //AgreedValue = c.AgreedValue,
                                //ChronicConditionOption = c.ChronicConditionOption,
                                //Day1AccidentOption = c.Day1AccidentOption,
                                //Iar = c.Iar,
                                //OccupationalCategory = c.OccupationalCategory,
                                PasriskOptionCode = c.PasriskOptionCode ?? string.Empty,
                                //PasriskOptionDesc = c.PasriskOptionDesc,
                                //SuperContributionPct = c.SuperContributionPct,
                                //GroupId = c.GroupId,
                                //SubBenefitFlag = c.SubBenefitFlag,
                                //StartDateCalculationType = c.StartDateCalculationType,
                                //EndDateCalculationType = c.EndDateCalculationType,
                                //MaximumBenefitPeriod = c.MaximumBenefitPeriod,
                                //MaximumBenefitPeriodAccident = c.MaximumBenefitPeriodAccident,
                                //MaximumBenefitPeriodHospital = c.MaximumBenefitPeriodHospital,
                                //MaximumBenefitPeriodBasis = c.MaximumBenefitPeriodBasis,
                                //MaximumBenefitPeriodAccidentBasis = c.MaximumBenefitPeriodAccidentBasis,
                                //MaximumBenefitPeriodHospitalBasis = c.MaximumBenefitPeriodHospitalBasis,
                                //SicknessWaitingPeriod = c.SicknessWaitingPeriod,
                                //AccidentWaitingPeriod = c.AccidentWaitingPeriod,
                                //HospitalWaitingPeriod = c.HospitalWaitingPeriod,
                                //WaitingPeriodBasis1 = c.WaitingPeriodBasis1,
                                //AccidentWaitingPeriodBasis = c.AccidentWaitingPeriodBasis,
                                //HospitalWaitingPeriodBasis = c.HospitalWaitingPeriodBasis,
                                SumInsured = c.SumInsured ?? 0,
                                //AgeroundingRule = c.AgeroundingRule,
                                //RoundUnit = c.RoundUnit,
                                //AgeroundingPrecision = c.AgeroundingPrecision,
                                //RoundInstruction = c.RoundInstruction,
                                //MaximumAggregateAmount = c.MaximumAggregateAmount,
                                //MinimumAmount = c.MinimumAmount,
                                //MinimumPercentage = c.MinimumPercentage,
                                //MinimumCalculationType = c.MinimumCalculationType,
                                //AutomaticAcceptanceLimit = c.AutomaticAcceptanceLimit,
                                //DuesCreatedInArrears = c.DuesCreatedInArrears,
                                //MaximumAmount = c.MaximumAmount,
                                //MaximumPercentage = c.MaximumPercentage,
                                //MaximumCalculationType = c.MaximumCalculationType,
                                //Underwritten = c.Underwritten,
                                //ReinsurerLiabilityApprovedToDate = c.ReinsurerLiabilityApprovedToDate,
                                //ToEndOfBenefit = c.ToEndOfBenefit,
                                //IndexationApplies = c.IndexationApplies,
                                AdjustmentTypeName = c.AdjustmentTypeName ?? string.Empty,
                                //EliminationPeriod = c.EliminationPeriod,
                                //EliminationPeriodBasis = c.EliminationPeriodBasis,
                                //MinimumRate = c.MinimumRate,
                                //IndexLeadTime = c.IndexLeadTime,
                                //AdjustBenefit = c.AdjustBenefit,
                                //MaximumRate = c.MaximumRate,
                                //MaximumCumulativeRate = c.MaximumCumulativeRate,
                                //MaxNumberIndexations = c.MaxNumberIndexations,
                                //MinThresholdApplies = c.MinThresholdApplies,
                                //MaxThresholdApplies = c.MaxThresholdApplies,
                                Type = c.Type ?? string.Empty,
                                //ChangeInClaimDefinitionDate = c.ChangeInClaimDefinitionDate,
                                //WhenAnyAllDecisionMade = c.WhenAnyAllDecisionMade,
                                //DateBenefitsWithheld = c.DateBenefitsWithheld,
                                //WhoAuthorizedBenefitsWithheldC = c.WhoAuthorizedBenefitsWithheldC,
                                //WhoAuthorizedBenefitsWithheldI = c.WhoAuthorizedBenefitsWithheldI,
                                //LastUpdateUserNameC = c.LastUpdateUserNameC,
                                //LastUpdateUserNameI = c.LastUpdateUserNameI,
                                //AnyAllReviewDate = c.AnyAllReviewDate,
                                //ReasonBenefitsWithheld = c.ReasonBenefitsWithheld,
                                //OverrideChangeInDefinitionDate = c.OverrideChangeInDefinitionDate,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Type":
                            query = query.Where(c => c.Type!.Contains(search));
                            break;
                        case "PasriskOptionDesc":
                            query = query.Where(c => c.PasriskOptionDesc!.Contains(search));
                            break;
                        case "SumInsured":
                            query = query.Where(c => c.SumInsured.ToString()!.Contains(search));
                            break;
                        case "AdjustmentTypeName":
                            query = query.Where(c => c.AdjustmentTypeName!.Contains(search));
                            break;
                        case "BenefitStartDate":
                            query = query.Where(c => c.BenefitStartDate.ToString()!.Contains(search));
                            break;

                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Benefit>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Benefit> GetBenefit(string id, int appflag = 1)
        {
            Benefit item = null!;
            try
            {
                var c = await _context.Benefits.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Benefit
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        OverrideClaimIncurredDate = c.OverrideClaimIncurredDate,
                        BenefitStartDate = c.BenefitStartDate,
                        BenefitEndDate = c.BenefitEndDate,
                        ProofOfLossDate = c.ProofOfLossDate,
                        ExpectedBenefitClosureDate = c.ExpectedBenefitClosureDate,
                        Source = c.Source,
                        EffectiveDateOfCoverage = c.EffectiveDateOfCoverage,
                        BenefitExpiryDate = c.BenefitExpiryDate,
                        WaitingPeriod = c.WaitingPeriod,
                        WaitingPeriodBasis = c.WaitingPeriodBasis,
                        FullyRetained = c.FullyRetained,
                        BenefitDecision = c.BenefitDecision,
                        BenefitDecisionDate = c.BenefitDecisionDate,
                        ReasonForBenefitDecision = c.ReasonForBenefitDecision,
                        BenefitSelected = c.BenefitSelected,
                        AgreedValue = c.AgreedValue,
                        ChronicConditionOption = c.ChronicConditionOption,
                        Day1AccidentOption = c.Day1AccidentOption,
                        Iar = c.Iar,
                        OccupationalCategory = c.OccupationalCategory,
                        PasriskOptionCode = c.PasriskOptionCode,
                        PasriskOptionDesc = c.PasriskOptionDesc,
                        SuperContributionPct = c.SuperContributionPct,
                        GroupId = c.GroupId,
                        SubBenefitFlag = c.SubBenefitFlag,
                        StartDateCalculationType = c.StartDateCalculationType,
                        EndDateCalculationType = c.EndDateCalculationType,
                        MaximumBenefitPeriod = c.MaximumBenefitPeriod,
                        MaximumBenefitPeriodAccident = c.MaximumBenefitPeriodAccident,
                        MaximumBenefitPeriodHospital = c.MaximumBenefitPeriodHospital,
                        MaximumBenefitPeriodBasis = c.MaximumBenefitPeriodBasis,
                        MaximumBenefitPeriodAccidentBasis = c.MaximumBenefitPeriodAccidentBasis,
                        MaximumBenefitPeriodHospitalBasis = c.MaximumBenefitPeriodHospitalBasis,
                        SicknessWaitingPeriod = c.SicknessWaitingPeriod,
                        AccidentWaitingPeriod = c.AccidentWaitingPeriod,
                        HospitalWaitingPeriod = c.HospitalWaitingPeriod,
                        WaitingPeriodBasis1 = c.WaitingPeriodBasis1,
                        AccidentWaitingPeriodBasis = c.AccidentWaitingPeriodBasis,
                        HospitalWaitingPeriodBasis = c.HospitalWaitingPeriodBasis,
                        SumInsured = c.SumInsured,
                        AgeroundingRule = c.AgeroundingRule,
                        RoundUnit = c.RoundUnit,
                        AgeroundingPrecision = c.AgeroundingPrecision,
                        RoundInstruction = c.RoundInstruction,
                        MaximumAggregateAmount = c.MaximumAggregateAmount,
                        MinimumAmount = c.MinimumAmount,
                        MinimumPercentage = c.MinimumPercentage,
                        MinimumCalculationType = c.MinimumCalculationType,
                        AutomaticAcceptanceLimit = c.AutomaticAcceptanceLimit,
                        DuesCreatedInArrears = c.DuesCreatedInArrears,
                        MaximumAmount = c.MaximumAmount,
                        MaximumPercentage = c.MaximumPercentage,
                        MaximumCalculationType = c.MaximumCalculationType,
                        Underwritten = c.Underwritten,
                        ReinsurerLiabilityApprovedToDate = c.ReinsurerLiabilityApprovedToDate,
                        ToEndOfBenefit = c.ToEndOfBenefit,
                        IndexationApplies = c.IndexationApplies,
                        AdjustmentTypeName = c.AdjustmentTypeName,
                        EliminationPeriod = c.EliminationPeriod,
                        EliminationPeriodBasis = c.EliminationPeriodBasis,
                        MinimumRate = c.MinimumRate,
                        IndexLeadTime = c.IndexLeadTime,
                        AdjustBenefit = c.AdjustBenefit,
                        MaximumRate = c.MaximumRate,
                        MaximumCumulativeRate = c.MaximumCumulativeRate,
                        MaxNumberIndexations = c.MaxNumberIndexations,
                        MinThresholdApplies = c.MinThresholdApplies,
                        MaxThresholdApplies = c.MaxThresholdApplies,
                        Type = c.Type,
                        ChangeInClaimDefinitionDate = c.ChangeInClaimDefinitionDate,
                        WhenAnyAllDecisionMade = c.WhenAnyAllDecisionMade,
                        DateBenefitsWithheld = c.DateBenefitsWithheld,
                        WhoAuthorizedBenefitsWithheldC = c.WhoAuthorizedBenefitsWithheldC,
                        WhoAuthorizedBenefitsWithheldI = c.WhoAuthorizedBenefitsWithheldI,
                        LastUpdateUserNameC = c.LastUpdateUserNameC,
                        LastUpdateUserNameI = c.LastUpdateUserNameI,
                        AnyAllReviewDate = c.AnyAllReviewDate,
                        ReasonBenefitsWithheld = c.ReasonBenefitsWithheld,
                        OverrideChangeInDefinitionDate = c.OverrideChangeInDefinitionDate,
                        AnyAllStatus = c.AnyAllStatus,
                        ApplicationId = c.ApplicationId,
                    };
                }
                else
                {
                    item = new Benefit();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Benefit();
            }

            return item;
        }


        public async Task<PaginatedList<BenefitExclusion>> SearchBenefitExclusion(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<BenefitExclusion> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.BenefitExclusions
                            orderby c.Id ascending
                            select new BenefitExclusion
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                BenefitC = c.BenefitC,
                                BenefitI = c.BenefitI,
                                Type = c.Type,
                                DurationUnit = c.DurationUnit,
                                Duration = c.Duration,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Status = c.Status,
                                LastStatusChanged = c.LastStatusChanged,
                                Description = c.Description,
                                StatusUpdatedByC = c.StatusUpdatedByC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "BenefitC":
                    //        query = query.Where(c => c.BenefitC!.Contains(search));
                    //        break;
                    //    case "BenefitI":
                    //        query = query.Where(c => c.BenefitI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<BenefitExclusion>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<BenefitExclusion> GetBenefitExclusion(string id)
        {
            BenefitExclusion item = null!;
            try
            {
                var c = await _context.BenefitExclusions.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new BenefitExclusion
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        BenefitC = c.BenefitC,
                        BenefitI = c.BenefitI,
                        Type = c.Type,
                        DurationUnit = c.DurationUnit,
                        Duration = c.Duration,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        Status = c.Status,
                        LastStatusChanged = c.LastStatusChanged,
                        Description = c.Description,
                        StatusUpdatedByC = c.StatusUpdatedByC,
                        StatusUpdatedByI = c.StatusUpdatedByI,
                    };
                }
                else
                {
                    item = new BenefitExclusion();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new BenefitExclusion();
            }

            return item;
        }


        public async Task<PaginatedList<BenefitReInsurance>> SearchBenefitReInsurance(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<BenefitReInsurance> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.BenefitReInsurances
                            orderby c.Id ascending
                            select new BenefitReInsurance
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                BenefitC = c.BenefitC,
                                BenefitI = c.BenefitI,
                                ReinsurerName = c.ReinsurerName,
                                ReinsuranceCode = c.ReinsuranceCode,
                                TreatyEffectiveFrom = c.TreatyEffectiveFrom,
                                ExcessPoolAmount = c.ExcessPoolAmount,
                                ReinsuredFromReinsuredAmount = c.ReinsuredFromReinsuredAmount,
                                RetentionSurplusLimit = c.RetentionSurplusLimit,
                                MandatoryReferralLimit = c.MandatoryReferralLimit,
                                ReinsurerNotificationDate = c.ReinsurerNotificationDate,
                                TreatyEffectiveTo = c.TreatyEffectiveTo,
                                ExcessLossFlag = c.ExcessLossFlag,
                                PoolPercentage = c.PoolPercentage,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "BenefitC":
                    //        query = query.Where(c => c.BenefitC!.Contains(search));
                    //        break;
                    //    case "BenefitI":
                    //        query = query.Where(c => c.BenefitI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<BenefitReInsurance>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<BenefitReInsurance> GetBenefitReInsurance(string id)
        {
            BenefitReInsurance item = null!;
            try
            {
                var c = await _context.BenefitReInsurances.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new BenefitReInsurance
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        BenefitC = c.BenefitC,
                        BenefitI = c.BenefitI,
                        ReinsurerName = c.ReinsurerName,
                        ReinsuranceCode = c.ReinsuranceCode,
                        TreatyEffectiveFrom = c.TreatyEffectiveFrom,
                        ExcessPoolAmount = c.ExcessPoolAmount,
                        ReinsuredFromReinsuredAmount = c.ReinsuredFromReinsuredAmount,
                        RetentionSurplusLimit = c.RetentionSurplusLimit,
                        MandatoryReferralLimit = c.MandatoryReferralLimit,
                        ReinsurerNotificationDate = c.ReinsurerNotificationDate,
                        TreatyEffectiveTo = c.TreatyEffectiveTo,
                        ExcessLossFlag = c.ExcessLossFlag,
                        PoolPercentage = c.PoolPercentage,
                        QuotaSharePercentage = c.QuotaSharePercentage,
                    };
                }
                else
                {
                    item = new BenefitReInsurance();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new BenefitReInsurance();
            }

            return item;
        }


        public async Task<PaginatedList<DocumentA>> SearchDocument(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<DocumentA> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Documents
                            //where c.ClaimNumber!.Contains(search)
                            orderby c.DateCreated descending
                            select new DocumentA
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                ContactC = c.ContactC,
                                ContactI = c.ContactI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                EnvelopId = c.EnvelopId,
                                Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                LastUpdated = c.LastUpdated,
                                Description = c.Description,
                                KeyDocument = c.KeyDocument,
                                EffectiveFrom = c.EffectiveFrom,
                                EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                UpdatedBy = c.UpdatedBy,
                                Title = c.Title,
                                FileName = c.FileName,
                                FileType = c.FileType,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "EffectiveFrom":
                            query = query.Where(c => c.EffectiveFrom.ToString()!.Contains(search));
                            break;
                        case "EffectiveTo":
                            query = query.Where(c => c.EffectiveTo.ToString()!.Contains(search));
                            break;


                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<DocumentA>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaginatedList<DocumentA>> SearchDocumentA(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<DocumentA> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Documents
                            orderby c.DateCreated descending
                            //where c.StaffInd == claimflag
                            select new DocumentA
                            {
                                Id = c.Id,
                                //C = c.C,
                                //I = c.I,
                                //PartyC = c.PartyC,
                                //PartyI = c.PartyI,
                                //ContactC = c.ContactC,
                                //ContactI = c.ContactI,
                                //CaseC = c.CaseC,
                                //CaseI = c.CaseI,
                                //EnvelopId = c.EnvelopId,
                                //Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                //LastUpdated = c.LastUpdated,
                                Description = c.Description,
                                //KeyDocument = c.KeyDocument,
                                //EffectiveFrom = c.EffectiveFrom,
                                //EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                //UpdatedBy = c.UpdatedBy,
                                //Title = c.Title,
                                //FileName = c.FileName,
                                //FileType = c.FileType,
                                ClaimNumber = c.ClaimNumber,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "EffectiveFrom":
                            query = query.Where(c => c.EffectiveFrom.ToString()!.Contains(search));
                            break;
                        case "EffectiveTo":
                            query = query.Where(c => c.EffectiveTo.ToString()!.Contains(search));
                            break;


                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<DocumentA>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<DocumentA> GetDocument(string id, int appflag = 1)
        {
            DocumentA item = null!;
            try
            {
                var c = await _context.Documents.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new DocumentA
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ContactC = c.ContactC,
                        ContactI = c.ContactI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        EnvelopId = c.EnvelopId,
                        Tag = c.Tag,
                        DateCreated = c.DateCreated,
                        LastUpdated = c.LastUpdated,
                        Description = c.Description,
                        KeyDocument = c.KeyDocument,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        DocumentType = c.DocumentType,
                        CreatedBy = c.CreatedBy,
                        UpdatedBy = c.UpdatedBy,
                        Title = c.Title,
                        FileName = c.FileName,
                        FileType = c.FileType,
                        ClaimNumber = c.ClaimNumber,
                    };
                }
                else
                {
                    item = new DocumentA();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new DocumentA();
            }

            return item;
        }


        public async Task<PaginatedList<DocumentGroup>> SearchDocumentGroup(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<DocumentGroup> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.DocumentGroups
                            orderby c.Id ascending
                            select new DocumentGroup
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "CaseC":
                    //        query = query.Where(c => c.CaseC!.Contains(search));
                    //        break;
                    //    case "CaseI":
                    //        query = query.Where(c => c.CaseI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<DocumentGroup>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<DocumentGroup> GetDocumentGroup(string id)
        {
            DocumentGroup item = null!;
            try
            {
                var c = await _context.DocumentGroups.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new DocumentGroup
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        DocumentGroup1 = c.DocumentGroup1,
                    };
                }
                else
                {
                    item = new DocumentGroup();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new DocumentGroup();
            }

            return item;
        }


        public async Task<PaginatedList<DocumentGroupLink>> SearchDocumentGroupLink(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<DocumentGroupLink> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.DocumentGroupLinks
                            orderby c.Id ascending
                            select new DocumentGroupLink
                            {
                                Id = c.Id,
                                CFrom = c.CFrom,
                                IFrom = c.IFrom,
                                CTo = c.CTo,
                                ITo = c.ITo,
                                DocumentGroupC = c.DocumentGroupC,
                                DocumentGroupI = c.DocumentGroupI,
                                DocumentC = c.DocumentC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "CFrom":
                    //        query = query.Where(c => c.CFrom!.Contains(search));
                    //        break;
                    //    case "IFrom":
                    //        query = query.Where(c => c.IFrom!.Contains(search));
                    //        break;
                    //    case "CTo":
                    //        query = query.Where(c => c.CTo!.Contains(search));
                    //        break;
                    //    case "ITo":
                    //        query = query.Where(c => c.ITo!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<DocumentGroupLink>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<DocumentGroupLink> GetDocumentGroupLink(string id)
        {
            DocumentGroupLink item = null!;
            try
            {
                var c = await _context.DocumentGroupLinks.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new DocumentGroupLink
                    {
                        Id = c.Id,
                        CFrom = c.CFrom,
                        IFrom = c.IFrom,
                        CTo = c.CTo,
                        ITo = c.ITo,
                        DocumentGroupC = c.DocumentGroupC,
                        DocumentGroupI = c.DocumentGroupI,
                        DocumentC = c.DocumentC,
                        DocumentI = c.DocumentI,
                    };
                }
                else
                {
                    item = new DocumentGroupLink();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new DocumentGroupLink();
            }

            return item;
        }


        public async Task<PaginatedList<DocumentUser>> SearchDocumentUser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<DocumentUser> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.DocumentUsers
                            orderby c.Id ascending
                            select new DocumentUser
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                UserName = c.UserName,
                                UserId = c.UserId,
                                UserEnabled = c.UserEnabled,
                                DepartmentDefaultC = c.DepartmentDefaultC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "UserName":
                    //        query = query.Where(c => c.UserName!.Contains(search));
                    //        break;
                    //    case "UserId":
                    //        query = query.Where(c => c.UserId!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<DocumentUser>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<DocumentUser> GetDocumentUser(string id)
        {
            DocumentUser item = null!;
            try
            {
                var c = await _context.DocumentUsers.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new DocumentUser
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        UserName = c.UserName,
                        UserId = c.UserId,
                        UserEnabled = c.UserEnabled,
                        DepartmentDefaultC = c.DepartmentDefaultC,
                        DepartmentDefaultI = c.DepartmentDefaultI,
                    };
                }
                else
                {
                    item = new DocumentUser();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new DocumentUser();
            }

            return item;
        }


        public async Task<PaginatedList<Earning>> SearchEarning(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Earning> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Earnings
                            orderby c.Id ascending
                            select new Earning
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                OccupationC = c.OccupationC,
                                OccupationI = c.OccupationI,
                                Type = c.Type,
                                EffectiveFrom = c.EffectiveFrom,
                                EffectiveTo = c.EffectiveTo,
                                ActualGross = c.ActualGross,
                                SalaryAmountBasis = c.SalaryAmountBasis,
                                AdditionalNotes = c.AdditionalNotes,
                                BiWeekly = c.BiWeekly,
                                SemiMonthly = c.SemiMonthly,
                                Monthly = c.Monthly,
                                Yearly = c.Yearly,
                                Yearly1 = c.Yearly1,
                                StandardHours = c.StandardHours,
                                OverrideWeeklyEarnings = c.OverrideWeeklyEarnings,
                                OvertimeHours = c.OvertimeHours,
                                OvertimeHourlyRate = c.OvertimeHourlyRate,
                                StandardEarnings = c.StandardEarnings,
                                VacationStatutoryTime = c.VacationStatutoryTime,
                                VacationStatutoryEarnings = c.VacationStatutoryEarnings,
                                ShiftHours = c.ShiftHours,
                                ShiftDifferential = c.ShiftDifferential,
                                ShiftPay = c.ShiftPay,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "OccupationC":
                    //        query = query.Where(c => c.OccupationC!.Contains(search));
                    //        break;
                    //    case "OccupationI":
                    //        query = query.Where(c => c.OccupationI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<Earning>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Earning> GetEarning(string id)
        {
            Earning item = null!;
            try
            {
                var c = await _context.Earnings.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Earning
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        OccupationC = c.OccupationC,
                        OccupationI = c.OccupationI,
                        Type = c.Type,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        ActualGross = c.ActualGross,
                        SalaryAmountBasis = c.SalaryAmountBasis,
                        AdditionalNotes = c.AdditionalNotes,
                        BiWeekly = c.BiWeekly,
                        SemiMonthly = c.SemiMonthly,
                        Monthly = c.Monthly,
                        Yearly = c.Yearly,
                        Yearly1 = c.Yearly1,
                        StandardHours = c.StandardHours,
                        OverrideWeeklyEarnings = c.OverrideWeeklyEarnings,
                        OvertimeHours = c.OvertimeHours,
                        OvertimeHourlyRate = c.OvertimeHourlyRate,
                        StandardEarnings = c.StandardEarnings,
                        VacationStatutoryTime = c.VacationStatutoryTime,
                        VacationStatutoryEarnings = c.VacationStatutoryEarnings,
                        ShiftHours = c.ShiftHours,
                        ShiftDifferential = c.ShiftDifferential,
                        ShiftPay = c.ShiftPay,
                        ShiftEarnings = c.ShiftEarnings,
                    };
                }
                else
                {
                    item = new Earning();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Earning();
            }

            return item;
        }


        public async Task<PaginatedList<Goal>> SearchGoal(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Goal> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Goals
                            orderby c.Id ascending
                            select new Goal
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClientGoalC = c.ClientGoalC,
                                ClientGoalI = c.ClientGoalI,
                                LifeAreaC = c.LifeAreaC,
                                LifeAreaI = c.LifeAreaI,
                                StrategyName = c.StrategyName,
                                SummarySnapshot = c.SummarySnapshot,
                                CustomerStrategyStatus = c.CustomerStrategyStatus,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClientGoalC":
                    //        query = query.Where(c => c.ClientGoalC!.Contains(search));
                    //        break;
                    //    case "ClientGoalI":
                    //        query = query.Where(c => c.ClientGoalI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<Goal>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Goal> GetGoal(string id)
        {
            Goal item = null!;
            try
            {
                var c = await _context.Goals.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Goal
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClientGoalC = c.ClientGoalC,
                        ClientGoalI = c.ClientGoalI,
                        LifeAreaC = c.LifeAreaC,
                        LifeAreaI = c.LifeAreaI,
                        StrategyName = c.StrategyName,
                        SummarySnapshot = c.SummarySnapshot,
                        CustomerStrategyStatus = c.CustomerStrategyStatus,
                        TargetDate = c.TargetDate,
                    };
                }
                else
                {
                    item = new Goal();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Goal();
            }

            return item;
        }


        public async Task<PaginatedList<LifeArea>> SearchLifeArea(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<LifeArea> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.LifeAreas
                            orderby c.Id ascending
                            select new LifeArea
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                Factors = c.Factors,
                                FactorStatus = c.FactorStatus,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "CaseC":
                    //        query = query.Where(c => c.CaseC!.Contains(search));
                    //        break;
                    //    case "CaseI":
                    //        query = query.Where(c => c.CaseI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<LifeArea>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<LifeArea> GetLifeArea(string id)
        {
            LifeArea item = null!;
            try
            {
                var c = await _context.LifeAreas.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new LifeArea
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        Factors = c.Factors,
                        FactorStatus = c.FactorStatus,
                        Notes = c.Notes,
                    };
                }
                else
                {
                    item = new LifeArea();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new LifeArea();
            }

            return item;
        }


        public async Task<PaginatedList<MedicalCode>> SearchMedicalCode(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<MedicalCode> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.MedicalCodes
                            orderby c.Id ascending
                            select new MedicalCode
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                ClaimNumber = c.ClaimNumber,
                                MedicalCondition = c.MedicalCondition,
                                DateOfFirstTreatment = c.DateOfFirstTreatment,
                                LifeExpectancy = c.LifeExpectancy,
                                Diagnosis = c.Diagnosis,
                                DateOfDiagnosis = c.DateOfDiagnosis,
                                DateOfFirstConsultation = c.DateOfFirstConsultation,
                                CustomerDominantSide = c.CustomerDominantSide,
                                ImpactOnActivityLevels = c.ImpactOnActivityLevels,
                                Description = c.Description,
                                Level = c.Level,
                                Type = c.Type,
                                Code = c.Code,
                                Severity = c.Severity,
                                Status = c.Status,
                                EffectiveFrom = c.EffectiveFrom,
                                PreExistingCondition = c.PreExistingCondition,
                                LevelIndicator = c.LevelIndicator,
                                DurationClass = c.DurationClass,
                                BodySide = c.BodySide,
                                BodyLocation = c.BodyLocation,
                                EffectiveTo = c.EffectiveTo,
                                Comment = c.Comment,
                                RequestDate = c.RequestDate,
                                ApprovalDate = c.ApprovalDate,
                                ApplicationId = c.ApplicationId,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Type":
                            query = query.Where(c => c.Type!.Contains(search));
                            break;
                        case "Code":
                            query = query.Where(c => c.Code!.Contains(search));
                            break;
                        case "EffectiveFrom":
                            query = query.Where(c => c.EffectiveFrom!.ToString()!.Contains(search));
                            break;
                        case "Status":
                            query = query.Where(c => c.Status!.ToString()!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<MedicalCode>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<MedicalCode> GetMedicalCode(string id, int appflag = 1)
        {
            MedicalCode item = null!;
            try
            {
                var c = await _context.MedicalCodes.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new MedicalCode
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        MedicalCondition = c.MedicalCondition,
                        DateOfFirstTreatment = c.DateOfFirstTreatment,
                        LifeExpectancy = c.LifeExpectancy,
                        Diagnosis = c.Diagnosis,
                        DateOfDiagnosis = c.DateOfDiagnosis,
                        DateOfFirstConsultation = c.DateOfFirstConsultation,
                        CustomerDominantSide = c.CustomerDominantSide,
                        ImpactOnActivityLevels = c.ImpactOnActivityLevels,
                        Description = c.Description,
                        Level = c.Level,
                        Type = c.Type,
                        Code = c.Code,
                        Severity = c.Severity,
                        Status = c.Status,
                        EffectiveFrom = c.EffectiveFrom,
                        PreExistingCondition = c.PreExistingCondition,
                        LevelIndicator = c.LevelIndicator,
                        DurationClass = c.DurationClass,
                        BodySide = c.BodySide,
                        BodyLocation = c.BodyLocation,
                        EffectiveTo = c.EffectiveTo,
                        Comment = c.Comment,
                        RequestDate = c.RequestDate,
                        ApprovalDate = c.ApprovalDate,
                        Source = c.Source,
                    };
                }
                else
                {
                    item = new MedicalCode();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new MedicalCode();
            }

            return item;
        }


        public async Task<PaginatedList<Note2>> SearchNote2(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<Note2> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Note2s
                                //join a in _context.Cases on new { c.CaseC, c.CaseI } equals new { a.CaseC, a.CaseI }
                                //where a.CaseNumber!.Contains(search)
                            where c.ClaimNumber!.Contains(search)
                            orderby c.DateCreated descending
                            select new Note2
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                //PartyC = c.PartyC,
                                //PartyI = c.PartyI,
                                //ContactC = c.ContactC,
                                //ContactI = c.ContactI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                PackedData = c.PackedData,
                                EnvelopId = c.EnvelopId,
                                Tag = c.Tag,
                                DateCreated = c.DateCreated,
                                LastUpdated = c.LastUpdated,
                                Description = c.Description,
                                //KeyDocument = c.KeyDocument,
                                //EffectiveFrom = c.EffectiveFrom,
                                //EffectiveTo = c.EffectiveTo,
                                DocumentType = c.DocumentType,
                                CreatedBy = c.CreatedBy,
                                Status = c.Status,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "DateCreated":
                            query = query.Where(c => c.DateCreated.ToString()!.Contains(search));
                            break;
                        case "CreatedBy":
                            query = query.Where(c => c.CreatedBy!.Contains(search));
                            break;
                        case "DocumentType":
                            query = query.Where(c => c.DocumentType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Note2>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Note2> GetNote2(string id, int appflag = 1)
        {
            Note2 item = null!;
            try
            {
                var c = await _context.Note2s.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Note2
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ContactC = c.ContactC,
                        ContactI = c.ContactI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        PackedData = c.PackedData,
                        EnvelopId = c.EnvelopId,
                        Tag = c.Tag,
                        DateCreated = c.DateCreated,
                        LastUpdated = c.LastUpdated,
                        Description = c.Description,
                        KeyDocument = c.KeyDocument,
                        EffectiveFrom = c.EffectiveFrom,
                        EffectiveTo = c.EffectiveTo,
                        DocumentType = c.DocumentType,
                        CreatedBy = c.CreatedBy,
                        UpdatedBy = c.UpdatedBy,
                        Status = c.Status,
                        ClaimNumber = c.ClaimNumber,
                        ApplicationId = c.ApplicationId,
                    };
                }
                else
                {
                    item = new Note2();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Note2();
            }

            return item;
        }


        public async Task<PaginatedList<OutstandingRequest>> SearchOutstandingRequest(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<OutstandingRequest> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.OutstandingRequests
                            orderby c.DateCreated descending
                            select new OutstandingRequest
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PartySourceC = c.PartySourceC,
                                PartySourceI = c.PartySourceI,
                                PartySubjectC = c.PartySubjectC,
                                PartySubjectI = c.PartySubjectI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                ProcessC = c.ProcessC,
                                ProcessI = c.ProcessI,
                                TaskC = c.TaskC,
                                TaskI = c.TaskI,
                                DocumentC = c.DocumentC,
                                DocumentI = c.DocumentI,
                                Type = c.Type,
                                DateCreated = c.DateCreated,
                                CreatedBy = c.CreatedBy,
                                LastFollowedUpBy = c.LastFollowedUpBy,
                                NextFollowUpDate = c.NextFollowUpDate,
                                Description = c.Description,
                                Category = c.Category,
                                CreationDate = c.CreationDate,
                                Status = c.Status,
                                DateRequested = c.DateRequested,
                                RequestedBy = c.RequestedBy,
                                DateLastFollowedUp = c.DateLastFollowedUp,
                                NotProceedingWithDate = c.NotProceedingWithDate,
                                DateCompleted = c.DateCompleted,
                                CompletionReason = c.CompletionReason,
                                CompletionNotes = c.CompletionNotes,
                                DateSuppressed = c.DateSuppressed,
                                SuppressionReason = c.SuppressionReason,
                                SuppressionNotes = c.SuppressionNotes,
                                SuppressedBy = c.SuppressedBy,
                                UserCreated = c.UserCreated,
                                UserLastUpdated = c.UserLastUpdated,
                                UpdatedBy = c.UpdatedBy,
                                SelectedCategory = c.SelectedCategory,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<OutstandingRequest>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<OutstandingRequest> GetOutstandingRequest(string id)
        {
            OutstandingRequest item = null!;
            try
            {
                var c = await _context.OutstandingRequests.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new OutstandingRequest
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PartySourceC = c.PartySourceC,
                        PartySourceI = c.PartySourceI,
                        PartySubjectC = c.PartySubjectC,
                        PartySubjectI = c.PartySubjectI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        ProcessC = c.ProcessC,
                        ProcessI = c.ProcessI,
                        TaskC = c.TaskC,
                        TaskI = c.TaskI,
                        DocumentC = c.DocumentC,
                        DocumentI = c.DocumentI,
                        Type = c.Type,
                        DateCreated = c.DateCreated,
                        CreatedBy = c.CreatedBy,
                        LastFollowedUpBy = c.LastFollowedUpBy,
                        NextFollowUpDate = c.NextFollowUpDate,
                        Description = c.Description,
                        Category = c.Category,
                        CreationDate = c.CreationDate,
                        Status = c.Status,
                        DateRequested = c.DateRequested,
                        RequestedBy = c.RequestedBy,
                        DateLastFollowedUp = c.DateLastFollowedUp,
                        NotProceedingWithDate = c.NotProceedingWithDate,
                        DateCompleted = c.DateCompleted,
                        CompletionReason = c.CompletionReason,
                        CompletionNotes = c.CompletionNotes,
                        DateSuppressed = c.DateSuppressed,
                        SuppressionReason = c.SuppressionReason,
                        SuppressionNotes = c.SuppressionNotes,
                        SuppressedBy = c.SuppressedBy,
                        UserCreated = c.UserCreated,
                        UserLastUpdated = c.UserLastUpdated,
                        UpdatedBy = c.UpdatedBy,
                        SelectedCategory = c.SelectedCategory,
                        SelectedType = c.SelectedType,
                    };
                }
                else
                {
                    item = new OutstandingRequest();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new OutstandingRequest();
            }

            return item;
        }


        public async Task<PaginatedList<OutstandingRequestDocument>> SearchOutstandingRequestDocument(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<OutstandingRequestDocument> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.OutstandingRequestDocuments
                            orderby c.Id ascending
                            select new OutstandingRequestDocument
                            {
                                Id = c.Id,
                                CFrom = c.CFrom,
                                IFrom = c.IFrom,
                                CTo = c.CTo,
                                ITo = c.ITo,
                                OutstandingRqtC = c.OutstandingRqtC,
                                OutstandingRqtI = c.OutstandingRqtI,
                                DocumentC = c.DocumentC,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "CFrom":
                    //        query = query.Where(c => c.CFrom!.Contains(search));
                    //        break;
                    //    case "IFrom":
                    //        query = query.Where(c => c.IFrom!.Contains(search));
                    //        break;
                    //    case "CTo":
                    //        query = query.Where(c => c.CTo!.Contains(search));
                    //        break;
                    //    case "ITo":
                    //        query = query.Where(c => c.ITo!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<OutstandingRequestDocument>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<OutstandingRequestDocument> GetOutstandingRequestDocument(string id)
        {
            OutstandingRequestDocument item = null!;
            try
            {
                var c = await _context.OutstandingRequestDocuments.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new OutstandingRequestDocument
                    {
                        Id = c.Id,
                        CFrom = c.CFrom,
                        IFrom = c.IFrom,
                        CTo = c.CTo,
                        ITo = c.ITo,
                        OutstandingRqtC = c.OutstandingRqtC,
                        OutstandingRqtI = c.OutstandingRqtI,
                        DocumentC = c.DocumentC,
                        DocumentI = c.DocumentI,
                    };
                }
                else
                {
                    item = new OutstandingRequestDocument();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new OutstandingRequestDocument();
            }

            return item;
        }


        public async Task<PaginatedList<OutstandingRequestHistory>> SearchOutstandingRequestHistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<OutstandingRequestHistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.OutstandingRequestHistories
                            orderby c.Id ascending
                            select new OutstandingRequestHistory
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                OutstandingRqtC = c.OutstandingRqtC,
                                OutstandingRqtI = c.OutstandingRqtI,
                                Status = c.Status,
                                UpdatedDate = c.UpdatedDate,
                                CompletionNotes = c.CompletionNotes,
                                ReasonForCompletion = c.ReasonForCompletion,
                                SupressionNotes = c.SupressionNotes,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "OutstandingRqtC":
                    //        query = query.Where(c => c.OutstandingRqtC!.Contains(search));
                    //        break;
                    //    case "OutstandingRqtI":
                    //        query = query.Where(c => c.OutstandingRqtI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<OutstandingRequestHistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<OutstandingRequestHistory> GetOutstandingRequestHistory(string id)
        {
            OutstandingRequestHistory item = null!;
            try
            {
                var c = await _context.OutstandingRequestHistories.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new OutstandingRequestHistory
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        OutstandingRqtC = c.OutstandingRqtC,
                        OutstandingRqtI = c.OutstandingRqtI,
                        Status = c.Status,
                        UpdatedDate = c.UpdatedDate,
                        CompletionNotes = c.CompletionNotes,
                        ReasonForCompletion = c.ReasonForCompletion,
                        SupressionNotes = c.SupressionNotes,
                        ReasonForSuppression = c.ReasonForSuppression,
                    };
                }
                else
                {
                    item = new OutstandingRequestHistory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new OutstandingRequestHistory();
            }

            return item;
        }


        public async Task<PaginatedList<Process>> SearchProcess(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Process> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Processes
                            orderby c.Id ascending
                            select new Process
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                DocumentC = c.DocumentC,
                                DocumentI = c.DocumentI,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                PlicyC = c.PlicyC,
                                PlicyI = c.PlicyI,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                ProcessC = c.ProcessC,
                                ProcessI = c.ProcessI,
                                TaskC = c.TaskC,
                                TaskI = c.TaskI,
                                Status = c.Status,
                                CaseManager = c.CaseManager,
                                InDepartment = c.InDepartment,
                                Role = c.Role,
                                TargetDate = c.TargetDate,
                                WorkType = c.WorkType,
                                Description = c.Description,
                                AssignedTo = c.AssignedTo,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "DocumentC":
                    //        query = query.Where(c => c.DocumentC!.Contains(search));
                    //        break;
                    //    case "DocumentI":
                    //        query = query.Where(c => c.DocumentI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<Process>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Process> GetProcess(string id)
        {
            Process item = null!;
            try
            {
                var c = await _context.Processes.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Process
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        DocumentC = c.DocumentC,
                        DocumentI = c.DocumentI,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        PlicyC = c.PlicyC,
                        PlicyI = c.PlicyI,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        ProcessC = c.ProcessC,
                        ProcessI = c.ProcessI,
                        TaskC = c.TaskC,
                        TaskI = c.TaskI,
                        Status = c.Status,
                        CaseManager = c.CaseManager,
                        InDepartment = c.InDepartment,
                        Role = c.Role,
                        TargetDate = c.TargetDate,
                        WorkType = c.WorkType,
                        Description = c.Description,
                        AssignedTo = c.AssignedTo,
                        CreatedBy = c.CreatedBy,
                    };
                }
                else
                {
                    item = new Process();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Process();
            }

            return item;
        }


        public async Task<PaginatedList<ProcessHistory>> SearchProcessHistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ProcessHistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ProcessHistories
                            orderby c.Id ascending
                            select new ProcessHistory
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ProcessC = c.ProcessC,
                                ProcessI = c.ProcessI,
                                Reason = c.Reason,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ProcessC":
                    //        query = query.Where(c => c.ProcessC!.Contains(search));
                    //        break;
                    //    case "ProcessI":
                    //        query = query.Where(c => c.ProcessI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ProcessHistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ProcessHistory> GetProcessHistory(string id)
        {
            ProcessHistory item = null!;
            try
            {
                var c = await _context.ProcessHistories.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ProcessHistory
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ProcessC = c.ProcessC,
                        ProcessI = c.ProcessI,
                        Reason = c.Reason,
                        ActionDate = c.ActionDate,
                    };
                }
                else
                {
                    item = new ProcessHistory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ProcessHistory();
            }

            return item;
        }


        public async Task<PaginatedList<TaskA>> SearchTaskA(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<TaskA> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                //var claimno = new SqlParameter("@pClaimNumber", search);
                var query = from c in _context.Tasks
                            //where c.ClaimNumber == search
                            orderby c.Target descending
                            select new TaskA
                            {
                                Id = c.Id,
                                //C = c.C,
                                //I = c.I,
                                //DocumentC = c.DocumentC,
                                //DocumentI = c.DocumentI,
                                //PartyC = c.PartyC,
                                //PartyI = c.PartyI,
                                //PlicyC = c.PlicyC,
                                //PlicyI = c.PlicyI,
                                //ProcessC = c.ProcessC,
                                //ProcessI = c.ProcessI,
                                //TaskC = c.TaskC,
                                //TaskI = c.TaskI,
                                TaskType = c.TaskType,
                                Status = c.Status,
                                //Target = c.Target,
                                Description = c.Description,
                                //OriginalTargetDate = c.OriginalTargetDate,
                                //Priority = c.Priority,
                                //Subject = c.Subject,
                                //Assignee = c.Assignee,
                                //OnHoldUntil = c.OnHoldUntil,
                                //CreatedBy = c.CreatedBy,
                                //DefaultDepartment = c.DefaultDepartment,
                                CreationDate1 = c.CreationDate,
                                //TargetDate = c.Target,
                                //LastUpdateDate = c.LastUpdateDate,
                                //UpdatedBy = c.UpdatedBy,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,
                            };

                if (column == "ClaimNumber" && !string.IsNullOrEmpty(search))
                {
                    query = query.Where(c => c.ClaimNumber == search);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        //case "ClaimNumber":
                        //    query = query.Where(c => c.ClaimNumber!.Contains(search));
                        //    break;
                        case "TaskType":
                            query = query.Where(c => c.TaskType!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "CreationDate":
                            query = query.Where(c => c.CreationDate.ToString()!.Contains(search));
                            break;
                        case "CreatedBy":
                            query = query.Where(c => c.CreatedBy!.Contains(search));
                            break;


                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<TaskA>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                list = new PaginatedList<TaskA>(null!, 1, 1, 1);
            }
            return list;
        }

        public async Task<TaskA> GetTaskA(string id)
        {
            TaskA item = null!;
            try
            {
                var c = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new TaskA
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        DocumentC = c.DocumentC,
                        DocumentI = c.DocumentI,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        PlicyC = c.PlicyC,
                        PlicyI = c.PlicyI,
                        ProcessC = c.ProcessC,
                        ProcessI = c.ProcessI,
                        TaskC = c.TaskC,
                        TaskI = c.TaskI,
                        TaskType = c.TaskType,
                        Status = c.Status,
                        Target = c.Target,
                        Description = c.Description,
                        OriginalTargetDate = c.OriginalTargetDate,
                        Priority = c.Priority,
                        Subject = c.Subject,
                        Assignee = c.Assignee,
                        OnHoldUntil = c.OnHoldUntil,
                        CreatedBy = c.CreatedBy,
                        DefaultDepartment = c.DefaultDepartment,
                        CreationDate = c.CreationDate,
                        CreationDate1 = c.CreationDate1,
                        TargetDate = c.TargetDate,
                        LastUpdateDate = c.LastUpdateDate,
                        UpdatedBy = c.UpdatedBy,
                        ClaimNumber = c.ClaimNumber
                    };
                }
                else
                {
                    item = new TaskA();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new TaskA();
            }

            return item;
        }


        public async Task<PaginatedList<TaskHistory>> SearchTaskHistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<TaskHistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.TaskHistories
                            orderby c.Id ascending
                            select new TaskHistory
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                TaskC = c.TaskC,
                                TaskI = c.TaskI,
                                ActionedBy = c.ActionedBy,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "TaskC":
                    //        query = query.Where(c => c.TaskC!.Contains(search));
                    //        break;
                    //    case "TaskI":
                    //        query = query.Where(c => c.TaskI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<TaskHistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<TaskHistory> GetTaskHistory(string id)
        {
            TaskHistory item = null!;
            try
            {
                var c = await _context.TaskHistories.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new TaskHistory
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        TaskC = c.TaskC,
                        TaskI = c.TaskI,
                        ActionedBy = c.ActionedBy,
                        ActionedDate = c.ActionedDate,
                    };
                }
                else
                {
                    item = new TaskHistory();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new TaskHistory();
            }

            return item;
        }

        public async Task<GeneralClaim> GetGeneralClaim(string id)
        {
            GeneralClaim item = null!;
            try
            {
                item.mCase = await GetCaseByClaimNo(id);
                item.mClaim = await GetClaimByClaimNumber(id);
                item.mCaseParty = await GetCaseParty(id);
                item.mParty = await GetParty(id);
                item.mPartyAddress = await GetPartyAddress(id);
                item.mDocument = await GetDocument(id);
                item.mProcess = await GetProcess(id);
                item.mContactDetail = await GetContactDetail(id);
                item.mDepartmentUser = await GetDepartmentUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new GeneralClaim();
            }

            return item;
        }

        public async Task<PaginatedList<Policy>> SearchPolicy(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<Policy> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Policies
                            orderby c.Id ascending
                            select new Policy
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PolicyNumber = c.PolicyNumber,
                                Product = c.Product,
                                ProductName = c.ProductName,
                                ContractStatus = c.ContractStatus,
                                ContractStatusName = c.ContractStatusName,
                                SourceSystem = c.SourceSystem,
                                SourceSystemName = c.SourceSystemName,
                                StartDate = c.StartDate,
                                TerminationDate = c.TerminationDate,
                                ApplicationId = c.ApplicationId
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "ProductName":
                            query = query.Where(c => c.ProductName!.Contains(search));
                            break;
                        case "StartDate":
                            query = query.Where(c => c.StartDate.ToString()!.Contains(search));
                            break;
                        case "TerminationDate":
                            query = query.Where(c => c.TerminationDate.ToString()!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Policy>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Policy> GetPolicy(string id, int appflag = 1)
        {
            Policy item = null!;
            try
            {
                var c = await _context.Policies.FirstOrDefaultAsync(m => m.PolicyNumber == id);
                if (c != null)
                {
                    item = new Policy
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PolicyNumber = c.PolicyNumber,
                        Product = c.Product,
                        ProductName = c.ProductName,
                        ContractStatus = c.ContractStatus,
                        ContractStatusName = c.ContractStatusName,
                        SourceSystem = c.SourceSystem,
                        SourceSystemName = c.SourceSystemName,
                        StartDate = c.StartDate,
                        TerminationDate = c.TerminationDate,
                        EffectiveDate = c.EffectiveDate,
                        ApplicationId = c.ApplicationId
                    };
                }
                else
                {
                    item = new Policy();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Policy();
            }

            return item;
        }

        public async Task<PaginatedList<PolicySearch>> SearchPolicySearch(string column, string search, int pageIndex = 1, int pageSize = 25, int claimflag = 0, int appflag = 1)
        {
            PaginatedList<PolicySearch> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.PolicySearches
                            orderby c.Id ascending
                            //where c.StaffInd == claimflag
                            select new PolicySearch
                            {
                                Id = c.Id,
                                ClaimNumber = c.ClaimNumber,
                                PolicyNumber = c.PolicyNumber,
                                ProductName = c.ProductName,
                                ContractStatusName = c.ContractStatusName,
                                StartDate = c.StartDate,
                                TerminationDate = c.TerminationDate,
                                StaffInd = c.StaffInd,
                                ApplicationId = c.ApplicationId,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "PolicyNumber":
                            query = query.Where(c => c.PolicyNumber!.Contains(search));
                            break;
                        case "ProductName":
                            query = query.Where(c => c.ProductName!.Contains(search));
                            break;
                        case "StartDate":
                            query = query.Where(c => c.StartDate.ToString()!.Contains(search));
                            break;
                        case "TerminationDate":
                            query = query.Where(c => c.TerminationDate.ToString()!.Contains(search));
                            break;
                    }
                }

                if (claimflag == 0)
                {
                    query = query.Where(c => c.StaffInd == 0);
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<PolicySearch>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<PaginatedList<Contact>> SearchContact(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<Contact> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Contacts
                            //where c.ClaimNumber == search
                            orderby c.ClaimNumber ascending
                            select new Contact
                            {
                                Id = c.Id,
                                //C = c.C,
                                //I = c.I,
                                //CaseC = c.CaseC,
                                //CaseI = c.CaseI,
                                DateTime = c.DateTime,
                                Reason = c.Reason,
                                Method = c.Method,
                                //Direction = c.Direction,
                                ContactSuccessful = c.ContactSuccessful,
                                Description = c.Description,
                                //MethodOfContact = c.MethodOfContact,
                                //CustomerRepresentative = c.CustomerRepresentative,
                                //PhoneRecordingLink = c.PhoneRecordingLink,
                                //User = c.User,
                                //ContactDuration = c.ContactDuration,
                                //PrivacyTag = c.PrivacyTag,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "Reason":
                            query = query.Where(c => c.Reason!.Contains(search));
                            break;
                        case "Method":
                            query = query.Where(c => c.Method!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "DateTime":
                            query = query.Where(c => c.DateTime.ToString()!.Contains(search));
                            break;


                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<Contact>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Contact> GetContact(string id, int appflag = 1)
        {
            Contact item = null!;
            try
            {
                var c = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Contact
                    {
                        Id = c.Id,                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        DateTime = c.DateTime,
                        Reason = c.Reason,
                        Method = c.Method,
                        Direction = c.Direction,
                        ContactSuccessful = c.ContactSuccessful,
                        Description = c.Description,
                        MethodOfContact = c.MethodOfContact,
                        CustomerRepresentative = c.CustomerRepresentative,
                        PhoneRecordingLink = c.PhoneRecordingLink,
                        User = c.User,
                        ContactDuration = c.ContactDuration,
                        PrivacyTag = c.PrivacyTag,
                        DealtWithBy = c.DealtWithBy,
                    };
                }
                else
                {
                    item = new Contact();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Contact();
            }

            return item;
        }

        public async Task<PaginatedList<CoverageSearch>> SearchCoverageSearch(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<CoverageSearch> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.CoverageSearches
                            orderby c.Pid ascending
                            select new CoverageSearch
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                PolicyNumber = c.PolicyNumber,
                                Product = c.Product,
                                ProductName = c.ProductName,
                                ContractStatus = c.ContractStatus,
                                ContractStatusName = c.ContractStatusName,
                                SourceSystem = c.SourceSystem,
                                SourceSystemName = c.SourceSystemName,
                                StartDate = c.StartDate,
                                TerminationDate = c.TerminationDate,
                                EffectiveDate = c.EffectiveDate,
                                ClaimPolicyC = c.ClaimPolicyC,
                                ClaimPolicyI = c.ClaimPolicyI,
                                Coverage = c.Coverage,
                                CoverageCode = c.CoverageCode,
                                Status = c.Status,
                                EffectiveDate1 = c.EffectiveDate1,
                                ClaimPolicyCoverageC = c.ClaimPolicyCoverageC,
                                ClaimPolicyCoverageI = c.ClaimPolicyCoverageI,
                                Type = c.Type,
                                BenefitEntitlementDescription = c.BenefitEntitlementDescription,
                                BenefitSelected = c.BenefitSelected,
                                PasriskOptionCode = c.PasriskOptionCode,
                                ClaimNumber = c.ClaimNumber,
                                ApplicationId = c.ApplicationId,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<CoverageSearch>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<CoverageSearch> GetCoverageSearch(string id, int appflag = 1)
        {
            CoverageSearch item = null!;
            try
            {
                var c = await _context.CoverageSearches.FirstOrDefaultAsync(m => m.ClaimNumber == id);
                if (c != null)
                {
                    item = new CoverageSearch
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        PolicyNumber = c.PolicyNumber,
                        Product = c.Product,
                        ProductName = c.ProductName,
                        ContractStatus = c.ContractStatus,
                        ContractStatusName = c.ContractStatusName,
                        SourceSystem = c.SourceSystem,
                        SourceSystemName = c.SourceSystemName,
                        StartDate = c.StartDate,
                        TerminationDate = c.TerminationDate,
                        EffectiveDate = c.EffectiveDate,
                        ClaimPolicyC = c.ClaimPolicyC,
                        ClaimPolicyI = c.ClaimPolicyI,
                        Coverage = c.Coverage,
                        CoverageCode = c.CoverageCode,
                        Status = c.Status,
                        EffectiveDate1 = c.EffectiveDate1,
                        ClaimPolicyCoverageC = c.ClaimPolicyCoverageC,
                        ClaimPolicyCoverageI = c.ClaimPolicyCoverageI,
                        Type = c.Type,
                        BenefitEntitlementDescription = c.BenefitEntitlementDescription,
                        BenefitSelected = c.BenefitSelected,
                        PasriskOptionCode = c.PasriskOptionCode,
                        ClaimNumber = c.ClaimNumber,
                        Pid = c.Pid,
                        ApplicationId = c.ApplicationId,
                    };
                }
                else
                {
                    item = new CoverageSearch();
                }

                if (item == null)
                {
                    item = new CoverageSearch();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new CoverageSearch();
            }

            return item;
        }


        public async Task<PaginatedList<Occupation>> SearchOccupation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<Occupation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Occupations
                            orderby c.Id ascending
                            select new Occupation
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                DateOfHire = c.DateOfHire,
                                JobTitle = c.JobTitle,
                                HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                                DateJobEnded = c.DateJobEnded,
                                OccupationCode = c.OccupationCode,
                                SelfEmployed = c.SelfEmployed,
                                EmploymentStatus = c.EmploymentStatus,
                                DaysWorkedPerWeek = c.DaysWorkedPerWeek,
                                NatureOfWorkDuties = c.NatureOfWorkDuties,
                                ReasonForCeasingPosition = c.ReasonForCeasingPosition,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "ClaimC":
                    //        query = query.Where(c => c.ClaimC!.Contains(search));
                    //        break;
                    //    case "ClaimI":
                    //        query = query.Where(c => c.ClaimI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<Occupation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<Occupation> GetOccupation(string id)
        {
            Occupation item = null!;
            try
            {
                var c = await _context.Occupations.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new Occupation
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        DateOfHire = c.DateOfHire,
                        JobTitle = c.JobTitle,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        DateJobEnded = c.DateJobEnded,
                        OccupationCode = c.OccupationCode,
                        SelfEmployed = c.SelfEmployed,
                        EmploymentStatus = c.EmploymentStatus,
                        DaysWorkedPerWeek = c.DaysWorkedPerWeek,
                        NatureOfWorkDuties = c.NatureOfWorkDuties,
                        ReasonForCeasingPosition = c.ReasonForCeasingPosition,
                        BusinessStructure = c.BusinessStructure,
                    };
                }
                else
                {
                    item = new Occupation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new Occupation();
            }

            return item;
        }

        public async Task<List<Occupation>> GetOccupationByClaimNumber(string id)
        {
            List<Occupation> items = new List<Occupation>();
            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetOccupationByClaimNumber";
                cmd.Parameters.AddWithValue("@pClaimNumber", id);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Occupation item = new Occupation
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                C = Convert.ToInt32(reader["C"].ToString()),
                                I = Convert.ToInt32(reader["I"].ToString()),
                                ClaimC = Convert.ToInt32(reader["Claim_C"].ToString()),
                                ClaimI = Convert.ToInt32(reader["Claim_I"].ToString()),
                                PartyC = Convert.ToInt32(reader["Party_C"].ToString()),
                                PartyI = Convert.ToInt32(reader["Party_I"].ToString()),
                                DateOfHire = Convert.ToDateTime(reader["DateOfHire"].ToString()),
                                JobTitle = reader["JobTitle"].ToString(),
                                HoursWorkedPerWeek = Convert.ToInt32(reader["HoursWorkedPerWeek"].ToString()),
                                DateJobEnded = Convert.ToDateTime(reader["DateJobEnded"].ToString()),
                                OccupationCode = reader["OccupationCode"].ToString(),
                                SelfEmployed = Convert.ToInt32(reader["SelfEmployed"].ToString()),
                                EmploymentStatus = reader["JobTitle"].ToString(),
                                DaysWorkedPerWeek = Convert.ToInt32(reader["DaysWorkedPerWeek"].ToString()),
                                NatureOfWorkDuties = reader["NatureOfWorkDuties"].ToString(),
                                ReasonForCeasingPosition = reader["ReasonForCeasingPosition"].ToString(),
                                BusinessStructure = reader["BusinessStructure"].ToString(),
                            };
                          
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return items;
        }


        public async Task<PaginatedList<ClaimOccupation>> SearchClaimOccupation(string column, string search, int pageIndex = 1, int pageSize = 25, int appflag = 1)
        {
            PaginatedList<ClaimOccupation> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimOccupations
                            orderby c.Id ascending
                            select new ClaimOccupation
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                PartyC = c.PartyC,
                                PartyI = c.PartyI,
                                ClaimNumber = c.ClaimNumber,
                                Occupation = c.Occupation,
                                JobTitle = c.JobTitle,
                                HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                                GrossAmt = c.GrossAmt,
                                DateOfHire = c.DateOfHire,
                                DateJobEnded = c.DateJobEnded,
                                OccupationCode = c.OccupationCode,
                                IncomeType = c.IncomeType,
                                EmploymentStatus = c.EmploymentStatus,
                                SelfEmployed = c.SelfEmployed,
                                DaysWorkedPerWeek = c.DaysWorkedPerWeek,
                                NatureOfWorkDuties = c.NatureOfWorkDuties,
                                ReasonForCeasingPosition = c.ReasonForCeasingPosition,
                                BusinessStructure = c.BusinessStructure,
                                ApplicationId = c.ApplicationId,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        //case "C":
                        //    query = query.Where(c => c.C!.Contains(search));
                        //    break;
                        //case "I":
                        //    query = query.Where(c => c.I!.Contains(search));
                        //    break;
                        //case "CaseC":
                        //    query = query.Where(c => c.CaseC!.Contains(search));
                        //    break;
                        //case "CaseI":
                        //    query = query.Where(c => c.CaseI!.Contains(search));
                        //    break;


                    }
                }

                query = query.Where(c => c.ApplicationId == appflag);

                list = await PaginatedList<ClaimOccupation>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimOccupation> GetClaimOccupation(string id)
        {
            ClaimOccupation item = null!;
            try
            {
                var c = await _context.ClaimOccupations.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimOccupation
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        PartyC = c.PartyC,
                        PartyI = c.PartyI,
                        ClaimNumber = c.ClaimNumber,
                        Occupation = c.Occupation,
                        JobTitle = c.JobTitle,
                        HoursWorkedPerWeek = c.HoursWorkedPerWeek,
                        GrossAmt = c.GrossAmt,
                        DateOfHire = c.DateOfHire,
                        DateJobEnded = c.DateJobEnded,
                        OccupationCode = c.OccupationCode,
                        IncomeType = c.IncomeType,
                        EmploymentStatus = c.EmploymentStatus,
                        SelfEmployed = c.SelfEmployed,
                        DaysWorkedPerWeek = c.DaysWorkedPerWeek,
                        NatureOfWorkDuties = c.NatureOfWorkDuties,
                        ReasonForCeasingPosition = c.ReasonForCeasingPosition,
                        BusinessStructure = c.BusinessStructure,
                        Rank = c.Rank,
                    };
                }
                else
                {
                    item = new ClaimOccupation();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimOccupation();
            }

            return item;
        }


        public async Task<PaginatedList<ClaimPeriod>> SearchClaimPeriod(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClaimPeriod> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClaimPeriods
                            orderby c.Id ascending
                            select new ClaimPeriod
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                ClaimC = c.ClaimC,
                                ClaimI = c.ClaimI,
                                PartyCFacility = c.PartyCFacility,
                                PartyIFacility = c.PartyIFacility,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Description = c.Description,
                                ClaimNumber = c.ClaimNumber,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        //case "C":
                        //    query = query.Where(c => c.C!.Contains(search));
                        //    break;
                        //case "I":
                        //    query = query.Where(c => c.I!.Contains(search));
                        //    break;
                        //case "ClaimC":
                        //    query = query.Where(c => c.ClaimC!.Contains(search));
                        //    break;
                        //case "ClaimI":
                        //    query = query.Where(c => c.ClaimI!.Contains(search));
                        //    break;


                    }
                }

                list = await PaginatedList<ClaimPeriod>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClaimPeriod> GetClaimPeriod(string id)
        {
            ClaimPeriod item = null!;
            try
            {
                var c = await _context.ClaimPeriods.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClaimPeriod
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        ClaimC = c.ClaimC,
                        ClaimI = c.ClaimI,
                        PartyCFacility = c.PartyCFacility,
                        PartyIFacility = c.PartyIFacility,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        Description = c.Description,
                        ClaimNumber = c.ClaimNumber,
                    };
                }
                else
                {
                    item = new ClaimPeriod();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClaimPeriod();
            }

            return item;
        }


        public async Task<TabCMP> GetTabCMP(string id, int appflag)
        {
            TabCMP cmp = new TabCMP();
            List<ClientGoalEx> clntgols = new List<ClientGoalEx>();
            List<GoalEx> goals = new List<GoalEx>();
            List<ActionAEx> actns = new List<ActionAEx>();
            List<LifeAreaEx> factors = new List<LifeAreaEx>();
            List<ActionHistoryEx> history = new List<ActionHistoryEx>();

            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetCMPByClaimNumber";
                cmd.Parameters.AddWithValue("@pClaimNumber", id);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        // client goals
                        while (reader.Read())
                        {
                            ClientGoalEx cg = new ClientGoalEx
                            {
                                Id = reader["Id"].ToString(),
                                C = reader["C"].ToString(),
                                I = reader["I"].ToString(),
                                CaseC = reader["Case_C"].ToString(),
                                CaseI = reader["Case_I"].ToString(),
                                CustomerGoalName = reader["CustomerGoalName"].ToString(),
                                GoalDescription = reader["GoalDescription"].ToString(),
                                GoalTargetDate = reader["GoalTargetDate"].ToString(),
                                Status = reader["Status"].ToString(),
                                OutcomeDate = reader["OutcomeDate"].ToString(),
                                OutcomeNotes = reader["OutcomeNotes"].ToString(),
                                GoalDateRationale = reader["GoalDateRationale"].ToString(),
                                AchievementTimeframe = reader["AchievementTimeframe"].ToString(),
                                CreateDate = reader["CreateDate"].ToString(),
                                GoalReason = reader["GoalReason"].ToString(),
                            };

                            clntgols.Add(cg);
                        }

                        // goals
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                GoalEx goal = new GoalEx
                                {
                                    Id = reader["Id"].ToString(),
                                    C = reader["C"].ToString(),
                                    I = reader["I"].ToString(),
                                    ClientGoalC = reader["ClientGoal_C"].ToString(),
                                    ClientGoalI = reader["ClientGoal_I"].ToString(),
                                    LifeAreaC = reader["LifeArea_C"].ToString(),
                                    LifeAreaI = reader["LifeArea_I"].ToString(),
                                    StrategyName = reader["StrategyName"].ToString(),
                                    SummarySnapshot = reader["SummarySnapshot"].ToString(),
                                    CustomerStrategyStatus = reader["CustomerStrategyStatus"].ToString(),
                                    TargetDate = reader["TargetDate"].ToString(),
                                };

                                goals.Add(goal);
                            }
                        }

                        // actions
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                ActionAEx actn = new ActionAEx
                                {
                                    Id = reader["Id"].ToString(),
                                    C = reader["C"].ToString(),
                                    I = reader["I"].ToString(),
                                    GoalC = reader["Goal_C"].ToString(),
                                    GoalI = reader["Goal_I"].ToString(),
                                    PartyCResponsibilityOfServiceProvider = reader["Party_C_ResponsibilityOfServiceProvider"].ToString(),
                                    PartyIResponsibilityOfServiceProvider = reader["Party_I_ResponsibilityOfServiceProvider"].ToString(),
                                    PartyCResponsibilityOfClient = reader["Party_C_ResponsibilityOfClient"].ToString(),
                                    PartyIResponsibilityOfClient = reader["Party_I_ResponsibilityOfClient"].ToString(),
                                    UserCResponsibilityOfStaffMember = reader["User_C_ResponsibilityOfStaffMember"].ToString(),
                                    UserIResponsibilityOfStaffMember = reader["User_I_ResponsibilityOfStaffMember"].ToString(),
                                    Rationale = reader["Rationale"].ToString(),
                                    ActionOutcome = reader["ActionOutcome"].ToString(),
                                    OutcomeComments = reader["OutcomeComments"].ToString(),
                                    ActionName = reader["ActionName"].ToString(),
                                    StartDate = reader["StartDate"].ToString(),
                                    EndDate = reader["EndDate"].ToString(),
                                    ReviewDate = reader["ReviewDate"].ToString(),
                                };

                                actns.Add(actn);
                            }
                        }

                        // factors
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                LifeAreaEx life = new LifeAreaEx
                                {
                                    Id = reader["Id"].ToString(),
                                    C = reader["C"].ToString(),
                                    I = reader["I"].ToString(),
                                    CaseC = reader["Case_C"].ToString(),
                                    CaseI = reader["Case_I"].ToString(),
                                    Factors = reader["Factors"].ToString(),
                                    FactorStatus = reader["FactorStatus"].ToString(),
                                    Notes = reader["Notes"].ToString(),
                                };

                                factors.Add(life);
                            }
                        }

                        // history
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                ActionHistoryEx hist = new ActionHistoryEx
                                {
                                    Id = reader["Id"].ToString(),
                                    LastUpdated = reader["LastUpdated"].ToString(),
                                    ClaimNumber = reader["ClaimNumber"].ToString(),
                                    BenefitNumber = reader["BenefitNumber"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Description = reader["Description"].ToString(),
                                };

                                history.Add(hist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            cmp.clientgoal = clntgols;
            cmp.goals = goals;
            cmp.actions = actns;
            cmp.factors = factors;
            cmp.history = history;

            return cmp;
        }

        public async Task<PaginatedList<ClientGoal>> SearchClientGoal(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ClientGoal> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ClientGoals
                            orderby c.Id ascending
                            select new ClientGoal
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                CaseC = c.CaseC,
                                CaseI = c.CaseI,
                                CustomerGoalName = c.CustomerGoalName,
                                GoalDescription = c.GoalDescription,
                                GoalTargetDate = c.GoalTargetDate,
                                Status = c.Status,
                                OutcomeDate = c.OutcomeDate,
                                OutcomeNotes = c.OutcomeNotes,
                                GoalDateRationale = c.GoalDateRationale,
                                AchievementTimeframe = c.AchievementTimeframe,
                                CreateDate = c.CreateDate,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "CaseC":
                    //        query = query.Where(c => c.CaseC!.Contains(search));
                    //        break;
                    //    case "CaseI":
                    //        query = query.Where(c => c.CaseI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ClientGoal>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ClientGoal> GetClientGoal(string id)
        {
            ClientGoal item = null!;
            try
            {
                var c = await _context.ClientGoals.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ClientGoal
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        CaseC = c.CaseC,
                        CaseI = c.CaseI,
                        CustomerGoalName = c.CustomerGoalName,
                        GoalDescription = c.GoalDescription,
                        GoalTargetDate = c.GoalTargetDate,
                        Status = c.Status,
                        OutcomeDate = c.OutcomeDate,
                        OutcomeNotes = c.OutcomeNotes,
                        GoalDateRationale = c.GoalDateRationale,
                        AchievementTimeframe = c.AchievementTimeframe,
                        CreateDate = c.CreateDate,
                        GoalReason = c.GoalReason,
                    };
                }
                else
                {
                    item = new ClientGoal();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ClientGoal();
            }

            return item;
        }

        public async Task<PaginatedList<ActionA>> SearchActionA(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ActionA> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Actions
                            orderby c.Id ascending
                            select new ActionA
                            {
                                Id = c.Id,
                                C = c.C,
                                I = c.I,
                                GoalC = c.GoalC,
                                GoalI = c.GoalI,
                                PartyCResponsibilityOfServiceProvider = c.PartyCResponsibilityOfServiceProvider,
                                PartyIResponsibilityOfServiceProvider = c.PartyIResponsibilityOfServiceProvider,
                                PartyCResponsibilityOfClient = c.PartyCResponsibilityOfClient,
                                PartyIResponsibilityOfClient = c.PartyIResponsibilityOfClient,
                                UserCResponsibilityOfStaffMember = c.UserCResponsibilityOfStaffMember,
                                UserIResponsibilityOfStaffMember = c.UserIResponsibilityOfStaffMember,
                                Rationale = c.Rationale,
                                ActionOutcome = c.ActionOutcome,
                                OutcomeComments = c.OutcomeComments,
                                ActionName = c.ActionName,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    //switch (column)
                    //{
                    //    case "Id":
                    //        query = query.Where(c => c.Id!.Contains(search));
                    //        break;
                    //    case "C":
                    //        query = query.Where(c => c.C!.Contains(search));
                    //        break;
                    //    case "I":
                    //        query = query.Where(c => c.I!.Contains(search));
                    //        break;
                    //    case "GoalC":
                    //        query = query.Where(c => c.GoalC!.Contains(search));
                    //        break;
                    //    case "GoalI":
                    //        query = query.Where(c => c.GoalI!.Contains(search));
                    //        break;


                    //}
                }

                list = await PaginatedList<ActionA>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ActionA> GetActionA(string id)
        {
            ActionA item = null!;
            try
            {
                var c = await _context.Actions.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ActionA
                    {
                        Id = c.Id,
                        C = c.C,
                        I = c.I,
                        GoalC = c.GoalC,
                        GoalI = c.GoalI,
                        PartyCResponsibilityOfServiceProvider = c.PartyCResponsibilityOfServiceProvider,
                        PartyIResponsibilityOfServiceProvider = c.PartyIResponsibilityOfServiceProvider,
                        PartyCResponsibilityOfClient = c.PartyCResponsibilityOfClient,
                        PartyIResponsibilityOfClient = c.PartyIResponsibilityOfClient,
                        UserCResponsibilityOfStaffMember = c.UserCResponsibilityOfStaffMember,
                        UserIResponsibilityOfStaffMember = c.UserIResponsibilityOfStaffMember,
                        Rationale = c.Rationale,
                        ActionOutcome = c.ActionOutcome,
                        OutcomeComments = c.OutcomeComments,
                        ActionName = c.ActionName,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        ReviewDate = c.ReviewDate,
                    };
                }
                else
                {
                    item = new ActionA();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ActionA();
            }

            return item;
        }

        public async Task<List<CaseAction>> SearchCaseAction(string id, int appId)
        {
            List<CaseAction> actions = new List<CaseAction>();

            var con = (SqlConnection)_context.Database.GetDbConnection();

            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetCaseActionsByClaimNumber";
                cmd.CommandTimeout = 120;
                cmd.Parameters.AddWithValue("@pClaimNumber", id);
                cmd.Parameters.AddWithValue("@pappId", appId);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        // client goals
                        while (reader.Read())
                        {
                            CaseAction act = new CaseAction
                            {
                                Status = reader["Status"].ToString(),
                                Reason = reader["Reason"].ToString(),
                                ActionedBy = reader["ActionedBy"].ToString(),
                                ActionDate = reader["ActionDate"].ToString(),
                                ClaimNumber = reader["ClaimNumber"].ToString(),
                            };

                            actions.Add(act);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return actions;
        }

        public async Task<PaginatedList<ActionHistory>> SearchActionHistory(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<ActionHistory> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.ActionHistories
                            orderby c.Id ascending
                            select new ActionHistory
                            {
                                Id = c.Id,
                                LastUpdated = c.LastUpdated,
                                ClaimNumber = c.ClaimNumber,
                                BenefitNumber = c.BenefitNumber,
                                Name = c.Name,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "LastUpdated":
                            query = query.Where(c => c.LastUpdated.ToString()!.Contains(search));
                            break;
                        case "ClaimNumber":
                            query = query.Where(c => c.ClaimNumber!.Contains(search));
                            break;
                        case "BenefitNumber":
                            query = query.Where(c => c.BenefitNumber!.Contains(search));
                            break;
                        case "Name":
                            query = query.Where(c => c.Name!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<ActionHistory>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<ActionHistoryEx> GetActionHistory(string id)
        {
            ActionHistoryEx item = null!;
            try
            {
                var c = await _context.ActionHistories.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new ActionHistoryEx
                    {
                        Id = c.Id.ToString(),
                        LastUpdated = c.LastUpdated.ToString(),
                        ClaimNumber = c.ClaimNumber,
                        BenefitNumber = c.BenefitNumber,
                        Name = c.Name,
                        Description = c.Description,
                    };
                }
                else
                {
                    item = new ActionHistoryEx();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new ActionHistoryEx();
            }

            return item;
        }


        public async Task<PaginatedList<AbleEmail>> SearchEmail(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<AbleEmail> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.Emails
                            orderby c.DateSent descending
                            select new AbleEmail
                            {
                                EmailId = c.EmailId,
                                SenderEmail = c.SenderEmail,
                                RecipientEmail = c.RecipientEmail,
                                MailSubject = c.MailSubject,
                                MailBody = c.MailBody,
                                DateSent = c.DateSent,

                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "DateSent":
                            query = query.Where(c => c.DateSent.ToString()!.Contains(search));
                            break;
                        case "SenderEmail":
                            query = query.Where(c => c.SenderEmail!.Contains(search));
                            break;
                        case "RecipientEmail":
                            query = query.Where(c => c.RecipientEmail!.Contains(search));
                            break;
                        case "MailSubject":
                            query = query.Where(c => c.MailSubject!.Contains(search));
                            break;
                        case "MailBody":
                            query = query.Where(c => c.MailBody!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<AbleEmail>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

        public async Task<AbleEmail> GetEmail(string id)
        {
            AbleEmail item = null!;
            try
            {
                var c = await _context.Emails.FirstOrDefaultAsync(m => m.EmailId == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new AbleEmail
                    {
                        EmailId = c.EmailId,
                        SenderEmail = c.SenderEmail,
                        RecipientEmail = c.RecipientEmail,
                        MailSubject = c.MailSubject,
                        MailBody = c.MailBody,
                        DateSent = c.DateSent,
                    };
                }
                else
                {
                    item = new AbleEmail();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new AbleEmail();
            }

            return item;
        }

        public async Task<PaginatedList<AbleIssue>> SearchAbleIssue(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            PaginatedList<AbleIssue> list = null!;
            search = HttpUtility.UrlDecode(search);

            try
            {
                var query = from c in _context.AbleIssues
                            orderby c.DateReported descending
                            select new AbleIssue
                            {
                                Id = c.Id,
                                ReportedBy = c.ReportedBy,
                                Description = c.Description,
                                DateReported = c.DateReported,
                                Status = c.Status,
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    switch (column)
                    {
                        case "ReportedBy":
                            query = query.Where(c => c.ReportedBy!.Contains(search));
                            break;
                        case "Description":
                            query = query.Where(c => c.Description!.Contains(search));
                            break;
                        case "DateReported":
                            query = query.Where(c => c.DateReported!.Contains(search));
                            break;


                    }
                }

                list = await PaginatedList<AbleIssue>.CreateAsync(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return list;
        }

       
        public async Task<AbleIssue> GetAbleIssue(string id)
        {
            AbleIssue item = null!;
            try
            {
                var c = await _context.AbleIssues.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
                if (c != null)
                {
                    item = new AbleIssue
                    {
                        Id = c.Id,
                        ReportedBy = c.ReportedBy,
                        Description = c.Description,
                        DateReported = c.DateReported,
                        Status = c.Status,
                    };
                }
                else
                {
                    item = new AbleIssue();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                item = new AbleIssue();
            }

            return item;
        }

  


    }
}
