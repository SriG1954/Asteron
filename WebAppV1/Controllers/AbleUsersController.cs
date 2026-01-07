using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleUsersController : Controller
    {
        private readonly IAbleSearch _context;
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";

        public AbleUsersController(IAbleSearch context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            var _rolename = HttpContext.Session.GetString("ABLERoleName");

            if (_rolename != "super")
            {
                string msg1 = "Your access to the ABLE Site Users is denied.";
                string msg2 = "Please raise a SailPoint request to change your role";
                HttpContext.Session.SetString(Messag1, msg1);
                HttpContext.Session.SetString(Messag2, msg2);
                HttpContext.Session.SetString("ClaimNumber", string.Empty);

                return RedirectToAction("AccessDenied", "Able");
            }
            ViewBag.searchcolumns = GetSearchAbleSiteUsers();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "AbleSiteUsers";
            var list = await _context.SearchAbleSiteUser(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetAbleSiteUser()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetAbleSiteUser(id);
            return PartialView("../AbleUsers/AbleSiteUserDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchAbleSiteUsers()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "UserId", Value = "UserId" });
            ls.Add(new SelectListItem() { Text = "UserName", Value = "UserName" });
            ls.Add(new SelectListItem() { Text = "RoleName", Value = "RoleName" });
            return ls;
        }
    }
}
