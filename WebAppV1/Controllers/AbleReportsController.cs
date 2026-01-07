using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleReportsController : Controller
    {
        private readonly IAbleSearch _context;
        private readonly ILogger<AbleReportsController> _logger;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";
        public const string HomeController = "Home";
        public int staffFlag = 0;
        public string RedirectPage = string.Empty;
        public string appName = "Able";

        public AbleReportsController(IAbleSearch context, ILogger<AbleReportsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string column, string search, string column1, string search1, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchClaimbenefitmvs();
                ViewBag.searchcolumns1 = GetSearchClaimbenefitmvs1();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.column1 = column1;
                ViewBag.search1 = search1;

                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Claim Benefit";

                var list = await _context.SearchClaimbenefitmvD(column, search, column1, search1, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<string> ValidateUserAccount()
        {
            RedirectPage = "NO";
            staffFlag = 0;

            // get able login user
            string username = HttpContext.User.Identity?.Name ?? string.Empty;
            var _loginuser = await _context.GetSiteUser(username);

            if (_loginuser == null || _loginuser.UserId != username || _loginuser.IsActive == false)
            {
                string msg1 = "User account is not found. Your access to the ABLE Archival Solution is denied.";
                string msg2 = "Please raise a SailPoint request to create ABLE user account";
                HttpContext.Session.SetString(Messag1, msg1);
                HttpContext.Session.SetString(Messag2, msg2);
                HttpContext.Session.SetString(ClaimNumber, string.Empty);

                RedirectPage = "YES";
            }

            if (_loginuser != null && _loginuser.RoleName == "admin")
            {
                staffFlag = 1;
            }
            return RedirectPage;
        }

        public IActionResult ModelDetails()
        {
            List<string> columns = new List<string>();
            columns.Add(LoginUser);
            return View(columns);
        }

        public async Task<IActionResult> Claimbenefitmv(string column, string search, string column1, string search1, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchClaimbenefitmvs();
                ViewBag.searchcolumns1 = GetSearchClaimbenefitmvs1();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.column1 = column1;
                ViewBag.search1 = search1;

                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Claim Benefit Report";

                var list = await _context.SearchClaimbenefitmvD(column, search, column1, search1, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetClaimbenefitmv()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetClaimbenefitmv(id, Convert.ToInt32(appId));


            return PartialView("../AbleReports/ClaimbenefitmvDetail", report);
        }

        // Search Columns
        private List<SelectListItem> GetSearchClaimbenefitmvs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            //ls.Add(new SelectListItem() { Text = "BenefitNumber", Value = "BenefitNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "Surname" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            ls.Add(new SelectListItem() { Text = "ClaimStatus", Value = "ClaimStatus" });
            return ls;
        }
        private List<SelectListItem> GetSearchClaimbenefitmvs1()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "Surname" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            ls.Add(new SelectListItem() { Text = "ClaimStatus", Value = "ClaimStatus" });
            return ls;
        }

        public async Task<IActionResult> ClaimbenefitmvDetail(string search, string id)
        {
            try
            {
                string loginuser = HttpContext.User.Identity?.Name ?? string.Empty;

                // get able login user
                var _loginuser = await _context.GetSiteUser(loginuser);
                if (_loginuser == null || _loginuser.UserId != loginuser || _loginuser.IsActive == false)
                {
                    return RedirectToAction("Index");
                }

                ViewData["Title"] = "Claim Hub";
                ViewData["CaseNumber"] = search;
                var list = await _context.GetClaimbenefitmv(id);

                //if (list != null && list.StaffInd != 0)
                //{
                //    if (_loginuser.RoleName != "admin")
                //    {
                //        string msg1 = "Your access to view the selected Claim " + search + " is denied.";
                //        string msg2 = "Please raise a SailPoint request to view ABLE staff claim access";
                //        HttpContext.Session.SetString(Messag1, msg1);
                //        HttpContext.Session.SetString(Messag2, msg2);
                //        HttpContext.Session.SetString(ClaimNumber, search);

                //        return RedirectToAction("AccessDenied", "Able");
                //    }
                //}

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Paymentsummarymv(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchPaymentsummarymvs();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Payment Summarym Report";

                int applicationflag = 1;
                ViewBag.applicationflag = applicationflag;

                var list = await _context.SearchPaymentsummarymv(column, search, pageIndex, pageSize, staffFlag, applicationflag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetPaymentsummarymv()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetPaymentsummarymv(id);
            return PartialView("../AbleReports/PaymentsummarymvDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchPaymentsummarymvs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "BenefitNumber", Value = "BenefitNumber" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "BenefitType", Value = "BenefitType" });
            ls.Add(new SelectListItem() { Text = "PaymentMethod", Value = "PaymentMethod" });
            ls.Add(new SelectListItem() { Text = "PaymentReference", Value = "PaymentReference" });
            ls.Add(new SelectListItem() { Text = "BenefitAmount", Value = "BenefitAmount" });
            ls.Add(new SelectListItem() { Text = "StartDate", Value = "From" });
            ls.Add(new SelectListItem() { Text = "EndDate", Value = "To" });
            return ls;
        }


        public async Task<IActionResult> Taskmv(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchTaskmvs();
                ViewBag.searchapps = GetSearchApplications();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;

                if (appId == 0) { appId = 1; }
                if (appId > 2) { appId = 1; }

                if (appId == 1)
                {
                    appName = "Able";
                }
                else if (appId == 2)
                {
                    appName = "Orion";
                }

                ViewData["Title"] = appName + " Task Report";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchTaskmv(column, search, pageIndex, pageSize, staffFlag, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetTaskmv()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetTaskmv(id);
            return PartialView("../AbleReports/TaskmvDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchTaskmvs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "TaskCreatedDate", Value = "TaskCreatedDate" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "CaseStatus", Value = "CaseStatus" });
            ls.Add(new SelectListItem() { Text = "TaskName", Value = "ITaskNamed" });
            return ls;
        }


        public async Task<IActionResult> RptAbleuser(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                ViewBag.searchcolumns = GetSearchRptAbleusers();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Users Report";

                var list = await _context.SearchRptAbleuser(column, search, pageIndex, pageSize);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptAbleuser()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptAbleuser(id);
            return PartialView("../AbleReports/RptAbleuserDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptAbleusers()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "LanId", Value = "LanId" });
            ls.Add(new SelectListItem() { Text = "FullName", Value = "FullName" });
            ls.Add(new SelectListItem() { Text = "JobTitle", Value = "JobTitle" });
            ls.Add(new SelectListItem() { Text = "Mail", Value = "Mail" });
            return ls;
        }


        public async Task<IActionResult> RptAbleusersallrole(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                ViewBag.searchcolumns = GetSearchRptAbleusersallroles();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Users All Roles Report";

                var list = await _context.SearchRptAbleusersallrole(column, search, pageIndex, pageSize);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptAbleusersallrole()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptAbleusersallrole(id);
            return PartialView("../AbleReports/RptAbleusersallroleDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptAbleusersallroles()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "LanId", Value = "LanId" });
            ls.Add(new SelectListItem() { Text = "FullName", Value = "FullName" });
            ls.Add(new SelectListItem() { Text = "JobTitle", Value = "JobTitle" });
            ls.Add(new SelectListItem() { Text = "Role", Value = "Role" });
            ls.Add(new SelectListItem() { Text = "Mail", Value = "Mail" });
            return ls;
        }


        public async Task<IActionResult> RptActionsservice(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptActionsservices();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Able Actions Services Report";

                var list = await _context.SearchRptActionsservice(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptActionsservice()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptActionsservice(id);
            return PartialView("../AbleReports/RptActionsserviceDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptActionsservices()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimCase", Value = "ClaimCase" });
            ls.Add(new SelectListItem() { Text = "ActionName", Value = "ActionName" });
            ls.Add(new SelectListItem() { Text = "ActionStartDate", Value = "ActionStartDate" });
            ls.Add(new SelectListItem() { Text = "CaseManager", Value = "CaseManager" });
            ls.Add(new SelectListItem() { Text = "ActionOutcome", Value = "ActionOutcome" });
            return ls;
        }


        public async Task<IActionResult> RptCaseaction(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptCaseactions();
                ViewBag.searchapps = GetSearchApplications();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;

                if (appId == 0) { appId = 1; }
                if (appId > 2) { appId = 1; }

                if (appId == 1)
                {
                    appName = "Able";
                }
                else if (appId == 2)
                {
                    appName = "Orion";
                }

                ViewData["Title"] = appName + " Case Actions Report";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchRptCaseaction(column, search, pageIndex, pageSize, staffFlag, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCaseaction()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCaseaction(id);
            return PartialView("../AbleReports/RptCaseactionDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCaseactions()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CaseType", Value = "CaseType" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            ls.Add(new SelectListItem() { Text = "ActionedBy", Value = "ActionedBy" });
            ls.Add(new SelectListItem() { Text = "ActionDate", Value = "ActionDate" });

            return ls;
        }


        public async Task<IActionResult> RptClaimbenefitactuarialrec(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimbenefitactuarialrecs();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimbenefitactuarialrecs";

                var list = await _context.SearchRptClaimbenefitactuarialrec(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimbenefitactuarialrec()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimbenefitactuarialrec(id);
            return PartialView("../AbleReports/RptClaimbenefitactuarialrecDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimbenefitactuarialrecs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "MonthEffectiveDate", Value = "MonthEffectiveDate" });
            ls.Add(new SelectListItem() { Text = "SourceSystem", Value = "SourceSystem" });
            ls.Add(new SelectListItem() { Text = "ProductName", Value = "ProductName" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "IndicativeClaimType", Value = "IndicativeClaimType" });
            return ls;
        }


        public async Task<IActionResult> RptClaimBenefitactuarialrecl(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimBenefitactuarialrecls();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimBenefitactuarialrecls";

                var list = await _context.SearchRptClaimBenefitactuarialrecl(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimBenefitactuarialrecl()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimBenefitactuarialrecl(id);
            return PartialView("../AbleReports/RptClaimBenefitactuarialreclDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimBenefitactuarialrecls()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "MonthEffectiveDate", Value = "MonthEffectiveDate" });
            ls.Add(new SelectListItem() { Text = "SourceSystem", Value = "SourceSystem" });
            ls.Add(new SelectListItem() { Text = "ProductName", Value = "ProductName" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "IndicativeClaimType", Value = "IndicativeClaimType" });
            return ls;
        }


        public async Task<IActionResult> RptClaimbenefitgroup(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimbenefitgroups();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimbenefitgroups";

                var list = await _context.SearchRptClaimbenefitgroup(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimbenefitgroup()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimbenefitgroup(id);
            return PartialView("../AbleReports/RptClaimbenefitgroupDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimbenefitgroups()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimStatus", Value = "ClaimStatus" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "Surname" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            return ls;
        }


        public async Task<IActionResult> RptClaimbenefitreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimbenefitreinsurances();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimbenefitreinsurances";

                var list = await _context.SearchRptClaimbenefitreinsurance(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimbenefitreinsurance()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimbenefitreinsurance(id);
            return PartialView("../AbleReports/RptClaimbenefitreinsuranceDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimbenefitreinsurances()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimStatus", Value = "ClaimStatus" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "Surname" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            return ls;
        }


        public async Task<IActionResult> RptClaimbenefitw(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimbenefitws();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimbenefitws";

                var list = await _context.SearchRptClaimbenefitw(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimbenefitw()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimbenefitw(id);
            return PartialView("../AbleReports/RptClaimbenefitwDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimbenefitws()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimStatus", Value = "ClaimStatus" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "Surname" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            return ls;
        }


        public async Task<IActionResult> RptClaimcasedecipha(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimcasedeciphas();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimcasedeciphas";

                var list = await _context.SearchRptClaimcasedecipha(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimcasedecipha()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimcasedecipha(id);
            return PartialView("../AbleReports/RptClaimcasedeciphaDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimcasedeciphas()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "FirstName", Value = "CustomerFirstName" });
            ls.Add(new SelectListItem() { Text = "LastName", Value = "CustomerLastName" });
            ls.Add(new SelectListItem() { Text = "State", Value = "State" });
            return ls;
        }


        public async Task<IActionResult> RptClaimexpense(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimexpenses();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimexpenses";

                var list = await _context.SearchRptClaimexpense(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimexpense()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimexpense(id);
            return PartialView("../AbleReports/RptClaimexpenseDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimexpenses()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "Payee", Value = "Payee" });
            ls.Add(new SelectListItem() { Text = "InvoiceNumber", Value = "InvoiceNumber" });
            ls.Add(new SelectListItem() { Text = "AmountIncGst", Value = "AmountIncGst" });
            return ls;
        }


        public async Task<IActionResult> RptClaimparticipant(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClaimparticipants();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClaimparticipants";

                var list = await _context.SearchRptClaimparticipant(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClaimparticipant()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClaimparticipant(id);
            return PartialView("../AbleReports/RptClaimparticipantDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClaimparticipants()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "Name", Value = "Name" });
            ls.Add(new SelectListItem() { Text = "Email", Value = "Email" });
            ls.Add(new SelectListItem() { Text = "Address", Value = "Address" });
            ls.Add(new SelectListItem() { Text = "Suburb", Value = "Suburb" });
            return ls;
        }


        public async Task<IActionResult> RptClosedtaskreport(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptClosedtaskreports();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptClosedtaskreports";

                var list = await _context.SearchRptClosedtaskreport(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptClosedtaskreport()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptClosedtaskreport(id);
            return PartialView("../AbleReports/RptClosedtaskreportDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptClosedtaskreports()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "CaseStatus", Value = "CaseStatus" });
            ls.Add(new SelectListItem() { Text = "TaskName", Value = "TaskName" });
            ls.Add(new SelectListItem() { Text = "TaskDescription", Value = "TaskDescription" });
            return ls;
        }


        public async Task<IActionResult> RptCmpaction(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptCmpactions();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptCmpactions";

                var list = await _context.SearchRptCmpaction(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCmpaction()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCmpaction(id);
            return PartialView("../AbleReports/RptCmpactionDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCmpactions()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CmpStatus", Value = "CmpStatus" });
            ls.Add(new SelectListItem() { Text = "GoalName", Value = "GoalName" });
            ls.Add(new SelectListItem() { Text = "GoalDescription", Value = "GoalDescription" });
            ls.Add(new SelectListItem() { Text = "GoalOutcome", Value = "GoalOutcome" });
            return ls;
        }


        public async Task<IActionResult> RptCmpgoaldatemovement(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }


                ViewBag.searchcolumns = GetSearchRptCmpgoaldatemovements();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptCmpgoaldatemovements";

                var list = await _context.SearchRptCmpgoaldatemovement(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCmpgoaldatemovement()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCmpgoaldatemovement(id);
            return PartialView("../AbleReports/RptCmpgoaldatemovementDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCmpgoaldatemovements()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CmpStatus", Value = "CmpStatus" });
            ls.Add(new SelectListItem() { Text = "PlanName", Value = "PlanName" });
            ls.Add(new SelectListItem() { Text = "CmpGoalDate", Value = "CmpGoalDate" });
            ls.Add(new SelectListItem() { Text = "CmpGoalUpdatedDate", Value = "CmpGoalUpdatedDate" });
            return ls;
        }


        public async Task<IActionResult> RptCmpplanstatus(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptCmpplanstatuss();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptCmpplanstatuss";

                var list = await _context.SearchRptCmpplanstatus(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCmpplanstatus()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCmpplanstatus(id);
            return PartialView("../AbleReports/RptCmpplanstatusDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCmpplanstatuss()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CmpStatus", Value = "CmpStatus" });
            ls.Add(new SelectListItem() { Text = "CmpGoalDate", Value = "CmpGoalDate" });
            ls.Add(new SelectListItem() { Text = "PlanName", Value = "PlanName" });
            ls.Add(new SelectListItem() { Text = "PlanStatus", Value = "PlanStatus" });
            return ls;
        }


        public async Task<IActionResult> RptCmpservice(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptCmpservices();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptCmpservices";

                var list = await _context.SearchRptCmpservice(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCmpservice()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCmpservice(id);
            return PartialView("../AbleReports/RptCmpserviceDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCmpservices()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CmpStatus", Value = "CmpStatus" });
            ls.Add(new SelectListItem() { Text = "CmpGoalDate", Value = "CmpGoalDate" });
            ls.Add(new SelectListItem() { Text = "GoalName", Value = "GoalName" });
            ls.Add(new SelectListItem() { Text = "GoalOutcome", Value = "GoalOutcome" });
            return ls;
        }


        public async Task<IActionResult> RptCompliant(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptCompliants();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptCompliants";

                var list = await _context.SearchRptCompliant(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptCompliant()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptCompliant(id);
            return PartialView("../AbleReports/RptCompliantDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptCompliants()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNo", Value = "ClaimNo" });
            ls.Add(new SelectListItem() { Text = "LastName", Value = "LastName" });
            ls.Add(new SelectListItem() { Text = "FirstName", Value = "FirstName" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            ls.Add(new SelectListItem() { Text = "PolicyNo1", Value = "PolicyNo1" });
            return ls;
        }


        public async Task<IActionResult> RptDocumentreport(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptDocumentreports();
                ViewBag.searchapps = GetSearchApplications();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;

                if (appId == 0) { appId = 1; }
                if (appId > 2) { appId = 1; }

                if (appId == 1)
                {
                    appName = "Able";
                }
                else if (appId == 2)
                {
                    appName = "Orion";
                }

                ViewData["Title"] = appName + " RptDocumentreports";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchRptDocumentreport(column, search, pageIndex, pageSize, staffFlag, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptDocumentreport()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptDocumentreport(id);
            return PartialView("../AbleReports/RptDocumentreportDetail", report);
        }

        // Search Columns
        private List<SelectListItem> GetSearchApplications()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Able", Value = "1" });
            ls.Add(new SelectListItem() { Text = "Orion", Value = "2" });
            return ls;
        }

        private List<SelectListItem> GetSearchRptDocumentreports()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "CaseNumber", Value = "CaseNumber" });
            ls.Add(new SelectListItem() { Text = "CaseType", Value = "CaseType" });
            ls.Add(new SelectListItem() { Text = "DocumentType", Value = "DocumentType" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreatedInAble" });
            ls.Add(new SelectListItem() { Text = "DateCreatedInAble", Value = "DateCreatedInAble" });
            ls.Add(new SelectListItem() { Text = "CreatedBy", Value = "CreatedBy" });
            ls.Add(new SelectListItem() { Text = "LastUpdatedBy", Value = "LastUpdatedBy" });

            return ls;
        }


        public async Task<IActionResult> RptEnquirycasereport(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                ViewBag.searchcolumns = GetSearchRptEnquirycasereports();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptEnquirycasereports";

                var list = await _context.SearchRptEnquirycasereport(column, search, pageIndex, pageSize);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptEnquirycasereport()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptEnquirycasereport(id);
            return PartialView("../AbleReports/RptEnquirycasereportDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptEnquirycasereports()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "EnquiryNumber", Value = "EnquiryNumber" });
            ls.Add(new SelectListItem() { Text = "EnquiryCaseStatus", Value = "EnquiryCaseStatus" });
            ls.Add(new SelectListItem() { Text = "GivenName", Value = "GivenName" });
            ls.Add(new SelectListItem() { Text = "Surname", Value = "ISurnamed" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DateOfBirth" });
            return ls;
        }


        public async Task<IActionResult> RptHcrcompletednote(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptHcrcompletednotes();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptHcrcompletednotes";

                var list = await _context.SearchRptHcrcompletednote(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptHcrcompletednote()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptHcrcompletednote(id);
            return PartialView("../AbleReports/RptHcrcompletednoteDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptHcrcompletednotes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimType", Value = "ClaimType" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "NoteType", Value = "NoteType" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            return ls;
        }


        public async Task<IActionResult> RptOpentask(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptOpentasks();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptOpentasks";

                var list = await _context.SearchRptOpentask(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptOpentask()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptOpentask(id);
            return PartialView("../AbleReports/RptOpentaskDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptOpentasks()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "CaseStatus", Value = "CaseStatus" });
            ls.Add(new SelectListItem() { Text = "TaskName", Value = "TaskName" });
            ls.Add(new SelectListItem() { Text = "TaskDescription", Value = "TaskDescription" });
            return ls;
        }


        public async Task<IActionResult> RptOverrideriskreport(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptOverrideriskreports();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptOverrideriskreports";

                var list = await _context.SearchRptOverrideriskreport(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptOverrideriskreport()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptOverrideriskreport(id);
            return PartialView("../AbleReports/RptOverrideriskreportDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptOverrideriskreports()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimType", Value = "ClaimType" });
            ls.Add(new SelectListItem() { Text = "OverrideProcessedBy", Value = "OverrideProcessedBy" });
            ls.Add(new SelectListItem() { Text = "LumpsumIpIndicator", Value = "LumpsumIpIndicator" });
            ls.Add(new SelectListItem() { Text = "RiskCategory", Value = "RiskCategory" });
            return ls;
        }


        public async Task<IActionResult> RptPaymentsummaryl(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptPaymentsummaryls();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptPaymentsummaryls";

                var list = await _context.SearchRptPaymentsummaryl(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptPaymentsummaryl()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptPaymentsummaryl(id);
            return PartialView("../AbleReports/RptPaymentsummarylDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptPaymentsummaryls()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "IClaimTyped", Value = "ClaimType" });
            ls.Add(new SelectListItem() { Text = "BenefitPayable", Value = "BenefitPayable" });
            ls.Add(new SelectListItem() { Text = "InvestmentAmount", Value = "InvestmentAmount" });
            ls.Add(new SelectListItem() { Text = "Bonus", Value = "Bonus" });
            return ls;
        }


        public async Task<IActionResult> RptPhoneenquiry(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptPhoneenquirys();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptPhoneenquirys";

                var list = await _context.SearchRptPhoneenquiry(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptPhoneenquiry()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptPhoneenquiry(id);
            return PartialView("../AbleReports/RptPhoneenquiryDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptPhoneenquirys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "ContactName", Value = "ContactName" });
            ls.Add(new SelectListItem() { Text = "ReasonForContact", Value = "ReasonForContact" });
            ls.Add(new SelectListItem() { Text = "Decision", Value = "Decision" });
            return ls;
        }


        public async Task<IActionResult> RptRecoveryrehabnote(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptRecoveryrehabnotes();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptRecoveryrehabnotes";

                var list = await _context.SearchRptRecoveryrehabnote(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptRecoveryrehabnote()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptRecoveryrehabnote(id);
            return PartialView("../AbleReports/RptRecoveryrehabnoteDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptRecoveryrehabnotes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "ClaimType", Value = "ClaimType" });
            ls.Add(new SelectListItem() { Text = "NoteType", Value = "NoteType" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            return ls;
        }


        public async Task<IActionResult> RptTaskreportgroup(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }


                ViewBag.searchcolumns = GetSearchRptTaskreportgroups();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptTaskreportgroups";

                var list = await _context.SearchRptTaskreportgroup(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptTaskreportgroup()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptTaskreportgroup(id);
            return PartialView("../AbleReports/RptTaskreportgroupDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptTaskreportgroups()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CaseStatus", Value = "CaseStatus" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "TaskName", Value = "TaskName" });
            ls.Add(new SelectListItem() { Text = "TaskDescription", Value = "TaskDescription" });
            return ls;
        }


        public async Task<IActionResult> RptTaskreportreinsurance(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchRptTaskreportreinsurances();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "RptTaskreportreinsurances";

                var list = await _context.SearchRptTaskreportreinsurance(column, search, pageIndex, pageSize, staffFlag);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetRptTaskreportreinsurance()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetRptTaskreportreinsurance(id);
            return PartialView("../AbleReports/RptTaskreportreinsuranceDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchRptTaskreportreinsurances()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CaseStatus", Value = "CaseStatus" });
            ls.Add(new SelectListItem() { Text = "ClaimantName", Value = "ClaimantName" });
            ls.Add(new SelectListItem() { Text = "ProductName", Value = "ProductName" });
            ls.Add(new SelectListItem() { Text = "TaskName", Value = "TaskName" });
            return ls;
        }

    }
}
