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
    public class UserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            this._config = config;
        }
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new {id = id};
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "ARMData");
            return output;
        }
    }
}