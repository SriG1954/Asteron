using AppCoreV1.ABLEModels;
using AppCoreV1.Data;
using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleExportRequestController : Controller
    {
        private readonly AbleDBContext _context1;
        private readonly IAbleSearch _context;

        public const string LoginUser = "LoginUser";
        public const string ClaimId = "ClaimId";
        public const string AccessDenied = "AccessDenied";
        public const string HomeController = "Home";

        public AbleExportRequestController(AbleDBContext context1, IAbleSearch context)
        {
            _context1 = context1;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ReportRequest(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchReportRequests();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "ReportRequests";

            var list = await _context.SearchReportRequest(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetReportRequest()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetReportRequest(id);
            return PartialView("../AbleExportRequest/ReportRequestDetail", report);
        }

        private List<SelectListItem> GetSearchReportRequests()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "UserId", Value = "UserId" });
            ls.Add(new SelectListItem() { Text = "ReportName", Value = "ReportName" });
            ls.Add(new SelectListItem() { Text = "Email", Value = "Email" });
            ls.Add(new SelectListItem() { Text = "DateRequested", Value = "DateRequested" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            return ls;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.reportnames = GetReportNames();

            ReportRequest req = new ReportRequest
            {
                Id = 0,
                UserId = "",
                ReportName = string.Empty,
                Email = string.Empty,
                DateRequested = DateTime.Now,
                Status = "New",
            };

            return View(req);
        }

        private List<SelectListItem> GetReportNames()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "RptAbleUser", Value = "RptAbleUser" });
            ls.Add(new SelectListItem() { Text = "RptAbleUserRole", Value = "RptAbleUserRole" });
            ls.Add(new SelectListItem() { Text = "RptActionService", Value = "RptActionService" });
            ls.Add(new SelectListItem() { Text = "RptCaseAction", Value = "RptCaseAction" });
            ls.Add(new SelectListItem() { Text = "RptClaimBenefit", Value = "RptClaimBenefit" });

            ls.Add(new SelectListItem() { Text = "RptClaimBenefitActuarialRec", Value = "RptClaimBenefitActuarialRec" });
            ls.Add(new SelectListItem() { Text = "RptClaimBenefitGroup", Value = "RptClaimBenefitGroup" });
            ls.Add(new SelectListItem() { Text = "RptClaimBenefitReinsurance", Value = "RptClaimBenefitReinsurance" });
            ls.Add(new SelectListItem() { Text = "RptClaimBenefitWS", Value = "RptClaimBenefitWS" });
            ls.Add(new SelectListItem() { Text = "RptClaimCaseDecipha", Value = "RptClaimCaseDecipha" });

            ls.Add(new SelectListItem() { Text = "RptClaimParticipant", Value = "RptClaimParticipant" });
            ls.Add(new SelectListItem() { Text = "RptClosedTaskReport", Value = "RptClosedTaskReport" });
            ls.Add(new SelectListItem() { Text = "RptCMPActions", Value = "RptCMPActions" });
            ls.Add(new SelectListItem() { Text = "RptCMPGDMovements", Value = "RptCMPGDMovements" });
            ls.Add(new SelectListItem() { Text = "RptCMPPlanStatus", Value = "RptCMPPlanStatus" });

            ls.Add(new SelectListItem() { Text = "RptCMPService", Value = "RptCMPService" });
            ls.Add(new SelectListItem() { Text = "RptComplaints", Value = "RptComplaints" });
            ls.Add(new SelectListItem() { Text = "RptDocumentReport", Value = "RptDocumentReport" });
            ls.Add(new SelectListItem() { Text = "RptEnquiryCaseReport", Value = "RptEnquiryCaseReport" });
            ls.Add(new SelectListItem() { Text = "RptHCRCompletedNotes", Value = "RptHCRCompletedNotes" });

            ls.Add(new SelectListItem() { Text = "RptOpenTask", Value = "RptOpenTask" });
            ls.Add(new SelectListItem() { Text = "RptOverrideRiskReport", Value = "RptOverrideRiskReport" });
            ls.Add(new SelectListItem() { Text = "RptPaymentSummary", Value = "RptPaymentSummary" });
            ls.Add(new SelectListItem() { Text = "RptPaymentSummaryLS", Value = "RptPaymentSummaryLS" });
            ls.Add(new SelectListItem() { Text = "RptPhoneEnquiry", Value = "RptPhoneEnquiry" });

            ls.Add(new SelectListItem() { Text = "RptRecoveryRehabNote", Value = "RptRecoveryRehabNote" });
            ls.Add(new SelectListItem() { Text = "RptTaskReport", Value = "RptTaskReport" });
            ls.Add(new SelectListItem() { Text = "RptTaskReportGroup", Value = "RptTaskReportGroup" });
            ls.Add(new SelectListItem() { Text = "RptTaskReportReinsurance", Value = "RptTaskReportReinsurance" });
            return ls;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReportRequest req)
        {
            _context1.Add(req);
            await _context1.SaveChangesAsync();
            return RedirectToAction("ReportRequest");
        }
    }
}
