using ARMDataManager.Library.Models;
using System.Collections.Generic;

namespace ARMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string id);
    }
}