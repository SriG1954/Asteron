using AppCoreV1.ABLEModels;

namespace WebAppV1.Helpers
{
    public class ValidateABLELoginUser
    {
        private AbleSiteUser _siteUser = null!;
        private string myresult = string.Empty;
        private readonly RequestDelegate _next;
        public const string SessionName = "ABLESession";
        public const string UserName = "ABLEUserName";
        public const string RoleName = "ABLERoleName";

        public ValidateABLELoginUser(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string _sessionValue = context.Session?.GetString(SessionName) ?? string.Empty;

            if (_sessionValue != "Authorised")
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                    var _helper = scope.ServiceProvider.GetRequiredService<IABLEPageHelper>();
                    var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ValidateABLELoginUser>>();

                    myresult = "Authorised";
                    string? loginuser = context.User.Identity?.Name;

                    if (!string.IsNullOrEmpty(loginuser))
                    {
                        //get site user
                        _siteUser = await _helper.GetSiteUser(loginuser);

                        if (_siteUser.UserId == null || _siteUser.UserId != loginuser || _siteUser.IsActive == false)
                        {
                            // site user is null
                            myresult = "NotAuthorised";
                        }
                    }

                    // save result in session
                    context.Session?.SetString(SessionName, myresult);
                    context.Session?.SetString(UserName, _siteUser!.UserName!);
                    context.Session?.SetString(RoleName, _siteUser!.RoleName!);

                    await _helper.LogSiteUser(_siteUser, myresult);
                }

                if (myresult == "NotAuthorised")
                {
                    // get route data
                    var routeData = context.GetRouteData();

                    // change to access denied
                    routeData.Values["controller"] = "Home";
                    routeData.Values["action"] = "AccessDenied";
                }
            }

            await _next(context);
        }

    }
}
