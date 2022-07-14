using ARMDataManager.Library.Internal.DataAccess;
using ARMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDataManager.Library.DataAccess
{
    public class UsernameData
    {
        private readonly IConfiguration _config;

        public UsernameData(IConfiguration config)
        {
            this._config = config;
        }
        public List<UsernameModel> GetUserByName(string name)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { EmailAddress = name };
            var output = sql.LoadData<UsernameModel, dynamic>("dbo.spUsernameLookup", p, "ARMData");
            return output;
        }
    }
}
