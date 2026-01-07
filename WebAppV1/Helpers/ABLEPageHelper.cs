using AppCoreV1.ABLEModels;
using AppCoreV1.Interfaces;

namespace WebAppV1.Helpers
{
    public class ABLEPageHelper : IABLEPageHelper, IDisposable
    {
        private readonly IAbleSearch _context;
        private readonly ILogger<ABLEPageHelper> _logger;
        private AbleSiteUser _siteUser = null!;

        public ABLEPageHelper(IAbleSearch context, ILogger<ABLEPageHelper> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> ValidateUser(string userName)
        {
            string result = "Authorised";

            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    _logger.LogInformation("User " + userName + " is loggingin");

                    //get site user
                    _siteUser = await _context.GetSiteUser(userName);

                    if (_siteUser == null)
                    {
                        // site user is null
                        result = "NotAuthorised";
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return result;
        }

        public async Task LogSiteUser(AbleSiteUser siteuser, string result)
        {
            SiteLog _log = new SiteLog
            {
                Id = 0,
                UserId = siteuser.UserId,
                Message = siteuser.UserName + " is " + result + " to login",
                LogType = "Login",
                DateCreated = DateTime.Now.ToString(),
            };

            await _context.AddSiteLog(_log);
        }

        public async Task<AbleSiteUser> GetSiteUser(string userid)
        {
            return await _context.GetSiteUser(userid);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
