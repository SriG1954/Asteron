using AppCoreV1.ABLEModels;
using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Web;

namespace WebAppV1.Controllers
{
    public class AbleTabsController : Controller
    {
        private readonly IAbleSearch _context;
        private readonly ILogger<AbleTabsController> _logger;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";

        public const string HomeController = "TABS";
        public string mySearch = string.Empty;
        public string myId = string.Empty;
        public string appName = "";

        public AbleTabsController(IAbleSearch context, ILogger<AbleTabsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: AbleTabsController

        public IActionResult Index(string search, string id)
        {
            try
            {
                if (search == "CaseDetail")
                {
                    return RedirectToAction("CaseDetail", "AbleTabs", id);
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> CaseDetail(string id)
        {
            try
            {
                string strid = HttpUtility.UrlDecode(id);
                ViewBag.searchcolumns = GetSearchClaimHub();
                ViewBag.search = mySearch;
                ViewBag.id = id;
                ViewData["Title"] = "Able Claim Hub";
                var report = await _context.GetCaseByClaimNo(strid);
                return View(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetClaimBenefitDetail()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaimbenefitmv(id);
            return PartialView("../AbleReports/ClaimbenefitmvDetail", report);
        }


        [HttpPost]
        public async Task<IActionResult> GetClaim()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaim(id);
            return PartialView("../AbleClaims/ClaimDetail", report);
        }

        [HttpPost]
        public async Task<IActionResult> GetClaimByClaimNumber()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaimByClaimNumber(id);
            return PartialView("../AbleClaims/ClaimDetail", report);
        }

        [HttpPost]
        public async Task<IActionResult> GetTasksByClaimNumber()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.SearchTaskmv("ClaimNumber", id, 1, 1000);
            return PartialView("../AbleTabs/Tasks", report);
        }

        [HttpPost]
        public async Task<IActionResult> GetDocumentsByClaimNumber()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.SearchRptDocumentreport("ClaimNumber", id, 1, 1000);
            return PartialView("../AbleTabs/Documents", report);
        }

        [HttpPost]
        public async Task<IActionResult> GetActionsByClaimNumber()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.SearchRptCaseaction("ClaimNumber", id, 1, 1000);
            return PartialView("../AbleTabs/Caseaction", report);
        }

        [HttpPost]
        public async Task<IActionResult> GetParticipantsByClaimNumber()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.SearchRptClaimparticipant("ClaimNumber", id, 1, 1000);
            return PartialView("../AbleTabs/Claimparticipant", report);
        }

        public async Task<IActionResult> ClaimHub(string search, int appId)
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

                ViewData["CaseNumber"] = search;
                var list = await _context.GetClaimbenefitmvByClaimNo(search);

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

                ViewData["Title"] = appName + " Claim Hub";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                //if (list != null && list.StaffInd != 0)
                //{
                //    if(_loginuser.RoleName != "admin")
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

        public async Task<IActionResult> GeneralClaim(string search, int appId)
        {
            try
            {
                ViewBag.column = "ClaimNumber";
                ViewBag.search = search;
                ViewData["Title"] = "General Claim";
                ViewData["CaseNumber"] = search;
                AppCoreV1.ABLEModels.Case _case = await _context.GetCaseByClaimNo(search, appId);
                AppCoreV1.ABLEModels.Claim _claim = await _context.GetClaimByClaimNumber(search, appId);
                PaginatedList<PartySearch> _party = await _context.SearchPartySearch("ClaimNumber", search, 1, 50, 0, appId);
                PaginatedList<Case> _child = await _context.GetChildCases(search, appId);
                List<Case> _links = await _context.GetLinkedCases(search, appId);

                if (_party == null)
                {
                    _party = PaginatedListHelper.GetPartySearch();
                }

                if (_child == null)
                {
                    _child = PaginatedListHelper.GetCase();
                }

                if (_case == null || _claim == null)
                {
                    throw new Exception("Case or claim is null");
                }

                ViewData["Claim"] = _claim;
                ViewData["Party"] = _party;
                ViewData["Child"] = _child;
                ViewData["Links"] = _links;

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

                ViewData["Title"] = appName + " Claim Hub";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                return View(_case);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("ClaimHub", new { search = search });
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetCaseDetail()
        {
            var id = Request.Form["ID"].ToString();
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetCaseByClaimNo(id, Convert.ToInt32(appId));
            return PartialView("../AbleTabs/CaseDetail", report);
        }

        public async Task<IActionResult> CoverageSearch(string search, int appId)
        {
            try
            {
                //ViewBag.column = column;
                ViewBag.search = search;
                ViewData["CaseNumber"] = search;
                //ViewBag.PageNumber = pageIndex;

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

                ViewData["Title"] = appName + " Coverage";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var report = await _context.GetCoverageSearch(search, appId);

                return View(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetCoverageSearch()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetCoverageSearch(id);
            return PartialView("../AbleTabs/CoverageSearchDetail", report);
        }


        public async Task<IActionResult> MedicalCode(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                ViewBag.column = column;
                ViewBag.search = search;
                ViewData["CaseNumber"] = search;
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
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchMedicalCode("ClaimNumber", search, pageIndex, pageSize, appId);

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

            var report = await _context.GetMedicalCode(id, Convert.ToInt32(appId));
            return PartialView("../AbleTabs/MedicalCodeDetail", report);
        }

        // tab claim notes
        public async Task<IActionResult> NotesExtDocument(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
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

                ViewData["Title"] = appName + " Claim Notes External Document";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchNote1("CaseNumber", search, pageIndex, pageSize, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> NotesEform(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
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

                ViewData["Title"] = appName + " Claim Notes Eform";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchNote2("CaseNumber", search, pageIndex, pageSize, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> CaseHistory(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
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

                ViewData["Title"] = appName + " Claim Case History";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchTaskA("ClaimNumber", search, pageIndex, pageSize, appId);

                //PaginatedList<DocumentA> _documents = await _context.SearchDocument("ClaimNumber", search, pageIndex, pageSize);
                //PaginatedList<Contact> _contacts = await _context.SearchContact("ClaimNumber", search, pageIndex, pageSize);
                //PaginatedList<OutstandingRequest> _requests = await _context.SearchOutstandingRequest("ClaimNumber", search, pageIndex, pageSize);

                //ViewData["Tasks"] = _tasks;
                //ViewData["Documents"] = _documents;
                //ViewData["Contacts"] = _contacts;
                //ViewData["Requests"] = _requests;

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // tab claim tasks
        public async Task<IActionResult> Tasks(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
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

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetTaskA()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetTaskA(id);
            return PartialView("../AbleTabs/TaskADetail", report);
        }

        // tab claim documents
        public async Task<IActionResult> Documents(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchDocument();
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
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchDocument("ClaimNumber", search, pageIndex, pageSize, appId);

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
            var appId = Request.Form["AppID"].ToString();

            var report = await _context.GetDocument(id, Convert.ToInt32(appId));

            return PartialView("../AbleTabs/DocumentDetail", report);
        }

        private List<SelectListItem> GetSearchDocument()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "EnvelopId", Value = "EnvelopId" });
            ls.Add(new SelectListItem() { Text = "DocumentType", Value = "DocumentType" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "CreatedBy", Value = "CreatedBy" });
            return ls;
        }

        // tab claim actions
        public async Task<IActionResult> CaseActions(string search, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
                //ViewBag.column = column;
                ViewBag.search = search;
                //ViewBag.PageNumber = pageIndex;
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

                ViewData["Title"] = appName + " Claim Case Actions";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchCaseAction(search, appId);
                //var list = await _context.SearchRptCaseaction("ClaimNumber", search, pageIndex, pageSize);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // tab claim phone enquiries
        public async Task<IActionResult> Contact(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchNote1s();
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

                ViewData["Title"] = appName + " Claim Phone Enquiries";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchContact("ClaimNumber", search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetContact()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetContact(id);
            return PartialView("../AbleTabs/ContactDetail", report);
        }

        // tab claim cmp services
        public async Task<IActionResult> CMPServices(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                var result = await _context.GetTabCMP(search, appId);

                //ViewBag.searchcolumns = GetSearchNote1s();
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

                ViewData["Title"] = appName + " Claim CPM Services";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchRptCmpservice("ClaimNumber", search, pageIndex, pageSize, appId);

                return View(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        //// AbleReport controller Post method
        //[HttpPost]
        //public async Task<IActionResult> GetNote1()
        //{
        //    var id = Request.Form["ID"].ToString();
        //    var report = await _context.GetNote1(id);
        //    return PartialView("../AbleTabs/Note1Detail", report);
        //}

        // tab claim phone enquiries
        public async Task<IActionResult> CaseValidation(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
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

                ViewData["Title"] = appName + " Claim Case Validation";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchCaseValidation("ClaimNumber", search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetCaseValidation()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetCaseValidation(id);
            return PartialView("../AbleTabs/CaseValidationDetail", report);
        }

        public async Task<IActionResult> OutstandingRequest(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
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

                ViewData["Title"] = appName + " Outstanding Requests";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchOutstandingRequest("ClaimNumber", search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetOutstandingRequest()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetOutstandingRequest(id);
            return PartialView("../AbleTabs/OutstandingRequestDetail", report);
        }


        private List<SelectListItem> GetSearchNote1s()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "C", Value = "C" });
            ls.Add(new SelectListItem() { Text = "I", Value = "I" });
            ls.Add(new SelectListItem() { Text = "PartyC", Value = "PartyC" });
            ls.Add(new SelectListItem() { Text = "PartyI", Value = "PartyI" });
            ls.Add(new SelectListItem() { Text = "ContactC", Value = "ContactC" });
            return ls;
        }


        private List<SelectListItem> GetSearchClaimHub()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "CaseDetails", Value = "CaseDetails" });
            ls.Add(new SelectListItem() { Text = "ClaimDetails", Value = "ClaimDetails" });
            ls.Add(new SelectListItem() { Text = "Participants", Value = "Participants" });
            ls.Add(new SelectListItem() { Text = "Policies", Value = "TriageSegment" });
            ls.Add(new SelectListItem() { Text = "Coverages", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Medical", Value = "Medical" });
            ls.Add(new SelectListItem() { Text = "Benefits", Value = "Benefits" });
            return ls;
        }

        public async Task<IActionResult> Occupation(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                ViewBag.searchcolumns = GetSearchOccupations();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "Occupations";

                var list = await _context.SearchOccupation(column, search, pageIndex, pageSize);

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
        public async Task<IActionResult> GetOccupation()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetOccupation(id);
            return PartialView("../AbleTabs/OccupationDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchOccupations()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "C", Value = "C" });
            ls.Add(new SelectListItem() { Text = "I", Value = "I" });
            ls.Add(new SelectListItem() { Text = "ClaimC", Value = "ClaimC" });
            ls.Add(new SelectListItem() { Text = "ClaimI", Value = "ClaimI" });
            ls.Add(new SelectListItem() { Text = "PartyC", Value = "PartyC" });
            return ls;
        }

        public async Task<IActionResult> ClaimOccupation(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchClaimOccupations();
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

                ViewData["Title"] = appName + " Occupation";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchClaimOccupation("ClaimNumber", search, pageIndex, pageSize, appId);

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
        public async Task<IActionResult> GetClaimOccupation()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaimOccupation(id);
            return PartialView("../AbleTabs/ClaimOccupationDetail", report);
        }

        public async Task<IActionResult> ClaimPeriod(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            try
            {
                //ViewBag.searchcolumns = GetSearchClaimPeriods();
                ViewBag.column = column;
                ViewBag.search = search;
                ViewBag.PageNumber = pageIndex;
                ViewData["Title"] = "ClaimPeriods";

                var list = await _context.SearchClaimPeriod(column, search, pageIndex, pageSize);

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
        public async Task<IActionResult> GetClaimPeriod()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaimPeriod(id);
            return PartialView("../AbleTabs/ClaimPeriodDetail", report);
        }

        public async Task<IActionResult> CMP(string search, int appId)
        {
            try
            {
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

                ViewData["Title"] = appName + " CPM";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var result = await _context.GetTabCMP(search, appId);
                ViewData["CaseNumber"] = search;

                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetClientGoal()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClientGoal(id);
            return PartialView("../AbleTabs/ClientGoalDetail", report);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetGoal()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetGoal(id);
            return PartialView("../AbleTabs/GoalDetail", report);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetActionA()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetActionA(id);
            return PartialView("../AbleTabs/ActionADetail", report);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetLifeArea()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetLifeArea(id);
            return PartialView("../AbleTabs/LifeAreaDetail", report);
        }

        public async Task<IActionResult> WorkStatus(string search, int appId)
        {
            try
            {
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

                ViewData["Title"] = appName + " Claim Workstatus";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var result = await _context.SearchClaimIncapacityPeriod("ClaimNumber", search, appId, 25, appId);
                ViewData["CaseNumber"] = search;

                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index", "Home");
            }
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetActionHistory()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetActionHistory(id);
            return PartialView("../AbleTabs/ActionHistoryDetail", report);
        }

        public async Task<IActionResult> Notes(string column, string search, int pageIndex = 1, int pageSize = 25, int appId = 1)
        {
            try
            {
                ViewBag.searchcolumns = GetSearchNotes();
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

                ViewData["Title"] = appName + " Notes";
                ViewBag.appName = appName;
                ViewBag.appId = appId;

                var list = await _context.SearchNotes("ClaimNumber", search, pageIndex, pageSize, 0, appId);

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
            var report = await _context.GetNote1(id);
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
    }
}
