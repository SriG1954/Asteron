using AppCoreV1.ABLEModels;

namespace WebAppV1.Helpers
{
    public interface IABLEPageHelper
    {
        Task<AbleSiteUser> GetSiteUser(string userid);
        Task<string> ValidateUser(string userName);
        Task LogSiteUser(AbleSiteUser siteuser, string result);
    }
}
