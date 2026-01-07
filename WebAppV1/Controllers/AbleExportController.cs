using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAppV1.Controllers
{
    public class AbleExportController : Controller
    {
        private readonly IABLEExport _context;
        public const string LoginUser = "LoginUser";
        public const string ClaimId = "ClaimId";
        public const string AccessDenied = "AccessDenied";
        public const string HomeController = "Home";

        public AbleExportController(IABLEExport context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RptAbleuser()
        {
            var result = await _context.RptAbleUser();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RptAbleUserRole()
        {
            var result = await _context.RptAbleUserRole();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RptActionService()
        {
            var result = await _context.RptActionService();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RptCaseAction()
        {
            var result = await _context.RptCaseAction();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RptClaimBenefit()
        {
            var result = await _context.RptClaimBenefit();
            return RedirectToAction("Index");
        }

    }
}
