using AppCoreV1.ABLEModels;
using AppCoreV1.Data;
using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppV1.Controllers
{
    public class AbleEmailsController : Controller
    {
        private readonly IAbleSearch _context;
        private readonly AbleDBContext _context1;

        public const string LoginUser = "LoginUser";
        public const string ClaimNumber = "ClaimNumber";
        public const string Messag1 = "Messag1";
        public const string Messag2 = "Messag2";
        public const string HomeController = "Home";
        public string RedirectPage = string.Empty;

        public AbleEmailsController(IAbleSearch context, AbleDBContext context1)
        {
            _context = context;
            _context1 = context1;
        }

        public async Task<IActionResult> Index(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            ViewBag.searchcolumns = GetSearchEmails();
            ViewBag.column = column;
            ViewBag.search = search;
            ViewBag.PageNumber = pageIndex;
            ViewData["Title"] = "Emails";
            var list = await _context.SearchEmail(column, search, pageIndex, pageSize);

            return View(list);
        }

        // AbleReport controller Post method
        [HttpPost]
        public async Task<IActionResult> GetEmail()
        {
            var id = Request.Form["ID"].ToString();
            var report = await _context.GetEmail(id);
            return PartialView("../AbleEmails/EmailDetail", report);
        }

        // Search Columns

        private List<SelectListItem> GetSearchEmails()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "SenderEmail", Value = "SenderEmail" });
            ls.Add(new SelectListItem() { Text = "RecipientEmail", Value = "RecipientEmail" });
            ls.Add(new SelectListItem() { Text = "MailSubject", Value = "MailSubject" });
            ls.Add(new SelectListItem() { Text = "MailBody", Value = "MailBody" });
            ls.Add(new SelectListItem() { Text = "DateSent", Value = "DateSent" });
            return ls;
        }


        // GET: EmailsController/Create
        public ActionResult Create()
        {
            AbleEmail email = new AbleEmail();
            return View(email);
        }

        // POST: EmailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AbleEmail email)
        {
            try
            {
                if (email != null)
                {
                    email.DateSent = DateTime.Now;

                    _context1.Emails.Add(email);
                    await _context1.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: EmailsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var email = await _context.GetEmail(id);
            return View(email);
        }

        // POST: EmailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AbleEmail email)
        {
            try
            {
                _context1.Emails.Update(email);
                await _context1.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: EmailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmailsController/Delete/5
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
