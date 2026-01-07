using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AsteronController : Controller
    {
        private readonly IAsteronSearch _context;
        private readonly ILogger<AsteronController> _logger;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";
        public const string HomeController = "Home";
        public int staffFlag = 0;
        public string RedirectPage = string.Empty;
        public string appName = "Asteron";

        public AsteronController(IAsteronSearch context, ILogger<AsteronController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Claim(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchClaims();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Claims";

            var list = await _context.SearchClaim(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetClaim()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetClaim(id);
            return PartialView("../Asteron/ClaimDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchClaims()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Claimnumber", Value = "Claimnumber" });
            ls.Add(new SelectListItem() { Text = "Policyid", Value = "Policyid" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Closedate", Value = "Closedate" });
            return ls;
        }

        public async Task<IActionResult> Policy(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchPolicys();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Policys";

            var list = await _context.SearchPolicy(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetPolicy()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetPolicy(id);
            return PartialView("../Asteron/PolicyDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchPolicys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Accountnumber", Value = "Accountnumber" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "Cancellationdate", Value = "Cancellationdate" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Createuserid", Value = "Createuserid" });
            return ls;
        }

        public async Task<IActionResult> Note(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchNotes();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Notes";

            var list = await _context.SearchNote(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetNote()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetNote(id);
            return PartialView("../Asteron/NoteDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchNotes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Activityid", Value = "Activityid" });
            ls.Add(new SelectListItem() { Text = "Authorid", Value = "Authorid" });
            ls.Add(new SelectListItem() { Text = "Authoringdate", Value = "Authoringdate" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "Body", Value = "Body" });
            return ls;
        }

        public async Task<IActionResult> Document(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchDocuments();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Documents";

            var list = await _context.SearchDocument(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetDocument()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetDocument(id);
            return PartialView("../Asteron/DocumentDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchDocuments()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Author", Value = "Author" });
            ls.Add(new SelectListItem() { Text = "Authordenorm", Value = "Authordenorm" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "Claimcontactid", Value = "Claimcontactid" });
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            return ls;
        }

        public async Task<IActionResult> Activity(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchActivitys();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Activitys";

            var list = await _context.SearchActivity(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetActivity()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetActivity(id);
            return PartialView("../Asteron/ActivityDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchActivitys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Activityclass", Value = "Activityclass" });
            ls.Add(new SelectListItem() { Text = "Activitypatternid", Value = "Activitypatternid" });
            ls.Add(new SelectListItem() { Text = "Assignedbyuserid", Value = "Assignedbyuserid" });
            ls.Add(new SelectListItem() { Text = "Assignedgroupid", Value = "Assignedgroupid" });
            ls.Add(new SelectListItem() { Text = "Assignedqueueid", Value = "Assignedqueueid" });
            return ls;
        }

        public async Task<IActionResult> History(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchHistorys();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Historys";

            var list = await _context.SearchHistory(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetHistory()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetHistory(id);
            return PartialView("../Asteron/HistoryDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchHistorys()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Customtype", Value = "Customtype" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Eventtimestamp", Value = "Eventtimestamp" });
            return ls;
        }

        public async Task<IActionResult> Contact(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchContacts();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Contacts";

            var list = await _context.SearchContact(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetContact()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetContact(id);
            return PartialView("../Asteron/ContactDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchContacts()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Addressbookuid", Value = "Addressbookuid" });
            ls.Add(new SelectListItem() { Text = "Afterhours", Value = "Afterhours" });
            ls.Add(new SelectListItem() { Text = "Attorneylicense", Value = "Attorneylicense" });
            ls.Add(new SelectListItem() { Text = "AutopaymentallowedExt", Value = "AutopaymentallowedExt" });
            ls.Add(new SelectListItem() { Text = "Autosync", Value = "Autosync" });
            return ls;
        }

        public async Task<IActionResult> Address(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchAddresss();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Addresss";

            var list = await _context.SearchAddress(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetAddress()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetAddress(id);
            return PartialView("../Asteron/AddressDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchAddresss()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Addressline1", Value = "Addressline1" });
            ls.Add(new SelectListItem() { Text = "Addressline2", Value = "Addressline2" });
            ls.Add(new SelectListItem() { Text = "Addressline3", Value = "Addressline3" });
            ls.Add(new SelectListItem() { Text = "Addresstype", Value = "Addresstype" });
            ls.Add(new SelectListItem() { Text = "Batchgeocode", Value = "Batchgeocode" });
            return ls;
        }

        public async Task<IActionResult> Coverage(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchCoverages();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Coverages";

            var list = await _context.SearchCoverage(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetCoverage()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetCoverage(id);
            return PartialView("../Asteron/CoverageDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchCoverages()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Createuserid", Value = "Createuserid" });
            ls.Add(new SelectListItem() { Text = "Currency", Value = "Currency" });
            ls.Add(new SelectListItem() { Text = "Effectivedate", Value = "Effectivedate" });
            return ls;
        }

        public async Task<IActionResult> Incident(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchIncidents();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Incidents";

            var list = await _context.SearchIncident(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetIncident()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetIncident(id);
            return PartialView("../Asteron/IncidentDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchIncidents()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Id", Value = "Id" });
            ls.Add(new SelectListItem() { Text = "Ambulanceused", Value = "Ambulanceused" });
            ls.Add(new SelectListItem() { Text = "Beanversion", Value = "Beanversion" });
            ls.Add(new SelectListItem() { Text = "ClaimanttypeExt", Value = "ClaimanttypeExt" });
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            return ls;
        }

    }
}
