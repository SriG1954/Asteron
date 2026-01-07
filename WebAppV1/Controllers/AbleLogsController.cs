using AppCoreV1.Interfaces;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleLogsController : Controller
    {
        private readonly IAbleSearch _context;
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";

        public AbleLogsController(IAbleSearch context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            var _rolename = HttpContext.Session.GetString("ABLERoleName");

            if (_rolename != "super")
            {
                string msg1 = "Your access to the ABLE Logs is denied.";
                string msg2 = "Please raise a SailPoint request to change your role";
                HttpContext.Session.SetString(Messag1, msg1);
                HttpContext.Session.SetString(Messag2, msg2);
                HttpContext.Session.SetString("ClaimNumber", string.Empty);

                return RedirectToAction("AccessDenied", "Able");
            }

            ViewBag.searchcolumns = GetSearchSiteLogs();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "SiteLogs";
            var list = await _context.SearchSiteLog(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetSiteLog()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetSiteLog(id);
            return PartialView("../AbleLogs/SiteLogDetail", report);
        }

        private List<SelectListItem> GetSearchSiteLogs()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "UserId", Value = "UserId" });
            ls.Add(new SelectListItem() { Text = "Message", Value = "Message" });
            ls.Add(new SelectListItem() { Text = "LogType", Value = "LogType" });
            ls.Add(new SelectListItem() { Text = "DateCreated", Value = "DateCreated" });
            return ls;
        }
    }
}
