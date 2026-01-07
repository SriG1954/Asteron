using AppCoreV1.ABLEModels;
using AppCoreV1.Data;
using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleIssuesController : Controller
    {
        private readonly IAbleSearch _context;
        private readonly AbleDBContext _context1;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";
        public const string HomeController = "Home";
        public string RedirectPage = string.Empty;

        public AbleIssuesController(IAbleSearch context, AbleDBContext context1)
        {
            _context = context;
            _context1 = context1;
        }

        public async Task<IActionResult> Index(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchAbleIssues();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "AbleIssues";

            var list = await _context.SearchAbleIssue(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetAbleIssue()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetAbleIssue(id);
            return PartialView("../AbleIssues/AbleIssueDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchAbleIssues()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "ReportedBy", Value = "ReportedBy" });
            ls.Add(new SelectListItem() { Text = "Description", Value = "Description" });
            ls.Add(new SelectListItem() { Text = "DateReported", Value = "DateReported" });
            ls.Add(new SelectListItem() { Text = "Status", Value = "Status" });
            return ls;
        }

        // GET: IssuesController/Create
        public ActionResult Create()
        {
            AbleIssue issue = new AbleIssue();
            return View(issue);
        }

        // POST: IssuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AbleIssue issue)
        {
            try
            {
                if (issue != null)
                {
                    issue.DateReported = DateTime.Now.ToString();
                    issue.Status = "New";

                    _context1.AbleIssues.Add(issue);
                    await _context1.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: IssuesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                var issue = await _context.GetAbleIssue(id);
                //var issue = await _dbcontext.FigIssues.FirstOrDefaultAsync(m => m.Id == id);
                return View(issue);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: IssuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AbleIssue issue)
        {
            try
            {
                _context1.AbleIssues.Update(issue);
                await _context1.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: IssuesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IssuesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
