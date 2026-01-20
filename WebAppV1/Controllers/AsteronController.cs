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

        public IActionResult Dashboard(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Dashboard";

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

        public async Task<IActionResult> ClaimLinks(string id)
        {
            ViewData["Title"] = "Claim Links";
            var claim = await _context.GetClaim(id);
            ViewData["Claim"] = claim;

            string claimid = claim.Id.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Closedate", Value = "Closedate" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });

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
            ls.Add(new SelectListItem() { Text = "Policynumber", Value = "Policynumber" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
            ls.Add(new SelectListItem() { Text = "Policytype", Value = "Policytype" });
            ls.Add(new SelectListItem() { Text = "Currency", Value = "Currency" });
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

        public async Task<IActionResult> NoteLinks(string id)
        {
            ViewData["Title"] = "Note Links";
            var note = await _context.GetNote(id);
            ViewData["Note"] = note;
            string claimid = note.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Subject", Value = "Subject" });
            ls.Add(new SelectListItem() { Text = "Topic", Value = "Topic" });
            ls.Add(new SelectListItem() { Text = "Body", Value = "Body" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
            ls.Add(new SelectListItem() { Text = "Retired", Value = "Retired" });

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

        public async Task<IActionResult> DocumentLinks(string id)
        {
            ViewData["Title"] = "Claim Links";
            var document = await _context.GetDocument(id);
            ViewData["Document"] = document;

            string claimid = document.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Docuid", Value = "Docuid" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Mimetype", Value = "Mimetype" });
            ls.Add(new SelectListItem() { Text = "Name", Value = "Name" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
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

        public async Task<IActionResult> ActivityLinks(string id)
        {
            ViewData["Title"] = "Activity Links";
            var activity = await _context.GetActivity(id);
            ViewData["Activity"] = activity;
            string claimid = activity.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Subject", Value = "Subject" });
            ls.Add(new SelectListItem() { Text = "Subtype", Value = "Subtype" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
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

        public async Task<IActionResult> HistoryLinks(string id)
        {
            ViewData["Title"] = "History Links";
            var history = await _context.GetHistory(id);
            ViewData["History"] = history;
            string claimid = history.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Eventtimestamp", Value = "Eventtimestamp" });
            ls.Add(new SelectListItem() { Text = "Subtype", Value = "Subtype" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
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

        public async Task<IActionResult> ContactLinks(string id)
        {
            ViewData["Title"] = "Contact Links";
            var claimcontact = await _context.GetClaimcontactByContactId(id);
            var contact = await _context.GetContact(id);
            ViewData["Contact"] = contact;

            string claimid = claimcontact.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Firstname", Value = "Firstname" });
            ls.Add(new SelectListItem() { Text = "Lastname", Value = "Lastname" });
            ls.Add(new SelectListItem() { Text = "Gender", Value = "Gender" });
            ls.Add(new SelectListItem() { Text = "Dateofbirth", Value = "Dateofbirth" });
            ls.Add(new SelectListItem() { Text = "Cellphone", Value = "Cellphone" });
            ls.Add(new SelectListItem() { Text = "Emailaddress1", Value = "Emailaddress1" });
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
            ls.Add(new SelectListItem() { Text = "Addressline1", Value = "Addressline1" });
            ls.Add(new SelectListItem() { Text = "Addressline2", Value = "Addressline2" });
            ls.Add(new SelectListItem() { Text = "City", Value = "City" });
            ls.Add(new SelectListItem() { Text = "Country", Value = "Country" });
            ls.Add(new SelectListItem() { Text = "Postalcode", Value = "Postalcode" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });

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
            ls.Add(new SelectListItem() { Text = "Policyid", Value = "Policyid" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Currency", Value = "Currency" });
            ls.Add(new SelectListItem() { Text = "Effectivedate", Value = "Effectivedate" });
            ls.Add(new SelectListItem() { Text = "Expirationdate", Value = "Expirationdate" });
            ls.Add(new SelectListItem() { Text = "Riskunitid", Value = "Riskunitid" });
            ls.Add(new SelectListItem() { Text = "Subtype", Value = "Subtype" });
            ls.Add(new SelectListItem() { Text = "Type", Value = "Type" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });

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

        public async Task<IActionResult> IncidentLinks(string id)
        {
            ViewData["Title"] = "Claim Links";
            var incident = await _context.GetIncident(id);
            ViewData["Incident"] = incident;

            string claimid = incident.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
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
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Detailedinjurytype", Value = "Detailedinjurytype" });
            ls.Add(new SelectListItem() { Text = "Generalinjurytype", Value = "Generalinjurytype" });
            ls.Add(new SelectListItem() { Text = "Subtype", Value = "Subtype" });
            ls.Add(new SelectListItem() { Text = "Publicid", Value = "Publicid" });
            return ls;
        }

        public async Task<IActionResult> Complaint(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchComplaints();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Complaints";

            var list = await _context.SearchComplaint(column, search, pageIndex, pageSize);

            return View(list);
        }

        public async Task<IActionResult> ComplaintLinks(string id)
        {
            ViewData["Title"] = "Complaint Links";
            var complaint = await _context.GetComplaint(id);
            ViewData["Complaint"] = complaint;

            string claimid = complaint.Claimid.ToString()!;
            var activityLinks = await _context.GetClaimDetails(claimid);

            return View(activityLinks);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetComplaint()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetComplaint(id);
            return PartialView("../Asteron/ComplaintDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchComplaints()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Complaintnumber", Value = "Complaintnumber" });
            ls.Add(new SelectListItem() { Text = "Claimid", Value = "Claimid" });
            ls.Add(new SelectListItem() { Text = "Createtime", Value = "Createtime" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "Incidentdate", Value = "Incidentdate" });
            ls.Add(new SelectListItem() { Text = "Resolutiondescription", Value = "Resolutiondescription" });
            return ls;
        }
    }
}
