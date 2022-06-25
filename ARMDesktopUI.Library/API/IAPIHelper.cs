using ARMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace ARMDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}