using ARMDataManager.Library.Internal.DataAccess;
using ARMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDataManager.Library.DataAccess
{
    public class UsernameData
    {
        public List<UsernameModel> GetUserByName(string name)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { EmailAddress = name };
            var output = sql.LoadData<UsernameModel, dynamic>("dbo.spUsernameLookup", p, "ARMData");
            return output;
        }
    }
}
