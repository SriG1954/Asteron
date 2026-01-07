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
    }
}
