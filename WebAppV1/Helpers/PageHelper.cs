using AppCoreV1.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace WebAppV1.Helpers
{
    public class PageHelper : IPageHelper, IDisposable
    {
        private readonly ILogger<PageHelper> _logger;
        //private SiteUser _siteUser = null!;

        public PageHelper(ILogger<PageHelper> logger)
        {
            //_context = context;
            _logger = logger;   
        }

        //string encriptedString1 = config.GetConnectionString("ABLEPRDConnection") ?? string.Empty;
        //string _connectionString1 = AESSecurity.Decrypt(encriptedString1);

        //// ecrypt and decrypt dev
        //string encriptedString2 = config.GetConnectionString("ABLEConnection") ?? string.Empty;
        //var encryptedText2 = AESSecurity.Encrypt(encriptedString2);
        //Console.WriteLine($"Encrypted: {encryptedText2}");

        //var decryptedText2 = AESSecurity.Decrypt(encryptedText2);
        //Console.WriteLine($"Decrypted: {decryptedText2}");

        //// ecrypt and decrypt prd
        //string encriptedString3 = config.GetConnectionString("ABLEPRDConnection") ?? string.Empty;
        //var encryptedText3 = AESSecurity.Encrypt(encriptedString3);
        //Console.WriteLine($"Encrypted: {encryptedText3}");

        //var decryptedText3 = AESSecurity.Decrypt(encryptedText3);
        //Console.WriteLine($"Decrypted: {decryptedText3}");

        //public async Task<string> ValidateUser(string userName)
        //{
        //    string result = "Authorised";

        //    if (!string.IsNullOrEmpty(userName))
        //    {
        //        _logger.LogInformation("User " + userName + " is loggingin");

        //        //get site user
        //        var _siteUser = await _context.GetSiteUser(userName);

        //        if (_siteUser == null)
        //        {
        //            // site user is null
        //            result = "NotAuthorised";
        //        }
        //    }

        //    return result;
        //}

        //public async Task<SiteUser> GetSiteUser(string userid)
        //{
        //    return await _context.GetSiteUser(userid);
        //}

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
