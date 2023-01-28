using Project.Data.Enums;
using System.Security.Claims;

namespace DemoProject.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(x => x.Type == "id")?.Value);
        }
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "firstName")?.Value;
        }
        public static string GetUserLastName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "lastName")?.Value;
        }
        public static bool IsLogged(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "id") != null)

                return true;
            else
                return false;
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "userType").Value == UserTypeEnum.Admin.ToString())
                return true;
            else
                return false;
        }
    }
}
