using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleController : Controller
    {
        private readonly IAbleSearch _context;
        private readonly ILogger<AbleController> _logger;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";
        public const string HomeController = "Home";
        public int staffFlag = 0;
        public string RedirectPage = string.Empty;
        public string appName = "Able";

        public AbleController(IAbleSearch context, ILogger<AbleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["SidebarPartial"] = "_SidebarA";

            return View();
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
        public IActionResult AccessDenied()
        {
            ViewData["CaseNumber"] = HttpContext.Session.GetString(ClaimNumber);
            ViewData["msg1"] = HttpContext.Session.GetString(Messag1);
            ViewData["msg2"] = HttpContext.Session.GetString(Messag2);
            return View();
        }

        public IActionResult Architecture()
        {
            ViewData["SidebarPartial"] = "_SidebarA";

            return View();
        }

        public IActionResult Dashboard(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchPartys();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Dashboard";
            ViewData["SidebarPartial"] = "_SidebarA";

            return View();
        }

        public async Task<IActionResult> Claim(string column, string search, string column1, string search1, int pageIndex = 1, int pageSize = 25, int appId = 1)
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
                ViewBag.searchapps = GetSearchApplications();

                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.column1 = column1;
                ViewBag.search1 = search1;
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

                ViewData["Title"] = appName + " Claim";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchClaimbenefitmvD(column, search, column1, search1, pageIndex, pageSize, staffFlag, appId);

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
            return PartialView("../Able/ClaimDetail", report);
        }

        // Search Columns
        private List<SelectListItem> GetSearchApplications()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Able", Value = "1" });
            ls.Add(new SelectListItem() { Text = "Orion", Value = "2" });
            return ls;
        }
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

        public async Task<IActionResult> Party(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchPartys();
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

                ViewData["Title"] = appName + " Partys";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                //var list = await _context.SearchParty(column, search, pageIndex, pageSize);
                var list = await _context.SearchPartySearch(column, search, pageIndex, pageSize, staffFlag, appId);

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
        public async Task<IActionResult> GetParty()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetParty(id);
            return PartialView("../Able/PartyDetail", report);
        }

        // Search Columns
        private List<SelectListItem> GetSearchPartys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "CustomerNo", Value = "CustomerNo" });
            ls.Add(new SelectListItem() { Text = "Name", Value = "Name" });
            ls.Add(new SelectListItem() { Text = "DateOfBirth", Value = "DOB" });
            ls.Add(new SelectListItem() { Text = "DateOfDeath", Value = "DOD" });
            return ls;
        }

        public async Task<IActionResult> PartyAddress(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchPartyAddresss();
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

                ViewData["Title"] = appName + " Party Address";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchPartyAddress(column, search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetPartyAddress()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetPartyAddress(id, Convert.ToInt32(appId));
            return PartialView("../Able/PartyAddressDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchPartyAddresss()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "PartyName", Value = "PartyName" });
            ls.Add(new SelectListItem() { Text = "EffectiveFrom", Value = "EffectiveFrom" });
            ls.Add(new SelectListItem() { Text = "AddressLine1", Value = "AddressLine1" });
            ls.Add(new SelectListItem() { Text = "Suburb", Value = "Suburb" });
            ls.Add(new SelectListItem() { Text = "PostCode", Value = "PostCode" });
            ls.Add(new SelectListItem() { Text = "PartyI", Value = "PartyI" });
            return ls;
        }

        public async Task<IActionResult> Policy(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchPolicys();
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

                ViewData["Title"] = appName + " Policies";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                //var list = await _context.SearchPolicy(column, search, pageIndex, pageSize);
                var list = await _context.SearchPolicySearch(column, search, pageIndex, pageSize, staffFlag, appId);

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
        public async Task<IActionResult> GetPolicy()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetPolicy(id, Convert.ToInt32(appId));
            return PartialView("../Able/PolicyDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchPolicys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "PolicyNumber", Value = "PolicyNumber" });
            ls.Add(new SelectListItem() { Text = "ProductName", Value = "ProductName" });
            ls.Add(new SelectListItem() { Text = "StartDate", Value = "StartDate" });
            ls.Add(new SelectListItem() { Text = "TerminationDate", Value = "TerminationDate" });
            return ls;
        }

        public async Task<IActionResult> Benefit(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchBenefits();
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

                ViewData["Title"] = appName + " Benefits";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchBenefit(column, search, pageIndex, pageSize, staffFlag, appId);

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
        public async Task<IActionResult> GetBenefit()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetBenefit(id, Convert.ToInt32(appId));
            return PartialView("../Able/BenefitDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchBenefits()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "Type", Value = "Type" });
            ls.Add(new SelectListItem() { Text = "PasriskOptionDesc", Value = "PasriskOptionDesc" });
            ls.Add(new SelectListItem() { Text = "SumInsured", Value = "SumInsured" });
            ls.Add(new SelectListItem() { Text = "AdjustmentTypeName", Value = "AdjustmentTypeName" });
            ls.Add(new SelectListItem() { Text = "BenefitStartDate", Value = "BenefitStartDate" });
            return ls;
        }

        public async Task<IActionResult> Note1(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchNotes();
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

                ViewData["Title"] = appName + " Notes";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;


                var list = await _context.SearchNotes(column, search, pageIndex, pageSize, staffFlag, appId);

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
        public async Task<IActionResult> GetNote1()
        {
            var id = Request.Form["ID"].ToString();
            var AppId = Request.Form["AppID"].ToString();

            var report = await _context.GetNote1(id, Convert.ToInt32(AppId));
            return PartialView("../Able/Note1Detail", report);
        }

        // Search Columns
        private List<SelectListItem> GetSearchNotes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "CreatedBy", Value = "CreatedBy" });
            ls.Add(new SelectListItem() { Text = "DocumentType", Value = "DocumentType" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            return ls;
        }

        public async Task<IActionResult> Paymentsummarymv(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchPaymentsummarymvs();
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

                ViewData["Title"] = appName + " Payment Summarym Report";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchPaymentsummarymv(column, search, pageIndex, pageSize, staffFlag, appId);

                if (list == null)
                {
                    return RedirectToAction("Index");
                }

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
            var report = await _context.GetPaymentsummarymv(id);
            return PartialView("../AbleReports/PaymentsummarymvDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchPaymentsummarymvs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "BenefitNumber", Value = "BenefitNumber" });
            ls.Add(new SelectListItem() { Text = "BenefitType", Value = "BenefitType" });
            ls.Add(new SelectListItem() { Text = "PaymentMethod", Value = "PaymentMethod" });
            ls.Add(new SelectListItem() { Text = "PaymentReference", Value = "PaymentReference" });
            ls.Add(new SelectListItem() { Text = "BenefitAmount", Value = "BenefitAmount" });
            ls.Add(new SelectListItem() { Text = "StartDate", Value = "From" });
            ls.Add(new SelectListItem() { Text = "EndDate", Value = "To" });

            return ls;
        }

        public async Task<IActionResult> Documents(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchDocument();
                ViewBag.searchapps = GetSearchApplications();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["CaseNumber"] = search;

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

                ViewData["Title"] = appName + " Documents";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;
                var list = await _context.SearchDocumentA(column, search, pageIndex, pageSize, staffFlag, appId);

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
        public async Task<IActionResult> GetDocument()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetDocument(id);
            return PartialView("../Able/DocumentDetail", report);
        }

        private List<SelectListItem> GetSearchDocument()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "DocumentType", Value = "DocumentType" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "CreatedBy", Value = "CreatedBy" });
            return ls;
        }

        public async Task<IActionResult> PaymentSummarySheet(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchNotes();
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

                ViewData["Title"] = appName + " Paument Summary";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchNotesPS(column, search, pageIndex, pageSize, staffFlag, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Contact(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            ViewBag.searchcolumns = GetSearchContacts();
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

            ViewData["Title"] = appName + " Contacts";
            ViewData["SidebarPartial"] = "_SidebarA";

            ViewBag.appName = appName;
            ViewBag.appId = appId;

            var list = await _context.SearchContact(column, search, pageIndex, pageSize, appId);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetContact()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetContact(id, Convert.ToInt32(appId));
            return PartialView("../Able/ContactDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchContacts()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "Reason", Value = "Reason" });
            ls.Add(new SelectListItem() { Text = "Method", Value = "Method" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "DateTime", Value = "DateTime" });
            return ls;
        }

        public async Task<IActionResult> MedicalCode(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchMedicalCodes();
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

                ViewData["Title"] = appName + " Medical Codes";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchMedicalCode(column, search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetMedicalCode()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetMedicalCode(id);
            return PartialView("../Able/MedicalCodeDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchMedicalCodes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "Type", Value = "Type" });
            ls.Add(new SelectListItem() { Text = "Code", Value = "Code" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            ls.Add(new SelectListItem() { Text = "EffectiveFrom", Value = "EffectiveFrom" });
            return ls;
        }


        [HttpPost]
        public IActionResult GetAbleData(string entity, string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            switch (entity)
            {
                case "Claim":
                    break;
            }

            return View();
        }

        public async Task<IActionResult> Tasks(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                string _redirect = await ValidateUserAccount();
                if (_redirect == "YES")
                {
                    return RedirectToAction("AccessDenied", "Able");
                }

                ViewBag.searchcolumns = GetSearchTasks();
                ViewBag.searchapps = GetSearchApplications();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["CaseNumber"] = search;

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

                ViewData["Title"] = appName + " Claim Tasks";
                ViewData["SidebarPartial"] = "_SidebarA";

                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchTaskA("ClaimNumber", search, pageIndex, pageSize, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        private List<SelectListItem> GetSearchTasks()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ClaimNumber", Value = "ClaimNumber" });
            ls.Add(new SelectListItem() { Text = "TaskType", Value = "TaskType" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            ls.Add(new SelectListItem() { Text = "CreationDate", Value = "CreationDate" });
            return ls;
        }
    }
}
