using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAppV1.Controllers
{
    public class AsteronDownloadController : Controller
    {
        private readonly IXLSAsteronHelper _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AsteronDownloadController> _logger;

        public AsteronDownloadController(IXLSAsteronHelper context, IConfiguration configuration, ILogger<AsteronDownloadController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<FileResult> GetClaims(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetClaims(column, search, pageIndex, pageSize);

            string filename = "Claims" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetClaim(string id)
        {
            byte[] data = null!;
            data = await _context.GetClaim(id);

            string filename = "Claim" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetPolicys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetPolicys(column, search, pageIndex, pageSize);

            string filename = "Policys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetPolicy(string id)
        {
            byte[] data = null!;
            data = await _context.GetPolicy(id);

            string filename = "Policy" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetNotes(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetNotes(column, search, pageIndex, pageSize);

            string filename = "Notes" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetNote(string id)
        {
            byte[] data = null!;
            data = await _context.GetNote(id);

            string filename = "Note" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetDocuments(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetDocuments(column, search, pageIndex, pageSize);

            string filename = "Documents" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetDocument(string id)
        {
            byte[] data = null!;
            data = await _context.GetDocument(id);

            string filename = "Document" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetActivitys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetActivitys(column, search, pageIndex, pageSize);

            string filename = "Activitys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetActivity(string id)
        {
            byte[] data = null!;
            data = await _context.GetActivity(id);

            string filename = "Activity" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetHistorys(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetHistorys(column, search, pageIndex, pageSize);

            string filename = "Historys" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetHistory(string id)
        {
            byte[] data = null!;
            data = await _context.GetHistory(id);

            string filename = "History" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetContacts(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetContacts(column, search, pageIndex, pageSize);

            string filename = "Contacts" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetContact(string id)
        {
            byte[] data = null!;
            data = await _context.GetContact(id);

            string filename = "Contact" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetAddresss(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetAddresss(column, search, pageIndex, pageSize);

            string filename = "Addresss" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetAddress(string id)
        {
            byte[] data = null!;
            data = await _context.GetAddress(id);

            string filename = "Address" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetCoverages(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetCoverages(column, search, pageIndex, pageSize);

            string filename = "Coverages" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetCoverage(string id)
        {
            byte[] data = null!;
            data = await _context.GetCoverage(id);

            string filename = "Coverage" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        public async Task<FileResult> GetIncidents(string column, string search, int pageIndex = 1, int pageSize = 25)
        {
            byte[] data = null!;
            data = await _context.GetIncidents(column, search, pageIndex, pageSize);

            string filename = "Incidents" + search + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        // Details Download
        public async Task<FileResult> GetIncident(string id)
        {
            byte[] data = null!;
            data = await _context.GetIncident(id);

            string filename = "Incident" + id + DateTime.Now.ToString("ddMMyyyyHHss") + ".xlsx";
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


    }
}
